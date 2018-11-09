using System;

namespace DataLayer
{
    public class Poi
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Lat { get; private set; }
        public decimal Long { get; private set; }

        private Poi()
        {
            //EF
        }

        public Poi(string name, string description, decimal lon, decimal lat)
        {
            Id = new Guid();
            Name = name;
            Description = description;
            Lat = lat;
            Long = lon;
        }
    }
}
