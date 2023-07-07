namespace KnowledgeMinutes
{
    /// <summary>
    /// 2017
    /// </summary>
    public class Csharp72
    {
        //High Performance changes to avoid unsafe code while maintaining good performance
        //in modifier(like a ref readonly for parameters)
        //readonly structs
        //ref struct
        //ref support for conditional access


        public static void NamedArgumentsAndOptionalParameter()
        {
            Foo(name: "Bar", age: 30, getCurrentTime: () => DateTimeOffset.Now);

            void Foo(string name, int age, Dictionary<string, string> metadata = null, Func<DateTimeOffset> getCurrentTime = null)
            {
                Console.WriteLine(name);
                Console.WriteLine(age);
                if (metadata != null)
                {
                    foreach (var keyValuePair in metadata)
                    {
                        Console.WriteLine($"{keyValuePair.Key} {keyValuePair.Value}");
                    }
                }

                if (getCurrentTime != null)
                {
                    Console.WriteLine(getCurrentTime());
                }
            }
        }

        /// <summary>
        /// private protected indicates that a member may be accessed by containing class or derived classes that are declared in the same assembly.
        /// While protected internal allows access by derived classes or classes that are in the same assembly.
        /// </summary>
        private protected int SomeNumber => 30;
    }
}