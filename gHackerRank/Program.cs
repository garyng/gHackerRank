using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Solution
{
	class Program
	{
		static void Main(string[] args)
		{
			int num = int.Parse(Console.ReadLine());
			for (int i = 0; i < num; i++)
			{
				string input = Console.ReadLine();
				MinimumDraws(input);
				
			}

			Console.ReadKey();
		}

	}
}
