
using System;
using System.Linq;

public class Solution
{
	public static void Main(string[] args)
	{
		var arr = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();

		QuickSort(arr);

		Console.WriteLine(string.Join(" ", arr));
	}



	private static void QuickSort(int[] arr)
	{
		QuickSort(arr, 0, arr.Length - 1);
	}


	private static void QuickSort(int[] arr, int lo, int hi)
	{
		if (lo >= hi) return;

		var i = Partition(arr, lo, hi);

		QuickSort(arr, lo, i - 1);
		QuickSort(arr, i + 1, hi);
	}


	private static int Partition(int[] arr, int lo, int hi)
	{
		var p = arr[hi];
		var i = lo;

		for (var j = lo; j < hi; j++)
		{
			if (arr[j] <= p)
			{
				Swap(arr, i, j);
				i += 1;
			}
		}
		Swap(arr, i, hi);
		return i;
	}


	private static void Swap(int[] arr, int a, int b)
	{
		var temp = arr[a];
		arr[a] = arr[b];
		arr[b] = temp;
	}
}

