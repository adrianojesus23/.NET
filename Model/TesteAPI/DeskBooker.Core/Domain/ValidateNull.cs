namespace DeskBooker.Core.Domain
{
    public readonly record struct ValidateNull
    {
        private readonly string _name;

        public ValidateNull(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException(nameof(name));
            _name = name;
        }

        public override string ToString() => _name;
    }
}
