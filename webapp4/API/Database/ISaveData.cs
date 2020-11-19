using API.Models;

namespace API.Database
{
    public interface ISaveData
    {
         public void SavePost(int id, string text);
    }
}