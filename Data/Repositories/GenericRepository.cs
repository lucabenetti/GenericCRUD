using Data.Context;
using GenericCore.Pagination;
using GenericDomain.Entities;
using GenericDomain.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class GenericRepository : IGenericRepository
    {
        protected GenericDbContext Db;

        public GenericRepository(GenericDbContext genericDbContext)
        {
            Db = genericDbContext;
        }
        
        public async Task Add<T>(T entity) where T : BaseEntity
        {
            await Db.Set<T>().AddAsync(entity);
        }
        
        public void Delete<T>(T entity) where T : BaseEntity
        {
            Db.Set<T>().Remove(entity);
        }

        public async Task<T> GetById<T>(Guid id) where T : BaseEntity
        {
            return await Db.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<PaginatedResult<T>> GetPaginated<T>(PaginatedInput input) where T : BaseEntity
        {
            return await Db.Set<T>().PaginateAsync(input);
        }
        
        public async Task CommitAsync()
        {
            await Db.SaveChangesAsync();
        }
    }
}
