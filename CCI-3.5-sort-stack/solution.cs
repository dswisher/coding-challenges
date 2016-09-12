
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
		if (stack.Count < 2) return;

		var temp = new Stack<int>();

		// Move everything from stack over to temp
		while (stack.Count > 0)
		{
			temp.Push(stack.Pop());
		}

		// Keep popping items off temp and inserting them into their proper place
		while (temp.Count > 0)
		{
			// Grab the item
			var x = temp.Pop();

			// Find the right spot
			while (stack.Count > 0 && x > stack.Peek())
			{
				temp.Push(stack.Pop());
			}

			// Push the new item
			stack.Push(x);

			// Shuffle back
			while (temp.Count > 0 && temp.Peek() < stack.Peek())
			{
				stack.Push(temp.Pop());
			}
		}
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

