using Dapper;
using FamChron.JwtService.Entities;
using FamChron.JwtService.Repositories.Contracts;
using FamChron.Models.Dtos;


namespace FamChron.JwtService.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly AuthDbContext authDbContext;

        public AuthRepository(AuthDbContext authDbContext)
        {
            this.authDbContext = authDbContext;
        }
        public async Task AddToken(AuthResponse token)
        {
            using var connection = authDbContext.CreateConnection();
            var sqlRequest = """INSERT INTO tokens (token, user_name, expires) VALUES (@Token, @UserName, @Expiration);""";
            await connection.ExecuteAsync(sqlRequest, token);
        }

        //public async Task<User> Regitration(RegistrationUserDto @user)
        //{
        //    string passwordHash
        //         = BCrypt.Net.BCrypt.HashPassword(@user.Password);
        //    var newUser = new User
        //    {
        //        id = @user.Id,
        //        UserName = @user.Name,
        //        PasswordHash = passwordHash
        //    };

        //    if (@user != null)
        //    {
        //        var result = await this.famChronDbContext.Users.AddAsync(newUser);
        //        await this.famChronDbContext.SaveChangesAsync();
        //        return result.Entity;
        //    }
        //    return null;
        //}
    }
}
