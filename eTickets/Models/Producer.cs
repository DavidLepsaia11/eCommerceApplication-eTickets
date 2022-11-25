using eTickets.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace eTickets.Models
{
    public class Producer : IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Profile Picture")]
        [Required(ErrorMessage = "Profile picture is required")]
        public string ProfilePictureURL { get; set; }

        [Display(Name = "Full Name")]
        [Required(ErrorMessage = "Full Name is required")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Full Name must be between 5 and 50 chars")]
        public string FullName { get; set; }

        [Display(Name = "Biography")]
        [Required(ErrorMessage = "Biography is required")]
        [StringLength(450, MinimumLength = 20, ErrorMessage = "Biography must be between 20 and 450 chars")]
        public string Bio { get; set; }

        // RelationShips
        public ICollection<Movie> Movies { get; set; }
    }
}
