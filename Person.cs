using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA230215
{
    internal class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public List<string> FavBooks { get; set; }
        public int NoChildren { get; set; }
        public string Workplace { get; set; }
        public bool Sex { get; set; }
        public bool IsMature
        {
            get
            {
                var today = DateTime.Today;
                var age = today.Year - BirthDate.Year;
                if (BirthDate.Date > today.AddYears(-age)) age--;
                return age >= 18;
            }
        }
    }
}
