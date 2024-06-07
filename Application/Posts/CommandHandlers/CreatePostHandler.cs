using Application.Abstractions;
using Application.Posts.Commands;
using Domain.Models;
using MediatR;

namespace Application.Posts.CommandHandlers
{
    public class CreatePostHandler : IRequestHandler<CreatePost, Post>
    {
        private readonly IPostRepository _postsRepo;
        public CreatePostHandler(IPostRepository postrepo)
        {
            _postsRepo = postrepo;
        }
        public async Task<Post> Handle(CreatePost request, CancellationToken cancellationToken)
        {
            var newPost = new Post
            {
                Content = request.PostContent
            };
            return await _postsRepo.CreatePost(newPost);
        }
    }
}
