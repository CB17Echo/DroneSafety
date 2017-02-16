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
            using (StreamReader r = new StreamReader(filename))
            {
                string json = r.ReadToEnd();
                dynamic array = JsonConvert.DeserializeObject(json);

                List<DataPoint> list = new List<DataPoint>();

                foreach (var item in array.entities)
                {
                    DataPoint p = new DataPoint();
                    p.DataType = "Bus Data";
                    p.Shape = "Point";
                    p.Severity = 2;
                    p.Location = new Point((float) item.latitude, (float) item.longitude);
                    p.Time = item.received_timestamp;
                    list.Add(p);
                }

                await DocDatabase.AddDataPoints(list);
            }
        }

        static void Main(string[] args)
        {
            string file = "C:\\Users\\mudit\\Documents\\Development\\DroneSafety\\Data\\1480550426_2016-12-01-00-00-26.json";
            try
            {
                DocDatabase.CreateDocumentClient();
                Console.WriteLine("Written");
                Console.ReadLine();
                FileToDataPoints(file).Wait();
            } catch (Exception e)
            {
                Console.WriteLine(e);
                Console.ReadLine();
            }
        }

        private static async Task AddFiles(string path)
        {
            String[] allfiles = System.IO.Directory.GetFiles(path, "*.json*", System.IO.SearchOption.AllDirectories);

            foreach (string file in allfiles)
            {
                await FileToDataPoints(file);
            }
        }
    }
}
