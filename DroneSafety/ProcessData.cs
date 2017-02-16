using Microsoft.Azure.Documents.Spatial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DroneSafety
{
    class ProcessData
    {
        private HeatMap mHeatMap = null;

        public void ProcessDataPoints(List<DataPoint> datapoints)
        {
            foreach(DataPoint datapoint in datapoints)
            {
                switch (datapoint.DataType)
                {
                    case "Bus Data": ProcessBusPoint(datapoint);
                        break;
                    default:
                        break;
                }
            }
        }


        // Radius given in metres
        // Convert to degrees to use with heatmap class
        private float MetresToDegrees(float resolution)
        {
            return 1.0f;
        }

        private void ProcessBusPoint(DataPoint datapoint)
        {
            float resolution = mHeatMap.GetResolution();
            
            // if data point resolution < map resolution 
            // add circle 
            // else add point
            
            
        }

        private void ProcessCircle(Point centre, int radius, float resolution, int value)
        {
            float lat = (float) centre.Position.Latitude;
            float lon = (float)centre.Position.Longitude;
            float resolutionDeg = MetresToDegrees(resolution);
            float radiusDeg = MetresToDegrees(radius);

            int radiusSteps = (int)(radiusDeg / resolutionDeg);
            for (int x = 0; x < radiusSteps; x++)
                for (int y = 0; y < radiusSteps; y++)
                {
                    if (x * x + y * y <= radiusSteps * radiusSteps)
                    {
                        float deltaLat = x * radiusDeg;
                        float deltaLon = y * radiusDeg;

                        mHeatMap.AddHazard(lat - deltaLat, lon - deltaLon, value);
                        mHeatMap.AddHazard(lat - deltaLat, lon + deltaLon, value);
                        mHeatMap.AddHazard(lat + deltaLat, lon - deltaLon, value);
                        mHeatMap.AddHazard(lat + deltaLat, lon + deltaLon, value);

                    }
                }

        }

        private void ProcessWifiPoint(DataPoint datapoint)
        {
            // ... 
        }

        private void ProcessPolygon(DataPoint datapoint)
        {
            // ...
        }
    }
}
