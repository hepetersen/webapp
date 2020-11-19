using System; 
using System.Collections.Generic;
using System.Data.SQLite;
using API.Models;

namespace API.Database
{
    public class DeleteData : IDeleteData
    {
        public void DeletePost(int id)
        {
             string cs = @"URI=file:C:\Users\hepet\source\repos\webapp4\posts.db";
             using var con = new SQLiteConnection(cs);
             con.Open();

             using var cmd = new SQLiteCommand(con);

             cmd.CommandText = @"DELETE FROM posts WHERE id = " + id;

             cmd.Prepare();
             cmd.ExecuteNonQuery();

        }
    }
}