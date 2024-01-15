//Создать класс «Car», со свойствами: Id, Model, Year.
//Создать базу данных «Cars». Создать таблицу с соответствующими столбцами, заполнить таблицу на 5 разных авто.
//Создать список класса, добавить все авто из таблицы и вывести на экран.
//Создать вторую коллекцию, в нее получить все авто младше 2018 года, вывести на экран.

using Microsoft.Data.SqlClient;

namespace Task_1
{
    internal class Program
    {
        static string connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=Cars;Trusted_Connection=True;";
        static void Main(string[] args)
        {
            //CreateDatabase();
            //CreateTable();
            //InsertIntoTable();

            List<Car> allCars = (List<Car>)GetCars();
            Console.WriteLine("\nAll Cars: ");
            PrintCars(allCars);

            int year = 2018;
            List<Car> SomeCars = (List<Car>)GetCarsYoungerThanYear(year);
            Console.WriteLine($"\nThe Cars Younger than {year}: ");
            PrintCars(SomeCars);


        }

        private static void CreateDatabase()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand("CREATE DATABASE Cars", connection);
                sqlCommand.ExecuteNonQuery();
            }
        }
        private static void CreateTable()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand("CREATE TABLE [Car] ([Id] INT PRIMARY KEY IDENTITY, [Model] NVARCHAR(100) NOT NULL, [Year] INT NOT NULL)", connection);
                int count = sqlCommand.ExecuteNonQuery();
            }
        }
        private static void InsertIntoTable()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = """
                    INSERT INTO [Car] (Model, Year) VALUES
                    ('Reno Trafic',2005),
                    ('Land Rover Discovery', 2018),
                    ('Wolksvagen ID6 ', 2023)
                    """;
                SqlCommand sqlCommand = new SqlCommand(sql, connection);
                int count = sqlCommand.ExecuteNonQuery();
            }
        }

        //Создать список класса, добавить все авто из таблицы и вывести на экран.
        private static IEnumerable<Car> GetCars()
        {
            List<Car> cars = new List<Car>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = """
                    SELECT Id, Model, Year From [Car]
                    """;
                SqlCommand sqlCommand = new SqlCommand(sql, connection);

                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            cars.Add(new Car
                            {
                                Id = reader.GetInt32(0),
                                Model = reader.GetString(1),
                                Year = reader.GetInt32(2)
                            });
                        }
                    }
                }
            }
            return cars;
        }

        //Создать вторую коллекцию, в нее получить все авто младше 2018 года, вывести на экран.
        private static IEnumerable<Car> GetCarsYoungerThanYear(int year)
        {
            List<Car> cars = new List<Car>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = $"""
                    SELECT Id, Model, Year
                    FROM [Car]
                    WHERE Year > {year}
                    """;
                SqlCommand sqlCommand = new SqlCommand(sql, connection);

                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            cars.Add(new Car
                            {
                                Id = reader.GetInt32(0),
                                Model = reader.GetString(1),
                                Year = reader.GetInt32(2)
                            });
                        }
                    }
                }
            }
            return cars;
        }

        private static void PrintCars(List<Car> cars)
        {
            foreach (Car car in cars)
            {
                Console.WriteLine(car.ToString());
            }
        }
    }
}
