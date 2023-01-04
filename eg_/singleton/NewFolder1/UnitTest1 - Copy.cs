using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace nilnul._obj_._TEST_.eg_.singleton1
{
	[TestClass]
	public class UnitTest1
	{
		[TestMethod]
		public void TestMethod1()
		{
			//var t = T.Singleton;
			var s = Set.Singleton;


		}
	}
	public class T
	{

		static public T Singleton
		{
			get
			{
				return nilnul.obj_.Singleton<T>.Instance;
			}
		}


	}
	public class Set : fs._address.doc_._exted.ext.Set
	{
		public Set() : base(".com", "exe", "bat")
		{

		}


		static public Set Singleton
		{
			get
			{
				return nilnul.obj_.Singleton<Set>.Instance;
			}
		}

	}

	namespace fs._address.doc_._exted.ext
	{
		public class Set : nilnul.obj.Set<Ext, ext.Eq>
		{
			public Set(IEnumerable<string> ext) : base(
				ext.Select(x => new Ext(x)) //.ToArray()
			)
			{

			}

			public Set(IEnumerable<Ext> exts) : base(exts)
			{

			}

			public Set(params string[] x) : this((IEnumerable<string>)x)
			{

			}
		}

		public class Ext
			: nilnul.obj.Box1<string>

		{
			//public En txt => this;

			public Ext(
				string txt = ""
			) : base(
				"." + txt

			)
			{

			}




		}

		public class Eq :

	IEqualityComparer<Ext>

		{
			public Eq()
			{
			}

			public bool Equals(Ext x, Ext y)
			{
				return true;
				throw new NotImplementedException();
			}

			public int GetHashCode(Ext obj)
			{
				return 0;
				throw new NotImplementedException();
			}
		}


	}


}
