using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace KOI_XS.Presentation.Views.Detail
{
    public class detail : PageModel
    {
        private readonly ILogger<detail> _logger;

        public detail(ILogger<detail> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}