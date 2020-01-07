using System;

namespace KnowledgeMinutes.Models
{
    public abstract class Animal
    {
        public override string ToString()
        {
            return this.GetType().Name;
        }

        public abstract float Weight { get; set; }
        public abstract AnimalType Type { get; set; }

        public void Deconstruct(out float weight)
        {
            weight = this.Weight;
        }
    }

    public class Dog : Animal
    {
        public virtual void SayHello()
        {
            Console.WriteLine("wuff");
        }

        public override float Weight { get; set; } = 20;
        public override AnimalType Type { get; set; } = AnimalType.Mammal;
    }

    public class Cat : Animal
    {
        public virtual void SayHello()
        {
            Console.WriteLine("meow");
        }

        public override float Weight { get; set; } = 5;
        public override AnimalType Type { get; set; } = AnimalType.Mammal;
    }

    public class Bat : Animal
    {
        public virtual void SayHello()
        {
            Console.WriteLine("piep in high frequency");
        }

        public override float Weight { get; set; } = 0.5f;
        public override AnimalType Type { get; set; } = AnimalType.Mammal;
    }

    public enum AnimalType
    {
        Reptile = 0,
        Mammal = 1
    }
}