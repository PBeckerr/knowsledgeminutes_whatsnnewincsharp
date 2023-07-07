namespace KnowledgeMinutes;

//requires NET7, Released November, 2022
public static class CsharpN110
{
    #region GenericAttributes

    #region old

    public class ByTypeAttribute : Attribute
    {
        public ByTypeAttribute(Type t) => ParamType = t;

        public Type ParamType { get; }
    }

    #endregion

    
    #region new

    //has to be known on compile time, so no dynamic or tuples or nullable reference types
    public class GenericAttribute<T> : Attribute
    {
        public T ParamType { get; }
    }

    #endregion

    public class Dto
    {
        [ByType(typeof(string))]
        public string FirstName { get; set; }

        [GenericAttribute<string>]
        public string LastName { get; set; }
    }
    #endregion

    // Generic math support 
    //      static virtual members in interfaces
    //      checked user defined operators
    //      relaxed shift operators
    //      unsigned right-shift operator

    //Pattern match Span<char> or ReadOnlySpan<char> on a constant string
    public static void PatternMatchingWithSpanChar()
    {
        var spanOfChars = "Develappers".AsSpan();
        if(spanOfChars is "Develappers") Console.WriteLine("Ist Develappers.");
    }

    // newline support in  interpolated expressions
    public static void InterpolatedNewLine(int safetyScore)
    {
        string message = $"The usage policy for {safetyScore} is {
            safetyScore switch
            {
                > 90 => "Unlimited usage",
                > 80 => "General usage, with daily safety check",
                > 70 => "Issues must be addressed within 1 week",
                > 50 => "Issues must be addressed within 1 day",
                _    => "Issues must be addressed before continued use",
            }
        }";
        Console.WriteLine(message);
    }

    // pattern matching now supports list patterns, read for more x10 info https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/patterns#list-patterns
    public static void ListPatterns()
    {
        var list = new List<int> {99, 1, 2, 3, 4, 5};
        if(list is [2,3,..]) Console.WriteLine("List contains sequence");
        else Console.WriteLine("List does not contain sequence");

        if (list is [var first, ..])
        {
            Console.WriteLine($"The first element of list is {first}.");
        }

        if (list is [>=0 , ..])
        {
            Console.WriteLine($"First element is equals or greater than 0.");
        }

        var numbers = list.ToArray();
        if (numbers is  [.. { Length: > 2 }])
        {
            Console.WriteLine($"Array/List has over 2 items.");
        }
    }

    //Raw string literals
    public static void RawStringLiterals()
    {
        var foo = "lala";
        // Multiple $ characters denote how many consecutive braces start and end the interpolation
        var jsonString = $$"""
                            { {{foo}}
                              "Date": "2019-08-01T00:00:00-07:00",
                              "TemperatureCelsius": 25,
                              "Summary": "Hot",
                              "DatesAvailable": [
                                "2019-08-01T00:00:00-07:00",
                                "2019-08-02T00:00:00-07:00"
                              ],
                              "TemperatureRanges": {
                                "Cold": {
                                  "High": 20,
                                  "Low": -10
                                },
                                "Hot": {
                                  "High": 60,
                                  "Low": 20
                                }
                              },
                              "SummaryWords": [
                                "Cool",
                                "Windy",
                                "Humid"
                              ]
                            }
                            """;
        Console.WriteLine(jsonString);
    }

    //required keyword in props

    public class WithRequiredProps
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
    }
}

//file scope
file class OnlyVisibleInFile
{

}