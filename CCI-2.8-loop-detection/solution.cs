
using System;
using System.Collections.Generic;

public class Solution
{
	public static void Main(string[] args)
	{
		var list = Node.CreateList(Console.ReadLine());
		var node = list.FindNode(Console.ReadLine());
		var tail = list.FindTail();

		// Create a loop
		tail.Next = node;

		// Find a node that is on the loop
		var loopNode = FindLoop(list);
		if (loopNode == null)
		{
			Console.WriteLine("No Loop");
			return;
		}

		// Enumerate all the nodes in the loop, and save the values in a hash
		var hash = new HashSet<string>();
		node = loopNode.Next;
		while (node != loopNode)
		{
			hash.Add(node.Data);
			node = node.Next;
		}

		// Walk through the list, looking for the last node that is not in the hash...
		var test = list;
		while (test != null && !hash.Contains(test.Data))
		{
			test = test.Next;
		}

		Console.WriteLine(test.Data);
	}


	private static Node FindLoop(Node node)
	{
		var leader = node;
		while (leader != null)
		{
			leader = leader.Next;
			if (leader != null) { leader = leader.Next; }
			if (leader == node) { return node; }
			node = node.Next;
		}

		return leader;
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


	public Node FindTail()
	{
		var node = this;

		while (node != null && node.Next != null)
		{
			node = node.Next;
		}

		return node;
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

