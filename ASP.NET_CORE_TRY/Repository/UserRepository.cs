using Microsoft.EntityFrameworkCore;
using ASP.NET_CORE_TRY.Models;
using ASP.NET_CORE_TRY.DataBase;

namespace ASP.NET_CORE_TRY.Repository;

public class UserRepository : IRepository<User>
{
    private readonly ApplicationContext _context;

    public UserRepository(ApplicationContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<User>> GetAll()
    {
        return await _context.Users.ToListAsync();
    }

    public async Task<User> Get(int? id)
    {
        return await _context.Users.FirstOrDefaultAsync(x => x.UserId == id);
    }

    public async Task<User> Add(User user)
    {
        await _context.Users.AddAsync(user);
        
        await _context.SaveChangesAsync();
        
        return user;
    }

    public async Task Update(User user)
    {
        _context.Users.Update(user);
        
        await _context.SaveChangesAsync();
    }

    public async Task Delete(User user)
    {
        _context.Users.Remove(user);
            
        await _context.SaveChangesAsync();
        
    }
}