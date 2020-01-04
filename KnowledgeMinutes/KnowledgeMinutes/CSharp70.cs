using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.InteropServices.ComTypes;
using KnowledgeMinutes.Models;

// ReSharper disable All

namespace KnowledgeMinutes
{
    public static class CSharp70
    {
        public static void InlineOutlineVariables(string number)
        {
            #region old

            int result;
            if (int.TryParse(number, out result))
                Console.WriteLine(result);
            else
                Console.WriteLine("Could not parse input");

            #endregion

            #region new

            if (int.TryParse(number, out var answer))
            {
                Console.WriteLine(answer);
            }
            else
            {
                Console.WriteLine("Could not parse input");
            }

            #endregion
        }

        public static void RuntimeSupportForTuples()
        {
            #region old

            var tuple = new Tuple<string, int>("Foo", 20);
            Console.WriteLine($"{tuple.Item1} {tuple.Item2}");

            #endregion

            #region new

            var newTuple = (Name: "Foo", Age: 20);
            //Names exists only on compile time so stuff like reflection only sees Item1, Item2 ...
            Console.WriteLine($"{newTuple.Name} {newTuple.Age}");

            //can also be initialized with names on left side
            (string Name, int Age) nameTuple = ("FooBar", 40);
            Console.WriteLine($"{nameTuple.Name} {nameTuple.Age}");
            
            //automatic deconstruction
            (string Name, int Age) = ("Bar", 30);
            Console.WriteLine($"{Name} {Age}");
            
            //https://docs.microsoft.com/en-us/dotnet/csharp/tuples  --- 20 minutes to read
            
            #endregion
        }

        public static void Discards(string number)
        {
            if (int.TryParse(number, out _))
            {
                Console.WriteLine($"{number} is a valid number");
            }
            else
            {
                Console.WriteLine($"{number} is not valid number");
            }
            
            //we can also discard tuple stuff when deconstructions
            var complexTuple = (City: "Dresden", State: "Sachsen", Population: 554649, Language: "german");
            //deconstruct but i dont need most of the stuff
            var (City, _, Population, _) = complexTuple;
            Console.WriteLine($"{City}: {Population}");
        }
        
        public static void PatternMatching()
        {
            var animals = new List<Animal>()
            {
                new Bat(),
                new Cat(),
                new Dog(),
                null
            };

            foreach (var animal in animals)
            {
                if (animal is Cat cat)
                {
                    Console.WriteLine(cat.ToString());
                    cat.SayHello();
                }
                if (animal is Dog dog)
                {
                    Console.WriteLine(dog.ToString());
                    dog.SayHello();
                }
                if (animal is Bat bat)
                {
                    Console.WriteLine(bat.ToString());
                    bat.SayHello();
                }
            }

            Console.WriteLine("==================");
            
            foreach (var animal in animals)
            {
                switch (animal)
                {
                    case Animal a when a.Weight < 5:
                        Console.WriteLine($"{a} is a small animal.");
                        break;
                    case Animal a when a.Weight >= 5 && a.Weight < 50:
                        Console.WriteLine($"{a} is a medium sized animal.");
                        break;
                    case null:
                        Console.WriteLine("null is weightless");
                        break;
                }
            }
        }
    }
}