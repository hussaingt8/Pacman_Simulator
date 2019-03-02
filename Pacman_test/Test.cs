using NUnit.Framework;
using System;
using PacmanSimulator;

namespace Pacman_test
{
	[TestFixture()]
	public class PacmanTests
	{
		[Test()]
		public void Pacman_CommandIgnored_WhenNotPlacedYet()
		{
			//arrange
			Pacman pacman = new Pacman();
			//act
			string result = pacman.command("REPORT");
			//assert
			Assert.AreEqual(Pacman.NOT_PLACED_YET_ERROR, result);
		}

		[Test()]
		public void Pacman_CommandReturnEmptyString_AfterBeingPlaced()
		{
			//arrange
			Pacman pacman = new Pacman();
			//act
			string result = pacman.command("PLACE 0,0,NORTH");
			//assert
			Assert.AreEqual(string.Empty, result);
		}

		[Test()]
		public void Pacman_Report_AfterBeingPlaced()
		{
			//arrange
			Pacman  pacman = new Pacman();
			//act
			string result = pacman.command("PLACE 0,0,NORTH");
			result = pacman.command("REPORT");
			//assert
			Assert.AreEqual("0,0,NORTH", result);
		}

		// ************** Test cardinal directions ********************************************
		[Test()]
		public void Pacman_Report_0_1_N_AfterPlaced_0_0_N_AndSingleMove()
		{
			//arrange
			Pacman pacman = new Pacman();
			//act
			string result = pacman.command("PLACE 0,0,NORTH");
			result = pacman.command("MOVE");
			result = pacman.command("REPORT");
			//assert
			Assert.AreEqual("0,1,NORTH", result);
		}

		[Test()]
		public void Pacman_Report_1_0_E_AfterPlaced_0_0_E_AndSingleMove()
		{
			//arrange
			Pacman pacman = new Pacman();
			//act
			string result = pacman.command("PLACE 0,0,EAST");
			result = pacman.command("MOVE");
			result = pacman.command("REPORT");
			//assert
			Assert.AreEqual("1,0,EAST", result);
		}

		[Test()]
		public void Pacman_Report_1_0_S_AfterPlaced_1_1_S_AndSingleMove()
		{
			//arrange
			Pacman pacman = new Pacman();
			//act
			string result = pacman.command("PLACE 1,1,SOUTH");
			result = pacman.command("MOVE");
			result = pacman.command("REPORT");
			//assert
			Assert.AreEqual("1,0,SOUTH", result);
		}

		[Test()]
		public void Pacman_Report_0_1_W_AfterPlaced_1_1_W_AndSingleMove()
		{
			//arrange
			Pacman pacman = new Pacman();
			//act
			string result = pacman.command("PLACE 1,1,WEST");
			result = pacman.command("MOVE");
			result = pacman.command("REPORT");
			//assert
			Assert.AreEqual("0,1,WEST", result);
		}

		// ************** Test left direction ********************************************
		[Test()]
		public void Pacman_Report_0_0_W_AfterPlaced_0_0_N_AndLeftCommand()
		{
			//arrange
			Pacman pacman = new Pacman();
			//act
			string result = pacman.command("PLACE 0,0,NORTH");
			result = pacman.command("LEFT");
			result = pacman.command("REPORT");
			//assert
			Assert.AreEqual("0,0,WEST", result);
		}

		[Test()]
		public void Pacman_Report_0_0_S_AfterPlaced_0_0_W_AndLeftCommand()
		{
			//arrange
			Pacman pacman = new Pacman();
			//act
			string result = pacman.command("PLACE 0,0,WEST");
			result = pacman.command("LEFT");
			result = pacman.command("REPORT");
			//assert
			Assert.AreEqual("0,0,SOUTH", result);
		}

		[Test()]
		public void Pacman_Report_0_0_E_AfterPlaced_0_0_S_AndLeftCommand()
		{
			//arrange
			Pacman pacman = new Pacman();
			//act
			string result = pacman.command("PLACE 0,0,SOUTH");
			result = pacman.command("LEFT");
			result = pacman.command("REPORT");
			//assert
			Assert.AreEqual("0,0,EAST", result);
		}

		[Test()]
		public void Pacman_Report_0_0_N_AfterPlaced_0_0_E_AndLeftCommand()
		{
			//arrange
			Pacman pacman = new Pacman();
			//act
			string result = pacman.command("PLACE 0,0,EAST");
			result = pacman.command("LEFT");
			result = pacman.command("REPORT");
			//assert
			Assert.AreEqual("0,0,NORTH", result);
		}

		// ************** Test right direction ********************************************
		[Test()]
		public void Pacman_Report_0_0_E_AfterPlaced_0_0_N_AndRightCommand()
		{
			//arrange
			Pacman pacman = new Pacman();
			//act
			string result = pacman.command("PLACE 0,0,NORTH");
			result = pacman.command("RIGHT");
			result = pacman.command("REPORT");
			//assert
			Assert.AreEqual("0,0,EAST", result);
		}
		[Test()]
		public void Pacman_Report_0_0_S_AfterPlaced_0_0_E_AndRightCommand()
		{
			//arrange
			Pacman pacman = new Pacman();
			//act
			string result = pacman.command("PLACE 0,0,EAST");
			result = pacman.command("RIGHT");
			result = pacman.command("REPORT");
			//assert
			Assert.AreEqual("0,0,SOUTH", result);
		}
		[Test()]
		public void Pacman_Report_0_0_W_AfterPlaced_0_0_S_AndRightCommand()
		{
			//arrange
			Pacman pacman = new Pacman();
			//act
			string result = pacman.command("PLACE 0,0,SOUTH");
			result = pacman.command("RIGHT");
			result = pacman.command("REPORT");
			//assert
			Assert.AreEqual("0,0,WEST", result);
		}
		[Test()]
		public void Pacman_Report_0_0_N_AfterPlaced_0_0_W_AndRightCommand()
		{
			//arrange
			Pacman pacman = new Pacman();
			//act
			string result = pacman.command("PLACE 0,0,WEST");
			result = pacman.command("RIGHT");
			result = pacman.command("REPORT");
			//assert
			Assert.AreEqual("0,0,NORTH", result);
		}

