using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Diagnostics;

namespace nilnul.obj._test._func
{
	[TestClass]
	public class ExprAsFunc_testClass
	{
		[TestMethod]
		public void ExprAsFunc_test()
		{
			var v = new nilnul.obj._var.Var_dynamicTyped(typeof(int));

			var v1 = new nilnul.obj._var.Var_dynamicTyped(typeof(string));

			nilnul.obj.var.NamingContext2 namingContext = nilnul.obj.var.NamingContext2.StaticContext;

			namingContext.name(v, "x");
			namingContext.name(v1, "y");

			var strRepeatOp = new nilnul.obj.duo.op.FuncAsOp<int, string, string>(
					(i, s) => (string.Concat(Enumerable.Repeat(s, i)))
				);

			nilnul.obj.NamingContext.Name(strRepeatOp, "*");

			var strRepeatExpr = new nilnul.obj.expr.duo.Call<int, string, string>(strRepeatOp, v, v1);

			var asFunc = new nilnul.obj._func.ExprAsFunc(strRepeatExpr);


			Debug.WriteLine(asFunc);





		}
	}
}
