namespace Demo
{
    public static class Demo003
    {

        //public static string Get(Person person)
        //{
        //    if ((bool)(person?.Name.HasValue()))
        //      //  person = new() { Name = "Laura" };

        //    return person.ToString();
        //}

        private static bool HasValue(this string value)
        {
            if (string.IsNullOrEmpty(value))
                return true;

            return false;
        }
        public static void DateValues()
        {
            var d = DateOnly.MaxValue;
            var dd = DateTime.UtcNow;
            var ddd = DateTimeKind.Local;
            var dddd = DateTimeOffset.Now;
            var unix = DateTime.UnixEpoch;
            IList<string> values = new List<string>();
            values.Add("Jesus");
            values.Add("Laura");
            values.Add("Gabriel");
            values.Add("Laura");
            values.Add("Vax");
            values.Add("Laura"); values.Add("Laura");
            values.Add("Laura");
            values.Add("Laura1");
            values.Add("Laura");
            values.RemoveAt(1);


            if (values.Contains("Vax"))
            {
                var valuess = values.Take(new Range(2, 7));

                valuess.ToList().ForEach(x => Console.WriteLine(x));

            }
            /*
             access modifier return type method_name (parameters){
              
            1- OOP
               Custom types:
               Class:
                    Fields: 
                    Variable:
                    Constructors:
                    Methods, 
                    Properties, 
                    Events
                    Acess modifiers: public, private,protected
               Struct:
               Objects:

            Types:  
                Type date privative:Value
                Enumeration: Value
                Struct: Value
                Class: reference
                String: reference
                Interface: reference
                Delegate: reference
               
             */
        }

        private static void ParseString(string value)
        {
            /*
             \n - break line
             \t - space
             */
            String.GetHashCode(value);
            var internalValue = string.Empty;
        }

        private static void ParseDate(DateTime date)
        {
            throw new NotImplementedException();
        }
    }

    public record PersonDetails(string FirstNaem, string LastNem, string Adress, DateTimeOffset DateOfBirth);

    public class Person
    {
        public Person(int id)
        {
            Id = id;
        }
        public int Id { get; private set; }
        public string Name { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public DateTimeOffset DateOfBirth { get; set; }

        public string ToString() => $"My name is: {this.Name}";
    }
}