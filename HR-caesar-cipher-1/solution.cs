
using System;
using System.Text;

public class Solution
{
	private static char[] _map;

	static Solution()
	{
		_map = new char[26];
		for (var i = 0; i < _map.Length; i++) { _map[i] = (char)(i + 'a'); }
	}


	public static void Main(string[] args)
	{
		Console.ReadLine(); // skip unused N
		var s = Console.ReadLine();
		var k = int.Parse(Console.ReadLine());

		StringBuilder result = new StringBuilder();
		foreach (var c in s) { result.Append(Encode(c, k)); }

		Console.WriteLine(result);
	}


	private static char Encode(char c, int k)
	{
		if (!Char.IsLetter(c)) { return c; }
		if (Char.IsUpper(c)) { return Char.ToUpper(Encode(Char.ToLower(c), k)); }

		return _map[((int)c - (int)'a' + k) % _map.Length];
	}
}

