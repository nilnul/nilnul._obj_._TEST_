using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using f = nilnul.obj.var._withType.form._dynamicTyped;
using v = nilnul.obj.var._withType;


using FormI = nilnul.obj.var._withType.form._dynamicTyped.FormI;

namespace nilnul.obj._test.var._withType.form._dynamicTyped
{
	[TestClass]
	public class Form_dynamic__Test
	{
		[TestMethod]
		public void Form_dynamic__test___method()
		{

			FormI form1;
			form1 = new f.no.op.Call<int>(1);

			var var = new f.VarAsForm( v.NamingContext1.CreateVar<int>("x") );

			var soloForm = new f.solo.op.Call<int, string>(
				(int x)=>x.ToString()
				,

				var
			);



		}
	}
}
