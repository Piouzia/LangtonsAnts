using System.Collections.Generic;


namespace LangtonsAnts
{
    /**
     * Class World : debut du jeu, permet de positionner la fourmi 
     * La fourmi est positionner au centre 
     *
     */

    public class World
    {
        //liste permettant de stocker la position de notre fourmi
        public List<Location> Locations;

        public World()
        {
            Location location = new Location { XCoordinate = 3, YCoordinate = 3, Colour = "white" };
            Locations = new List<Location> { location };
        }
    }
}
