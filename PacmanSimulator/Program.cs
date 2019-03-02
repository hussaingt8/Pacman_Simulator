using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacmanSimulator
{	
	class Program
	{
		static void Main(string[] args)
		{
			string UserInput = String.Empty;

			Pacman pacman = new Pacman();

			Console.WriteLine("-- PACMAN SIMULATOR --");
			Console.WriteLine("Enter commands to move Pacman: (type EXIT at any time to quit)\n");
			Console.WriteLine("Valid commands are:\nPLACE X,Y,Z\nMOVE\nLEFT\nRIGHT\nREPORT\n");

			while (true)
			{
				Console.WriteLine("Enter Command for pacman:");
				UserInput = Console.ReadLine();

				if (UserInput.ToUpper().Equals("EXIT"))
					break;

				Console.WriteLine(pacman.command(UserInput));
				Console.WriteLine();
			}
			Console.WriteLine("Exited - press any key to close");
			Console.ReadLine();
		}
	}
}
