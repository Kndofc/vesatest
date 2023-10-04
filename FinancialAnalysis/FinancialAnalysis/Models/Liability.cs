using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialAnalysis.Models
{
    public class Liability
    {
        public string Name { get; set; }
        public decimal Value { get; set; }
        public bool IsCurrent { get; set; }
    }
}
