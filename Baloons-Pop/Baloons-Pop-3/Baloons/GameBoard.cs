using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BalloonsPops
{
    public class GameBoard
    {
        private int width;
        private int height;
        private char[,] gameBoard;
        private Balloon[,] balloons;
        private int count = 0;
        private int remainingBalloons = 50;

        public GameBoard(int width, int height)
        {
            this.Width = width;
            this.Height = height;
            this.gameBoard = new char[this.Width, this.Height];
            this.balloons = new Balloon[this.Height, this.Width];
        }

        public int Width
        {
            get
            {
                return this.width;
            }

            private set
            {
                this.width = value;
            }
        }

        public int Height
        {
            get
            {
                return this.height;
            }

            private set
            {
                this.height = value;
            }
        }

        public int ShootCounter
        {
            get
            {
                return this.count;
            }
        }

        public int RemainingBaloons
        {
            get
            {
                return this.remainingBalloons;
            }
        }

        //public void GenerateNewGame()
        //{
        //    Console.WriteLine("Welcome to “Balloons Pops” game. Please try to pop the balloons. Use 'top' to view the top scoreboard, 'restart' to start a new game and 'exit' to quit the game.");
        //    remainingBalloons = 50;
        //    FillBlankGameBoard();
        //    Random random = new Random();

        //    Coordinates coordinate = new Coordinates();

        //    for (int row = 0; row < 10; row++)
        //    {
        //        for (int col = 0; col < 5; col++)
        //        {
        //            coordinate.PositionX = row;
        //            coordinate.PositionY = col;

        //            AddNewBaloonToGameBoard(coordinate, (char)(random.Next(1, 5) + (int)'0'));
        //        }
        //    }
        //}

        public void GenerateNewGame()
        {
            this.remainingBalloons = 50;
            Random randomGenerator = new Random();

            for (int row = 0; row < this.Height; row++)
            {
                for (int col = 0; col < this.Width; col++)
                {
                    this.balloons[row, col] = new Balloon(randomGenerator.Next(1, 5));
                }
            }
        }

        private void AddNewBaloonToGameBoard(Coordinates coordinate, char value)
        {
            int xPosition,
                yPosition;

            xPosition = 4 + coordinate.PositionX * 2;
            yPosition = 2 + coordinate.PositionY;

            gameBoard[xPosition, yPosition] = value;
        }

        private char Get(Coordinates coordinate)
        {
            int xPosition, 
                yPosition;

            if (coordinate.PositionX < 0 || coordinate.PositionY < 0 || coordinate.PositionX > 9 || coordinate.PositionY > 4)
            {
                return 'e'; //TODO
            }

            xPosition = 4 + coordinate.PositionX * 2;

            yPosition = 2 + coordinate.PositionY;
            return gameBoard[xPosition, yPosition];
        }

        private void Initialise()
        {
            //assign initial value to all cells
            for (int i = 0; i < this.Height; i++)
            {
                for (int j = 0; j < this.Width; j++)
                {
                    gameBoard[j, i] = ' ';
                }
            }
        }

        //public void PrintGameBoard()
        //{
        //    for (int row = 0; row < this.Height; row++)
        //    {
        //        for (int col = 0; col < this.Width; col++)
        //        {
        //            Console.Write(this.balloons[row, col].Value);
        //        }

        //        Console.WriteLine();
        //    }

        //    Console.WriteLine();
        //}

        public void Shoot(int row, int col)
        {
            int balloonValue;
            balloonValue = this.balloons[row, col].Value;
            int currentRow = 0, currentCol = 0;

            if (balloonValue < 1 || balloonValue > 4)
            {
                Console.WriteLine("Illegal move: cannot pop missing ballon!");
                return;
            }

            balloons[row, col].Value = 0;
            this.remainingBalloons--;

            currentRow = row - 1;
            currentCol = col;

            while (balloonValue == this.balloons[currentRow, currentCol].Value)
            {
                this.balloons[currentRow, currentCol].Value = 0;
                remainingBalloons--;
                currentRow--;
            }

            currentRow = row + 1; 
            currentCol = col;

            while (balloonValue == this.balloons[currentRow, currentCol].Value)
            {
                this.balloons[currentRow, currentCol].Value = 0;
                remainingBalloons--;
                currentRow++;
            }

            currentRow = row;
            currentCol = col - 1;

            while (balloonValue == this.balloons[currentRow, currentCol].Value)
            {
                this.balloons[currentRow, currentCol].Value = 0;
                remainingBalloons--;
                currentCol--;
            }

            currentRow = row;
            currentCol = col + 1;

            while (balloonValue == this.balloons[currentRow, currentCol].Value)
            {
                this.balloons[currentRow, currentCol].Value = 0;
                remainingBalloons--;
                currentCol++;
            }

            count++;
            //LandFlyingBaloons();
        }

        private void Swap(Coordinates c, Coordinates c1)
        {
            char tmp = Get(c);
            AddNewBaloonToGameBoard(c, Get(c1));
            AddNewBaloonToGameBoard(c1, tmp);
        }

        private void LandFlyingBaloons()
        {
            Coordinates c = new Coordinates();
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j <= 4; j++)
                {
                    c.PositionX = i;
                    c.PositionY = j;
                    if (Get(c) == '.')
                    {
                        for (int k = j; k > 0; k--)
                        {
                            Coordinates tempCoordinates = new Coordinates();
                            Coordinates tempCoordinates1 = new Coordinates();
                            tempCoordinates.PositionX = i;
                            tempCoordinates.PositionY = k;
                            tempCoordinates1.PositionX = i;
                            tempCoordinates1.PositionY = k - 1;
                            Swap(tempCoordinates, tempCoordinates1);
                        }
                    }
                }
            }
        }

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
            catch(ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }

            
        }

        public override string ToString()
        {
            Console.Write("  ");

            for (int i = 0; i < this.Width; i++)
            {
                Console.Write("{0, 3}", i);
            }

            Console.WriteLine();
            Console.Write("  ");

            for (int i = 0; i < this.Width; i++)
            {
                Console.Write("{0, 3}", "~");
            }

            Console.WriteLine();

            for (int row = 0; row < this.Height; row++)
            {
                Console.Write(row + "|");

                for (int i = 0; i < this.Width; i++)
                {
                    Console.Write("{0, 3}", this.balloons[row, i].Value);
                }

                Console.WriteLine();
            }

            return string.Empty;
        }
    }
}
