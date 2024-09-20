using System;
using System.Linq;
using Entities;
using RepositoryContracts;

namespace CLI1.UI.ManagePosts
{
    public class ListPostsView
    {
        private readonly IPostRepository postRepository;

        public ListPostsView(IPostRepository postRepository)
        {
            this.postRepository = postRepository;
        }

        public void ListPosts()
        {
            var singlePostsView = new SinglePostsView(this.postRepository);
            var managePostsView = new ManagePostsView(this.postRepository);
            
            Console.Clear();
            Console.WriteLine("#-------------  ALL POSTS PAGE  ---------------#");
            Console.WriteLine("#----------  PICK AN OPTION BESTIEEE  ------------#");
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine("<<#>> MANAGE POSTS");
            Console.WriteLine("<<number of a post>> SPECIFIC POST");
            var posts = postRepository.GetMany().ToList();
            if (posts.Any())
            {
                Console.WriteLine("--------------NO POSTS YET--------------");
                managePostsView.ManagePosts();
            }
            
            for (int i = 0; i < posts.Count; i++) 
            {
                Post post = posts[i];
                Console.WriteLine($"<<{i}>>    {post.Title}     ID: {post.Id}");
                Console.WriteLine("---------------------------------------------------");
            }

            Console.Write("Enter your option: ");
            string? input = Console.ReadLine();

            if (input.Equals("#"))
            {
                managePostsView.ManagePosts();
            }
            else if (int.TryParse(input, out int postIndex) && postIndex >= 0 && postIndex < posts.Count)
            {
                 singlePostsView.SinglePost(posts[postIndex].Id);
            }
            else
            {
                Console.WriteLine("Invalid input. Please try again.");
            }
        }


    }
}