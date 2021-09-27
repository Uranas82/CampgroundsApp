﻿using Persistence.Models.ReadModels;
using Persistence.Models.WriteModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class CampgroundRepository : ICampgroundRepository
    {
        private readonly ISqlClient _sqlClient;
        private const string TableName = "campground";

        public CampgroundRepository(ISqlClient sqlClient)
        {
            _sqlClient = sqlClient;
        }

        public Task<IEnumerable<CampgroundReadModel>> GetAllAsync()
        {
            var sql = $"SELECT * FROM {TableName}";

            return _sqlClient.QueryAsync<CampgroundReadModel>(sql);
        }

        public Task<CampgroundReadModel> GetAsync(Guid id)
        {
            var sql = $"SELECT * FROM {TableName} WHERE Id = @Id";

            return _sqlClient.QueryFirstOrDefaultAsync<CampgroundReadModel>(sql, new { Id = id });
        }

        public Task<CampgroundReadModel> GetAsync(Guid id, Guid userId)
        {
            var sql = $"SELECT * FROM {TableName} WHERE Id = @Id AND UserId = @UserId";

            return _sqlClient.QueryFirstOrDefaultAsync<CampgroundReadModel>(sql, new { Id = id, UserId = userId });
        }

        public Task<int> SaveOrUpdateAsync(CampgroundWriteModel model)
        {
            var sql = @$"INSERT INTO {TableName} (Id, UserId, Name, Price, Description, DateCreated) 
            VALUES(@Id, @UserId, @Name, @Price, @Description, @DateCreated) 
            ON DUPLICATE KEY UPDATE Name = @Name, Price = @Price, Description = @Description;";

            return _sqlClient.ExecuteAsync(sql, model);
        }

        public Task<int> DeleteAsync(Guid id)
        {
            var sql = $"DELETE FROM {TableName} WHERE Id = @Id;";

            return _sqlClient.ExecuteAsync(sql, new { Id = id });
        }
    }
}
