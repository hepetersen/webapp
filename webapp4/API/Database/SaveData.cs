using System; 
using System.Collections.Generic;
using System.Data.SQLite; 
using API.Models;


namespace API.Database
{
    public class SaveData : ISeedData, ISaveData, IAddData
    {

        public void SavePost(int id, string text)
        {
             string cs = @"URI=file:C:\Users\hepet\source\repos\webapp4\posts.db";
             using var con = new SQLiteConnection(cs);
             con.Open();

             using var cmd = new SQLiteCommand(con);

             cmd.CommandText = @"UPDATE posts SET text = @text WHERE id = @id";
             cmd.Parameters.AddWithValue("@id", id);
             cmd.Parameters.AddWithValue("@text", text);
             //cmd.Parameters.AddWithValue("@date", value.Date);  
             cmd.Prepare();
             cmd.ExecuteNonQuery();
        }

        public void AddData(Post value)
        {
             string cs = @"URI=file:C:\Users\hepet\source\repos\webapp4\posts.db";
             using var con = new SQLiteConnection(cs);
             con.Open();

             using var cmd = new SQLiteCommand(con);

             cmd.CommandText = @"INSERT INTO posts(text, date) VALUES(@text, @date)";
             cmd.Parameters.AddWithValue("@id", value.Id);
             cmd.Parameters.AddWithValue("@text", value.Text);
             cmd.Parameters.AddWithValue("@date", value.Date);
             cmd.Prepare();
             cmd.ExecuteNonQuery();
        }

        public void SeedData()
        {
             string cs = @"URI=file:C:\users\hepet\source\repos\webapp4\posts.db";
             using var con = new SQLiteConnection(cs);
             con.Open();

             using var cmd = new SQLiteCommand(con);

             cmd.CommandText = "DROP TABLE IF EXISTS posts";
             cmd.ExecuteNonQuery();

             cmd.CommandText = @"CREATE TABLE posts(id INTEGER PRIMARY KEY, text TEXT, date DATE)";
             cmd.ExecuteNonQuery();


             string dateInput = "10/02/2020 2:48:52 PM";
             cmd.CommandText = @"INSERT INTO posts(text, date) VALUES(@text, @date)";
             cmd.Parameters.AddWithValue("@text", "hey its big al here");
             cmd.Parameters.AddWithValue("@date", DateTime.Parse(dateInput));
             cmd.Prepare();
             cmd.ExecuteNonQuery();

             dateInput = "10/05/2020 9:24:32 AM";
             cmd.CommandText = @"INSERT INTO posts(text, date) VALUES(@text, @date)";
             cmd.Parameters.AddWithValue("@text", "big al again lol");
             cmd.Parameters.AddWithValue("@date", DateTime.Parse(dateInput));
             cmd.Prepare();
             cmd.ExecuteNonQuery();
        }
    }
}