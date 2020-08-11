namespace QL_Vat_Lieu_Xay_Dung_WDF_Core
{
    partial class frmNhaCungCap
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
            this.stackPanel1 = new DevExpress.Utils.Layout.StackPanel();
            this.btnThem = new DevExpress.XtraEditors.SimpleButton();
            this.btnSua = new DevExpress.XtraEditors.SimpleButton();
            this.btnXoa = new DevExpress.XtraEditors.SimpleButton();
            this.btnBack = new DevExpress.XtraEditors.SimpleButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkTrangThai = new DevExpress.XtraEditors.CheckButton();
            this.lblTrangThai = new DevExpress.XtraEditors.LabelControl();
            this.txtDiaChi = new DevExpress.XtraEditors.TextEdit();
            this.txtTen = new DevExpress.XtraEditors.TextEdit();
            this.txtPhone = new DevExpress.XtraEditors.TextEdit();
            this.lblDiaChi = new DevExpress.XtraEditors.LabelControl();
            this.lblSDT = new DevExpress.XtraEditors.LabelControl();
            this.lblTen = new DevExpress.XtraEditors.LabelControl();
            this.gv_NhaCC = new DevExpress.XtraGrid.GridControl();
            this.grid_NhaCC = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.panelInfor = new DevExpress.Utils.Layout.TablePanel();
            ((System.ComponentModel.ISupportInitialize)(this.stackPanel1)).BeginInit();
            this.stackPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDiaChi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPhone.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_NhaCC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid_NhaCC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelInfor)).BeginInit();
            this.panelInfor.SuspendLayout();
            this.SuspendLayout();
            // 
            // stackPanel1
            // 
            this.stackPanel1.Appearance.BackColor = System.Drawing.Color.White;
            this.stackPanel1.Appearance.Options.UseBackColor = true;
            this.panelInfor.SetColumn(this.stackPanel1, 0);
            this.stackPanel1.Controls.Add(this.btnThem);
            this.stackPanel1.Controls.Add(this.btnSua);
            this.stackPanel1.Controls.Add(this.btnXoa);
            this.stackPanel1.Controls.Add(this.btnBack);
            this.stackPanel1.Location = new System.Drawing.Point(3, 3);
            this.stackPanel1.Name = "stackPanel1";
            this.panelInfor.SetRow(this.stackPanel1, 0);
            this.stackPanel1.Size = new System.Drawing.Size(1118, 62);
            this.stackPanel1.TabIndex = 0;
            // 
            // btnThem
            // 
            this.btnThem.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.Appearance.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnThem.Appearance.Options.UseFont = true;
            this.btnThem.Appearance.Options.UseForeColor = true;
            this.btnThem.Appearance.Options.UseTextOptions = true;
            this.btnThem.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.btnThem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnThem.ImageOptions.Image = global::QL_Vat_Lieu_Xay_Dung_WDF_Core.Properties.Resources.add_32x322;
            this.btnThem.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnThem.Location = new System.Drawing.Point(20, -3);
            this.btnThem.Margin = new System.Windows.Forms.Padding(20, 3, 20, 3);
            this.btnThem.Name = "btnThem";
            this.btnThem.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnThem.Size = new System.Drawing.Size(250, 68);
            this.btnThem.TabIndex = 2;
            this.btnThem.Text = "Thêm nhà cung cấp";
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnSua
            // 
            this.btnSua.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSua.Appearance.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnSua.Appearance.Options.UseFont = true;
            this.btnSua.Appearance.Options.UseForeColor = true;
            this.btnSua.Appearance.Options.UseTextOptions = true;
            this.btnSua.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.btnSua.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSua.ImageOptions.Image = global::QL_Vat_Lieu_Xay_Dung_WDF_Core.Properties.Resources.publicfix_32x32;
            this.btnSua.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnSua.Location = new System.Drawing.Point(310, -3);
            this.btnSua.Margin = new System.Windows.Forms.Padding(20, 3, 20, 3);
            this.btnSua.Name = "btnSua";
            this.btnSua.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnSua.Size = new System.Drawing.Size(300, 68);
            this.btnSua.TabIndex = 3;
            this.btnSua.Text = "Sửa thông tin nhà cung cấp";
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.Appearance.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnXoa.Appearance.Options.UseFont = true;
            this.btnXoa.Appearance.Options.UseForeColor = true;
            this.btnXoa.Appearance.Options.UseTextOptions = true;
            this.btnXoa.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.btnXoa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnXoa.ImageOptions.Image = global::QL_Vat_Lieu_Xay_Dung_WDF_Core.Properties.Resources.deletetablerows_32x32;
            this.btnXoa.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnXoa.Location = new System.Drawing.Point(650, -3);
            this.btnXoa.Margin = new System.Windows.Forms.Padding(20, 3, 20, 3);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnXoa.Size = new System.Drawing.Size(250, 68);
            this.btnXoa.TabIndex = 4;
            this.btnXoa.Text = "Xoá nhà cung cấp";
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnBack
            // 
            this.btnBack.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.Appearance.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnBack.Appearance.Options.UseFont = true;
            this.btnBack.Appearance.Options.UseForeColor = true;
            this.btnBack.Appearance.Options.UseTextOptions = true;
            this.btnBack.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.btnBack.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnBack.ImageOptions.Image = global::QL_Vat_Lieu_Xay_Dung_WDF_Core.Properties.Resources.backward_32x32;
            this.btnBack.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnBack.Location = new System.Drawing.Point(940, -3);
            this.btnBack.Margin = new System.Windows.Forms.Padding(20, 3, 20, 3);
            this.btnBack.Name = "btnBack";
            this.btnBack.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnBack.Size = new System.Drawing.Size(250, 68);
            this.btnBack.TabIndex = 5;
            this.btnBack.Text = "Back";
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightSkyBlue;
            this.panelInfor.SetColumn(this.panel1, 0);
            this.panel1.Controls.Add(this.chkTrangThai);
            this.panel1.Controls.Add(this.lblTrangThai);
            this.panel1.Controls.Add(this.txtDiaChi);
            this.panel1.Controls.Add(this.txtTen);
            this.panel1.Controls.Add(this.txtPhone);
            this.panel1.Controls.Add(this.lblDiaChi);
            this.panel1.Controls.Add(this.lblSDT);
            this.panel1.Controls.Add(this.lblTen);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 71);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.panel1.Name = "panel1";
            this.panelInfor.SetRow(this.panel1, 1);
            this.panel1.Size = new System.Drawing.Size(1118, 170);
            this.panel1.TabIndex = 3;
            // 
            // chkTrangThai
            // 
            this.chkTrangThai.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Success;
            this.chkTrangThai.Appearance.ForeColor = System.Drawing.Color.White;
            this.chkTrangThai.Appearance.Options.UseBackColor = true;
            this.chkTrangThai.Appearance.Options.UseForeColor = true;
            this.chkTrangThai.Location = new System.Drawing.Point(725, 93);
            this.chkTrangThai.Name = "chkTrangThai";
            this.chkTrangThai.Size = new System.Drawing.Size(166, 26);
            this.chkTrangThai.TabIndex = 26;
            this.chkTrangThai.Text = "Hoạt động";
            this.chkTrangThai.CheckedChanged += new System.EventHandler(this.chkTrangThai_CheckedChanged);
            // 
            // lblTrangThai
            // 
            this.lblTrangThai.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTrangThai.Appearance.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblTrangThai.Appearance.Options.UseFont = true;
            this.lblTrangThai.Appearance.Options.UseForeColor = true;
            this.lblTrangThai.Location = new System.Drawing.Point(561, 94);
            this.lblTrangThai.Name = "lblTrangThai";
            this.lblTrangThai.Size = new System.Drawing.Size(87, 21);
            this.lblTrangThai.TabIndex = 25;
            this.lblTrangThai.Text = "Trạng thái";
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Location = new System.Drawing.Point(125, 90);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDiaChi.Properties.Appearance.Options.UseFont = true;
            this.txtDiaChi.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.txtDiaChi.Size = new System.Drawing.Size(379, 30);
            this.txtDiaChi.TabIndex = 23;
            // 
            // txtTen
            // 
            this.txtTen.Location = new System.Drawing.Point(125, 29);
            this.txtTen.Name = "txtTen";
            this.txtTen.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTen.Properties.Appearance.Options.UseFont = true;
            this.txtTen.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.txtTen.Size = new System.Drawing.Size(379, 30);
            this.txtTen.TabIndex = 23;
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(725, 28);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPhone.Properties.Appearance.Options.UseFont = true;
            this.txtPhone.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.txtPhone.Size = new System.Drawing.Size(276, 30);
            this.txtPhone.TabIndex = 22;
            // 
            // lblDiaChi
            // 
            this.lblDiaChi.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiaChi.Appearance.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblDiaChi.Appearance.Options.UseFont = true;
            this.lblDiaChi.Appearance.Options.UseForeColor = true;
            this.lblDiaChi.Location = new System.Drawing.Point(28, 94);
            this.lblDiaChi.Name = "lblDiaChi";
            this.lblDiaChi.Size = new System.Drawing.Size(58, 21);
            this.lblDiaChi.TabIndex = 13;
            this.lblDiaChi.Text = "Địa chỉ";
            // 
            // lblSDT
            // 
            this.lblSDT.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSDT.Appearance.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblSDT.Appearance.Options.UseFont = true;
            this.lblSDT.Appearance.Options.UseForeColor = true;
            this.lblSDT.Location = new System.Drawing.Point(561, 33);
            this.lblSDT.Name = "lblSDT";
            this.lblSDT.Size = new System.Drawing.Size(113, 21);
            this.lblSDT.TabIndex = 16;
            this.lblSDT.Text = "Số điện thoại";
            // 
            // lblTen
            // 
            this.lblTen.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTen.Appearance.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblTen.Appearance.Options.UseFont = true;
            this.lblTen.Appearance.Options.UseForeColor = true;
            this.lblTen.Location = new System.Drawing.Point(28, 33);
            this.lblTen.Name = "lblTen";
            this.lblTen.Size = new System.Drawing.Size(36, 21);
            this.lblTen.TabIndex = 13;
            this.lblTen.Text = "Tên ";
            // 
            // gv_NhaCC
            // 
            this.panelInfor.SetColumn(this.gv_NhaCC, 0);
            this.gv_NhaCC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gv_NhaCC.Location = new System.Drawing.Point(3, 244);
            this.gv_NhaCC.MainView = this.grid_NhaCC;
            this.gv_NhaCC.Name = "gv_NhaCC";
            this.panelInfor.SetRow(this.gv_NhaCC, 2);
            this.gv_NhaCC.Size = new System.Drawing.Size(1118, 558);
            this.gv_NhaCC.TabIndex = 4;
            this.gv_NhaCC.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grid_NhaCC,
            this.gridView1});
            // 
            // grid_NhaCC
            // 
            this.grid_NhaCC.GridControl = this.gv_NhaCC;
            this.grid_NhaCC.Name = "grid_NhaCC";
            this.grid_NhaCC.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.grid_Khach_NV_NhaCC_RowCellClick);
            this.grid_NhaCC.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.grid_Khach_NV_NhaCC_CellValueChanged);
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gv_NhaCC;
            this.gridView1.Name = "gridView1";
            // 
            // panelInfor
            // 
            this.panelInfor.Appearance.BackColor = System.Drawing.Color.White;
            this.panelInfor.Appearance.Options.UseBackColor = true;
            this.panelInfor.Columns.AddRange(new DevExpress.Utils.Layout.TablePanelColumn[] {
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 60.53F)});
            this.panelInfor.Controls.Add(this.gv_NhaCC);
            this.panelInfor.Controls.Add(this.panel1);
            this.panelInfor.Controls.Add(this.stackPanel1);
            this.panelInfor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelInfor.Location = new System.Drawing.Point(0, 0);
            this.panelInfor.Margin = new System.Windows.Forms.Padding(3, 3, 30, 3);
            this.panelInfor.Name = "panelInfor";
            this.panelInfor.Rows.AddRange(new DevExpress.Utils.Layout.TablePanelRow[] {
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 67.59998F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 173.2003F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 26F)});
            this.panelInfor.Size = new System.Drawing.Size(1124, 805);
            this.panelInfor.TabIndex = 0;
            // 
            // frmNhaCungCap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1124, 805);
            this.Controls.Add(this.panelInfor);
            this.Name = "frmNhaCungCap";
            this.Text = "frmKhachHang_NCC";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmKhachHang_NCC_FormClosing);
            this.Load += new System.EventHandler(this.frmKhachHang_NCC_Load);
            ((System.ComponentModel.ISupportInitialize)(this.stackPanel1)).EndInit();
            this.stackPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDiaChi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPhone.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_NhaCC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid_NhaCC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelInfor)).EndInit();
            this.panelInfor.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.Utils.Layout.StackPanel stackPanel1;
        private DevExpress.Utils.Layout.TablePanel panelInfor;
        private DevExpress.XtraGrid.GridControl gv_NhaCC;
        private DevExpress.XtraGrid.Views.Grid.GridView grid_NhaCC;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.TextEdit txtTen;
        private DevExpress.XtraEditors.TextEdit txtPhone;
        private DevExpress.XtraEditors.LabelControl lblSDT;
        private DevExpress.XtraEditors.LabelControl lblTen;
        private DevExpress.XtraEditors.SimpleButton btnThem;
        private DevExpress.XtraEditors.SimpleButton btnSua;
        private DevExpress.XtraEditors.SimpleButton btnXoa;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.SimpleButton btnBack;
        private DevExpress.XtraEditors.LabelControl lblTrangThai;
        private DevExpress.XtraEditors.CheckButton chkTrangThai;
        private DevExpress.XtraEditors.TextEdit txtDiaChi;
        private DevExpress.XtraEditors.LabelControl lblDiaChi;
    }
}