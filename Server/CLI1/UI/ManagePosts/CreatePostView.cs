using System;
using System.Reflection;
using Entities;
using RepositoryContracts;

namespace CLI1.UI.ManagePosts
{
    public class CreatePostView
    {
        private readonly IPostRepository postRepository;
        

        public CreatePostView(IPostRepository postRepository)
        {
            this.postRepository=postRepository;
        }

        public void CreatePost()
        {
            Console.Write("Create a new post: " +
                          "Title: ");
            string? title = Console.ReadLine();
            Console.Write("Description: ");
            string? body = Console.ReadLine();
            Post post = new Post();
            post.Title = title;
            post.Body = body;
            
            this.postRepository.AddAsync(post);
        }
        
        
        
    }   
    
    
    
}   