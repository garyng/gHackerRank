using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Solution
{
	public static class hrSolutions
	{
		//The first line contains an integer T representing the number of testcases 
		//Each test case is a line containing four space separated integers Px Py Qx Qy representing the (x,y) coordinates of P and Q.
		static public void FindPoint(string input)
		{
			List<int> points = input.Split(' ').ToList().Select(item => int.Parse(item)).ToList();
			int x = points[2] * 2 - points[0];
			int y = points[3] * 2 - points[1];
			Console.WriteLine(x + " " + y);
		}

		//The first line contains the number of test cases T. 
		//Next T lines contains an integer N which indicates the total pairs of socks present in the drawer.
		static public void MinimumDraws(string input)
		{
			int num = int.Parse(input);
			Console.WriteLine(num + 1);
		}

		//First line contains integers L,S1,S2. 
		//Next line contains Q, the number of queries. 
		//Each of the next Q lines consists of one integer qi in one line.
		public static void SherlockAndMovingTiles(string input, int speed1, int speed2, int length)
		{

			double area = double.Parse(input);
			double p = (speed1 - speed2) / Math.Sqrt(2);
			double a = Math.Sqrt(area);
			double t = (a - (double)length) / p;
			Console.WriteLine(Math.Abs(t));
		}

	}
}
