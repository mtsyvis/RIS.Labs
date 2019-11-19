using System;
using System.Linq;
using Accounting.Service.Infrastructure;
using Accounting.Service.Interfaces;

namespace Lab1.UI
{
    public class AccountingUI
    {
        private const int BoarderLength = 120;

        private IProductGenericRepository<FuelRow> _repository = new ProductXmlFileGenericRepository<FuelRow>();

        public void RunService()
        {
            string choise = "";
            while (choise != "0")
            {
                string productId;
                FuelRow row;
                PrintMenu();
                choise = Console.ReadLine();

                switch (choise)
                {
                    case "1":
                        var productRow = CreateRow();
                        _repository.Add(productRow);
                        continue;
                    case "2":
                        _repository.GetAll().ToList().ForEach(PrintRow);
                        continue;
                    case "3":
                        Console.Write("Enter row id to delete: ");
                        productId = Console.ReadLine();
                        row = _repository.GetProduct(p => p.Id == productId);
                        if (row is null)
                        {
                            Console.WriteLine("Wrong id");
                            continue;
                        }

                        _repository.Delete(row);
                        continue;
                    case "4":
                        Console.Write("Enter row id to update: ");
                        productId = Console.ReadLine();
                        row = _repository.GetProduct(p => p.Id == productId);
                        if (row is null)
                        {
                            Console.WriteLine("Wrong id");
                            continue;
                        }

                        UpdateProduct(row);
                        _repository.Save();
                        continue;

                    case "5":
                        _repository.GetAll().OrderBy(p => p.Amount).ToList().ForEach(PrintRow);
                        continue;

                    case "6":
                        try
                        {
                            Console.Write("Enter start amount: ");
                            var startAmount = double.Parse(Console.ReadLine());
                            Console.Write("Enter end amount: ");
                            var endAmount = double.Parse(Console.ReadLine());
                            if(startAmount> endAmount || startAmount < 0 || endAmount < 0)
                            {
                                Console.WriteLine("Wrong input");
                                continue;
                            }

                            _repository.GetAll().Where(p => p.Amount >= startAmount && p.Amount <= endAmount)
                                .OrderBy(p => p.Amount).ToList().ForEach(PrintRow);
                        }
                        catch(FormatException)
                        {
                            Console.WriteLine("Wrong input");
                        }
                        continue;
                    case "0":
                        continue;
                    default:
                        Console.WriteLine("Unknown command. Repeate please.");
                        continue;
                }
            }
        }

        private void PrintMenu()
        {
            Console.WriteLine("1. Add fuel supply row;");
            Console.WriteLine("2. Get all fuel supply row;");
            Console.WriteLine("3. Delete row by id;");
            Console.WriteLine("4. Update row by id;");
            Console.WriteLine("5. Sort fuel row by fuel amount;");
            Console.WriteLine("6. Find fuel rows by entered amount;");
            Console.WriteLine("0. Exit.");
        }

        private FuelRow CreateRow()
        {
            var row = new FuelRow();

            Console.WriteLine("Enter Id: ");
            row.Id = Console.ReadLine();

            Console.WriteLine("Enter fuel type: ");
            row.FuelType = Console.ReadLine();

            Console.WriteLine("Enter fuel amount: ");
            double.TryParse(Console.ReadLine(), out double fuelAmount);
            row.Amount = fuelAmount;

            row.DateOfDelivery = DateTime.Now;

            return row;
        }

        private void PrintRow(FuelRow row)
        {
            Console.WriteLine($"Id: {row.Id, -5} Fuel Type: {row.FuelType, -10} Fuel Amount: {row.Amount, -6} Date of delivery: {row.DateOfDelivery, -10}");
            var boarder = new string('-', BoarderLength);
            Console.WriteLine(boarder);
        }

        private void UpdateProduct(FuelRow row)
        {
            Console.WriteLine("Enter fuel type: ");
            row.FuelType = Console.ReadLine();

            Console.WriteLine("Enter fuel amount: ");
            double.TryParse(Console.ReadLine(), out double fuelAmount);
            row.Amount = fuelAmount;

            row.DateOfDelivery = DateTime.Now;
        }
    }
}
