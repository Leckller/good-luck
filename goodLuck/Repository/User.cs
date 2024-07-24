using GoodLuck.Db;
using GoodLuck.Models;
using Microsoft.EntityFrameworkCore;

namespace GoodLuck.Repository;

class UserRepository
{
    private readonly DatabaseContext _context;

    public UserRepository(DatabaseContext context)
    {
        _context = context;
    }

    public User? GetByName(string name)
    {
        return this._context.Users
                    .Where(u => u.name == name)
                    .Include(d => d.Days)
                    .FirstOrDefault(u => u.name == name);
    }

    public User? addUser(string email, string password, string name)
    {
        var newUser = new User()
        {
            email = email,
            password = password,
            name = name
        };

        this._context.Users.Add(newUser);
        this._context.SaveChanges();

        return newUser;
    }
}