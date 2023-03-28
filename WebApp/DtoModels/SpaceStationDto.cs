namespace SpaceProgram.WebApp.DtoModels;

public class SpaceStationDto
{
    public Guid SpaceStationId { get; set; }
    public string Name { get; set; }

    public SpaceStationDto()
    {
    }

    public SpaceStationDto(Guid spaceStationId, string name)
    {
        SpaceStationId = spaceStationId;
        Name = name;
    }
}