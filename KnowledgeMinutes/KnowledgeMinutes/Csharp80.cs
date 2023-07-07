using System.Data.SqlClient;
using KnowledgeMinutes.Models;
// ReSharper disable All

namespace KnowledgeMinutes
{
    /// <summary>
    /// Sep 2019, depends now on .NET Core version
    /// </summary>
    public class Csharp80
    {
        //readonly modifier for properties in structs, more granular than marking the whole struct as readonly
        //IDisposable support for ref structs
        //nullable reference 

        public static void PatternMatchingSwitch()
        {
            #region old

            static RGBColor FromRainbowClassic(Rainbow colorBand)
            {
                switch (colorBand)
                {
                    case Rainbow.Red:
                        return new RGBColor(0xFF, 0x00, 0x00);
                    case Rainbow.Orange:
                        return new RGBColor(0xFF, 0x7F, 0x00);
                    case Rainbow.Yellow:
                        return new RGBColor(0xFF, 0xFF, 0x00);
                    case Rainbow.Green:
                        return new RGBColor(0x00, 0xFF, 0x00);
                    case Rainbow.Blue:
                        return new RGBColor(0x00, 0x00, 0xFF);
                    case Rainbow.Indigo:
                        return new RGBColor(0x4B, 0x00, 0x82);
                    case Rainbow.Violet:
                        return new RGBColor(0x94, 0x00, 0xD3);
                    default:
                        throw new ArgumentException("invalid enum value", nameof(colorBand));
                }
            }

            #endregion

            #region new

            static RGBColor FromRainbow(Rainbow colorBand)
            {
                return colorBand switch
                {
                    Rainbow.Red => new RGBColor(0xFF, 0x00, 0x00),
                    Rainbow.Orange => new RGBColor(0xFF, 0x7F, 0x00),
                    Rainbow.Yellow => new RGBColor(0xFF, 0xFF, 0x00),
                    Rainbow.Green => new RGBColor(0x00, 0xFF, 0x00),
                    Rainbow.Blue => new RGBColor(0x00, 0x00, 0xFF),
                    Rainbow.Indigo => new RGBColor(0x4B, 0x00, 0x82),
                    Rainbow.Violet => new RGBColor(0x94, 0x00, 0xD3),
                    _ => throw new ArgumentException("invalid enum value", nameof(colorBand))
                };
            }

            //property matching!
            static string InfoForAnimalBasedOnType(Animal animal)
            {
                return animal switch
                {
                    {Type: AnimalType.Mammal} => "Im a mamal",
                    {Type: AnimalType.Reptile} => "Im a reptile",
                    var (weight) when weight > 10000000000 => "do i exist ??",
                    _ => "im not yet discovered"
                };
            }

            //switch on multiple input with the power of tuples
            static string RockPaperScissors(string first, string second)
            {
                return (first, second) switch
                {
                    ("rock", "paper") => "rock is covered by paper. Paper wins.",
                    ("rock", "scissors") => "rock breaks scissors. Rock wins.",
                    ("paper", "rock") => "paper covers rock. Paper wins.",
                    ("paper", "scissors") => "paper is cut by scissors. Scissors wins.",
                    ("scissors", "rock") => "scissors is broken by rock. Rock wins.",
                    ("scissors", "paper") => "scissors cuts paper. Scissors wins.",
                    (_, _) => "tie"
                };
            }

            #endregion
        }

        public static void UsingWithInferedScope()
        {
            #region old

            using (var sqlCon = new SqlConnection())
            {
                sqlCon.Open();
                using (var transaction = sqlCon.BeginTransaction())
                {
                    using (var command = sqlCon.CreateCommand())
                    {
                        //stuff   
                    }
                }
            }


            #endregion

            #region new

            using var con = new SqlConnection();
            con.Open();
            using var sqlTransaction = con.BeginTransaction();
            using var sqlCommand = con.CreateCommand();
            //stuff   

            #endregion
        } //disposed here

        public static async Task AsyncStreams()
        {
            await foreach (var number in GenerateSequence())
            {
                Console.WriteLine(number);
            }

            static async IAsyncEnumerable<int> GenerateSequence()
            {
                for (int i = 0; i < 20; i++)
                {
                    await Task.Delay(100);
                    yield return i;
                }
            }
        }

        public static void IndicesAndRanges()
        {
            var array = new[]
            {
                1, 2, 3, 4, 5, 6, 7, 8
            };
            Console.WriteLine($"Source: {string.Join(",", array)}");

            Console.WriteLine("Last element");
            Console.WriteLine(array[^1]);

            Console.WriteLine("Element before last");
            var index = ^2;
            Console.WriteLine(array[index]);

            
            Console.WriteLine("Range from first to third");
            var r = ..3;
            var subArray = array[r];
            foreach (var i in subArray)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine("Range from 2 before last to end");
            var subArray2 = array[^2..];
            foreach (var i in subArray2)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine("Range from third to 1 before last");
            var subArray3 = array[2..^1];
            foreach (var i in subArray3)
            {
                Console.WriteLine(i);
            }
        }

        public static void NullCoalicingAssignment()
        {
            List<int> numbers = null;
            int? i = null;

            numbers ??= new List<int>();
            numbers.Add(i ??= 17);
            numbers.Add(i ??= 20);

            Console.WriteLine(string.Join(" ", numbers));  // output: 17 17
            Console.WriteLine(i);  // output: 17
        }

        //Default method implementation in interfaces
        //can also be used to extend/introduce function to a already shipped interface
        public interface IAdd
        {
            public int Add1 { get; set; }
            public int Add2 { get; set; }

            public int Add()
            {
                return this.Add1 + this.Add2;
            }
        }

        public class AddImpl : IAdd
        {
            public int Add1 { get; set; }
            public int Add2 { get; set; }
        }

        public static void DefaultInterfaces()
        {
            IAdd add = new AddImpl
            {
                Add1 = 10,
                Add2 = 10
            };
            Console.WriteLine(add.Add());
        }
    }
}