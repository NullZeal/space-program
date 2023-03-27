using SpaceProgram.DataLayer.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BusinessLayer.DtoModels
{
    public class OfficerDto
    {
        public Guid OfficerId { get; set; }

        public string Name { get; set; }

        public string Rank { get; set; }

        public Guid SpaceStationId { get; set; }

        public OfficerDto()
        {
        }
    }
}