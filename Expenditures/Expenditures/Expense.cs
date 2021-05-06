using System;
using System.Collections.Generic;
using System.Text;

namespace Expenditure
{
    abstract class Expense
    {
        protected double grossIncome = 0;
        protected double[] monthlyExpenditures;
        protected string[] expenditureCategory = { "Groceries", "Water and Lights", "Travel cost(including petrol)", "Cellphone and telephone", "Other expenses" };
        protected double totalMonthlyExpenditure = 0;
        protected string option;

        public abstract void Selection(string option);
        public abstract void Alert();

        //property for getting and setting the grossIncome
        public double GrossIncome
        {
            get { return grossIncome; }
            set { grossIncome = value; }
        }

        public string Option
        {
            get { return option; }
            set { option = value; }
        }

        // this method takes in the users expenditures
        public void InputExpenditures()
        {
            try
            {
                monthlyExpenditures = new double[expenditureCategory.Length];

                for (int i = 0; i < expenditureCategory.Length; i++)
                {
                    Console.WriteLine("Enter expenditure for " + expenditureCategory[i]);
                    monthlyExpenditures[i] = Convert.ToDouble(Console.ReadLine());
                    totalMonthlyExpenditure += monthlyExpenditures[i];
                }
            }
            catch (FormatException error)
            {
                Console.WriteLine(error.Message);
            }
        }
    }
}
