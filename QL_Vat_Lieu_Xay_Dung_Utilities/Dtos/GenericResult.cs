using System;
using System.Collections.Generic;
using System.Text;

namespace QL_Vat_Lieu_Xay_Dung_Utilities.Dtos
{
    public class GenericResult
    {
        public GenericResult()
        {
        }

        public GenericResult(bool success)
        {
            Success = success;
        }

        public GenericResult(bool success, string message)
        {
            Success = success;
            Message = message;
        }
        public GenericResult(bool success, string message, string caption)
        {
            Success = success;
            Message = message;
            Caption = caption;
        }
        public GenericResult(bool success,string error, string message, string caption)
        {
            Success = success;
            Error = error;
            Message = message;
            Caption = caption;
        }
        public GenericResult(bool success, object data)
        {
            Success = success;
            Data = data;
        }

        public object Data { get; set; }

        public bool Success { get; set; }

        public string Message { get; set; }

        public object Error { get; set; }
        public string Caption { get; set; }
    }
}
