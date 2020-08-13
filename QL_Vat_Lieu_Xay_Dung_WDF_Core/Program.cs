using QL_Vat_Lieu_Xay_Dung_Services.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using QL_Vat_Lieu_Xay_Dung_Data.Entities;
using QL_Vat_Lieu_Xay_Dung_Data_EF;
using QL_Vat_Lieu_Xay_Dung_Infrastructure.Interfaces;
using QL_Vat_Lieu_Xay_Dung_Services;
using QL_Vat_Lieu_Xay_Dung_Services.AutoMapper;
using QL_Vat_Lieu_Xay_Dung_Services.Implementation;
using QL_Vat_Lieu_Xay_Dung_WDF_Core.Authorization;
using QL_Vat_Lieu_Xay_Dung_WDF_Core.Form_QuanLy;
using QL_Vat_Lieu_Xay_Dung_WDF_Core.Helpers;

namespace QL_Vat_Lieu_Xay_Dung_WDF_Core
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            #region Create IHostBuilder

            var services = Host.CreateDefaultBuilder()
                .ConfigureServices((context, serviceCollection) =>
                {
                    ConfigureServices(context.Configuration, serviceCollection);
                })
                .Build().Services;

            #endregion

            #region Đổi Form Ở Đây
            // Doi Form o day

            Application.Run(services.GetRequiredService<frmDanhMucHangHoa>());

            var mainForm = services.GetRequiredService<frmLogin>();
            if (mainForm.ShowDialog() == DialogResult.OK)
            {
                Application.Run(services.GetRequiredService<frmQuanLy>());
            }

            if (mainForm.ShowDialog() == DialogResult.No)
            {
                Application.Exit();
            }
            else
            {
                Application.Run(mainForm);
            }

            #endregion
        }

        private static void ConfigureServices(IConfiguration configuration,
            IServiceCollection services)
        {
            #region Configuration Entity Framework / Identity

            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection"), o => o.MigrationsAssembly("QL_Vat_Lieu_Xay_Dung_Data_EF")));
            services.AddIdentity<AppUser, AppRole>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();
            // Configure Identity
            services.Configure<IdentityOptions>(options =>
            {
                // Password settings
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
                // Lockout settings
                options.Lockout.DefaultLockoutTimeSpan = DateTime.Now.AddHours(-5).TimeOfDay.Add(TimeSpan.FromMinutes(30));
                options.Lockout.MaxFailedAccessAttempts = 3;

                // User settings
                options.User.RequireUniqueEmail = true;
            });

            #endregion

            #region Configuration AutoMapper

            services.AddAutoMapper(typeof(Program));
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());

            });
            var mapper = mappingConfig.CreateMapper();

            #endregion

            #region Add Singleton
            services.AddSingleton(mapper);
            #endregion
            #region Add Scoped

            services.AddScoped<UserManager<AppUser>, UserManager<AppUser>>();
            services.AddScoped<RoleManager<AppRole>, RoleManager<AppRole>>();
            services.AddScoped<IUserClaimsPrincipalFactory<AppUser>, CustomClaim>();

            #endregion

            #region Add Transient
            services.AddTransient(typeof(IUnitOfWork), typeof(EntityFrameworkUnitOfWork));
            services.AddTransient(typeof(IRepository<,>), typeof(EntityFrameworkRepository<,>));
            //Services
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IProductCategoryService, ProductCategoryService>();
            services.AddTransient<IFunctionService, FunctionService>();
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<IRoleService, RoleService>();
            services.AddTransient<IBillService, BillService>();
            services.AddTransient<ISupplierService, SupplierService>();
            services.AddTransient<IProductReceiptService, ProductReceiptService>();
            services.AddTransient<IAuthorizationHandler, DocumentAuthorizationCrudHandler>();

            // Form
            //Add form vao service o day

            services.AddScoped<frmLogin>();
            services.AddTransient<frmBill_BillDetailt>();
            services.AddTransient<frmDanhMucHangHoa>();
            services.AddTransient<frmHangHoa>();
            services.AddTransient<frmUser>();
            services.AddTransient<frmMain>();
            services.AddTransient<frmManHinh>();
            services.AddTransient<frmNhomQuyen>();
            services.AddTransient<frmQuanLy>();
            services.AddTransient<frmNhaCungCap>();
            #endregion
        }
    }
}
