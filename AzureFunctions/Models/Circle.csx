#load "Hazard.csx"
using Microsoft.Azure.Documents.Spatial;
using System;

public class Circle : Hazard 
{
    public Point Centre { get;  set; }
    public int Radius { get; set; } //Unit is metres
}
