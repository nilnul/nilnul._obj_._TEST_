using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;
using System.Linq.Expressions;

namespace nilnul._obj_._TEST_.expr_.lambda
{
	[TestClass]
	public class UnitTest1
	{
		[TestMethod]
		public void TestMethod1()
		{
		}

		public Expression<Func<string, string>> ConstructGreetingFunction1()
		{
			var personNameParameter = Expression.Parameter(typeof(string), "personName");

			// Condition
			var isNullOrWhiteSpaceMethod = typeof(string)
				.GetMethod(nameof(string.IsNullOrWhiteSpace));

			var condition = Expression.Not(
				Expression.Call(isNullOrWhiteSpaceMethod, personNameParameter));

			// True clause
			var concatMethod = typeof(string)
					.GetMethod(nameof(string.Concat), new[] { typeof(string), typeof(string) });
			var trueClause = Expression.Call(
					concatMethod,
					Expression.Constant("Greetings, "),
					personNameParameter);
			/// add is String.Concat
			//var trueClause = Expression.Add(
			//	Expression.Constant("Greetings, "),
			//	personNameParameter);

			// False clause
			var falseClause = Expression.Constant(null, typeof(string));

			var conditional = Expression.Condition(condition, trueClause, falseClause);

			var lambda = Expression.Lambda<Func<string, string>>(conditional, personNameParameter);

			return lambda;
		}



		public Func<string, string> ConstructGreetingFunction()
		{
			var personNameParameter = Expression.Parameter(typeof(string), "personName");

			// Condition
			var isNullOrWhiteSpaceMethod = typeof(string)
				.GetMethod(nameof(string.IsNullOrWhiteSpace));

			var condition = Expression.Not(
				Expression.Call(isNullOrWhiteSpaceMethod, personNameParameter));

			// True clause
			var trueClause = Expression.Add(
				Expression.Constant("Greetings, "),
				personNameParameter);

			// False clause
			var falseClause = Expression.Constant(null, typeof(string));

			var conditional = Expression.Condition(condition, trueClause, falseClause);

			var lambda = Expression.Lambda<Func<string, string>>(conditional, personNameParameter);

			return lambda.Compile();

		}

		static public Expression CreateStatementBlock()
		{
			var consoleWriteMethod = typeof(Console)
				.GetMethod(nameof(Console.Write), new[] { typeof(string) });

			var consoleWriteLineMethod = typeof(Console)
				.GetMethod(nameof(Console.WriteLine), new[] { typeof(string) });

			return Expression.Block(
				Expression.Call(consoleWriteMethod, Expression.Constant("Hello ")),
				Expression.Call(consoleWriteLineMethod, Expression.Constant("world!")));
		}

		public static void MethodName()
		{
			var block = CreateStatementBlock();
			Debug.Assert(
				block.Type == typeof(void)
			);

			var lambda = Expression.Lambda<Action>(block).Compile();

			lambda();
		}


		static public Expression CreateStatementBlock1()
		{
			var consoleWriteMethod = typeof(Console)
				.GetMethod(nameof(Console.Write), new[] { typeof(string) });

			var consoleWriteLineMethod = typeof(Console)
				.GetMethod(nameof(Console.WriteLine), new[] { typeof(string) });

			var variableA = Expression.Variable(typeof(string), "a");
			var variableB = Expression.Variable(typeof(string), "b");

			return Expression.Block(
				// Declare variables in scope
				new[] { variableA, variableB },

				// Assign values to variables
				Expression.Assign(variableA, Expression.Constant("Foo ")),
				Expression.Assign(variableB, Expression.Constant("bar")),

				// Call methods
				Expression.Call(consoleWriteMethod, variableA),
				Expression.Call(consoleWriteLineMethod, variableB));
		}
		static public void M()
		{
			var block = CreateStatementBlock1();
			var lambda = Expression.Lambda<Action>(block).Compile();

			lambda();

			// Foo bar
		}

	}
}
