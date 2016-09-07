
using System;
using System.Linq;

public class Solution
{
	public static void Main(string[] args)
	{
		var tests = int.Parse(Console.ReadLine());
		for (var t = 0; t < tests; t++)
		{
			Console.ReadLine();	// skip n

			var a = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();

			var nonCon = FindNonContig(a);
			int contig;
			if (nonCon < 0)
			{
				contig = nonCon;
			}
			else
			{
				// contig = FindContig(a);
				contig = Kadane(a);
			}

			Console.WriteLine("{0} {1}", contig, nonCon);
		}
	}


	private static int Kadane(int[] a)
	{
		// From Wikipedia  :(     See https://en.wikipedia.org/wiki/Maximum_subarray_problem
		var maxEndingHere = a[0];
		var maxSoFar = a[0];
		for (var i = 1; i < a.Length; i++)
		{
			maxEndingHere = Math.Max(a[i], maxEndingHere + a[i]);
			maxSoFar = Math.Max(maxSoFar, maxEndingHere);
		}
		return maxSoFar;
	}


	private static int FindContig(int[] a)
	{
		int start = 0;

		// Eliminate any "runs" of negative numbers at the start
		while (start < a.Length && a[start] < 0) start++;

		// Assume at least one positive number?
		var lastSum = ReadChunk(a, ref start).Value;
		var maxSum = lastSum;
		while (start < a.Length)
		{
			var chunk1 = ReadChunk(a, ref start);
			var chunk2 = ReadChunk(a, ref start);

			if (!chunk1.HasValue || !chunk2.HasValue)
			{
				break;
			}

			var chunkSum = chunk1.Value + chunk2.Value + lastSum;
			if (chunkSum > lastSum && chunkSum > chunk2.Value)
			{
				lastSum = chunkSum;
			}
			else
			{
				lastSum = chunk2.Value;
			}

			if (lastSum > maxSum)
			{
				maxSum = lastSum;
			}
		}

		return maxSum;
	}


	private static int? ReadChunk(int[] a, ref int start)
	{
		if (start >= a.Length) return null;

		int sum = 0;
		if (a[start] < 0)
		{
			while (start < a.Length && a[start] < 0) { sum += a[start++]; }
		}
		else
		{
			while (start < a.Length && a[start] >= 0) { sum += a[start++]; }
		}

		return sum;
	}


	private static int FindNonContig(int[] a)
	{
		var sum = 0;
		var max = int.MinValue;
		for (var i = 0; i < a.Length; i++)
		{
			if (a[i] > 0) { sum += a[i]; }
			if (a[i] > max) { max = a[i]; }
		}

		if (sum == 0) { sum = max; }

		return sum;
	}
}

