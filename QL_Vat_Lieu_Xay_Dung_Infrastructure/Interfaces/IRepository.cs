using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace QL_Vat_Lieu_Xay_Dung_Infrastructure.Interfaces
{
    // T là 1 class còn U là kiểu dữ liệu truyền vào
    public interface IRepository<T, K> where T : class
    {
        /// <summary>
        /// params Expression<Func<T, object>>[] là 1 danh sách các cái tham số nó sẽ trả về 1 object
        /// </summary>
        /// <param name="id"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        T FindById(K id);
        T FindSingle(Expression<Func<T, bool>> predicate);
        IQueryable<T> FindAll(Expression<Func<T, bool>> predicate);
        T FindFirstOrDefault(Expression<Func<T, bool>> predicate);
        IQueryable<T> FindAll();



        //T FindById(K id, params Expression<Func<T, object>>[] includeProperties);

        //T FindSingle(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);

        //IQueryable<T> FindAll(params Expression<Func<T, object>>[] includeProperties);

        //IQueryable<T> FindAll(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);

        void Add(T entity);

        void Update(T entity);

        void Remove(T entity);

        void Remove(K id);

        void RemoveMultiple(List<T> entities);
    }
}
