using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

namespace nilnul.obj._test.str.op_.sort_.quick
{
	[TestClass]
	public class UnitTest1
	{
		[TestMethod]
		public void QuickSort(int len)
		{
			 

			int[] numbers = new int[len];
			var rnd = new Random();

			for (int i = 0; i < len; i++)
			{
				numbers[i] = rnd.Next( len *3);

			}

			Debug.WriteLine(
				nilnul.obj.str.to_._txt.Extensions.ToTxt(numbers)
			);



			var sorted=nilnul.obj.str.op_.sortUnstable_._Quick.Sort(numbers);



			Debug.WriteLine(
				nilnul.obj.str.to_._txt.Extensions.ToTxt(sorted)
			);





		}


		[TestMethod]
		public void QuickSort1()
		{
			QuickSort(0);
			QuickSort(1);
			QuickSort(2);
			QuickSort(3);
			QuickSort(4);
			QuickSort(5);
			 
		}
	}
}
