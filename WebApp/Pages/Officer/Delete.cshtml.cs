using Microsoft.AspNetCore.Mvc;
using WebApp.Business.DtoModels;
using WebApp.Business.Extensions;
using WebApp.Business.ParentPageModels;

namespace WebApp.Pages.Officer
{
    public class DeleteModel : LoginValidationModel
    {
        private readonly HttpClient _httpClient;

        [BindProperty]
        public OfficerDto Officer { get; set; } = new OfficerDto();
        public string Error { get; set; }

        public DeleteModel(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public override async Task<IActionResult> OnGet(Guid id)
        {
            var validate = await base.OnGet(id);
            if (validate != null) { return validate; }

            return await this.LoadOfficer(_httpClient, id, Officer, Error);
        }

        public async Task<IActionResult> OnPost(Guid id)
        {
            var validate = await this.LoadOfficer(_httpClient, id, Officer, Error);
            if (validate != null) { return validate; }

            try
            {
                var httpPostResponse = await _httpClient.DeleteAsync($"https://localhost:7202/api/officer/{id}");
                httpPostResponse.EnsureSuccessStatusCode();

                return RedirectToPage("/officer/index");
            }
            catch (Exception ex)
            {
                Error = ex.Message;
            }

            return Page();
        }
    }
}