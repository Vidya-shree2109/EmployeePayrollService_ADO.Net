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
            Console.WriteLine("\nEnter\n1. To insert data into database\nSs2.Reteive Data\n3.Update Employee Details\n4.Delete Employee From database\n5.Exit\n");
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
                    List<EmployeeModel> employeeList = payrollService.GetAllEmployees();
                    foreach (EmployeeModel data in employeeList)
                    {
                        Console.WriteLine(data.Id + " " + data.Name + " " + data.Salary + " " + data.StartDate + " " + data.Gender + " " + data.Address + " " + data.Phone + " " + data.BasicPay + " " + data.Deduction + " " + data.TaxablePay + " " + data.IncomeTax + " " + data.NetPay);
                    }
                    break;
                case 3:
                    EmployeeModel model = new EmployeeModel();
                    model.Id = 106;
                    model.Salary = "25000";
                    model.Department = "Sales";
                    payrollService.UpdateEmployee(model);
                    break;
                case 4:
                    EmployeeModel emp = new EmployeeModel();
                    List<EmployeeModel> eList = payrollService.GetAllEmployees();
                    Console.WriteLine("\nEnter the Employee Id to Delete : ");
                    int employeeId = Convert.ToInt32(Console.ReadLine());
                    foreach (EmployeeModel data in eList)
                    {
                        if (data.Id == employeeId)
                        {
                            payrollService.DeleteEmployee(employeeId);
                            Console.WriteLine("\nEmployee Deleted Successfully !");
                        }
                        else
                        {
                            Console.WriteLine(employeeId + "is not in the database");
                        }
                    }
                    break;
                case 5:
                    verify = false;
                    break;
                default:
                    Console.WriteLine("Enter valid option !\n");
                    break;
            }
        }
    }
}