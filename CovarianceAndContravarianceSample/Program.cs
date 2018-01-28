using System;
using System.Collections;
using System.Collections.Generic;

namespace CovarianceAndContravarianceSample
{
	public class Animal : IAbleToFeed<Animal>
	{
		public void Eat() => Console.WriteLine("Eat");

		public void Feed(Animal t)
		{
			Console.WriteLine("Feeding");
			t.Eat();
		}
	}

	public class Bird : Animal
	{
		public void Fly() => Console.WriteLine("Fly");
	}

	delegate Animal ReturnAnimalDelegate();
	delegate Bird ReturnBirdDelegate();


	delegate void TakeAnimalDelegate(Animal a);
	delegate void TakeBirdDelegate(Bird b);

	interface IAbleToFeed<in T>
	{
		void Feed(T t);
	}

	interface IZoo<in T>
	{
		void Add(T t);
	}

	public class Zoo<T> : IZoo<T>
	{
		public void Add(T t)
		{
			
		}
	}

	interface IProcessItem<out T>
	{
		T Process();
	}

	public class AnimalProcessor<T> : IProcessItem<T>
	{
		public T Process()
		{
			throw new NotImplementedException();
		}
	}

	class Human : Animal
	{

	}
	class Program
	{
		public static Bird GetBird() => new Bird();
		public static Animal GetAnimal() => new Animal();


		public static void Eat(Animal a) => a.Eat();

		public static void Fly(Bird b) => b.Fly();

		static void Main(string[] args)
		{
			//IComparer - contravarinace
			IZoo<Animal> animalZoo = new Zoo<Animal>(); //GetANimalZoo
			IZoo<Bird> birdZoo = new Zoo<Bird>(); //GetBirdZoo
			birdZoo = animalZoo;
			
			IAbleToFeed<Human> a = new Bird();
			a.Feed(new Human());
			
			//IEnumerator - covariant
			IProcessItem<Animal> animalProcessor = new AnimalProcessor<Animal>();
			IProcessItem<Bird> birdProcessor = new AnimalProcessor<Bird>();

			IEnumerable<Animal> alist = new List<Bird>();
			animalProcessor = birdProcessor;

			//Animal[] animalArray = new Bird[10];
			//animalArray[0] = new Human();


			//IEnumerable<Animal> cc = new List<Bird>();


			//IGetBest<Animal> bb = new GetBestAnimal();

			//var pp = bb.MyMethod();


			//Animal[] aa = new Bird[5];
			//aa[1] = new Giraffe();



			//ProcessBirdDelegate dd = EatAnimal;
			//dd(new Bird());

			//IEnumerable<int>
			//Func<int,int>



			//dd(new Fly)

			//ProcessBirdDelegate d1 = EatAnimal;
			//ProcessBirdDelegate d2 = FlyBird;



			//d1(new Bird());
		}
	}

	//interface IGetBest<out T>
	//{

	//	T GetBestItem();
	//}

	//class GetBestAnimal : IGetBest<Animal>
	//{
	//	public Animal GetBestItem()
	//	{
	//		throw new NotImplementedException();
	//	}
	//}
}
