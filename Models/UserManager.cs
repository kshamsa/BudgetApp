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

        public int AddUser(UserModel _User)
        {
            int returnID = -1; 

            using (NpgsqlCommand cmd = connection.CreateCommand())
            {
                cmd.Connection.Open();

                try
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "add_user";
                    cmd.Parameters.AddWithValue("_first_name", NpgsqlTypes.NpgsqlDbType.Text, _User.FirstName);
                    cmd.Parameters.AddWithValue("_last_name", NpgsqlTypes.NpgsqlDbType.Text, _User.LastName);
                    cmd.Parameters.AddWithValue("_email", NpgsqlTypes.NpgsqlDbType.Text, _User.Email);
                    cmd.Parameters.AddWithValue("_password", NpgsqlTypes.NpgsqlDbType.Text, _User.Password);
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

        public bool CheckUser(string _Email)
        {
            int returnedId = -1; 

            using (NpgsqlCommand cmd = connection.CreateCommand())
            {
                cmd.Connection.Open();

                try
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "check_user";
                    cmd.Parameters.AddWithValue("_email", NpgsqlTypes.NpgsqlDbType.Text, _Email);
                    NpgsqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            //Normally you would check for the column name, 
                            //but in PostgreSQL you would when a function is called
                            //the function name is what is returned
                            int userIdIndex = reader.GetOrdinal("check_user");
                            returnedId = reader.GetInt32(userIdIndex);
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

            if(returnedId == -1)
            {
                return false;
            }
            else
            {
                return true; 
            }
        }

        public UserModel GetUser(int _UserId)
        {
            int returnedId = -1;

            using (NpgsqlCommand cmd = connection.CreateCommand())
            {
                cmd.Connection.Open();

                try
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "get_user";
                    cmd.Parameters.AddWithValue("_user_ID", NpgsqlTypes.NpgsqlDbType.Integer, _UserId);
                    NpgsqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            //Normally you would check for the column name, 
                            //but in PostgreSQL you would when a function is called
                            //the function name is what is returned
                            UserModel oUser = new UserModel();

                            int ordID = reader.GetOrdinal("user_ID");
                            int ordFirstName = reader.GetOrdinal("first_name");
                            int ordLastName = reader.GetOrdinal("last_name");
                            int ordEmail = reader.GetOrdinal("email");
                            int ordPassword = reader.GetOrdinal("password");

                            oUser.Id = reader.GetInt32(ordID);
                            oUser.FirstName = reader.GetString(ordFirstName);
                            oUser.LastName = reader.GetString(ordLastName);
                            oUser.Email = reader.GetString(ordEmail);
                            oUser.Password = reader.GetString(ordPassword);

                            return oUser;
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

            return new UserModel(); 
        }

        public UserModel LoginUser(UserModel _User)
        {

            using (NpgsqlCommand cmd = connection.CreateCommand())
            {
                cmd.Connection.Open();

                try
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "login";
                    cmd.Parameters.AddWithValue("_email", NpgsqlTypes.NpgsqlDbType.Text, _User.Email);
                    cmd.Parameters.AddWithValue("_password", NpgsqlTypes.NpgsqlDbType.Text, _User.Password);
                    NpgsqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            UserModel oUser = new UserModel(); 

                            int ordID =        reader.GetOrdinal("user_ID");
                            int ordFirstName = reader.GetOrdinal("first_name");
                            int ordLastName =  reader.GetOrdinal("last_name");
                            int ordEmail =     reader.GetOrdinal("email");
                            int ordPassword =  reader.GetOrdinal("password");

                            oUser.Id =        reader.GetInt32(ordID); 
                            oUser.FirstName = reader.GetString(ordFirstName);
                            oUser.LastName =  reader.GetString(ordLastName);
                            oUser.Email =     reader.GetString(ordEmail);
                            oUser.Password =  reader.GetString(ordPassword);

                            return oUser; 
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
                    cmd.Connection.Close();
                }
            }

            return new UserModel();
        }
    }
}

