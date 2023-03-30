using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Text;
using WebApp.Business.DtoModels;

namespace WebApp.Pages.User
{
    public class SignupModel : PageModel
    {
        private readonly HttpClient _httpClient;

        public SignupModel(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [BindProperty]
        public UserDto CurrentUser { get; set; }

        public string Error { get; set; }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                try
                {
                    string currentUserString = JsonConvert.SerializeObject(CurrentUser, Formatting.None);
                    HttpContent userContent = new StringContent(currentUserString, Encoding.UTF8, "application/json");

                    var httpPostResponse = await _httpClient.PostAsync("https://localhost:7202/api/user", userContent);
                    httpPostResponse.EnsureSuccessStatusCode();

                    return RedirectToPage("/user/login");
                }
                catch
                {
                    Error = "An error occured while creating your user.";
                }
            }
            return Page();
        }
    }
}
