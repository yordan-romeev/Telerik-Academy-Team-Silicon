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

        public bool ConvertCommand(string input)
        {
            switch (input.ToLower())
            {
                case "top":
                    this.Type = CommandType.TopScore;
                    return true;
                case "restart":
                    this.Type = CommandType.Restart;
                    return true;
                case "exit":
                    this.Type = CommandType.Exit;
                    return true;
                default:
                    return false;
            }
        }
    }
}
