using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
using System.Collections;
using System.Net;
using System.Diagnostics;

namespace Solution
{
	class Program
	{
		public static Func<string, int> converter = new Func<string, int>((item) => int.Parse(item));
		static void Main(string[] args)
		{
			int num = int.Parse(Console.ReadLine());
			for (int i = 0; i < num; i++)
			{
				string input = Console.ReadLine();
			}
			Console.ReadKey();
		}


		public static List<T> convertToList<T>(string input, Func<string, T> converter)
		{
			List<T> l = input.Split(' ').ToList().Select(item => converter(item)).ToList();
			return l;
		}
	}
}
