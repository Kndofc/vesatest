
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
                Console.WriteLine("Elija una opción:");
                Console.WriteLine("1. Ver análisis financiero");
                Console.WriteLine("2. Añadir nuevo registro financiero");
                Console.WriteLine("3. Añadir nuevo activo");
                Console.WriteLine("4. Añadir nuevo pasivo");
                Console.WriteLine("5. Ver balance general");
                Console.WriteLine("6. Salir");

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
                        var newAsset = GetAssetData();
                        company.Assets.Add(newAsset);
                        break;
                    case "4":
                        var newLiability = GetLiabilityData();
                        company.Liabilities.Add(newLiability);
                        break;
                    case "5":
                        DisplayBalanceSheet(company, analysisService);
                        break;
                    case "6":
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

        public static Asset GetAssetData()
        {
            Console.Write("Ingrese el nombre del activo: ");
            string name = Console.ReadLine();

            Console.Write("Ingrese el valor del activo: ");
            decimal value = decimal.Parse(Console.ReadLine());

            Console.Write("¿Es este activo corriente (s/n)? ");
            bool isCurrent = Console.ReadLine().ToLower() == "s";

            return new Asset { Name = name, Value = value, IsCurrent = isCurrent };
        }

        public static Liability GetLiabilityData()
        {
            Console.Write("Ingrese el nombre del pasivo: ");
            string name = Console.ReadLine();

            Console.Write("Ingrese el valor del pasivo: ");
            decimal value = decimal.Parse(Console.ReadLine());

            Console.Write("¿Es este pasivo corriente (s/n)? ");
            bool isCurrent = Console.ReadLine().ToLower() == "s";

            return new Liability { Name = name, Value = value, IsCurrent = isCurrent };
        }


        public static void DisplayFinancialAnalysis(Company company, FinancialAnalysisService analysisService)
        {
            Console.WriteLine("ANÁLISE FINANCEIRA");
            Console.WriteLine("---------------------");
            Console.Write("Ingrese la fecha de inicio (yyyy-MM-dd): ");
            DateTime startDate = DateTime.Parse(Console.ReadLine());

            Console.Write("Ingrese la fecha final (yyyy-MM-dd): ");
            DateTime endDate = DateTime.Parse(Console.ReadLine());

            Console.WriteLine($"Ingresos Totales: {analysisService.CalculateTotalRevenues()}");
            Console.WriteLine($"Gastos Totales: {analysisService.CalculateTotalExpenses()}");
            Console.WriteLine($"Beneficio Neto: {analysisService.CalculateNetProfit()}");
            Console.WriteLine($"Margen de Beneficio Neto: {analysisService.CalculateNetProfitMargin()}%");
            Console.WriteLine($"Índice de Liquidez: {analysisService.CalculateCurrentRatio()}%");
            Console.WriteLine("---------------------");
        }

        public static void DisplayBalanceSheet(Company company, FinancialAnalysisService analysisService)
        {
            Console.WriteLine($"Total de Activos: {analysisService.CalculateTotalAssets()}");
            Console.WriteLine($"Activos Corrientes: {analysisService.CalculateCurrentAssets()}");
            Console.WriteLine($"Pasivos Corrientes: {analysisService.CalculateCurrentLiabilities()}");
            Console.WriteLine($"Total de Pasivos: {analysisService.CalculateTotalLiabilities()}");
            Console.WriteLine("BALANÇO PATRIMONIAL");
            Console.WriteLine("---------------------");
            Console.WriteLine($"Total de Activos: {analysisService.CalculateTotalAssets()}");
            Console.WriteLine($"- Activos Corrientes: {analysisService.CalculateCurrentAssets()}");
            Console.WriteLine($"Total de Pasivos: {analysisService.CalculateTotalLiabilities()}");
            Console.WriteLine($"- Pasivos Corrientes: {analysisService.CalculateCurrentLiabilities()}");
            Console.WriteLine("---------------------");
        }
    }
}
