using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities;
using RepositoryContracts;

namespace InMemoryRepositories
{
    public class PostInMemoryRepository: IPostRepository
    {
        public List<Post> posts;
        
        public Task<Post> AddAsync(Post post)
        {
            post.Id = posts.Any() 
                ? posts.Max(p => p.Id) + 1
                : 1;
            posts.Add(post);
            return Task.FromResult(post);
        }



    }
}