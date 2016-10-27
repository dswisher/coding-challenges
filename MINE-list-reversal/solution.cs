
using System;
using System.Collections.Generic;

public class Solution
{
	public static void Main(string[] args)
	{
		var node = Node.CreateList(Console.ReadLine());

		var list = Reverse(node);
		list.Tail.Next = null;

		list.Head.Print();
	}


	private static List Reverse(Node node)
	{
		if (node.Next == null)
		{
			return new List { Head = node, Tail = node };
		}
		var newList = Reverse(node.Next);
		newList.Tail.Next = node;
		newList.Tail = node;
		return newList;
	}
}


public class List
{
	public Node Head { get; set; }
	public Node Tail { get; set; }
}


public class Node
{
	public string Data { get; set; }
	public Node Next { get; set; }

	public static Node CreateList(string input)
	{
		Node head = null;
		Node tail = null;
		foreach (var s in input.Split(' '))
		{
			var node = new Node { Data = s };
			if (head == null)
			{
				head = node;
			}
			else
			{
				tail.Next = node;
			}
			tail = node;
		}

		return head;
	}


	public void Print()
	{
		var looper = new HashSet<string>();
		var node = this;
		while (node != null)
		{
			if (looper.Count > 0) { Console.Write(" "); }
			Console.Write(node.Data);

			if (looper.Contains(node.Data))
			{
				Console.WriteLine(" LOOP!");
				return;
			}
			looper.Add(node.Data);

			node = node.Next;
		}
		Console.WriteLine();
	}
}

