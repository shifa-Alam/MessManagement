using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MM.Core.Models.InputModel
{
    public class FundInputModel
    {

        public long MemberId { get; set; }
        public string Purpose { get; set; }
        public double Amount { get; set; }
        public bool IsDeduction { get; set; }
        public DateTime FundDate { get; set; }

        public long Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool Active { get; set; }
    }
}
