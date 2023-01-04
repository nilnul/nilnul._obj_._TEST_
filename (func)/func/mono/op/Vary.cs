using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

namespace nilnul.obj._test.func.mono.op
{
	/// <summary>
	/// Summary description for Vary
	/// </summary>
	[TestClass]
	public class Vary
	{
		public Vary()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		private TestContext testContextInstance;

		/// <summary>
		///Gets or sets the test context which provides
		///information about and functionality for the current test run.
		///</summary>
		public TestContext TestContext
		{
			get
			{
				return testContextInstance;
			}
			set
			{
				testContextInstance = value;
			}
		}

		#region Additional test attributes
		//
		// You can use the following additional attributes as you write your tests:
		//
		// Use ClassInitialize to run code before running the first test in the class
		// [ClassInitialize()]
		// public static void MyClassInitialize(TestContext testContext) { }
		//
		// Use ClassCleanup to run code after all tests in a class have run
		// [ClassCleanup()]
		// public static void MyClassCleanup() { }
		//
		// Use TestInitialize to run code before running each test 
		// [TestInitialize()]
		// public void MyTestInitialize() { }
		//
		// Use TestCleanup to run code after each test has run
		// [TestCleanup()]
		// public void MyTestCleanup() { }
		//
		#endregion

		[TestMethod]
		public void Vary_test()
		{
			//
			// TODO: Add test logic here
			//

			var v = new nilnul.obj._var.Var_dynamicTyped(typeof(int));

			var v1 = new nilnul.obj._var.Var_dynamicTyped(typeof(string));

			var v2=new nilnul.obj._var.Var_dynamicTyped(typeof(object));

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

			var varied2= nilnul.obj.func.mono.op.Vary.Eval(varied, v2);


			Debug.WriteLine(varied2);

		}
	}
}
