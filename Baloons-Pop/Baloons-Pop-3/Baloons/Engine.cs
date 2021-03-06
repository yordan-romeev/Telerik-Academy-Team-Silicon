﻿using System;
using System.Linq;
using System.Text;

namespace BalloonsPops
{
    public class Engine
    {
        private int boardWidth;
        private int boardHeight;
        private int remainingBalloons;
        private int numberOfShootings;
        private Balloon[,] board;
        private bool gameOver;
        private bool exit;
        ScoreManager scoreManager;

        public int BoardWidth
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

        public int BoardHeight
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

        public int NumberOfShootings
        {
            get
            {
                return this.numberOfShootings;
            }

            private set
            {
                this.numberOfShootings = value;
            }
        }

        public Engine()
        {
            this.scoreManager = new ScoreManager();
            this.BoardWidth = 10;
            this.BoardHeight = 4;
            this.numberOfShootings = 0;
            this.remainingBalloons = this.BoardWidth * this.BoardHeight;
            this.board = new Balloon[this.BoardHeight, this.BoardWidth];
        }

        public Engine(int width, int height)
        {
            this.scoreManager = new ScoreManager();
            this.BoardWidth = width;
            this.BoardHeight = height;
            this.numberOfShootings = 0;
            this.remainingBalloons = this.BoardWidth * this.BoardHeight;
            this.board = new Balloon[this.BoardHeight, this.BoardWidth];
        }

        public Engine(Balloon[,] balloons)
        {
            this.BoardWidth = balloons.GetLength(1);
            this.BoardHeight = balloons.GetLength(0);
            this.numberOfShootings = 0;
            this.remainingBalloons = this.BoardWidth * this.BoardHeight;
            this.board = balloons;
        }

        /// <summary>
        /// Starts the game loop and execute commands according to player input.
        /// </summary>
        public void Run()
        {
            Console.WriteLine("Welcome to “Balloons Pops” game. Please try to pop the balloons." +  
                "Use 'top' to view the top scoreboard, 'restart' to start a new game and 'exit' to quit the game.");
            NewGame();

            while (true)
            {
                string currentCommand = ReadInput();
                CommandType commandType = CommandParser.GetCommandType(currentCommand);

                try
                {
                    ExecuteCommand(commandType, currentCommand);
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Console.WriteLine(ex.Message);
                }

                if (this.exit)
                {
                    this.scoreManager.SaveTopScoreList();
                    return;
                }

                if (this.gameOver)
                {
                    Console.WriteLine("Congratulations, you've won the game!");
                    SaveScore();
                }
            }
        }

