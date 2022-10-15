namespace API.Entities
{
    public record UserDto
    {
        public string? Name { get; set; }
        public string? Local { get; set; }
        public string? Email { get; set; }
    }
}