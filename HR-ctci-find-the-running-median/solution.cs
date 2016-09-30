
using System;
using System.Collections.Generic;

public class Solution
{
	public static void Main(string[] args)
	{
		var medianFinder = new HeapMedianFinder();
		var n = int.Parse(Console.ReadLine());
		for (var i = 0; i < n; i++)
		{
			medianFinder.Add(int.Parse(Console.ReadLine()));
			Console.WriteLine("{0:0.0}", medianFinder.GetMedian());
		}
	}
}


public class HeapMedianFinder
{
	private MinHeap _right = new MinHeap();
	private MaxHeap _left = new MaxHeap();

	public void Add(int num)
	{
		// Add new number to the proper list
		if (num > _right.GetMin())
		{
			_right.Add(num);
		}
		else
		{
			_left.Add(num);
		}

		// Rebalance
		while (_left.Count <= _right.Count)
		{
			var moved = _right.GetMin();
			_right.Delete();
			_left.Add(moved);
		}

		while (_left.Count - 1 > _right.Count)
		{
			var moved = _left.GetMax();
			_left.Delete();
			_right.Add(moved);
		}
	}

	public double GetMedian()
	{
		if (_left.Count == 0)
		{
			throw new Exception("Can't get from empty median-finder!");
		}

		if (_left.Count == _right.Count)
		{
			return (_left.GetMax() + _right.GetMin()) / 2.0;
		}

		return _left.GetMax();
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
	public int GetMin() { return Count > 0 ? GetRoot() : int.MaxValue; }
	protected override bool NeedsSwap(int parent, int child) { return child < parent; }
}


public class MaxHeap : AbstractHeap
{
	public int GetMax() { return Count > 0 ? GetRoot() : int.MinValue; }
	protected override bool NeedsSwap(int parent, int child) { return child > parent; }
}




