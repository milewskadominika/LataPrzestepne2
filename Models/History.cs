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

        public override string ToString()
        {
            string Result = "";
            Result += CreatedDate;
            Result += ", ";
            Result += UserId ?? "";
            Result += ", ";
            Result += UserLogin ?? "";
            Result += ", ";
            Result += Year;
            Result += " - ";
            if (IsLeap == true)
            {
                Result += "przestępny";
            }
            else
            {
                Result += "rok nieprzestępny";
            }
            return Result;
        }
    }
}
