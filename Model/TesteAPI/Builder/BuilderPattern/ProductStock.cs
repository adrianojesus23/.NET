using System.Text;

namespace Builder.BuilderPattern
{
    public class ProductStock
    {
        public IList<Product> Products { get; set; }
        public string Header { get; set; }
        public string Body { get; set; }
        public string Footer { get; set; }
        public override string ToString() => new StringBuilder(Header).AppendLine(Body).AppendLine(Footer).ToString();
        public void Add(Product product)
        {
            Products.Add(product);
        }
        public Product? Retrieve(int id)
        {
            return Products.FirstOrDefault(x => x.Id == id);
        }

        public IList<Product> GetAll()
        {
            return Products;
        }
    }
}
