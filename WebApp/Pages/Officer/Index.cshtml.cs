using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json.Linq;
using SpaceProgram.WebApp.DtoModels;

namespace SpaceProgramWeb.Pages.OfficerPages
{
    public class IndexModel : PageModel
    {
        public List<OfficerDto> OfficerList = new List<OfficerDto>();
        public string Error { get; set; }
        private readonly HttpClient _httpClient;
        
        public IndexModel(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task OnGet()
        {
            await loadOfficerList();
        }

        private async Task loadOfficerList()
        {
            var httpGetResponse = await _httpClient.GetAsync("https://localhost:7202/api/officer");
            httpGetResponse.EnsureSuccessStatusCode();

            var responseString = await httpGetResponse.Content.ReadAsStringAsync();
            var jsonObject = JObject.Parse(responseString);

            foreach (var officer in jsonObject["fetchedOfficers"])
            {
                OfficerList.Add(new OfficerDto((Guid)officer["officerId"], officer["name"].ToString(), officer["rank"].ToString(), (Guid)officer["spaceStationId"]));
            }
        }
    }
}
