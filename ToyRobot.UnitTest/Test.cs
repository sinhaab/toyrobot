using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit;
using NUnit.Framework;
using ToyRobot.Core;

namespace ToyRobot.UnitTest
{
    [TestFixture]
    public class Test
    {
            
            [TestCase]
            public void Robot_CommandIgnored_WhenNotPlacedYet()
                {
                    //arrange
                    Robot robot = new Robot();
                    //act
                    string result = robot.command("REPORT");
                    //assert
                    Assert.AreEqual(Robot.NOT_PLACED_YET_MESSAGE, result);
                }

            [TestCase]
            public void Robot_CommandReturnEmptyString_AfterBeingPlaced()
                {
                    //arrange
                    Robot robot = new Robot();
                    //act
                    string result = robot.command("PLACE 0,0,NORTH");
                    //assert
                    Assert.AreEqual(string.Empty, result);
                }

            [TestCase]
            public void Robot_Report_AfterBeingPlaced()
                {
                    //arrange
                    Robot robot = new Robot();
                    //act
                    string result = robot.command("PLACE 0,0,NORTH");
                    result = robot.command("REPORT");
                    //assert
                    Assert.AreEqual("0,0,NORTH", result);
                }

            // ************** Test cardinal directions ********************************************
            [TestCase]
            public void Robot_Report_0_1_N_AfterPlaced_0_0_N_AndSingleMove()
                {
                    //arrange
                    Robot robot = new Robot();
                    //act
                    string result = robot.command("PLACE 0,0,NORTH");
                    result = robot.command("MOVE");
                    result = robot.command("REPORT");
                    //assert
                    Assert.AreEqual("0,1,NORTH", result);
                }

            [TestCase]
            public void Robot_Report_1_0_E_AfterPlaced_0_0_E_AndSingleMove()
                {
                    //arrange
                    Robot robot = new Robot();
                    //act
                    string result = robot.command("PLACE 0,0,EAST");
                    result = robot.command("MOVE");
                    result = robot.command("REPORT");
                    //assert
                    Assert.AreEqual("1,0,EAST", result);
                }

            [TestCase]
            public void Robot_Report_1_0_S_AfterPlaced_1_1_S_AndSingleMove()
                {
                    //arrange
                    Robot robot = new Robot();
                    //act
                    string result = robot.command("PLACE 1,1,SOUTH");
                    result = robot.command("MOVE");
                    result = robot.command("REPORT");
                    //assert
                    Assert.AreEqual("1,0,SOUTH", result);
                }

            [TestCase]
            public void Robot_Report_0_1_W_AfterPlaced_1_1_W_AndSingleMove()
                {
                    //arrange
                    Robot robot = new Robot();
                    //act
                    string result = robot.command("PLACE 1,1,WEST");
                    result = robot.command("MOVE");
                    result = robot.command("REPORT");
                    //assert
                    Assert.AreEqual("0,1,WEST", result);
                }

            // ************** Test left direction ********************************************
            [TestCase]
            public void Robot_Report_0_0_W_AfterPlaced_0_0_N_AndLeftCommand()
                {
                    //arrange
                    Robot robot = new Robot();
                    //act
                    string result = robot.command("PLACE 0,0,NORTH");
                    result = robot.command("LEFT");
                    result = robot.command("REPORT");
                    //assert
                    Assert.AreEqual("0,0,WEST", result);
                }

            [TestCase]
            public void Robot_Report_0_0_S_AfterPlaced_0_0_W_AndLeftCommand()
                {
                    //arrange
                    Robot robot = new Robot();
                    //act
                    string result = robot.command("PLACE 0,0,WEST");
                    result = robot.command("LEFT");
                    result = robot.command("REPORT");
                    //assert
                    Assert.AreEqual("0,0,SOUTH", result);
                }

            [TestCase]
            public void Robot_Report_0_0_E_AfterPlaced_0_0_S_AndLeftCommand()
                {
                    //arrange
                    Robot robot = new Robot();
                    //act
                    string result = robot.command("PLACE 0,0,SOUTH");
                    result = robot.command("LEFT");
                    result = robot.command("REPORT");
                    //assert
                    Assert.AreEqual("0,0,EAST", result);
                }
            [TestCase]
          
                public void Robot_Report_0_0_N_AfterPlaced_0_0_E_AndLeftCommand()
                {
                    //arrange
                    Robot robot = new Robot();
                    //act
                    string result = robot.command("PLACE 0,0,EAST");
                    result = robot.command("LEFT");
                    result = robot.command("REPORT");
                    //assert
                    Assert.AreEqual("0,0,NORTH", result);
                }

