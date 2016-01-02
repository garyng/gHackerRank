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
				FindPoint(input);
			}

			Console.ReadKey();
		}

		
		static private void FindPoint(string input)
		{
			//Given two points P and Q, output the symmetric point of point P about Q.
			List<int> points = input.Split(' ').ToList().Select(item => int.Parse(item)).ToList();
			int x = points[2] * 2 - points[0];
			int y = points[3] * 2 - points[1];
			Console.WriteLine(x + " " + y);
		}

	}
}
