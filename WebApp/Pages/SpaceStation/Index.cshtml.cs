using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using WebApp.Business.DtoModels;
using WebApp.Business.Extensions;
using WebApp.Business.ParentPageModels;

namespace SpaceProgramWeb.Pages.SpaceStation;

public class IndexModel : LoginValidationModel
{
    private readonly HttpClient _httpClient;

    public List<SpaceStationDto> SpaceStations = new List<SpaceStationDto>();
    public string Error { get; set; }
    
    public IndexModel(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public override async Task<IActionResult> OnGet(Guid id)
    {
        var validate = await base.OnGet(id);
        if (validate != null) { return validate; }

        return await this.LoadSpaceStations(_httpClient, SpaceStations, Error);
    }
}
