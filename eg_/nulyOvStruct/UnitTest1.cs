using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace nilnul._obj_._TEST_.eg_.nulyOvStruct
{
	[TestClass]
	public class UnitTest1
	{
		[TestMethod]
		public void TestMethod1()
		{
			int? a = null;
			if (a is null)
			{

			}
			else
			{
				throw new AssertFailedException(
					"that Nullable struct is null, shall succeed."
				);
			}
		}
	}
}
