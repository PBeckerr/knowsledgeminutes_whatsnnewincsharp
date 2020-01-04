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
    }

    public class Dog : Animal
    {
        public virtual void SayHello()
        {
            Console.WriteLine("wuff");
        }

        public override float Weight { get; set; } = 20;
    }

    public class Cat : Animal
    {
        public virtual void SayHello()
        {
            Console.WriteLine("meow");
        }

        public override float Weight { get; set; } = 5;
    }

    public class Bat : Animal
    {
        public virtual void SayHello()
        {
            Console.WriteLine("piep in high frequency");
        }

        public override float Weight { get; set; } = 0.5f;
    }
}