
using System;

public class Solution
{
	public static void Main(string[] args)
	{
		var list = Node.CreateList(Console.ReadLine());
		var node = list.FindNode(Console.ReadLine());

		if (node.Next != null)
		{
			node.Data = node.Next.Data;
			node.Next = node.Next.Next;
		}

		list.Print();
	}
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


	public Node FindNode(string data)
	{
		var node = this;
		while (node != null)
		{
			if (node.Data == data) { return node; }
			node = node.Next;
		}
		return null;
	}


	public void Print()
	{
		var node = this;
		while (node != null)
		{
			if (node != this) { Console.Write(" "); }
			Console.Write(node.Data);
			node = node.Next;
		}
		Console.WriteLine();
	}
}

