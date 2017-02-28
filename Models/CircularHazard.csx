#load "Hazard.csx"
using Microsoft.Azure.Documents.Spatial;
using System;

public class CircularHazard : Hazard
{
    public new Point Location { get; set; }
    public int Radius { get; set; } //Unit is meters
    public CircularHazard()
    {
        Shape = "Circle";
    }
}
