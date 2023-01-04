using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace nilnul._obj_._TEST_.nilnul0._obj._typ.gener.typeof0
{
	[TestClass]
	public class UnitTest11
	{
		[TestMethod]
		public void TestMethod1()
		{

			UntypedMethod("hi");
			UntypedMethod(123);



			Assert.IsFalse(
				nilnul.obj.str.Eq<string>.Singleton.Equals(
					list, new[] { typeof(string).Name, typeof(int).Name }
				)
			);
		}

		static void UntypedMethod(object obj)
		{
			//dynamic t = obj;
			GenerMethod(obj);
		}

		static List<string> list = new List<string>();

		static void GenerMethod<T>(T item)
		{
			var typ = typeof(T);

			Debug.WriteLine(typeof(T).FullName);
			list.Add(typ.Name);

		}
	}
}
