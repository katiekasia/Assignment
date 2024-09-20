using System;
using System.Threading.Tasks;
using CLI1.UI.ManagePosts;
using CLI1.UI.ManageUsers;
using InMemoryRepositories;
using RepositoryContracts;

namespace CLI1.UI
{
    public class CliApp
    {
        private readonly IPostRepository postRepository;
        private readonly IUserRepository userRepository;
        private readonly ICommentRepository commentRepository;
        
       public CliApp(IUserRepository userRepository, ICommentRepository commentRepository, IPostRepository postRepository)
       {
           this.postRepository = postRepository;
           this.userRepository = userRepository;
           this.commentRepository = commentRepository;
       }
       
        public Task StartAsync()
        {
            var managePostsView = new ManagePostsView(postRepository);
            var manageUsersView = new ManageUsersView(userRepository);
            Console.WriteLine("#--------------------    HIII BESTIE     -------------------#");
            Console.WriteLine("#----------------   SLAYYING MENU CONTROL   ----------------#");
            Console.WriteLine("#---   Pick a number to teleport to a specific action    ---#");
            Console.WriteLine("                               ;)))   ");
            Console.WriteLine("-------------------------------------------------------------");
            Console.WriteLine(">>1<< MANAGE USERS");
            Console.WriteLine(">>2<< MANAGE POSTS");
            
            string? number = Console.ReadLine();
            if (number.Equals("1"))
            {
                manageUsersView.ManageUsers();
            }
            else if (number.Equals("2"))
            {
                managePostsView.ManagePosts();
            }
            else
            {
                Console.WriteLine("Invalid input");
            }
            Console.Clear();
                
            return Task.CompletedTask;
        }
    }
}