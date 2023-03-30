using Microsoft.AspNetCore.Mvc;
using WebApp.Business.ParentPageModels;

namespace WebApp.Pages;

public class IndexModel : LoginValidationModel
{
    private readonly ILogger<IndexModel> _logger;

    public string Error { get; set; }

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public override async Task<IActionResult> OnGet(Guid id)
    {
        return await base.OnGet(id);
    }
}