
using System;
using System.Linq;

public class Solution
{
	public static void Main(string[] args)
	{
		var n = int.Parse(Console.ReadLine());
		var ar = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();

		var e = Select(ar, 0, n - 1, n / 2);

		Console.WriteLine(e);
	}


	private static int Select(int[] ar, int left, int right, int pos)
	{
		if (left == right) return ar[left];

		var pivotIdx = left + (right - left) / 2;
		pivotIdx = Partition(ar, left, right, pivotIdx);

		if (pos == pivotIdx)
			return ar[pos];
		else if (pos < pivotIdx)
			return Select(ar, left, pivotIdx - 1, pos);
		else
			return Select(ar, pivotIdx + 1, right, pos);
	}


	private static int Partition(int[] ar, int left, int right, int pivotIdx)
	{
		var pivotValue = ar[pivotIdx];
		Swap(ar, pivotIdx, right);
		// TODO - see https://en.wikipedia.org/wiki/Quickselect#Partition-based_general_selection_algorithm
	}


	private static void Swap(int[] ar, int a, int b)
	{
		var temp = ar[a];
		ar[a] = ar[b];
		ar[b] = temp;
	}
}

