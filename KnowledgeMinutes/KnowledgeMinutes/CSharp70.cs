using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KnowledgeMinutes.Models;

// ReSharper disable All

namespace KnowledgeMinutes
{
    /// <summary>
    /// Released with VS 2017, March 2017
    /// </summary>
    public static class CSharp70
    {
        public static void InlineOutVariables(string number)
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
                Console.WriteLine(answer);
            else
                Console.WriteLine("Could not parse input");

            #endregion
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
        
        public static void RefReturnAndLocalFunction()
        {
            int[,] matrix = new int[7, 7];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = int.Parse($"{i}{j}");
                }
            }

            Console.WriteLine("Without reference to value");
            var itemWithoutRef = findWithoutRef(matrix, (val) => val == 42);
            Console.WriteLine(itemWithoutRef);
            itemWithoutRef = 24;
            Console.WriteLine(matrix[4, 2]);

            Console.WriteLine("With reference to value");
            ref var item = ref findWithRef(matrix, (val) => val == 42);
            Console.WriteLine(item);
            item = 24;
            Console.WriteLine(matrix[4, 2]);

            #region local functions

            ref int findWithRef(int[,] matrix, Func<int, bool> predicate)
            {
                for (int i = 0; i < matrix.GetLength(0); i++)
                for (int j = 0; j < matrix.GetLength(1); j++)
                    if (predicate(matrix[i, j]))
                        return ref matrix[i, j];
                throw new InvalidOperationException("Not found");
            }

            static int findWithoutRef(int[,] matrix, Func<int, bool> predicate)
            {
                for (int i = 0; i < matrix.GetLength(0); i++)
                for (int j = 0; j < matrix.GetLength(1); j++)
                    if (predicate(matrix[i, j]))
                        return matrix[i, j];
                throw new InvalidOperationException("Not found");
            }

            #endregion
        }

        public static void StringLiteralForNumbers()
        {
            var oneMillion = 1_000_000;
            var binary16 = 0b0001_0000;
            var goldenRatio = 1.618_033_988_749_894_848_204_586_834_365_638_117_720_309_179M;
            Console.WriteLine(oneMillion);
            Console.WriteLine(binary16);
            Console.WriteLine(goldenRatio);
        }

        /// <summary>
        /// ValueTask should be used for lightwight stuff that most likely already has completed before it gets awaited
        /// also good for caching of values because well Value = allocated on stack instead of heap
        /// </summary>
        /// <returns></returns>
        public static async ValueTask<int> AsyncSupportOtherTypesOfTaskAsync()
        {
            await Task.Delay(100);
            return 42;
        }

        public class MoreExpressionBodies
        {
            private string label;

            // Expression-bodied constructor
            public MoreExpressionBodies(string label) => this.Label = label;

            // Expression-bodied finalizer
            ~MoreExpressionBodies() => Console.Error.WriteLine("Finalized!");

            // Expression-bodied get / set accessors.
            public string Label
            {
                get => label;
                set => this.label = value ?? "Default label";
            }
            
            // new throw expression
            public string ThrowShowCase
            {
                get => label;
                set => this.label = value ?? throw new ArgumentException(nameof(ThrowShowCase));
            }
        }
    }
}