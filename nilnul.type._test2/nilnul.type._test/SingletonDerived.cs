using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using nilnul.type;

namespace nilnul.type._test
{
	public class SingletonDerived
		:Singleton<SingletonDerived>
	{

		static private readonly SingletonDerived _Instance = new SingletonDerived();
		static public SingletonDerived Instance
		{
			get
			{
				return _Instance;
			}
		}
		private SingletonDerived()
		{
		}
		private int _instanceMember=42;

		public int instanceMember {
			get {
				return _instanceMember;
			}
			set {
				_instanceMember = value;
			}
		}
				
		static SingletonDerived() {
			Singleton<SingletonDerived>._Instance = Instance;
		}
	}
}
