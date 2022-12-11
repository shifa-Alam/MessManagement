using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MM.Core.Models.FilterModel
{
    public class MemberFilter : BaseFilter
    {
        public string MemberName { get; set; } = "";
        public string MobileNumber { get; set; } = "";
    }
}
