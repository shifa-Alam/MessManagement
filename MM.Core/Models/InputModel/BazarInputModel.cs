using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MM.Core.Models.InputModel
{
    public class BazarInputModel
    {

        public long MemberId { get; set; }
        public decimal Amount { get; set; }
        public DateTime BazarDate { get; set; }

        public long Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool Active { get; set; }
    }
}
