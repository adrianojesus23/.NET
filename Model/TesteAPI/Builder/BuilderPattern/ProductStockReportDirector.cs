namespace Builder.BuilderPattern
{
    public class ProductStockReportDirector
    {
        private readonly IProductStock _productStock;

        public ProductStockReportDirector(IProductStock productStockReportBuilder)
        {
            _productStock = productStockReportBuilder;
        }

        public void BuildStockReport()
        {
            _productStock.BuilderHeader().BuilderBody().BuilderFooter();
        }
    }
}
