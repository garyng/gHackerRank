using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Solution
{
	public static class hrSolutions
	{
		public static Func<string, int> converter = new Func<string, int>((item) => int.Parse(item));

		#region Solutions
		
		//The first line contains an integer T representing the number of testcases 
		//Each test case is a line containing four space separated integers Px Py Qx Qy representing the (x,y) coordinates of P and Q.
		public static void FindPoint(string input)
		{
			List<int> points = input.Split(' ').ToList().Select(item => int.Parse(item)).ToList();
			int x = points[2] * 2 - points[0];
			int y = points[3] * 2 - points[1];
			Console.WriteLine(x + " " + y);
		}

		//The first line contains the number of test cases T. 
		//Next T lines contains an integer N which indicates the total pairs of socks present in the drawer.
		public static void MinimumDraws(string input)
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

		//The first line contains an integer, T, followed by T lines, each containing 4 space separated integers i.e. a b x y
		public static void PossiblePath(string input)
		{
			List<int> l = convertToList(input, new Func<string, int>((x) => int.Parse(x)));
			Console.WriteLine(GCD(l[0], l[1]) == GCD(l[2], l[3]) ? "YES" : "NO");
		}

		//The first line contains an integer T. T lines follow. 
		//Each line contains two space separated integers l and b which denote length and breadth of the bread.
		public static void Restaurant(string input)
		{
			List<int> l = convertToList(input, converter);
			int largest = GCD(l[0], l[1]);
			int num = l[0] * l[1] / (largest * largest);
			Console.WriteLine(num);
		}

		#endregion

		#region Helper Functions

		public static int GCD(int a, int b)
		{
			int x = a;
			int y = b;
			int temp = 0;

			while (y != 0)
			{
				temp = x;
				x = y;
				y = temp % y;

			}

			return x;
		}

		public static List<T> convertToList<T>(string input, Func<string, T> converter)
		{
			List<T> l = input.Split(' ').ToList().Select(item => converter(item)).ToList();
			return l;
		}

		#endregion
	}
}
