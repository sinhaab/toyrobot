using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobot.Core;

namespace ToyRobot
{
    class Interface
    {
        static void Main(string[] args)
        {
            string inputCommand = String.Empty;

            Robot robot = new Robot();

            Console.WriteLine("Toy Robot initialised. Enter commands to send to Move Robot: (X at any time to quit)");

            while (true)
            {
                Console.WriteLine("Enter command for Robot:");
                inputCommand = Console.ReadLine();

                if (inputCommand.ToUpper().Equals("X"))
                    break;

                Console.WriteLine(robot.command(inputCommand));
                Console.WriteLine();
            }
            Console.WriteLine("Exited - press any key to close");
            Console.ReadLine();
        }
    }
}
