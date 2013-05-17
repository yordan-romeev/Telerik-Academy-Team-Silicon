using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BalloonsPops
{
    public class Coordinates
    {
        private int positionX;
        private int positionY;

        public int PositionX
        {
            get
            {
                return this.positionX;
            }

            private set
            {

                this.positionX = value;
            }
        }

        public int PositionY
        {
            get
            {
                return this.positionY;
            }

            private set
            {

                this.positionY = value;
            }
        }

        public Coordinates() { }

        public Coordinates(int x, int y)
        {
            this.PositionX = x;
            this.PositionY = y;
        }
    }
}
