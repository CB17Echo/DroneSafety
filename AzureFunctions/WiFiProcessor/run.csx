#load "../Models/Circle.csx"
#load "../Models/WiFi.csx"
#r "Microsoft.Azure.WebJobs.Extensions.DocumentDB"
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using System;
using System.Configuration;

public static void Run(TimerInfo myTimer,
                       //[DocumentDB] DocumentClient client,
                       [DocumentDB("MockData", "hazards")] IAsyncCollector<Circle> hazards,
                       TraceWriter log)
{
    log.Info($"C# Timer trigger function executed at: {DateTime.Now}");
    DocumentClient client = new DocumentClient(new Uri(ConfigurationManager.AppSettings["DocumentDbUri"]), ConfigurationManager.AppSettings["DocumentDbKey"]);
    Database database = client.CreateDatabaseIfNotExistsAsync(new Database { Id = "MockData" }).Result;
    DocumentCollection hazardCollection = client.CreateDocumentCollectionIfNotExistsAsync(database.SelfLink, new DocumentCollection { Id = "hazards" }).Result;
    Collector collector = new Collector
    {
        client = client,
        outputCollector = hazards,
        hazardDBCollection = hazardCollection
    };
    client.CreateDocumentQuery<WiFi>(UriFactory.CreateDocumentCollectionUri("MockData", "datapoints"))
                            .Where(a => a.Time > DateTime.Now.AddMinutes(-2) && a.Type == "WiFi")
                            .AsParallel().ForAll(item => collector.Process(item));
}

public class Collector
{
    public IAsyncCollector<CircularHazard> outputCollector { get; set; }
    public DocumentClient client { get; set; }
    public DocumentCollection hazardDBCollection { get; set; }

    public void Process(WiFi datapoint)
    {
        var current = client
                .CreateDocumentQuery<Circle>(UriFactory.CreateDocumentCollectionUri("MockData", "hazards"))
                .Where(a => a.StartTime == datapoint.Time && a.Centre == datapoint.Location);
        if (current.AsEnumerable().Any()) { return; }
        Circle newCircle = new Circle
        {
            Centre = datapoint.Location,
            StartTime = datapoint.Time,
            EndTime = datapoint.Time.AddMinutes(1),
            Radius = 100,
            HazardLevel = datapoint.Connections / 50
        };
        outputCollector.AddAsync(newCircle);
    }
}