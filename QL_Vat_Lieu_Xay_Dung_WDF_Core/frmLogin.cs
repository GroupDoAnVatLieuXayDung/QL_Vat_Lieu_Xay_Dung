using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using QL_Vat_Lieu_Xay_Dung_Data.Entities;

namespace QL_Vat_Lieu_Xay_Dung_WDF_Core
{
    public partial class frmLogin : Form
    {
        private readonly UserManager<AppUser> _userManager;
       // private readonly IServiceProvider _serviceProvider;

        private readonly SignInManager<AppUser> _signInManager;
        public frmLogin(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            InitializeComponent();
        }

        private async void simpleButton1_Click(object sender, EventArgs e)
        {
            //if (txtTenDN.Text.Equals("Admin") && txtMatKhau.Text.Equals("123456789"))
            //{
            //    frmMain showMain = new frmMain();
            //    showMain.Show();
            //}
            //else
            //{
            //    MessageBox.Show("Ten Tai Khoan Hoac Mat Khau Khong Dung", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            if (!string.IsNullOrEmpty(txtTenDN.Text.Trim()) && !string.IsNullOrEmpty(txtMatKhau.Text.Trim()))
            {
                var user = await _userManager.FindByNameAsync(txtTenDN.Text);
                if (_userManager.GetRolesAsync(user).Result.Count > 0)
                {
                    //This doesn't count login failures towards account lockout
                    //To enable password failures to trigger account lockout, set lockoutOnFailure: true

                    var result = await _signInManager.PasswordSignInAsync(user, txtMatKhau.Text, false, true);
                    if (result.Succeeded)
                    {
                        DialogResult = DialogResult.OK;
                        //var form = _serviceProvider.GetRequiredService<frmHangHoa>();
                        //form.ShowDialog(this);


                    }
                    else if (result.IsLockedOut)
                    {
                        MessageBox.Show("Tài Khoản Của Bạn Đã Bị Khóa ! Xin Vui Lòng Liên Hệ Admin", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("Tài Khoản Hoặc Mật Khẩu Không Chính Xác", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Tài Khoản Và Mật Khẩu Không Được Bỏ Trống", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }




        }

        private void ptrThoat_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
