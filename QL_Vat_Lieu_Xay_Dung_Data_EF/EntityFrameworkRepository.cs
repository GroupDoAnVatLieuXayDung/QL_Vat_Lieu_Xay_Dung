using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QL_Vat_Lieu_Xay_Dung_Infrastructure.Interfaces;
using QL_Vat_Lieu_Xay_Dung_Infrastructure.SharedKernel;

namespace QL_Vat_Lieu_Xay_Dung_Data_EF
{
    public class EntityFrameworkRepository<T, K>: IRepository<T, K>,IDisposable where T: DomainEntity<K>
    {
        private readonly AppDbContext _context;

        public EntityFrameworkRepository(AppDbContext context)
        {
            _context = context;
        }
        public T FindById(K id)
        {
            return _context.Set<T>().SingleOrDefault(c => c.Id.Equals(id));
        }

        public T FindSingle(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().SingleOrDefault(predicate);
        }

        public IQueryable<T> FindAll()
        {
            return _context.Set<T>();

        }

        public bool CheckByAny(T entity)
        {
            return _context.Set<T>().Any();
        }

        public bool CheckByAny(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Any(predicate);
        }

        public IQueryable<T> FindAll(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Where(predicate);
        }

        public T FindFirstOrDefault(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().FirstOrDefault(predicate);
        }

        //public T FindById(K id, params Expression<Func<T, object>>[] includeProperties)
        //{
        //    return FindAll(includeProperties).SingleOrDefault(c => c.Id.Equals(id));
        //}

        //public T FindSingle(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        //{
        //    return FindAll(includeProperties).SingleOrDefault(predicate);
        //}

        //public IQueryable<T> FindAll(params Expression<Func<T, object>>[] includeProperties)
        //{
        //    IQueryable<T> items = _context.Set<T>();
        //    if (includeProperties != null)
        //    {
        //        #region C1 dùng Foreach

        //        //foreach (var includeProperty in includeProperties)
        //        //{
        //        //    items = items.Include(includeProperty);
        //        //}
        //        #endregion

        //        #region C2 dùng Linq-Expression
        //        // Aggregate trong linq là 	Thực thi 1 toán tử tổng hợp tự tạo dựa trên giá trị của 1 tập dữ liệu.
        //        // current là biến items bị ẩn nó tương đương vs items.Include(includeProperty) , includeProperty biến trong foreach
        //         items = includeProperties.Aggregate(items, (current, includeProperty) => current.Include(includeProperty));
        //        #endregion
        //    }
        //    return items;

        //}

        //public IQueryable<T> FindAll(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        //{
        //    IQueryable<T> items = _context.Set<T>();



        //        // Aggregate trong linq là 	Thực thi 1 toán tử tổng hợp tự tạo dựa trên giá trị của 1 tập dữ liệu.
        //        // current là biến items bị ẩn nó tương đương vs items.Include(includeProperty) , includeProperty biến trong foreach
        //        items = includeProperties.Aggregate(items, (current, includeProperty) => current.Include(includeProperty));
        //        return items.Where(predicate);
        //}

        public void Add(T entity)
        {
            _context.Add(entity);
        }

        public void AddMultiple(List<T> entities)
        {
            _context.Set<T>().AddRange(entities);
        }


        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }
        public void UpdateMultiple(List<T> entities)
        {
            _context.Set<T>().UpdateRange(entities);
        }
        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public void Remove(K id)
        {
            Remove(FindById(id));
        }

        public void RemoveMultiple(List<T> entities)
        {
            _context.Set<T>().RemoveRange(entities);
        }

        public void Dispose()
        {
            // _context != null thì gọi hàm này để thu hồi bộ nhớ
            _context?.Dispose();
        }
    }
}
