using System;
using RepositoryContracts;

namespace CLI1.UI.ManagePosts
{
    public class ManagePostsView
    {
        private readonly IPostRepository postRepository;
        public ManagePostsView(IPostRepository postRepository)
        {
            this.postRepository = postRepository;
        }

        public void ManagePosts()
        {
            var createPostView = new CreatePostView(postRepository);
            var singlePostsView = new SinglePostsView(postRepository);
            Console.Clear();
            Console.WriteLine("#-------------  MANAGE POSTS PAGE  ---------------#");
            Console.WriteLine("#----------  PICK AN OPTION BESTIEEE  ------------#");
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine("<<1>> CREATE A POST");
            Console.WriteLine("<<2>> SHOW ALL POSTS");
            string? input = Console.ReadLine();
            if (input.Equals("1"))
            {
                createPostView.CreatePost();
            }
            else if (input.Equals("2"))
            {
                singlePostsView.SinglePostView();
            }
        }
        
    }
}