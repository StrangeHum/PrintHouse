using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MySqlConnector;

namespace PrintHouse.src
{
    public class StrangeDB
    {
        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;
        public StrangeDB()
        {
            Initialize();

        }
        /// <summary>
        /// HardCode данных в код
        /// </summary>
        private void Initialize()
        {
            server = "127.0.0.1";
            database = "printinghouse";
            uid = "root";
            password = "root"; //StrangeHoney
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            connection = new MySqlConnection(connectionString);
            TryOpenConnection();
        }

        public MySqlDataReader Select(string query = "Select * from client")
        {
            if (connection.State != System.Data.ConnectionState.Open)
            {
                throw new Exception("Нет подключения");
            }

            MySqlCommand cmd = new MySqlCommand(query, connection);

            var data = cmd.ExecuteReader();

            return data;
        }

        /// <summary>
        /// Добаляет данные в таблицу
        /// </summary>
        public void Insert()
        {
            if (this.TryOpenConnection() != true)
            {
                return;
            }

            string query = "INSERT INTO tableinfo (name, age) VALUES('John Smith', '33')";
            //create command and assign the query and connection from the constructor
            MySqlCommand cmd = new MySqlCommand(query, connection);

            //Execute command
            cmd.ExecuteNonQuery();

            //close connection
            this.TryCloseConnection();
        }
        /// <summary>
        /// Обновляет данные в таблице
        /// </summary>
        public void Update()
        {
            if (this.TryOpenConnection() != true)
            {
                throw new Exception("");
            }

            string query = "UPDATE tableinfo SET name='Joe', age='22' WHERE name='John Smith'";

            MySqlCommand cmd = new MySqlCommand();

            cmd.CommandText = query;

            cmd.Connection = connection;

            cmd.ExecuteNonQuery();

            this.TryCloseConnection();
        }
        /// <summary>
        /// Удаляет данные из таблицы
        /// </summary>
        public void Delete()
        {
            string query = "DELETE FROM tableinfo WHERE name='John Smith'";

            if (this.TryOpenConnection() != true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                this.TryCloseConnection();
            }
        }



        private bool TryOpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        MessageBox.Show("Cannot connect to server. Contact administrator");
                        break;

                    case 1045:
                        MessageBox.Show("Invalid username/password, please try again");
                        break;
                }
                return false;
            }
        }
        private bool TryCloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
    }
}
