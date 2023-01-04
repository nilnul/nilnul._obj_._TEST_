using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq.Expressions;
using System.Reflection;

namespace nilnul._obj_._TEST_.func.calc_.lambda
{
	[TestClass]
	public class UnitTest1
	{
		[TestMethod]
		public void TestMethod1()
		{
		}

		static public Expression<T> Execute<T>(Expression<T> func)
		{

			return func;
		}

		static public Expression<Func<T, T>> Ex<T>()
		{
			return Execute<Func<T, T>>(
				(T x) => x
			);
		}

		public class Gen<T>
		{

		}

		public static void MethodName()
		{
			dynamic instance = null;
			Type fieldType = null;// This is the type I have discovered
			Type genericType = typeof(Gen<>).MakeGenericType(fieldType);
			object genericInstance = Activator.CreateInstance(genericType);
			MethodInfo mi = genericType.GetMethod("DoSomething",
											BindingFlags.Instance | BindingFlags.Public);
			var value = Expression.Constant(instance, fieldType);

			var lambda = Expression.Lambda<Func<int>>(
				Expression.Call(Expression.Constant(genericInstance), mi, value));
			var answer = lambda.Compile()();

			//Delegate s =  (int x)  => 1 ;

			//delegate f1 = delegate { return 1; };
			//	var f = delegate (x) { return x; };
			//Delegate d = delegate (object o) { };



		}

	}
}
