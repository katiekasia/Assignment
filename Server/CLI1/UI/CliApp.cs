using System;
using System.Threading.Tasks;
using CLI1.UI.ManagePosts;
using InMemoryRepositories;
using RepositoryContracts;

namespace CLI1.UI
{
    public class CliApp
    {
       public  CliApp(IUserRepository userRepository, ICommentRepository commentRepository, IPostRepository postRepository)
        {
            
        }
        
        CreatePostView CreatePostView = new CreatePostView();

        public Task StartAsync()
        {
            Console.WriteLine(">>1<< Create user");
            Console.WriteLine(">>2<< Create new post");
            Console.WriteLine(">>3<< View posts");
            return Task.CompletedTask;
        }
    }
}