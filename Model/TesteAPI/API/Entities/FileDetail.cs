namespace API.Entities
{
    public class FileDetail
    {
        public Guid Id { get; set; }
        public DateTime? DateEntered { get; set; }
        public bool? Deleted { get; set; }
        public string? DocumentName { get; set; }
        public string? DocId { get; set; }
        public string? DocType { get; set; }
        public string? DocUrl { get; set; }
    }
}
