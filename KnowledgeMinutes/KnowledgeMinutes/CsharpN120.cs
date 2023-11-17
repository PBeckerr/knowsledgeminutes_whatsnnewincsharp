using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
//alias any type
using PBE = System.Collections.Generic.Dictionary<System.Guid, System.Collections.Generic.List<string>>;
using Develappers = (string Name, int Alter);

namespace KnowledgeMinutes;

// .NET8, NOV 2023
[SuppressMessage("ReSharper", "ConvertToLocalFunction")]
public static class CsharpN120
{
    #region Primary constructor

    // Primary constructor parameters may not be stored if they aren't needed.
    // Primary constructor parameters aren't members of the class. For example, a primary constructor parameter named param can't be accessed as this.param.
    // Primary constructor parameters can be assigned to.
    // Primary constructor parameters don't become properties, except in record types.

    public class MyClass(ImmutableList<string> names) : MyClassBase(names)
    {
        public MyClass(int departmentNumber) : this([])
        {
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }

    public abstract class MyClassBase(ImmutableList<string> names)
    {
        public ImmutableList<string> Names => names;
    }

    #endregion

    #region Collection expressions

    public static void CollectionExpression()
    {
        //old
        var a = new List<string> {"one", "two", "three"};

        //new 
        List<string> b = ["1", "2", "3"];

        // spread operator, ..
        HashSet<string> c = [..a, ..b[^1..]];
        
        // better way for empty List, Array, IEnumerable
        List<string> empty = []; //before Array.Empty<string>().ToList() for a empty list- urgh!
    }

    #endregion

    #region Optional parameters in lambda expressions
    
    public static void Lambda()
    {
        var lambdaExpr = (string name = "Paul") => Console.WriteLine(name);
        var foo = new PBE();
        lambdaExpr();
        lambdaExpr("Develappers");
    }

    #endregion
}