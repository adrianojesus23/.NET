using Microsoft.Extensions.ObjectPool;
using System.Collections.Immutable;
using System.Text;
namespace Builder.BuilderPattern
{
    public class Employee
    {
        /// <summary>
        /// Implementing Recursive Generics with Fluent Builder
        /// </summary>
        public string Name { get; set; }
        public string Position { get; set; }
        public double Salary { get; set; }
        private readonly ObjectPool<StringBuilder> _stringBuilderPool =
                    new DefaultObjectPoolProvider().CreateStringBuilderPool();

        public override string ToString()
        {
            return $"Name: {Name}, Position: {Position}, Salary: {Salary}";
        }

        //ImmutableSortedDictionary.CreateRange
        public void Sorted(Employee employee)
        {
            var builder = ImmutableSortedSet.CreateBuilder<Employee>();
            builder.Add(employee);
            var collection = builder.ToImmutable();
            foreach (var item in collection)
            {


            }
            var sb = this._stringBuilderPool.Get();
            //var _stringArray = new Array();
            // for (var index = 0; index < this._stringArray.Length; index++)
            // {
            //     _ = sb.Append(this._stringArray[index]);
            // }

            //var xx = _stringBuilderPool.Return(sb);

        }
    }
}

