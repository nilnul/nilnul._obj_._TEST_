using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace nilnul.type._test
{
	[TestClass]
	public class UnitTest1
	{
		[TestMethod]
		public void UseSingletonBase()
		{
			//var a=SingletonDerived.Instance;
			var c=Singleton<SingletonDerived>.Instance;
			var d = c.instanceMember;

		}
	}
}
