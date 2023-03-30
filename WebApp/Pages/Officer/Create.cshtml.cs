using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using WebApp.Business.DtoModels;
using WebApp.Business.ParentPageModels;
using WebApp.Business.Extensions;

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
        var result = await this.LoadSpaceStations(_httpClient, StationsList, Error);
        if (result != null) { return result; }
        return await base.OnGet();
    }

    public async Task<IActionResult> OnPost()
    {
        var result = await this.LoadSpaceStations(_httpClient, StationsList, Error);
        if (result != null) { return result; }

        if (ModelState.IsValid)
        {
            try
            {
                string officerString = JsonConvert.SerializeObject(OfficerDto, Formatting.None);
                HttpContent officerContent = new StringContent(officerString, Encoding.UTF8, "application/json");
                
                var httpPostResponse = await _httpClient.PostAsync("https://localhost:7202/api/officer/", officerContent);
                httpPostResponse.EnsureSuccessStatusCode();

                return RedirectToPage("/officer/index");
            }
            catch(Exception ex)
            {
                Error = ex.Message;
            }
        }
        return Page();
    }
}