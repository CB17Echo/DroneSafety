using Microsoft.Azure.Documents.Spatial;
using System;

public abstract class DataPoint
{
    public DateTime Time { get; set; }
    public Point Location { get; set; }
    public string Type
    {
        get
        {
            return GetType().Name;
        }
    }
}
