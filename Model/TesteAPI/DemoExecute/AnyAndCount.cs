using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

namespace DemoExecute
{
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    public class AnyAndCount
    {
        private static readonly IEnumerable<int> _ints = Enumerable.Range(1, 1000);
        [Benchmark]
        public bool CheckWithAny(int num)
        {
            //check value exist
            //Check return are greater than num
            return _ints.Any(x => x > num);
        }

        // IEnumerable --> Use Any
        //  ICollection --> use count

        [Benchmark]
        public bool CheckWithCount()
        {
            return _ints.Count() > 0;
        }

        [Benchmark]
        public bool CheckWithCountAndCondition()
        {
            return _ints.Count(num => num > 500) > 0;
        }
    }
}
