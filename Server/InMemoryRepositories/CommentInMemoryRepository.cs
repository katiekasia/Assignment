using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities;

namespace InMemoryRepositories
{
    public class CommentInMemoryRepository
    {
        public List<Comment> comments = new List<Comment>();

        public Task<Comment> AddAsync(Comment comment)
        {
            comment.Id = comments.Any() 
                ? comments.Max(p => p.Id) + 1
                : 1;
            comments.Add(comment);
            return Task.FromResult(comment);
        }

        public Task UpdateAsync(Comment comment)
        {
            Comment? existingComment = comments.SingleOrDefault(p => p.Id == comment.Id);
            if (existingComment is null)
            {
                throw new InvalidOperationException(
                    $"Comment with ID '{comment.Id}' not found");
            }

            comments.Remove(existingComment);
            comments.Add(comment);
            return Task.CompletedTask;
        }

        public Task DeleteAsync(int id)
        {
            Comment? commentToRemove =
                comments.SingleOrDefault(c => id == c.Id);
            if (commentToRemove is null)
            {
                throw new InvalidOperationException(
                    $"Comment with ID '{id}' not found");
            }
            
            comments.Remove(commentToRemove);
            return Task.CompletedTask;
        }

        public Task<Comment> GetSingleAsync(int id)
        {
            Comment? commentToGet = comments.SingleOrDefault(c => c.Id == id);
            return Task.FromResult(commentToGet);
        }

        public IQueryable<Comment> GetMany()
        {
            return comments.AsQueryable();
        }
    }
}