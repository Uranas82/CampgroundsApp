﻿using Persistence.Models.ReadModels;
using Persistence.Models.WriteModels;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ISqlClient _sqlClient;
        private const string TableName = "user";

        public UserRepository(ISqlClient sqlClient)
        {
            _sqlClient = sqlClient;
        }

        public Task<UserReadModel> GetAsync(string localId)
        {
            var sql = $"SELECT * FROM {TableName} WHERE LocalId = @LocalId";

            return _sqlClient.QueryFirstOrDefaultAsync<UserReadModel>(sql, new { LocalId = localId });
        }

        public Task<int> SaveUserAsync(UserWriteModel user)
        {
            var sql = $"INSERT INTO {TableName} (Id, Email, LocalId) VALUES(@Id, @Email, @LocalId)";

            return _sqlClient.ExecuteAsync(sql, user);
        }
    }
}
