using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyRobot.Core
{
        public class Robot
        {
            public const string OUT_OF_BOUNDS_MESSAGE = "Command ignored - out of bounds";
            public const string NOT_PLACED_YET_MESSAGE = "Command ignored - robot not placed yet";
            public const string COMMAND_NOT_RECOGNISED_MESSAGE = "Command ignored - robot did not understand this command";
            public const string VALID_COMMANDS_MESSAGE = "Error during command handling.\nValid commands are:\nPLACE X,Y,Z\nMOVE\nLEFT\nRIGHT\nREPORT";

            private const int xLowerBoundary = 0; //minimum valid x coordinate
            private const int yLowerBoundary = 0; // minimum valid y coordinate

            private int xUpperBoundary = -1;
            private int yUpperBoundary = -1;
            private int xPosition = -1;
            private int yPosition = -1;
            private string direction = string.Empty;
            private bool isPlaced = false;

            // Valid table size 5,5, Constructor will initialize the upper bundary for x and y to 5 respectively.
            public Robot()
            {
                xUpperBoundary = 5;
                yUpperBoundary = 5;
            }

            // Custom table size if supplied
            public Robot(int tableSizeX, int tableSizeY)
            {
                xUpperBoundary = tableSizeX;
                yUpperBoundary = tableSizeY;
            }

            // Validate the X,Y Coordinate Position
            private bool validatePosition()
            {
                if ((xPosition < xLowerBoundary) || (yPosition < yLowerBoundary))
                    return false;
                else if ((xPosition > xUpperBoundary) || (yPosition > yUpperBoundary))
                    return false;
                else
                    return true;
            }

            // Store input command for Place Keyword
            private string place(string command)
            {
                string result = string.Empty;
                char[] delimiterChars = { ',', ' ' };
                string[] wordsInCommand = command.Split(delimiterChars);

                xPosition = Int32.Parse(wordsInCommand[1]);
                yPosition = Int32.Parse(wordsInCommand[2]);
                direction = wordsInCommand[3];

                // if the robot is outside x,y valid coordinate
                if (!validatePosition())
                    result = OUT_OF_BOUNDS_MESSAGE;
                else
                    isPlaced = true;

                return result;
            }

            // Process Report command
            private string report()
            {
                return xPosition + "," + yPosition + "," + direction;
            }

            private string move()
            {
                string result = string.Empty;
                int originalX = this.xPosition;
                int originalY = this.yPosition;

                switch (direction)
                {
                    case "NORTH":
                        yPosition++; break;
                    case "WEST":
                        xPosition--; break;
                    case "SOUTH":
                        yPosition--; break;
                    case "EAST":
                        xPosition++; break;
                }

                if (!validatePosition())
                {
                    xPosition = originalX;
                    yPosition = originalY;
                    result = OUT_OF_BOUNDS_MESSAGE;
                }
                return result;
            }

            // Will change the direction of robot last position to left side
            private void left()
            {
                switch (direction)
                {
                    case "NORTH":
                        direction = "WEST"; break;
                    case "WEST":
                        direction = "SOUTH"; break;
                    case "SOUTH":
                        direction = "EAST"; break;
                    case "EAST":
                        direction = "NORTH"; break;
                }
            }
            // Will change the direction of robot last position to left side
            private void right()
            {
                switch (direction)
                {
                    case "NORTH":
                        direction = "EAST"; break;
                    case "EAST":
                        direction = "SOUTH"; break;
                    case "SOUTH":
                        direction = "WEST"; break;
                    case "WEST":
                        direction = "NORTH"; break;
                }
            }

            public string command(string input)
            {
                string command = input.ToUpper();
                string result = string.Empty;

                try
                {
                    if (command.Contains("PLACE"))
                        result = place(command);
                    // if any other command is executed before placing the robot
                    else if (!isPlaced)
                        result = NOT_PLACED_YET_MESSAGE;

                    else if (command.Contains("REPORT"))
                        result = report();

                    else if (command.Contains("MOVE"))
                        result = move();

                    else if (command.Contains("LEFT"))
                        left();

                    else if (command.Contains("RIGHT"))
                        right();

                    else
                        result = COMMAND_NOT_RECOGNISED_MESSAGE;
                }
                catch (Exception ex)
                {
                    result = VALID_COMMANDS_MESSAGE;
                }

                return result;
            }
        }
  
  
}
