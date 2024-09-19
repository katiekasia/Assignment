using System;
using RepositoryContracts;

namespace CLI1.UI.ManagePosts
{
    public class SinglePostsView
    {
        private readonly IPostRepository postRepository;

        public SinglePostsView(IPostRepository postRepository)
        {
            this.postRepository = postRepository;
        }

        public void SinglePostView()
        {
            var managePostsView = new ManagePostsView(postRepository);
            var listPostsView = new ListPostsView(postRepository);
            
            Console.Clear();
            Console.WriteLine(listPostsView.ListPosts());
            Console.WriteLine("-------------------------------------------------------------");
            Console.WriteLine("#----------------  PICK AN OPTION BESTIEEE  -----------------#");
            Console.WriteLine("-------------------------------------------------------------");
            Console.WriteLine("<<0>> BACK TO MANAGE POSTS PAGE");
            Console.WriteLine("<<1>> ADD COMMENT");
            string? input = Console.ReadLine();
            if (input.Equals("0"))
            {
               
            }
            else if (input.Equals("1"))
            {
               
            }
            
        }
        
    }
}