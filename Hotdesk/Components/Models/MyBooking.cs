using Hotdesk.Models;

namespace Hotdesk.Components.Models
{
    public class MyBooking
    {
        public int Id { get; set; }
        public string UserId { get; set; } = string.Empty;
        public int BookingId { get; set; }

        // Navigation property
        public virtual Booking? Booking { get; set; }
    }
}
