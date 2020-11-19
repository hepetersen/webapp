using System.Collections.Generic;
using API.Models;

namespace API.Database
{
    public interface IReadAllData
    {
         public List<Post> GetAllPosts();
    }
}