        /// <summary>
        /// Serves as a crossway for the commands, invoked by the Run method. Executes 
        /// the command by given command type.
        /// </summary>
        /// <param name="currentCommand"></param>
        /// <param name="command"></param>
        private void ExecuteCommand(CommandType currentCommand, string command)
        {
            switch (currentCommand)
            {
                case CommandType.TopScore:
                    scoreManager.PrintScoreList();
                    break;
                case CommandType.Restart:
                    NewGame();
                    break;
                case CommandType.Exit:
                    this.exit = true;
                    break;
                case CommandType.Invalid:
                    Console.WriteLine("Invalid command!");
                    break;
                case CommandType.Coordinates:
                    Coordinates coordinates = CommandParser.ParseCoordinates(command);

                    if (coordinates.Row < 0 || this.BoardHeight <= coordinates.Row ||
                        coordinates.Column < 0 || this.BoardWidth <= coordinates.Column)
                    {
                        throw new ArgumentOutOfRangeException(
                            String.Format("First coordinate must be in [0, {0}) range, second in [0, {1})", 
                            this.BoardHeight, 
                            this.BoardWidth));
                    }
                    else
                    {
                        Shoot(coordinates.Row, coordinates.Column);
                    }
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Checks if the score is high enough to be a top score and saves it.
        /// If the score is not high score, it is ignored.
        /// </summary>
        private void SaveScore()
        {
            Person player = new Person(this.numberOfShootings);

            if (this.scoreManager.IsTopScore(player))
            {
                Console.Write("Enter your name: ");
                string playerName = Console.ReadLine();
                player.Name = playerName;
                this.scoreManager.AddToTopScoreList(player);
            }
        }

        /// <summary>
        /// Starts new game
        /// </summary>
        private void NewGame()
        {
            this.gameOver = false;
            this.remainingBalloons = this.BoardWidth * this.BoardHeight;
            this.NumberOfShootings = 0;
            Random randomGenerator = new Random();

            for (int row = 0; row < this.BoardHeight; row++)
            {
                for (int col = 0; col < this.BoardWidth; col++)
                {
                    this.board[row, col] = new Balloon(randomGenerator.Next(1, 5));
                }
            }

            PrintGameBoard();
        }

        /// <summary>
        /// Pops the balloon in the given position and all balloons with the same value, that are
        /// neighbors horizontally or vertically. Calls another function to land 'flying balloons'.
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        private void Shoot(int row, int col)
        {
            int balloonValue;
            balloonValue = this.board[row, col].Value;
            int currentRow = 0, currentCol = 0;

            if (balloonValue < 1 || balloonValue > 4)
            {
                Console.WriteLine("Illegal move: cannot pop missing ballon!");
                return;
            }

            board[row, col].Pop();
            this.remainingBalloons--;

            currentRow = row - 1;
            currentCol = col;

            while (currentRow >= 0 && balloonValue == this.board[currentRow, currentCol].Value)
            {
                this.board[currentRow, currentCol].Pop();
                remainingBalloons--;
                currentRow--;
            }

            currentRow = row + 1;
            currentCol = col;

            while (currentRow < this.BoardHeight && balloonValue == this.board[currentRow, currentCol].Value)
            {
                this.board[currentRow, currentCol].Pop();
                remainingBalloons--;
                currentRow++;
            }

            currentRow = row;
            currentCol = col - 1;

            while (currentCol >= 0 && balloonValue == this.board[currentRow, currentCol].Value)
            {
                this.board[currentRow, currentCol].Pop();
                remainingBalloons--;
                currentCol--;
            }

            currentRow = row;
            currentCol = col + 1;

            while (currentCol < this.BoardWidth && balloonValue == this.board[currentRow, currentCol].Value)
            {
                this.board[currentRow, currentCol].Pop();
                remainingBalloons--;
                currentCol++;
            }

            this.numberOfShootings++;
            LandFlyingBaloons();
            Console.WriteLine(this.RemainingBalloons);
            if (this.RemainingBalloons <= 0)
            {
                this.gameOver = true;
            }
            
            PrintGameBoard();
        }


        private void LandFlyingBaloons()
        {
            for (int col = 0; col < this.BoardWidth; col++)
            {
                LandColumn(col);
            }
        }

        private void LandColumn(int col)
        {
            for (int row = this.BoardHeight - 1; row > 0; row--)
            {
                if (this.board[row, col].Value == 0)
                {
                    int fallingBalloonIndex = FindFallingBalloonIndex(row, col);

                    if (fallingBalloonIndex >= 0)
                    {
                        while (fallingBalloonIndex >= 0)
                        {
                            if (this.board[fallingBalloonIndex, col].Value != 0)
                            {
                                this.board[row, col].Value = this.board[fallingBalloonIndex, col].Value;
                            }
                            else
                            {
                                this.board[row, col].Pop();
                            }

                            this.board[fallingBalloonIndex, col].Pop();
                            row--;
                            fallingBalloonIndex--;
                        }
                    }
                }
            }
        }

        private int FindFallingBalloonIndex(int zeroElementRowIndex, int col)
        {
            for (int row = zeroElementRowIndex - 1; row >= 0; row--)
            {
                if (this.board[row, col].Value != 0)
                {
                    return row;
                }
            }

            return -1;
        }

        private string  ReadInput()
        {
            if (this.gameOver)
            {
                Console.Write("Enter command: ");
            }
            else
            {
                Console.Write("Enter a row and column: ");
            }

            string consoleInput = Console.ReadLine();

            return consoleInput;
        }

        private void PrintGameBoard()
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

                for (int col = 0; col < this.BoardWidth; col++)
                {
                    if (this.board[row, col].Value == 0)
                    {
                        sb.Append(String.Format("{0, 3}", "."));
                    }
                    else
                    {
                        sb.Append(String.Format("{0, 3}", this.board[row, col].Value));
                    }
                }

                sb.Append(Environment.NewLine);
            }

            Console.WriteLine(sb.ToString());
        }
    }
}
