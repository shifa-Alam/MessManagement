using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MM.Core.Entities
{
    public class Fund : BaseEntity
    {
        public long MemberId { get; set; }
        public string Purpose { get; set; }
        public double Amount { get; set; }
        public bool IsDeduction { get; set; }
        public DateTime FundDate { get; set; }
        public virtual Member Member { get; set; }

    }
}
