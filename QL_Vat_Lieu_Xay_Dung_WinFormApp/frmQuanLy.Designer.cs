namespace QL_Vat_Lieu_Xay_Dung_WinFormApp
{
    partial class frmQuanLy
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.Container = new DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormContainer();
            this.ribbonStatusBar1 = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnManHinh = new DevExpress.XtraBars.BarButtonItem();
            this.barCheckItem1 = new DevExpress.XtraBars.BarCheckItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.btnNhomQuyen = new DevExpress.XtraBars.BarButtonItem();
            this.btnNguoiDung = new DevExpress.XtraBars.BarButtonItem();
            this.btnNhaCungCap = new DevExpress.XtraBars.BarButtonItem();
            this.btnHangHoa = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
            this.tabPhanQuyen = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.gruopManHinh = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.gruopNhomQuyen = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.gruopNguoiDung = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.tabQuanLy = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.fluentDesignFormControl1 = new DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl();
            this.Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fluentDesignFormControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // Container
            // 
            this.Container.Controls.Add(this.ribbonStatusBar1);
            this.Container.Controls.Add(this.ribbonControl1);
            this.Container.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Container.Location = new System.Drawing.Point(0, 39);
            this.Container.Name = "Container";
            this.Container.Size = new System.Drawing.Size(1081, 684);
            this.Container.TabIndex = 0;
            // 
            // ribbonStatusBar1
            // 
            this.ribbonStatusBar1.Location = new System.Drawing.Point(0, 656);
            this.ribbonStatusBar1.Name = "ribbonStatusBar1";
            this.ribbonStatusBar1.Ribbon = this.ribbonControl1;
            this.ribbonStatusBar1.Size = new System.Drawing.Size(1081, 28);
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.ribbonControl1.SearchEditItem,
            this.btnManHinh,
            this.barCheckItem1,
            this.barButtonItem1,
            this.btnNhomQuyen,
            this.btnNguoiDung,
            this.btnNhaCungCap,
            this.btnHangHoa,
            this.barButtonItem2,
            this.barButtonItem3});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 11;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.tabPhanQuyen,
            this.tabQuanLy});
            this.ribbonControl1.Size = new System.Drawing.Size(1081, 178);
            this.ribbonControl1.StatusBar = this.ribbonStatusBar1;
            // 
            // btnManHinh
            // 
            this.btnManHinh.Caption = "Màn hình";
            this.btnManHinh.Hint = "Quản lý màn hình";
            this.btnManHinh.Id = 2;
            this.btnManHinh.ImageOptions.Image = global::QL_Vat_Lieu_Xay_Dung_WinFormApp.Properties.Resources.selectall_16x16;
            this.btnManHinh.ImageOptions.LargeImage = global::QL_Vat_Lieu_Xay_Dung_WinFormApp.Properties.Resources.selectall_32x32;
            this.btnManHinh.Name = "btnManHinh";
            this.btnManHinh.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnManHinh.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnManHinh_ItemClick);
            // 
            // barCheckItem1
            // 
            this.barCheckItem1.Caption = "barCheckItem1";
            this.barCheckItem1.Id = 3;
            this.barCheckItem1.Name = "barCheckItem1";
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "Nhóm quyền";
            this.barButtonItem1.Hint = "Quản lý nhóm quyền";
            this.barButtonItem1.Id = 4;
            this.barButtonItem1.ImageOptions.Image = global::QL_Vat_Lieu_Xay_Dung_WinFormApp.Properties.Resources.usergroup_16x16;
            this.barButtonItem1.ImageOptions.LargeImage = global::QL_Vat_Lieu_Xay_Dung_WinFormApp.Properties.Resources.usergroup_32x32;
            this.barButtonItem1.Name = "barButtonItem1";
            this.barButtonItem1.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // btnNhomQuyen
            // 
            this.btnNhomQuyen.Caption = "Nhóm quyền";
            this.btnNhomQuyen.Hint = "Quản lý nhóm quyền";
            this.btnNhomQuyen.Id = 5;
            this.btnNhomQuyen.ImageOptions.Image = global::QL_Vat_Lieu_Xay_Dung_WinFormApp.Properties.Resources.usergroup_32x32;
            this.btnNhomQuyen.Name = "btnNhomQuyen";
            this.btnNhomQuyen.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnNhomQuyen.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnNhomQuyen_ItemClick);
            // 
            // btnNguoiDung
            // 
            this.btnNguoiDung.Caption = "Người dùng";
            this.btnNguoiDung.Hint = "Quản lý người dùng";
            this.btnNguoiDung.Id = 6;
            this.btnNguoiDung.ImageOptions.SvgImage = global::QL_Vat_Lieu_Xay_Dung_WinFormApp.Properties.Resources.actions_user1;
            this.btnNguoiDung.Name = "btnNguoiDung";
            this.btnNguoiDung.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnNguoiDung.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnNguoiDung_ItemClick);
            // 
            // btnNhaCungCap
            // 
            this.btnNhaCungCap.Caption = "Nhà cung cấp";
            this.btnNhaCungCap.Id = 7;
            this.btnNhaCungCap.ImageOptions.SvgImage = global::QL_Vat_Lieu_Xay_Dung_WinFormApp.Properties.Resources.actions_user;
            this.btnNhaCungCap.Name = "btnNhaCungCap";
            this.btnNhaCungCap.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnNhaCungCap.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnNhaCungCap_ItemClick);
            // 
            // btnHangHoa
            // 
            this.btnHangHoa.Caption = "Hàng hoá";
            this.btnHangHoa.Id = 8;
            this.btnHangHoa.ImageOptions.Image = global::QL_Vat_Lieu_Xay_Dung_WinFormApp.Properties.Resources.boproductgroup_16x16;
            this.btnHangHoa.ImageOptions.LargeImage = global::QL_Vat_Lieu_Xay_Dung_WinFormApp.Properties.Resources.boproductgroup_32x32;
            this.btnHangHoa.Name = "btnHangHoa";
            this.btnHangHoa.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnHangHoa.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnHangHoa_ItemClick);
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "Danh mục hàng hoá";
            this.barButtonItem2.Id = 9;
            this.barButtonItem2.ImageOptions.Image = global::QL_Vat_Lieu_Xay_Dung_WinFormApp.Properties.Resources.tableofcontent_16x16;
            this.barButtonItem2.ImageOptions.LargeImage = global::QL_Vat_Lieu_Xay_Dung_WinFormApp.Properties.Resources.tableofcontent_32x32;
            this.barButtonItem2.Name = "barButtonItem2";
            this.barButtonItem2.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem2_ItemClick);
            // 
            // barButtonItem3
            // 
            this.barButtonItem3.Caption = "Hoá đơn bán hàng";
            this.barButtonItem3.Id = 10;
            this.barButtonItem3.ImageOptions.Image = global::QL_Vat_Lieu_Xay_Dung_WinFormApp.Properties.Resources.boorder_16x16;
            this.barButtonItem3.ImageOptions.LargeImage = global::QL_Vat_Lieu_Xay_Dung_WinFormApp.Properties.Resources.boorder_32x32;
            this.barButtonItem3.Name = "barButtonItem3";
            this.barButtonItem3.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.barButtonItem3.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem3_ItemClick);
            // 
            // tabPhanQuyen
            // 
            this.tabPhanQuyen.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.gruopManHinh,
            this.gruopNhomQuyen,
            this.gruopNguoiDung});
            this.tabPhanQuyen.Name = "tabPhanQuyen";
            this.tabPhanQuyen.Text = "Phân quyền";
            // 
            // gruopManHinh
            // 
            this.gruopManHinh.ItemLinks.Add(this.btnManHinh);
            this.gruopManHinh.Name = "gruopManHinh";
            // 
            // gruopNhomQuyen
            // 
            this.gruopNhomQuyen.ItemLinks.Add(this.btnNhomQuyen);
            this.gruopNhomQuyen.Name = "gruopNhomQuyen";
            // 
            // gruopNguoiDung
            // 
            this.gruopNguoiDung.ItemLinks.Add(this.btnNguoiDung);
            this.gruopNguoiDung.Name = "gruopNguoiDung";
            // 
            // tabQuanLy
            // 
            this.tabQuanLy.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.ribbonPageGroup2,
            this.ribbonPageGroup3});
            this.tabQuanLy.Name = "tabQuanLy";
            this.tabQuanLy.Text = "Quản lý";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.btnNhaCungCap);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "ribbonPageGroup1";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.btnHangHoa);
            this.ribbonPageGroup2.ItemLinks.Add(this.barButtonItem2);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.Text = "ribbonPageGroup2";
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.ItemLinks.Add(this.barButtonItem3);
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            this.ribbonPageGroup3.Text = "ribbonPageGroup3";
            // 
            // fluentDesignFormControl1
            // 
            this.fluentDesignFormControl1.FluentDesignForm = this;
            this.fluentDesignFormControl1.Location = new System.Drawing.Point(0, 0);
            this.fluentDesignFormControl1.Name = "fluentDesignFormControl1";
            this.fluentDesignFormControl1.Size = new System.Drawing.Size(1081, 39);
            this.fluentDesignFormControl1.TabIndex = 2;
            this.fluentDesignFormControl1.TabStop = false;
            // 
            // frmQuanLy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1081, 723);
            this.ControlContainer = this.Container;
            this.Controls.Add(this.Container);
            this.Controls.Add(this.fluentDesignFormControl1);
            this.FluentDesignFormControl = this.fluentDesignFormControl1;
            this.Name = "frmQuanLy";
            this.Text = "frmQuanLy";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmQuanLy_FormClosing);
            this.Load += new System.EventHandler(this.frmQuanLy_Load);
            this.Container.ResumeLayout(false);
            this.Container.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fluentDesignFormControl1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormContainer Container;
        private DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl fluentDesignFormControl1;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar1;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.BarButtonItem btnManHinh;
        private DevExpress.XtraBars.Ribbon.RibbonPage tabPhanQuyen;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup gruopManHinh;
        private DevExpress.XtraBars.BarCheckItem barCheckItem1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarButtonItem btnNhomQuyen;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup gruopNhomQuyen;
        private DevExpress.XtraBars.BarButtonItem btnNguoiDung;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup gruopNguoiDung;
        private DevExpress.XtraBars.Ribbon.RibbonPage tabQuanLy;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.BarButtonItem btnNhaCungCap;
        private DevExpress.XtraBars.BarButtonItem btnHangHoa;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.BarButtonItem barButtonItem3;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
    }
}