using LangtonsAnts;
using NUnit.Framework;


namespace LangtonsAntsTests
{
    class AntTest
    {
        [Test]
        public void Ant_should_start_in_middle_of_world()
        {
            //initilisation de world
            World world = new World();
            //initialisation de notre nouvel fourmi
            Ant ant = new Ant(world);

            Location currentLocation = new Location { XCoordinate = 3, YCoordinate = 3 };
            Assert.That(ant.World.Locations[0], Is.EqualTo(currentLocation));
        }

        [Test]
        public void Ant_starts_on_a_white_square()
        {
            World world = new World();
            new Ant(world);

            Assert.That("white", Is.EqualTo(world.Locations[0].Colour));
        }

        [Test]
        public void Ant_starts_facing_north()
        {
            World world = new World();
            Ant ant = new Ant(world);

            Assert.That(ant.Compass[ant.Direction], Is.EqualTo("North"));
        }

        [Test]
        public void After_ant_moves_first_square_turns_black()
        {
            World world = new World();
            Ant ant = new Ant(world);

            ant.Move();

            Assert.That(ant.World.Locations[0].Colour, Is.EqualTo("black"));

        }

        [Test]
        public void After_ant_moves_ant_is_facing_east()
        {
            World world = new World();
            Ant ant = new Ant(world);

            ant.Move();

            Assert.That(ant.Compass[ant.Direction], Is.EqualTo("East"));
        }

        [Test]
        public void Ant_moves_right_if_location_colour_is_white()
        {
            World world = new World();
            Ant ant = new Ant(world);

            ant.Move();

            Location currentLocation = new Location();
            currentLocation.XCoordinate = 4;
            currentLocation.YCoordinate = 3;
            currentLocation.Colour = "white";

            Assert.That(ant.CurrentLocation, Is.EqualTo(currentLocation));
        }

        [Test]
        public void Ant_moves_two_steps()
        {
            World world = new World();
            Ant ant = new Ant(world);

            ant.Move();
            ant.Move();

            Location currentLocation = new Location { XCoordinate = 4, YCoordinate = 2, Colour = "white" };

            Assert.That(ant.CurrentLocation, Is.EqualTo(currentLocation));
        }

        [Test]
        public void Ant_moves_three_steps()
        {
            World world = new World();
            Ant ant = new Ant(world);

            ant.Move();
            ant.Move();
            ant.Move();

            Location currentLocation = new Location { XCoordinate = 3, YCoordinate = 2, Colour = "white" };

            Assert.That(ant.CurrentLocation, Is.EqualTo(currentLocation));

            Location previousLocation = new Location { Colour = "black", XCoordinate = 4, YCoordinate = 3 };

            Assert.That(ant.World.Locations[1], Is.EqualTo(previousLocation));
        }

        [Test]
        public void Ant_moves_four_steps()
        {
            World world = new World();
            Ant ant = new Ant(world);

            ant.Move(4);

            Location currentLocation = new Location { XCoordinate = 3, YCoordinate = 3, Colour = "black" };

            Assert.That(ant.CurrentLocation, Is.EqualTo(currentLocation));

            Location previousLocation = new Location { Colour = "black", XCoordinate = 4, YCoordinate = 3 };

            Assert.That(ant.World.Locations[1], Is.EqualTo(previousLocation));
        }

        [Test]
        public void Ant_moves_five_steps()
        {
            World world = new World();
            Ant ant = new Ant(world);

            ant.Move(5);

            Location currentLocation = new Location { XCoordinate = 2, YCoordinate = 3, Colour = "white" };

            Assert.That(ant.CurrentLocation, Is.EqualTo(currentLocation));

            Location previousLocation = new Location { Colour = "white", XCoordinate = 3, YCoordinate = 3 };

            Assert.That(ant.World.Locations[0], Is.EqualTo(previousLocation));
        }

        [Test]
        public void Ant_moves_six_steps()
        {
            World world = new World();
            Ant ant = new Ant(world);

            ant.Move(6);

            Location currentLocation = new Location { XCoordinate = 2, YCoordinate = 4, Colour = "white" };

            Assert.That(ant.CurrentLocation, Is.EqualTo(currentLocation));
        }
    }
}
