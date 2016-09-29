
using System;
using System.Collections.Generic;

public class Solution
{
	public static void Main(string[] args)
	{
		Console.ReadLine();

		// Read the words
		var hash = new Dictionary<string, int>();
		foreach (var w in ReadWords())
		{
			if (hash.ContainsKey(w))
			{
				hash[w] += 1;
			}
			else
			{
				hash.Add(w, 1);
			}
		}

		Console.WriteLine(AreAllAvailable(ReadWords(), hash) ? "Yes" : "No");
	}


	private static bool AreAllAvailable(IEnumerable<string> ransomWords, Dictionary<string, int> hash)
	{
		foreach (var word in ransomWords)
		{
			if (!hash.ContainsKey(word)) { return false; }

			if (hash[word] == 0) { return false; }

			hash[word] -= 1;
		}

		return true;
	}


	private static IEnumerable<string> ReadWords()
	{
		return Console.ReadLine().Split(' ');
	}
}

