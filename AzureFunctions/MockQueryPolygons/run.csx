using Microsoft.Azure.Documents.Client;
using Microsoft.Azure.Documents.Linq;
using Microsoft.Azure.Documents.Spatial;
using System.Configuration;
using System.Net;

public class Location {public Polygon location { get; set; }};

public static async Task<HttpResponseMessage> Run(HttpRequestMessage req, TraceWriter log)
{
    log.Info($"C# HTTP trigger function processed a request. RequestUri={req.RequestUri}");
    var Location = new Point(52.209076, 0.123335);
    var Client = new DocumentClient(new Uri(ConfigurationManager.AppSettings["DocumentDbUri"]), ConfigurationManager.AppSettings["DocumentDbKey"]);
    var Query = Client.CreateDocumentQuery<Location>(UriFactory.CreateDocumentCollectionUri("MockData", "polygons"), new FeedOptions { EnableScanInQuery = true }).Where(a => a.location.Distance(Location) < 1000);
    int num = 0;
    foreach (object polygon in Query)
    {
        num++;
    }
    return req.CreateResponse(HttpStatusCode.OK, num.ToString());
}