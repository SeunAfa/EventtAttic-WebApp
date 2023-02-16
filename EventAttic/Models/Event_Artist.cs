namespace EventAttic.Models
{
    public class Event_Artist
    {
        public int EventId { get; set; }
        public Event Event { get; set; }

        public int ArtistId { get; set; }
        public Artist Artist { get; set; }
    }
}
