using System;
using System.Collections.Generic;

namespace CoffeeShop
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Customer> customers = new List<Customer>();
            char choice;

            do
            {
                Customer customer = new Customer();

                // Input Customer Name
                customer.SetName();

                // Input Number Of Coffee Bags
                customer.SetNumBags();

                // Input If The Customer Is A Reseller
                customer.SetIsReseller();

                // Compute Bill and Print
                customer.ComputeBill();
                customer.PrintBill();

                // Add customer to list
                customers.Add(customer);

                // Input User Choice
                Console.Write("Input Y/y To Continue Or Any Other Key To Exit: ");

                // Get First Letter Of Choice
                choice = Console.ReadLine().ToLower()[0];
                Console.WriteLine();

            } while (choice == 'y');

            // Print All Bills
            foreach (Customer customer in customers)
            {
                customer.PrintBill();
            }
        }
    }

    class Customer
    {
        string name;
        int numBags;
        bool isReseller;

        public void SetName()
        {
            Console.Write("Enter Customer Name: ");
            name = Console.ReadLine();
        }

        public void SetNumBags()
        {
            Console.Write("Enter Number Of Coffee Bags (1-200): ");
            numBags = Int32.Parse(Console.ReadLine());

            while (numBags < 1 || numBags > 200)
            {
                Console.WriteLine("Value Must Be Between 1 And 200!");
                Console.Write("Re-Enter Number Of Coffee Bags (1-200): ");
                numBags = Int32.Parse(Console.ReadLine());
            }
        }

        public void SetIsReseller()
        {
            Console.Write("Is Customer A Reseller? (y/Y For Yes): ");
            char choice = Console.ReadLine().ToLower()[0];
            isReseller = choice == 'y';
        }

        public double ComputeBill()
        {
            double totalCost = 0.0;

            if (numBags < 6)
            {
                totalCost += numBags * 36;
            }
            else if (numBags < 16)
            {
                totalCost += numBags * 34.5;
            }
            else
            {
                totalCost += numBags * 32.7;
            }

            if (isReseller)
            {
                totalCost *= 0.8;
            }

            return totalCost;
        }

        public void PrintBill()
        {
            Console.WriteLine();
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("------------------- BILL -------------------");
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("Customer Name: {0}", name);
            Console.WriteLine("Number Of Coffee Bags: {0}", numBags);
            Console.WriteLine("Total Cost Of Bags: {0:C}", ComputeBill());
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("Amount Payable: {0:C}", ComputeBill());
            Console.WriteLine("--------------------------------------------");
        }
    }
}
