using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Cafe_Store.DAO
{
    public class AccountDAO
    {
        public string userNameGlobal;

        private static AccountDAO instance;

        private AccountDAO() { }

        public static AccountDAO Instance
        {
            get
            {
                if (instance == null) instance = new AccountDAO(); return instance;
            }

            private set
            {
                instance = value;
            }
        }

        public bool LogIn(string userName, string passWord)
        {
            string strQuery = "sp_LogIn @userName , @passWord";

            DataTable result = DataProvider.Instance.ExecuteQuery(strQuery, new object[] { userName, passWord });

            userNameGlobal = userName;

            return result.Rows.Count > 0;
        }
    }
}
