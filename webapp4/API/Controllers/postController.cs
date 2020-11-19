using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using API;
using API.Models;
using API.Database;
using Microsoft.AspNetCore.Cors;
using System.Data.SQLite;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class postController : ControllerBase
    {
        // GET: api/posts
        [EnableCors("AnotherPolicy")]
        [HttpGet]
        public List<Post> Get()
        {
            IReadAllData readObject = new ReadData();
            return readObject.GetAllPosts();
        }

        // GET: api/posts/5
        [EnableCors("AnotherPolicy")]
        [HttpGet("{id}", Name = "Get")]
        public Post Get(int id)
        {
            IGetPost readObject = new ReadData();
            return readObject.GetPost(id);
        }

        // POST: api/posts //creating a post
        [EnableCors("AnotherPolicy")]
        [HttpPost]
        public void Post([FromBody] Post value)
        {
            IAddData addObject = new SaveData();
            addObject.AddData(value);
        }
   
        // PUT: api/posts/5
        [EnableCors("AnotherPolicy")]
        [HttpPut("{id}")]
        [Route("posts/{id:int}")]
        public void Put([FromBody] int id, string text)
        {
            ISaveData saveObject = new SaveData();
            saveObject.SavePost(id, text);
        }

        // DELETE: api/ApiWithActions/5
        [EnableCors("AnotherPolicy")]
        [HttpDelete("{id}")]
        [Route("posts/{id:int}")]
        public void Delete(int id)
        {
            IDeleteData deleteObject = new DeleteData();
            deleteObject.DeletePost(id);
        }
    }
}
