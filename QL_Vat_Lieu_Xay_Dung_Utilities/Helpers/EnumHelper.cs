using System;

namespace QL_Vat_Lieu_Xay_Dung_Utilities.Helpers
{
    public class EnumHelper
    {
        public static T ParseEnum<T>(string value)
        {
            return (T)Enum.Parse(typeof(T), value, true);
        }
    }
}