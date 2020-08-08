namespace QL_Vat_Lieu_Xay_Dung_WDF_Core
{
    partial class frmManHinh
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
            this.datagv_ManHinh = new DevExpress.XtraGrid.GridControl();
            this.gv_ManHinh = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.tablePanel1 = new DevExpress.Utils.Layout.TablePanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tablePanel2 = new DevExpress.Utils.Layout.TablePanel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnBack = new DevExpress.XtraEditors.SimpleButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblHoatDong = new DevExpress.XtraEditors.LabelControl();
            this.toggleSwitchHoatDong = new DevExpress.XtraEditors.ToggleSwitch();
            this.txtSortOrder = new DevExpress.XtraEditors.TextEdit();
            this.lblSort = new DevExpress.XtraEditors.LabelControl();
            this.txtIconCSS = new DevExpress.XtraEditors.TextEdit();
            this.txtURL_ = new DevExpress.XtraEditors.TextEdit();
            this.lblCha = new DevExpress.XtraEditors.LabelControl();
            this.txtMaManHinh = new DevExpress.XtraEditors.TextEdit();
            this.txtTenManHinh = new DevExpress.XtraEditors.TextEdit();
            this.lblMaManHinh = new DevExpress.XtraEditors.LabelControl();
            this.lblTenManHinh = new DevExpress.XtraEditors.LabelControl();
            this.lblIconCSS = new DevExpress.XtraEditors.LabelControl();
            this.lblURL__ = new DevExpress.XtraEditors.LabelControl();
            this.cbManHinhCha = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.stackPanel1)).BeginInit();
            this.stackPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datagv_ManHinh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_ManHinh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel1)).BeginInit();
            this.tablePanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel2)).BeginInit();
            this.tablePanel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.toggleSwitchHoatDong.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSortOrder.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIconCSS.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtURL_.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaManHinh.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenManHinh.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // stackPanel1
            // 
            this.stackPanel1.Appearance.BackColor = System.Drawing.Color.White;
            this.stackPanel1.Appearance.Options.UseBackColor = true;
            this.tablePanel1.SetColumn(this.stackPanel1, 1);
            this.stackPanel1.Controls.Add(this.btnThem);
            this.stackPanel1.Controls.Add(this.btnSua);
            this.stackPanel1.Controls.Add(this.btnXoa);
            this.stackPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stackPanel1.LayoutDirection = DevExpress.Utils.Layout.StackPanelLayoutDirection.TopDown;
            this.stackPanel1.Location = new System.Drawing.Point(1024, 215);
            this.stackPanel1.Name = "stackPanel1";
            this.tablePanel1.SetRow(this.stackPanel1, 1);
            this.stackPanel1.Size = new System.Drawing.Size(284, 573);
            this.stackPanel1.TabIndex = 2;
            // 
            // btnThem
            // 
            this.btnThem.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.Appearance.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnThem.Appearance.Options.UseFont = true;
            this.btnThem.Appearance.Options.UseForeColor = true;
            this.btnThem.Appearance.Options.UseTextOptions = true;
            this.btnThem.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.btnThem.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnThem.ImageOptions.SvgImage = global::QL_Vat_Lieu_Xay_Dung_WDF_Core.Properties.Resources.addparameter;
            this.btnThem.Location = new System.Drawing.Point(16, 3);
            this.btnThem.Margin = new System.Windows.Forms.Padding(20, 3, 20, 3);
            this.btnThem.Name = "btnThem";
            this.btnThem.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnThem.Size = new System.Drawing.Size(252, 80);
            this.btnThem.TabIndex = 2;
            this.btnThem.Text = "Tạo mới màn hình";
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
            this.btnSua.ImageOptions.Image = global::QL_Vat_Lieu_Xay_Dung_WDF_Core.Properties.Resources.edittask_32x32;
            this.btnSua.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnSua.Location = new System.Drawing.Point(20, 89);
            this.btnSua.Margin = new System.Windows.Forms.Padding(20, 3, 20, 3);
            this.btnSua.Name = "btnSua";
            this.btnSua.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnSua.Size = new System.Drawing.Size(244, 80);
            this.btnSua.TabIndex = 3;
            this.btnSua.Text = "Chỉnh sửa màn hình";
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
            this.btnXoa.ImageOptions.Image = global::QL_Vat_Lieu_Xay_Dung_WDF_Core.Properties.Resources.removepivotfield_32x32;
            this.btnXoa.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnXoa.Location = new System.Drawing.Point(21, 175);
            this.btnXoa.Margin = new System.Windows.Forms.Padding(20, 3, 20, 3);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnXoa.Size = new System.Drawing.Size(241, 80);
            this.btnXoa.TabIndex = 4;
            this.btnXoa.Text = "Xoá màn hình";
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // datagv_ManHinh
            // 
            this.tablePanel1.SetColumn(this.datagv_ManHinh, 0);
            this.datagv_ManHinh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.datagv_ManHinh.Location = new System.Drawing.Point(3, 215);
            this.datagv_ManHinh.MainView = this.gv_ManHinh;
            this.datagv_ManHinh.Name = "datagv_ManHinh";
            this.tablePanel1.SetRow(this.datagv_ManHinh, 1);
            this.datagv_ManHinh.Size = new System.Drawing.Size(1015, 573);
            this.datagv_ManHinh.TabIndex = 3;
            this.datagv_ManHinh.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gv_ManHinh,
            this.gridView1});
            // 
            // gv_ManHinh
            // 
            this.gv_ManHinh.GridControl = this.datagv_ManHinh;
            this.gv_ManHinh.Name = "gv_ManHinh";
            this.gv_ManHinh.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.gv_ManHinh_RowCellClick);
            this.gv_ManHinh.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gv_ManHinh_CellValueChanged);
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.datagv_ManHinh;
            this.gridView1.Name = "gridView1";
            // 
            // tablePanel1
            // 
            this.tablePanel1.Appearance.BackColor = System.Drawing.Color.White;
            this.tablePanel1.Appearance.Options.UseBackColor = true;
            this.tablePanel1.Columns.AddRange(new DevExpress.Utils.Layout.TablePanelColumn[] {
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 81.75F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 23.25F)});
            this.tablePanel1.Controls.Add(this.datagv_ManHinh);
            this.tablePanel1.Controls.Add(this.stackPanel1);
            this.tablePanel1.Controls.Add(this.panel1);
            this.tablePanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tablePanel1.Location = new System.Drawing.Point(20, 0);
            this.tablePanel1.Margin = new System.Windows.Forms.Padding(15);
            this.tablePanel1.Name = "tablePanel1";
            this.tablePanel1.Rows.AddRange(new DevExpress.Utils.Layout.TablePanelRow[] {
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 211.6004F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 459.5965F)});
            this.tablePanel1.Size = new System.Drawing.Size(1311, 791);
            this.tablePanel1.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightSkyBlue;
            this.tablePanel1.SetColumn(this.panel1, 0);
            this.tablePanel1.SetColumnSpan(this.panel1, 2);
            this.panel1.Controls.Add(this.tablePanel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.tablePanel1.SetRow(this.panel1, 0);
            this.panel1.Size = new System.Drawing.Size(1311, 212);
            this.panel1.TabIndex = 0;
            // 
            // tablePanel2
            // 
            this.tablePanel2.Columns.AddRange(new DevExpress.Utils.Layout.TablePanelColumn[] {
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 46.85F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 13.15F)});
            this.tablePanel2.Controls.Add(this.panel3);
            this.tablePanel2.Controls.Add(this.panel2);
            this.tablePanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tablePanel2.Location = new System.Drawing.Point(0, 0);
            this.tablePanel2.Name = "tablePanel2";
            this.tablePanel2.Rows.AddRange(new DevExpress.Utils.Layout.TablePanelRow[] {
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 26F)});
            this.tablePanel2.Size = new System.Drawing.Size(1311, 212);
            this.tablePanel2.TabIndex = 0;
            // 
            // panel3
            // 
            this.tablePanel2.SetColumn(this.panel3, 1);
            this.panel3.Controls.Add(this.btnBack);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(1027, 3);
            this.panel3.Name = "panel3";
            this.tablePanel2.SetRow(this.panel3, 0);
            this.panel3.Size = new System.Drawing.Size(281, 206);
            this.panel3.TabIndex = 1;
            // 
            // btnBack
            // 
            this.btnBack.Appearance.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.Appearance.ForeColor = System.Drawing.Color.DarkGreen;
            this.btnBack.Appearance.Options.UseFont = true;
            this.btnBack.Appearance.Options.UseForeColor = true;
            this.btnBack.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnBack.ImageOptions.Image = global::QL_Vat_Lieu_Xay_Dung_WDF_Core.Properties.Resources.backward_32x32;
            this.btnBack.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnBack.Location = new System.Drawing.Point(0, 0);
            this.btnBack.Name = "btnBack";
            this.btnBack.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnBack.Size = new System.Drawing.Size(281, 206);
            this.btnBack.TabIndex = 30;
            this.btnBack.Text = "Back";
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // panel2
            // 
            this.tablePanel2.SetColumn(this.panel2, 0);
            this.panel2.Controls.Add(this.cbManHinhCha);
            this.panel2.Controls.Add(this.lblHoatDong);
            this.panel2.Controls.Add(this.toggleSwitchHoatDong);
            this.panel2.Controls.Add(this.txtSortOrder);
            this.panel2.Controls.Add(this.lblSort);
            this.panel2.Controls.Add(this.txtIconCSS);
            this.panel2.Controls.Add(this.txtURL_);
            this.panel2.Controls.Add(this.lblCha);
            this.panel2.Controls.Add(this.txtMaManHinh);
            this.panel2.Controls.Add(this.txtTenManHinh);
            this.panel2.Controls.Add(this.lblMaManHinh);
            this.panel2.Controls.Add(this.lblTenManHinh);
            this.panel2.Controls.Add(this.lblIconCSS);
            this.panel2.Controls.Add(this.lblURL__);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.tablePanel2.SetRow(this.panel2, 0);
            this.panel2.Size = new System.Drawing.Size(1018, 206);
            this.panel2.TabIndex = 0;
            // 
            // lblHoatDong
            // 
            this.lblHoatDong.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHoatDong.Appearance.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblHoatDong.Appearance.Options.UseFont = true;
            this.lblHoatDong.Appearance.Options.UseForeColor = true;
            this.lblHoatDong.Location = new System.Drawing.Point(737, 168);
            this.lblHoatDong.Name = "lblHoatDong";
            this.lblHoatDong.Size = new System.Drawing.Size(105, 21);
            this.lblHoatDong.TabIndex = 29;
            this.lblHoatDong.Text = "Hoạt động ?";
            // 
            // toggleSwitchHoatDong
            // 
            this.toggleSwitchHoatDong.Location = new System.Drawing.Point(859, 168);
            this.toggleSwitchHoatDong.Name = "toggleSwitchHoatDong";
            this.toggleSwitchHoatDong.Properties.OffText = "Off";
            this.toggleSwitchHoatDong.Properties.OnText = "On";
            this.toggleSwitchHoatDong.Size = new System.Drawing.Size(95, 24);
            this.toggleSwitchHoatDong.TabIndex = 28;
            // 
            // txtSortOrder
            // 
            this.txtSortOrder.Location = new System.Drawing.Point(611, 120);
            this.txtSortOrder.Name = "txtSortOrder";
            this.txtSortOrder.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSortOrder.Properties.Appearance.Options.UseFont = true;
            this.txtSortOrder.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.txtSortOrder.Size = new System.Drawing.Size(304, 30);
            this.txtSortOrder.TabIndex = 27;
            // 
            // lblSort
            // 
            this.lblSort.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSort.Appearance.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblSort.Appearance.Options.UseFont = true;
            this.lblSort.Appearance.Options.UseForeColor = true;
            this.lblSort.Location = new System.Drawing.Point(472, 124);
            this.lblSort.Name = "lblSort";
            this.lblSort.Size = new System.Drawing.Size(87, 21);
            this.lblSort.TabIndex = 26;
            this.lblSort.Text = "Sort order";
            // 
            // txtIconCSS
            // 
            this.txtIconCSS.Location = new System.Drawing.Point(613, 75);
            this.txtIconCSS.Name = "txtIconCSS";
            this.txtIconCSS.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIconCSS.Properties.Appearance.Options.UseFont = true;
            this.txtIconCSS.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.txtIconCSS.Size = new System.Drawing.Size(304, 30);
            this.txtIconCSS.TabIndex = 25;
            // 
            // txtURL_
            // 
            this.txtURL_.Location = new System.Drawing.Point(166, 120);
            this.txtURL_.Name = "txtURL_";
            this.txtURL_.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtURL_.Properties.Appearance.Options.UseFont = true;
            this.txtURL_.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.txtURL_.Size = new System.Drawing.Size(277, 30);
            this.txtURL_.TabIndex = 24;
            // 
            // lblCha
            // 
            this.lblCha.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCha.Appearance.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblCha.Appearance.Options.UseFont = true;
            this.lblCha.Appearance.Options.UseForeColor = true;
            this.lblCha.Location = new System.Drawing.Point(472, 34);
            this.lblCha.Name = "lblCha";
            this.lblCha.Size = new System.Drawing.Size(114, 21);
            this.lblCha.TabIndex = 22;
            this.lblCha.Text = "Màn hình cha";
            // 
            // txtMaManHinh
            // 
            this.txtMaManHinh.Location = new System.Drawing.Point(166, 27);
            this.txtMaManHinh.Name = "txtMaManHinh";
            this.txtMaManHinh.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaManHinh.Properties.Appearance.Options.UseFont = true;
            this.txtMaManHinh.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.txtMaManHinh.Size = new System.Drawing.Size(277, 30);
            this.txtMaManHinh.TabIndex = 20;
            // 
            // txtTenManHinh
            // 
            this.txtTenManHinh.Location = new System.Drawing.Point(166, 72);
            this.txtTenManHinh.Name = "txtTenManHinh";
            this.txtTenManHinh.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenManHinh.Properties.Appearance.Options.UseFont = true;
            this.txtTenManHinh.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.txtTenManHinh.Size = new System.Drawing.Size(277, 30);
            this.txtTenManHinh.TabIndex = 21;
            // 
            // lblMaManHinh
            // 
            this.lblMaManHinh.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaManHinh.Appearance.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblMaManHinh.Appearance.Options.UseFont = true;
            this.lblMaManHinh.Appearance.Options.UseForeColor = true;
            this.lblMaManHinh.Location = new System.Drawing.Point(29, 31);
            this.lblMaManHinh.Name = "lblMaManHinh";
            this.lblMaManHinh.Size = new System.Drawing.Size(110, 21);
            this.lblMaManHinh.TabIndex = 18;
            this.lblMaManHinh.Text = "Mã màn hình";
            // 
            // lblTenManHinh
            // 
            this.lblTenManHinh.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenManHinh.Appearance.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblTenManHinh.Appearance.Options.UseFont = true;
            this.lblTenManHinh.Appearance.Options.UseForeColor = true;
            this.lblTenManHinh.Location = new System.Drawing.Point(29, 76);
            this.lblTenManHinh.Name = "lblTenManHinh";
            this.lblTenManHinh.Size = new System.Drawing.Size(116, 21);
            this.lblTenManHinh.TabIndex = 19;
            this.lblTenManHinh.Text = "Tên màn hình";
            // 
            // lblIconCSS
            // 
            this.lblIconCSS.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIconCSS.Appearance.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblIconCSS.Appearance.Options.UseFont = true;
            this.lblIconCSS.Appearance.Options.UseForeColor = true;
            this.lblIconCSS.Location = new System.Drawing.Point(472, 79);
            this.lblIconCSS.Name = "lblIconCSS";
            this.lblIconCSS.Size = new System.Drawing.Size(71, 21);
            this.lblIconCSS.TabIndex = 17;
            this.lblIconCSS.Text = "Icon css";
            // 
            // lblURL__
            // 
            this.lblURL__.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblURL__.Appearance.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblURL__.Appearance.Options.UseFont = true;
            this.lblURL__.Appearance.Options.UseForeColor = true;
            this.lblURL__.Location = new System.Drawing.Point(29, 124);
            this.lblURL__.Name = "lblURL__";
            this.lblURL__.Size = new System.Drawing.Size(35, 21);
            this.lblURL__.TabIndex = 16;
            this.lblURL__.Text = "URL";
            // 
            // cbManHinhCha
            // 
            this.cbManHinhCha.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbManHinhCha.FormattingEnabled = true;
            this.cbManHinhCha.Location = new System.Drawing.Point(613, 28);
            this.cbManHinhCha.Name = "cbManHinhCha";
            this.cbManHinhCha.Size = new System.Drawing.Size(302, 32);
            this.cbManHinhCha.TabIndex = 30;
            // 
            // frmManHinh
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1351, 791);
            this.Controls.Add(this.tablePanel1);
            this.Name = "frmManHinh";
            this.Padding = new System.Windows.Forms.Padding(20, 0, 20, 0);
            this.Text = "frmManHinh";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmManHinh_FormClosing);
            this.Load += new System.EventHandler(this.frmManHinh_Load);
            ((System.ComponentModel.ISupportInitialize)(this.stackPanel1)).EndInit();
            this.stackPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.datagv_ManHinh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_ManHinh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel1)).EndInit();
            this.tablePanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel2)).EndInit();
            this.tablePanel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.toggleSwitchHoatDong.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSortOrder.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIconCSS.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtURL_.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaManHinh.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenManHinh.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.Utils.Layout.TablePanel tablePanel1;
        private DevExpress.XtraGrid.GridControl datagv_ManHinh;
        private DevExpress.XtraGrid.Views.Grid.GridView gv_ManHinh;
        private DevExpress.Utils.Layout.StackPanel stackPanel1;
        private DevExpress.XtraEditors.SimpleButton btnThem;
        private DevExpress.XtraEditors.SimpleButton btnSua;
        private DevExpress.XtraEditors.SimpleButton btnXoa;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.Utils.Layout.TablePanel tablePanel2;
        private System.Windows.Forms.Panel panel3;
        private DevExpress.XtraEditors.SimpleButton btnBack;
        private System.Windows.Forms.Panel panel2;
        private DevExpress.XtraEditors.LabelControl lblHoatDong;
        private DevExpress.XtraEditors.ToggleSwitch toggleSwitchHoatDong;
        private DevExpress.XtraEditors.TextEdit txtSortOrder;
        private DevExpress.XtraEditors.LabelControl lblSort;
        private DevExpress.XtraEditors.TextEdit txtIconCSS;
        private DevExpress.XtraEditors.TextEdit txtURL_;
        private DevExpress.XtraEditors.LabelControl lblCha;
        private DevExpress.XtraEditors.TextEdit txtMaManHinh;
        private DevExpress.XtraEditors.TextEdit txtTenManHinh;
        private DevExpress.XtraEditors.LabelControl lblMaManHinh;
        private DevExpress.XtraEditors.LabelControl lblTenManHinh;
        private DevExpress.XtraEditors.LabelControl lblIconCSS;
        private DevExpress.XtraEditors.LabelControl lblURL__;
        private System.Windows.Forms.ComboBox cbManHinhCha;
    }
}