using LataPrzestepne2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace LataPrzestepne2.Pages
{
    public class ZapisaneModel : PageModel
    {
        public List<Model> people { get; set; }

        public void OnGet()
        {
            var Data = HttpContext.Session.GetString("Data");
            if (Data != null)
                people =
                JsonConvert.DeserializeObject<List<Model>>(Data);

        }
    }
}
