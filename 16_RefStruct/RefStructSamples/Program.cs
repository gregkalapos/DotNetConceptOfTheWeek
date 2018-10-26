using System;
using System.Collections.Generic;
using System.Threading.Tasks;


/// <summary>
/// Sample code for episode 16 of .NET Concept of the Week. 
/// https://www.youtube.com/playlist?list=PLFSD3X7beNRCh29bqslAbaBKoy64qQVb8 
/// </summary>
namespace RefStructSamples
{
	ref struct MyRefStruct {}

	//Scenarios where the C# compiler prevents us from using a ref struct:
	//Those are commented out, because that code is invalid, and does not compile

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
		//What is allowed with a ref struct:

		//1: method parameter
		public void MethodWithRefStructParam(MyRefStruct myRefStruct)
		{
			//...
		}

		//2: method(s) returning a ref struct
		public MyRefStruct MethodWithRetRefStruct()
		{
			var retVal = new MyRefStruct();
			//...
			return retVal;
		}

		//3: local variable 
		public void MethodWithRefStructLocalVar()
		{
			var variable = new MyRefStruct();
			//...
		}

		static void Main(string[] args)
		{
			
		}
	}

	ref struct SampleRefStruct
	{
		Span<int> intSpan;
		Span<double> doubleSpan;
	}
}
