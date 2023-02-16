using EventAttic.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace EventAttic.Models
{
    public class Artist : IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Profile Picture Url")]
        [Required(ErrorMessage = "Profile Picture is required")]
        public string? ProfilePictureURL { get; set; }

        [Display(Name = "Stage Background Image Url")]
        [Required(ErrorMessage = "Stage Picture URL is required")]
        public string? StagePictureURL { get; set; }

        [Display(Name = "Artist")]
        [Required(ErrorMessage = "Artist Name is required")]
        public string? ArtistName { get; set; }

        [Display(Name = "Biography")]
        [Required(ErrorMessage = "Biography is required")]
        //[StringLength(450, MinimumLength = 5, ErrorMessage = "Biography must be between 5 to 150 characters")]
        public string? Bio { get; set; }

        //SpotifyList
        [Display(Name = "Spotify")]
        [Required(ErrorMessage = "SpotifyPlayList URl is required")]
        public string? SpotifyPlayList { get; set; }

        //Insta
        [Display(Name = "Instagram")]
        [Required(ErrorMessage = "Instagram account link is required")]
        public string? InstaLink { get; set; }

        //Twitter
        [Display(Name = "Twitter")]
        [Required(ErrorMessage = "Twitter account link is required")]
        public string? TwitterLink { get; set; }

        //Relationships
        public List<Event_Artist>? Events_Artists { get; set; }
    }
}
