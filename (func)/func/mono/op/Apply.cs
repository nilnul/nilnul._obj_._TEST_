using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Diagnostics;

namespace nilnul.obj._test.func.mono.op
{
	[TestClass]
	public class Apply_testClass
	{
		[TestMethod]
		public void Apply_test()
		{

			var v = new nilnul.obj._var.Var_dynamicTyped(typeof(int));

			var v1 = new nilnul.obj._var.Var_dynamicTyped(typeof(string));

			var v2 = new nilnul.obj._var.Var_dynamicTyped(typeof(object));

			nilnul.obj.var.NamingContext2 namingContext = nilnul.obj.var.NamingContext2.StaticContext;

			namingContext.name(v, "x");
			namingContext.name(v1, "y");

			var strRepeatOp = new nilnul.obj.duo.op.FuncAsOp<int, string, string>(
					(i, s) => (string.Concat(Enumerable.Repeat(s, i)))
				);

			nilnul.obj.NamingContext.Name(strRepeatOp, "*");



			var strRepeatExpr = new nilnul.obj.expr.duo.Call<int, string, string>(strRepeatOp, v, v1);

			var asFunc = new nilnul.obj._func.ExprAsFunc(strRepeatExpr);

			var varied = nilnul.obj.func.mono.op.Vary.Eval(asFunc, v);

			var varied2 = nilnul.obj.func.mono.op.Vary.Eval(varied, v2);


			Debug.WriteLine(varied2);


			var applyCall = new nilnul.obj.func.mono.op.Apply.Call(varied2, 3);

			var applyCall_applied = applyCall.eval();

			var applyCall_X= new nilnul.obj.func.mono.op.Apply.Call(varied, 3);

			var applyCall_x__evaled = applyCall_X.eval();

			var applyCall_yVary_Apply = new nilnul.obj.func.mono.op.Apply.Call(
				
				nilnul.obj.func.mono.op.Vary.Eval(applyCall_x__evaled, v1)
				,
				"abc"
			).eval();

			var exprREduced=applyCall_yVary_Apply.expr.reduce();



			
		}
	}
}
