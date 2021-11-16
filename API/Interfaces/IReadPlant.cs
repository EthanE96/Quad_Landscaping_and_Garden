using System.Collections.Generic;
using API.Models;

namespace API.Interfaces
{
    public interface IReadPlant
    {
         public List<Post> GetAllPosts();
    }
}