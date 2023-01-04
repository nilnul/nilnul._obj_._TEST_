using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace nilnul._obj_._TEST_.func.op_.unary_.Ycombi
{
	[TestClass]
	public class UnitTest1
	{

		delegate Func<A, R> Recursive<A, R>(Recursive<A, R> r);
		static Func<A, R> Ycombi<A, R>(
			Func<
				Func<A, R>, Func<A, R>
			> f
		)
		{
			Recursive<A, R> rec = r => a => f(r(r))(a);
			return rec(rec);
		}

		[TestMethod]
		public void TestMethod1()
		{
			Func<int, int> fib = Ycombi<int, int>(f => n => n > 1 ? f(n - 1) + f(n - 2) : n);
			Func<int, int> fact = Ycombi<int, int>(f => n => n > 1 ? n * f(n - 1) : 1);
			Console.WriteLine(fib(6)); // displays 8
			Console.WriteLine(fact(6)); // displays 720		}
		}
	}
}
