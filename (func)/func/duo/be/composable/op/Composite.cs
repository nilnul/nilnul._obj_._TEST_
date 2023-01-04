using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using nilnul.obj.func;
using nilnul.obj._func.func;
using nilnul.obj.func.mono.op;

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace nilnul.obj._test.func.duo.composable
{
	[TestClass]
	public class Composite
	{
		
		[TestMethod]
		public void Composite_test()
		{

			//var x=new nilnul.obj.expr.Var<int>();

			
			var x = nilnul.obj.var.NamingContext1.CreateVar<int>("x");

			var x1 = new nilnul.obj._var.Var<int>();
			nilnul.obj.var.NamingContext2.Name(x1, "x");

			var three = new nilnul.obj.expr.Call<int>(3);

			var three1 = new nilnul.obj._expr.Form<int>(3);


			var plus = nilnul.obj.op.binary.Closed.IntPlus;
			var plus1 = new nilnul.obj.duo.op.Closed<int>( (xx,y)=>xx+y);

			nilnul.obj.NamingContext.Name(plus1, "+");

			var xPlus3 = new nilnul.obj.expr.binary.Closed<int>(plus,x,three);

			var xPlus3_1 = new nilnul.obj.expr.duo.Call<int,int,int>(plus1, x1,three1 );

			var xPlus3_asFunc = new nilnul.obj.func.Nullary<int>(xPlus3);
			var xPlus3_asFunc1 = nilnul.obj._func.Func.Create(xPlus3_1);


			//var func = new  nilnul.obj.func.Unary<int,int>(x, xPlus3 as expr.ExprI<int>);
			var func__1 =   nilnul.obj.func.mono.op.Vary.Eval( xPlus3_1 ,x1);

			//var func1 = new  nilnul.obj.func.Unary<int,int>(x, xPlus3 as expr.ExprI<int>);;

			var func1__1=nilnul.obj.func.mono.op.Vary.Eval( xPlus3_1 ,x1);

			//var funcComposite = new nilnul.obj.func.Unary<int, int>.Composite<int, int, int>(func, func1);

			var funcComposite1 = nilnul.obj.func.duo.composable.op.Composite._Eval__assertComposable(func__1, func1__1);

			nilnul.obj.NamingContext.StaticContext.name(funcComposite1.vars.First(), "y");


			var funcCompositeEvaled= funcComposite1.Reduce();

			var funcCompositeEvaledCall = nilnul.obj.func.mono.op.ApplyStatic.Eval(funcCompositeEvaled, new form.no.Call<int>(3));
			var funcCompositeEvaledCall_reduced = funcCompositeEvaledCall.Reduce();




		}
	}
}
