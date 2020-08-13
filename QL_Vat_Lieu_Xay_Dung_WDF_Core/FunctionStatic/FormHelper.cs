using DevExpress.CodeParser;
using DevExpress.Mvvm.Native;
using DevExpress.XtraGrid.EditForm.Helpers;
using QL_Vat_Lieu_Xay_Dung_Utilities.Dtos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace QL_Vat_Lieu_Xay_Dung_WDF_Core.FunctionStatic
{
    public class FormHelper
    {
        public static void closeForm(Form frm, FormClosingEventArgs e)
        {
            DialogResult rs = MessageBox.Show("Bạn có chắc chắn muốn thoát chương trình !","EXITS DIALOG",
                MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button2);
            if (rs == DialogResult.No)
                e.Cancel = true;
        }
        public static DialogResult showRemoveDialog(string mess)
        {
            return  MessageBox.Show("Bạn có chắc muốn xoá " + mess + " này ?", "Are you sure ?", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);  
        }
        public static DialogResult showSuccessDialog(string mess,string caption)
        {
            return MessageBox.Show(mess, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public static DialogResult showErrorDialog(string mess,object err, string caption)
        {
            return MessageBox.Show(mess + err.ToString(), caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public static void showDialog(GenericResult rs)
        {
            if (rs.Success)
                FormHelper.showSuccessDialog(rs.Message, rs.Caption);
            else
                FormHelper.showErrorDialog(rs.Message, rs.Error, rs.Caption);
        }
        public static string chonFileNameHinhAnh()
        {
            OpenFileDialog of = new OpenFileDialog();
            of.Filter = "All Files|*.*|JPEGs|*.jpg|Bitmaps|*.bmp|GIFs|*.gif|PNG|*.png";
            DialogResult res = of.ShowDialog();
            return res == DialogResult.OK ? of.FileName : null;
        }
        public static string copyHinh(string fNguon)
        {
            if (string.IsNullOrEmpty(fNguon))
                return string.Empty;
            DateTime dt = DateTime.Now;
            string fDich = string.Format("sp{0}_{1}_{2}_{3}_{4}_{5}.jpg", dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, dt.Second);
            File.Copy(fNguon, "@" + fDich +"/img_ds/");
            return fDich;
        }
    }
}
