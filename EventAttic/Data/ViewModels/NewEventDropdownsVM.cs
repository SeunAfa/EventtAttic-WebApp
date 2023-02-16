using EventAttic.Models;

namespace EventAttic.Data.ViewModels
{
    public class NewEventDropdownsVM
    {
        public NewEventDropdownsVM()
        {
            Organisers = new List<Organiser>();
            Artists = new List<Artist>();
            EventLocations = new List<EventLocation>();
        }
        public List<Organiser> Organisers { get; set; }
        public List<Artist> Artists { get; set; }
        public List<EventLocation> EventLocations { get; set; }
    }
}
