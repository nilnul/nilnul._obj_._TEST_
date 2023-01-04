using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using nilnul.obj.func;

namespace nilnul.obj._test.func
{
	[TestClass]
	public class Composite
	{
		
		[TestMethod]
		public void Composite_test()
		{

			//var x=new nilnul.obj.expr.Var<int>();
			var x = nilnul.obj.var.NamingContext1.CreateVar<int>("x");
			var three = new nilnul.obj.expr.Call<int>(3);

			var plus = nilnul.obj.op.binary.Closed.IntPlus;

			var xPlus3 = new nilnul.obj.expr.binary.Closed<int>(plus,x,three);

			var xPlus3_asFunc = new nilnul.obj.func.Nullary<int>(xPlus3);

			var func = new  nilnul.obj.func.Unary<int,int>(x, xPlus3 as expr.ExprI<int>);

			var func1 = new  nilnul.obj.func.Unary<int,int>(x, xPlus3 as expr.ExprI<int>);;


			var funcComposite = new nilnul.obj.func.Unary<int, int>.Composite<int, int, int>(func, func1);

			nilnul.obj.var.NamingContext1.StaticContext.set(funcComposite.func1.var, "y");
			var funcCompositeEvaled= funcComposite.eval();

			var funcCompositeEvaledCall = funcCompositeEvaled.apply(3);
			var funcCompositeEvaledCall_reduced = funcCompositeEvaledCall.reduce2new();




		}
	}
}
