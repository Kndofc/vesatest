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

        private decimal CalculateTotalAmount(bool isRevenue)
        {
            return _company.Records.Where(r => r.IsRevenue == isRevenue).Sum(r => r.Amount);
        }

        public decimal CalculateTotal(FinancialType type)
        {
            return _company.Records.Where(r => r.Type == type).Sum(r => r.Amount);
        }

        public decimal CalculateNetProfit()
        {
            return CalculateTotalRevenues() - CalculateTotalExpenses();
        }

        public decimal CalculateNetProfitMargin()
        {
            decimal revenues = CalculateTotalRevenues();
            if (revenues == 0) return 0; // Evitar divisão por zero
            return (CalculateNetProfit() / revenues) * 100;
        }

        public decimal CalculateTotalAssets()
        {
            return _company.Assets.Sum(a => a.Value);
        }

        public decimal CalculateTotalLiabilities()
        {
            return _company.Liabilities.Sum(l => l.Value);
        }

        public decimal CalculateCurrentAssets()
        {
            return _company.Assets.Where(a => a.IsCurrent).Sum(a => a.Value);
        }

        public decimal CalculateCurrentLiabilities()
        {
            return _company.Liabilities.Where(l => l.IsCurrent).Sum(l => l.Value);
        }

        public decimal CalculateCurrentRatio()
        {
            decimal currentAssets = CalculateCurrentAssets();
            decimal currentLiabilities = CalculateCurrentLiabilities();

            if (currentLiabilities == 0)
            {
                throw new InvalidOperationException("No se puede calcular el índice de liquidez cuando los pasivos corrientes son cero.");
            }

            return currentAssets / currentLiabilities;
        }

    }
}
