#if TRIAL
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;


namespace nilnul._obj_._TEST_.stream.of_.str_.started_.recur
{
	[TestClass]
	public class UnitTest1
	{
		[TestMethod]
		public void TestMethod1()
		{
			double helper=1;
			IEnumerable<double> infinite=null;

			infinite = new object[] { null }.SelectMany(
				dummy => new double[] { helper = (helper / 2) }.Concat(
					infinite
				)
			);

			foreach (var item in infinite)
			{
				Trace.WriteLine(item);
			}	//0 eventually and then loops forever

			//double? helper=null;
			//IEnumerable<double> infinite=null;

			//infinite = new object[] { null }.SelectMany(
			//	dummy => new double[] { (helper = (helper / 2) ?? 1).Value }.Concat(
			//		infinite
			//	)
			//);

		}
	}
}
#endif