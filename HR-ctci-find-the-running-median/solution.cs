
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
		heap.Print();
		heap.DeleteMax();
		heap.DeleteMax();
		heap.Print();
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

	protected void RemoveRoot()
	{
		// TODO
	}

	protected abstract bool NeedsSwap(int parent, int child);

	public void Add(int n)
	{
		_list.Add(n);

		var pos = _list.Count - 1;
		while (pos > 0 && NeedsSwap(_list[GetParent(pos)], _list[pos]))
		{
			var parent = GetParent(pos);
			Swap(pos, parent);
			pos = parent;
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

	public void Print()
	{
		// TODO - make it pretty!
		Console.WriteLine(string.Join(", ", _list));
	}
}


public class MinHeap : AbstractHeap
{
	public int GetMin() { return GetRoot(); }
	public void DeleteMin() { RemoveRoot(); }
	protected override bool NeedsSwap(int parent, int child) { return child < parent; }
}


public class MaxHeap : AbstractHeap
{
	public int GetMax() { return GetRoot(); }
	public void DeleteMax() { RemoveRoot(); }
	protected override bool NeedsSwap(int parent, int child) { return child > parent; }
}




