using LataPrzestepne2.Data;

namespace LataPrzestepne2.Models
{
    public class Model
    {
        
        public int? Year { get; set; }
        public string? Name { get; set; }
        public bool? Przestepny { get; set; }


        public override string ToString()
        {
            string Result = "";
            Result += Name;
            Result += ", ";
            Result += Year;
            Result += " - ";
            if (Przestepny == true)
            {
                Result += "rok przestępny";
            }
            else
            {
                Result += "rok nieprzestępny";
            }
            return Result;
        }
    }
}

