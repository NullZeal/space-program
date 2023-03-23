using Microsoft.IdentityModel.Tokens;
using System.ComponentModel.DataAnnotations;

namespace SpaceProgramApi.Models
{
    public class SpaceStation
    {
        [Key]
        [Display(Name = "Station Number")]
        public Guid SpaceStationId { get; set; }

        [Required]
        [Display(Name = "Station Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "List of all officers")]
        public List<Officer> OfficerList { get; set; }

        public SpaceStation()
        {
        }
    }
}
