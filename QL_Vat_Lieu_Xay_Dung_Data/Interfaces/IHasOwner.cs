namespace QL_Vat_Lieu_Xay_Dung_Data.Interfaces
{
    public interface IHasOwner<T>
    {
        public T OwnerId { get; set; }
    }
}