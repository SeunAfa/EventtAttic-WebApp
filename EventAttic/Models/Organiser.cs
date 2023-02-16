using EventAttic.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace EventAttic.Models
{
    public class Organiser : IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Profile Picture Url")]
        [Required]
        public string? ProfilePictureURL { get; set; }

        [Display(Name = "Name")]
        [Required]
        public string? EventOrganiserName { get; set; }

        [Display(Name = "Biography")]
        //[Required]
        public string? Bio { get; set; }

        //Maybe Promoter social medai links
        [Display(Name = "Instagram")]
        [Required]
        public string? InstaLink { get; set; }


        [Display(Name = "Twitter")]
        [Required]
        public string? TwitterLink { get; set; }

        //Relationships
        public List<Event>? Events { get; set; }
    }
}
