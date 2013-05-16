using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BalloonsPops
{
    public static class CommandParser
    {
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
                if (!int.TryParse(coordinates[0], x))
                {
                    isCoordinates = false;
                }

                if (!int.TryParse(coordinates[1], y))
                {
                    isCoordinates = false;
                }
            }

            return isCoordinates;
        }

        public static Coordinates ParseCoordinates(string coordinatesAsString)
        {
            char[] separators = { ' ', ',' };
            string coordinatesArray = coordinatesAsString.Split(separators, StringSplitOptions.RemoveEmptyEntries);

            int x = int.Parse(coordinatesArray[0]);
            int y = int.Parse(coordinatesArray[1]);

            Coordinates result = new Coordinates(x, y);

            return result;
        }
    }
}
