using System.Collections.Generic;

namespace QL_Vat_Lieu_Xay_Dung_Utilities.Dtos
{
    public class PagedResult<T> : PagedResultBase where T : class
    {
        public PagedResult()
        {
            ResultList = new List<T>();
        }

        public IList<T> ResultList { get; set; }
    }
}