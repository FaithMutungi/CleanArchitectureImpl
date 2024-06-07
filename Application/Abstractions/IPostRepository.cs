

using Domain.Models;

namespace Application.Abstractions
{
    public interface IPostRepository
    {
        Task<ICollection<Post>> GetPosts();
        Task<Post> GetPostById(int PostId);
        Task<Post> CreatePost(Post toCreate);
        Task<Post> UpdatePost(string updatedContent, int postId);
        Task DeletePost(int postId);
    }
}
