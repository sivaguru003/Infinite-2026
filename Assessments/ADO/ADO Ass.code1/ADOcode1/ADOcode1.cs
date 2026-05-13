using System;
using System.Data;
using System.Data.SqlClient;

class ADOAss1
{
   public static void Main()
    {
        string dbcon =
        "Data Source=ZT-89BDJ84\\SQLEXPRESS;Initial Catalog=Employeemanagement;Integrated Security=True";

        SqlConnection connection =
        new SqlConnection(dbcon);
        connection.Open();
        SqlCommand insertcmd =
        new SqlCommand("AddEmployee", connection);
        insertcmd.CommandType =
        CommandType.StoredProcedure;

        insertcmd.Parameters.AddWithValue("@EmpName", "Ram");
        insertcmd.Parameters.AddWithValue("@EmpSal", 35000);
        insertcmd.Parameters.AddWithValue("@EmpType", "F");
        insertcmd.ExecuteNonQuery();

        Console.WriteLine("Employee Inserted Successfully");
        SqlCommand show =
        new SqlCommand("select * from Employee_Details", connection);
        SqlDataReader data = show.ExecuteReader();
        Console.WriteLine("\nEmployee List");
        while (data.Read())
        {
            Console.WriteLine(
                data["Empno"] + " " +
                data["EmpName"] + " " +
                data["EmpSal"] + " " +
                data["EmpType"]);
        }
    }
}