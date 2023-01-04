using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq.Expressions;

namespace nilnul._obj_._TEST_.expr.substitute
{
	/// <summary>
	/// https://tyrrrz.me/blog/expression-trees
	/// </summary>
	[TestClass]
	public class UnitTest1
	{
		[TestMethod]
		public void TestMethod1()
		{
		}
		public static void MethodName()
		{
			Expression<Func<double>> expr = () => Math.Sin(Guid.NewGuid().GetHashCode()) / 10;
			var result = expr.Compile()();

			Console.WriteLine($"Old expression: {expr.ToString()}");
			Console.WriteLine($"Old result: {result}");

			var newExpr = (Expression<Func<double>>)new Visitor().Visit(expr);
			var newResult = newExpr.Compile()();

			Console.WriteLine($"New expression: {newExpr.ToString()}");
			Console.WriteLine($"New result value: {newResult}");

			// Old expression: () => Math.Sin((double)Guid.NewGuid().GetHashCode()) / 10d
			// Old result: 0.09489518488876232
			// New expression: () => Math.Cos((double)Guid.NewGuid().GetHashCode()) / 10d
			// New result value: 0.07306426748550407

		}


	}
	public class Visitor : ExpressionVisitor
	{
		protected override Expression VisitMethodCall(MethodCallExpression node)
		{
			var newMethodCall = node.Method == typeof(Math).GetMethod(nameof(Math.Sin))
				? typeof(Math).GetMethod(nameof(Math.Cos))
				: node.Method;

			return Expression.Call(newMethodCall, node.Arguments);
		}
	}

}
