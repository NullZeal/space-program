using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using WebApp.Business.DtoModels;
using WebApp.Business.Extensions;
using WebApp.Business.ParentPageModels;

namespace WebApp.Pages.SpaceStation;

public class EditModel : LoginValidationModel
{
    private readonly HttpClient _httpClient;

    [BindProperty]
    public SpaceStationDto SpaceStation { get; set; } = new SpaceStationDto();
    public string Error { get; set; }

    public EditModel(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public override async Task<IActionResult> OnGet(Guid id)
    {
        var validate = await base.OnGet(id);
        if (validate != null) { return validate; }

        return await this.LoadSpaceStation(_httpClient, id, SpaceStation, Error);
    }

    public async Task<IActionResult> OnPost(Guid id)
    {
        SpaceStation.SpaceStationId = id;

        if (ModelState.IsValid)
        {
            try
            {
                string spaceStationString = JsonConvert.SerializeObject(SpaceStation, Formatting.None);
                HttpContent spaceStationContent = new StringContent(spaceStationString, Encoding.UTF8, "application/json");

                var httpPostResponse = await _httpClient.PutAsync("https://localhost:7202/api/spacestation/", spaceStationContent);
                httpPostResponse.EnsureSuccessStatusCode();

                return RedirectToPage("/spacestation/index");
            }
            catch (Exception ex)
            {
                Error = ex.Message;
            }
        }
        return Page();
    }
}