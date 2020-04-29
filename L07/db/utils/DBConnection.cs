using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L07.db.utils
{
    class DBConnection
    {
        public static MySqlConnection getConnection()
        {
            MySqlConnection con;

            try
            {
                con = new MySqlConnection("SERVER=127.0.0.1;PORT=3306;DATABASE=game;UID=root;PASSWORD=;");
                con.Open();
            }
            catch (Exception e)
            {
                con = null;
            }

            return con;
        }

    }
}
