using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq.Expressions;

namespace nilnul._obj_._TEST_.expr_.lambda.compiled
{
	[TestClass]
	public class UnitTest1
	{
		[TestMethod]
		public void TestMethod1()
		{
		}
	}

	public static class ThreeFourths
	{
		private static class Impl<T>
		{
			public static Func<T, T> Of { get; }

			static Impl()
			{
				var param = Expression.Parameter(typeof(T));

				var three = Expression.Convert(Expression.Constant(3), typeof(T));
				var four = Expression.Convert(Expression.Constant(4), typeof(T));

				var operation = Expression.Divide(Expression.Multiply(param, three), four);

				var lambda = Expression.Lambda<Func<T, T>>(operation, param);

				Of = lambda.Compile();
			}
		}

		public static T Of<T>(T x) => Impl<T>.Of(x);
	}

	// ThreeFourths.Of(18) -> 13
}
