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
    public OfficerDto OfficerDto { get; set; } = new OfficerDto();
    public List<SpaceStationDto> StationsList { get; set; } = new List<SpaceStationDto>();
    public string Error { get; set; }

    public EditModel(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public override async Task<IActionResult> OnGet(Guid id)
    {
        var loadSpaceStationsResult = await this.LoadSpaceStations(_httpClient, StationsList, Error);
        if (loadSpaceStationsResult != null) { return loadSpaceStationsResult; }

        var loadOfficerResult = await this.LoadOfficer(_httpClient, id, OfficerDto, Error);
        if (loadOfficerResult != null) { return loadOfficerResult; }

        return await base.OnGet(id);
    }

    public async Task<IActionResult> OnPost(Guid id)
    {
        OfficerDto.OfficerId = id;

        var result = await this.LoadSpaceStations(_httpClient, StationsList, Error);
        if (result != null) { return result; }

        if (ModelState.IsValid)
        {
            try
            {
                string officerString = JsonConvert.SerializeObject(OfficerDto, Formatting.None);
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