namespace LangtonsAnts
{
    public class Ant
    {

        private World _world;
        public string[] Compass = { "North", "East", "South", "West" };
        public int Direction;
        public Location CurrentLocation;
        private int _locationIndex;

        public World World { get => _world; set => _world = value; }

        public Ant(World world)
        {
            this._world = world;
            Direction = 0;
            CurrentLocation = (Location)World.Locations[0].Clone();
            _locationIndex = 0;
        }

        private void SwitchColour()
        {
            CurrentLocation.Colour = CurrentLocation.Colour == "white" ? "black" : "white";
            World.Locations[_locationIndex].Colour = CurrentLocation.Colour;
        }

        public void Move(int times)
        {
            for (var i = 1; i <= times; i++)
            {
                Move();
            }
        }


        public void Move()
        {
            // change direction
            Direction = CurrentLocation.Colour == "white" ? TurnRight() : TurnLeft();

            // change colour
            SwitchColour();

            // move forward one step
            MoveForward();

            // check current location exists within the world
            UpdateLocation();
        }

        private void MoveForward()
        {
            switch (Compass[Direction])
            {
                case "North":
                    MoveNorth();
                    break;
                case "West":
                    MoveWest();
                    break;
                case "East":
                    MoveEast();
                    break;
                case "South":
                    MoveSouth();
                    break;
            }
        }

        private void UpdateLocation()
        {
            if (!World.Locations.Exists(x => x.XCoordinate == CurrentLocation.XCoordinate && x.YCoordinate == CurrentLocation.YCoordinate))
            {
                CreateNewLocation();
            }
            else
            {
                UpdateCurrentLocation();
            }
        }

        private void UpdateCurrentLocation()
        {
            var visitedLocation =
                World.Locations.Find(
                    x =>
                    x.XCoordinate == CurrentLocation.XCoordinate && x.YCoordinate == CurrentLocation.YCoordinate);
            CurrentLocation.Colour = visitedLocation.Colour;
            _locationIndex = World.Locations.IndexOf(visitedLocation);
        }

        private void CreateNewLocation()
        {
            Location newLocation = new Location { XCoordinate = CurrentLocation.XCoordinate, YCoordinate = CurrentLocation.YCoordinate, Colour = "white" };
            World.Locations.Add(newLocation);
            CurrentLocation = (Location)newLocation.Clone();
            _locationIndex += 1;
        }

        private int TurnRight()
        {
            int direction = Direction + 1;
            if (direction <= 3) return direction;
            direction = 0;
            return direction;
        }

        private int TurnLeft()
        {
            int direction = Direction - 1;
            if (direction >= 0) return direction;
            direction = 3;
            return direction;
        }

        private void MoveSouth()
        {
            CurrentLocation.YCoordinate -= 1;
        }

        private void MoveEast()
        {
            CurrentLocation.XCoordinate += 1;
        }

        private void MoveWest()
        {
            CurrentLocation.XCoordinate -= 1;
        }

        private void MoveNorth()
        {
            CurrentLocation.YCoordinate += 1;
        }
    }

}
