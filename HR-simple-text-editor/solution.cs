
using System;
using System.Collections.Generic;
using System.Text;

public class Solution
{
	public static void Main(string[] args)
	{
		var ops = int.Parse(Console.ReadLine());
		var stack = new Stack<ICommand>();
		var S = new StringBuilder();

		for (var i = 0; i < ops; i++)
		{
			var bits = Console.ReadLine().Split(' ');
			var opCode = int.Parse(bits[0]);
			switch (opCode)
			{
				case 1:		// append(W) - append string W to S
					{
						var command = new Append(bits[1]);
						stack.Push(command);
						command.Execute(S);
					}
					break;

				case 2:		// delete(k) - delete last k chars
					{
						var command = new Delete(int.Parse(bits[1]));
						stack.Push(command);
						command.Execute(S);
					}
					break;

				case 3:		// print(k) - print the kth char of S
					Console.WriteLine(S[int.Parse(bits[1]) - 1]);
					break;

				case 4:		// undo() - undo the last operation
					{
						var command = stack.Pop();
						command.Undo(S);
					}
					break;
			}
		}
	}


	public interface ICommand
	{
		void Execute(StringBuilder builder);
		void Undo(StringBuilder builder);
	}


	public class Append : ICommand
	{
		private readonly string _w;

		public Append(string w)
		{
			_w = w;
		}

		public void Execute(StringBuilder builder)
		{
			// Console.WriteLine("Exec append({0}), pre-S: {1}", _w, builder);
			builder.Append(_w);
			// Console.WriteLine("   post-S: {0}",  builder);
		}

		public void Undo(StringBuilder builder)
		{
			// Console.WriteLine("Undo append({0}), pre-S: {1}", _w, builder);
			builder.Length -= _w.Length;
			// Console.WriteLine("   post-S: {0}",  builder);
		}
	}


	public class Delete : ICommand
	{
		private readonly int _k;
		private string _removed;

		public Delete(int k)
		{
			_k = k;
		}

		public void Execute(StringBuilder builder)
		{
			// Console.WriteLine("Exec delete({0}), pre-S: {1}", _k, builder);
			_removed = builder.ToString(builder.Length - _k, _k);
			builder.Length -= _k;
			// Console.WriteLine("   post-S: {0}",  builder);
		}

		public void Undo(StringBuilder builder)
		{
			// Console.WriteLine("Undo delete({0}), pre-S: {1}", _k, builder);
			builder.Append(_removed);
			// Console.WriteLine("   post-S: {0}",  builder);
		}
	}
}

