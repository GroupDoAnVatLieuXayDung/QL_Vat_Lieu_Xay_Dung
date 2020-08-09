using QL_Vat_Lieu_Xay_Dung_Infrastructure.SharedKernel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QL_Vat_Lieu_Xay_Dung_Data.Entities
{
    [Table("ProductReceiptDetails")]
    public class ProductReceiptDetail : DomainEntity<int>
    {
        public ProductReceiptDetail()
        {
        }

        [Required]
        [Column(Order = 1)]
        public int ProductId { get; set; }

        [Required]
        [Column(Order = 2)]
        public int SizeId { get; set; }

        [Required]
        [Column(Order = 3)]
        public int ProductReceiptId { get; set; }

        public int Quantity { get; set; }

        // Giá gốc khi nhập hàng vào
        [Required]
        public decimal OriginalPrice { get; set; }

        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }

        [ForeignKey("SizeId")]
        public virtual Size Size { get; set; }

        [ForeignKey("ProductReceiptId")]
        public virtual ProductReceipt ProductReceipt { get; set; }
    }
}