
using System;
using System.Collections.Generic;

public class Solution
{
	public static void Main(string[] args)
	{
		var mediator = new ListMediator();
		var n = int.Parse(Console.ReadLine());
		for (var i = 0; i < n; i++)
		{
			mediator.Add(int.Parse(Console.ReadLine()));
			Console.WriteLine("{0:0.0}", mediator.GetMedian());
		}
	}
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

