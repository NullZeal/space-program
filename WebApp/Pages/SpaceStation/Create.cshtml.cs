using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using WebApp.Business.DtoModels;
using WebApp.Business.ParentPageModels;

namespace WebApp.Pages.SpaceStation;

public class CreateModel : LoginValidationModel
{
    private readonly HttpClient _httpClient;

    [BindProperty]
    public SpaceStationDto SpaceStation { get; set; } = new SpaceStationDto();
    public string Error { get; set; }

    public CreateModel(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    
    public override async Task<IActionResult> OnGet(Guid id)
    {
        return await base.OnGet(id);
    }

    public async Task<IActionResult> OnPost()
    {
        if (ModelState.IsValid)
        {
            try
            {
                string spaceStationString = JsonConvert.SerializeObject(SpaceStation, Formatting.None);
                HttpContent spaceStationContent = new StringContent(spaceStationString, Encoding.UTF8, "application/json");
                
                var httpPostResponse = await _httpClient.PostAsync("https://localhost:7202/api/spacestation/", spaceStationContent);
                httpPostResponse.EnsureSuccessStatusCode();

                return RedirectToPage("/spacestation/index");
            }
            catch(Exception ex)
            {
                Error = ex.Message;
            }
        }
        return Page();
    }
}