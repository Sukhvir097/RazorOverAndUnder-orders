using Microsoft.Data.Sqlite;

namespace OrderBot
{
    public class registerDriver
    {
        private string Driver_name;  
        private string _phone;
        private string _password;

        public string Name{
            get => Driver_name;
            set => Driver_name = value;
        }
        public string Phone{
            get => _phone;
            set => _phone = value;
        }
        public string Password{
            get => _password;
            set => _password = value;
        }
        public void Save(){
           using (var connection = new SqliteConnection(DB.GetConnectionString()))
            {
                connection.Open();
                    var commandInsert = connection.CreateCommand();
                    commandInsert.CommandText =
                    @"INSERT INTO register(name, phone, password) VALUES($name, $phone,password)";
                    commandInsert.Parameters.AddWithValue("$name", Name);
                    commandInsert.Parameters.AddWithValue("$phone", Phone);
                    commandInsert.Parameters.AddWithValue("$phone", Password);
                    int nRowsInserted = commandInsert.ExecuteNonQuery();

            }
        }
       
    }
}
