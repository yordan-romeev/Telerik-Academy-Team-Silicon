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
            GameBoard gameBoard = new GameBoard(25, 8);
            gameBoard.GenerateNewGame();
            gameBoard.PrintGameBoard();
            TopScore topScore = new TopScore();

            topScore.OpenTopScoreList();

            InputType inputType;
            Coordinates coordinates = new Coordinates(); ;
            Command command = new Command();

            while (gameBoard.RemainingBaloons > 0)
            {
                gameBoard.ReadInput(ref coordinates, ref command, out inputType);
                switch (inputType)
                {
                    case InputType.Coordinates:
                        gameBoard.Shoot(coordinates.PositionX, coordinates.PositionY);
                        gameBoard.PrintGameBoard();
                        break;
                    case InputType.Command:
                        switch (command.Type)
                        {
                            case CommandType.TopScore:
                                topScore.PrintScoreList();
                                break;
                            case CommandType.Restart:
                                gameBoard.GenerateNewGame();
                                gameBoard.PrintGameBoard();
                                break;
                            case CommandType.Exit:
                                return;
                        }
                        break;
                    case InputType.Invalid:
                        Console.WriteLine("Wrong Input!");
                        break;
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
