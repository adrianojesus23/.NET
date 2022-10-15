namespace Command
{
    public class Class1
    {
        public class Product
        {
            public string Name { get; set; }
            public int Price { get; set; }

            public Product(string name, int price)
            {
                Name = name;
                Price = price;
            }

            public void IncreasePrice(int amount)
            {
                Price += amount;
                Console.WriteLine($"The price for the {Name} has been increased by {amount}$.");
            }

            //public void DecreasePrice(int amount)
            //{
            //    if (amount < Price)
            //    {
            //        Price -= amount;
            //        Console.WriteLine($"The price for the {Name} has been decreased by {amount}$.");
            //    }
            //}
            public bool DecreasePrice(int amount)
            {
                if (amount < Price)
                {
                    Price -= amount;
                    Console.WriteLine($"The price for the {Name} has been decreased by {amount}$.");
                    return true;
                }
                return false;
            }

            public override string ToString() => $"Current price for the {Name} product is {Price}$.";
        }
        public interface ICommand
        {
            void ExecuteAction();
            void UndoAction();
        }
        public enum PriceAction
        {
            Increase,
            Decrease
        }

        public class ProductCommand : ICommand
        {
            private readonly Product _product;
            private readonly PriceAction _priceAction;
            private readonly int _amount;

            public bool IsCommandExecuted { get; private set; }

            public ProductCommand(Product product, PriceAction priceAction, int amount)
            {
                _product = product;
                _priceAction = priceAction;
                _amount = amount;
            }

            public void ExecuteAction()
            {
                if (_priceAction == PriceAction.Increase)
                {
                    _product.IncreasePrice(_amount);
                    IsCommandExecuted = true;
                }
                else
                {
                    IsCommandExecuted = _product.DecreasePrice(_amount);
                }
            }

            public void UndoAction()
            {
                if (!IsCommandExecuted)
                    return;

                if (_priceAction == PriceAction.Increase)
                {
                    _product.DecreasePrice(_amount);
                }
                else
                {
                    _product.IncreasePrice(_amount);
                }
            }
        }

    }
}