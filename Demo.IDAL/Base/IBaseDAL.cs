using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Demo.IDAL
{
    public partial interface IBaseDAL<T> where T : class, new()
    {
        #region 添加
        /// <summary>
        /// 添加一條數據
        /// </summary>
        /// <param name="t">實體</param>
        /// <returns></returns>
        void Add(T t);
        /// <summary>
        /// 批量添加數據
        /// </summary>
        /// <param name="list">實體集合</param>
        void AddList(List<T> list);
        #endregion

        #region 刪除
        /// <summary>
        /// 刪除一條數據
        /// </summary>
        /// <param name="t">實體</param>
        /// <returns></returns>
        void Delete(T t);
        /// <summary>
        /// 批量刪除數據
        /// </summary>
        /// <param name="list">實體集合</param>
        /// <returns></returns>
        void DeleteList(List<T> list);
        #endregion

        #region 修改
        /// <summary>
        /// 修改一條數據
        /// </summary>
        /// <param name="t">實體</param>
        /// <returns></returns>
        void Update(T t);
        /// <summary>
        /// 批量修改數據
        /// </summary>
        /// <param name="list">實體集合</param>
        /// <returns></returns>
        void UpdateList(List<T> list);
        #endregion

        #region 獲取數量
        /// <summary>
        /// 獲取數量（所有）
        /// </summary>
        /// <returns></returns>
        int GetCount();
        /// <summary>
        /// 獲取數量
        /// </summary>
        /// <param name="whereLambda">條件</param>
        /// <returns></returns>
        int GetCount(Expression<Func<T, bool>> whereLambda);
        #endregion

        #region 獲取實體
        /// <summary>
        /// 獲取實體
        /// </summary>
        /// <param name="id">主鍵</param>
        /// <returns></returns>
        T GetModel(long id);
        /// <summary>
        /// 獲取實體（異步）
        /// </summary>
        /// <param name="id">主鍵</param>
        /// <returns></returns>
        Task<T> GetModelAsync(long id);
        /// <summary>
        /// 獲取實體
        /// </summary>
        /// <param name="whereLambda">條件</param>
        /// <returns></returns>
        T GetModel(Expression<Func<T, bool>> whereLambda);
        /// <summary>
        /// 獲取實體（異步）
        /// </summary>
        /// <param name="whereLambd">條件</param>
        /// <returns></returns>
        Task<T> GetModelAsync(Expression<Func<T, bool>> whereLambd);
        #endregion

        #region 獲取列表
        /// <summary>
        /// 獲取列表（所有數據）
        /// </summary>
        /// <returns></returns>
        IQueryable<T> GetList();
        /// <summary>
        /// 獲取列表
        /// </summary>
        /// <param name="whereLambda">條件</param>
        /// <returns></returns>
        IQueryable<T> GetList(Expression<Func<T, bool>> whereLambda);
        /// <summary>
        /// 根據排序獲取列表（所有數據）
        /// </summary>
        /// <typeparam name="type"></typeparam>
        /// <param name="isAsc">是否正序</param>
        /// <param name="orderByLambda">排序條件</param>
        /// <returns></returns>
        IQueryable<T> GetListSort<type>(bool isAsc, Expression<Func<T, type>> orderByLambda);
        /// <summary>
        /// 根據排序獲取列表
        /// </summary>
        /// <typeparam name="type"></typeparam>
        /// <param name="isAsc">是否正序</param>
        /// <param name="orderByLambda">排序條件</param>
        /// <param name="whereLambda">條件</param>
        /// <returns></returns>
        IQueryable<T> GetListSort<type>(bool isAsc, Expression<Func<T, type>> orderByLambda, Expression<Func<T, bool>> whereLambda);
        /// <summary>
        /// 獲取列表（sql語句）
        /// </summary>
        /// <param name="sql">sql語句</param>
        /// <param name="parameters">參數</param>
        /// <returns></returns>
        List<T> GetListSql(string sql, params object[] parameters);
        /// <summary>
        /// 異步獲取列表（sql語句）
        /// </summary>
        /// <param name="sql">sql語句</param>
        /// <param name="parameters">參數</param>
        /// <returns></returns>
        Task<List<T>> GetListSqlAsync(string sql, params object[] parameters);
        #endregion

        #region 分頁獲取列表
        /// <summary>
        /// 分頁獲取列表
        /// </summary>
        /// <typeparam name="type"></typeparam>
        /// <param name="pageSize">每頁條數</param>
        /// <param name="pageIndex">當前頁</param>
        /// <param name="isAsc">是否正序</param>
        /// <param name="orderByLambda">排序列</param>
        /// <param name="whereLambda">條件</param>
        /// <returns></returns>
        IQueryable<T> GetListByPage<type>(int pageSize, int pageIndex, bool isAsc, Expression<Func<T, type>> orderByLambda, Expression<Func<T, bool>> whereLambda);
        #endregion

        #region 執行SQL語句
        /// <summary>
        /// 執行SQL語句
        /// </summary>
        /// <param name="sql">sql語句</param>
        /// <param name="parameters">參數</param>
        bool ExecuteSql(string sql, params object[] parameters);
        /// <summary>
        /// 異步執行SQL語句
        /// </summary>
        /// <param name="sql">sql語句</param>
        /// <param name="parameters">參數</param>
        Task<bool> ExecuteSqlAsync(string sql, params object[] parameters);
        #endregion

        #region EF保存操作
        /// <summary>
        /// 保存
        /// </summary>
        /// <returns></returns>
        bool SaveChanges();
        /// <summary>
        /// 異步保存
        /// </summary>
        /// <returns></returns>
        Task<bool> SaveChangesAsync();
        #endregion
    }
}
