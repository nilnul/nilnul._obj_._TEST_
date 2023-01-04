using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;

namespace nilnul._obj_._TEST_._this.typ.init
{


	public class P
	{
		static void Main(string[] args)
		{
			var test = Single.S;
		}
		public class Single
		{
			static readonly Single s = new Single();

			public static Single S
			{
				get { return s; }
			}
			private Single()
			{
				Console.WriteLine("Default");
				Debug.WriteLine(s);

			}
			static Single()
			{
				// the field init shall be moved here:
				//s = new Single();
				Console.WriteLine("staic");
			}
		}
	}

	[TestClass]
	public class UnitTest1
	{
		[TestMethod]
		public void TestMethod1()
		{
			Debug.WriteLine(
				P.Single.S
			);

		}
	}
}

/*The first thing that happens here when loading the class is

static Single s = new Single();
C# executes static initializers like this in the order they are seen. I am not sure if this ordering point also applies to the static constructor but from your test it seems that the static initializer does occur before the static constructor.

In any case, in order to assign to static Single s, one must first construct new Single(), which means invoking the non-static constructor. I am not sure what you would get if you read from Single.s in the non-static constructor but I would expect either null or an exception.

Share
Edit
Follow
answered Oct 27 '18 at 3:40

sjb-sjb
96144 silver badges1313 bronze badges
1
Re the last part: it's a NullReferenceException. – Llama Oct 27 '18 at 4:04

 
11

See ECMA 334 §17.4.5.1:

17.4.5.1 Static field initialization

The static field variable initializers of a class declaration correspond to a sequence of assignments that are executed in the textual order in which they appear in the class declaration. If a static constructor (§17.11) exists in the class, execution of the static field initializers occurs immediately prior to executing that static constructor. Otherwise, the static field initializers are executed at an implementation-dependent time prior to the first use of a static field of that class

It is caused by line public static MyClass aVar = new MyClass();.

In fact the aVar = new MyClass(); is prepend to the static contrstructor. So your static constructor:

static MyClass() {
    Console.WriteLine("Static");
}
is changed to:

static MyClass() {
    aVar = new MyClass(); // this will run instance contstructor and prints "Non-Static"
    Console.WriteLine("Static");
}*/