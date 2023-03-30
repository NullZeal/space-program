using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp.Business.Extensions;

namespace WebApp.Business.ParentPageModels;

public abstract class LoginValidationModel : PageModel
{
    public virtual async Task<IActionResult> OnGet(Guid id)
    {
        return this.ValidateConnectedUser();
    }
}