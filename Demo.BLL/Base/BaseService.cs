using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Demo.IDAL;

namespace Demo.BLL
{
    public abstract partial class BaseService<T> where T : class, new()
    {
        public BaseService()
        {
            SetDal();
        }

        public IBaseDAL<T> Dal;

        public abstract void SetDal();

        #region 添加
        public bool Add(T t)
        {
            Dal.Add(t);
            return Dal.SaveChanges();
        }
        public async Task<bool> AddAsync(T t)
        {
            Dal.Add(t);
            return await Dal.SaveChangesAsync();
        }
        public bool AddList(List<T> list)
        {
            Dal.AddList(list);
            return Dal.SaveChanges();
        }
        public async Task<bool> AddListAsync(List<T> list)
        {
            Dal.AddList(list);
            return await Dal.SaveChangesAsync();
        }
        #endregion

        #region 刪除
        public bool Delete(T t)
        {
            Dal.Delete(t);
            return Dal.SaveChanges();
        }
        public async Task<bool> DeleteAsync(T t)
        {
            Dal.Delete(t);
            return await Dal.SaveChangesAsync();
        }
        public bool DeleteList(List<T> list)
        {
            Dal.DeleteList(list);
            return Dal.SaveChanges();
        }
        public async Task<bool> DeleteListAsync(List<T> list)
        {
            Dal.DeleteList(list);
            return await Dal.SaveChangesAsync();
        }
        #endregion

        #region 修改
        public bool Update(T t)
        {
            Dal.Update(t);
            return Dal.SaveChanges();
        }
        public async Task<bool> UpdateAsync(T t)
        {
            Dal.Update(t);
            return await Dal.SaveChangesAsync();
        }
        public bool UpdateList(List<T> list)
        {
            Dal.UpdateList(list);
            return Dal.SaveChanges();
        }
        public async Task<bool> UpdateListAsync(List<T> list)
        {
            Dal.UpdateList(list);
            return await Dal.SaveChangesAsync();
        }
        #endregion

        #region 獲取數量
        public int GetCount()
        {
            return Dal.GetCount();
        }
        public int GetCount(Expression<Func<T, bool>> whereLambda)
        {
            return Dal.GetCount(whereLambda);
        }
        #endregion

        #region 獲取實體
        public T GetModel(long id)
        {
            return Dal.GetModel(id);
        }
        public Task<T> GetModelAsync(long id)
        {
            return Dal.GetModelAsync(id);
        }
        public T GetModel(Expression<Func<T, bool>> whereLambda)
        {
            return Dal.GetModel(whereLambda);
        }
        public Task<T> GetModelAsync(Expression<Func<T, bool>> whereLambda)
        {
            return Dal.GetModelAsync(whereLambda);
        }
        #endregion

        #region 獲取列表
        public IQueryable<T> GetList()
        {
            return Dal.GetList();
        }
        public IQueryable<T> GetList(Expression<Func<T, bool>> whereLambda)
        {
            return Dal.GetList(whereLambda);
        }
        public IQueryable<T> GetListSort<type>(bool isAsc, Expression<Func<T, type>> orderByLambda)
        {
            return Dal.GetListSort<type>(isAsc, orderByLambda);
        }
        public IQueryable<T> GetListSort<type>(bool isAsc, Expression<Func<T, type>> orderByLambda, Expression<Func<T, bool>> whereLambda)
        {
            return Dal.GetListSort(isAsc, orderByLambda, whereLambda);
        }
        public List<T> GetListSql(string sql, params object[] parameters)
        {
            return Dal.GetListSql(sql, parameters);
        }
        public async Task<List<T>> GetListSqlAsync(string sql, params object[] parameters)
        {
            return await Dal.GetListSqlAsync(sql, parameters);
        }
        #endregion

        #region 執行SQL語句
        public bool ExecuteSql(string sql, params object[] parameters)
        {
            return Dal.ExecuteSql(sql, parameters);
        }
        public async Task<bool> ExecuteSqlAsync(string sql, params object[] parameters)
        {
            return await Dal.ExecuteSqlAsync(sql, parameters);
        }
        #endregion

        #region 分頁獲取列表
        public IQueryable<T> GetListByPage<type>(int pageSize, int pageIndex, bool isAsc,
            Expression<Func<T, type>> orderByLambda, Expression<Func<T, bool>> whereLambda)
        {
            return Dal.GetListByPage(pageSize, pageIndex, isAsc, orderByLambda, whereLambda);
        }
        #endregion
    }
}
