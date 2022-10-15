using System.ComponentModel.DataAnnotations;

namespace DeskBooker.Core.Domain
{
    public class DeskBookingBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required]
        [StringLength(50)]
        [EmailAddress]
        public string Email { get; set; }
        [DataType(DataType.Date)]
        //[DateInFuture]
        //[DateWithouTime]
        public DateTime Date { get; set; }
    }
}