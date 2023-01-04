using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq.Expressions;

namespace nilnul._obj_._TEST_.expr_.op
{
	[TestClass]
	public class UnitTest1
	{
		[TestMethod]
		public void TestMethod1()
		{
		}

		public T ThreeFourths<T>(T x)
		{
			var param = Expression.Parameter(typeof(T));

			// Cast the numbers '3' and '4' to our type
			var three = Expression.Convert(Expression.Constant(3), typeof(T));
			var four = Expression.Convert(Expression.Constant(4), typeof(T));

			// Perform the calculation
			var operation = Expression.Divide(Expression.Multiply(param, three), four);

			var lambda = Expression.Lambda<Func<T, T>>(operation, param);

			var func = lambda.Compile();

			return func(x);
		}

		// ThreeFourths(18) -> 13
		// ThreeFourths(6.66) -> 4.995
		// ThreeFourths(100M) -> 75
	}
}
