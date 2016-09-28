
using System;
using System.Collections.Generic;

public class Solution
{
	public static void Main(string[] args)
	{
		Console.ReadLine();

		var availableWords = new HashSet<string>();
		availableWords.UnionWith(ReadWords());

		Console.WriteLine(AreAllAvailable(ReadWords(), availableWords) ? "Yes" : "No");
	}


	private static bool AreAllAvailable(IEnumerable<string> ransomWords, HashSet<string> availableWords)
	{
		foreach (var word in ransomWords)
		{
			if (!availableWords.Contains(word))
			{
				return false;
			}
		}

		return true;
	}


	private static IEnumerable<string> ReadWords()
	{
		return Console.ReadLine().Split(' ');
	}
}

