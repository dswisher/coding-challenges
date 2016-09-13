
using System;
using System.Linq;

public class Solution
{
	public static void Main(string[] args)
	{
		var bits = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();
		var numChapters = bits[0];
		var maxProbsPerPage = bits[1];
		var problems = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();

		var pageNum = 1;
		var pageProbs = 0;
		var numSpecial = 0;
		for (var c = 1; c <= numChapters; c++)
		{
			// Lay out the problems for this chapter
			for (var p = 1; p <= problems[c - 1]; p++)
			{
				pageProbs += 1;
				if (pageProbs > maxProbsPerPage)
				{
					pageProbs = 1;
					pageNum += 1;
				}

				if (p == pageNum)
				{
					numSpecial += 1;
				}
			}

			// Set up for next chapter
			if (pageProbs > 0)
			{
				pageNum += 1;
				pageProbs = 0;
			}
		}

		Console.WriteLine(numSpecial);
	}
}

