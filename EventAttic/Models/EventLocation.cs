using EventAttic.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace EventAttic.Models
{
    public class EventLocation : IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? Venue { get; set; }

        [Required]
        [Display(Name = "Street Address")]
        public string? StreetAddress { get; set; }

        [Required]
        public string? City { get; set; }

        [Required]
        [Display(Name = "Post Code")]
        public string? PostCode { get; set; }

        //Relationships
        public List<Event>? Events { get; set; }

    }
}
