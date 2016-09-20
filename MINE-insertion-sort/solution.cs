
using System;
using System.Linq;

public class Solution
{
	public static void Main(string[] args)
	{
		var arr = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();

		for (var i = 1; i < arr.Length; i++)
		{
			var j = i;
			while ((j > 0) && (arr[j - 1] > arr[j]))
			{
				var temp = arr[j];
				arr[j] = arr[j - 1];
				arr[j - 1] = temp;
				j -= 1;
			}
		}

		Console.WriteLine(string.Join(" ", arr));
	}
}

