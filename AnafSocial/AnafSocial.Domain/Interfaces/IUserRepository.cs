using AnafSocial.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnafSocial.Domain.Interfaces;

public interface IUserRepository : IRepository<User>
{
    Task <User?> GetByUserIdAsync(Guid id);

    Task<IEnumerable<User>> GetAllUsersAsync();

    Task AddUserAsync(User user);

    void UpdateUser(User user);
    void RemoveUser(User user);


}

