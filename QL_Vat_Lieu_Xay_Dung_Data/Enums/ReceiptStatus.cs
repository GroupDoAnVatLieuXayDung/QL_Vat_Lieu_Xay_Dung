using System.ComponentModel;

namespace QL_Vat_Lieu_Xay_Dung_Data.Enums
{
    public enum ReceiptStatus
    {
        [Description("In Progress")]
        InProgress,
        [Description("Returned")]
        Returned,
        [Description("Cancelled")]
        Cancelled,
        [Description("Completed")]
        Completed
    }
}