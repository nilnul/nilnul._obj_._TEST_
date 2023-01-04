using System;
using System.Text;
using System.IO;
// Add references to Soap and Binary formatters.
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Runtime.Serialization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

namespace nilnul._obj_._TEST_.serialize
{


	[Serializable]
	public class MyItemType : ISerializable
	{
		public MyItemType()
		{
			// Empty constructor required to compile.
		}

		// The value to serialize.
		private string myProperty_value;

		public string MyProperty
		{
			get { return myProperty_value; }
			set { myProperty_value = value; }
		}

		// Implement this method to serialize data. The method is called 
		// on serialization.
		public void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			// Use the AddValue method to specify serialized values.
			info.AddValue("props", myProperty_value, typeof(string));

		}

		// The special constructor is used to deserialize values.
		public MyItemType(SerializationInfo info, StreamingContext context)
		{
			// Reset the property value using the GetValue method.
			myProperty_value = (string)info.GetValue("props", typeof(string));
		}
	}

	// This is a console application. 
	public  class Test
	{
		[Microsoft.VisualStudio.TestTools.UnitTesting.TestMethod]
		public void MyTestMethod()
		{

		
			// This is the name of the file holding the data. You can use any file extension you like.
			//string fileName = "dataStuff.myData";
			var fileName = System.IO.Path.GetTempFileName();

			

			

			// Use a BinaryFormatter or SoapFormatter.
			IFormatter formatter = new BinaryFormatter();
			//IFormatter formatter = new SoapFormatter();

			SerializeItem(fileName, formatter); // Serialize an instance of the class.
			DeserializeItem(fileName, formatter); // Deserialize the instance.

			Debug.WriteLine("Done");


		}


		//[TestMethod]
		public void SerializeItem(string fileName, IFormatter formatter)
		{
			// Create an instance of the type and serialize it.
			MyItemType t = new MyItemType();
			t.MyProperty = "Hello World";

			FileStream s = new FileStream(fileName, FileMode.Create);
			formatter.Serialize(s, t);
			s.Close();
		}

		//[TestMethod]
		public void  DeserializeItem(string fileName, IFormatter formatter)
		{
			FileStream s = new FileStream(fileName, FileMode.Open);
			MyItemType t = (MyItemType)formatter.Deserialize(s);
			Debug.WriteLine(t.MyProperty);
		}
	}
}
