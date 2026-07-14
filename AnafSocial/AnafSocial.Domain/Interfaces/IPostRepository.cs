using AnafSocial.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnafSocial.Domain.Interfaces;

public interface IPostRepository : IRepository<Post>
{
    Task<IEnumerable<Post>> GetFeedForUserAsync(Guid userId, int page, int pageSize);
    //Task<Post?> GetPostByIdAsync(Guid id);
    Task<IEnumerable<Post>> GetAllPostsAsync(User user);
    Task AddPostAsync(Post entity);
    void UpdatePost(Post entity);
    void RemovePost(Post entity);
}

