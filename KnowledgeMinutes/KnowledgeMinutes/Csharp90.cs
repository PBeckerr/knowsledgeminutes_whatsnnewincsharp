namespace KnowledgeMinutes
{
    //NET5 and later. Released November, 2020
    public static class Csharp90
    {
        #region records

        public class Customer
        {
            public Guid Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Telephone { get; set; }

            // public override bool Equals(object? obj)
            // {
            //     return this.GetHashCode() == obj?.GetHashCode();
            // }
            //
            // public static bool operator ==(Customer customer1, Customer customer2)
            // {
            //     return customer1?.GetHashCode() == customer2?.GetHashCode();
            // }
            //
            // public static bool operator !=(Customer customer1, Customer customer2)
            // {
            //     return !(customer1 == customer2);
            // }
            //
            // public override int GetHashCode()
            // {
            //     return HashCode.Combine(this.Id, this.FirstName, this.LastName, this.Telephone);
            // }
            //
            // public override string ToString()
            // {
            //     return $"{nameof(this.Id)}: {this.Id}, {nameof(this.FirstName)}: {this.FirstName}, {nameof(this.LastName)}: {this.LastName}, {nameof(this.Telephone)}: {this.Telephone}";
            // }
        }

        // Concise syntax for creating a reference type with immutable properties
        //     Behavior useful for a data-centric reference type:
        //     Value equality
        //     Immutable
        //     Concise syntax for nondestructive mutation
        //     Built-in formatting for display
        //     Support for inheritance hierarchies
        public record CustomerRecord(Guid Id, string FirstName, string LastName, string Telephone);
        public record CustomerWithEmailRecord(Guid Id, string FirstName, string LastName, string Telephone, string Email) : CustomerRecord(Id, FirstName, LastName, Telephone);

        public static void Records()
        {
            var customerId = Guid.NewGuid();
            var customer = new Customer
            {
                Id = customerId,
                FirstName = "Max",
                LastName = "Mustermann",
                Telephone = "+4915145721"
            };
            var customer2 = new Customer
            {
                Id = customerId,
                FirstName = "Max",
                LastName = "Mustermann",
                Telephone = "+4915145721"
            };
            Console.WriteLine(customer.ToString());
            Console.WriteLine("Customers are == {0}", customer == customer2);
            Console.WriteLine("Customers are equal {0}", customer.Equals(customer2));
            Console.WriteLine("Customers are ReferenceEquals {0}", ReferenceEquals(customer, customer2));

            var customerRecord = new CustomerRecord(customerId, "Max", "Mustermann", "+4915145721");
            var customerRecord2 = new CustomerRecord(customerId, "Max", "Mustermann", "+4915145721");

            // Immutable
            // customerRecord.FirstName = "Maxim";

            Console.WriteLine(customerRecord.ToString());
            Console.WriteLine("Customerrecords are == {0}", customerRecord2 == customerRecord);
            Console.WriteLine("Customerrecords are equal {0}", customerRecord2.Equals(customerRecord));
            Console.WriteLine("Customerrecords are ReferenceEquals {0}", ReferenceEquals(customerRecord, customerRecord2));

            //with
            var customerRecord3 = customerRecord with
            {
                FirstName = "Maxim"
            };
            Console.WriteLine();
            Console.WriteLine(customerRecord3.ToString());
        }

        #endregion

        #region Pattern matching enhancements

        public static bool IsLetterOld(this char charToCheck) =>
            charToCheck >= 'a' && charToCheck <= 'z' || charToCheck >= 'A' && charToCheck <= 'Z';

        public static bool IsLetterNew(this char charToCheck) =>
            charToCheck is >= 'a' and <= 'z' or >= 'A' and <= 'Z';

        //Csharp90.PatternWithObject(new CustomerRecord(Guid.NewGuid(), "Max", "Mustermann", "+4915145721"));
        public static void PatternWithObject(object obj)
        {
            switch (obj)
            {
                case Customer c:
                    Console.WriteLine("Its a customer");
                    Console.WriteLine(c.ToString());
                    break;
                case CustomerRecord cRecord:
                    Console.WriteLine("Its a customerrecord");
                    Console.WriteLine(cRecord.ToString());
                    break;
            }
        }

        #endregion

        #region new expression

        public static Dictionary<Guid, List<Customer>> SectionCustomers = new();

        public static void ReinitSectionCustomers()
        {
            SectionCustomers = new()
            {
                {new Guid(), new List<Customer>()}
            };
        }

        #endregion

        #region Code Generator

        // Ask OKE if you want to know more about that
        // Samples where its used:
        //        Json: https://devblogs.microsoft.com/dotnet/try-the-new-system-text-json-source-generator/
        //        gRPC: https://grpc.io/docs/languages/csharp/quickstart/

        #endregion
    }
}