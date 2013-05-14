using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//test commit
namespace BalloonsPops
{
    class Command
    {
        private string c;

        public string Value
        {
            get
            {
                return this.c;
            }

            set
            {
                this.c = value;
            }
        }

        public static bool TryParse(string input, ref Command result)
        {
            if (input == "top")
            {
                result.Value = input;
                return true;
            }

            if (input == "restart")
            {
                result.Value = input;
                return true;
            }

            if (input == "exit")
            {
                result.Value = input;
                return true;
            }

            return false;
        }
    }
}
