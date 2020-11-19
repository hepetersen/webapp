using System.Collections.Generic;
using System.Data.SQLite;
using API.Models;

namespace API.Database
{
    public class ReadData : IReadAllData, IGetPost
    {
        public List<Post> GetAllPosts()
        {
            List<Post> allPosts = new List<Post>(); 

            string cs = @"URI=file:C:\Users\hepet\source\repos\webapp4\posts.db";
            using var con = new SQLiteConnection(cs);
            con.Open();

            string stm = "SELECT * FROM posts ";
            using var cmd = new SQLiteCommand(stm, con);

            using SQLiteDataReader rdr = cmd.ExecuteReader();

            while(rdr.Read())
            {
                Post temp = new Post(){Id=rdr.GetInt32(0), Text=rdr.GetString(1), Date=rdr.GetDateTime(2)};
                allPosts.Add(temp);
            }

            return allPosts;
        }

        public Post GetPost(int id)
        {
            string cs = @"URI=file:c:\users\hepet\source\repos\webapp4\posts.db";
            using var con = new SQLiteConnection(cs);
            con.Open();

            string stm = "SELECT * FROM posts WHERE id = @id";
            using var cmd = new SQLiteCommand(stm, con);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Prepare();
            using SQLiteDataReader rdr = cmd.ExecuteReader();

            rdr.Read();
            return new Post(){Id=rdr.GetInt32(0), Text=rdr.GetString(1), Date=rdr.GetDateTime(2)};
        }
    }
}