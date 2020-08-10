using System.ComponentModel;

namespace QL_Vat_Lieu_Xay_Dung_Data.Enums
{
    public enum PaymentMethod
    {
        // Trả hàng lúc nhận tiền
        [Description("Cash On Delivery")]
        CashOnDelivery,

        // Trả tiền qua ngân hàng nội địa
        [Description("Online Banking")]
        OnlineBanking,

        // Trả tiền qua Ví điện tử
        [Description("Payment Gateway")]
        PaymentGateway,

        [Description("Visa")]
        Visa,

        [Description("Master Card")]
        MasterCard,

        [Description("PayPal")]
        PayPal
    }
}