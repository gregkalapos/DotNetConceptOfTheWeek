using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RefStructSamples
{
	ref struct MyRefStruct {}

	//Scenarios where the C# compiler prevents us from using a ref struct:

	//1: Field of a class/ normal struct - NOT allowed
	//class MyClass
	//{
	//	MyRefStruct myRefStruct;
	//}


	//2: Async method/lambda parameter - NOT allowed
	//class MyClass
	//{
	//	public async Task MyMethod(MyRefStruct myRefStruct)
	//	{
	//		//...method body 
	//	}
	//}

	//3: box - NOT allowed
	//class MyClass
	//{
	//	void MyMethod()
	//	{
	//		MyRefStruct myRefStruct = new MyRefStruct();
	//		Object boxedRefStruct = myRefStruct;
	//	}
	//}

	//4: Generic type argument and Array type - NOT allowed
	//class MyClass
	//{
	//	void MyMethod()
	//	{
	//		List<MyRefStruct> myRefStructsList = new List<MyRefStruct>();
	//		MyRefStruct[] myRefStructsArray = new MyRefStruct[15];
	//	}
	//}


	class Program
	{

		static void Main(string[] args)
		{
			
		}
	}
}
