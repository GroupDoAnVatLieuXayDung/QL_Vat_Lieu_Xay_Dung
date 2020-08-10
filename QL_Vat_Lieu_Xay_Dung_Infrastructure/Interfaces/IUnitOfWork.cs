using System;

namespace QL_Vat_Lieu_Xay_Dung_Infrastructure.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Khi gọi sẽ lưu dữ liệu thay đổi đến DbContext
        /// </summary>
        void Commit();
    }
}