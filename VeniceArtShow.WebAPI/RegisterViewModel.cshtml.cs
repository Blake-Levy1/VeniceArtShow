using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace VeniceArtShow.WebAPI
{
    public class RegisterViewModel : PageModel
    {
        private readonly ILogger<RegisterViewModel> _logger;

        public RegisterViewModel(ILogger<RegisterViewModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}