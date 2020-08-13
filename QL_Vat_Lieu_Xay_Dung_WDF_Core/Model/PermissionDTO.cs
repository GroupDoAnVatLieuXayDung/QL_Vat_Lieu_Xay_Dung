using System;
using System.Collections.Generic;
using System.Text;

namespace QL_Vat_Lieu_Xay_Dung_WDF_Core.Model
{
    public class PermissionDTO
    {
        public string RoleId { get; set; }
        public string FunctionId { get; set; }
        public string Name { get; set; }
        public bool CanRead { set; get; }
        public bool CanCreate { set; get; }
        public bool CanUpdate { set; get; }
        public bool CanDelete { set; get; }

    }
}
