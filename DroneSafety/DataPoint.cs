using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Documents.Spatial;

namespace DroneSafety
{

    class DataPoint
    {
        public string DataType;
        public int Time;
        public Geometry Location;
        public int Radius;
        public int Data_ID;
    }

}
