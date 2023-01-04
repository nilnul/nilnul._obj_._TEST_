using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace nilnul._obj_._TEST_.eg_.singleton
{
	[TestClass]
	public class UnitTest1
	{
		[TestMethod]
		public void TestMethod1()
		{
			var t = T.Singleton;


		}
	}
	public class D
	{
		public class E : IEqualityComparer<D>
		{
			public bool Equals(D x, D y)
			{
				return true;;
			}

			public int GetHashCode(D obj)
			{
				return 0;
				throw new NotImplementedException();
			}
		}
	}
	public class T : nilnul.obj.Set<D,D.E>
	{

		public T():base(
			new D(),new D()
		)
		{

		}
		static public T Singleton
		{
			get
			{
				return nilnul.obj_.Singleton<T>.Instance;
			}
		}


	}


}
