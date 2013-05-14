using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//test commit
namespace BalloonsPops
{
    public class Command
    {
        public CommandType Type 
        { 
            get; 
            set; 
        }

        public static bool TryParse(string input, ref Command result)
        {
            if (input == "top")
            {
                result.Type = CommandType.TopScore;
                return true;
            }

            if (input == "restart")
            {
                result.Type = CommandType.Restart;
                return true;
            }

            if (input == "exit")
            {
                result.Type = CommandType.Exit;
                return true;
            }

            return false;
        }
    }
}
