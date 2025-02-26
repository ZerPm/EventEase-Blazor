using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Modelos;

public class UserService : IUserService
{
    private List<User> _users = new List<User>();

    public async Task<List<User>> GetUsersAsync()
    {
        return await Task.FromResult(_users);
    }

    public async Task<User> GetUserByIdAsync(int id)
    {
        return await Task.FromResult(_users.FirstOrDefault(u => u.Id == id));
    }

    public async Task<bool> AddUserAsync(User user)
    {
        _users.Add(user);
        return await Task.FromResult(true);
    }

    public async Task<bool> UpdateUserAsync(User user)
    {
        var existingUser = _users.FirstOrDefault(u => u.Id == user.Id);
        if (existingUser != null)
        {
            existingUser.Name = user.Name;
            existingUser.Email = user.Email;
            return await Task.FromResult(true);
        }
        return await Task.FromResult(false);
    }

    public async Task<bool> DeleteUserAsync(int id)
    {
        var user = _users.FirstOrDefault(u => u.Id == id);
        if (user != null)
        {
            _users.Remove(user);
            return await Task.FromResult(true);
        }
        return await Task.FromResult(false);
    }
}
