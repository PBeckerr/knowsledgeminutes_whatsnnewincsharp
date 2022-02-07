using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace KnowledgeMinutes;

//requires NET6
//First Feature is file scoped namespace, YE!
//Honorable mentions:
//  Record structs
//  Compilated string interpolation, aweseome for logging and already supported -> https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/tokens/interpolated#compilation-of-interpolated-strings
//  Global using directives
//  Preview:
//          Generic Attributes https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-10#generic-attributes
//          Static abstract members in interfaces https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-10#static-abstract-members-in-interfaces
public static class CsharpN100
{
    #region Extended property patterns

    public class Department
    {
        public string Name { get; set; }
        public Person Manager { get; set; }
    }
    
    public class Person
    {
        public string Name { get; set; }
    }

    public static void ExtendedPropertyPatterns(List<Department> departments)
    {
        //print all departments with a Boss named Max
        foreach (var department in departments)
        {
            //old
            if (department is {Manager: {Name: "Max"}})
            {
                Console.WriteLine(department);
            }
            
            //new
            if (department is {Manager.Name: "Max"})
            {
                Console.WriteLine(department);
            }
        }
    }

    #endregion

    #region Lampda expression improvements

    public static void LambdaImprovments()
    {
        // Lambda expressions may have a natural type, where the compiler can infer a delegate type from the lambda expression or method group.
        // Lambda expressions may declare a return type when the compiler can't infer it.
        // Attributes can be applied to lambda expressions.
        // Heavily used in ASP.NET Core Minimal APIs

        var myLamda = ([MinLength(1)]string name) => name;
    }

    #endregion

    #region const string interpolation

    public const string ProgramName = nameof(ProgramName);
    //if all the placeholders are themselves constant strings.
    public const string ProgramNameGreeting = $"Hello from {ProgramName}";

    #endregion

    #region CallerArgumentExpression attribute diagnostics

    public static void Validate(bool condition, [CallerArgumentExpression("condition")] string? message=null)
    {
        if (!condition)
        {
            throw new InvalidOperationException($"Argument failed validation: <{message}>");
        }
    }

    public static void CallerArgumentExpression()
    {
        var name = "Max";
        Validate(name.Length > 10 && name.StartsWith("X"));
    }

    #endregion
}