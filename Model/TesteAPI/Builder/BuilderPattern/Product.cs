namespace Builder.BuilderPattern
{
    public record Product
    {
        /// <summary>
        /// Class base de product
        /// </summary>
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
    }
}
