
using System;

public class Solution
{
	public static void Main(string[] args)
	{
		string s = Console.ReadLine().Replace(" ", string.Empty);

		// Determine the number of rows and columns (L = s.Length):
		//  * floor(sqrt(L)) <= rows <= cols <= ceil(sqrt(L))
		//  * ensure that rows * cols >= L
		//  * if multiple grids satisfy the above, choose one with smallest area (rows * cols)
		// TODO
		var rows = 7;
		var cols = 8;

		// Print the encryption
		for (var i = 0; i < cols; i++)
		{
			if (i > 0)
			{
				Console.Write(' ');
			}

			for (var j = i; j < s.Length; j += cols)
			{
				Console.Write(s[j]);
			}
		}

		Console.WriteLine();
	}
}

