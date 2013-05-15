using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BalloonsPops
{
    public class GameBoard
    {
        private char[,] gameBoard = new char[25, 8];
        private int count = 0;
        private int broya4 = 50;

        public int ShootCounter
        {
            get
            {
                return count;
            }
        }

        public int RemainingBaloons
        {
            get
            {
                return broya4;
            }
        }

        public void GenerateNewGame()
        {
            Console.WriteLine("Welcome to “Balloons Pops” game. Please try to pop the balloons. Use 'top' to view the top scoreboard, 'restart' to start a new game and 'exit' to quit the game.");
            broya4 = 50;
            FillBlankGameBoard();
            Random random = new Random();

            Coordinates coordinate = new Coordinates();

            for (int row = 0; row < 10; row++)
            {
                for (int coll = 0; coll < 5; coll++)
                {
                    coordinate.PositionX = row;
                    coordinate.PositionY = coll;

                    AddNewBaloonToGameBoard(coordinate, (char)(random.Next(1, 5) + (int)'0'));
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

        private void FillBlankGameBoard()
        {
            //printing blank spaces
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 25; j++)
                {
                    gameBoard[j, i] = ' ';
                }
            }

            //printing firs row 
            for (int i = 0; i < 4; i++)
            {
                gameBoard[i, 0] = ' ';
            }

            char counter = '0';

            for (int i = 4; i < 25; i++)
            {
                if ((i % 2 == 0) && counter <= '9') gameBoard[i, 0] = (char)counter++;
                else gameBoard[i, 0] = ' ';
            }

            //printing second row
            for (int i = 3; i < 24; i++)
            {
                gameBoard[i, 1] = '-';
            }

            //printing left game board wall
            counter = '0';

            for (int i = 2; i < 8; i++)
            {
                if (counter <= '4')
                {
                    gameBoard[0, i] = counter++;
                    gameBoard[1, i] = ' ';

                    gameBoard[2, i] = '|';
                    gameBoard[3, i] = ' ';
                }
            }

            //printing down game board wall
            for (int i = 3; i < 24; i++)
            {
                gameBoard[i, 7] = '-';
            }

            //printing right game board wall
            for (int i = 2; i < 7; i++)
            {
                gameBoard[24, i] = '|';
            }
        }

        public void PrintGameBoard()
        {
            for (int row = 0; row < 8; row++)
            {
                for (int coll = 0; coll < 25; coll++)
                {
                    Console.Write(gameBoard[coll, row]);
                }

                Console.WriteLine();
            }

            Console.WriteLine();
        }

        public void Shoot(Coordinates coordinate)
        {
            char currentBaloon;
            currentBaloon = Get(coordinate);
            Coordinates tempCoordinates = new Coordinates();

            if (currentBaloon < '1' || currentBaloon > '4')
            {
                Console.WriteLine("Illegal move: cannot pop missing ballon!");
                return;
            }

            AddNewBaloonToGameBoard(coordinate, '.');
            broya4--;

            tempCoordinates.PositionX = coordinate.PositionX - 1;
            tempCoordinates.PositionY = coordinate.PositionY;

            while (currentBaloon == Get(tempCoordinates))
            {
                AddNewBaloonToGameBoard(tempCoordinates, '.');
                broya4--;
                tempCoordinates.PositionX--;
            }

            tempCoordinates.PositionX = coordinate.PositionX + 1; 
            tempCoordinates.PositionY = coordinate.PositionY;

            while (currentBaloon == Get(tempCoordinates))
            {
                AddNewBaloonToGameBoard(tempCoordinates, '.');
                broya4--;
                tempCoordinates.PositionX++;
            }

            tempCoordinates.PositionX = coordinate.PositionX;
            tempCoordinates.PositionY = coordinate.PositionY - 1;

            while (currentBaloon == Get(tempCoordinates))
            {
                AddNewBaloonToGameBoard(tempCoordinates, '.');
                broya4--;
                tempCoordinates.PositionY--;
            }

            tempCoordinates.PositionX = coordinate.PositionX;
            tempCoordinates.PositionY = coordinate.PositionY + 1;

            while (currentBaloon == Get(tempCoordinates))
            {
                AddNewBaloonToGameBoard(tempCoordinates, '.');
                broya4--;
                tempCoordinates.PositionY++;
            }

            count++;
            LandFlyingBaloons();
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
    }
}
