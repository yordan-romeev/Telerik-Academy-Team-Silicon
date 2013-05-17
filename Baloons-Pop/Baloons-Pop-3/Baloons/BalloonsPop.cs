using System;
using System.Linq;

namespace BalloonsPops
{
    public class BalloonsPop
    {
        public static void Main(string[] args)
        {
            Engine gameEngine = new Engine(8, 4);
            gameEngine.Run();
        }
    }
}
