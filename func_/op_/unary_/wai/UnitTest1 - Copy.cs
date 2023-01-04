#if TRIAL

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using static nilnul.obj.func.lamda_.combi_._WaiX;

namespace nilnul._obj_._TEST_.func_.op_.unary_.wai
{
	[TestClass]
	public class UnitTest11
	{
		[TestMethod]
		public void TestMethod1()
		{

			Func<
				Func<
					Func<int, double>
					,
					Func<int, double>
				>
				,
				Func<int, double>
			> Wai = null;

			Wai= f=>t => f(Wai(f))(t);



			Func<int, int> factorial = null;
			factorial=n => n * factorial(n - 1);


		}
	}
}
#endif
