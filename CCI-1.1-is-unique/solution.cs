
using System;
using System.Collections.Generic;

public class Solution
{
	public static void Main(string[] args)
	{
		string s;
		while ((s = Console.ReadLine()) != null)
		{
			Console.WriteLine(IsUnique(s) ? "yes" : "no");
		}
	}


	public static bool IsUnique(string s)
	{
		var seen = new HashSet<char>();

		foreach (var c in s)
		{
			if (seen.Contains(c)) { return false; }
			seen.Add(c);
		}

		return true;
	}
}

