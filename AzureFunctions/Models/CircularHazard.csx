#load "Hazard.csx"
using Microsoft.Azure.Documents.Spatial;
using System;

public class CircularHazard : Hazard 
{
    public Point Centre { get;  set; }
    public int Radius { get; set; } //Unit is metres
}
