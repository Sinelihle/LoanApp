using System;
using System.Collections.Generic;
using System.Text;

namespace Expenditure
{
    class HomeLoan: Expense
    {
        double monthlyTax = 0;
        double rentAmount = 0;
        double purchasePrice = 0;
        double totalDeposit = 0;
        double interestRate = 0;
        int numOfMonths = 0;
        double monthlyRepayment = 0;
       
       
        //HomeLoan class constructor
        public  HomeLoan(double grossIncome, double monthlyTax)
        {
            this.grossIncome = grossIncome;
            this.monthlyTax = monthlyTax;
        }

        public double Tax
        {
            get { return monthlyTax; }
            set { monthlyTax = value; }
        }

        //method to check if the expense is greater than the income
        public void CheckExpenses() { 
            
            for(int j=  0; j < expenditureCategory.Length; j++)
            {
                while (monthlyExpenditures[j] >= GrossIncome)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error: " + expenditureCategory[j]+ " cannot be greater Gross Income");
                    Console.ResetColor();

                    Console.WriteLine("Enter your estimated " +expenditureCategory[j] + " deducted: ");
                    monthlyExpenditures[j] = Convert.ToDouble(Console.ReadLine());
                }
            }
        }

       //method adds the total expenditure and the accomodation amount
        public void SetExpenditureTotal(string option)
        {
            if (option.ToUpper().Equals("A"))
            {
                totalMonthlyExpenditure += rentAmount;
            }
            else if (option.ToUpper().Equals("B"))
            {
                totalMonthlyExpenditure += monthlyRepayment;
            }
        }

        //method that returns the total monthly expenditure
        public double GetExpenditureTotal()
        {
            return totalMonthlyExpenditure;
        }

        //this the method that queries user according to their option
        public override void Selection(string option)
        {
            if (option.ToUpper().Equals("A"))
            {
                Console.WriteLine("Enter monthly rental amount");
                rentAmount = Convert.ToDouble(Console.ReadLine());
            }
            else if (option.ToUpper().Equals("B"))
            {
                Console.WriteLine("Enter property purchase price: ");
                purchasePrice = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("Enter total deposit: ");
                totalDeposit = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("Enter interst rate: ");
                interestRate = Convert.ToDouble(Console.ReadLine());
                while (interestRate > 100)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        Console.Beep();
                    }
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error: Please make  sure that the entered interest rate is less than 100");
                    Console.ResetColor();
                    try
                    {
                        Console.WriteLine("Enter interst rate: ");
                        interestRate = Convert.ToDouble(Console.ReadLine());
                    }
                    catch (FormatException exc)
                    {
                        Console.WriteLine(exc.Message);
                    }

                }
                Console.WriteLine("Enter number of months: ");
                numOfMonths = Convert.ToInt32(Console.ReadLine());

                while (numOfMonths < 240 || numOfMonths > 360)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        Console.Beep();
                    }
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error: The value should be between 240 and 360 months");
                    Console.ResetColor();
                    Console.WriteLine("Enter number of months: ");
                    numOfMonths = Convert.ToInt32(Console.ReadLine());
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error: please select A or B");
                Console.ResetColor();
            }

        }
       
        //this method determines if the user can or cannot be approved for a loan
        public override void Alert()
        {
            if (GetMonthlyLoanRepayment() > grossIncome / 3)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Approval of your loan is very unlikely");
                Console.ResetColor();
            }
            else if(GetMonthlyLoanRepayment() < grossIncome / 3)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Loan approval is pending");
                Console.ResetColor();
            }
        }

       //this method calculates the loan 
        public double CalculateLoan()
        {
            double loan = (purchasePrice - totalDeposit)*(1 + (interestRate / 100) * (numOfMonths / 12));
            return loan;
        }

        //method for calculating the loan monthly repayment
        public double GetMonthlyLoanRepayment()
        {
            double totalLoan = CalculateLoan();
            monthlyRepayment = totalLoan / numOfMonths;
            return monthlyRepayment;
        }
    }
      
}