            // ************** Test right direction ********************************************
            [TestCase]
            public void Robot_Report_0_0_E_AfterPlaced_0_0_N_AndRightCommand()
                {
                    //arrange
                    Robot robot = new Robot();
                    //act
                    string result = robot.command("PLACE 0,0,NORTH");
                    result = robot.command("RIGHT");
                    result = robot.command("REPORT");
                    //assert
                    Assert.AreEqual("0,0,EAST", result);
                }
            [TestCase]
            public void Robot_Report_0_0_S_AfterPlaced_0_0_E_AndRightCommand()
                {
                    //arrange
                    Robot robot = new Robot();
                    //act
                    string result = robot.command("PLACE 0,0,EAST");
                    result = robot.command("RIGHT");
                    result = robot.command("REPORT");
                    //assert
                    Assert.AreEqual("0,0,SOUTH", result);
                }
            [TestCase]
            public void Robot_Report_0_0_W_AfterPlaced_0_0_S_AndRightCommand()
                {
                    //arrange
                    Robot robot = new Robot();
                    //act
                    string result = robot.command("PLACE 0,0,SOUTH");
                    result = robot.command("RIGHT");
                    result = robot.command("REPORT");
                    //assert
                    Assert.AreEqual("0,0,WEST", result);
                }
            [TestCase]
            public void Robot_Report_0_0_N_AfterPlaced_0_0_W_AndRightCommand()
                {
                    //arrange
                    Robot robot = new Robot();
                    //act
                    string result = robot.command("PLACE 0,0,WEST");
                    result = robot.command("RIGHT");
                    result = robot.command("REPORT");
                    //assert
                    Assert.AreEqual("0,0,NORTH", result);
                }

            // ************** Test robot environment boundaries on placement ******************************
            [TestCase]
            public void Robot_IgnoreCommand_AfterPlace_NegativeXCoordinate()
                {
                    //arrange
                    Robot robot = new Robot();
                    //act
                    string result = robot.command("PLACE -1,0,WEST");
                    //assert
                    Assert.AreEqual(Robot.OUT_OF_BOUNDS_MESSAGE, result);
                }
            [TestCase]
            public void Robot_IgnoreCommand_AfterPlace_NegativeYCoordinate()
                {
                    //arrange
                    Robot robot = new Robot();
                    //act
                    string result = robot.command("PLACE 0,-1,WEST");
                    //assert
                    Assert.AreEqual(Robot.OUT_OF_BOUNDS_MESSAGE, result);
                }
          

            // ************** Test robot environment boundaries on movement ************************
            [TestCase]
            public void Robot_IgnoreCommand_AfterMove_NegativeXCoordinate()
                {
                    //arrange
                    Robot robot = new Robot();
                    //act
                    string result = robot.command("PLACE 0,0,WEST");
                    result = robot.command("MOVE");
                    //assert
                    Assert.AreEqual(Robot.OUT_OF_BOUNDS_MESSAGE, result);
                }
            [TestCase]
            public void Robot_IgnoreCommand_AfterMove_NegativeYCoordinate()
                {
                    //arrange
                    Robot robot = new Robot();
                    //act
                    string result = robot.command("PLACE 0,0,SOUTH");
                    result = robot.command("MOVE");
                    //assert
                    Assert.AreEqual(Robot.OUT_OF_BOUNDS_MESSAGE, result);
                }


            // ************** Test Multiple command input ************************
            [TestCase]
            public void ProvidedTest_C()
                {
                    //arrange
                    Robot robot = new Robot();
                    //act
                    string result = robot.command("PLACE 1,2,EAST");
                    result = robot.command("MOVE");
                    result = robot.command("MOVE");
                    result = robot.command("LEFT");
                    result = robot.command("MOVE");
                    result = robot.command("REPORT");
                    //assert
                    Assert.AreEqual("3,3,NORTH", result);
                }

            // ************** Test invalid input ************************
            [TestCase]
            public void Robot_ReturnsErrorMessage_AfterPlacement_WhenGarbageCommandSent()
                {
                    //arrange
                    Robot robot = new Robot();
                    //act
                    string result = robot.command("PLACE 1,2,EAST");
                    result = robot.command("BANANAS");
                    //assert
                    Assert.AreEqual(Robot.COMMAND_NOT_RECOGNISED_MESSAGE, result);
                }

            // ************** Test invalid input ************************
            [TestCase]
            public void Robot_ReturnsValidCommandsMessage_WhenGarbageCommandSent()
                {
                    //arrange
                    Robot robot = new Robot();
                    //act
                    string result = robot.command("PLACE %,2,EAST");
                    //assert
                    Assert.AreEqual(Robot.VALID_COMMANDS_MESSAGE, result);
                }

            }
       
    }

