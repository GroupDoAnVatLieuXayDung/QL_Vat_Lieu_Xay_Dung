using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using QL_Vat_Lieu_Xay_Dung_Data.Enums;
using QL_Vat_Lieu_Xay_Dung_Data.Interfaces;
using QL_Vat_Lieu_Xay_Dung_Infrastructure.SharedKernel;

namespace QL_Vat_Lieu_Xay_Dung_Data.Entities
{
    [Table("ProductReceipts")]
    public class ProductReceipt : DomainEntity<int>,IDateTracking
    {
        public ProductReceipt()
        {
            
        }
        public int SupplierId { get; set; }
        [DefaultValue(0)]
        public decimal Total { get; set; }
        public DateTime DateCreated { get; set; }
        public Guid? UserId { set; get; }
        [ForeignKey("UserrId")]
        public virtual AppUser User { set; get; }
        public DateTime DateModified { get; set; }
        public ReceiptStatus ReceiptStatus { set; get; }
        [ForeignKey("SupplierId")]
        public virtual Supplier Supplier { get; set; }
        //Đây là mối quan hệ 1 - nhiều (1 danh mục nhiều receipt)
        public virtual ICollection<ProductReceiptDetail> ProductReceiptDetails { get; set; }
    }
}
