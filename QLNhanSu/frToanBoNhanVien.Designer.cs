
namespace QLHS.QLNhanSu
{
    partial class frToanBoNhanVien
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frToanBoNhanVien));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.NAVI_Panel_Bottom = new System.Windows.Forms.Panel();
            this.NAVI_expPanel = new DevComponents.DotNetBar.ExpandablePanel();
            this.txtIDCurrent = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.btnPrevous = new DevComponents.DotNetBar.ButtonX();
            this.btnLast = new DevComponents.DotNetBar.ButtonX();
            this.btnFirst = new DevComponents.DotNetBar.ButtonX();
            this.btnNext = new DevComponents.DotNetBar.ButtonX();
            this.bar1 = new DevComponents.DotNetBar.Bar();
            this.btnThemHoSo = new DevComponents.DotNetBar.ButtonItem();
            this.btnSuaHoSo = new DevComponents.DotNetBar.ButtonItem();
            this.btnXoaHoSo = new DevComponents.DotNetBar.ButtonItem();
            this.btnF5HoSo = new DevComponents.DotNetBar.ButtonItem();
            this.btnCloseHoSo = new DevComponents.DotNetBar.ButtonItem();
            this.expandPanelGridView = new DevComponents.DotNetBar.ExpandablePanel();
            this.dgv_nhansu = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.STT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaNhanVien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NAVI_Panel_Bottom.SuspendLayout();
            this.NAVI_expPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).BeginInit();
            this.expandPanelGridView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_nhansu)).BeginInit();
            this.SuspendLayout();
            // 
            // NAVI_Panel_Bottom
            // 
            this.NAVI_Panel_Bottom.Controls.Add(this.NAVI_expPanel);
            this.NAVI_Panel_Bottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.NAVI_Panel_Bottom.Location = new System.Drawing.Point(0, 495);
            this.NAVI_Panel_Bottom.Name = "NAVI_Panel_Bottom";
            this.NAVI_Panel_Bottom.Size = new System.Drawing.Size(830, 26);
            this.NAVI_Panel_Bottom.TabIndex = 29;
            // 
            // NAVI_expPanel
            // 
            this.NAVI_expPanel.CanvasColor = System.Drawing.SystemColors.Control;
            this.NAVI_expPanel.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.NAVI_expPanel.Controls.Add(this.txtIDCurrent);
            this.NAVI_expPanel.Controls.Add(this.btnPrevous);
            this.NAVI_expPanel.Controls.Add(this.btnLast);
            this.NAVI_expPanel.Controls.Add(this.btnFirst);
            this.NAVI_expPanel.Controls.Add(this.btnNext);
            this.NAVI_expPanel.DisabledBackColor = System.Drawing.Color.Empty;
            this.NAVI_expPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NAVI_expPanel.HideControlsWhenCollapsed = true;
            this.NAVI_expPanel.Location = new System.Drawing.Point(0, 0);
            this.NAVI_expPanel.Name = "NAVI_expPanel";
            this.NAVI_expPanel.Size = new System.Drawing.Size(830, 26);
            this.NAVI_expPanel.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.NAVI_expPanel.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.NAVI_expPanel.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(210)))), ((int)(((byte)(255)))));
            this.NAVI_expPanel.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.NAVI_expPanel.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.NAVI_expPanel.Style.BorderSide = DevComponents.DotNetBar.eBorderSide.Bottom;
            this.NAVI_expPanel.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.NAVI_expPanel.Style.GradientAngle = 90;
            this.NAVI_expPanel.TabIndex = 4;
            this.NAVI_expPanel.TitleHeight = 0;
            this.NAVI_expPanel.TitleStyle.Alignment = System.Drawing.StringAlignment.Center;
            this.NAVI_expPanel.TitleStyle.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.NAVI_expPanel.TitleStyle.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.NAVI_expPanel.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.RaisedInner;
            this.NAVI_expPanel.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.NAVI_expPanel.TitleStyle.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.NAVI_expPanel.TitleStyle.GradientAngle = 90;
            this.NAVI_expPanel.TitleText = "Title Bar";
            // 
            // txtIDCurrent
            // 
            // 
            // 
            // 
            this.txtIDCurrent.Border.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtIDCurrent.Border.BorderBottomWidth = 1;
            this.txtIDCurrent.Border.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarCaptionBackground;
            this.txtIDCurrent.Border.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtIDCurrent.Border.BorderLeftWidth = 1;
            this.txtIDCurrent.Border.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtIDCurrent.Border.BorderRightWidth = 1;
            this.txtIDCurrent.Border.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtIDCurrent.Border.BorderTopWidth = 1;
            this.txtIDCurrent.Border.Class = "TextBoxBorder";
            this.txtIDCurrent.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtIDCurrent.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIDCurrent.Location = new System.Drawing.Point(36, 4);
            this.txtIDCurrent.Name = "txtIDCurrent";
            this.txtIDCurrent.ReadOnly = true;
            this.txtIDCurrent.Size = new System.Drawing.Size(60, 19);
            this.txtIDCurrent.TabIndex = 32;
            this.txtIDCurrent.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnPrevous
            // 
            this.btnPrevous.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnPrevous.BackColor = System.Drawing.Color.Transparent;
            this.btnPrevous.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnPrevous.FocusCuesEnabled = false;
            this.btnPrevous.Image = ((System.Drawing.Image)(resources.GetObject("btnPrevous.Image")));
            this.btnPrevous.Location = new System.Drawing.Point(20, 5);
            this.btnPrevous.Name = "btnPrevous";
            this.btnPrevous.Size = new System.Drawing.Size(16, 15);
            this.btnPrevous.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnPrevous.TabIndex = 29;
            this.btnPrevous.Tooltip = "Hồ sơ trước";
            // 
            // btnLast
            // 
            this.btnLast.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnLast.BackColor = System.Drawing.Color.Transparent;
            this.btnLast.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnLast.FocusCuesEnabled = false;
            this.btnLast.Image = ((System.Drawing.Image)(resources.GetObject("btnLast.Image")));
            this.btnLast.Location = new System.Drawing.Point(114, 5);
            this.btnLast.Name = "btnLast";
            this.btnLast.Size = new System.Drawing.Size(16, 15);
            this.btnLast.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnLast.TabIndex = 31;
            this.btnLast.Tooltip = "Hồ sơ cuối";
            // 
            // btnFirst
            // 
            this.btnFirst.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnFirst.BackColor = System.Drawing.Color.Transparent;
            this.btnFirst.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnFirst.FocusCuesEnabled = false;
            this.btnFirst.Image = ((System.Drawing.Image)(resources.GetObject("btnFirst.Image")));
            this.btnFirst.Location = new System.Drawing.Point(4, 5);
            this.btnFirst.Name = "btnFirst";
            this.btnFirst.Size = new System.Drawing.Size(16, 15);
            this.btnFirst.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnFirst.TabIndex = 28;
            this.btnFirst.Tooltip = "Hồ sơ đầu tiên";
            // 
            // btnNext
            // 
            this.btnNext.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnNext.BackColor = System.Drawing.Color.Transparent;
            this.btnNext.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnNext.FocusCuesEnabled = false;
            this.btnNext.Image = ((System.Drawing.Image)(resources.GetObject("btnNext.Image")));
            this.btnNext.Location = new System.Drawing.Point(98, 5);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(16, 15);
            this.btnNext.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnNext.TabIndex = 30;
            this.btnNext.Tooltip = "Hồ sơ kế tiếp";
            // 
            // bar1
            // 
            this.bar1.AntiAlias = true;
            this.bar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.bar1.EqualButtonSize = true;
            this.bar1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bar1.IsMaximized = false;
            this.bar1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnThemHoSo,
            this.btnSuaHoSo,
            this.btnXoaHoSo,
            this.btnF5HoSo,
            this.btnCloseHoSo});
            this.bar1.ItemSpacing = 7;
            this.bar1.Location = new System.Drawing.Point(0, 0);
            this.bar1.Name = "bar1";
            this.bar1.Size = new System.Drawing.Size(830, 52);
            this.bar1.Stretch = true;
            this.bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bar1.TabIndex = 30;
            this.bar1.TabStop = false;
            this.bar1.Text = "barToanBoNhanSu";
            this.bar1.ItemClick += new System.EventHandler(this.bar1_ItemClick);
            // 
            // btnThemHoSo
            // 
            this.btnThemHoSo.BeginGroup = true;
            this.btnThemHoSo.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnThemHoSo.Image = ((System.Drawing.Image)(resources.GetObject("btnThemHoSo.Image")));
            this.btnThemHoSo.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnThemHoSo.Name = "btnThemHoSo";
            this.btnThemHoSo.Text = "Thêm nhân viên";
            this.btnThemHoSo.Tooltip = "Thêm nhân sự";
            this.btnThemHoSo.Click += new System.EventHandler(this.btnThemHoSo_Click);
            // 
            // btnSuaHoSo
            // 
            this.btnSuaHoSo.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnSuaHoSo.Image = ((System.Drawing.Image)(resources.GetObject("btnSuaHoSo.Image")));
            this.btnSuaHoSo.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnSuaHoSo.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Center;
            this.btnSuaHoSo.Name = "btnSuaHoSo";
            this.btnSuaHoSo.RibbonWordWrap = false;
            this.btnSuaHoSo.Text = "Sửa thông tin";
            this.btnSuaHoSo.Tooltip = "Sửa thông tin hồ sơ";
            this.btnSuaHoSo.Click += new System.EventHandler(this.btnSuaHoSo_Click);
            // 
            // btnXoaHoSo
            // 
            this.btnXoaHoSo.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnXoaHoSo.Image = ((System.Drawing.Image)(resources.GetObject("btnXoaHoSo.Image")));
            this.btnXoaHoSo.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnXoaHoSo.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Center;
            this.btnXoaHoSo.Name = "btnXoaHoSo";
            this.btnXoaHoSo.RibbonWordWrap = false;
            this.btnXoaHoSo.Text = "Xóa nhân viên";
            this.btnXoaHoSo.Tooltip = "Xóa hồ sơ đang chọn";
            this.btnXoaHoSo.Click += new System.EventHandler(this.btnXoaHoSo_Click);
            // 
            // btnF5HoSo
            // 
            this.btnF5HoSo.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnF5HoSo.Image = ((System.Drawing.Image)(resources.GetObject("btnF5HoSo.Image")));
            this.btnF5HoSo.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnF5HoSo.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Center;
            this.btnF5HoSo.Name = "btnF5HoSo";
            this.btnF5HoSo.RibbonWordWrap = false;
            this.btnF5HoSo.Text = "Làm mới";
            this.btnF5HoSo.Tooltip = "Cập nhật lại dữ liệu";
            this.btnF5HoSo.Click += new System.EventHandler(this.btnF5HoSo_Click);
            // 
            // btnCloseHoSo
            // 
            this.btnCloseHoSo.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnCloseHoSo.Image = ((System.Drawing.Image)(resources.GetObject("btnCloseHoSo.Image")));
            this.btnCloseHoSo.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnCloseHoSo.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Center;
            this.btnCloseHoSo.Name = "btnCloseHoSo";
            this.btnCloseHoSo.Text = "Đóng";
            this.btnCloseHoSo.Tooltip = "Đóng cửa sổ";
            this.btnCloseHoSo.Click += new System.EventHandler(this.btnCloseHoSo_Click);
            // 
            // expandPanelGridView
            // 
            this.expandPanelGridView.CanvasColor = System.Drawing.SystemColors.Control;
            this.expandPanelGridView.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.expandPanelGridView.Controls.Add(this.dgv_nhansu);
            this.expandPanelGridView.DisabledBackColor = System.Drawing.Color.Empty;
            this.expandPanelGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.expandPanelGridView.HideControlsWhenCollapsed = true;
            this.expandPanelGridView.Location = new System.Drawing.Point(0, 52);
            this.expandPanelGridView.Name = "expandPanelGridView";
            this.expandPanelGridView.Padding = new System.Windows.Forms.Padding(4);
            this.expandPanelGridView.Size = new System.Drawing.Size(830, 443);
            this.expandPanelGridView.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.expandPanelGridView.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.expandPanelGridView.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.expandPanelGridView.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.expandPanelGridView.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.expandPanelGridView.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expandPanelGridView.Style.GradientAngle = 90;
            this.expandPanelGridView.TabIndex = 34;
            this.expandPanelGridView.TitleHeight = 0;
            this.expandPanelGridView.TitleStyle.Alignment = System.Drawing.StringAlignment.Center;
            this.expandPanelGridView.TitleStyle.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.expandPanelGridView.TitleStyle.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.expandPanelGridView.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.RaisedInner;
            this.expandPanelGridView.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandPanelGridView.TitleStyle.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.expandPanelGridView.TitleStyle.GradientAngle = 90;
            this.expandPanelGridView.TitleText = "Title Bar";
            // 
            // dgv_nhansu
            // 
            this.dgv_nhansu.AllowUserToAddRows = false;
            this.dgv_nhansu.AllowUserToOrderColumns = true;
            this.dgv_nhansu.BackgroundColor = System.Drawing.SystemColors.HighlightText;
            this.dgv_nhansu.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(0, 3, 0, 6);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_nhansu.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_nhansu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_nhansu.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.STT,
            this.MaNhanVien,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column1});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_nhansu.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_nhansu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_nhansu.EnableHeadersVisualStyles = false;
            this.dgv_nhansu.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgv_nhansu.HighlightSelectedColumnHeaders = false;
            this.dgv_nhansu.Location = new System.Drawing.Point(4, 4);
            this.dgv_nhansu.Margin = new System.Windows.Forms.Padding(1);
            this.dgv_nhansu.Name = "dgv_nhansu";
            this.dgv_nhansu.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_nhansu.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_nhansu.RowHeadersWidth = 30;
            this.dgv_nhansu.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 14F);
            this.dgv_nhansu.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_nhansu.RowTemplate.Height = 80;
            this.dgv_nhansu.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_nhansu.Size = new System.Drawing.Size(822, 435);
            this.dgv_nhansu.TabIndex = 4;
            this.dgv_nhansu.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgv_nhansu_CellFormatting);
            this.dgv_nhansu.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgv_nhansu_CellMouseUp);
            // 
            // STT
            // 
            this.STT.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.STT.FillWeight = 30F;
            this.STT.HeaderText = "STT";
            this.STT.MinimumWidth = 6;
            this.STT.Name = "STT";
            this.STT.ReadOnly = true;
            // 
            // MaNhanVien
            // 
            this.MaNhanVien.DataPropertyName = "MaNhanVien";
            this.MaNhanVien.HeaderText = "Mã nhân viên";
            this.MaNhanVien.MinimumWidth = 6;
            this.MaNhanVien.Name = "MaNhanVien";
            this.MaNhanVien.ReadOnly = true;
            this.MaNhanVien.Visible = false;
            this.MaNhanVien.Width = 110;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column2.DataPropertyName = "tennhanvien";
            this.Column2.FillWeight = 200F;
            this.Column2.HeaderText = "Họ và tên";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column3.DataPropertyName = "capbachientai";
            this.Column3.FillWeight = 200F;
            this.Column3.HeaderText = "Cấp bậc";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column4.DataPropertyName = "chucvuhientai";
            this.Column4.FillWeight = 200F;
            this.Column4.HeaderText = "Chức vụ";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column1.DataPropertyName = "GhiChu";
            this.Column1.FillWeight = 100.0719F;
            this.Column1.HeaderText = "Ghi chú";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // frToanBoNhanVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ClientSize = new System.Drawing.Size(830, 521);
            this.Controls.Add(this.expandPanelGridView);
            this.Controls.Add(this.bar1);
            this.Controls.Add(this.NAVI_Panel_Bottom);
            this.DoubleBuffered = true;
            this.EnableGlass = false;
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frToanBoNhanVien";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frToanBoNhanSu";
            this.Load += new System.EventHandler(this.frToanBoNhanSu_Load);
            this.NAVI_Panel_Bottom.ResumeLayout(false);
            this.NAVI_expPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).EndInit();
            this.expandPanelGridView.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_nhansu)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel NAVI_Panel_Bottom;
        private DevComponents.DotNetBar.ExpandablePanel NAVI_expPanel;
        private DevComponents.DotNetBar.Controls.TextBoxX txtIDCurrent;
        private DevComponents.DotNetBar.ButtonX btnPrevous;
        private DevComponents.DotNetBar.ButtonX btnLast;
        private DevComponents.DotNetBar.ButtonX btnFirst;
        private DevComponents.DotNetBar.ButtonX btnNext;
        private DevComponents.DotNetBar.Bar bar1;
        private DevComponents.DotNetBar.ButtonItem btnThemHoSo;
        private DevComponents.DotNetBar.ButtonItem btnSuaHoSo;
        private DevComponents.DotNetBar.ButtonItem btnXoaHoSo;
        private DevComponents.DotNetBar.ButtonItem btnF5HoSo;
        private DevComponents.DotNetBar.ButtonItem btnCloseHoSo;
        private DevComponents.DotNetBar.ExpandablePanel expandPanelGridView;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgv_nhansu;
        private System.Windows.Forms.DataGridViewTextBoxColumn STT;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaNhanVien;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
    }
}