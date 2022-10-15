namespace Builder.BuilderPattern
{
    public interface IProductStock
    {
        /// <summary>
        /// Interface: Builder
        /// </summary>
        /// <returns></returns>
        IProductStock BuilderHeader();
        IProductStock BuilderBody();
        IProductStock BuilderFooter();
        ProductStock Get();
        Product Retrieve(int id);
        IList<Product> GetAll();
    }
}
