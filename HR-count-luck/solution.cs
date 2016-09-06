
using System;
using System.Linq;

public class Solution
{
	public static void Main(string[] args)
	{
		var numTests = int.Parse(Console.ReadLine());
		for (var t = 0; t < numTests; t++)
		{
			RunTest();
		}
	}


	private static void RunTest()
	{
		// Load the board
		var board = Board.Create();
		var K = int.Parse(Console.ReadLine());

		// Find the path from player to goal

		// TODO - DEBUG - print the board
		board.Print();
	}
}


public class Board
{
	private char[,] _cells;
	public int PlayerX { get; set; }
	public int PlayerY { get; set; }

	public int GoalX { get; private set; }
	public int GoalY { get; private set; }

	public int Width { get; private set; }
	public int Height { get; private set; }


	public static Board Create()
	{
		var board = new Board();
		var l1 = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();
		board.Height = l1[0];
		board.Width = l1[1];

		board._cells = new char[board.Width, board.Height];

		for (var j = 0; j < board.Height; j++)
		{
			var line = Console.ReadLine();
			for (var i = 0; i < board.Width; i++)
			{
				board._cells[i,j] = line[i];
				if (line[i] == 'M') { board.PlayerX = i; board.PlayerY = j; }
				if (line[i] == '*') { board.GoalX = i; board.GoalY = j; }
			}
		}

		return board;
	}


	public void Print()
	{
		Console.WriteLine("- - - - - - - - - - - - - - - - - - - - - -");
		Console.WriteLine("Player: {0},{1}", PlayerX, PlayerY);
		Console.WriteLine("Goal:   {0},{1}", GoalX, GoalY);
		Console.WriteLine("Map:");

		for (var j = 0; j < Height; j++)
		{
			Console.Write("   ");

			for (var i = 0; i < Width; i++)
			{
				Console.Write(_cells[i, j]);
			}

			Console.WriteLine();
		}
	}
}

