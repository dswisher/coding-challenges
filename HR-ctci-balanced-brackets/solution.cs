
using System;
using System.Collections.Generic;

public class Solution
{
	public static void Main(string[] args)
	{
		var n = int.Parse(Console.ReadLine());
		for (var i = 0; i < n; i++)
		{
			var s = Console.ReadLine();

			Console.WriteLine(IsMatched(s) ? "YES" : "NO");
		}
	}


	private static bool IsMatched(string s)
	{
		var stack = new Stack<char>();
		foreach (var c in s)
		{
			if (IsLeft(c))
			{
				stack.Push(c);
			}
			else if (IsRight(c))
			{
				if (stack.Count == 0) { return false; }
				var o = stack.Pop();
				if (!AreMatch(o, c)) { return false; }
			}
			// TODO - handle non-brackets?
		}

		return stack.Count == 0;
	}


	private static bool AreMatch(char left, char right)
	{
		if (left == '{' && right == '}') return true;
		if (left == '(' && right == ')') return true;
		if (left == '[' && right == ']') return true;
		return false;
	}


	private static bool IsLeft(char c)
	{
		return (c == '{' || c == '(' || c == '[');
	}


	private static bool IsRight(char c)
	{
		return (c == '}' || c == ')' || c == ']');
	}
}

