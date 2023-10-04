using System;

namespace FinancialAnalysis.Models
{
    public class FinancialRecord
    {
        public DateTime Date { get; set; }
        public string Concept { get; set; }
        public decimal Amount { get; set; }
        public bool IsRevenue { get; set; }
        public string Category { get; set; }
        public string TransactionType { get; set; }
    }
}
