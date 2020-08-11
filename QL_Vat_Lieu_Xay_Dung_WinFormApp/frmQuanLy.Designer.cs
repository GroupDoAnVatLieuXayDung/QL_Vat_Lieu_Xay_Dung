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
            this.tabQuanLy = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.gruopManHinh = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.fluentDesignFormControl1 = new DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl();
            this.gruopNhomQuyen = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.btnNhomQuyen = new DevExpress.XtraBars.BarButtonItem();
            this.gruopNguoiDung = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.btnNguoiDung = new DevExpress.XtraBars.BarButtonItem();
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
            this.btnNguoiDung});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 7;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
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
            // tabQuanLy
            // 
            this.tabQuanLy.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.gruopManHinh,
            this.gruopNhomQuyen,
            this.gruopNguoiDung});
            this.tabQuanLy.Name = "tabQuanLy";
            this.tabQuanLy.Text = "Quản lý";
            // 
            // gruopManHinh
            // 
            this.gruopManHinh.ItemLinks.Add(this.btnManHinh);
            this.gruopManHinh.Name = "gruopManHinh";
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
            // gruopNhomQuyen
            // 
            this.gruopNhomQuyen.ItemLinks.Add(this.btnNhomQuyen);
            this.gruopNhomQuyen.Name = "gruopNhomQuyen";
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
            // gruopNguoiDung
            // 
            this.gruopNguoiDung.ItemLinks.Add(this.btnNguoiDung);
            this.gruopNguoiDung.Name = "gruopNguoiDung";
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
        private DevExpress.XtraBars.Ribbon.RibbonPage tabQuanLy;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup gruopManHinh;
        private DevExpress.XtraBars.BarCheckItem barCheckItem1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarButtonItem btnNhomQuyen;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup gruopNhomQuyen;
        private DevExpress.XtraBars.BarButtonItem btnNguoiDung;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup gruopNguoiDung;
    }
}