using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp.Business.DtoModels;

namespace WebApp.Pages.Officer;

public class EditModel : PageModel
{
    [BindProperty]
    public OfficerDto Officer { get; set; }

    private readonly HttpClient _httpClient;
    public string Error { get; set; }

    public EditModel(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public List<SpaceStationDto> StationsList { get; set; }

    public async Task<IActionResult> OnGet(Guid id)
    {
        HttpClient httpClient = _httpClient;

        OfficerDto officerRetrieved = await httpClient.GetFromJsonAsync<OfficerDto>($"https://localhost:7202/api/Officer/{id}");
        Officer = officerRetrieved;

        List<SpaceStationDto> stations = await httpClient.GetFromJsonAsync<List<SpaceStationDto>>("https://localhost:7202/api/SpaceStations");
        StationsList = stations.ToList();

        return Page();
    }
}