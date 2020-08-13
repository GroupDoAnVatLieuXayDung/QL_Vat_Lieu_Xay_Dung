namespace QL_Vat_Lieu_Xay_Dung_WDF_Core.Form_QuanLy
{
    partial class frmNhomQuyen
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
        ///
        private void InitializeComponent()
        {
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnBack = new DevExpress.XtraEditors.SimpleButton();
            this.tablePanel2 = new DevExpress.Utils.Layout.TablePanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtMoTa = new System.Windows.Forms.TextBox();
            this.lblMoTa = new DevExpress.XtraEditors.LabelControl();
            this.txtNhomQuyen = new DevExpress.XtraEditors.TextEdit();
            this.lblNhomQuyen = new DevExpress.XtraEditors.LabelControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tablePanel1 = new DevExpress.Utils.Layout.TablePanel();
            this.tablePanel3 = new DevExpress.Utils.Layout.TablePanel();
            this.btnBackPermission = new DevExpress.XtraEditors.SimpleButton();
            this.btnSavePermission = new DevExpress.XtraEditors.SimpleButton();
            this.gv_PhanQuyen = new DevExpress.XtraGrid.GridControl();
            this.grid_PhanQuyen = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colP_RoleId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colP_FunctionId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFunctionName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colP_CanRead = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colP_CanCreate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colP_CanUpdate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colP_CanDelete = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lblPhanQuyen = new System.Windows.Forms.Label();
            this.gv_NhomQuyen = new DevExpress.XtraGrid.GridControl();
            this.grid_NhomQuyen = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colRoleId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRoleName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRoleDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.stackPanel1 = new DevExpress.Utils.Layout.StackPanel();
            this.btnThem = new DevExpress.XtraEditors.SimpleButton();
            this.btnSua = new DevExpress.XtraEditors.SimpleButton();
            this.btnXoa = new DevExpress.XtraEditors.SimpleButton();
            this.repositoryItemCheckEdit = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel2)).BeginInit();
            this.tablePanel2.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNhomQuyen.Properties)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel1)).BeginInit();
            this.tablePanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel3)).BeginInit();
            this.tablePanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gv_PhanQuyen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid_PhanQuyen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_NhomQuyen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid_NhomQuyen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stackPanel1)).BeginInit();
            this.stackPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit)).BeginInit();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.tablePanel2.SetColumn(this.panel3, 1);
            this.panel3.Controls.Add(this.btnBack);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(985, 3);
            this.panel3.Name = "panel3";
            this.tablePanel2.SetRow(this.panel3, 0);
            this.panel3.Size = new System.Drawing.Size(297, 155);
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
            this.btnBack.Size = new System.Drawing.Size(297, 155);
            this.btnBack.TabIndex = 30;
            this.btnBack.Text = "Back";
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // tablePanel2
            // 
            this.tablePanel2.Columns.AddRange(new DevExpress.Utils.Layout.TablePanelColumn[] {
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 45.85F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 14.15F)});
            this.tablePanel2.Controls.Add(this.panel3);
            this.tablePanel2.Controls.Add(this.panel2);
            this.tablePanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tablePanel2.Location = new System.Drawing.Point(0, 0);
            this.tablePanel2.Name = "tablePanel2";
            this.tablePanel2.Rows.AddRange(new DevExpress.Utils.Layout.TablePanelRow[] {
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 26F)});
            this.tablePanel2.Size = new System.Drawing.Size(1285, 161);
            this.tablePanel2.TabIndex = 0;
            // 
            // panel2
            // 
            this.tablePanel2.SetColumn(this.panel2, 0);
            this.panel2.Controls.Add(this.txtMoTa);
            this.panel2.Controls.Add(this.lblMoTa);
            this.panel2.Controls.Add(this.txtNhomQuyen);
            this.panel2.Controls.Add(this.lblNhomQuyen);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.tablePanel2.SetRow(this.panel2, 0);
            this.panel2.Size = new System.Drawing.Size(976, 155);
            this.panel2.TabIndex = 0;
            // 
            // txtMoTa
            // 
            this.txtMoTa.Location = new System.Drawing.Point(235, 63);
            this.txtMoTa.Multiline = true;
            this.txtMoTa.Name = "txtMoTa";
            this.txtMoTa.Size = new System.Drawing.Size(688, 71);
            this.txtMoTa.TabIndex = 23;
            // 
            // lblMoTa
            // 
            this.lblMoTa.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMoTa.Appearance.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblMoTa.Appearance.Options.UseFont = true;
            this.lblMoTa.Appearance.Options.UseForeColor = true;
            this.lblMoTa.Location = new System.Drawing.Point(71, 76);
            this.lblMoTa.Name = "lblMoTa";
            this.lblMoTa.Size = new System.Drawing.Size(48, 21);
            this.lblMoTa.TabIndex = 22;
            this.lblMoTa.Text = "Mô tả";
            // 
            // txtNhomQuyen
            // 
            this.txtNhomQuyen.Location = new System.Drawing.Point(235, 17);
            this.txtNhomQuyen.Name = "txtNhomQuyen";
            this.txtNhomQuyen.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNhomQuyen.Properties.Appearance.Options.UseFont = true;
            this.txtNhomQuyen.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.txtNhomQuyen.Size = new System.Drawing.Size(688, 30);
            this.txtNhomQuyen.TabIndex = 20;
            // 
            // lblNhomQuyen
            // 
            this.lblNhomQuyen.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNhomQuyen.Appearance.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblNhomQuyen.Appearance.Options.UseFont = true;
            this.lblNhomQuyen.Appearance.Options.UseForeColor = true;
            this.lblNhomQuyen.Location = new System.Drawing.Point(71, 21);
            this.lblNhomQuyen.Name = "lblNhomQuyen";
            this.lblNhomQuyen.Size = new System.Drawing.Size(109, 21);
            this.lblNhomQuyen.TabIndex = 18;
            this.lblNhomQuyen.Text = "Nhóm quyền";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightSkyBlue;
            this.tablePanel1.SetColumn(this.panel1, 0);
            this.tablePanel1.SetColumnSpan(this.panel1, 2);
            this.panel1.Controls.Add(this.tablePanel2);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.tablePanel1.SetRow(this.panel1, 0);
            this.panel1.Size = new System.Drawing.Size(1285, 161);
            this.panel1.TabIndex = 0;
            // 
            // tablePanel1
            // 
            this.tablePanel1.Appearance.BackColor = System.Drawing.Color.White;
            this.tablePanel1.Appearance.Options.UseBackColor = true;
            this.tablePanel1.Columns.AddRange(new DevExpress.Utils.Layout.TablePanelColumn[] {
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 20.45F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 84.55F)});
            this.tablePanel1.Controls.Add(this.tablePanel3);
            this.tablePanel1.Controls.Add(this.gv_NhomQuyen);
            this.tablePanel1.Controls.Add(this.stackPanel1);
            this.tablePanel1.Controls.Add(this.panel1);
            this.tablePanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tablePanel1.Location = new System.Drawing.Point(0, 0);
            this.tablePanel1.Margin = new System.Windows.Forms.Padding(15);
            this.tablePanel1.Name = "tablePanel1";
            this.tablePanel1.Rows.AddRange(new DevExpress.Utils.Layout.TablePanelRow[] {
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 161.2004F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 315.597F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 26F)});
            this.tablePanel1.Size = new System.Drawing.Size(1285, 855);
            this.tablePanel1.TabIndex = 3;
            // 
            // tablePanel3
            // 
            this.tablePanel1.SetColumn(this.tablePanel3, 1);
            this.tablePanel3.Columns.AddRange(new DevExpress.Utils.Layout.TablePanelColumn[] {
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 29.72F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 30.28F)});
            this.tablePanel3.Controls.Add(this.btnBackPermission);
            this.tablePanel3.Controls.Add(this.btnSavePermission);
            this.tablePanel3.Controls.Add(this.gv_PhanQuyen);
            this.tablePanel3.Controls.Add(this.lblPhanQuyen);
            this.tablePanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tablePanel3.LabelVertAlignment = DevExpress.Utils.Layout.LabelVertAlignment.Center;
            this.tablePanel3.Location = new System.Drawing.Point(253, 480);
            this.tablePanel3.Name = "tablePanel3";
            this.tablePanel1.SetRow(this.tablePanel3, 2);
            this.tablePanel3.Rows.AddRange(new DevExpress.Utils.Layout.TablePanelRow[] {
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 52.40007F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 263.6003F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 26F)});
            this.tablePanel3.Size = new System.Drawing.Size(1029, 372);
            this.tablePanel3.TabIndex = 4;
            // 
            // btnBackPermission
            // 
            this.btnBackPermission.Appearance.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBackPermission.Appearance.ForeColor = System.Drawing.Color.DarkGreen;
            this.btnBackPermission.Appearance.Options.UseFont = true;
            this.btnBackPermission.Appearance.Options.UseForeColor = true;
            this.tablePanel3.SetColumn(this.btnBackPermission, 0);
            this.btnBackPermission.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnBackPermission.ImageOptions.Image = global::QL_Vat_Lieu_Xay_Dung_WDF_Core.Properties.Resources.backward_32x32;
            this.btnBackPermission.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnBackPermission.Location = new System.Drawing.Point(3, 319);
            this.btnBackPermission.Name = "btnBackPermission";
            this.btnBackPermission.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.tablePanel3.SetRow(this.btnBackPermission, 2);
            this.btnBackPermission.Size = new System.Drawing.Size(504, 50);
            this.btnBackPermission.TabIndex = 31;
            this.btnBackPermission.Text = "Back";
            this.btnBackPermission.Click += new System.EventHandler(this.btnBackPermission_Click);
            // 
            // btnSavePermission
            // 
            this.btnSavePermission.Appearance.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold);
            this.btnSavePermission.Appearance.Options.UseFont = true;
            this.tablePanel3.SetColumn(this.btnSavePermission, 1);
            this.btnSavePermission.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSavePermission.Location = new System.Drawing.Point(560, 319);
            this.btnSavePermission.Margin = new System.Windows.Forms.Padding(50, 3, 50, 3);
            this.btnSavePermission.Name = "btnSavePermission";
            this.btnSavePermission.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.tablePanel3.SetRow(this.btnSavePermission, 2);
            this.btnSavePermission.Size = new System.Drawing.Size(419, 50);
            this.btnSavePermission.TabIndex = 2;
            this.btnSavePermission.Text = "Lưu";
            this.btnSavePermission.Click += new System.EventHandler(this.btnSavePermission_Click);
            // 
            // gv_PhanQuyen
            // 
            this.tablePanel3.SetColumn(this.gv_PhanQuyen, 0);
            this.tablePanel3.SetColumnSpan(this.gv_PhanQuyen, 2);
            this.gv_PhanQuyen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gv_PhanQuyen.Location = new System.Drawing.Point(3, 55);
            this.gv_PhanQuyen.MainView = this.grid_PhanQuyen;
            this.gv_PhanQuyen.Name = "gv_PhanQuyen";
            this.gv_PhanQuyen.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit});
            this.tablePanel3.SetRow(this.gv_PhanQuyen, 1);
            this.gv_PhanQuyen.Size = new System.Drawing.Size(1023, 258);
            this.gv_PhanQuyen.TabIndex = 1;
            this.gv_PhanQuyen.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grid_PhanQuyen});
            // 
            // grid_PhanQuyen
            // 
            this.grid_PhanQuyen.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colP_RoleId,
            this.colP_FunctionId,
            this.colFunctionName,
            this.colP_CanRead,
            this.colP_CanCreate,
            this.colP_CanUpdate,
            this.colP_CanDelete});
            this.grid_PhanQuyen.GridControl = this.gv_PhanQuyen;
            this.grid_PhanQuyen.Name = "grid_PhanQuyen";
            this.grid_PhanQuyen.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.grid_PhanQuyen.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.grid_PhanQuyen_CellValueChanged);
            this.grid_PhanQuyen.CellValueChanging += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.grid_PhanQuyen_CellValueChanging);
            // 
            // colP_RoleId
            // 
            this.colP_RoleId.AppearanceHeader.Options.UseTextOptions = true;
            this.colP_RoleId.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colP_RoleId.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colP_RoleId.Caption = "Role Id";
            this.colP_RoleId.FieldName = "RoleId";
            this.colP_RoleId.MinWidth = 25;
            this.colP_RoleId.Name = "colP_RoleId";
            this.colP_RoleId.Width = 94;
            this.colP_RoleId.OptionsFilter.AllowFilter = false;
            // 
            // colP_FunctionId
            // 
            this.colP_FunctionId.AppearanceHeader.Options.UseTextOptions = true;
            this.colP_FunctionId.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colP_FunctionId.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colP_FunctionId.Caption = "Function Id";
            this.colP_FunctionId.FieldName = "FunctionId";
            this.colP_FunctionId.MinWidth = 25;
            this.colP_FunctionId.Name = "colP_FunctionId";
            this.colP_FunctionId.Width = 94;
            this.colP_FunctionId.OptionsFilter.AllowFilter = false;
            // 
            // colFunctionName
            // 
            this.colFunctionName.AppearanceHeader.Options.UseTextOptions = true;
            this.colFunctionName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colFunctionName.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colFunctionName.Caption = "Name";
            this.colFunctionName.FieldName = "Name";
            this.colFunctionName.MinWidth = 25;
            this.colFunctionName.Name = "colFunctionName";
            this.colFunctionName.Visible = true;
            this.colFunctionName.VisibleIndex = 0;
            this.colFunctionName.Width = 94;
            this.colFunctionName.OptionsFilter.AllowFilter = false;
            // 
            // colP_CanRead
            // 
            this.colP_CanRead.AppearanceHeader.Options.UseTextOptions = true;
            this.colP_CanRead.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colP_CanRead.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colP_CanRead.Caption = "Can Read";
            this.colP_CanRead.ColumnEdit = this.repositoryItemCheckEdit;
            this.colP_CanRead.FieldName = "CanRead";
            this.colP_CanRead.MinWidth = 25;
            this.colP_CanRead.Name = "colP_CanRead";
            this.colP_CanRead.Visible = true;
            this.colP_CanRead.VisibleIndex = 1;
            this.colP_CanRead.Width = 94;
            this.colP_CanRead.OptionsFilter.AllowFilter = false;
            // 
            // colP_CanCreate
            // 
            this.colP_CanCreate.AppearanceHeader.Options.UseTextOptions = true;
            this.colP_CanCreate.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colP_CanCreate.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colP_CanCreate.Caption = "Can Create";
            this.colP_CanCreate.ColumnEdit = this.repositoryItemCheckEdit;
            this.colP_CanCreate.FieldName = "CanCreate";
            this.colP_CanCreate.MinWidth = 25;
            this.colP_CanCreate.Name = "colP_CanCreate";
            this.colP_CanCreate.Visible = true;
            this.colP_CanCreate.VisibleIndex = 2;
            this.colP_CanCreate.Width = 94;
            this.colP_CanCreate.OptionsFilter.AllowFilter = false;
            // 
            // colP_CanUpdate
            // 
            this.colP_CanUpdate.AppearanceHeader.Options.UseTextOptions = true;
            this.colP_CanUpdate.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colP_CanUpdate.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colP_CanUpdate.Caption = "Can Update";
            this.colP_CanUpdate.ColumnEdit = this.repositoryItemCheckEdit;
            this.colP_CanUpdate.FieldName = "CanUpdate";
            this.colP_CanUpdate.MinWidth = 25;
            this.colP_CanUpdate.Name = "colP_CanUpdate";
            this.colP_CanUpdate.UnboundType = DevExpress.Data.UnboundColumnType.Boolean;
            this.colP_CanUpdate.Visible = true;
            this.colP_CanUpdate.VisibleIndex = 3;
            this.colP_CanUpdate.OptionsFilter.AllowFilter = false;
            this.colP_CanUpdate.Width = 94;
            // 
            // colP_CanDelete
            // 
            this.colP_CanDelete.AppearanceHeader.Options.UseTextOptions = true;
            this.colP_CanDelete.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colP_CanDelete.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colP_CanDelete.Caption = "Can Delete";
            this.colP_CanDelete.ColumnEdit = this.repositoryItemCheckEdit;
            this.colP_CanDelete.FieldName = "CanDelete";
            this.colP_CanDelete.MinWidth = 25;
            this.colP_CanDelete.Name = "colP_CanDelete";
            this.colP_CanDelete.UnboundType = DevExpress.Data.UnboundColumnType.Boolean;
            this.colP_CanDelete.Visible = true;
            this.colP_CanDelete.VisibleIndex = 4;
            this.colP_CanDelete.Width = 94;
            this.colP_CanDelete.OptionsFilter.AllowFilter = false;
            // 
            // lblPhanQuyen
            // 
            this.lblPhanQuyen.AutoSize = true;
            this.tablePanel3.SetColumn(this.lblPhanQuyen, 0);
            this.tablePanel3.SetColumnSpan(this.lblPhanQuyen, 2);
            this.lblPhanQuyen.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPhanQuyen.Location = new System.Drawing.Point(30, 15);
            this.lblPhanQuyen.Margin = new System.Windows.Forms.Padding(30, 0, 3, 0);
            this.lblPhanQuyen.Name = "lblPhanQuyen";
            this.tablePanel3.SetRow(this.lblPhanQuyen, 0);
            this.lblPhanQuyen.Size = new System.Drawing.Size(111, 21);
            this.lblPhanQuyen.TabIndex = 0;
            this.lblPhanQuyen.Text = "Phân quyền";
            this.lblPhanQuyen.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gv_NhomQuyen
            // 
            this.tablePanel1.SetColumn(this.gv_NhomQuyen, 1);
            this.gv_NhomQuyen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gv_NhomQuyen.Location = new System.Drawing.Point(253, 164);
            this.gv_NhomQuyen.MainView = this.grid_NhomQuyen;
            this.gv_NhomQuyen.Name = "gv_NhomQuyen";
            this.tablePanel1.SetRow(this.gv_NhomQuyen, 1);
            this.gv_NhomQuyen.Size = new System.Drawing.Size(1029, 310);
            this.gv_NhomQuyen.TabIndex = 3;
            this.gv_NhomQuyen.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grid_NhomQuyen});
            // 
            // grid_NhomQuyen
            // 
            this.grid_NhomQuyen.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colRoleId,
            this.colRoleName,
            this.colRoleDescription});
            this.grid_NhomQuyen.GridControl = this.gv_NhomQuyen;
            this.grid_NhomQuyen.Name = "grid_NhomQuyen";
            this.grid_NhomQuyen.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.grid_NhomQuyen_RowCellClick);
            // 
            // colRoleId
            // 
            this.colRoleId.AppearanceCell.Options.UseTextOptions = true;
            this.colRoleId.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colRoleId.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colRoleId.AppearanceHeader.Options.UseTextOptions = true;
            this.colRoleId.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colRoleId.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colRoleId.Caption = "Id";
            this.colRoleId.FieldName = "Id";
            this.colRoleId.MinWidth = 25;
            this.colRoleId.Name = "colRoleId";
            this.colRoleId.OptionsColumn.AllowEdit = false;
            this.colRoleId.OptionsColumn.ReadOnly = true;
            this.colRoleId.Width = 94;
            // 
            // colRoleName
            // 
            this.colRoleName.AppearanceCell.Options.UseTextOptions = true;
            this.colRoleName.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colRoleName.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colRoleName.AppearanceHeader.Options.UseTextOptions = true;
            this.colRoleName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colRoleName.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colRoleName.Caption = "Name";
            this.colRoleName.FieldName = "Name";
            this.colRoleName.MinWidth = 25;
            this.colRoleName.Name = "colRoleName";
            this.colRoleName.OptionsColumn.AllowEdit = false;
            this.colRoleName.OptionsColumn.ReadOnly = true;
            this.colRoleName.Visible = true;
            this.colRoleName.VisibleIndex = 0;
            this.colRoleName.Width = 94;
            // 
            // colRoleDescription
            // 
            this.colRoleDescription.AppearanceCell.Options.UseTextOptions = true;
            this.colRoleDescription.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colRoleDescription.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colRoleDescription.AppearanceHeader.Options.UseTextOptions = true;
            this.colRoleDescription.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colRoleDescription.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colRoleDescription.Caption = "Description";
            this.colRoleDescription.FieldName = "Description";
            this.colRoleDescription.MinWidth = 25;
            this.colRoleDescription.Name = "colRoleDescription";
            this.colRoleDescription.OptionsColumn.AllowEdit = false;
            this.colRoleDescription.OptionsColumn.ReadOnly = true;
            this.colRoleDescription.Visible = true;
            this.colRoleDescription.VisibleIndex = 1;
            this.colRoleDescription.Width = 94;
            // 
            // stackPanel1
            // 
            this.stackPanel1.Appearance.BackColor = System.Drawing.Color.White;
            this.stackPanel1.Appearance.Options.UseBackColor = true;
            this.tablePanel1.SetColumn(this.stackPanel1, 0);
            this.stackPanel1.Controls.Add(this.btnThem);
            this.stackPanel1.Controls.Add(this.btnSua);
            this.stackPanel1.Controls.Add(this.btnXoa);
            this.stackPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stackPanel1.LayoutDirection = DevExpress.Utils.Layout.StackPanelLayoutDirection.TopDown;
            this.stackPanel1.Location = new System.Drawing.Point(3, 164);
            this.stackPanel1.Name = "stackPanel1";
            this.tablePanel1.SetRow(this.stackPanel1, 1);
            this.tablePanel1.SetRowSpan(this.stackPanel1, 2);
            this.stackPanel1.Size = new System.Drawing.Size(244, 688);
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
            this.btnThem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnThem.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnThem.ImageOptions.SvgImage = global::QL_Vat_Lieu_Xay_Dung_WDF_Core.Properties.Resources.addparameter;
            this.btnThem.Location = new System.Drawing.Point(8, 3);
            this.btnThem.Margin = new System.Windows.Forms.Padding(20, 3, 20, 3);
            this.btnThem.Name = "btnThem";
            this.btnThem.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnThem.Size = new System.Drawing.Size(228, 80);
            this.btnThem.TabIndex = 2;
            this.btnThem.Text = "Thêm nhóm quyền";
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
            this.btnSua.ImageOptions.Image = global::QL_Vat_Lieu_Xay_Dung_WDF_Core.Properties.Resources.edittask_32x32;
            this.btnSua.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnSua.Location = new System.Drawing.Point(7, 89);
            this.btnSua.Margin = new System.Windows.Forms.Padding(20, 3, 20, 3);
            this.btnSua.Name = "btnSua";
            this.btnSua.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnSua.Size = new System.Drawing.Size(230, 80);
            this.btnSua.TabIndex = 3;
            this.btnSua.Text = "Sửa nhóm quyền";
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
            this.btnXoa.ImageOptions.Image = global::QL_Vat_Lieu_Xay_Dung_WDF_Core.Properties.Resources.removepivotfield_32x32;
            this.btnXoa.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnXoa.Location = new System.Drawing.Point(10, 175);
            this.btnXoa.Margin = new System.Windows.Forms.Padding(20, 3, 20, 3);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnXoa.Size = new System.Drawing.Size(224, 80);
            this.btnXoa.TabIndex = 4;
            this.btnXoa.Text = "Xoá nhóm quyền";
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // repositoryItemCheckEdit
            // 
            this.repositoryItemCheckEdit.AutoHeight = false;
            this.repositoryItemCheckEdit.Name = "repositoryItemCheckEdit";
            this.repositoryItemCheckEdit.EditValueChanged += new System.EventHandler(this.repositoryItemCheckEdit_EditValueChanged);
            // 
            // frmNhomQuyen
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1285, 855);
            this.Controls.Add(this.tablePanel1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmNhomQuyen";
            this.Text = "Form Nhóm quyền";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmNhomQuyen_FormClosing);
            this.Load += new System.EventHandler(this.frmNhomQuyen_Load);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel2)).EndInit();
            this.tablePanel2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNhomQuyen.Properties)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel1)).EndInit();
            this.tablePanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel3)).EndInit();
            this.tablePanel3.ResumeLayout(false);
            this.tablePanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gv_PhanQuyen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid_PhanQuyen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_NhomQuyen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid_NhomQuyen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stackPanel1)).EndInit();
            this.stackPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private DevExpress.Utils.Layout.TablePanel tablePanel2;
        private System.Windows.Forms.Panel panel2;
        private DevExpress.XtraEditors.LabelControl lblMoTa;
        private DevExpress.XtraEditors.TextEdit txtNhomQuyen;
        private DevExpress.XtraEditors.LabelControl lblNhomQuyen;
        private DevExpress.XtraEditors.SimpleButton btnBack;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.Utils.Layout.TablePanel tablePanel1;
        private DevExpress.Utils.Layout.StackPanel stackPanel1;
        private DevExpress.XtraEditors.SimpleButton btnThem;
        private DevExpress.XtraEditors.SimpleButton btnSua;
        private DevExpress.XtraEditors.SimpleButton btnXoa;
        private System.Windows.Forms.TextBox txtMoTa;
        private DevExpress.XtraGrid.GridControl gv_NhomQuyen;
        private DevExpress.XtraGrid.Views.Grid.GridView grid_NhomQuyen;
        private DevExpress.XtraGrid.Columns.GridColumn colRoleId;
        private DevExpress.XtraGrid.Columns.GridColumn colRoleName;
        private DevExpress.XtraGrid.Columns.GridColumn colRoleDescription;
        private DevExpress.Utils.Layout.TablePanel tablePanel3;
        private DevExpress.XtraEditors.SimpleButton btnBackPermission;
        private DevExpress.XtraEditors.SimpleButton btnSavePermission;
        private DevExpress.XtraGrid.GridControl gv_PhanQuyen;
        private DevExpress.XtraGrid.Views.Grid.GridView grid_PhanQuyen;
        private DevExpress.XtraGrid.Columns.GridColumn colP_RoleId;
        private DevExpress.XtraGrid.Columns.GridColumn colP_FunctionId;
        private DevExpress.XtraGrid.Columns.GridColumn colFunctionName;
        private DevExpress.XtraGrid.Columns.GridColumn colP_CanRead;
        private DevExpress.XtraGrid.Columns.GridColumn colP_CanCreate;
        private DevExpress.XtraGrid.Columns.GridColumn colP_CanUpdate;
        private DevExpress.XtraGrid.Columns.GridColumn colP_CanDelete;
        private System.Windows.Forms.Label lblPhanQuyen;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit;
    }
}