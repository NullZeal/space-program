using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Business.Extensions;

public static class LoginValidationExtension
{
    public static IActionResult ValidateConnectedUser(this PageModel someModel)
    {
        if (someModel.Request.Cookies["currentUser"] == null || someModel.Request.Cookies["currentUser"] == "")
        {
            return someModel.RedirectToPage("/login");
        }
        return null;
    }
}