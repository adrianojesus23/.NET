using System.Collections;

namespace Generic
{
    public class Class1
    {
        /*
         * Collection: object , type
            List 
            Dictionary -- key,value
           arrays
         
         
         
         
         
         */

        public struct Person
        {
            public Person(int id, string name)
            {
                Id = id;
                Name = name;
            }
            public int Id { get; set; }
            public string Name { get; set; }
        }
        public record struct Product(int CategoryId, string Name)
        {
            public Product() : this(int.MinValue, "Disk") { } // Uses internally the primary constructor

            public Product(int categoryId) : this(categoryId, "Disk") { } // Uses internally the primary constructor

            public Product(string name) : this(int.MinValue) { } // Uses the constructor with the int categoryId parameter
        }

        public record struct Pessoal
        {
            public DateTimeOffset date => DateTimeOffset.Now;
            public int Id { get; set; }
        }

        public string ToDate(DateTime date) => date.Hour switch
        {
            >= 5 and <= 9 => "Good morning",
            >= 9 and <= 19 => "Good afternoon",
            _ => "Good Night"
        };

        public interface IDate
        {
            public DateTimeOffset _Now { get; }
        }

        public sealed record Date : IDate
        {
            public DateTimeOffset _Now => DateTimeOffset.Now;
        }

        public record struct DateService
        {
            private readonly Date _date;

            public DateService(Date date)
            {
                _date = date;
            }
        }

        public static IEnumerable<int> ForEach(List<int> ints)
        {
            foreach (var item in ints)
            {
                yield return item;
            }

            yield return 1;
        }

        public record TesteDate
        {
            private readonly IDate _date;

            public TesteDate(IDate dateService)
            {
                _date = dateService;
            }

            public DateTimeOffset GetDate()
            {
                return _date._Now;
            }
        }

        public static List<int> SkipWhile(List<int> ints)
        {
            ints.Sort();

            var x = (List<int>)ints.SkipWhile(x => x > 2);
            var x1 = (List<int>)ints.SkipLast<int>(2);
            var x2 = (List<int>)ints.Skip<int>(2);

            var x9 = (List<int>)ints.Take(7);
            var x4 = (List<int>)ints.TakeWhile(x => x > 2);
            var x5 = (List<int>)ints.ToLookup(x => x > 2);
            ints.ToHashSet();
            var x7 = (List<int>)ints.Chunk(5);
            var x8 = ints.BinarySearch(8);
            return (List<int>)ints.SkipWhile(x => x > 2);
        }

        public int[] GetArray(Span<int> lists, IDate date)
        {
            Person<string> person = new("Name");
            Person<int> person1 = new(3);
            Vendor<TesteDate> vendor = new();
            vendor.Lista = new Lazy<List<TesteDate>>();
            vendor.Lista2 = new List<TesteDate>();
            var item3 = new TesteDate(date);
            vendor.Lista2.Add(item3);

            vendor.Lista2.SkipWhile(x => x != null).Chunk<TesteDate>(2);

            var arr = new int[lists.Length + 1];
            var sp = new Span<int>();
            sp.Fill(3);
            Pessoal xx = new();


            var z = Retrieve<int, string>("", 2);
            foreach (var item in lists)
            {
            }

            return arr;
        }
        public T Populate<T>(string s) where T : class, new()
        {
            T ins = new T();

            return ins;
        }



        public T Retrieve<T, P>(string s, T defaultName)
        {
            T value = defaultName;

            IList<T> _values = new List<T>();
            _values.Add(defaultName);
            _values.Insert(2, value);
            Dictionary<T, T> keyValuePairs = new();
            SortedDictionary<T, T> keyValuePairs2 = new SortedDictionary<T, T>();
            SortedList<T, T> list = new SortedList<T, T>();
            SortedSet<T> list2 = new SortedSet<T>();

            //ILookup<T, T> lookup = new Lookup<T, T>();

            return value;
        }



        public class Lookup : ILookup<int, string>
        {
            public IEnumerable<string> this[int key] => throw new NotImplementedException();

            public int Count => throw new NotImplementedException();

            public bool Contains(int key)
            {
                throw new NotImplementedException();
            }

            public IEnumerator<IGrouping<int, string>> GetEnumerator()
            {
                throw new NotImplementedException();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                throw new NotImplementedException();
            }
        }

        public record Vendor<T> where T : class
        {
            public Lazy<List<T>> Lista { get; set; }
            public IList<T> Lista2 { get; set; }


        }

        public record Person<T>
        {
            private T _name;

            private T Name { get => _name; set => _name = value; }
            public Person(T name)
            {
                this.Name = name;
            }
        }
    }


}