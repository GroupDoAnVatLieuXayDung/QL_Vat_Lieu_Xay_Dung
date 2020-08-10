namespace QL_Vat_Lieu_Xay_Dung_Data.Interfaces
{
    public interface IHasSeoMetaData
    {
        public string SeoPageTitle { get; set; }

        public string SeoAlias { get; set; }

        public string SeoKeywords { get; set; }

        public string SeoDescription { get; set; }
    }
}