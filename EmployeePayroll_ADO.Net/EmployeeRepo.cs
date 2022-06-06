using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayroll_ADO.Net
{
    public class EmployeeRepo
    {
        public static string connectionString = @"Data Source=(localdb)\\MSSQLLocaldb;Initial Catalog=Payroll_Service";
        SqlConnection connection = new SqlConnection(connectionString);
        public void GetAllEmployee()
        {
            try
            {
                EmployeeModel employeeModel = new EmployeeModel();
                using (this.connection)
                {
                    string query = @"Select * from employee_payroll;";
                    SqlCommand cmd = new SqlCommand(query, this.connection);
                    this.connection.Open();
                    SqlDataReader dataReader = cmd.ExecuteReader();
                    if (dataReader.HasRows)
                    {
                        while (dataReader.Read())
                        {
                            employeeModel.Id = dataReader.GetInt32(0);
                            employeeModel.Name = dataReader.GetString(1);
                            employeeModel.Salary = dataReader.GetString(1);
                            employeeModel.StartDate = dataReader.GetDateTime(3);
                            employeeModel.Gender = Convert.ToChar(dataReader.GetString(4));
                            employeeModel.Phone = dataReader.GetString(5);
                            employeeModel.Address = dataReader.GetString(6);
                            employeeModel.Department = dataReader.GetString(7);
                            employeeModel.BasicPay = dataReader.GetDecimal(2);
                            employeeModel.Deduction = dataReader.GetDouble(8);
                            employeeModel.TaxablePay = dataReader.GetDouble(8);
                            employeeModel.IncomeTax = dataReader.GetDouble(9);
                            employeeModel.NetPay = dataReader.GetDouble(10);
                            System.Console.WriteLine(employeeModel.Id + " " + employeeModel.Name + " " + employeeModel.Salary + " " + employeeModel.StartDate + " " + employeeModel.Gender + " " + employeeModel.Phone + " " + employeeModel.Address + " " + employeeModel.Department + " " + employeeModel.BasicPay + " " + employeeModel.Deduction + " " + employeeModel.TaxablePay + " " + employeeModel.IncomeTax + " " + employeeModel.NetPay);
                            System.Console.WriteLine("\n");
                        }
                    }
                    else
                    {
                        System.Console.WriteLine("No data found !");
                    }
                }
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.Message);
            }
        }
        public bool AddEmployee(EmployeeModel model)
        {
            try
            {
                using (this.connection)
                {

                    SqlCommand command = new SqlCommand("SpAddEmployeeDetails", this.connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ID", model.Id);
                    command.Parameters.AddWithValue("@EmployeeName", model.Name);
                    command.Parameters.AddWithValue("@Salary", model.Salary);
                    command.Parameters.AddWithValue("@StartDate", DateTime.Now);
                    command.Parameters.AddWithValue("@Gender", model.Gender);
                    command.Parameters.AddWithValue("@Phone", model.Phone);
                    command.Parameters.AddWithValue("@Address", model.Address);
                    command.Parameters.AddWithValue("@Department", model.Department);
                    command.Parameters.AddWithValue("@BasicPay", model.BasicPay);
                    command.Parameters.AddWithValue("@Deduction", model.Deduction);
                    command.Parameters.AddWithValue("@TaxablePay", model.TaxablePay);
                    command.Parameters.AddWithValue("@IncomeTax", model.IncomeTax);
                    command.Parameters.AddWithValue("@NetPay", model.NetPay);

                    this.connection.Open();
                    var result = command.ExecuteNonQuery();
                    this.connection.Close();
                    if (result != 0)
                    {

                        return true;
                    }
                    return false;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                this.connection.Close();
            }
            return false;
        }
        public List<EmployeeModel> GetAllEmployees()
        {
            List<EmployeeModel> EmployeeList = new List<EmployeeModel>();

            SqlCommand com = new SqlCommand("spGetAllEmployeePayroll", connection);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();

            connection.Open();
            da.Fill(dt);
            connection.Close();
            foreach (DataRow dr in dt.Rows)
            {
                EmployeeList.Add(
                new EmployeeModel
                {
                    Id = Convert.ToInt32(dr["Id"]),
                    Name = Convert.ToString(dr["Name"]),
                    Salary = Convert.ToString(dr["Salary"]),
                    StartDate = Convert.ToDateTime(dr["StartDate"]),
                    Gender = Convert.ToChar(dr["Gender"]),
                    Phone = Convert.ToString(dr["ContactNumber"]),
                    Address = Convert.ToString(dr["Address"]),
                    Department = Convert.ToString(dr["Department"]),
                    BasicPay = Convert.ToDecimal(dr["Pay"]),
                    Deduction = Convert.ToDouble(dr["Deduction"]),
                    TaxablePay = Convert.ToDouble(dr["TaxablePay"]),
                    IncomeTax = Convert.ToDouble(dr["IncomeTax"]),
                    NetPay = Convert.ToDouble(dr["NetPay"])
                }
                    );
            }
            return EmployeeList;
        }
        public bool UpdateEmployee(EmployeeModel obj)
        {
            SqlCommand com = new SqlCommand("spUpdateEmployeeDetails", connection);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Id", obj.Id);
            com.Parameters.AddWithValue("@Salary", obj.Salary);
            com.Parameters.AddWithValue("@Department", obj.Department);
            connection.Open();
            int i = com.ExecuteNonQuery();
            connection.Close();
            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}