using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace nilnul._obj_._TEST_.nilnul0._obj._typ.gener
{
	[TestClass]
	public class UnitTest1
	{
		[TestMethod]
		public void TestMethod1()
		{

			UntypedMethod("hi");
			UntypedMethod(123);

			Assert.IsTrue(
				nilnul.obj.str.Eq<string>.Singleton.Equals(
					list, new[] { typeof(string).Name,typeof(int).Name }
				)
			);
		}

		static void UntypedMethod(object obj) {
			dynamic t = obj;
			GenerMethod(t);
		}

		static List<string> list = new List<string>();

		static void GenerMethod<T>(T item) {

			Debug.WriteLine(item.GetType().FullName);
			list.Add(item.GetType().Name);
			
		}
	}
}
