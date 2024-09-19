using System;
using System.Reflection;
using Entities;
using RepositoryContracts;

namespace CLI1.UI.ManagePosts
{
    public class CreatePostView
    {
        private readonly IPostRepository postRepository;
        private ManagePostsView managePostsView;

        public CreatePostView(IPostRepository postRepository)
        {
            this.postRepository=postRepository;
            managePostsView = new ManagePostsView(postRepository);
        }

        public void CreatePost()
        {
            Console.Clear();
            Console.WriteLine("#----------------CREATING A POST----------------#");
            Console.WriteLine("------------------------------------------------");
            Console.Write("TITLE: ");
            string? title = Console.ReadLine();
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("DESCRIPTION: ");
            string? body = Console.ReadLine();
            Post post = new Post();
            post.Title = title;
            post.Body = body;
            postRepository.AddAsync(post);
            managePostsView.ManagePosts();
            
        }
        
        
        
    }   
    
    
    
}   