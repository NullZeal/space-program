using System.ComponentModel.DataAnnotations;

namespace SpaceProgram.DataLayer.Models;

public class SpaceStation
{
    [Key]
    [Display(Name = "Station Number")]
    public Guid SpaceStationId { get; set; }

    [Required]
    [Display(Name = "Station Name")]
    public string Name { get; set; }

    [Display(Name = "List of all officers")]
    public virtual ICollection<Officer> OfficerList { get; set; }

    public SpaceStation()
    {
    }
}
