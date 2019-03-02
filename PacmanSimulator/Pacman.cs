using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacmanSimulator
{
	public class Pacman
	{
		public const string OUT_OF_BOUNDS_ERROR = "Command ignored - out of bounds";
		public const string DIRECTION_NOT_SET_ERROR = "Command ignored - Direction not selected, check third co-ordinate";
		public const string NOT_PLACED_YET_ERROR = "Command ignored - pacman not placed yet";
		public const string COMMAND_NOT_RECOGNISED_ERROR = "Command ignored - pacman did not understand this command";
		public const string VALID_COMMANDS_ERROR = "Command not recognized.\nValid commands are:\nPLACE X,Y,Z\nMOVE\nLEFT\nRIGHT\nREPORT";

		private const int xLowerBoundary = 0;
		private const int yLowerBoundary = 0;

		private int xUpperBoundary = -1;
		private int yUpperBoundary = -1;
		private int xPosition = -1;
		private int yPosition = -1;
		private string direction = string.Empty;
		private bool isPlaced = false;

		// Default table size 5,5 
		public Pacman()
		{
			xUpperBoundary = 5;
			yUpperBoundary = 5;
		}

		// Custom table size if wanna change
		public Pacman(int tableSizeX, int tableSizeY)
		{
			xUpperBoundary = tableSizeX;
			yUpperBoundary = tableSizeY;
		}

		// Check if pacman inside the created grid 
		private bool validatePosition() 
		{
			if ((xPosition < xLowerBoundary) || (yPosition < yLowerBoundary)) 
				return false;
			
			else if ((xPosition > xUpperBoundary) || (yPosition > yUpperBoundary)) 
				return false;
			
			else 
				return true;
			
		}

		// place pacman on assigned co-ordinates 
		private string place(string command)
		{
			string result = string.Empty;
			char[] delimiterChars = { ',', ' ' };
			string[] wordsInCommand = command.Split(delimiterChars);

			xPosition = Int32.Parse(wordsInCommand[1]);
			yPosition = Int32.Parse(wordsInCommand[2]);
			direction = wordsInCommand[3];

			if (!validatePosition ()) 
				result = OUT_OF_BOUNDS_ERROR;

			else if (!(direction.Contains ("NORTH") || direction.Contains ("SOUTH") || direction.Contains ("EAST") || direction.Contains ("WEST"))) 
				result = DIRECTION_NOT_SET_ERROR;

			else 
				isPlaced = true;
		
			return result;
		}

		// announces the X,Y and Direction of the pacman on grid
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
				case "N":
					yPosition++; break;
				case "WEST":
				case "W":
					xPosition--; break;
				case "SOUTH":
				case "S":
					yPosition--; break;
				case "EAST":
				case "E":
					xPosition++; break;
			}                

			if (!validatePosition())
			{
				xPosition = originalX;
				yPosition = originalY;
				result = OUT_OF_BOUNDS_ERROR;
			}
			return result;
		}

		// Rotates pacman 90 degreess to the left without changing cooridnates
		private void left()
		{
			switch (direction)
			{
				case "NORTH":
				case "N":
					direction = "WEST"; break;
				case "WEST":
				case "W":
					direction = "SOUTH"; break;
				case "SOUTH":
				case "S":
					direction = "EAST"; break;
				case "EAST":
				case "E":
					direction = "NORTH"; break;
			}
		}

		// Rotates pacman 90 degreess to the right without changing cooridnates
		private void right()
		{
			switch (direction)
			{
				case "NORTH":
				case "N":
					direction = "EAST"; break;
				case "E":
				case "EAST":
					direction = "SOUTH"; break;
				case "S":
				case "SOUTH":
					direction = "WEST"; break;
				case "W":
				case "WEST":
					direction = "NORTH"; break;
			}
		}

		// calls the respective fucntion based on user input command
		public string command(string input)
		{
			string command = input.ToUpper();
			string result = string.Empty;

			try
			{
				if (command.Contains("PLACE"))
					result = place(command);

				else if (!isPlaced)
					result = NOT_PLACED_YET_ERROR;

				else if (command.Contains("REPORT"))
					result = report();

				else if (command.Contains("MOVE"))
					result = move();

				else if (command.Contains("LEFT"))
					left();

				else if (command.Contains("RIGHT"))
					right();

				else
					result = COMMAND_NOT_RECOGNISED_ERROR;
			}
			catch (Exception)
			{
				result = VALID_COMMANDS_ERROR;
			}

			return result;
		}
	}
}
