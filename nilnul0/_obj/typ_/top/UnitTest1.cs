using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace nilnul._obj_._TEST_.nilnul0._obj.typ_.top
{
	[TestClass]
	public class UnitTest1
	{
		[TestMethod]
		public void TestMethod1()
		{
			///for MSIL, when compiled with the option /noAutoInherit, you class can inherit from none. Or else it has to inherit from object, directly or indirectly.
			///But when compiled into CIL (common intermediate language), no inheriting from object is an error.
			///
			///Every Class (with the exception of System.Object and the special class <Module>) shall extend one, and only one, other Class &ndash; so Extends for a Class shall be non-null [ERROR]
			///
			/// at least on .NET 4.5.2 on Windows it compile but doesn't execute (TypeLoadException). PEVerify returns: [MD]: Error: TypeDef that is not an Interface and not the Object class extends Nil token.
			///
	

			

		}
	}
}
