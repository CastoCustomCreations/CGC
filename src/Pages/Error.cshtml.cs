using System.Diagnostics;
using System.Net.NetworkInformation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using CGC.Models;

namespace CGC.Pages
{
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public class ErrorModel : PageModel
    {
        public string? RequestProduct_id { get; set; }

        public bool ShowRequestProduct_id => !string.IsNullOrEmpty(RequestProduct_id);

        private readonly ILogger<ErrorModel> _logger;

        public ErrorModel(ILogger<ErrorModel> logger) => _logger = logger;

        //public void OnGet() => RequestProduct_id = Activity.Current?.Product_id ?? HttpContext.TraceProduct_identifier;
    }
}
