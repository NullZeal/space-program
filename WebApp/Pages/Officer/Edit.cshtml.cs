using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Text;
using WebApp.Business.DtoModels;
using WebApp.Business.Extensions;
using WebApp.Business.ParentPageModels;

namespace WebApp.Pages.Officer;

public class EditModel : LoginValidationModel
{
    private readonly HttpClient _httpClient;

    [BindProperty]
    public OfficerDto Officer { get; set; } = new OfficerDto();
    public List<SpaceStationDto> StationsList { get; set; } = new List<SpaceStationDto>();
    public string Error { get; set; }

    public EditModel(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public override async Task<IActionResult> OnGet(Guid id)
    {
        var validate = await base.OnGet(id);
        if (validate != null) { return validate; }

        var loadSpaceStationsResult = await this.LoadSpaceStations(_httpClient, StationsList, Error);
        if (loadSpaceStationsResult != null) { return loadSpaceStationsResult; }

        return await this.LoadOfficer(_httpClient, id, Officer, Error);
    }

    public async Task<IActionResult> OnPost(Guid id)
    {
        Officer.OfficerId = id;

        var result = await this.LoadSpaceStations(_httpClient, StationsList, Error);
        if (result != null) { return result; }

        if (ModelState.IsValid)
        {
            try
            {
                string officerString = JsonConvert.SerializeObject(Officer, Formatting.None);
                HttpContent officerContent = new StringContent(officerString, Encoding.UTF8, "application/json");

                var httpPostResponse = await _httpClient.PutAsync("https://localhost:7202/api/officer/", officerContent);
                httpPostResponse.EnsureSuccessStatusCode();

                return RedirectToPage("/officer/index");
            }
            catch (Exception ex)
            {
                Error = ex.Message;
            }
        }
        return Page();
    }
}