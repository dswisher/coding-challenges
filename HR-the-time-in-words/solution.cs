
using System;
using System.Collections.Generic;

public class Solution
{
	private static Dictionary<int, string> _names = new Dictionary<int, string>();

	static Solution()
	{
		string[] lows = {"zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine",
					"ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen",
					"eighteen", "nineteen", "twenty"};

		for (var i = 0; i < lows.Length; i++) _names.Add(i, lows[i]);

		_names.Add(30, "thirty");	// won't be used, but included for completeness
		_names.Add(40, "forty");
		_names.Add(50, "fifty");
	}

	public static void Main(string[] args)
	{
		var h = int.Parse(Console.ReadLine());
		var m = int.Parse(Console.ReadLine());

		if (m == 0)
		{
			Console.WriteLine(string.Concat(ToWords(h), " o' clock"));
		}
		else if (m > 30)
		{
			Console.WriteLine(string.Concat(Minutes(60 - m), " to ", Hours(h + 1)));
		}
		else
		{
			Console.WriteLine(string.Concat(Minutes(m), " past ", Hours(h)));
		}
	}


	private static string Hours(int h)
	{
		if (h > 12) h -= 12;

		return ToWords(h);
	}


	private static string Minutes(int m)
	{
		if (m == 15) return "quarter";
		if (m == 30) return "half";

		return string.Format("{0} {1}{2}", ToWords(m), "minute", m == 1 ? string.Empty : "s");
	}


	private static string ToWords(int n)
	{
		if (_names.ContainsKey(n))
		{
			return _names[n];
		}

		for (var i = 50; i >= 20; i -= 10)
		{
			if (n > i) { return string.Concat(_names[i], " ", ToWords(n - i)); }
		}

		throw new Exception(string.Format("Unhandled number: {0}", n));
	}
}

