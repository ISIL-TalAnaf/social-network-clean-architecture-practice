using AnafSocial.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnafSocial.Domain.Interfaces;

public interface ILikeRepository : IRepository<Like>
{
    Task<Like?> GetAsync(Guid postId, Guid userId);
    Task<int> CountForPostAsync(Guid postId);
}
