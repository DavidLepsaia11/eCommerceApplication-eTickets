
using eTickets.Domain.Interfaces.Base;
using System.ComponentModel.DataAnnotations;

namespace eTickets.Domain.Models
{
    public class Cinema : IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name="Cinema logo")]
        [Required(ErrorMessage = "Cinema Logo is required")]
        public string Logo { get; set; }

        [Display(Name = "Cinema Name")]
        [Required(ErrorMessage = "Cinema Name is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Cinema Name must be between 3 and 50 chars")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [Display(Name = "Description")]
        [StringLength(450, MinimumLength = 20, ErrorMessage = "Description  must be between 20 and 450 chars")]
        public string Description { get; set; }

        //Relationships
        public ICollection<Movie> Movies  { get; set; }
    }
}
