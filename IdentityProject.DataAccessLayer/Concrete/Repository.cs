﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using IdentityProject.DataAccessLayer.Abstract;
using IdentityProject.DataAccessLayer.DbContext;
using IdentityProject.EntityLayer.Infrastructure;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace IdentityProject.DataAccessLayer.Concrete
{
    public class Repository<T> : IRepository<T> where T : class
    {

        private DatabaseContext _context;
        private readonly DbContextOptions<DatabaseContext> _dbOptions;

        public Repository(DatabaseContext context, DbContextOptions<DatabaseContext> dbOptions)
        {
            _context = context;
            _dbOptions = dbOptions;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<T> GetFirstOrDefaultAsync(Expression<Func<T, bool>> predicate = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
            bool disableTracking = true,
            bool ignoreQueryFilters = false)
        {
            using (var context = new DatabaseContext(_dbOptions))
            {
                var dbSet = context.Set<T>();

                IQueryable<T> query = dbSet;

                if (disableTracking)
                {
                    query = query.AsNoTracking();
                }

                if (include != null)
                {
                    query = include(query);
                }

                if (predicate != null)
                {
                    query = query.Where(predicate);
                }

                if (ignoreQueryFilters)
                {
                    query = query.IgnoreQueryFilters();
                }

                if (orderBy != null)
                {
                    return await orderBy(query).FirstOrDefaultAsync();
                }
                else
                {
                    return await query.FirstOrDefaultAsync();
                }
            }
        }

        public async Task<List<T>> GetListAsync(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null, int pageIndex = 0, int pageSize = 20, bool disableTracking = true, CancellationToken cancellationToken = default, bool ignoreQueryFilters = false)
        {
            using (var context = new DatabaseContext(_dbOptions))
            {
                var dbSet = context.Set<T>();
                IQueryable<T> query = dbSet;

                if (disableTracking)
                {
                    query = query.AsNoTracking();
                }
                if (include != null)
                {
                    query = include(query);
                }

                if (predicate != null)
                {
                    query = query.Where(predicate);
                }

                if (ignoreQueryFilters)
                {
                    query = query.IgnoreQueryFilters();
                }

                if (orderBy != null)
                {
                    return await orderBy(query).ToListAsync(cancellationToken).ConfigureAwait(false);
                }
                else
                {
                    return await query.ToListAsync(cancellationToken).ConfigureAwait(false);
                }
            }

        }

        public async Task<int> SaveAsync(T item)
        {
            try
            {
                using (var context = new DatabaseContext(_dbOptions))
                {

                    PropertyInfo[] virtualProperties = typeof(T).GetProperties().Where(x => !x.GetAccessors()[0].IsFinal && x.GetAccessors()[0].IsVirtual).ToArray();

                    foreach (var property in virtualProperties)
                    {
                        property.SetValue(item, null);
                    }


                    var dbSet = context.Set<T>();

                    dbSet.Attach(item);

                    var state = item.GetType().GetProperty("EntityState")?.GetValue(item).ToString();

                    if (state != "Added")
                    {
                        context.Entry(item).State = EntityState.Modified;

                    }

                    var list = _context.ChangeTracker.Entries<Base>().ToList();
                    foreach (var entry in list)
                    {
                        var entity = entry.Entity;
                        entry.State = GetEntityState(entity.EntityState);
                    }

                    try
                    {
                        await context.SaveChangesAsync();
                        var result = Convert.ToInt32(context.Entry(item).GetDatabaseValues()["Id"].ToString());
                        context.Entry(item).State = EntityState.Detached;
                        return result;

                    }
                    catch (Exception ex)
                    {
                        context.Entry(item).State = EntityState.Detached;
                        //  throw ex;
                        if (!(ex.GetBaseException() is SqlException)) throw;
                        if (ex.InnerException == null) throw;

                        var errorCode = ((SqlException)ex.InnerException).Number;
                        switch (errorCode)
                        {
                            case 2627:  // Unique constraint error
                                throw new(
                                    "Aynı değeri iki kez eklemeye çalışıyorsunuz. Ayrıntılı bilgi için loglara bakınız!  ", ex.InnerException);

                            case 547:   // Constraint check violation
                                throw new (
                                    "Veri tabanına olması gereken veri dışında veri ekliyorsunuz. Ayrıntılı bilgi için loglara bakınız! ", ex.InnerException
                                    );
                            case 2601:  // Duplicated key row error
                                throw new (
                                    "Aynı ID değerini iki kez eklemeye çalışıyorsunuz. Ayrıntılı bilgi için loglara bakınız!  ", ex.InnerException);
                        }
                        throw;
                    }
                }

            }
            catch (Exception ex) //DbEntityValidationException ex
            {
                throw ex;
            }
        }

        protected static EntityState GetEntityState(EntityState entityState)
        {
            switch (entityState)
            {
                case EntityState.Unchanged:
                    return EntityState.Unchanged;
                case EntityState.Added:
                    return EntityState.Added;
                case EntityState.Modified:
                    return EntityState.Modified;
                case EntityState.Deleted:
                    return EntityState.Deleted;
                case EntityState.Detached:
                    return EntityState.Detached;
            }
            return EntityState.Detached;
        }
    }
}