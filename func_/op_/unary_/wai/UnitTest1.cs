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
	public class UnitTest1
	{
		[TestMethod]
		public void TestMethod1()
		{
			var halves = Wai<double, IEnumerable<double>>(
				self => d => new[] { 0d }.SelectMany(_ => new[] { d }.Concat(self(d / 2)))
			);
			var fibonacci = Wai<int, int>(self => n => n > 1 ? self(n - 1) + self(n - 2) : n);
			var factorial = Wai<int, int>(self => n => n > 1 ? n * self(n - 1) : n);
			var hanoi = Wai<int, int>(self => n => n == 1 ? 1 : 2 * self(n - 1) + 1);

			foreach (var item in halves(20)) //retrieve the first item first.
			{
				Trace.WriteLine(item);
			}	/// the result will be 0 eventually and the loops then go on indefinitly.

		}
	}
}
#endif
