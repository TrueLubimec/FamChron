using FamChron.Api.Entities;

namespace FamChron.Api.Repositories.Contracts
{
    public interface IUserRepository
    {
        Task<User> GetUser(int id);
    }
}
