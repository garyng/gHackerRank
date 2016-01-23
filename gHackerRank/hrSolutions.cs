using System;
using System.Collections;
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
			//https://www.hackerrank.com/challenges/find-point
			//The first line contains an integer T representing the number of testcases 
			//Each test case is a line containing four space separated integers Px Py Qx Qy representing the (x,y) coordinates of P and Q.

			List<int> points = input.Split(' ').ToList().Select(item => int.Parse(item)).ToList();
			int x = points[2] * 2 - points[0];
			int y = points[3] * 2 - points[1];
			Console.WriteLine(x + " " + y);
		}

		public static void MinimumDraws(string input)
		{
			//https://www.hackerrank.com/challenges/minimum-draws
			//The first line contains the number of test cases T. 
			//Next T lines contains an integer N which indicates the total pairs of socks present in the drawer.

			int num = int.Parse(input);
			Console.WriteLine(num + 1);
		}

		public static void SherlockAndMovingTiles(string input, int speed1, int speed2, int length)
		{
			//https://www.hackerrank.com/challenges/sherlock-and-moving-tiles
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
			//https://www.hackerrank.com/challenges/possible-path
			//The first line contains an integer, T, followed by T lines, each containing 4 space separated integers i.e. a b x y

			List<int> l = convertToList(input, new Func<string, int>((x) => int.Parse(x)));
			Console.WriteLine(GCD(l[0], l[1]) == GCD(l[2], l[3]) ? "YES" : "NO");
		}

		public static void Restaurant(string input)
		{
			//https://www.hackerrank.com/challenges/restaurant
			//The first line contains an integer T. T lines follow. 
			//Each line contains two space separated integers l and b which denote length and breadth of the bread.

			List<int> l = convertToList(input, converter);
			int largest = GCD(l[0], l[1]);
			int num = l[0] * l[1] / (largest * largest);
			Console.WriteLine(num);
		}

		public static void ConnectingTown(string n, string r)
		{
			//https://www.hackerrank.com/challenges/connecting-towns
			//The first line contains an integer T, T test-cases follow. 
			//Each test-case has 2 lines. The first line contains an integer N (the number of towns). 
			//The second line contains N - 1 space separated integers where the ith integer denotes the number of routes, Ni, from the town Ti to Ti+1

			int noOfTown = int.Parse(n);
			List<int> routes = convertToList(r, converter);
			int mul = 1;
			routes.ForEach((item) => mul = mul * item % 1234567);   // (a*b) mod c = (a mod c)*(b mod c)
			Console.WriteLine(mul);
		}

		public static void Handshake(string input)
		{
			//https://www.hackerrank.com/challenges/handshake
			//The first line contains the number of test cases T, T lines follow. 
			//Each line then contains an integer N, the total number of Board of Directors of Acme.
			int num = int.Parse(input);
			Console.WriteLine(arithmeticSum(1, 1, num - 1));

		}

		public static void ReverseGame(string input)
		{
			//https://www.hackerrank.com/challenges/reverse-game
			//The first line contains an integer T, i.e., the number of the test cases. 
			//The next T lines will contain two integers N and K.

			List<int> v = convertToList(input, converter);
			int length = v[0]; //7
			int num = v[1];  //0
			int i = 0;
			int startIndex = 0;

			while (true)
			{
				num = length + i - 1 - num;
				startIndex = i;
				if (num == startIndex)
				{
					break;
				}
				i++;
			}
			Console.WriteLine(num);
		}

		public static void StrangeGrid(string input)
		{
			//https://www.hackerrank.com/challenges/strange-grid
			//There will be two integers r and c separated by a single space.

			List<long> val = convertToList(input, new Func<string, long>(item => long.Parse(item)));
			long row = val[0];
			long col = val[1];

			long num = 0;

			// long typed / 2 -> Floored
			num = 2 * col - (row % 2 == 0 ? 1 : 2) + ((row - 1) / 2) * 10;

			Console.WriteLine(num);

		}

		public static void SherlockAndDivisors(string input)
		{
			//https://www.hackerrank.com/challenges/sherlock-and-divisors
			//First line contains T, the number of testcases. This is followed by T lines each containing an integer N.

			long num = long.Parse(input);
			Dictionary<long, long> factors = findPrimeFactors(num);

			long noOfPow2;
			if (factors.TryGetValue(2, out noOfPow2))
			{
				if (factors.Count == 1) //Only Power of 2
				{
					Console.WriteLine(noOfPow2);
				}
				else
				{
					long all = findFactorsCount(factors);
					factors.Remove(2);
					long odd = findFactorsCount(factors);
					Console.WriteLine(all - odd);
				}
			}
			else
			{
				Console.WriteLine("0");
			}

		}

		public static void DiwaliLights(string input)
		{
			//https://www.hackerrank.com/challenges/diwali-lights
			//The first line contains the number of test cases T, T lines follow. 
			//Each line contains an integer N, the number of bulbs in the serial light bulb set.

			long num = long.Parse(input);
			long pow = 1;
			for (int i = 0; i < num; i++)
			{
				pow = (pow << 1) % 100000;
			}
			Console.WriteLine(pow - 1);

		}

		public static void SummingTheNSeries(string input)
		{
			//https://www.hackerrank.com/challenges/summing-the-n-series
			//The first line of input contains T, the number of test cases.
			//Each test case consists of one line containing a single integer n.

			BigInteger num = BigInteger.Parse(input);
			BigInteger r = BigInteger.Pow(num, 2);
			BigInteger rem;
			BigInteger.DivRem(r, 1000000007, out rem);
			Console.WriteLine(rem);
		}

		public static void SumarAndTheFloatingRocks(string input)
		{
			//https://www.hackerrank.com/challenges/harry-potter-and-the-floating-rocks
			//The first line contains a single integer T, the number of test cases. T lines follow. 
			//Each of the following T lines contains one test case each. Each test case contains 4 integers x1, y1, x2 and y2 separated by a single space.

			List<long> val = convertToList<long>(input, new Func<string, long>(item => long.Parse(item)));
			long dx = val[0] - val[2];
			long dy = val[1] - val[3];

			long gcd = GCD(Math.Abs(dx), Math.Abs(dy));

			Console.WriteLine(gcd - 1);

		}

		public static void HalloweenParty(string input)
		{
			//https://www.hackerrank.com/challenges/halloween-party
			//The first line contains an integer T, the number of test cases. T lines follow.
			//Each line contains an integer K.

			long cut = long.Parse(input);
			long num = (cut % 2 == 0) ? ((cut / 2) * (cut / 2)) : ((cut + 1) / 2 * ((cut + 1) / 2 - 1));
			Console.WriteLine(num);
		}

		public static void FillingJars()
		{
			//https://www.hackerrank.com/challenges/filling-jars
			//The first line contains two integers, N and M, separated by a single space. 
			//M lines follow; each of them contains three integers, a, b, and k, separated by spaces.

			List<long> val = convertToList<long>(Console.ReadLine(), new Func<string, long>(item => long.Parse(item)));
			long jarNum = val[0];
			long count = val[1];
			long sum = 0;
			for (long i = 0; i < count; i++)
			{
				val = convertToList<long>(Console.ReadLine(), new Func<string, long>(item => long.Parse(item)));
				long startIndex = val[0];
				long endIndex = val[1];
				long fillNum = val[2];

				sum += (endIndex - startIndex + 1) * fillNum;
			}
			long avg = sum / jarNum;

			Console.WriteLine(avg);

		}

		public static void IsFibo(string input, List<long> fibCache)
		{
			//https://www.hackerrank.com/challenges/is-fibo
			//The first line contains T, number of test cases. 
			//T lines follow. Each line contains an integer N.

			long num = long.Parse(input);
			if (fibCache.IndexOf(num) >= 0)
			{
				Console.WriteLine("IsFibo");
			}
			else
			{
				Console.WriteLine("IsNotFibo");
			}
		}

		public static void BusStation()
		{
			//https://www.hackerrank.com/challenges/bus-station
			//The first line contains an integer n (1≤n≤105). The second line contains n space-separated integers a1,a2,…,an (1≤ai≤104).

			long groupCount = long.Parse(Console.ReadLine());
			List<long> lGroupSize = convertToList<long>(Console.ReadLine(), new Func<string, long>(item => long.Parse(item)));
			List<long> lCumulativeSum = new List<long>();
			HashSet<long> hsCumulativeSum = new HashSet<long>();


			lCumulativeSum.Add(lGroupSize.First());
			hsCumulativeSum.Add(lGroupSize.First());

			long sum = 0;
			for (int i = 1; i < groupCount; i++)
			{
				sum = lCumulativeSum[i - 1] + lGroupSize[i];
				lCumulativeSum.Add(sum);
				hsCumulativeSum.Add(sum);
			}

			long cumulativeSum = lCumulativeSum.Last();

			List<long> divisors = findAllDivisors(cumulativeSum);
			divisors.Sort();

			List<long> ans = new List<long>();

			foreach (long div in divisors)
			{
				long k = 1;
				while (k * div <= cumulativeSum)
				{
					if (!hsCumulativeSum.Contains(k * div))
					{
						break;
					}
					if (k * div == cumulativeSum)
					{
						ans.Add(div);
					}
					k++;
				}
			}
			Console.WriteLine(string.Join(" ", ans));

		}

		public static void UtopianTree(string input)
		{
			//https://www.hackerrank.com/challenges/utopian-tree
			//The first line contains an integer, T, the number of test cases. 
			//T subsequent lines each contain an integer, N, denoting the number of cycles for that test case.

			long cycle = long.Parse(input);
			long height = 1;
			for (long i = 0; i < cycle; i++)
			{
				height = (i % 2 == 0) ? height * 2 : height + 1;
			}

			Console.WriteLine(height);
		}

		public static void KCandyStore()
		{
			//https://www.hackerrank.com/challenges/k-candy-store
			//The first line contains an integer T, the number of tests. 
			//This is followed by 2T lines which contain T tests: 
			//The first line(of each testcase) is an integer N and the second line (of each testcase) is an integer K.

			BigInteger types = BigInteger.Parse(Console.ReadLine());
			BigInteger choose = BigInteger.Parse(Console.ReadLine());

			BigInteger n = choose + types - 1;
			BigInteger r = types - 1;

			BigInteger nCrN = 1;
			BigInteger nCrR = 1;

			while (r > 0)
			{
				nCrN *= n;
				nCrR *= r;
				n--;
				r--;
			}

			BigInteger nCr = BigInteger.Divide(nCrN, nCrR);
			nCr = BigInteger.Remainder(nCr, 1000000000);
			Console.WriteLine(nCr.ToString());

		}

		public static void DieHard3(string input)
		{
			//https://www.hackerrank.com/challenges/die-hard-3
			//First line contains the number of testcases T. T lines follow.
			//Each line contains 3 space separated integers a, b and c .
			//a and b indicate the capacity of the two jugs respectively, and c denotes the exact capacity with which one of the jugs should be filled.

			List<int> vals = convertToList<int>(input, converter);
			int a = vals[0];
			int b = vals[1];
			int target = vals[2];

			int g = GCD(a, b);
			if (target > a && target > b)
			{
				Console.WriteLine("NO");
			}
			else
			{
				if (target % g != 0)
				{
					Console.WriteLine("NO");
				}
				else
				{
					Console.WriteLine("YES");
				}
			}

		}

		public static void SherlockandPermutations(string input)
		{
			//https://www.hackerrank.com/challenges/sherlock-and-permutations
			//First line contains T, the number of test cases. 
			//Each test case consists of N and M separated by a space.

			List<int> vals = convertToList<int>(input, converter);
			int N = vals[0];
			int M = vals[1];

			int numeratorFac = N + (M - 1);
			int denominatorNFac = N;
			int denominatorMFac = M - 1;

			BigInteger nr = 1;
			BigInteger dr = 1;

			while (numeratorFac > 0)
			{
				nr *= numeratorFac;
				numeratorFac--;

				dr *= denominatorNFac <= 0 ? 1 : denominatorNFac;
				denominatorNFac--;

				dr *= denominatorMFac <= 0 ? 1 : denominatorMFac;
				denominatorMFac--;
			}

			BigInteger fac = BigInteger.Divide(nr, dr);
			fac = BigInteger.Remainder(fac, 1000000007);
			Console.WriteLine(fac.ToString());

		}

		public static void SpecialMultiple(string input)
		{
			//https://www.hackerrank.com/challenges/special-multiple
			//The first line contains an integer T which denotes the number of test cases. T lines follow. 
			//Each line contains the integer N for which the solution has to be found.

			int n = int.Parse(input);
			double max = Math.Pow(2, 13);

			for (int i = 1; i < max; i++)
			{
				long b = long.Parse(Convert.ToString(i, 2)) * 9;

				if (b % n == 0)
				{
					Console.WriteLine(b.ToString());
					break;
				}
			}
		}

		public static void MatrixTracing(string input)
		{
			//https://www.hackerrank.com/challenges/matrix-tracing
			//The first line of input contains an integer T.T test cases follow. 
			//Each test case contains 2 space separated integers m &n(in a new line) indicating that the matrix has m rows and each row has n characters.

			List<long> vals = convertToList<long>(input, new Func<string, long>(item => long.Parse(item)));

			long m = vals[0];
			long n = vals[1];

			long nC = m + n - 1 - 1;
			long Cr = n - 1;

			Console.WriteLine(nCr(nC, Cr, 1000000007));
		}

		#endregion

		#region Project Euler

		public static void euler001(string input)
		{
			//https://www.hackerrank.com/contests/projecteuler/challenges/euler001
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
			//https://www.hackerrank.com/contests/projecteuler/challenges/euler002
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

		public static void euler003(string input)
		{
			//https://www.hackerrank.com/contests/projecteuler/challenges/euler003
			//First line contains T, the number of test cases. This is followed by T lines each containing an integer N.
			//Find largest prime factor

			long num = long.Parse(input);
			long largest = 1;


			long i = 2;
			while (i * i <= num)
			{
				if (num % i == 0)
				{
					num = num / i;
					largest = i;
				}
				else
				{
					i = (i == 2) ? 3 : i + 2;
				}
			}
			if (num > largest)
			{
				largest = num;
			}

			Console.WriteLine(largest);
		}

		#endregion

		#endregion

		#region Helper Functions

		public static long nCr(long n, long r, long p)
		{
			//nCr mod p, p is a prime
			//n<=r
			long a = 1;
			long b = 1;

			while (r > 0)
			{
				a *= n;
				a %= p;
				n--;

				b *= r;
				b %= p;
				r--;
			}

			b = powWithMod(b, p - 2, p) % p;

			return (a * b) % p;

		}

		public static long powWithMod(long a, long n, long p)
		{
			//Exponentiation by Squaring
			//https://en.wikipedia.org/wiki/Exponentiation_by_squaring

			long result = 1;
			while (n > 0)
			{
				if (n % 2 == 1)
				{
					result *= a;
					result %= p;
					n--;
				}
				a *= a;
				a %= p;
				n /= 2;
			}
			return result % p;
		}

		public static long findFactorsCount(Dictionary<long, long> factors)
		{
			long count = 1;
			foreach (KeyValuePair<long, long> item in factors)
			{
				count *= item.Value + 1;
			}
			return count;
		}
		public static Dictionary<long, long> findPrimeFactors(long num)
		{

			long factor = 2;
			Dictionary<long, long> dFactors = new Dictionary<long, long>(); //Prime,Pow

			long fac;
			long largestFac = 0;
			while (factor * factor <= num)
			{
				if (num % factor == 0)
				{
					num = num / factor;
					largestFac = factor;
					if (dFactors.TryGetValue(factor, out fac))
					{
						dFactors[factor] = dFactors[factor] + 1;
					}
					else
					{
						dFactors.Add(factor, 1);
					}
				}
				else
				{
					factor = (factor == 2) ? 3 : factor + 2;
				}
			}

			// num is a prime
			if (num >= largestFac)
			{
				if (dFactors.TryGetValue(num, out fac))
				{
					dFactors[num] = dFactors[num] + 1;
				}
				else
				{
					dFactors.Add(num, 1);
				}
			}

			return dFactors;
		}
		public static List<long> findAllDivisors(long num)
		{
			List<long> divisors = new List<long>();

			long div = 1;
			while (div * div <= num)
			{
				if (num % div == 0)
				{
					divisors.Add(div);
					if (num / div != div)   // Duplicate when num is a perfect square
					{
						divisors.Add(num / div);
					}
				}
				div++;
			}

			return divisors;
		}

		public static List<int> ESieve(int max)
		{
			BitArray baSeive = new BitArray(max - 1);
			List<int> primes = new List<int>();
			for (int i = 2; i < baSeive.Count + 2; i++)
			{
				if (baSeive.Get(i - 2) == false)
				{
					for (int j = i + i; j <= max; j += i)
					{
						baSeive.Set(j - 2, true);
					}
				}
			}
			for (int i = 0; i < baSeive.Count; i++)
			{
				if (baSeive.Get(i) == false)
				{
					primes.Add(i + 2);
				}
			}
			return primes;
		}

		public static List<long> cacheFibonacci(long max)
		{
			List<long> fibCache = new List<long>();
			fibCache.Add(0);
			fibCache.Add(1);

			int i = 2;
			while (fibCache.Last() < max)
			{
				fibCache.Add(fibCache[i - 1] + fibCache[i - 2]);
				i++;
			}

			return fibCache;
		}
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
		public static long GCD(long a, long b)
		{
			long x = a;
			long y = b;
			long temp = 0;

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
