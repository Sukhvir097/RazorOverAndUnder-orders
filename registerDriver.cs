using Microsoft.Data.Sqlite;

namespace OrderBot
{
    public class registerDriver
    {
        private string d_name;  
        private string d_phone;
        private string d_password;



        public string DName{
            get => d_name;
            set => d_name = value;
        }
        public string DPhone{
            get => d_phone;
            set => d_phone = value;
        }
        public string DPassword{
            get => d_password;
            set => d_password = value;
        }
        public void D_register(){
           using (var connection = new SqliteConnection(DB.GetConnectionString()))
            {
                connection.Open();
                    var commandInsert = connection.CreateCommand();
                    commandInsert.CommandText =
                    @"INSERT INTO register(name, phone, password) VALUES($name, $phone,password)";
                    commandInsert.Parameters.AddWithValue("$name", DName);
                    commandInsert.Parameters.AddWithValue("$phone", DPhone);
                    commandInsert.Parameters.AddWithValue("$phone", DPassword);
                    int nRowsInserted = commandInsert.ExecuteNonQuery();

            }
        }
       public int D_login(string nam,string pass){
            using (var connection = new SqliteConnection(DB.GetConnectionString()))
            {
                connection.Open();
                    var commandSelect = connection.CreateCommand();
                    commandSelect.CommandText=@"SELECT * from register where name=$name and password=$password";
                    commandSelect.Parameters.AddWithValue("$name", nam);
                    commandSelect.Parameters.AddWithValue("$password", pass);
                    int nRowsInserted = commandSelect.ExecuteNonQuery();

            }
            return 1;
       }
        public string D_history(){
            using (var connection = new SqliteConnection(DB.GetConnectionString()))
            {
                connection.Open();
                    var commandSelect = connection.CreateCommand();
                    commandSelect.CommandText=@"SELECT * from history where Id=$ID";
                    int nRowsInserted = commandSelect.ExecuteNonQuery();
                    return "sfs";

            }
       }
       public void D_Odometer_pic(string pic){
           using (var connection = new SqliteConnection(DB.GetConnectionString()))
            {
                connection.Open();
                    var commandInsert = connection.CreateCommand();
                    commandInsert.CommandText =
                    @"INSERT INTO odometer(photo) VALUES($photo)";
                    commandInsert.Parameters.AddWithValue("$photo", pic);
                    int nRowsInserted = commandInsert.ExecuteNonQuery();

            }
        }
       
    }
}
