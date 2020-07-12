using ContosoPets.Ui.Extensions;
using ContosoPets.Ui.Models;
using ContosoPets.Ui.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ContosoPets.Ui.Pages.OptionChains
{
    public class IndexModel : PageModel
    {
        private readonly OptionChainService _optionChainService;

        public string AntiforgeryToken => HttpContext.GetAntiforgeryTokenForJs();
        public OptionChain OptionChain { get; private set; } = new OptionChain();

        public IndexModel(OptionChainService optionChainService)
        {
            _optionChainService = optionChainService;
        }

        public async Task OnGet()
        {
            OptionChain = await _optionChainService.GetOptionChain("SKYW", "ALL");
        }
    }
}
