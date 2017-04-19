using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LangtonsAnts
{
    public class Ant
    {
        public int PositionX { get; private set; }
        public int PositionY { get; private set; }
        public bool EvilAnt { get; private set; }

        public Ant(int positionX, int positionY, bool evil)
        {
            PositionX = positionX;
            PositionY = positionY;
            EvilAnt = evil;
        }

        public void MoveAnt(int x, int y)
        {
            PositionX = x;
            PositionY = y;
        }

    }
}
