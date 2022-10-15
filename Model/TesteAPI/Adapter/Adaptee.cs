using Dawn;

namespace Adapter
{
    public class Adaptee
    {
        public string GetDetails(string name)
        {
            return $"{name} {nameof(name)}";
        }
    }

    public class Adapter : ITarget
    {
        private readonly Adaptee _adaptee;

        public Adapter(Adaptee adaptee)
        {
            _adaptee = adaptee;
        }
        public string GetName()
        {
            return "return interface";
        }

        public string GetName(string name)
        {
            return _adaptee.GetDetails(name);
        }

        public static void GuardExeception(Adaptee adaptee)
        {
            var xx = Guard.Argument(adaptee, nameof(adaptee)).HasValue();
        }
    }
}
