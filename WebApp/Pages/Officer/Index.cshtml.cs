using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json.Linq;
using SpaceProgram.WebApp.DtoModels;

namespace SpaceProgramWeb.Pages.OfficerPages
{
    public class IndexModel : PageModel
    {
        public List<OfficerDto> Officers = new List<OfficerDto>();

        private readonly HttpClient _httpClient;

        public IndexModel(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IActionResult> OnGet()
        {
            HttpClient httpClient = _httpClient;
            List<OfficerDto> officersRetrived = await httpClient.GetFromJsonAsync<List<OfficerDto>>("https://localhost:7202/api/Officers");
            Officers = officersRetrived;
            return Page();
        }
    }
}
