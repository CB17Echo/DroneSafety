#load "../Models/WiFi.csx"

using Microsoft.Azure.Documents.Spatial;
using System;
using System.Collections.Generic;

static Random RNG = new Random();

public static int MinsToConnections(int mins, double modifier)
{
    //An empirical model of number of connections based on time of day
    double trueConnections = -0.0913*Math.Pow(mins/60.0, 3)
                             + 2.4725*Math.Pow(mins/60.0, 2)
                             - 4.8756*mins/60.0 - 2.3972;
    return (int)Math.Round(trueConnections*modifier);
}

public static int GetRandomModifier()
{
    return RNG.Next(-50, 50);
}

public static int GetConnections(DateTime time, double modifier, TraceWriter log)
{
    int baseConnections = MinsToConnections(time.Hour * 60 + time.Minute, modifier);
    int realConnections = Math.Max(0, GetRandomModifier() + baseConnections);
    Console.Write($"Calculated {realConnections} from base {baseConnections}");
    return realConnections;
}
public static void Run(TimerInfo myTimer, out WiFi[] datapoints, TraceWriter log)
{
    log.Info($"C# WiFi Timer trigger function executed at: {DateTime.Now}");
    DateTime time = DateTime.Now;
    datapoints = new WiFi[] {
        new WiFi {
            Location = new Point(0.119219, 52.205576), //Waffle man, Market
            Connections = GetConnections(time, 1.1, log),
            Time = time
        },
        new WiFi {
            Location = new Point(0.122259, 52.201987), //Downing site
            Connections = GetConnections(time, 0.9, log),
            Time = time
        },
        new WiFi {
            Location = new Point(0.1168093, 52.20485), //King's chapel
            Connections = GetConnections(time, 0.5, log),
            Time = time
        },
    };
}