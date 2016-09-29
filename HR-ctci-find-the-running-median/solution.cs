
using System;
using System.Collections.Generic;

public class Solution
{
	public static void Main(string[] args)
	{
#if true

		var mediator = new ListMediator();
		var n = int.Parse(Console.ReadLine());
		for (var i = 0; i < n; i++)
		{
			mediator.Add(int.Parse(Console.ReadLine()));
			Console.WriteLine("{0:0.0}", mediator.GetMedian());
		}

#else

		var heap = new MaxHeap();
		heap.Add(12);
		heap.Add(32);
		heap.Add(2);
		heap.Print();
		heap.Add(52);
		heap.Add(44);
		heap.Add(1);
		heap.Add(24);
		heap.Print();

		while (heap.Count > 1)
		{
			heap.Delete();
			heap.Print();
		}
#endif
	}
}


public class HeapMediator
{
}


public class ListMediator
{
	private List<int> _list = new List<int>();

	public void Add(int num)
	{
		_list.Add(num);
		var i = _list.Count - 1;
		while (i > 0 && _list[i] < _list[i - 1])
		{
			var temp = _list[i];
			_list[i] = _list[i - 1];
			_list[i - 1] = temp;
			i -= 1;
		}
	}


	public double GetMedian()
	{
		var mid = _list.Count / 2;

		if (_list.Count % 2 == 1)
		{
			// Odd
			return _list[mid];
		}

		// Even
		return (_list[mid] + _list[mid - 1]) / 2.0;
	}
}



public abstract class AbstractHeap
{
	private readonly List<int> _list = new List<int>();

	protected int GetRoot()
	{
		if (_list.Count == 0) throw new Exception("Cannot 'get' from an empty heap!");
		return _list[0];
	}

	public void Delete()
	{
		Swap(0, _list.Count - 1);
		_list.RemoveAt(_list.Count - 1);

		HeapifyDown(0);
	}

	public int Count { get { return _list.Count; } }

	protected abstract bool NeedsSwap(int parent, int child);

	public void Add(int n)
	{
		_list.Add(n);

		var pos = _list.Count - 1;
		HeapifyUp(pos);
	}

	private void HeapifyDown(int pos)
	{
		var left = GetLeftChild(pos);
		var right = GetRightChild(pos);
		var swapPos = pos;

		if (left != -1 && NeedsSwap(_list[swapPos], _list[left]))
			swapPos = left;
		if (right != -1 && NeedsSwap(_list[swapPos], _list[right]))
			swapPos = right;

		if (swapPos != pos)
		{
			Swap(pos, swapPos);
			HeapifyDown(swapPos);
		}
	}

	private void HeapifyUp(int pos)
	{
		if (pos == 0) return;

		var parent = GetParent(pos);
		if (NeedsSwap(_list[parent], _list[pos]))
		{
			Swap(pos, parent);
			HeapifyUp(parent);
		}
	}

	private void Swap(int a, int b)
	{
		var temp = _list[a];
		_list[a] = _list[b];
		_list[b] = temp;
	}

	protected int GetParent(int pos)
	{
		return pos / 2;
	}

	protected int GetLeftChild(int pos)
	{
		var n = pos * 2;
		return FilterChild(n);
	}

	protected int GetRightChild(int pos)
	{
		var n = (pos * 2) + 1;
		return FilterChild(n);
	}

	private int FilterChild(int n)
	{
		return n < _list.Count ? n : -1;
	}

	public void Print()
	{
		// TODO - make it pretty!
		Console.WriteLine(string.Join(", ", _list));
	}
}


public class MinHeap : AbstractHeap
{
	public int GetMin() { return GetRoot(); }
	protected override bool NeedsSwap(int parent, int child) { return child < parent; }
}


public class MaxHeap : AbstractHeap
{
	public int GetMax() { return GetRoot(); }
	protected override bool NeedsSwap(int parent, int child) { return child > parent; }
}




