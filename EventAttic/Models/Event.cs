using EventAttic.Data.Base;
using EventAttic.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventAttic.Models
{
    public class Event : IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Event Name")]
        public string? Name { get; set; }

        public string? Description { get; set; }

        [Display(Name = "Age Restriction")]
        public string? AgeRestriction { get; set; }

        public double Price { get; set; }

        [Display(Name = "Event Image")]
        public string? ImageUrl { get; set; }

        [Display(Name = "Time Till")]
        public string? TimeTill { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime StartDate { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime EndDate { get; set; }

        public EventGenereCategory EventGenereCategory { get; set; }

        //Relationships
        public List<Event_Artist> Events_Artists { get; set; }

        //Event
        public int EventLocationId { get; set; }
        [ForeignKey("EventLocationId")]
        public EventLocation? EventLocation { get; set; }

        //Organiser
        public int OrganiserId { get; set; }
        [ForeignKey("OrganiserId")]
        public Organiser? Organiser { get; set; }
    }
}
