using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Text;
using WebApp.Business.DtoModels;
using WebApp.Business.ParentPageModels;

namespace WebApp.Pages.Officer;

public class CreateModel : LoginValidationModel
{
    private readonly HttpClient _httpClient;

    [BindProperty]
    public OfficerDto OfficerDto { get; set; }
    public List<SpaceStationDto> StationsList { get; set; } = new List<SpaceStationDto>();
    public string Error { get; set; }

    public CreateModel(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public override async Task<IActionResult> OnGet()
    {
        return await base.OnGet();
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

    private async Task<IActionResult> loadStationList()
    {
        try
        {
            var httpGetResponse = await _httpClient.GetAsync("https://localhost:7202/api/spacestation");
            httpGetResponse.EnsureSuccessStatusCode();

            var responseString = await httpGetResponse.Content.ReadAsStringAsync();
            var jsonObject = JObject.Parse(responseString);

            foreach (var spaceStation in jsonObject["fetchedSpaceStations"])
            {
                StationsList.Add(new SpaceStationDto((Guid)spaceStation["spaceStationId"], spaceStation["name"].ToString()));
            }
            return null;
        }
        catch
        {
            Error = "Error - Could not retrieve the existing Space Stations.";
            return Page();
        }      
    }
}