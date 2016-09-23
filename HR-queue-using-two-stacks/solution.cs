
using System;
using System.Collections.Generic;
using System.Linq;

public class Solution
{
	private static Stack<int> _head = new Stack<int>();
	private static Stack<int> _tail = new Stack<int>();

	public static void Main(string[] args)
	{
		var q = int.Parse(Console.ReadLine());

		for (var i = 0; i < q; i++)
		{
			var bits = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();
			switch (bits[0])
			{
				case 1:		// Enqueue
					FillTail();
					_tail.Push(bits[1]);
					break;

				case 2:		// Dequeue
					FillHead();
					_head.Pop();
					break;

				case 3:		// Print (aka Peek)
					FillHead();
					Console.WriteLine(_head.Peek());
					break;
			}
		}
	}

	private static void FillTail()
	{
		while (_head.Count > 0) { _tail.Push(_head.Pop()); }
	}

	private static void FillHead()
	{
		while (_tail.Count > 0) { _head.Push(_tail.Pop()); }
	}
}

