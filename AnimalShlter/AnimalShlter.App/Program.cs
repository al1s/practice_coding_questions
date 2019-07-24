using System;
using System.Collections.Generic;

namespace AnimalShlter.App
{
  class Program
  {
    static void Main(string[] args)
    {
      var s = new Shelter<Animal>();
      s.Enqueue(new Dog("Dog1"));
      s.Enqueue(new Dog("Doggy"));
      s.Enqueue(new Dog("Dog2"));
      s.Enqueue(new Cat("Cat2"));
      s.Enqueue(new Dog("Dog3"));
      System.Console.WriteLine($"{s.DequeueCat().Name}");
    }
  }
  public class Shelter<Animal>
  {
    private LinkedList<Animal> _shelter = new LinkedList<Animal>();
    public void Enqueue(Animal animal)
    {
      _shelter.AddLast(animal);
    }
    public Animal DequeueAny()
    {
      var animal = _shelter.First.Value;
      _shelter.RemoveFirst();
      return animal;
    }
    public Cat DequeueCat()
    {
      var current = _shelter.First;
      while (!(current.Value is Cat) && current.Next != null)
      {
        current = current.Next;
      }
      if (!(current.Value is Cat)) throw new Exception("No cats available");
      _shelter.Remove(current);
      return current.Value as Cat;
    }
  }
  public abstract class Animal
  {
    public string Kind { get; set; }
    public string Name { get; set; }
    public Animal() { }
    public Animal(string value)
    {
      Kind = value;
    }
  }

  public class Dog : Animal
  {
    public Dog() : base("Dog") { }
    public Dog(string name) : base("Dog")
    {
      Name = name;
    }
  }
  public class Cat : Animal
  {
    public Cat() : base("Cat") { }
    public Cat(string name) : base("Cat")
    {
      Name = name;
    }
  }
}
