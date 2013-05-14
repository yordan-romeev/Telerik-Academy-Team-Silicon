using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BalloonsPops
{
    public class Balloons
    {
        public static void Main(string[] args)
        {
            GameBoard gameBoard = new GameBoard();
            gameBoard.GenerateNewGame();
            gameBoard.PrintGameBoard();
            TopScore topScore = new TopScore();

            topScore.OpenTopScoreList();
            
            bool isCoordinates;
            Coordinates coordinates = new Coordinates();
            Command command = new Command();
            while (gameBoard.RemainingBaloons > 0)
            {
                if (gameBoard.ReadInput(out isCoordinates, ref coordinates, ref command))
                {
                    if (isCoordinates)
                    {
                        gameBoard.Shoot(coordinates);
                        gameBoard.PrintGameBoard();
                    }
                    else
                    {
                        switch (command.Type)
                        {
                            case CommandType.TopScore:
                                {
                                    topScore.PrintScoreList();
                                }

                                break;
                            case CommandType.Restart:
                                {
                                    gameBoard.GenerateNewGame();
                                    gameBoard.PrintGameBoard();
                                }

                                break;
                            case CommandType.Exit:
                                {
                                    return;
                                }
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Wrong Input!");
                }
            }

            Person player = new Person(gameBoard.ShootCounter);

            if (topScore.IsTopScore(player))
            {
                Console.WriteLine("Please enter your name for the top scoreboard: ");
                player.Name = Console.ReadLine();
                topScore.AddToTopScoreList(player);
            }

            topScore.SaveTopScoreList();
        }
    }
}
