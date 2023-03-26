using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpaceProgram.DataLayer.Models
{
    public class Officer
    {
        [Key]
        [Display(Name = "Officer Badge Number")]
        public Guid OfficerId { get; set; }

        [Required]
        [Display(Name = "Officer Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Officer Rank")]
        public string Rank { get; set; }

        [ForeignKey("SpaceStationId")]
        public Guid SpaceStationId { get; set; }

        public virtual SpaceStation SpaceStation { get; set; }

        public Officer()
        {
        }
    }
}
