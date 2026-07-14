using AnafSocial.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnafSocial.Domain.Interfaces;

public interface IFollowRepository : IRepository<Follow>
{
    Task<Follow?> GetAsync(Guid followerId, Guid followingId);
    Task<IEnumerable<Guid>> GetFollowingIdsAsync(Guid userId);
    Task<IEnumerable<User>> GetFollowersAsync(Guid userId);
    Task<IEnumerable<User>> GetFollowingAsync(Guid userId);
}