using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using nilnul.obj.func;

namespace nilnul.obj._test
{
	[TestClass]
	public class Call
	{
		[TestMethod]
		public void Call_test()
		{
			var intOp = new nilnul.obj.op.binary.Closed<int>((x, y) => x + y);

			intOp.name = "+";



			var call = new nilnul.obj.call.binary.Closed<int>(intOp, 3, 5);

			var callStr = call.ToString();

			var callEval = call.eval();



		}

		[TestMethod]
		public void Expr_test()
		{


			//var x=new nilnul.obj.expr.Var<int>();
			var x = nilnul.obj.var.NamingContext1.CreateVar<int>("x");
			var three = new nilnul.obj.expr.Call<int>(3);

			var plus = nilnul.obj.op.binary.Closed.IntPlus;

			var xPlus3 = new nilnul.obj.expr.binary.Closed<int>(plus,x,three);

			var xPlus3str = xPlus3.ToString();









		}
		[TestMethod]
		public void Func_test()
		{

			//var x=new nilnul.obj.expr.Var<int>();
			var x = nilnul.obj.var.NamingContext1.CreateVar<int>("x");
			var three = new nilnul.obj.expr.Call<int>(3);

			var plus = nilnul.obj.op.binary.Closed.IntPlus;

			var xPlus3 = new nilnul.obj.expr.binary.Closed<int>(plus,x,three);

			var xPlus3_asFunc = new nilnul.obj.func.Nullary<int>(xPlus3);

			var func = nilnul.obj.func.op.Param.Eval(x, xPlus3 as expr.ExprI<int>);

			//var func = nilnul.obj.func.op.Param.Eval(x, xPlus3_asFunc);

			///int => ()=>x+3
			//var funcApply = nilnul.obj.func.op.Apply.Eval<int,Void,int>(func as FuncI1<int,obj.func.Expr<int>> ,2);

			var funcApply= func.apply(2);

			var funcReduced2new= func.reduce2new();


			var funcDemoted = func;

			//var funcAbstract = new nilnul.obj.func.op.Abstraction.Call<string, int, nilnul.obj.func.FuncI<Void, int>>(
			//	nilnul.obj.var.NamingContext1.CreateVar<string>("z")
			//	,
			//	func
			//);

			var funcParam = nilnul.obj.func.op.Param.Eval(
				nilnul.obj.var.NamingContext1.CreateVar<string>("z")
				, func
			);

			var funcParamApply = funcParam.apply("");
			var funcParamApplyApply = funcParamApply.apply(3);

			var funcParamApplyApply_reduced2new= funcParamApplyApply.reduce2new();



		}
	}
}
