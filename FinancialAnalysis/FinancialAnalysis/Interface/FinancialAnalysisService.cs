using FinancialAnalysis.Models;
using System;
using System.Linq;

namespace FinancialAnalysis.Services
{
    public class FinancialAnalysisService
    {
        private readonly Company _company;

        public FinancialAnalysisService(Company company)
        {
            _company = company;
        }

        public decimal CalculateTotalRevenues()
        {
            return CalculateTotalAmount(true);
        }

        public decimal CalculateTotalExpenses()
        {
            return CalculateTotalAmount(false);
        }

        public decimal CalculateNetProfit()
        {
            return CalculateTotalRevenues() - CalculateTotalExpenses();
        }

        public decimal CalculateNetProfitMargin()
        {
            decimal revenues = CalculateTotalRevenues();
            if (revenues == 0) return 0; 
            return (CalculateNetProfit() / revenues) * 100;
        }

        public decimal CalculateCurrentRatio()
        {
            var oneMonthAgo = DateTime.Now.AddMonths(-1);

            decimal currentAssets = _company.Records
                .Where(r => r.IsRevenue && r.Date > oneMonthAgo)
                .Sum(r => r.Amount);

            decimal currentLiabilities = _company.Records
                .Where(r => !r.IsRevenue && r.Date > oneMonthAgo)
                .Sum(r => r.Amount);

            if (currentLiabilities == 0)
            {
                throw new InvalidOperationException("No se puede calcular la razón de liquidez corriente cuando los pasivos corrientes son cero.");
            }

            return currentAssets / currentLiabilities;
        }

        private decimal CalculateTotalAmount(bool isRevenue)
        {
            decimal total = 0;

            foreach (var record in _company.Records)
            {
                if (record.IsRevenue == isRevenue)
                {
                    total += record.Amount;
                }
            }

            return total;
        }
    }
}
