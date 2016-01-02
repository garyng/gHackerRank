using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Solution
{
	public static class hrSolutions
	{
		//Given two points P and Q, output the symmetric point of point P about Q.
		static public void FindPoint(string input)
		{
			List<int> points = input.Split(' ').ToList().Select(item => int.Parse(item)).ToList();
			int x = points[2] * 2 - points[0];
			int y = points[3] * 2 - points[1];
			Console.WriteLine(x + " " + y);
		}

		//Jim is off to a party and is searching for a matching pair of socks. 
		//His drawer is filled with socks, each pair of a different color. 
		//In its worst case scenario, how many socks (x) should Jim remove from his drawer until he finds a matching pair?
		static public void MinimumDraws(string input)
		{
			int num = int.Parse(input);
			Console.WriteLine(num + 1);
		}

	}
}
