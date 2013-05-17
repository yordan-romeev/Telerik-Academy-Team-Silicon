using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BalloonsPops
{
    public static class CommandParser
    {
        /// <summary>
        /// Parse command by given string and returns the command type.
        /// </summary>
        /// <param name="consoleInput"></param>
        /// <returns></returns>
        public static CommandType GetCommandType(string consoleInput)
        {
            CommandType command = CommandType.Invalid;
            consoleInput = consoleInput.Trim().ToLower();

            if (consoleInput == "exit")
            {
                command = CommandType.Exit;
            }

            if (consoleInput == "restart")
            {
                command = CommandType.Restart;
            }

            if (consoleInput == "top")
            {
                command = CommandType.TopScore;
            }

            if (IsValidCoordinates(consoleInput))
            {
                command = CommandType.Coordinates;
            }

            return command;
        }

        /// <summary>
        /// Checks if given string can be parsed to valid coordinates.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        private static bool IsValidCoordinates(string command)
        {
            bool isCoordinates = true;
            char[] separators = { ' ', ',' };
            int x, y;

            string[] coordinates = command.Split(separators, StringSplitOptions.RemoveEmptyEntries);

            if (coordinates.Length != 2)
            {
                isCoordinates = false;
            }
            else
            {
                if (!int.TryParse(coordinates[0], out x))
                {
                    isCoordinates = false;
                }

                if (!int.TryParse(coordinates[1], out y))
                {
                    isCoordinates = false;
                }
            }

            return isCoordinates;
        }

        /// <summary>
        /// Parse given string command and returns coordinates.
        /// </summary>
        /// <param name="coordinatesAsString"></param>
        /// <returns></returns>
        public static Coordinates ParseCoordinates(string coordinatesAsString)
        {
            char[] separators = { ' ', ',' };
            string[] coordinatesArray = coordinatesAsString.Split(separators, StringSplitOptions.RemoveEmptyEntries);

            int x = int.Parse(coordinatesArray[0]);
            int y = int.Parse(coordinatesArray[1]);

            Coordinates result = new Coordinates(x, y);

            return result;
        }
    }
}
