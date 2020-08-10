using QL_Vat_Lieu_Xay_Dung_Infrastructure.Interfaces;

namespace QL_Vat_Lieu_Xay_Dung_Data_EF
{
    public class EntityFrameworkUnitOfWork : IUnitOfWork

    {
        private readonly AppDbContext _context;

        public EntityFrameworkUnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}