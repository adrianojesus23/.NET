namespace Builder.BuilderPattern
{
    public class ProductStockReportBuilder : IProductStock
    {
        private readonly IEnumerable<Product> _products;
        private ProductStock _productStock;
        /// <summary>
        /// ConcreteBuilder 
        /// </summary>
        /// <param name="products"></param>
        public ProductStockReportBuilder(IEnumerable<Product> products)
        {
            _products = products;
            _productStock = new();
            _productStock.Products = new List<Product>();
        }
        public IProductStock BuilderBody()
        {
            _productStock.Body = _products.Select(x => x.Name + " - " + x.Price).FirstOrDefault();
            _products.ToList().ForEach(x => _productStock.Products.Add(x));
            return this;
        }

        public IProductStock BuilderFooter()
        {
            _productStock.Footer = "Footer";
            return this;
        }

        public IProductStock BuilderHeader()
        {
            _productStock.Header = "Header";
            return this;
        }

        public ProductStock Get()
        {
            var productStockReport = _productStock;
            Clear();
            return productStockReport;
        }

        public IList<Product> GetAll()
        {
            return _productStock.GetAll();
        }

        public Product Retrieve(int id)
        {
            return _productStock.Retrieve(id);
        }

        public string Show(Product product)
        {
            return $"{nameof(product.Id)}: {product.Id}, {nameof(product.Name)}:{product.Name} , {nameof(product.Price)}:{product.Price}";
        }

        private void Clear() => _productStock = new();
    }
}
