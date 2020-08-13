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
using QL_Vat_Lieu_Xay_Dung_Services.Interfaces;

namespace QL_Vat_Lieu_Xay_Dung_WDF_Core
{
    public partial class frmLogin : Form
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IServiceProvider _serviceProvider;
        private readonly IUserService _userService;
        private readonly SignInManager<AppUser> _signInManager;
        public frmLogin(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IServiceProvider serviceProvider, IUserService userService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _serviceProvider = serviceProvider;
            _userService = userService;
            InitializeComponent();
        }

        private async void simpleButton1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtTenDN.Text.Trim()) && !string.IsNullOrEmpty(txtMatKhau.Text.Trim()))
            {
                var user = await _userManager.FindByNameAsync(txtTenDN.Text);
                if (user != null)
                {
                    var roles = await _userManager.GetRolesAsync(user);
                    if (roles.Count > 0)
                    {
                        //This doesn't count login failures towards account lockout
                        //To enable password failures to trigger account lockout, set lockoutOnFailure: true
                        var result = await _signInManager.CheckPasswordSignInAsync(user, txtMatKhau.Text, true);
                        if (result.Succeeded)
                        {
                            DialogResult = DialogResult.OK;
                        }
                        else if (result.IsLockedOut)
                        {
                            MessageBox.Show("Tài Khoản Của Bạn Đã Bị Khóa ! Xin Vui Lòng Liên Hệ Admin", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            MessageBox.Show("Mật Khẩu Không Chính Xác", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Bạn Không Có Quyền Truy Cập Vào Phần Mềm Này", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Tài Khoản Không Tồn Tại", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            else
            {
                MessageBox.Show("Tài Khoản Và Mật Khẩu Không Được Bỏ Trống", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void ptrThoat_Click(object sender, EventArgs e)
        {
            Close(); 
            DialogResult = DialogResult.No;
        }
    }
}
