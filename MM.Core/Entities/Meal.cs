using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MM.Core.Entities
{
    public class Meal : BaseEntity
    {
        public long MemberId { get; set; }
        public double Quantity { get; set; }
        public DateTime MealDate { get; set; }
        public virtual  Member ?Member { get; set; }

    }
}
