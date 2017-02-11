using Microsoft.Azure.Documents.Spatial;
using System.Net;


public class Location { public Polygon location { get; set; } public string name { get; set; } };

public static HttpResponseMessage Run(HttpRequestMessage req, out Location[] polygons, TraceWriter log)
{
    log.Info($"C# HTTP trigger function processed a request. RequestUri={req.RequestUri}");
    //See documentation for Polygon: https://msdn.microsoft.com/en-us/library/azure/microsoft.azure.documents.spatial.polygon.aspx
    var JesusGreen = new Polygon(
        new[]
        {
            //In anti-clockwise order
            new Position(52.211722, 0.118803),
            new Position(52.213174, 0.125398),
            new Position(52.210849, 0.126959),
            new Position(52.210910, 0.122061),
            new Position(52.211722, 0.118803)
        }
    );
    var TheOrchard = new Polygon(
        new[]
        {
            new Position(52.210088, 0.121890),
            new Position(52.209519, 0.123026),
            new Position(52.209299, 0.122170),
            new Position(52.210088, 0.121890)
        }
    );
    polygons = new Location[] {
        new Location{ name = "Jesus Green", location = JesusGreen },
        new Location{ name = "The Orchard", location = TheOrchard }
    };
    return req.CreateResponse(HttpStatusCode.OK, "Points created");
}