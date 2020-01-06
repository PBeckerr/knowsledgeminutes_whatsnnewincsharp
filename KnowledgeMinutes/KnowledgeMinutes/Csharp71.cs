using System;
using KnowledgeMinutes.Models;

// ReSharper disable All

namespace KnowledgeMinutes
{
    public static class Csharp71
    {
        public static void InferedTupleNames()
        {
            int count = 5;
            string label = "hello world";
            var tuple = (count, label);

            Console.WriteLine(tuple.count);
            Console.WriteLine(tuple.label);
        }

        public static void PatternmatchingForGeneric<T>(T toCheck)
        {
            switch (toCheck)
            {
                case int _:
                    Console.WriteLine("Is a int");
                    break;
                case decimal _:
                    Console.WriteLine("Is a decimal");
                    break;
                default:
                    Console.WriteLine("i dont know what what iam");
                    break;
            }
        }
        //Async main method....

        public static void ShortDefaultLiteral()
        {
            #region old

            AnimalType type = default(AnimalType);
            Console.WriteLine(type);

            #endregion

            #region new

            AnimalType type2 = default;
            Console.WriteLine(type2);

            #endregion
        }
    }
}