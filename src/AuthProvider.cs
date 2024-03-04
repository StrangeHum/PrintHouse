using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Windows;

namespace PrintHouse.src
{
    internal static class AuthProvider
    {
        public static PersonalData personalData = null;
        //TODO: Если что-то с админом не так, то смотреть на строку ниже
        public static bool IsAdmin => personalData?.IsAdmin ?? false;
        public static bool TryAuth(string login, string password)
        {
            StrangeDB db = new StrangeDB();

            string hashPassword = GetHashString(password);

            var reader = db.Select($"select isAdmin, idProfile from authData where login = '{login}' and password = '{hashPassword}'");
            

            //todo: Заполнение данных
            if (reader.Read())
            {
                personalData = new PersonalData()
                {
                    IsAdmin = (bool)reader[0]
                };
                reader.DisposeAsync();
                MessageBox.Show($"Всё ок,{reader[1]}");
                return true;
            }
            else
            {
                reader.DisposeAsync();
                MessageBox.Show("Проблемка...");
                return false;
            }
            
        }

        public static void TrySignup(string login, string password, string firstName, string secontName, string midleName)
        {
            StrangeDB db = new StrangeDB();
            string hashPassword = GetHashString(password);
            db.Insert($"call CreateUser('{login}', '{hashPassword}', '{firstName}', '{secontName}', '{midleName}');");


            //TryAuth(login, password);
        }

        private static byte[] GetHash(string inputString)
        {
            using (HashAlgorithm algorithm = SHA256.Create())
                return algorithm.ComputeHash(Encoding.UTF8.GetBytes(inputString));
        }
        private static string GetHashString(string inputString)
        {
            StringBuilder sb = new StringBuilder();
            foreach (byte b in GetHash(inputString))
                sb.Append(b.ToString("X2"));

            return sb.ToString();
        }
    }
}
