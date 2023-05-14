using LataPrzestepne2.Data;
using Microsoft.AspNetCore.SignalR;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LataPrzestepne2.Models
{
    [Table("History")]
    public class History
	{
        
        private readonly ApplicationDbContext _context;

        
        public History(ApplicationDbContext context)
        {
            _context = context;
        }

        [Key]
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
		public bool IsLeap { get; set; }
		public string? UserId { get; set; }
		public string? UserLogin { get; set; }
        public int Year { get; set; }

        public string IsLeap_toString()
        {
            if (IsLeap)
            {
                return "tak";
            }
            else
            {
                return "nie";
            }
        }

    }
}
