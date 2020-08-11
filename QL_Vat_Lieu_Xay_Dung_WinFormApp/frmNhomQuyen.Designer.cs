namespace QL_Vat_Lieu_Xay_Dung_WinFormApp
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
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.gv_PhanQuyen = new DevExpress.XtraGrid.GridControl();
            this.grid_PhanQuyen = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.lblPhanQuyen = new System.Windows.Forms.Label();
            this.gv_NhomQuyen = new DevExpress.XtraGrid.GridControl();
            this.grid_NhomQuyen = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.stackPanel1 = new DevExpress.Utils.Layout.StackPanel();
            this.btnThem = new DevExpress.XtraEditors.SimpleButton();
            this.btnSua = new DevExpress.XtraEditors.SimpleButton();
            this.btnXoa = new DevExpress.XtraEditors.SimpleButton();
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
            this.btnBack.ImageOptions.Image = global::QL_Vat_Lieu_Xay_Dung_WinFormApp.Properties.Resources.backward_32x32;
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
            this.tablePanel3.Controls.Add(this.simpleButton1);
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
            // simpleButton1
            // 
            this.simpleButton1.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton1.Appearance.Options.UseFont = true;
            this.tablePanel3.SetColumn(this.simpleButton1, 1);
            this.simpleButton1.Location = new System.Drawing.Point(560, 319);
            this.simpleButton1.Margin = new System.Windows.Forms.Padding(50, 3, 50, 3);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.tablePanel3.SetRow(this.simpleButton1, 2);
            this.simpleButton1.Size = new System.Drawing.Size(419, 50);
            this.simpleButton1.TabIndex = 2;
            this.simpleButton1.Text = "Lưu";
            // 
            // gv_PhanQuyen
            // 
            this.tablePanel3.SetColumn(this.gv_PhanQuyen, 0);
            this.tablePanel3.SetColumnSpan(this.gv_PhanQuyen, 2);
            this.gv_PhanQuyen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gv_PhanQuyen.Location = new System.Drawing.Point(3, 55);
            this.gv_PhanQuyen.MainView = this.grid_PhanQuyen;
            this.gv_PhanQuyen.Name = "gv_PhanQuyen";
            this.tablePanel3.SetRow(this.gv_PhanQuyen, 1);
            this.gv_PhanQuyen.Size = new System.Drawing.Size(1023, 258);
            this.gv_PhanQuyen.TabIndex = 1;
            this.gv_PhanQuyen.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grid_PhanQuyen});
            // 
            // grid_PhanQuyen
            // 
            this.grid_PhanQuyen.GridControl = this.gv_PhanQuyen;
            this.grid_PhanQuyen.Name = "grid_PhanQuyen";
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
            this.grid_NhomQuyen.GridControl = this.gv_NhomQuyen;
            this.grid_NhomQuyen.Name = "grid_NhomQuyen";
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
            this.btnThem.ImageOptions.SvgImage = global::QL_Vat_Lieu_Xay_Dung_WinFormApp.Properties.Resources.addparameter;
            this.btnThem.Location = new System.Drawing.Point(8, 3);
            this.btnThem.Margin = new System.Windows.Forms.Padding(20, 3, 20, 3);
            this.btnThem.Name = "btnThem";
            this.btnThem.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnThem.Size = new System.Drawing.Size(228, 80);
            this.btnThem.TabIndex = 2;
            this.btnThem.Text = "Thêm nhớm quyền";
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
            this.btnSua.ImageOptions.Image = global::QL_Vat_Lieu_Xay_Dung_WinFormApp.Properties.Resources.edittask_32x32;
            this.btnSua.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnSua.Location = new System.Drawing.Point(7, 89);
            this.btnSua.Margin = new System.Windows.Forms.Padding(20, 3, 20, 3);
            this.btnSua.Name = "btnSua";
            this.btnSua.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnSua.Size = new System.Drawing.Size(230, 80);
            this.btnSua.TabIndex = 3;
            this.btnSua.Text = "Sửa nhớm quyền";
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
            this.btnXoa.ImageOptions.Image = global::QL_Vat_Lieu_Xay_Dung_WinFormApp.Properties.Resources.removepivotfield_32x32;
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
        private DevExpress.Utils.Layout.TablePanel tablePanel3;
        private System.Windows.Forms.Label lblPhanQuyen;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraGrid.GridControl gv_PhanQuyen;
        private DevExpress.XtraGrid.Views.Grid.GridView grid_PhanQuyen;
    }
}