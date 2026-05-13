using System;
using System.Data;
using System.Data.SqlClient;

class ADOcode2
{
 public   static void Main()
    {
        string conStr = "Data Source=ZT-89BDJ84\\SQLEXPRESS;Initial Catalog=Employeemanagement;Integrated Security=True";

        Console.Write("Enter Employee no: ");
        int id = Convert.ToInt32(Console.ReadLine());

        SqlConnection con = new SqlConnection(conStr);

         SqlCommand cmd = new SqlCommand("update_salary", con);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@empid", id);

         SqlParameter outParam = new SqlParameter("@updated_salary", SqlDbType.Decimal);
        outParam.Direction = ParameterDirection.Output;
        outParam.Precision = 10;
        outParam.Scale = 2;

        cmd.Parameters.Add(outParam);

        con.Open();
        cmd.ExecuteNonQuery();
        Console.WriteLine("Salary Updated");
        Console.WriteLine("New Salary: " + outParam.Value);
    }
}