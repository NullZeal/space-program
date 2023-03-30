using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Security.Cryptography;
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
                    HashPassword();
                    
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

        private void HashPassword()
        {
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);
            var pbkdf2 = new Rfc2898DeriveBytes(CurrentUser.Password, salt, 100000);
            byte[] hash = pbkdf2.GetBytes(20);
            byte[] hashBytes = new byte[36];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);
            CurrentUser.Password = Convert.ToBase64String(hashBytes);
        }
    }
}
