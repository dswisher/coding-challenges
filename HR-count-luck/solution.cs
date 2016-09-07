
using System;
using System.Collections.Generic;
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

		// Find the path from player to goal, counting the decision points
		var path = FindPath(board);

		// TODO - DEBUG - print the board
		board.Print();
	}
	

	private static List<PathNode> FindPath(Board board)
	{
		var x = board.Player.X;
		var y = board.Player.Y;
		var stack = new Stack<PathNode>();

		// while (x != board.GoalX && y != board.GoalY)
		// {
			// TODO
		// }

		return stack.ToList();
	}
}


public class PathNode
{
	public int X { get; set; }
	public int Y { get; set; }
}


public class Position
{
	public int X { get; set; }
	public int Y { get; set; }
}


public class Board
{
	private char[,] _cells;
	private Position _player = new Position();
	private Position _goal = new Position();

	public Position Player { get { return _player; } }
	public Position Goal { get { return _goal; } }

	public int Width { get; private set; }
	public int Height { get; private set; }


	public static Board Create()
	{
		var board = new Board();
		var l1 = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();

		// Add extra spots to have a border around the whole map
		board.Height = l1[0] + 2;
		board.Width = l1[1] + 2;

		board._cells = new char[board.Width, board.Height];

		// Paint the border
		for (var j = 0; j < board.Height; j++)
		{
			board._cells[0, j] = 'X';
			board._cells[board.Width - 1, j] = 'X';
		}

		for (var i = 0; i < board.Width; i++)
		{
			board._cells[i, 0] = 'X';
			board._cells[i, board.Height - 1] = 'X';
		}

		// Load the innards
		for (var j = 1; j < board.Height - 1; j++)
		{
			var line = Console.ReadLine();
			for (var i = 1; i < board.Width - 1; i++)
			{
				board._cells[i,j] = line[i - 1];
				if (line[i - 1] == 'M') { board.Player.X = i; board.Player.Y = j; }
				if (line[i - 1] == '*') { board.Goal.X = i; board.Goal.Y = j; }
			}
		}

		return board;
	}


	public void Print()
	{
		Console.WriteLine("- - - - - - - - - - - - - - - - - - - - - -");
		Console.WriteLine("Player: {0},{1}", Player.X, Player.Y);
		Console.WriteLine("Goal:   {0},{1}", Goal.X, Goal.Y);
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

