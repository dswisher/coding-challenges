
using System;
using System.Linq;

public class Solution
{
	public static void Main(string[] args)
	{
		var board = ReadBoard();

		// PrintBoard(board);

		Console.WriteLine(GetWinner(board));
	}


	private static char GetWinner(char[,] board)
	{
		var n = board.GetLength(0);

		// Check verticals and horizontals
		for (var i = 0; i < n; i++)
		{
			if (InRow(board, i, 0, 0, 1)) return board[i,0];
			if (InRow(board, 0, i, 1, 0)) return board[0,i];
		}

		// Check diagonals
		if (InRow(board, 0, 0, 1, 1)) return board[0,0];
		if (InRow(board, n - 1, 0, -1, -1)) return board[n - 1, 0];

		// No winner!
		return '.';
	}


	private static bool InRow(char[,] board, int x, int y, int dx, int dy)
	{
		char winner = board[x,y];

		if (winner == '.') return false;

		while (x < board.GetLength(0) && y < board.GetLength(1))
		{
			if (board[x,y] != winner) return false;
			x += dx;
			y += dy;
		}

		return true;
	}


	private static char[,] ReadBoard()
	{
		var result = new char[3,3];

		for (var i = 0; i < 3; i++)
		{
			var line = Console.ReadLine().Split(' ').Select(x => x[0]).ToArray();

			for (var j = 0; j < 3; j++)
			{
				result[i,j] = line[j];
			}
		}

		return result;
	}


	private static void PrintBoard(char[,] board)
	{
		for (var i = 0; i < board.GetLength(0); i++)
		{
			for (var j = 0; j < board.GetLength(1); j++)
			{
				if (j > 0) Console.Write(' ');
				Console.Write(board[i,j]);
			}

			Console.WriteLine();
		}
	}

}

