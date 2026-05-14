using Microsoft.EntityFrameworkCore;
using MyRecipeBook.Domain.Entities;

namespace MyRecipeBook.Infrastructure.DataAccess.Repositories
{
    public class UserRepository
    {
        private readonly MyRecipeBookDbContext _dbContext;

        public UserRepository(MyRecipeBookDbContext dbContext) => _dbContext = dbContext;

        public async Task Add(User user) => await _dbContext.AddAsync(user);

        public async Task<bool> ActiveUserWithEmail(string email) => await _dbContext.Users.AnyAsync(x => x.Email.Equals(email) && x.Active);
    }
}
