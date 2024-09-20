using System;
using Entities;
using InMemoryRepositories;
using RepositoryContracts;

namespace CLI1.UI.ManagePosts
{
    public class SinglePostsView
    {
        private readonly IPostRepository postRepository;
        private readonly ICommentRepository commentRepository;
        private readonly IUserRepository userRepository;
        public SinglePostsView(IPostRepository postRepository)
        {
            this.postRepository = postRepository;
        }
        
        public void SinglePost(int postId)
        {
            var listPosts = new ListPostsView(postRepository);
            var listComments = new ListCommentsView(commentRepository);
            Post post = postRepository.GetSingleAsync(postId).Result;
            
            Console.Clear();
            Console.WriteLine("-------------------------------------------------------------");
            Console.WriteLine($"Post Title: {post.Title}");
            Console.WriteLine($"Post Body: {post.Body}");
            Console.WriteLine("-------------------------------------------------------------");
            
            listComments.ListComments(post.Id);
            
            Console.WriteLine("#-------------  MANAGE POSTS PAGE  ---------------#");
            Console.WriteLine("#----------  PICK AN OPTION BESTIEEE  ------------#");
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine("<<#>> SHOW ALL POSTS");
            Console.WriteLine("<<1>> ADD COMMENT");
            Console.WriteLine("-------------------------------------------------------------");

            string? input = Console.ReadLine();

            if (input.Equals("1"))
            {
                AddComment(postId);
            }
            if (input.Equals("#"))
            {
                listPosts.ListPosts();
            }
        }
        
        
        private void AddComment(int postId)
        {
            Console.Clear();
            Console.WriteLine("------------ADD A COMMENT-----------");
            Console.WriteLine($"-------- Post ID : {postId}------");

            Console.Write("Enter your User ID: ");
            if (!int.TryParse(Console.ReadLine(), out int userId) || userRepository.GetSingleAsync(userId).Result == null)
            {
                Console.WriteLine("Invalid User ID.");
                return;
            }

            Console.Write("Enter your comment: ");
            string? commentBody = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(commentBody))
            {
                Console.WriteLine("Comment cannot be empty.");
            }
            else
            {
                Comment newComment = new Comment
                {
                    Body = commentBody,
                    PostId = postId
                };

                commentRepository.AddAsync(newComment);
                Console.WriteLine("Comment added successfully!");
            }
        }
    }
}