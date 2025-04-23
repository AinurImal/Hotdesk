namespace Hotdesk.Components.Models
{
    public class BookingFinder
    {
        public int Id { get; set; }
        public string Location { get; set; } = string.Empty;
        public bool IsAvailable { get; set; }
        public DateTime? Date { get; set; }
    }
}
