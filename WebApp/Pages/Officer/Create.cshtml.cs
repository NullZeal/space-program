using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpaceProgram.WebApp.DtoModels;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Text;

namespace WebApp.Pages.Officer;

public class CreateModel : PageModel
{
    [BindProperty]
    public OfficerDto OfficerDto { get; set; }
    public List<SpaceStationDto> StationsList { get; set; } = new List<SpaceStationDto>();
    public string Error { get; set; }
    private readonly HttpClient _httpClient;

    public CreateModel(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task OnGet()
    {
        await loadStationList();
    }

    public async Task<IActionResult> OnPost()
    {
        await loadStationList();

        if (ModelState.IsValid)
        {
            try
            {
                string officerString = JsonConvert.SerializeObject(OfficerDto, Formatting.None);
                HttpContent officerContent = new StringContent(officerString, Encoding.UTF8, "application/json");
                
                var httpPostResponse = await _httpClient.PostAsync("https://localhost:7202/api/officer/", officerContent);
                httpPostResponse.EnsureSuccessStatusCode();

                return RedirectToPage("/Index");
            }
            catch(Exception ex)
            {
                Error = ex.Message;
            }
        }
        return Page();
    }

    private async Task loadStationList()
    {
        var httpGetResponse = await _httpClient.GetAsync("https://localhost:7202/api/spacestation");
        httpGetResponse.EnsureSuccessStatusCode();

        var responseString = await httpGetResponse.Content.ReadAsStringAsync();
        var jsonObject = JObject.Parse(responseString);

        foreach (var spaceStation in jsonObject["fetchedSpaceStations"])
        {
            StationsList.Add(new SpaceStationDto((Guid)spaceStation["spaceStationId"], spaceStation["name"].ToString()));
        }
    }
}
