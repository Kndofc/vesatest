using System;

namespace FinancialAnalysis.Models
{
    public enum FinancialType
    {
        CurrentAsset,
        FixedAsset,
        CurrentLiability,
        LongTermLiability,
        Revenue,
        Expense
    }
    public class FinancialRecord
    {
        public DateTime Date { get; set; }
        public string Concept { get; set; }
        public decimal Amount { get; set; }
        public FinancialType Type { get; set; }
        public bool IsRevenue { get; set; }
        public string Category { get; set; }
        public string TransactionType { get; set; }
    }
}
