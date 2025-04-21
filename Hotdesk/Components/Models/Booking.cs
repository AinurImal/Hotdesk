using Hotdesk.Components.Models;

namespace Hotdesk.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public int DeskId { get; set; }
        public string UserId { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public DateTime BookingDate { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool CheckedIn { get; set; }
        public DateTime? CheckInTime { get; set; }

        // Navigation property
        public virtual Desk? Desk { get; set; }
    }
}