		// ************** Test pacman environment boundaries on placement ******************************
		[Test()]
		public void Pacman_IgnoreCommand_AfterPlace_NegativeXCoordinate()
		{
			//arrange
			Pacman pacman = new Pacman();
			//act
			string result = pacman.command("PLACE -1,0,WEST");
			//assert
			Assert.AreEqual(Pacman.OUT_OF_BOUNDS_ERROR, result);
		}
		[Test()]
		public void Pacman_IgnoreCommand_AfterPlace_NegativeYCoordinate()
		{
			//arrange
			Pacman pacman = new Pacman();
			//act
			string result = pacman.command("PLACE 0,-1,WEST");
			//assert
			Assert.AreEqual(Pacman.OUT_OF_BOUNDS_ERROR, result);
		}
		[Test()]
		public void Pacman_IgnoreCommand_AfterPlace_UpperBoundX()
		{
			//arrange
			Pacman pacman = new Pacman(5, 5);
			//act
			string result = pacman.command("PLACE 6,5,WEST");
			//assert
			Assert.AreEqual(Pacman.OUT_OF_BOUNDS_ERROR, result);
		}
		[Test()]
		public void Pacman_IgnoreCommand_AfterPlace_UpperBoundY()
		{
			//arrange
			Pacman pacman = new Pacman(5, 5);
			//act
			string result = pacman.command("PLACE 5,6,WEST");
			//assert
			Assert.AreEqual(Pacman.OUT_OF_BOUNDS_ERROR, result);
		}

		// ************** Test pacman environment boundaries on movement ************************
		[Test()]
		public void Pacman_IgnoreCommand_AfterMove_NegativeXCoordinate()
		{
			//arrange
			Pacman pacman = new Pacman();
			//act
			string result = pacman.command("PLACE 0,0,WEST");
			result = pacman.command("MOVE");
			//assert
			Assert.AreEqual(Pacman.OUT_OF_BOUNDS_ERROR, result);
		}
		[Test()]
		public void Pacman_IgnoreCommand_AfterMove_NegativeYCoordinate()
		{
			//arrange
			Pacman pacman = new Pacman();
			//act
			string result = pacman.command("PLACE 0,0,SOUTH");
			result = pacman.command("MOVE");
			//assert
			Assert.AreEqual(Pacman.OUT_OF_BOUNDS_ERROR, result);
		}
		[Test()]
		public void Pacman_IgnoreCommand_AfterMove_UpperBoundXCoordinate()
		{
			//arrange
			Pacman pacman = new Pacman(1,1);
			//act
			string result = pacman.command("PLACE 0,0,EAST");
			result = pacman.command("MOVE");
			result = pacman.command("MOVE");
			//assert
			Assert.AreEqual(Pacman.OUT_OF_BOUNDS_ERROR, result);
		}
		[Test()]
		public void Pacman_IgnoreCommand_AfterMove_UpperBoundYCoordinate()
		{
			//arrange
			Pacman pacman = new Pacman(1,1);
			//act
			string result = pacman.command("PLACE 0,0,NORTH");
			result = pacman.command("MOVE");
			result = pacman.command("MOVE");
			//assert
			Assert.AreEqual(Pacman.OUT_OF_BOUNDS_ERROR, result);
		}

		// ************** Sample tests provided ************************
		[Test()]
		public void ProvidedTest_A()
		{
			//arrange
			Pacman pacman = new Pacman();
			//act
			string result = pacman.command("PLACE 0,0,NORTH");
			result = pacman.command("MOVE");
			result = pacman.command("REPORT");
			//assert
			Assert.AreEqual("0,1,NORTH", result);
		}
		[Test()]
		public void ProvidedTest_B()
		{
			//arrange
			Pacman pacman = new Pacman();
			//act
			string result = pacman.command("PLACE 0,0,NORTH");
			result = pacman.command("LEFT");
			result = pacman.command("REPORT");
			//assert
			Assert.AreEqual("0,0,WEST", result);
		}
		[Test()]
		public void ProvidedTest_C()
		{
			//arrange
			Pacman pacman = new Pacman();
			//act
			string result = pacman.command("PLACE 1,2,EAST");
			result = pacman.command("MOVE");
			result = pacman.command("MOVE");
			result = pacman.command("LEFT");
			result = pacman.command("MOVE");
			result = pacman.command("REPORT");
			//assert
			Assert.AreEqual("3,3,NORTH", result);
		}

		// ************** Test garbage input ************************
		[Test()]
		public void Pacman_ReturnsErrorMessage_AfterPlacement_WhenGarbageCommandSent()
		{
			//arrange
			Pacman pacman = new Pacman();
			//act
			string result = pacman.command("PLACE 1,2,EAST");
			result = pacman.command("BANANAS");
			//assert
			Assert.AreEqual(Pacman.COMMAND_NOT_RECOGNISED_ERROR, result);
		}

		// ************** Test garbage input ************************
		[Test()]
		public void Pacman_ReturnsValidCommandsMessage_WhenGarbageCommandSent()
		{
			//arrange
			Pacman pacman = new Pacman();
			//act
			string result = pacman.command("PLACE %,2,EAST");
			//assert
			Assert.AreEqual(Pacman.VALID_COMMANDS_ERROR, result);
		}

	}
}

