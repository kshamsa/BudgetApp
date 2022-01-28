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

        public int AddUser(UserModel user)
        {
            int returnID = -1; 

            using (NpgsqlCommand cmd = connection.CreateCommand())
            {
                cmd.Connection.Open();

                try
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "add_user";
                    cmd.Parameters.AddWithValue("_first_name", NpgsqlTypes.NpgsqlDbType.Text, user.FirstName);
                    cmd.Parameters.AddWithValue("_last_name", NpgsqlTypes.NpgsqlDbType.Text, user.LastName);
                    cmd.Parameters.AddWithValue("_email", NpgsqlTypes.NpgsqlDbType.Text, user.Email);
                    cmd.Parameters.AddWithValue("_password", NpgsqlTypes.NpgsqlDbType.Text, user.Password);
                    NpgsqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            returnID = reader.GetInt32(0);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(System.Environment.NewLine + ex.Message + System.Environment.NewLine);
                    throw new Exception(ex.Message);
                }
                finally
                {
                    //garuntee that the connection to your database is closed. 
                    cmd.Connection.Close();
                }
            }

            return returnID; 
        }
    }
}
