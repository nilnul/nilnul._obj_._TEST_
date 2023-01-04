using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using nilnul.obj;

namespace nilnul.obj._test.var._withType
{
	[Microsoft.VisualStudio.TestTools.UnitTesting.TestClass]
	public class NamingContext_testClass
	{
		[TestMethod]
		public void NamingContext_test()
		{
			var v = new nilnul.obj._var.Var_dynamicTyped( typeof( int) );

			var v2 = new nilnul.obj._var.Var_dynamicTyped( typeof(int));

			nilnul.obj.var.NamingContext2 namingContext = nilnul.obj.var.NamingContext2.StaticContext;

			namingContext.name(v, "x");
			namingContext.name(v2, "y");

		}

	}
	
}
