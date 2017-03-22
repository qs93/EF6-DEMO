using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity;
using System.Data.Entity.Migrations;

namespace Demo.DAL
{
    public partial class BaseDAL<T> where T : class, new()
    {
        private DbContext dbContext = DbContextFactory.Create();

        #region 增加
        public void Add(T t)
        {
            dbContext.Set<T>().Add(t);
        }
        public void AddList(List<T> list)
        {
            dbContext.Set<T>().AddRange(list);
        }
        #endregion

        #region 刪除
        public void Delete(T t)
        {
            dbContext.Set<T>().Remove(t);
        }
        public void DeleteList(List<T> list)
        {
            dbContext.Set<T>().RemoveRange(list);
        }
        #endregion

        #region 修改
        public void Update(T t)
        {
            //dbContext.Set<T>().AddOrUpdate(t);
            dbContext.Entry(t).State = EntityState.Modified;
        }
        public void UpdateList(List<T> list)
        {
            dbContext.Entry(list).State = EntityState.Modified;
        }
        #endregion

        #region 獲取數量
        /// <returns></returns>
        public int GetCount()
        {
            return dbContext.Set<T>().Count();
        }
        public int GetCount(Expression<Func<T, bool>> whereLambda)
        {
            return dbContext.Set<T>().Count(whereLambda);
        }
        #endregion

        #region 獲取實體
        public T GetModel(long id)
        {
            return dbContext.Set<T>().Find(id);
        }
        public Task<T> GetModelAsync(long id)
        {
            return dbContext.Set<T>().FindAsync(id);
        }
        public T GetModel(Expression<Func<T, bool>> whereLambd)
        {
            return dbContext.Set<T>().LastOrDefault(whereLambd);
        }
        public Task<T> GetModelAsync(Expression<Func<T, bool>> whereLambd)
        {
            return dbContext.Set<T>().FirstOrDefaultAsync(whereLambd);
        }
        #endregion

        #region 獲取列表
        public IQueryable<T> GetList()
        {
            return dbContext.Set<T>();
        }
        public IQueryable<T> GetList(Expression<Func<T, bool>> whereLambda)
        {
            return dbContext.Set<T>().Where(whereLambda);
        }
        public IQueryable<T> GetListSort<type>(bool isAsc, Expression<Func<T, type>> orderByLambda)
        {
            if (isAsc)
            {
                return dbContext.Set<T>().OrderBy(orderByLambda);
            }
            else
            {
                return dbContext.Set<T>().OrderByDescending(orderByLambda);
            }
        }
        public IQueryable<T> GetListSort<type>(bool isAsc, Expression<Func<T, type>> orderByLambda, Expression<Func<T, bool>> whereLambda)
        {
            if (isAsc)
            {
                return dbContext.Set<T>().Where(whereLambda).OrderBy(orderByLambda);
            }
            else
            {
                return dbContext.Set<T>().Where(whereLambda).OrderByDescending(orderByLambda);
            }
        }
        public List<T> GetListSql(string sql, params object[] parameters)
        {
            return dbContext.Database.SqlQuery<T>(sql, parameters).ToList();
        }
        public async Task<List<T>> GetListSqlAsync(string sql, params object[] parameters)
        {
            return await dbContext.Database.SqlQuery<T>(sql, parameters).ToListAsync();
        }
        #endregion

        #region 分頁獲取列表
        public IQueryable<T> GetListByPage<type>(int pageSize, int pageIndex, bool isAsc,
            Expression<Func<T, type>> orderByLambda, Expression<Func<T, bool>> whereLambda)
        {
            //是否升序
            if (isAsc)
            {
                return dbContext.Set<T>().Where(whereLambda).OrderBy(orderByLambda).Skip((pageIndex - 1) * pageSize).Take(pageSize);
            }
            else
            {
                return dbContext.Set<T>().Where(whereLambda).OrderByDescending(orderByLambda).Skip((pageIndex - 1) * pageSize).Take(pageSize);
            }
        }
        #endregion

        #region 執行SQL語句
        public bool ExecuteSql(string sql, params object[] parameters)
        {
            return dbContext.Database.ExecuteSqlCommand(sql, parameters) > 0;
        }
        public async Task<bool> ExecuteSqlAsync(string sql, params object[] parameters)
        {
            return await dbContext.Database.ExecuteSqlCommandAsync(sql, parameters) > 0;
        }
        #endregion

        #region EF保存操作
        public bool SaveChanges()
        {
            return dbContext.SaveChanges() > 0;
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await dbContext.SaveChangesAsync() > 0;
        }
        #endregion
    }
}
