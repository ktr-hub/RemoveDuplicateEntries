using System;
using System.Linq;

namespace adoDemo
{

    /*
     public static string connectionString = @"Data Source=(LocalDb)\Ktr;Initial Catalog=payroll_service;Integrated Security=True";
        SqlConnection connection = new SqlConnection(connectionString);

        public void GetAllEmployee()
        {
            try
            {
                EmployeePayroll employee = new EmployeePayroll();
                using (this.connection)
                {
                    string query = @"select empName,deptName,netPay,companyName from employee,department,employeeDepartment,payroll,company
                                     where employeeDepartment.empId = employee.empId 
                                     AND department.deptId = employeeDepartment.deptId
                                     AND payroll.empId = employeeDepartment.empId;";

                    SqlCommand cmd = new SqlCommand(query, this.connection);

                    this.connection.Open();

                    Console.WriteLine("\nConnection established with the database");

                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    {
                        Console.WriteLine("\nReading Data Rows : ");
                        while (dr.Read())
                        {
                            employee.EmployeeName = dr.GetString(0);
                            employee.Department = dr.GetString(1);
                            employee.Country = dr.GetString(3);
                            Console.WriteLine("\n"+employee.EmployeeName + " " + employee.Department + " " + employee.Country);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No data");
                    }
                    dr.Close();

                    this.connection.Close();
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                this.connection.Close();
            }
        }
     
     
     */


    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Sql Remove Duplicate entry!");
            //duplicate();
            AdoNet.selectUniqueRecords();
        }

        public static void duplicate()
        {
            int[] arr = { 1, 1, 1, 2, 2, 2, 3, 3, 4, 4, 5 };
            arr = arr.Distinct().ToArray();
            Array.ForEach(arr, x => 
            { 
                Console.WriteLine(x);
            });
        }
    }
}
