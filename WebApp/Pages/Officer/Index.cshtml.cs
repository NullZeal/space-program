using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using WebApp.Business.DtoModels;
using WebApp.Business.ParentPageModels;

namespace WebApp.Pages.Officer;

public class IndexModel : LoginValidationModel
{
    private readonly HttpClient _httpClient;

    public List<OfficerDto> OfficerList = new List<OfficerDto>();
    public string Error { get; set; }
    
    public IndexModel(HttpClient httpClient)
    {
        _httpClient = httpClient;
        
    }

    public override async Task<IActionResult> OnGet(Guid id)
    {
        var validate = await base.OnGet(id);
        if (validate != null) { return validate; }

        return await LoadOfficerList();
    }

    private async Task<IActionResult> LoadOfficerList()
    {
        try
        {
            var httpGetResponse = await _httpClient.GetAsync("https://localhost:7202/api/officer");
            httpGetResponse.EnsureSuccessStatusCode();

            var responseString = await httpGetResponse.Content.ReadAsStringAsync();
            var jsonObject = JObject.Parse(responseString);

            foreach (var officer in jsonObject["fetchedOfficers"])
            {
                OfficerList.Add(new OfficerDto((Guid)officer["officerId"], officer["name"].ToString(), officer["rank"].ToString(), (Guid)officer["spaceStationId"]));
            }
            return null;
        }
        catch
        {
            Error = "Error - Could not retrieve the existing officers.";
            return Page();
        }
    }
}
