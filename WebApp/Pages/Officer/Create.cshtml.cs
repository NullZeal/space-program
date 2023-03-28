using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text;
using Newtonsoft.Json.Linq;
using SpaceProgram.WebApp.DtoModels;
using Newtonsoft.Json;

namespace WebApp.Pages.Officer;

public class CreateModel : PageModel
{
    [BindProperty]
    public OfficerDto OfficerDto { get; set; }

    private readonly HttpClient _httpClient;
    public string Error { get; set; }

    public CreateModel(HttpClient httpClient)
    {
        _httpClient = httpClient;
        StationsList = new List<SpaceStationDto>();
    }

    public List<SpaceStationDto> StationsList { get; set; }

    public async Task OnGet()
    {
        var response = await _httpClient.GetAsync("https://localhost:7202/api/spacestation");
        var values = await response.Content.ReadAsStringAsync();
        var obj = JObject.Parse(values);
        foreach (var item in obj["fetchedSpaceStations"])
        {
            StationsList.Add(new SpaceStationDto((Guid)item["spaceStationId"], item["name"].ToString()));
        }
    }

    public async Task<IActionResult> OnPost()
    {

        var response1 = await _httpClient.GetAsync("https://localhost:7202/api/spacestation");
        var values1 = await response1.Content.ReadAsStringAsync();
        var obj1 = JObject.Parse(values1);
        foreach (var item in obj1["fetchedSpaceStations"])
        {
            StationsList.Add(new SpaceStationDto((Guid)item["spaceStationId"], item["name"].ToString()));
        }

        if (ModelState.IsValid)
        {
            using StringContent jsonContent = new StringContent(
                System.Text.Json.JsonSerializer.Serialize(OfficerDto),
                Encoding.UTF8,
                "application/json"
            );

            var response = await _httpClient.PostAsync("https://localhost:7202/api/officer/", jsonContent);
            var values = await response.Content.ReadAsStringAsync();
            var obj = JObject.Parse(values);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToPage("/Index");
            }
            else
            {
                Error = obj["detail"].ToString();
            }
        }
        return Page();
    }
}
