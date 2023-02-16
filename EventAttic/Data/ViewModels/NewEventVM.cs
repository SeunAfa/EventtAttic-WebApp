using EventAttic.Data.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EventAttic.Data.ViewModels
{
    public class NewEventVM
    {
        public int Id { get; set; }

        [DisplayName("Event Title")]
        [Required(ErrorMessage = "Event title is required")]
        public string? Name { get; set; }

        [DisplayName("Description")]
        [Required(ErrorMessage = "Description is required")]
        public string? Description { get; set; }

        [DisplayName("Age Restriction")]
        [Required(ErrorMessage = "Age restriction is required")]
        public string? AgeRestriction { get; set; }

        [DisplayName("Price (£)")]
        [Required(ErrorMessage = "Price is required")]
        public double Price { get; set; }


        [Required(ErrorMessage = " Image Url is required")]
        [Display(Name = "Image Url")]
        public string? ImageUrl { get; set; }

        [Required(ErrorMessage = "Time is required")]
        [Display(Name = "Time Till")]
        public string? TimeTill { get; set; }

        [Required(ErrorMessage = "Start Date is required")]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "End Date is required")]
        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }

        [Required(ErrorMessage = "Music genre is required")]
        [Display(Name = "Music Genre")]
        public EventGenereCategory EventGenereCategory { get; set; }

        //Relationships
        //[Required(ErrorMessage = "Event Performing Artist is required")]
        //[Display(Name = "Select Performing Artist")]
        [Display(Name = "")]
        public List<int>? ArtistIds { get; set; }

        //Event
        [Required(ErrorMessage = "Venue is required")]
        [Display(Name = "Venue")]
        public int EventLocationId { get; set; }

        //Organiser
        [Required(ErrorMessage = "Organiser is required")]
        [Display(Name = "Select Organiser")]
        public int OrganiserId { get; set; }
    }
}
