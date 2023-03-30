using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Text;
using WebApp.Business.DtoModels;

namespace WebApp.Pages.User;

public class LoginModel : PageModel
{
    private readonly HttpClient _httpClient;

    [BindProperty]
    public UserDto User { get; set; }
    public string Error { get; set; }

    public LoginModel(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IActionResult> OnPost()
    {
        if (ModelState.IsValid)
        {
            try
            {
                string currentUserString = JsonConvert.SerializeObject(User, Formatting.None);
                HttpContent userContent = new StringContent(currentUserString, Encoding.UTF8, "application/json");

                var httpPostResponse = await _httpClient.PostAsync("https://localhost:7202/api/user/username", userContent);
                httpPostResponse.EnsureSuccessStatusCode();

                string userId = httpPostResponse.Content.ReadAsStringAsync().Result;

                Response.Cookies.Append("currentUser", userId);
                Response.Cookies.Append("currentUserUsername", User.Username);

                return RedirectToPage("/index");
            }
            catch
            {
                Error = "Invalid credentials. Please review username and password information.";
            }
        }
        return Page();
    }
}