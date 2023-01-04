using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace nilnul.obj._test._expr
{
	[Microsoft.VisualStudio.TestTools.UnitTesting.TestClass]
	public class Expr_dynamic__testClass
	{
		[TestMethod]
		public void Expr_dynamic__test()
		{

			var v = new nilnul.obj._var.Var_dynamicTyped(typeof(int));

			var v1 = new nilnul.obj._var.Var_dynamicTyped(typeof(string));

			nilnul.obj.var.NamingContext2 namingContext = nilnul.obj.var.NamingContext2.StaticContext;

			namingContext.name(v, "x");
			namingContext.name(v1, "y");

			var strRepeatOp = new nilnul.obj.duo.op.FuncAsOp<int, string, string>(
					(i,s)=>(string.Concat(Enumerable.Repeat(s, i)))
				);

			nilnul.obj.NamingContext.Name(strRepeatOp, "*");

			var strRepeatExpr = new nilnul.obj.expr.duo.Call<int, string, string>(strRepeatOp, v, v1);

			Debug.WriteLine(strRepeatExpr);



		}

	}
	
}
