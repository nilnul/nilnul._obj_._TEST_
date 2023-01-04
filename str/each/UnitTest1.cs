using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace nilnul._obj_._TEST_.str.each
{
	[TestClass]
	public class UnitTest1
	{
		[TestMethod]
		public void TestMethod1()
		{
			foreach (var item in Iterator())
			{

			}


		}

		static IEnumerable<string> Iterator()
		{
			try
			{
				Console.WriteLine("Before first yield");
				yield return "first";
				Console.WriteLine("Between yields");
				yield return "second";
				Console.WriteLine("After second yield");
			}
			finally
			{
				Console.WriteLine("In finally block");
			}
		}

	}
}
