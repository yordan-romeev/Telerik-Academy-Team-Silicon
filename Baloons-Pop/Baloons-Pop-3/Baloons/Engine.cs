using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BalloonsPops
{
    public class Engine
    {
        private int boardWidth;
        private int boardHeight;
        private int remainingBalloons;
        private int counter;
        private Balloon[,] board;

        private int BoardWidth
        {
            get
            {
                return this.boardWidth;
            }

            set
            {
                this.boardWidth = value;
            }
        }

        private int BoardHeight
        {
            get
            {
                return this.boardHeight;
            }

            set
            {
                this.boardHeight = value;
            }
        }

        public int RemainingBalloons
        {
            get
            {
                return this.remainingBalloons;
            }
        }

        public int ShootCounter
        {
            get
            {
                return this.counter;
            }
        }

        public Engine()
        {
            this.BoardWidth = 10;
            this.BoardHeight = 4;
            this.counter = 0;
            this.remainingBalloons = this.BoardWidth * this.BoardHeight;
            this.board = new Balloon[this.BoardHeight, this.BoardWidth];
        }

        public Engine(int width, int height)
        {
            this.BoardWidth = width;
            this.BoardHeight = height;
            this.counter = 0;
            this.remainingBalloons = this.BoardWidth * this.BoardHeight;
            this.board = new Balloon[this.BoardHeight, this.BoardWidth];
        }

        public void NewGame()
        {
            this.remainingBalloons = this.BoardWidth * this.BoardHeight;
            Random randomGenerator = new Random();

            for (int row = 0; row < this.BoardHeight; row++)
            {
                for (int col = 0; col < this.BoardWidth; col++)
                {
                    this.board[row, col] = new Balloon(randomGenerator.Next(1, 5));
                }
            }
        }

        public void Shoot(int row, int col)
        {
            int balloonValue;
            balloonValue = this.board[row, col].Value;
            int currentRow = 0, currentCol = 0;

            if (balloonValue < 1 || balloonValue > 4)
            {
                Console.WriteLine("Illegal move: cannot pop missing ballon!");
                return;
            }

            board[row, col].Value = 0;
            this.remainingBalloons--;

            currentRow = row - 1;
            currentCol = col;

            while (currentRow >= 0 && balloonValue == this.board[currentRow, currentCol].Value)
            {
                this.board[currentRow, currentCol].Value = 0;
                remainingBalloons--;
                currentRow--;
            }

            currentRow = row + 1;
            currentCol = col;

            while (currentRow < this.BoardHeight && balloonValue == this.board[currentRow, currentCol].Value)
            {
                this.board[currentRow, currentCol].Value = 0;
                remainingBalloons--;
                currentRow++;
            }

            currentRow = row;
            currentCol = col - 1;

            while (currentCol >= 0 && balloonValue == this.board[currentRow, currentCol].Value)
            {
                this.board[currentRow, currentCol].Value = 0;
                remainingBalloons--;
                currentCol--;
            }

            currentRow = row;
            currentCol = col + 1;

            while (currentCol < this.BoardWidth && balloonValue == this.board[currentRow, currentCol].Value)
            {
                this.board[currentRow, currentCol].Value = 0;
                remainingBalloons--;
                currentCol++;
            }

            this.counter++;
            //LandFlyingBaloons();
        }


        //private void LandFlyingBaloons()
        //{
        //    Coordinates c = new Coordinates();
        //    for (int i = 0; i < 10; i++)
        //    {
        //        for (int j = 0; j <= 4; j++)
        //        {
        //            c.PositionX = i;
        //            c.PositionY = j;
        //            if (Get(c) == '.')
        //            {
        //                for (int k = j; k > 0; k--)
        //                {
        //                    Coordinates tempCoordinates = new Coordinates();
        //                    Coordinates tempCoordinates1 = new Coordinates();
        //                    tempCoordinates.PositionX = i;
        //                    tempCoordinates.PositionY = k;
        //                    tempCoordinates1.PositionX = i;
        //                    tempCoordinates1.PositionY = k - 1;
        //                    //Swap(tempCoordinates, tempCoordinates1);
        //                }
        //            }
        //        }
        //    }
        //}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="coordinates"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        public void ReadInput(ref Coordinates coordinates, ref Command command, out InputType inputType)
        {
            inputType = InputType.Invalid;

            try
            {
                Console.Write("Enter action (coordinates or a command): ");
                string consoleInput = Console.ReadLine();

                coordinates = new Coordinates();
                if (coordinates.ConvertCoordinates(consoleInput))
                {
                    inputType = InputType.Coordinates;
                }

                command = new Command();
                if (command.ConvertCommand(consoleInput))
                {
                    inputType = InputType.Command;
                }
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }


        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("  ");

            for (int i = 0; i < this.BoardWidth; i++)
            {
                sb.Append(String.Format("{0, 3}", i));
            }

            sb.Append(Environment.NewLine);
            sb.Append("  ");

            for (int i = 0; i < this.BoardWidth; i++)
            {
                sb.Append(String.Format("{0, 3}", "~"));
            }

            sb.Append(Environment.NewLine);

            for (int row = 0; row < this.BoardHeight; row++)
            {
                sb.Append(row + "|");

                for (int i = 0; i < this.BoardWidth; i++)
                {
                    sb.Append(String.Format("{0, 3}", this.board[row, i].Value));
                }

                sb.Append(Environment.NewLine);
            }

            return sb.ToString();
        }
    }
}
