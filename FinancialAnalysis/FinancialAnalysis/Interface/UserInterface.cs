
using FinancialAnalysis.Models;
using FinancialAnalysis.Services;
using System;
using System.Collections.Generic;

namespace FinancialAnalysis.Interface
{
    public static class UserInterface
    {
        public static void Start()
        {
            var company = GetCompanyData();
            var analysisService = new FinancialAnalysisService(company);

            bool continueRunning = true;

            while (continueRunning)
            {
                Console.WriteLine("elija una opción:");
                Console.WriteLine("1. ver análisis financiero");
                Console.WriteLine("2. agregar nuevo registro financiero");
                Console.WriteLine("3. salir");

                string userOption = Console.ReadLine();

                switch (userOption)
                {
                    case "1":
                        DisplayFinancialAnalysis(company, analysisService);
                        break;
                    case "2":
                        var newRecord = GetFinancialRecord();
                        company.Records.Add(newRecord);
                        break;
                    case "3":
                        continueRunning = false;
                        break;
                    default:
                        Console.WriteLine("Opción no válida, por favor intente de nuevo.");
                        break;
                }
            }
        }

        public static Company GetCompanyData()
        {
            var company = new Company
            {
                Records = new List<FinancialRecord>
                {
                    new FinancialRecord { Date = DateTime.Now.AddDays(-10), Concept = "Venta", Amount = 1000, IsRevenue = true },
                    new FinancialRecord { Date = DateTime.Now.AddDays(-5), Concept = "Gasto", Amount = 500, IsRevenue = false }
                }
            };

            return company;
        }

        public static FinancialRecord GetFinancialRecord()
        {
            Console.Write("Introduzca el concepto: ");
            string concept = Console.ReadLine();

            Console.Write("Introduzca la cantidad: ");
            decimal amount = decimal.Parse(Console.ReadLine());

            Console.Write("¿Este registro es un ingreso (s/n)? ");
            bool isRevenue = Console.ReadLine().ToLower() == "y";

            return new FinancialRecord { Date = DateTime.Now, Concept = concept, Amount = amount, IsRevenue = isRevenue };
        }

        public static void DisplayFinancialAnalysis(Company company, FinancialAnalysisService analysisService)
        {
            Console.WriteLine($"Ingresos Totales: {analysisService.CalculateTotalRevenues()}");
            Console.WriteLine($"Gastos Totales: {analysisService.CalculateTotalExpenses()}");
            Console.WriteLine($"Beneficio Neto: {analysisService.CalculateNetProfit()}");
            Console.WriteLine($"Margen de Beneficio Neto: {analysisService.CalculateNetProfitMargin()}%");
            Console.WriteLine($"Índice de Liquidez: {analysisService.CalculateCurrentRatio()}%");
        }
    }
}
