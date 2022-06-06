using System;
using EmployeePayroll_ADO.Net;
public class Program
{
    public static void Main(String[] args)
    {
        Console.WriteLine("\t\t\t\t\tWELCOME TO EMPLOYEE PAROLL SERVICE PROGRAM !\t\t\t\t\t\n");
        EmployeeRepo payrollService = new EmployeeRepo();
        bool verify = true;


        while (verify)
        {
            Console.WriteLine("\nEnter\n1. To insert data into database\n2.Exit\n");
            int option = Convert.ToInt32(Console.ReadLine());
            switch (option)
            {
                case 1:
                    EmployeeModel employeeModel = new EmployeeModel();
                    employeeModel.Id = 101;
                    employeeModel.Name = "Vidya";
                    employeeModel.Salary = "10000";
                    employeeModel.StartDate = DateTime.Now;
                    employeeModel.Gender = 'F';
                    employeeModel.Phone = "9087655432";
                    employeeModel.Address = "Bangalore";
                    employeeModel.Department = "Testing";
                    employeeModel.BasicPay = 500;
                    employeeModel.Deduction = 100;
                    employeeModel.TaxablePay = 200;
                    employeeModel.IncomeTax = 100;
                    employeeModel.NetPay = 900;
                    payrollService.AddEmployee(employeeModel);
                    break;
                case 2:
                    verify = false;
                    break;
                default:
                    Console.WriteLine("Enter valid option !\n");
                    break;
            }
        }
    }
}