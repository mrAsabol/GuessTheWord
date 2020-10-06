using System.Collections.Generic;
using System.Data.SqlClient;

namespace WordGame
{
    public class DbService
    {
        public List<string> GetWords()
        {
            var conn = new SqlConnection("Server=.\\SQLEXPRESS;Database=wordgame;Integrated Security=true");
            conn.Open();

            SqlCommand cmd = new SqlCommand("SELECT word FROM words", conn);
            SqlDataReader reader = cmd.ExecuteReader();
            List<string> results = new List<string>();

            while (reader.Read())
            {
                results.Add((string)reader["word"]);
            }

            reader.Close();
            conn.Close();

            return results;
        }
    }
}
