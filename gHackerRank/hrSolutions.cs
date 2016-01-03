using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace Solution
{
	public static class hrSolutions
	{
		public static Func<string, int> converter = new Func<string, int>((item) => int.Parse(item));

		#region Solutions

		#region Mathematic>Fundamentals

		public static void FindPoint(string input)
		{
			//The first line contains an integer T representing the number of testcases 
			//Each test case is a line containing four space separated integers Px Py Qx Qy representing the (x,y) coordinates of P and Q.

			List<int> points = input.Split(' ').ToList().Select(item => int.Parse(item)).ToList();
			int x = points[2] * 2 - points[0];
			int y = points[3] * 2 - points[1];
			Console.WriteLine(x + " " + y);
		}

		public static void MinimumDraws(string input)
		{
			//The first line contains the number of test cases T. 
			//Next T lines contains an integer N which indicates the total pairs of socks present in the drawer.

			int num = int.Parse(input);
			Console.WriteLine(num + 1);
		}

		public static void SherlockAndMovingTiles(string input, int speed1, int speed2, int length)
		{
			//First line contains integers L,S1,S2. 
			//Next line contains Q, the number of queries. 
			//Each of the next Q lines consists of one integer qi in one line.

			double area = double.Parse(input);
			double p = (speed1 - speed2) / Math.Sqrt(2);
			double a = Math.Sqrt(area);
			double t = (a - (double)length) / p;
			Console.WriteLine(Math.Abs(t));
		}

		public static void PossiblePath(string input)
		{
			//The first line contains an integer, T, followed by T lines, each containing 4 space separated integers i.e. a b x y

			List<int> l = convertToList(input, new Func<string, int>((x) => int.Parse(x)));
			Console.WriteLine(GCD(l[0], l[1]) == GCD(l[2], l[3]) ? "YES" : "NO");
		}

		public static void Restaurant(string input)
		{
			//The first line contains an integer T. T lines follow. 
			//Each line contains two space separated integers l and b which denote length and breadth of the bread.

			List<int> l = convertToList(input, converter);
			int largest = GCD(l[0], l[1]);
			int num = l[0] * l[1] / (largest * largest);
			Console.WriteLine(num);
		}

		public static void ConnectingTown(string n, string r)
		{
			//The first line contains an integer T, T test-cases follow. 
			//Each test-case has 2 lines. The first line contains an integer N (the number of towns). 
			//The second line contains N - 1 space separated integers where the ith integer denotes the number of routes, Ni, from the town Ti to Ti+1

			int noOfTown = int.Parse(n);
			List<int> routes = convertToList(r, converter);
			int mul = 1;
			routes.ForEach((item) => mul = mul * item % 1234567);	// (a*b) mod c = (a mod c)*(b mod c)
			Console.WriteLine(mul);
		}

		#endregion

		#region Project Euler

		public static void euler001(string input)
		{
			//First line contains T that denotes the number of test cases. This is followed by T lines, each containing an integer, N.

			BigInteger max = BigInteger.Parse(input) - 1;
			BigInteger mul1 = 3;
			BigInteger mul2 = 5;
			BigInteger mul3 = mul1 * mul2;

			BigInteger o;

			BigInteger mul1N = BigInteger.DivRem(max, mul1, out o);
			BigInteger mul1Sum = arithmeticSum(mul1, mul1, mul1N);

			BigInteger mul2N = BigInteger.DivRem(max, mul2, out o);
			BigInteger mul2Sum = arithmeticSum(mul2, mul2, mul2N);

			BigInteger mul3N = BigInteger.DivRem(max, mul3, out o);
			BigInteger mul3Sum = arithmeticSum(mul3, mul3, mul3N);

			Console.WriteLine(mul1Sum + mul2Sum - mul3Sum);

		}

		public static void euler002(string input, List<long> fibCache)
		{
			//First line contains T that denotes the number of test cases. This is followed by T lines, each containing an integer, N.
			long max = long.Parse(input);

			int j = 2;
			long sum = 0;
			while (fibCache[j] <= max)
			{
				sum += fibCache[j];
				j += 3;
			}
			Console.WriteLine(sum);
		}

		#endregion

		#endregion

		#region Helper Functions

		public static List<long> cacheFibonacci(int n)
		{
			List<long> fibCache = new List<long>();
			fibCache.Add(1);
			fibCache.Add(1);
			for (int i = 2; i < 100; i++)
			{
				fibCache.Add(fibCache[i - 1] + fibCache[i - 2]);
			}
			return fibCache;
		}
		public static long Fibonacci(long n)
		{
			double sqrt5 = Math.Sqrt(5);
			double phi = (1 - sqrt5) / 2.0;
			double Phi = (1 + sqrt5) / 2.0;

			double fib = (Math.Pow(Phi, (double)n) - Math.Pow(phi, (double)n)) / sqrt5;
			return (long)fib;

		}

		public static BigInteger arithmeticSum(BigInteger a, BigInteger d, BigInteger n)
		{
			BigInteger tN = a + (n - 1) * d;
			return (a + tN) * n / 2;
		}

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
