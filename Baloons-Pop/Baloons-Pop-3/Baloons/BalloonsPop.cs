using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BalloonsPops
{
    public class BalloonsPop
    {
        public static void Main(string[] args)
        {
            Engine gameEngine = new Engine(2, 3);
            gameEngine.Run();
        }
    }
}
