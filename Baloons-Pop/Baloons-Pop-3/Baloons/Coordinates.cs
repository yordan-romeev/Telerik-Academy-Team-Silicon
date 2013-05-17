using System;
using System.Linq;

namespace BalloonsPops
{
    public class Coordinates
    {
        private int row;
        private int column;

        public int Row
        {
            get
            {
                return this.row;
            }

            private set
            {

                this.row = value;
            }
        }

        public int Column
        {
            get
            {
                return this.column;
            }

            private set
            {

                this.column = value;
            }
        }

        public Coordinates(int x, int y)
        {
            this.Row = x;
            this.Column = y;
        }
    }
}
