using System;

namespace CSharpDiscovery.Quest03
{
    public class Campus : PointOfInterest
    {
        public int Capacity { get; set; }

        public Campus()
            : base()
        {
            Capacity = 0;
        }

        public Campus(string name, double latitude, double longitude, int capacity)
            : base(name, latitude, longitude)
        {
            Capacity = capacity;
        }

        public override string ToString()
        {
            return $"{Name} is a campus with a capacity of {Capacity} students";
        }
    }
}
