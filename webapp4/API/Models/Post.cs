using System;
using System.Data.SQLite;
using System.Collections.Generic;
using API.Database;

namespace API.Models
{
    public class Post 
    {
        public int Id{get; set;}
        public string Text{get; set;}
        public DateTime Date{get; set;}
        public int count{get; }

        // public int CompareTo(Post temp) //required for list sort method. sorting by timestamp
        // {
        //     return this.Date.CompareTo(temp.Date);
        // }

        // public static List<Post> UpdatePosts()  //reads all posts from posts.db into a new list
        // {
        //     List<Post> myPosts = new List<Post>();
            
        //     IReadAllData readObject = new ReadData();
        //     myPosts = readObject.GetAllPosts();

        //     return myPosts;
        // }

        // public static List<Post> DeletePost(List<Post> myPosts) //prompts user for post ID to delete. 
        // {
        //     int deleteID;
        //     bool postFound = false;

        //     Console.Write("Enter the Post ID of the post you would like to delete: ");
        //     string inputDeleteID = Console.ReadLine();

        //     if(int.TryParse(inputDeleteID, out deleteID)) //returns true if parse from string to int is successful
        //     {
        //         deleteID = int.Parse(inputDeleteID);
                
        //         if (deleteID > 0) //no IDs will be less than one
        //         {
        //             for(int i = myPosts.Count - 1; i >= 0; i--)
        //             {
        //                 if(myPosts[i].Id == deleteID)
        //                 {
        //                     //Console.WriteLine("post to delete: " + myPosts[i].ToString()); //testing selection of ID
        //                     //removing from databse
        //                     DeleteData deleteObject = new DeleteData();
        //                     deleteObject.DeletePost(myPosts[i]);

        //                     //removing from list
        //                     myPosts.RemoveAt(i);

        //                     Console.WriteLine("Post was successfully deleted.");
        //                     postFound = true;
        //                 }
        //             }
        //             if (postFound == false)
        //             {
        //                 Console.WriteLine("Post not found. Please try again.");
        //                 DeletePost(myPosts);
        //             }
        //         }
        //         else 
        //         {
        //             Console.WriteLine("Post not found. Please try again.");
        //             DeletePost(myPosts);
        //         }
        //     }
        //     else
        //     {
        //         Console.WriteLine("Error: Invalid format. Please try again.");
        //         DeletePost(myPosts);
        //     }

        //     return myPosts;
        // }

        // public static List<Post> AddPost(List<Post> myPosts)
        // {
        //     Console.WriteLine("Enter the text for your new post:");

        //     string newText = Console.ReadLine();

        //     myPosts.Sort();
        //     int newID = myPosts[myPosts.Count - 1].Id + 1;
            
        //     DateTime newTimeStamp = DateTime.Now;

        //     Post newPost = new Post(){Id = newID, Text = newText, Date = newTimeStamp};
        //     myPosts.Add(newPost);

        //     SaveData saveObject = new SaveData();
        //     saveObject.AddData(newPost);
   
        //     Console.WriteLine("Your post was successfully created!");

        //     return myPosts;
        // }


        // public static void ShowAllPosts(List<Post> myPosts)
        // {
        //     if (myPosts.Count > 0) //will only display posts if list is populated
        //     {
        //         Console.WriteLine();
        //         myPosts.Sort(); //sorts list by ascending timestamp
        //         myPosts.Reverse(); //reverses order of list so that list is sorted by descending timestamp

        //         Console.WriteLine("Post ID: \t Post Text: \t \t \t \t \t Post Date:");
        //         foreach (Post post in myPosts)
        //         {
        //             Console.WriteLine(post.ToString());
        //         }
        //     }
        //     else
        //     {
        //         Console.WriteLine("Oops! There are no posts to display.");  
        //     }
        // }

        public override string ToString()
        {
            return Id + "\t" + "\t" + Text + "\t" + "\t" + "\t" + "\t" + Date;
        }
    }
}
