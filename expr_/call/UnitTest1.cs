using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq.Expressions;
using System.Reflection;

namespace nilnul._obj_._TEST_.expr_.call
{
	[TestClass]
	public class UnitTest1
	{
		public class Command
		{
			private int Execute() => 42;
		}
		public static class ReflectionCached
		{
			private static MethodInfo ExecuteMethod { get; } = typeof(Command)
				.GetMethod("Execute", BindingFlags.NonPublic | BindingFlags.Instance);

			public static int CallExecute(Command command) => (int)ExecuteMethod.Invoke(command, null);
		}

		[TestMethod]
		public void TestMethod1()
		{
		}
		public static class ReflectionDelegate
		{
			private static MethodInfo ExecuteMethod { get; } = typeof(Command)
				.GetMethod("Execute", BindingFlags.NonPublic | BindingFlags.Instance);

			private static Func<Command, int> Impl { get; } =
				(Func<Command, int>)Delegate.CreateDelegate(typeof(Func<Command, int>), ExecuteMethod);

			public static int CallExecute(Command command) => Impl(command);
		}

		public static class ExpressionTrees
		{
			private static MethodInfo ExecuteMethod { get; } = typeof(Command)
				.GetMethod("Execute", BindingFlags.NonPublic | BindingFlags.Instance);

			private static Func<Command, int> Impl { get; }

			static ExpressionTrees()
			{
				var instance = Expression.Parameter(typeof(Command));
				var call = Expression.Call(instance, ExecuteMethod);
				Impl = Expression.Lambda<Func<Command, int>>(call, instance).Compile();
			}

			public static int CallExecute(Command command) => Impl(command);
		}
	}
}
