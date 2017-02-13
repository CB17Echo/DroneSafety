using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Microsoft.Azure.Documents.Linq;
using Newtonsoft.Json;
using System.IO;
using Microsoft.Azure.Documents.Spatial;
using DroneSafety;

namespace DroneSafety
{
    class Program
    {
        
        private static async Task FileToDataPoints(string filename)
        {
            // using (StreamReader r = new StreamReader(filename))
            using (StreamReader r = new StreamReader("D:/Group Project/bus_positions_2016-12/12/01/1480550426_2016-12-01-00-00-26.json"))
            {
                string json = r.ReadToEnd();
                dynamic array = JsonConvert.DeserializeObject(json);

                List<DataPoint> list = new List<DataPoint>();

                foreach (var item in array.entities)
                {
                    DataPoint p = new DataPoint();
                    p.DataType = "Bus Data";
                    p.Location = new Point((float) item.latitude, (float) item.longitude);
                    p.Time = item.received_timestamp;
                    p.Data_ID = item.vehicle_id;
                    list.Add(p);
                }

                await DocDatabase.AddDataPoints(list);
            }
        }

        static void Main(string[] args)
        {
            try
            {
                DocDatabase.CreateDocumentClient();
                List<DataPoint> list = DocDatabase.GetDataPoints(new Point(51.90286636352539, -0.22166046500205994), 10000);
                foreach (DataPoint datapoint in list)
                {
                    Console.WriteLine(datapoint.Data_ID);
                }
                Console.ReadLine();
            } catch (Exception e)
            {
                Console.WriteLine(e);
                Console.ReadLine();
            }
        }

        private static async Task getPaths()
        {
            String[] allfiles = System.IO.Directory.GetFiles("D:\\Group Project\\", "*.json*", System.IO.SearchOption.AllDirectories);

            foreach (string file in allfiles)
            {
                await FileToDataPoints(file);
            }
        }
    }
}
