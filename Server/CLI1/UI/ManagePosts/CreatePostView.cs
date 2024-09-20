using System;
using System.Reflection;
using Entities;
using RepositoryContracts;

namespace CLI1.UI.ManagePosts
{
    public class CreatePostView
    {
        private readonly IPostRepository postRepository;
        private readonly IUserRepository userRepository;
        public CreatePostView(IPostRepository postRepository)
        {
            this.postRepository=postRepository;
        }

        public void CreatePost()
        {
            var managePostsView = new ManagePostsView(postRepository);
            
            Console.Clear();
            Console.WriteLine("#----------------CREATING A POST----------------#");
            Console.WriteLine("------------------------------------------------");
            Console.Write("TITLE: ");
            string title = Console.ReadLine();
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("DESCRIPTION: ");
            string body = Console.ReadLine();
            Console.Write("ENTER USER ID (must be an existing user): ");
            string? userInput = Console.ReadLine();
            
            if (!int.TryParse(userInput, out int userId))
            {
                Console.WriteLine("Invalid input. Please enter a valid numeric User ID.");
                return;
            }
            var user = userRepository.GetSingleAsync(userId).Result;
            if (user == null)
            {
                Console.WriteLine($"User with ID {userId} does not exist. Please enter a valid User ID.");
                return;
            }

            Post post = new Post
            {
                Title = title,
                Body = body,
                UserId = userId
            };
            
            
           postRepository.AddAsync(post);
            managePostsView.ManagePosts();
            
        }
        
        
        
    }   
    
    
    
}   