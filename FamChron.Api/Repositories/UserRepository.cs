using FamChron.Api.Data;
using FamChron.Api.Entities;
using FamChron.Api.Repositories.Contracts;

namespace FamChron.Api.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly FamChronDbContext famChronDbContext;

        public UserRepository(FamChronDbContext famChronDbContext)
        {
            this.famChronDbContext = famChronDbContext;
        }
        public async Task<User> GetUser(int id)
        {
            var user = await this.famChronDbContext.Users.FindAsync(id);
            return user;
        }
    }
}
