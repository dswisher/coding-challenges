
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
		Console.WriteLine(" -> {0}", string.Join(" ", arr));
		QuickSort(arr, 0, arr.Length - 1);
	}


	private static void QuickSort(int[] arr, int lo, int hi)
	{
		if (lo >= hi) return;

		var i = Partition(arr, lo, hi);

		QuickSort(arr, lo, i);
		QuickSort(arr, i + 1, hi);
	}


	private static int Partition(int[] arr, int lo, int hi)
	{
		var p = arr[lo];	// arbitrary
		var i = lo - 1;
		var j = hi + 1;

		while (true)
		{
			do { i += 1; } while (arr[i] < p);
			do { j -= 1; } while (arr[j] > p);

			if (i >= j) return j;

			var temp = arr[i];
			arr[i] = arr[j];
			arr[j] = temp;
		}
	}
}

