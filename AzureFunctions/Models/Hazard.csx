using System;

abstract public class Hazard
{
    public int HazardLevel { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public string Type
    {
        get
        {
            return GetType().Name;
        }
    }
}
