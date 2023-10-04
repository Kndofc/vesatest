using FinancialAnalysis.Models;
using FinancialAnalysis.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace FinancialAnalysis.Tests
{
    public class FinancialAnalysisTests
    {
        [Fact]
        public void CalculateNetProfit_ShouldReturnCorrectValue()
        {
            // Arrange
            var company = new Company
            {
                Records = new List<FinancialRecord>
                {
                    new FinancialRecord { Amount = 1000, IsRevenue = true },
                    new FinancialRecord { Amount = 500, IsRevenue = false }
                }
            };
            var service = new FinancialAnalysisService(company);

            // Act
            var netProfit = service.CalculateNetProfit();

            // Assert
            Assert.Equal(500, netProfit);
        }

        [Fact]
        public void CalculateNetProfitMargin_ShouldReturnCorrectValue()
        {
            // Arrange
            var company = new Company
            {
                Records = new List<FinancialRecord>
                {
                    new FinancialRecord { Amount = 1000, IsRevenue = true },
                    new FinancialRecord { Amount = 500, IsRevenue = false }
                }
            };
            var service = new FinancialAnalysisService(company);

            // Act
            var netProfitMargin = service.CalculateNetProfitMargin();

            // Assert
            Assert.Equal(50, netProfitMargin);
        }
    }
}
