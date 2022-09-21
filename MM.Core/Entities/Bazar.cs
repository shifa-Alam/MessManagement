using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MM.Core.Entities
{
    public class Bazar : BaseEntity
    {
        public long MemberId { get; set; }
        public decimal Amount { get; set; }
        public DateTime BazarDate { get; set; }
        public virtual  Member Member { get; set; }

    }
}
