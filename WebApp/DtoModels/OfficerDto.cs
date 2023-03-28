namespace SpaceProgram.WebApp.DtoModels;

public class OfficerDto
{
    public Guid OfficerId { get; set; }
    public string Name { get; set; }
    public string Rank { get; set; }
    public Guid SpaceStationId { get; set; }

    public OfficerDto()
    {
    }

    public OfficerDto(Guid officerId, string name, string rank, Guid spaceStationId)
    {
        OfficerId = officerId;
        Name = name;
        Rank = rank;
        SpaceStationId = spaceStationId;
    }
}