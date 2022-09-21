using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MM.Core.Entities
{
    public class Member : BaseEntity
    {
        public Member()
        {
            Meals = new List<Meal> ();
        }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string MobileNumber { get; set; } = string.Empty;
        public string EmergencyContact { get; set; } = string.Empty;
        public string HomeDistrict { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public List<Meal> Meals { get; set; }
    }
}
