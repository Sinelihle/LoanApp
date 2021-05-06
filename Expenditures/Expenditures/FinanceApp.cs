using System;

namespace Expenditure
{
    class FinanceApp
    {
        static void Main()
        {
            //declaring variables to take in income and tax
            double grossIncome = 0;
            double monthlyTax = 0;

            //calling method to print the banner
            PrintBanner();

            Console.WriteLine("Enter your Gross monthly income(before deductions): ");
            grossIncome = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Enter your estimated monthly tax deducted: ");
            monthlyTax = Convert.ToDouble(Console.ReadLine());

            while(monthlyTax >= grossIncome)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error monthly tax cannot be equal or more than gross income");
                Console.ResetColor();
                Console.WriteLine("Enter your estimated monthly tax deducted: ");
                monthlyTax = Convert.ToDouble(Console.ReadLine());
            }

            //creating an instance of the homeloan class
            HomeLoan home = new HomeLoan(grossIncome, monthlyTax);

            home.InputExpenditures();
            home.CheckExpenses();

            Console.WriteLine("Enter A or B for your accomadation type:" + "\n" + "A) Rent" + "\n"
                              + "B) Purchase Property");
            home.Option = Console.ReadLine();

            home.Selection(home.Option);

            //printing out final report
            Console.WriteLine();
            Console.WriteLine("***************************************************");
            Console.WriteLine("Gross Income: " + home.GrossIncome);
            Console.WriteLine("Monthly Tax: " + home.Tax);
            Console.WriteLine("Total Monthly Expenditure(no accomodation included): " + home.GetExpenditureTotal());
            Console.WriteLine("Available Monthly Money(after tax and monthly expenditure(accomodation not included) is deducted): " + (home.GrossIncome - home.GetExpenditureTotal() - home.Tax));
      
            Console.WriteLine("Total Loan Repayment: " + home.CalculateLoan());
            Console.WriteLine("Monthly Loan Repayment: " + home.GetMonthlyLoanRepayment());
            home.SetExpenditureTotal(home.Option);
            Console.WriteLine("Total Monthly Expenditure(after the accomodation included): " + home.GetExpenditureTotal());
            Console.WriteLine("Available Monthly money after expenditures(including monthly loan repayment) and tax are deducted: " + (home.GrossIncome - home.GetExpenditureTotal() - home.Tax));
            home.Alert();
        }

        //method to print application banner
        public static void PrintBanner()
        {
            for (int i = 0; i < 50; i++)
            {
                Console.Write("*");
            }
            Console.WriteLine();  
            
            Console.WriteLine("                Homeloan Application");

            for (int i = 0; i < 50; i++)
            {
                Console.Write("*");
            }
            Console.WriteLine();
        }
    }
}
