#load "../Models/WiFi.csx"

using Microsoft.Azure.Documents.Spatial;
using System;
using System.Collections.Generic;

public static void Run(TimerInfo myTimer, out WiFi[] datapoints, TraceWriter log)
{
    log.Info($"C# WiFi Timer trigger function executed at: {DateTime.Now}");
    datapoints= new WiFi[] {
        new WiFi
            {
                Location = new Point(52.209076, 0.123335), //Jesus college
                Connections = 50,
                Time = DateTime.Now
            }
    };
}