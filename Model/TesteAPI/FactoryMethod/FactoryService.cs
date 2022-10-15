namespace FactoryMethod
{
    public abstract class FactoryService
    {
        public abstract int Count { get; set; }

        public abstract int GetCount();
    }


    public class Factory : FactoryService
    {
        private static Factory instance;

        public override int Count { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override int GetCount()
        {
            throw new NotImplementedException();
        }
    }

    public enum TypeEnum
    {
        A,
        B
    }

    public interface IType
    {
        string Create(string code = "");
    }

    public class ManagerType : IType
    {
        private readonly string _code;

        public ManagerType(string code)
        {
            _code = code;
        }
        public string Create(string code = "") => $"{_code} {code}";
    }

    public abstract class AType
    {
        public abstract IType Builder(string code);
    }

    public class FactoryType : AType
    {
        public override IType Builder(string code) => new ManagerType(code);
    }
    public class AirConditioner
    {
        private readonly Dictionary<TypeEnum, FactoryType> _factories;

        private AirConditioner()
        {
            _factories = new Dictionary<TypeEnum, FactoryType>();

            foreach (TypeEnum action in Enum.GetValues(typeof(TypeEnum)))
            {
                var factory = (FactoryType)Activator.CreateInstance(Type.GetType("FactoryMethod." + Enum.GetName(typeof(TypeEnum), action) + "Factory"));
                _factories.Add(action, factory);
            }
        }

        public static AirConditioner InitializeFactories() => new AirConditioner();

        public IType ExecuteCreation(TypeEnum action, string code)
        {
            return _factories[action].Builder(code);
        }
    }

}
