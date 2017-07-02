using System;

namespace LangtonsAnts
{
    public class Location : ICloneable
    {
        public string Colour;
        public int XCoordinate { get; set; }
        public int YCoordinate { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Location l = (Location)obj;
            return (XCoordinate == l.XCoordinate) && (YCoordinate == l.YCoordinate);
        }

        public override int GetHashCode()
        {
            // ReSharper disable once BaseObjectGetHashCodeCallInGetHashCode
            return base.GetHashCode();
        }

        public object Clone()
        {
            Location location = new Location
            {
                XCoordinate = XCoordinate,
                YCoordinate = YCoordinate,
                Colour = Colour
            };

            return location;
        }
    }
}
