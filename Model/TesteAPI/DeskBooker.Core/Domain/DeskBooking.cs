namespace DeskBooker.Core.Domain
{
    public class DeskBooking : DeskBookingBase
    {
        public int Id { get; set; }
        public int DeskId { get; set; }


        public static string DeskName(ValidateNull validate)
        {
            if (validate.ToString() == null)
            {

            }
            return string.Empty;
        }


    }
}
