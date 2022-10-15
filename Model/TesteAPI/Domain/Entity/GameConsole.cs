using System.ComponentModel.DataAnnotations;

namespace Domain.Entity
{
    public class GameConsole
    {
        public int Id { get; set; }
        [Required]
        [MinLength(10)]
        [MaxLength(30)]
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public ICollection<Game> Games { get; set; }
    }
}
