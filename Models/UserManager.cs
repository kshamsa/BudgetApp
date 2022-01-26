using Npgsql;

namespace BudgetApp.Models
{
    public class UserManager
    {
        private NpgsqlConnection connection; 

        public UserManager()
        {
            connection = new NpgsqlConnection("Host=127.0.0.1;Username=postgres;Password=pg_password;Database=budget_app");
        }

        public void TestInsert()
        {
            using(NpgsqlCommand cmd = connection.CreateCommand())
            {
                cmd.CommandText = "SELECT PUBLIC.test_functions()";
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                //cmd.ExecuteReader() this will return a reader object that you will loop through 
                cmd.Connection.Close(); 
            }
        }

    }
}
