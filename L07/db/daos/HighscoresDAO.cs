using L07.db.models;
using L07.db.utils;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L07.db.daos
{
    class HighscoresDAO
    {
        public static List<Highscore> findAll()
        {
            List<Highscore> rez = new List<Highscore>();

            // preia conexiune de la db

            MySqlConnection con = DBConnection.getConnection();

            if (con==null)
            {
                throw new Exception("Conexiunea la baza de date nu s-a realizat.");
            }

            // executa query pentru preluare date + transfer in lista

            MySqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT * FROM highscores ORDER BY highscore DESC";

            MySqlDataReader data = cmd.ExecuteReader();

            while (data.Read())
            {
                Highscore hs = new Highscore();
                hs.Id = long.Parse(data["id"].ToString());
                hs.Gamer = data["gamer"].ToString();
                hs.Hscore = int.Parse(data["highscore"].ToString());

                rez.Add(hs);
            }

            // inchide conexiune + cleanup
            data.Close();
            con.Close();

            return rez;
        }

        public static void insert(Highscore hs)
        {
            MySqlConnection con = DBConnection.getConnection();

            if (con == null)
            {
                throw new Exception("Conexiunea la baza de date nu s-a realizat.");
            }

            MySqlCommand cmd = con.CreateCommand();

            cmd.CommandText = "INSERT INTO highscores(gamer, highscore) VALUES(@gamer, @hscore)";
            cmd.Parameters.AddWithValue("@gamer", hs.Gamer);
            cmd.Parameters.AddWithValue("@hscore", hs.Hscore);

            if (cmd.ExecuteNonQuery()!=1)
            {
                throw new Exception("Inserarea nu s-a putut face.");
            }

            con.Close();
        }
    }
}
