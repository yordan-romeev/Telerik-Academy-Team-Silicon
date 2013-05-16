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
            Engine gameEngine = new Engine();
            gameEngine.Run();

            //TopScore topScore = new TopScore();

            //topScore.OpenTopScoreList();

            //InputType inputType;
            //Coordinates coordinates = new Coordinates();
            //Command command = new Command();

            //while (gameEngine.RemainingBalloons > 0)
            //{
            //    gameEngine.ReadInput(ref coordinates, ref command, out inputType);
            //    switch (inputType)
            //    {
            //        case InputType.Coordinates:
            //            gameEngine.Shoot(coordinates.PositionX, coordinates.PositionY);
            //            Console.WriteLine(gameEngine.ToString());
            //            break;
            //        case InputType.Command:
            //            switch (command.Type)
            //            {
            //                case CommandType.TopScore:
            //                    topScore.PrintScoreList();
            //                    break;
            //                case CommandType.Restart:
            //                    gameEngine.NewGame();
            //                    Console.WriteLine(gameEngine.ToString());
            //                    break;
            //                case CommandType.Exit:
            //                    return;
            //            }
            //            break;
            //        case InputType.Invalid:
            //            Console.WriteLine("Wrong Input!");
            //            break;
            //    }
            //}

            //Person player = new Person(gameEngine.ShootCounter);

            //if (topScore.IsTopScore(player))
            //{
            //    Console.WriteLine("Please enter your name for the top scoreboard: ");
            //    player.Name = Console.ReadLine();
            //    topScore.AddToTopScoreList(player);
            //}

            //topScore.SaveTopScoreList();
        }
    }
}
