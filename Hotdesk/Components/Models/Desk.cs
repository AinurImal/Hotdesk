namespace Hotdesk.Components.Models
{
    public class Desk
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public bool HasMonitor { get; set; }
        public bool IsAvailable { get; set; } = true;
        public string? Description { get; set; }
    }
}