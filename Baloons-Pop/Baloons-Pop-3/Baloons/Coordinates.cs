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

            set
            {
                if (0 > value || value > 9)
                {
                    throw new ArgumentOutOfRangeException("The position of X should be between 1 and 8");
                }

                this.positionX = value;
            }
        }

        public int PositionY
        {
            get
            {
                return this.positionY;
            }

            set
            {
                if (0 > value || value > 4)
                {
                    throw new ArgumentOutOfRangeException("The position of Y should be between 1 and 3");
                }

                this.positionY = value;
            }
        }

        public Coordinates() { }

        public Coordinates(int x, int y)
        {
            this.PositionX = x;
            this.PositionY = y;
        }

        /// <summary>
        /// Converts input coordinates from string to integer values 
        /// </summary>
        /// <param name="input">String input value for coordinates</param>
        /// <returns>Converted coordinate values</returns>
        public bool ConvertCoordinates(string input)
        {
            char[] separators = { ' ', ',' };

            string[] coordinates = input.Split(separators);

            if (coordinates.Count<string>() != 2)
            {
                return false;
            }

            string xCoordinate = coordinates[0].Trim();
            int positionX;
            if (!int.TryParse(xCoordinate, out positionX)) 
            {
                return false;
            }


            string yCoordinate = coordinates[1].Trim();
            int positionY;
            if (!int.TryParse(yCoordinate, out positionY))
            {
                return false;
            }

            this.positionX = positionX;
            this.PositionY = positionY;
            
            return true;
        }
    }
}
