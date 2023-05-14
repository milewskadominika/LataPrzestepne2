using LataPrzestepne2.Data;
using LataPrzestepne2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Security.AccessControl;
using System.Security.Claims;

namespace LataPrzestepne2.Pages
{
    public class HistoryModel : PageModel
    {
        private readonly ILogger<IndexModel>? _logger;
        private readonly ApplicationDbContext? _context;
        private readonly IConfiguration? Configuration;

        public PaginatedList<History>? records { get; set; }
        public string? currentUser { get; set; }

        
        public HistoryModel(ILogger<IndexModel> logger, ApplicationDbContext context, IConfiguration configuration)
        {
            _logger = logger;
            _context = context;
            Configuration = configuration;
        }


        public async Task OnGetAsync(int? pageIndex)
        {
            currentUser = User.FindFirstValue(ClaimTypes.NameIdentifier);
            IQueryable<History> historyIQ = from s in _context.History
                                            select s;
            historyIQ = historyIQ.OrderByDescending(s => s.CreatedDate);
            var pageSize = Configuration.GetValue("PageSize", 4);
            records = await PaginatedList<History>.CreateAsync(
                historyIQ.AsNoTracking(), pageIndex ?? 1, pageSize);
        }




    }
}



