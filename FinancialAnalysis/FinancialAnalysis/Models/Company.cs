using System.Collections.Generic;

namespace FinancialAnalysis.Models
{
    public class Company
    {
        public string Name { get; set; }
        public List<FinancialRecord> Records { get; set; } = new List<FinancialRecord>();
    }
}
