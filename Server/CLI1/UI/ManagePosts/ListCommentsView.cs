using System;
using System.Linq;
using RepositoryContracts;

namespace CLI1.UI.ManagePosts
{
    public class ListCommentsView
    {
        private readonly ICommentRepository commentRepository;
        
        public ListCommentsView(ICommentRepository commentRepository)
        {
            this.commentRepository = commentRepository;
        }

        public void ListComments(int postId)
        {
            Console.Clear();
            Console.WriteLine("#-------------  COMMENTS  ---------------#");
            Console.WriteLine("---------------------------------------------------");
            var comments = commentRepository.GetMany();
            if (comments.Any())
            {
                foreach (var comment in comments)
                {
                    if (comment.PostId == postId)
                    Console.WriteLine($"- {comment.Body} ");
                    Console.WriteLine("---------------------------------------------------");
                }
            }
            else
            {
                Console.WriteLine("No comments yet.");
            }
        }

    }
}