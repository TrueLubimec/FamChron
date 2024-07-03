using Dapper;
using FamChron.JwtService.Data;
using Microsoft.Extensions.Options;
using Npgsql;
using System.Data;

public class AuthDbContext
{
    private readonly DbSettings dbSettings;

    public AuthDbContext(IOptions<DbSettings> dbSettings)
    {
        this.dbSettings = dbSettings.Value;
    }

    public IDbConnection CreateConnection()
    {
        var connectionString = $"host={dbSettings.Server} dbname={dbSettings.Database} user={dbSettings.User} password={dbSettings.Password} connection_timeout={dbSettings.ConnectionTimeOut}";
        return new NpgsqlConnection(connectionString);
    }

    public async Task Init()
    {
        await _initDatabase();
        await _initTables();
    }

    private async Task _initDatabase()
    {
        // create database if it doesn't exist
        var connectionString = $"host={dbSettings.Server} dbname={dbSettings.Database} user={dbSettings.User} password={dbSettings.Password} connection_timeout={dbSettings.ConnectionTimeOut}";
        using var connection = new NpgsqlConnection(connectionString);
        var sqlDbCount = $"SELECT COUNT(*) FROM pg_database WHERE datname = '{dbSettings.Database}';";
        var dbCount = await connection.ExecuteScalarAsync<int>(sqlDbCount);
        if (dbCount == 0)
        {
            var sql = $"CREATE DATABASE \"{dbSettings.Database}\"";
            await connection.ExecuteAsync(sql);
        }
    }

    private async Task _initTables()
    {
        // create tables if they don't exist
        using var connection = CreateConnection();
        await _initUsers();

        async Task _initUsers()
        {
            var sql = """
            CREATE TABLE IF NOT EXISTS Users (
                Id SERIAL PRIMARY KEY,
                Name VARCHAR,
                Email VARCHAR,
                Role INTEGER,
                PasswordHash VARCHAR
            );
        """;
            await connection.ExecuteAsync(sql);
        }
    }
    
}