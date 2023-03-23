using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text;
using Newtonsoft.Json.Linq;
using SpaceProgramWeb.Models;

namespace SpaceProgramWeb.Pages
{
    public class CreateModel : PageModel
    {

        [BindProperty]
        public Models.Officer Officer { get; set; }

        private readonly HttpClient _httpClient;
        public string Error { get; set; }

        public CreateModel(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public List<SpaceStation> StationsList { get; set; }

        public async Task<IActionResult> OnGet()
        {
            HttpClient httpClient = _httpClient;
            List<SpaceStation> stations = await httpClient.GetFromJsonAsync<List<SpaceStation>>("https://localhost:7202/api/SpaceStations");
            StationsList = stations.ToList();
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {

            HttpClient httpClient = _httpClient;
            List<SpaceStation> stations = await httpClient.GetFromJsonAsync<List<SpaceStation>>("https://localhost:7202/api/SpaceStations");
            StationsList = stations.ToList();

            if (ModelState.IsValid)
            {
                using StringContent jsonContent = new StringContent(

                    System.Text.Json.JsonSerializer.Serialize(Officer),
                    Encoding.UTF8,
                    "application/json"

                );

                var response = await _httpClient.PostAsync("https://localhost:7202/api/Officers/", jsonContent);
                var values = await response.Content.ReadAsStringAsync();
                var obj = JObject.Parse(values);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToPage("/Index");
                }
                else
                {
                    Error = obj["detail"].ToString();
                }
            }
            return Page();
        }
    }
}
