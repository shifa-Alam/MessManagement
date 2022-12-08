using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MM.Core.Models.FilterModel
{
    public class MealFilter : BaseFilter
    {
        public string MemberName { get; set; } = "shifa";
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
