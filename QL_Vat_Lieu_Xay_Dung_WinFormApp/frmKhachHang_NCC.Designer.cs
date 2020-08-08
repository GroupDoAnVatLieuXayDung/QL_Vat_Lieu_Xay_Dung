namespace QL_Vat_Lieu_Xay_Dung_WinFormApp
{
    partial class frmKhachHang_NCC
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
            this.stackPanel1 = new DevExpress.Utils.Layout.StackPanel();
            this.btnThem = new DevExpress.XtraEditors.SimpleButton();
            this.btnSua = new DevExpress.XtraEditors.SimpleButton();
            this.btnXoa = new DevExpress.XtraEditors.SimpleButton();
            this.btnBack = new DevExpress.XtraEditors.SimpleButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkTrangThai = new DevExpress.XtraEditors.CheckButton();
            this.lblTrangThai = new DevExpress.XtraEditors.LabelControl();
            this.txtEmail = new DevExpress.XtraEditors.TextEdit();
            this.txtTen = new DevExpress.XtraEditors.TextEdit();
            this.txtPhone = new DevExpress.XtraEditors.TextEdit();
            this.txtConfirmEmail = new DevExpress.XtraEditors.TextEdit();
            this.dateBirthday = new DevExpress.XtraEditors.DateEdit();
            this.lblBirthDay = new DevExpress.XtraEditors.LabelControl();
            this.lblPhone = new DevExpress.XtraEditors.LabelControl();
            this.lblConfirmEmail = new DevExpress.XtraEditors.LabelControl();
            this.lblEmail = new DevExpress.XtraEditors.LabelControl();
            this.lblUserName = new DevExpress.XtraEditors.LabelControl();
            this.gv_Khach_NV_NhaCC = new DevExpress.XtraGrid.GridControl();
            this.grid_Khach_NV_NhaCC = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.lslSuDung = new DevExpress.XtraEditors.LabelControl();
            this.toggleSwitchSuDungAvatar = new DevExpress.XtraEditors.ToggleSwitch();
            this.ptrAvatar = new DevExpress.XtraEditors.PictureEdit();
            this.stackPanel2 = new DevExpress.Utils.Layout.StackPanel();
            this.grpLoaiDoiTuong = new DevExpress.XtraEditors.GroupControl();
            this.chkNhaCC = new DevExpress.XtraEditors.CheckButton();
            this.chkNhanVien = new DevExpress.XtraEditors.CheckButton();
            this.chkKhachHang = new DevExpress.XtraEditors.CheckButton();
            this.radioGroup1 = new DevExpress.XtraEditors.RadioGroup();
            this.panelInfor = new DevExpress.Utils.Layout.TablePanel();
            this.xtraOpenFileDialog1 = new DevExpress.XtraEditors.XtraOpenFileDialog(this.components);
            this.xtraSaveFileDialog1 = new DevExpress.XtraEditors.XtraSaveFileDialog(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.stackPanel1)).BeginInit();
            this.stackPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmail.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPhone.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtConfirmEmail.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateBirthday.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateBirthday.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_Khach_NV_NhaCC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid_Khach_NV_NhaCC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.toggleSwitchSuDungAvatar.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptrAvatar.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stackPanel2)).BeginInit();
            this.stackPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpLoaiDoiTuong)).BeginInit();
            this.grpLoaiDoiTuong.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelInfor)).BeginInit();
            this.panelInfor.SuspendLayout();
            this.SuspendLayout();
            // 
            // stackPanel1
            // 
            this.stackPanel1.Appearance.BackColor = System.Drawing.Color.White;
            this.stackPanel1.Appearance.Options.UseBackColor = true;
            this.panelInfor.SetColumn(this.stackPanel1, 0);
            this.panelInfor.SetColumnSpan(this.stackPanel1, 2);
            this.stackPanel1.Controls.Add(this.btnThem);
            this.stackPanel1.Controls.Add(this.btnSua);
            this.stackPanel1.Controls.Add(this.btnXoa);
            this.stackPanel1.Controls.Add(this.btnBack);
            this.stackPanel1.Location = new System.Drawing.Point(3, 3);
            this.stackPanel1.Name = "stackPanel1";
            this.panelInfor.SetRow(this.stackPanel1, 0);
            this.stackPanel1.Size = new System.Drawing.Size(1455, 62);
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
            this.btnThem.ImageOptions.Image = global::QL_Vat_Lieu_Xay_Dung_WinFormApp.Properties.Resources.add_32x322;
            this.btnThem.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnThem.Location = new System.Drawing.Point(20, -3);
            this.btnThem.Margin = new System.Windows.Forms.Padding(20, 3, 20, 3);
            this.btnThem.Name = "btnThem";
            this.btnThem.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnThem.Size = new System.Drawing.Size(250, 68);
            this.btnThem.TabIndex = 2;
            this.btnThem.Text = "Thêm khách hàng,NCC";
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
            this.btnSua.ImageOptions.Image = global::QL_Vat_Lieu_Xay_Dung_WinFormApp.Properties.Resources.publicfix_32x32;
            this.btnSua.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnSua.Location = new System.Drawing.Point(310, -3);
            this.btnSua.Margin = new System.Windows.Forms.Padding(20, 3, 20, 3);
            this.btnSua.Name = "btnSua";
            this.btnSua.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnSua.Size = new System.Drawing.Size(300, 68);
            this.btnSua.TabIndex = 3;
            this.btnSua.Text = "Sửa thông tin khách hàng,NCC";
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
            this.btnXoa.ImageOptions.Image = global::QL_Vat_Lieu_Xay_Dung_WinFormApp.Properties.Resources.deletetablerows_32x32;
            this.btnXoa.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnXoa.Location = new System.Drawing.Point(650, -3);
            this.btnXoa.Margin = new System.Windows.Forms.Padding(20, 3, 20, 3);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnXoa.Size = new System.Drawing.Size(250, 68);
            this.btnXoa.TabIndex = 4;
            this.btnXoa.Text = "Xoá khách hàng,NCC";
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
            this.btnBack.ImageOptions.Image = global::QL_Vat_Lieu_Xay_Dung_WinFormApp.Properties.Resources.backward_32x32;
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
            this.panel1.Controls.Add(this.txtEmail);
            this.panel1.Controls.Add(this.txtTen);
            this.panel1.Controls.Add(this.txtPhone);
            this.panel1.Controls.Add(this.txtConfirmEmail);
            this.panel1.Controls.Add(this.dateBirthday);
            this.panel1.Controls.Add(this.lblBirthDay);
            this.panel1.Controls.Add(this.lblPhone);
            this.panel1.Controls.Add(this.lblConfirmEmail);
            this.panel1.Controls.Add(this.lblEmail);
            this.panel1.Controls.Add(this.lblUserName);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 71);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.panel1.Name = "panel1";
            this.panelInfor.SetRow(this.panel1, 1);
            this.panel1.Size = new System.Drawing.Size(1192, 170);
            this.panel1.TabIndex = 3;
            // 
            // chkTrangThai
            // 
            this.chkTrangThai.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Success;
            this.chkTrangThai.Appearance.ForeColor = System.Drawing.Color.White;
            this.chkTrangThai.Appearance.Options.UseBackColor = true;
            this.chkTrangThai.Appearance.Options.UseForeColor = true;
            this.chkTrangThai.Location = new System.Drawing.Point(970, 99);
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
            this.lblTrangThai.Location = new System.Drawing.Point(845, 99);
            this.lblTrangThai.Name = "lblTrangThai";
            this.lblTrangThai.Size = new System.Drawing.Size(87, 21);
            this.lblTrangThai.TabIndex = 25;
            this.lblTrangThai.Text = "Trạng thái";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(552, 29);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.Properties.Appearance.Options.UseFont = true;
            this.txtEmail.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.txtEmail.Size = new System.Drawing.Size(261, 30);
            this.txtEmail.TabIndex = 24;
            // 
            // txtTen
            // 
            this.txtTen.Location = new System.Drawing.Point(125, 29);
            this.txtTen.Name = "txtTen";
            this.txtTen.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTen.Properties.Appearance.Options.UseFont = true;
            this.txtTen.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.txtTen.Size = new System.Drawing.Size(256, 30);
            this.txtTen.TabIndex = 23;
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(940, 29);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPhone.Properties.Appearance.Options.UseFont = true;
            this.txtPhone.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.txtPhone.Size = new System.Drawing.Size(219, 30);
            this.txtPhone.TabIndex = 22;
            // 
            // txtConfirmEmail
            // 
            this.txtConfirmEmail.Location = new System.Drawing.Point(552, 95);
            this.txtConfirmEmail.Name = "txtConfirmEmail";
            this.txtConfirmEmail.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConfirmEmail.Properties.Appearance.Options.UseFont = true;
            this.txtConfirmEmail.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.txtConfirmEmail.Size = new System.Drawing.Size(261, 30);
            this.txtConfirmEmail.TabIndex = 21;
            // 
            // dateBirthday
            // 
            this.dateBirthday.EditValue = null;
            this.dateBirthday.Location = new System.Drawing.Point(125, 95);
            this.dateBirthday.Name = "dateBirthday";
            this.dateBirthday.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateBirthday.Properties.Appearance.Options.UseFont = true;
            this.dateBirthday.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.dateBirthday.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateBirthday.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateBirthday.Size = new System.Drawing.Size(256, 30);
            this.dateBirthday.TabIndex = 18;
            // 
            // lblBirthDay
            // 
            this.lblBirthDay.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBirthDay.Appearance.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblBirthDay.Appearance.Options.UseFont = true;
            this.lblBirthDay.Appearance.Options.UseForeColor = true;
            this.lblBirthDay.Location = new System.Drawing.Point(28, 99);
            this.lblBirthDay.Name = "lblBirthDay";
            this.lblBirthDay.Size = new System.Drawing.Size(79, 21);
            this.lblBirthDay.TabIndex = 17;
            this.lblBirthDay.Text = "Brithday:";
            // 
            // lblPhone
            // 
            this.lblPhone.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPhone.Appearance.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblPhone.Appearance.Options.UseFont = true;
            this.lblPhone.Appearance.Options.UseForeColor = true;
            this.lblPhone.Location = new System.Drawing.Point(845, 33);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(60, 21);
            this.lblPhone.TabIndex = 16;
            this.lblPhone.Text = "Phone:";
            // 
            // lblConfirmEmail
            // 
            this.lblConfirmEmail.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConfirmEmail.Appearance.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblConfirmEmail.Appearance.Options.UseFont = true;
            this.lblConfirmEmail.Appearance.Options.UseForeColor = true;
            this.lblConfirmEmail.Location = new System.Drawing.Point(405, 99);
            this.lblConfirmEmail.Name = "lblConfirmEmail";
            this.lblConfirmEmail.Size = new System.Drawing.Size(125, 21);
            this.lblConfirmEmail.TabIndex = 15;
            this.lblConfirmEmail.Text = "Confirm email:";
            // 
            // lblEmail
            // 
            this.lblEmail.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmail.Appearance.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblEmail.Appearance.Options.UseFont = true;
            this.lblEmail.Appearance.Options.UseForeColor = true;
            this.lblEmail.Location = new System.Drawing.Point(405, 33);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(52, 21);
            this.lblEmail.TabIndex = 14;
            this.lblEmail.Text = "Email:";
            // 
            // lblUserName
            // 
            this.lblUserName.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserName.Appearance.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblUserName.Appearance.Options.UseFont = true;
            this.lblUserName.Appearance.Options.UseForeColor = true;
            this.lblUserName.Location = new System.Drawing.Point(28, 33);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(55, 21);
            this.lblUserName.TabIndex = 13;
            this.lblUserName.Text = "Name:";
            // 
            // gv_Khach_NV_NhaCC
            // 
            this.panelInfor.SetColumn(this.gv_Khach_NV_NhaCC, 0);
            this.gv_Khach_NV_NhaCC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gv_Khach_NV_NhaCC.Location = new System.Drawing.Point(3, 244);
            this.gv_Khach_NV_NhaCC.MainView = this.grid_Khach_NV_NhaCC;
            this.gv_Khach_NV_NhaCC.Name = "gv_Khach_NV_NhaCC";
            this.panelInfor.SetRow(this.gv_Khach_NV_NhaCC, 2);
            this.gv_Khach_NV_NhaCC.Size = new System.Drawing.Size(1192, 558);
            this.gv_Khach_NV_NhaCC.TabIndex = 4;
            this.gv_Khach_NV_NhaCC.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grid_Khach_NV_NhaCC,
            this.gridView1});
            // 
            // grid_Khach_NV_NhaCC
            // 
            this.grid_Khach_NV_NhaCC.GridControl = this.gv_Khach_NV_NhaCC;
            this.grid_Khach_NV_NhaCC.Name = "grid_Khach_NV_NhaCC";
            this.grid_Khach_NV_NhaCC.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.grid_Khach_NV_NhaCC_RowCellClick);
            this.grid_Khach_NV_NhaCC.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.grid_Khach_NV_NhaCC_CellValueChanged);
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gv_Khach_NV_NhaCC;
            this.gridView1.Name = "gridView1";
            // 
            // panelControl1
            // 
            this.panelInfor.SetColumn(this.panelControl1, 1);
            this.panelControl1.Controls.Add(this.lslSuDung);
            this.panelControl1.Controls.Add(this.toggleSwitchSuDungAvatar);
            this.panelControl1.Controls.Add(this.ptrAvatar);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(1208, 71);
            this.panelControl1.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.panelControl1.Name = "panelControl1";
            this.panelInfor.SetRow(this.panelControl1, 1);
            this.panelControl1.Size = new System.Drawing.Size(243, 167);
            this.panelControl1.TabIndex = 5;
            // 
            // lslSuDung
            // 
            this.lslSuDung.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lslSuDung.Appearance.Options.UseFont = true;
            this.lslSuDung.Location = new System.Drawing.Point(17, 130);
            this.lslSuDung.Name = "lslSuDung";
            this.lslSuDung.Size = new System.Drawing.Size(59, 18);
            this.lslSuDung.TabIndex = 10;
            this.lslSuDung.Text = "Sủ dụng";
            // 
            // toggleSwitchSuDungAvatar
            // 
            this.toggleSwitchSuDungAvatar.Location = new System.Drawing.Point(99, 127);
            this.toggleSwitchSuDungAvatar.Name = "toggleSwitchSuDungAvatar";
            this.toggleSwitchSuDungAvatar.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toggleSwitchSuDungAvatar.Properties.Appearance.Options.UseFont = true;
            this.toggleSwitchSuDungAvatar.Properties.OffText = "Off";
            this.toggleSwitchSuDungAvatar.Properties.OnText = "On";
            this.toggleSwitchSuDungAvatar.Size = new System.Drawing.Size(95, 24);
            this.toggleSwitchSuDungAvatar.TabIndex = 9;
            // 
            // ptrAvatar
            // 
            this.ptrAvatar.Dock = System.Windows.Forms.DockStyle.Top;
            this.ptrAvatar.Location = new System.Drawing.Point(2, 2);
            this.ptrAvatar.Margin = new System.Windows.Forms.Padding(20, 20, 20, 3);
            this.ptrAvatar.Name = "ptrAvatar";
            this.ptrAvatar.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.ptrAvatar.Size = new System.Drawing.Size(239, 119);
            this.ptrAvatar.TabIndex = 8;
            this.ptrAvatar.EditValueChanged += new System.EventHandler(this.ptrAvatar_EditValueChanged);
            // 
            // stackPanel2
            // 
            this.panelInfor.SetColumn(this.stackPanel2, 1);
            this.stackPanel2.Controls.Add(this.grpLoaiDoiTuong);
            this.stackPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stackPanel2.LayoutDirection = DevExpress.Utils.Layout.StackPanelLayoutDirection.TopDown;
            this.stackPanel2.Location = new System.Drawing.Point(1201, 244);
            this.stackPanel2.Name = "stackPanel2";
            this.panelInfor.SetRow(this.stackPanel2, 2);
            this.stackPanel2.Size = new System.Drawing.Size(257, 558);
            this.stackPanel2.TabIndex = 6;
            // 
            // grpLoaiDoiTuong
            // 
            this.grpLoaiDoiTuong.Controls.Add(this.chkNhaCC);
            this.grpLoaiDoiTuong.Controls.Add(this.chkNhanVien);
            this.grpLoaiDoiTuong.Controls.Add(this.chkKhachHang);
            this.grpLoaiDoiTuong.Controls.Add(this.radioGroup1);
            this.grpLoaiDoiTuong.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpLoaiDoiTuong.Location = new System.Drawing.Point(28, 50);
            this.grpLoaiDoiTuong.Margin = new System.Windows.Forms.Padding(10, 50, 10, 3);
            this.grpLoaiDoiTuong.Name = "grpLoaiDoiTuong";
            this.grpLoaiDoiTuong.Size = new System.Drawing.Size(200, 275);
            this.grpLoaiDoiTuong.TabIndex = 0;
            this.grpLoaiDoiTuong.Text = "Loại đối tượng";
            // 
            // chkNhaCC
            // 
            this.chkNhaCC.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkNhaCC.Appearance.Options.UseFont = true;
            this.chkNhaCC.Location = new System.Drawing.Point(28, 189);
            this.chkNhaCC.Name = "chkNhaCC";
            this.chkNhaCC.Size = new System.Drawing.Size(149, 47);
            this.chkNhaCC.TabIndex = 3;
            this.chkNhaCC.Text = "Nhà cung cấp";
            // 
            // chkNhanVien
            // 
            this.chkNhanVien.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkNhanVien.Appearance.Options.UseFont = true;
            this.chkNhanVien.Location = new System.Drawing.Point(28, 122);
            this.chkNhanVien.Name = "chkNhanVien";
            this.chkNhanVien.Size = new System.Drawing.Size(149, 47);
            this.chkNhanVien.TabIndex = 2;
            this.chkNhanVien.Text = "Nhân viên";
            // 
            // chkKhachHang
            // 
            this.chkKhachHang.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkKhachHang.Appearance.Options.UseFont = true;
            this.chkKhachHang.Location = new System.Drawing.Point(28, 54);
            this.chkKhachHang.Name = "chkKhachHang";
            this.chkKhachHang.Size = new System.Drawing.Size(149, 47);
            this.chkKhachHang.TabIndex = 1;
            this.chkKhachHang.Text = "Khách hàng";
            // 
            // radioGroup1
            // 
            this.radioGroup1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radioGroup1.Location = new System.Drawing.Point(2, 28);
            this.radioGroup1.Name = "radioGroup1";
            this.radioGroup1.Size = new System.Drawing.Size(196, 245);
            this.radioGroup1.TabIndex = 0;
            // 
            // panelInfor
            // 
            this.panelInfor.Appearance.BackColor = System.Drawing.Color.White;
            this.panelInfor.Appearance.Options.UseBackColor = true;
            this.panelInfor.Columns.AddRange(new DevExpress.Utils.Layout.TablePanelColumn[] {
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 86.08F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 18.92F)});
            this.panelInfor.Controls.Add(this.stackPanel2);
            this.panelInfor.Controls.Add(this.panelControl1);
            this.panelInfor.Controls.Add(this.gv_Khach_NV_NhaCC);
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
            this.panelInfor.Size = new System.Drawing.Size(1461, 805);
            this.panelInfor.TabIndex = 0;
            // 
            // xtraOpenFileDialog1
            // 
            this.xtraOpenFileDialog1.FileName = "xtraOpenFileDialog1";
            // 
            // xtraSaveFileDialog1
            // 
            this.xtraSaveFileDialog1.FileName = "xtraSaveFileDialog1";
            // 
            // frmKhachHang_NCC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1461, 805);
            this.Controls.Add(this.panelInfor);
            this.Name = "frmKhachHang_NCC";
            this.Text = "frmKhachHang_NCC";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmKhachHang_NCC_FormClosing);
            this.Load += new System.EventHandler(this.frmKhachHang_NCC_Load);
            ((System.ComponentModel.ISupportInitialize)(this.stackPanel1)).EndInit();
            this.stackPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmail.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPhone.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtConfirmEmail.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateBirthday.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateBirthday.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_Khach_NV_NhaCC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid_Khach_NV_NhaCC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.toggleSwitchSuDungAvatar.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptrAvatar.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stackPanel2)).EndInit();
            this.stackPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grpLoaiDoiTuong)).EndInit();
            this.grpLoaiDoiTuong.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelInfor)).EndInit();
            this.panelInfor.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.Utils.Layout.StackPanel stackPanel1;
        private DevExpress.Utils.Layout.TablePanel panelInfor;
        private DevExpress.Utils.Layout.StackPanel stackPanel2;
        private DevExpress.XtraEditors.GroupControl grpLoaiDoiTuong;
        private DevExpress.XtraEditors.RadioGroup radioGroup1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LabelControl lslSuDung;
        private DevExpress.XtraEditors.ToggleSwitch toggleSwitchSuDungAvatar;
        private DevExpress.XtraEditors.PictureEdit ptrAvatar;
        private DevExpress.XtraGrid.GridControl gv_Khach_NV_NhaCC;
        private DevExpress.XtraGrid.Views.Grid.GridView grid_Khach_NV_NhaCC;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.TextEdit txtEmail;
        private DevExpress.XtraEditors.TextEdit txtTen;
        private DevExpress.XtraEditors.TextEdit txtPhone;
        private DevExpress.XtraEditors.TextEdit txtConfirmEmail;
        private DevExpress.XtraEditors.DateEdit dateBirthday;
        private DevExpress.XtraEditors.LabelControl lblBirthDay;
        private DevExpress.XtraEditors.LabelControl lblPhone;
        private DevExpress.XtraEditors.LabelControl lblConfirmEmail;
        private DevExpress.XtraEditors.LabelControl lblEmail;
        private DevExpress.XtraEditors.LabelControl lblUserName;
        private DevExpress.XtraEditors.SimpleButton btnThem;
        private DevExpress.XtraEditors.SimpleButton btnSua;
        private DevExpress.XtraEditors.SimpleButton btnXoa;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.CheckButton chkKhachHang;
        private DevExpress.XtraEditors.CheckButton chkNhaCC;
        private DevExpress.XtraEditors.CheckButton chkNhanVien;
        private DevExpress.XtraEditors.SimpleButton btnBack;
        private DevExpress.XtraEditors.LabelControl lblTrangThai;
        private DevExpress.XtraEditors.CheckButton chkTrangThai;
        private DevExpress.XtraEditors.XtraOpenFileDialog xtraOpenFileDialog1;
        private DevExpress.XtraEditors.XtraSaveFileDialog xtraSaveFileDialog1;
    }
}