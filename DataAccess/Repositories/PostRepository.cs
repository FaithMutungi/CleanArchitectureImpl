

using Application.Abstractions;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly SocialDbContext _context;
        public PostRepository(SocialDbContext _context)
        {
            this._context= _context;
        }

    public async Task<Post> CreatePost(Post toCreate)
        {
            toCreate.DateCreated = DateTime.Now;
            toCreate.LastModified = DateTime.Now;
            _context.Add(toCreate);
            await _context.SaveChangesAsync();
            return toCreate;
           
        }

        public async Task DeletePost(int postId)
        {
            var post = await _context.Posts.FirstOrDefaultAsync(p=>p.Id == postId);
            if (post == null) return;
            _context.Posts.Remove(post);
            await _context.SaveChangesAsync();
        


        }

        public async Task<Post> GetPostById(int postId)
        {
            var post = await _context.Posts.FirstOrDefaultAsync(p => p.Id == postId);
            return post == null ? throw new KeyNotFoundException($"Post with ID {postId} was not found.") : post;
        }


        public async Task<ICollection<Post>> GetPosts()
        {
            return await _context.Posts.ToListAsync();
        }

        public async Task<Post> UpdatePost(string updatedContent, int postId)
        {
            var post = await _context.Posts.FirstOrDefaultAsync(p => p.Id == postId);
            post.LastModified= DateTime.Now;
            post.Content = updatedContent;
            await _context.SaveChangesAsync();
            return post;
        }
    }
}
 