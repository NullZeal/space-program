using Microsoft.AspNetCore.Mvc;
using WebApp.Business.DtoModels;
using WebApp.Business.Extensions;
using WebApp.Business.ParentPageModels;

namespace WebApp.Pages.SpaceStation
{
    public class DeleteModel : LoginValidationModel
    {
        private readonly HttpClient _httpClient;

        [BindProperty]
        public SpaceStationDto SpaceStation { get; set; } = new SpaceStationDto();
        public string Error { get; set; }

        public DeleteModel(HttpClient httpClient)
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
            var validate = await this.LoadSpaceStation(_httpClient, id, SpaceStation, Error);
            if (validate != null) { return validate; }

            try
            {
                var httpPostResponse = await _httpClient.DeleteAsync($"https://localhost:7202/api/spacestation/{id}");
                httpPostResponse.EnsureSuccessStatusCode();

                return RedirectToPage("/spacestation/index");
            }
            catch (Exception ex)
            {
                Error = ex.Message;
            }

            return Page();
        }
    }
}