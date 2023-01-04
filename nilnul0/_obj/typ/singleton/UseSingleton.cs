using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace nilnul.type._test.singleton
{
	[TestClass]
	public class UseSingleton
	{
		[Microsoft.VisualStudio.TestTools.UnitTesting.TestMethod]
      public void useSingleton()
      {
		  var x = DefaultValToSingleton.Instance;

		  Assert.AreEqual(x.Val,3);
          
      }
	}
}
