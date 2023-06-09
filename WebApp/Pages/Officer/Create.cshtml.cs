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
    public OfficerDto Officer { get; set; }
    public List<SpaceStationDto> StationsList { get; set; } = new List<SpaceStationDto>();
    public string Error { get; set; }

    public CreateModel(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    
    public override async Task<IActionResult> OnGet(Guid id)
    {
        var validate = await base.OnGet(id);
        if (validate != null) { return validate; }

        return await this.LoadSpaceStations(_httpClient, StationsList, Error);
    }

    public async Task<IActionResult> OnPost()
    {
        var result = await this.LoadSpaceStations(_httpClient, StationsList, Error);
        if (result != null) { return result; }

        if (ModelState.IsValid)
        {
            try
            {
                string officerString = JsonConvert.SerializeObject(Officer, Formatting.None);
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