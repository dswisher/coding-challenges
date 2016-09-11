
using System;
using System.Collections.Generic;
using System.Linq;

public class Solution
{
	public static void Main(string[] args)
	{
		var stack = new Stack<int>();
		foreach (var i in Console.ReadLine().Split(' ').Select(x => int.Parse(x)).Reverse())
		{
			stack.Push(i);
		}

		Sort(stack);

		Print(stack);
	}


	private static void Sort(Stack<int> stack)
	{
		var temp = new Stack<int>();
	}


	private static void Print(Stack<int> stack)
	{
		bool first = true;
		foreach (var i in stack)
		{
			if (first)
			{
				first = false;
			}
			else
			{
				Console.Write(" ");
			}

			Console.Write(i);
		}
		Console.WriteLine();
	}
}

