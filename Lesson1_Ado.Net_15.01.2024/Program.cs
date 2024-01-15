// See https://aka.ms/new-console-template for more information
using Microsoft.Data.SqlClient;
string connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=master;Trusted_Connection=True;";
using(SqlConnection connection = new SqlConnection(connectionString))
{
    connection.Open();
    SqlCommand sqlCommand = new SqlCommand("CREATE DATABASE Library", connection);
    sqlCommand.ExecuteNonQuery();
}