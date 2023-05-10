using LataPrzestepne2.Data;
using LataPrzestepne2.Forms;
using LataPrzestepne2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Security.Claims;
using System.Security.Principal;

namespace LataPrzestepne2.Pages
{
    public class IndexModel : PageModel
    {
 
        private readonly ILogger<IndexModel> _logger;
        private readonly ApplicationDbContext _context;

        [BindProperty]
        public YearForm Form { set; get; }

        public List<Model> people = new();

        public string Result = "";


        public IndexModel(ILogger<IndexModel> logger,ApplicationDbContext contex)
        {
            _logger = logger;
            _context = contex;
        }


        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            else
            {
                bool prz = czyPrzestepny();
                Result = Verbose(prz);
                var Data = HttpContext.Session.GetString("Data");
                if (Data != null)
                    people =
                    JsonConvert.DeserializeObject<List<Model>>(Data);
                people.Add(recordCreation(prz));
                HttpContext.Session.SetString("Data",
                JsonConvert.SerializeObject(people));

                _context.History.Add(recordCreation());

                return Page();
            }
        }

        public Model recordCreation(bool p)
        {
            Model record = new Model()
            {
                Name = Form.Name ?? "",
                Year = Form.Year,
                Przestepny = p
            };

            return record;

        }

        public History recordCreation()
        {
            History record = new History(_context)
            {
                CreatedDate = DateTime.Now,
                UserId = "1",
                UserLogin = "Dupa",
                Year = Form.Year,
                //UserId = User.FindFirst(ClaimTypes.NameIdentifier).Value,
                //UserLogin = User.FindFirst(ClaimTypes.Name).Value
            };
            Console.WriteLine(record.ToString());
            return record;
        }
        

        public bool czyPrzestepny()
        {
            //1 gdy przestepny, 0 gdy nie
            return ((Form.Year % 4 == 0 && Form.Year % 100 != 0) || Form.Year % 400 == 0);
        }


        public String Verbose(bool p)
        {
            if(Form.Name!= null)
            {
                Result += Form.Name;
                Result += " urodził się w ";
                Result += Form.Year;
                Result += " roku. To";
            }
            else
            {
                Result += Form.Year;
                Result += " to";
            }
            

            if (p)
            {
                Result += " był rok przestępny.";
            }
            else
            {
                Result += " nie był rok przestępny.";
            }

            
            return Result;
        }

    }

}
