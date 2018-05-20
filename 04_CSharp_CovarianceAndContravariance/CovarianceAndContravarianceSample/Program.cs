using System;
using System.Collections;
using System.Collections.Generic;

namespace CovarianceAndContravarianceSample
{
	public class Animal 
	{
		public void Eat() => Console.WriteLine("Eat");
	}

	public class Bird : Animal
	{
		public void Fly() => Console.WriteLine("Fly");
	}

    public class Human: Animal{}

	delegate Animal ReturnAnimalDelegate();
	delegate Bird ReturnBirdDelegate();

    delegate void TakeAnimalDelegate(Animal a);
    delegate void TakeBirdDelegate(Bird b);

    interface IProcess<out T>
    {
        T Process();
    }

    public class AnimalProcessor<T> : IProcess<T>
    {
        public T Process()
        {
            throw new NotImplementedException();
        }
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

    class Program
	{
		public static Bird GetBird() => new Bird();
		public static Animal GetAnimal() => new Animal();

        public static void Eat(Animal a) => a.Eat();
        public static void Fly(Bird b) => b.Fly();

		static void Main(string[] args)
		{
            //delegates covariance
            Animal a = new Bird();
            ReturnAnimalDelegate d = GetBird;

            //Delegates contravariance
            TakeBirdDelegate d2 = Eat;
            d2(new Bird());

            //arrays covariance
            Animal[] animals = new Bird[10];
            //This is broken:
            //animals[0] = new Human(); 

            //generics covariance
            IProcess<Animal> animalProcessor = new AnimalProcessor<Animal>();
            IProcess<Bird> birdProcessor = new AnimalProcessor<Bird>();

            Animal animal = birdProcessor.Process();
            animalProcessor = birdProcessor;

            IEnumerable<Animal> animalList = new List<Bird>();

            //generic contravariance
            IZoo<Animal> animalZoo = new Zoo<Animal>();
            animalZoo.Add(new Animal());
            IZoo<Bird> birdZoo = new Zoo<Bird>();
           
            birdZoo = animalZoo;
            birdZoo.Add(new Bird());
		}
	}
}
