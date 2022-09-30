
using System.Drawing;

namespace QLHS
{
    partial class fMainQLHS
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fMainQLHS));
            this.timerHome = new System.Windows.Forms.Timer(this.components);
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.superTabMain = new DevComponents.DotNetBar.SuperTabControl();
            this.superTabControlPanel1 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.itemPanelStart = new DevComponents.DotNetBar.ItemPanel();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.TabItem0 = new DevComponents.DotNetBar.SuperTabItem();
            this.bar1 = new DevComponents.DotNetBar.Bar();
            this.lblTitle = new DevComponents.DotNetBar.LabelItem();
            this.lblTime = new DevComponents.DotNetBar.LabelItem();
            this.lblDay = new DevComponents.DotNetBar.LabelItem();
            this.styleManager1 = new DevComponents.DotNetBar.StyleManager(this.components);
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.buttonItem1 = new DevComponents.DotNetBar.ButtonItem();
            this.ribbonControlMain = new DevComponents.DotNetBar.RibbonControl();
            this.ribbonPanel3 = new DevComponents.DotNetBar.RibbonPanel();
            this.ribbonBar3 = new DevComponents.DotNetBar.RibbonBar();
            this.btn_huongdansd = new DevComponents.DotNetBar.ButtonItem();
            this.btn_thongtinpm = new DevComponents.DotNetBar.ButtonItem();
            this.ribbonPanel1 = new DevComponents.DotNetBar.RibbonPanel();
            this.ribbonBar2 = new DevComponents.DotNetBar.RibbonBar();
            this.btn_nhansu = new DevComponents.DotNetBar.ButtonItem();
            this.btn_chuyengia = new DevComponents.DotNetBar.ButtonItem();
            this.ribbonBar1 = new DevComponents.DotNetBar.RibbonBar();
            this.buttonItem2 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem3 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem4 = new DevComponents.DotNetBar.ButtonItem();
            this.ribbonTabItem1 = new DevComponents.DotNetBar.RibbonTabItem();
            this.ribbonTabItem3 = new DevComponents.DotNetBar.RibbonTabItem();
            this.applicationButton1 = new DevComponents.DotNetBar.ApplicationButton();
            this.itemContainer1 = new DevComponents.DotNetBar.ItemContainer();
            this.itemContainer2 = new DevComponents.DotNetBar.ItemContainer();
            this.itemContainer3 = new DevComponents.DotNetBar.ItemContainer();
            this.buttonItem5 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem6 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem7 = new DevComponents.DotNetBar.ButtonItem();
            this.galleryContainer1 = new DevComponents.DotNetBar.GalleryContainer();
            this.labelItem8 = new DevComponents.DotNetBar.LabelItem();
            this.buttonItem8 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem9 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem10 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem11 = new DevComponents.DotNetBar.ButtonItem();
            this.itemContainer4 = new DevComponents.DotNetBar.ItemContainer();
            this.buttonItem12 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem13 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem14 = new DevComponents.DotNetBar.ButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.superTabMain)).BeginInit();
            this.superTabMain.SuspendLayout();
            this.superTabControlPanel1.SuspendLayout();
            this.itemPanelStart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).BeginInit();
            this.ribbonControlMain.SuspendLayout();
            this.ribbonPanel3.SuspendLayout();
            this.ribbonPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // timerHome
            // 
            this.timerHome.Tick += new System.EventHandler(this.timerHome_Tick);
            // 
            // superTabMain
            // 
            this.superTabMain.CloseButtonOnTabsVisible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            this.superTabMain.ControlBox.CloseBox.Name = "";
            // 
            // 
            // 
            this.superTabMain.ControlBox.MenuBox.Name = "";
            this.superTabMain.ControlBox.Name = "";
            this.superTabMain.ControlBox.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.superTabMain.ControlBox.MenuBox,
            this.superTabMain.ControlBox.CloseBox});
            this.superTabMain.Controls.Add(this.superTabControlPanel1);
            this.superTabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabMain.Font = new System.Drawing.Font("Tahoma", 14F);
            this.superTabMain.Location = new System.Drawing.Point(5, 300);
            this.superTabMain.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.superTabMain.Name = "superTabMain";
            this.superTabMain.ReorderTabsEnabled = true;
            this.superTabMain.SelectedTabFont = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.superTabMain.SelectedTabIndex = 0;
            this.superTabMain.Size = new System.Drawing.Size(1558, 539);
            this.superTabMain.TabFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.superTabMain.TabIndex = 2;
            this.superTabMain.Tabs.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.TabItem0});
            this.superTabMain.Text = "superTabMain";
            // 
            // superTabControlPanel1
            // 
            this.superTabControlPanel1.Controls.Add(this.itemPanelStart);
            this.superTabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel1.Font = new System.Drawing.Font("Tahoma", 14F);
            this.superTabControlPanel1.Location = new System.Drawing.Point(0, 39);
            this.superTabControlPanel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.superTabControlPanel1.Name = "superTabControlPanel1";
            this.superTabControlPanel1.Size = new System.Drawing.Size(1558, 500);
            this.superTabControlPanel1.TabIndex = 2;
            this.superTabControlPanel1.TabItem = this.TabItem0;
            // 
            // itemPanelStart
            // 
            this.itemPanelStart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            // 
            // 
            // 
            this.itemPanelStart.BackgroundStyle.Class = "ItemPanel";
            this.itemPanelStart.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.itemPanelStart.ContainerControlProcessDialogKey = true;
            this.itemPanelStart.Controls.Add(this.labelX4);
            this.itemPanelStart.Controls.Add(this.pictureBox1);
            this.itemPanelStart.Controls.Add(this.labelX3);
            this.itemPanelStart.Controls.Add(this.labelX2);
            this.itemPanelStart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.itemPanelStart.DragDropSupport = true;
            this.itemPanelStart.HorizontalItemAlignment = DevComponents.DotNetBar.eHorizontalItemsAlignment.Center;
            this.itemPanelStart.Location = new System.Drawing.Point(0, 0);
            this.itemPanelStart.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.itemPanelStart.Name = "itemPanelStart";
            this.itemPanelStart.ReserveLeftSpace = false;
            this.itemPanelStart.Size = new System.Drawing.Size(1558, 500);
            this.itemPanelStart.TabIndex = 0;
            this.itemPanelStart.Text = " thành xử lý";
            // 
            // labelX4
            // 
            this.labelX4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelX4.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Font = new System.Drawing.Font("Times New Roman", 30F, System.Drawing.FontStyle.Bold);
            this.labelX4.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.labelX4.Location = new System.Drawing.Point(127, 301);
            this.labelX4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(1299, 60);
            this.labelX4.TabIndex = 17;
            this.labelX4.Text = "TRUNG TÂM CÔNG NGHỆ XỬ LÝ BOM MÌN";
            this.labelX4.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::QLHS.Properties.Resources.image;
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(200, 271);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 16;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Location = new System.Drawing.Point((labelX4.Width - labelX4.Location.X) / 2 + 40, labelX4.Location.Y - 320);


            // 
            // labelX3
            // 
            this.labelX3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelX3.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold);
            this.labelX3.ForeColor = System.Drawing.Color.DarkBlue;
            this.labelX3.Location = new System.Drawing.Point(127, 404);
            this.labelX3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(1299, 71);
            this.labelX3.TabIndex = 15;
            this.labelX3.Text = "Địa chỉ: 290 Lạc Long Quân, Tây Hồ, Hà Nội";
            this.labelX3.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // labelX2
            // 
            this.labelX2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelX2.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold);
            this.labelX2.ForeColor = System.Drawing.Color.DarkBlue;
            this.labelX2.Location = new System.Drawing.Point(127, 368);
            this.labelX2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(1299, 38);
            this.labelX2.TabIndex = 14;
            this.labelX2.Text = "TECHNOLOGY CENTRE FOR BOMB AND MINE DISPOSAL";
            this.labelX2.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // TabItem0
            // 
            this.TabItem0.AttachedControl = this.superTabControlPanel1;
            this.TabItem0.CloseButtonVisible = false;
            this.TabItem0.GlobalItem = false;
            this.TabItem0.Name = "TabItem0";
            this.TabItem0.TabFont = new System.Drawing.Font("Tahoma", 14F);
            this.TabItem0.Text = "Giới thiệu";
            // 
            // bar1
            // 
            this.bar1.AntiAlias = true;
            this.bar1.CanDockBottom = false;
            this.bar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bar1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.bar1.IsMaximized = false;
            this.bar1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.lblTitle,
            this.lblTime,
            this.lblDay});
            this.bar1.Location = new System.Drawing.Point(5, 839);
            this.bar1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bar1.Name = "bar1";
            this.bar1.Size = new System.Drawing.Size(1558, 22);
            this.bar1.Stretch = true;
            this.bar1.TabIndex = 2;
            this.bar1.TabStop = false;
            this.bar1.Text = "bar1";
            this.bar1.WrapItemsDock = true;
            // 
            // lblTitle
            // 
            this.lblTitle.ImageTextSpacing = 5;
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Text = "Hệ thống quản lý hồ sơ rà phá bom mìn";
            // 
            // lblTime
            // 
            this.lblTime.BeginGroup = true;
            this.lblTime.Name = "lblTime";
            this.lblTime.Text = "Time";
            this.lblTime.Width = 70;
            // 
            // lblDay
            // 
            this.lblDay.BeginGroup = true;
            this.lblDay.Name = "lblDay";
            this.lblDay.Text = "Time";
            this.lblDay.Width = 70;
            // 
            // styleManager1
            // 
            this.styleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2007Blue;
            this.styleManager1.MetroColorParameters = new DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(System.Drawing.Color.White, System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(87)))), ((int)(((byte)(154))))));
            // 
            // labelX1
            // 
            this.labelX1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelX1.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Font = new System.Drawing.Font("Times New Roman", 35F, System.Drawing.FontStyle.Bold);
            this.labelX1.ForeColor = System.Drawing.Color.Teal;
            this.labelX1.Location = new System.Drawing.Point(3, 93);
            this.labelX1.Name = "labelX1";
            this.labelX1.SingleLineColor = System.Drawing.SystemColors.Desktop;
            this.labelX1.Size = new System.Drawing.Size(864, 712);
            this.labelX1.TabIndex = 14;
            this.labelX1.Text = "TRUNG TÂM CÔNG NGHỆ XỬ LÝ BOM MÌN";
            this.labelX1.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // buttonItem1
            // 
            this.buttonItem1.Name = "buttonItem1";
            this.buttonItem1.Text = "buttonItem1";
            // 
            // ribbonControlMain
            // 
            this.ribbonControlMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ribbonControlMain.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ribbonControlMain.BackgroundImage")));
            // 
            // 
            // 
            this.ribbonControlMain.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonControlMain.CanCustomize = false;
            this.ribbonControlMain.CaptionFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.ribbonControlMain.CaptionHeight = 20;
            this.ribbonControlMain.CaptionVisible = true;
            this.ribbonControlMain.Controls.Add(this.ribbonPanel1);
            this.ribbonControlMain.Controls.Add(this.ribbonPanel3);
            this.ribbonControlMain.Dock = System.Windows.Forms.DockStyle.Top;
            this.ribbonControlMain.Font = new System.Drawing.Font("Tahoma", 14F);
            this.ribbonControlMain.ForeColor = System.Drawing.Color.Black;
            this.ribbonControlMain.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.ribbonTabItem1,
            this.ribbonTabItem3});
            this.ribbonControlMain.KeyTipsFont = new System.Drawing.Font("Tahoma", 10F);
            this.ribbonControlMain.Location = new System.Drawing.Point(5, 1);
            this.ribbonControlMain.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ribbonControlMain.MdiSystemItemVisible = false;
            this.ribbonControlMain.Name = "ribbonControlMain";
            this.ribbonControlMain.Padding = new System.Windows.Forms.Padding(0, 0, 0, 4);
            this.ribbonControlMain.QuickToolbarItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.applicationButton1});
            this.ribbonControlMain.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ribbonControlMain.Size = new System.Drawing.Size(1558, 299);
            this.ribbonControlMain.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ribbonControlMain.SystemText.MaximizeRibbonText = "&Maximize the Ribbon";
            this.ribbonControlMain.SystemText.MinimizeRibbonText = "Mi&nimize the Ribbon";
            this.ribbonControlMain.SystemText.QatAddItemText = "&Add to Quick Access Toolbar";
            this.ribbonControlMain.SystemText.QatCustomizeMenuLabel = "<b>Customize Quick Access Toolbar</b>";
            this.ribbonControlMain.SystemText.QatCustomizeText = "&Customize Quick Access Toolbar...";
            this.ribbonControlMain.SystemText.QatDialogAddButton = "&Add >>";
            this.ribbonControlMain.SystemText.QatDialogCancelButton = "Cancel";
            this.ribbonControlMain.SystemText.QatDialogCaption = "Customize Quick Access Toolbar";
            this.ribbonControlMain.SystemText.QatDialogCategoriesLabel = "&Choose commands from:";
            this.ribbonControlMain.SystemText.QatDialogOkButton = "OK";
            this.ribbonControlMain.SystemText.QatDialogPlacementCheckbox = "&Place Quick Access Toolbar below the Ribbon";
            this.ribbonControlMain.SystemText.QatDialogRemoveButton = "&Remove";
            this.ribbonControlMain.SystemText.QatPlaceAboveRibbonText = "&Place Quick Access Toolbar above the Ribbon";
            this.ribbonControlMain.SystemText.QatPlaceBelowRibbonText = "&Place Quick Access Toolbar below the Ribbon";
            this.ribbonControlMain.SystemText.QatRemoveItemText = "&Remove from Quick Access Toolbar";
            this.ribbonControlMain.TabGroupHeight = 14;
            this.ribbonControlMain.TabIndex = 0;
            this.ribbonControlMain.Text = "Hệ thống quản lý hồ sơ";
            this.ribbonControlMain.TitleText = "Hệ thống quản lý hồ sơ";
            // 
            // ribbonPanel3
            // 
            this.ribbonPanel3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ribbonPanel3.Controls.Add(this.ribbonBar3);
            this.ribbonPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ribbonPanel3.Location = new System.Drawing.Point(0, 91);
            this.ribbonPanel3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ribbonPanel3.Name = "ribbonPanel3";
            this.ribbonPanel3.Padding = new System.Windows.Forms.Padding(4, 0, 4, 4);
            this.ribbonPanel3.Size = new System.Drawing.Size(1558, 204);
            // 
            // 
            // 
            this.ribbonPanel3.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonPanel3.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonPanel3.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonPanel3.TabIndex = 3;
            this.ribbonPanel3.Visible = false;
            // 
            // ribbonBar3
            // 
            this.ribbonBar3.AutoOverflowEnabled = true;
            this.ribbonBar3.AutoSizeIncludesTitle = true;
            // 
            // 
            // 
            this.ribbonBar3.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonBar3.ContainerControlProcessDialogKey = true;
            this.ribbonBar3.Dock = System.Windows.Forms.DockStyle.Left;
            this.ribbonBar3.DragDropSupport = true;
            this.ribbonBar3.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btn_huongdansd,
            this.btn_thongtinpm});
            this.ribbonBar3.ItemSpacing = 15;
            this.ribbonBar3.Location = new System.Drawing.Point(4, 0);
            this.ribbonBar3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ribbonBar3.Name = "ribbonBar3";
            this.ribbonBar3.Padding = new System.Windows.Forms.Padding(7, 0, 0, 0);
            this.ribbonBar3.ResizeItemsToFit = false;
            this.ribbonBar3.Size = new System.Drawing.Size(340, 200);
            this.ribbonBar3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ribbonBar3.TabIndex = 1;
            this.ribbonBar3.Text = "Hỗ trợ";
            // 
            // 
            // 
            this.ribbonBar3.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar3.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonBar3.UseNativeDragDrop = true;
            this.ribbonBar3.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle;
            // 
            // btn_huongdansd
            // 
            this.btn_huongdansd.Image = ((System.Drawing.Image)(resources.GetObject("btn_huongdansd.Image")));
            this.btn_huongdansd.ImagePaddingHorizontal = 12;
            this.btn_huongdansd.ImagePaddingVertical = 10;
            this.btn_huongdansd.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btn_huongdansd.Name = "btn_huongdansd";
            this.btn_huongdansd.RibbonWordWrap = false;
            this.btn_huongdansd.SplitButton = true;
            this.btn_huongdansd.SubItemsExpandWidth = 14;
            this.btn_huongdansd.Text = "<div align=\"center\">Hướng dẫn<br>sử dụng</br></div>";
            this.btn_huongdansd.Click += new System.EventHandler(this.btn_huongdansd_Click);
            // 
            // btn_thongtinpm
            // 
            this.btn_thongtinpm.Image = ((System.Drawing.Image)(resources.GetObject("btn_thongtinpm.Image")));
            this.btn_thongtinpm.ImagePaddingHorizontal = 12;
            this.btn_thongtinpm.ImagePaddingVertical = 10;
            this.btn_thongtinpm.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btn_thongtinpm.Name = "btn_thongtinpm";
            this.btn_thongtinpm.SplitButton = true;
            this.btn_thongtinpm.SubItemsExpandWidth = 14;
            this.btn_thongtinpm.Text = "<div align=\"center\">Thông tin<br>phần mềm</br></div>";
            this.btn_thongtinpm.Click += new System.EventHandler(this.btn_thongtinpm_Click);
            // 
            // ribbonPanel1
            // 
            this.ribbonPanel1.AutoSize = true;
            this.ribbonPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ribbonPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ribbonPanel1.Controls.Add(this.ribbonBar2);
            this.ribbonPanel1.Controls.Add(this.ribbonBar1);
            this.ribbonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ribbonPanel1.Font = new System.Drawing.Font("Tahoma", 14F);
            this.ribbonPanel1.Location = new System.Drawing.Point(0, 91);
            this.ribbonPanel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ribbonPanel1.Name = "ribbonPanel1";
            this.ribbonPanel1.Padding = new System.Windows.Forms.Padding(4, 0, 4, 4);
            this.ribbonPanel1.Size = new System.Drawing.Size(1558, 204);
            // 
            // 
            // 
            this.ribbonPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonPanel1.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonPanel1.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonPanel1.TabIndex = 1;
            // 
            // ribbonBar2
            // 
            this.ribbonBar2.AutoOverflowEnabled = true;
            // 
            // 
            // 
            this.ribbonBar2.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonBar2.ContainerControlProcessDialogKey = true;
            this.ribbonBar2.Dock = System.Windows.Forms.DockStyle.Left;
            this.ribbonBar2.DragDropSupport = true;
            this.ribbonBar2.HorizontalItemAlignment = DevComponents.DotNetBar.eHorizontalItemsAlignment.Center;
            this.ribbonBar2.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btn_nhansu,
            this.btn_chuyengia});
            this.ribbonBar2.ItemSpacing = 15;
            this.ribbonBar2.Location = new System.Drawing.Point(437, 0);
            this.ribbonBar2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ribbonBar2.Name = "ribbonBar2";
            this.ribbonBar2.Padding = new System.Windows.Forms.Padding(7, 0, 0, 0);
            this.ribbonBar2.Size = new System.Drawing.Size(344, 200);
            this.ribbonBar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ribbonBar2.TabIndex = 1;
            this.ribbonBar2.Text = "Quản lý nhân sự";
            // 
            // 
            // 
            this.ribbonBar2.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar2.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonBar2.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle;
            // 
            // btn_nhansu
            // 
            this.btn_nhansu.Image = ((System.Drawing.Image)(resources.GetObject("btn_nhansu.Image")));
            this.btn_nhansu.ImagePaddingHorizontal = 12;
            this.btn_nhansu.ImagePaddingVertical = 10;
            this.btn_nhansu.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btn_nhansu.Name = "btn_nhansu";
            this.btn_nhansu.SubItemsExpandWidth = 14;
            this.btn_nhansu.Text = "<div align=\"center\">Nhân sự <br>đơn vị\r\n</br></div>";
            this.btn_nhansu.Click += new System.EventHandler(this.btn_nhansu_Click);
            // 
            // btn_chuyengia
            // 
            this.btn_chuyengia.Image = ((System.Drawing.Image)(resources.GetObject("btn_chuyengia.Image")));
            this.btn_chuyengia.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btn_chuyengia.Name = "btn_chuyengia";
            this.btn_chuyengia.SubItemsExpandWidth = 14;
            this.btn_chuyengia.Text = "<div align=\"center\">Nhân sự<br>đối tác\r\n</br></div>";
            this.btn_chuyengia.Click += new System.EventHandler(this.btn_chuyengia_Click);
            // 
            // ribbonBar1
            // 
            this.ribbonBar1.AutoOverflowEnabled = true;
            this.ribbonBar1.AutoSizeIncludesTitle = true;
            // 
            // 
            // 
            this.ribbonBar1.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonBar1.ContainerControlProcessDialogKey = true;
            this.ribbonBar1.Dock = System.Windows.Forms.DockStyle.Left;
            this.ribbonBar1.DragDropSupport = true;
            this.ribbonBar1.HorizontalItemAlignment = DevComponents.DotNetBar.eHorizontalItemsAlignment.Center;
            this.ribbonBar1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.buttonItem2,
            this.buttonItem3,
            this.buttonItem4});
            this.ribbonBar1.ItemSpacing = 15;
            this.ribbonBar1.Location = new System.Drawing.Point(4, 0);
            this.ribbonBar1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ribbonBar1.Name = "ribbonBar1";
            this.ribbonBar1.Padding = new System.Windows.Forms.Padding(7, 0, 0, 0);
            this.ribbonBar1.ResizeItemsToFit = false;
            this.ribbonBar1.Size = new System.Drawing.Size(433, 200);
            this.ribbonBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ribbonBar1.TabIndex = 0;
            this.ribbonBar1.Text = "Quản lý hồ sơ";
            // 
            // 
            // 
            this.ribbonBar1.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar1.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonBar1.UseNativeDragDrop = true;
            this.ribbonBar1.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle;
            // 
            // buttonItem2
            // 
            this.buttonItem2.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.buttonItem2.Image = ((System.Drawing.Image)(resources.GetObject("buttonItem2.Image")));
            this.buttonItem2.ImagePaddingHorizontal = 12;
            this.buttonItem2.ImagePaddingVertical = 10;
            this.buttonItem2.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.buttonItem2.Name = "buttonItem2";
            this.buttonItem2.RibbonWordWrap = false;
            this.buttonItem2.SplitButton = true;
            this.buttonItem2.SubItemsExpandWidth = 14;
            this.buttonItem2.Text = "<div align=\"center\">Tất cả<br>hồ sơ</br></div>";
            this.buttonItem2.Click += new System.EventHandler(this.buttonItem2_Click);
            // 
            // buttonItem3
            // 
            this.buttonItem3.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.buttonItem3.Image = ((System.Drawing.Image)(resources.GetObject("buttonItem3.Image")));
            this.buttonItem3.ImagePaddingHorizontal = 12;
            this.buttonItem3.ImagePaddingVertical = 10;
            this.buttonItem3.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.buttonItem3.Name = "buttonItem3";
            this.buttonItem3.SplitButton = true;
            this.buttonItem3.SubItemsExpandWidth = 14;
            this.buttonItem3.Text = "<div align=\"center\">Sắp xếp<br>theo tên</br></div>";
            this.buttonItem3.Click += new System.EventHandler(this.buttonItem3_Click);
            // 
            // buttonItem4
            // 
            this.buttonItem4.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.buttonItem4.Image = ((System.Drawing.Image)(resources.GetObject("buttonItem4.Image")));
            this.buttonItem4.ImagePaddingHorizontal = 12;
            this.buttonItem4.ImagePaddingVertical = 10;
            this.buttonItem4.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.buttonItem4.Name = "buttonItem4";
            this.buttonItem4.SplitButton = true;
            this.buttonItem4.SubItemsExpandWidth = 14;
            this.buttonItem4.Text = "<div align=\"center\">Sắp xếp<br>theo năm\r\n</br></div>";
            this.buttonItem4.Click += new System.EventHandler(this.buttonItem4_Click);
            // 
            // ribbonTabItem1
            // 
            this.ribbonTabItem1.Checked = true;
            this.ribbonTabItem1.Name = "ribbonTabItem1";
            this.ribbonTabItem1.Panel = this.ribbonPanel1;
            this.ribbonTabItem1.Text = "Chức năng chính";
            // 
            // ribbonTabItem3
            // 
            this.ribbonTabItem3.Name = "ribbonTabItem3";
            this.ribbonTabItem3.Panel = this.ribbonPanel3;
            this.ribbonTabItem3.Text = "Trợ giúp";
            // 
            // applicationButton1
            // 
            this.applicationButton1.AutoExpandOnClick = true;
            this.applicationButton1.CanCustomize = false;
            this.applicationButton1.HotTrackingStyle = DevComponents.DotNetBar.eHotTrackingStyle.Image;
            this.applicationButton1.Image = ((System.Drawing.Image)(resources.GetObject("applicationButton1.Image")));
            this.applicationButton1.ImagePaddingHorizontal = 2;
            this.applicationButton1.ImagePaddingVertical = 2;
            this.applicationButton1.Name = "applicationButton1";
            this.applicationButton1.ShowSubItems = false;
            this.applicationButton1.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.itemContainer1});
            this.applicationButton1.Text = "&File";
            // 
            // itemContainer1
            // 
            // 
            // 
            // 
            this.itemContainer1.BackgroundStyle.Class = "RibbonFileMenuContainer";
            this.itemContainer1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.itemContainer1.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical;
            this.itemContainer1.Name = "itemContainer1";
            this.itemContainer1.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.itemContainer2,
            this.itemContainer4});
            // 
            // 
            // 
            this.itemContainer1.TitleMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.itemContainer1.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // itemContainer2
            // 
            // 
            // 
            // 
            this.itemContainer2.BackgroundStyle.Class = "RibbonFileMenuTwoColumnContainer";
            this.itemContainer2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.itemContainer2.ItemSpacing = 0;
            this.itemContainer2.Name = "itemContainer2";
            this.itemContainer2.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.itemContainer3,
            this.galleryContainer1});
            // 
            // 
            // 
            this.itemContainer2.TitleMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.itemContainer2.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // itemContainer3
            // 
            // 
            // 
            // 
            this.itemContainer3.BackgroundStyle.Class = "RibbonFileMenuColumnOneContainer";
            this.itemContainer3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.itemContainer3.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical;
            this.itemContainer3.MinimumSize = new System.Drawing.Size(120, 0);
            this.itemContainer3.Name = "itemContainer3";
            this.itemContainer3.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.buttonItem5,
            this.buttonItem6,
            this.buttonItem7});
            // 
            // 
            // 
            this.itemContainer3.TitleMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.itemContainer3.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // buttonItem5
            // 
            this.buttonItem5.BeginGroup = true;
            this.buttonItem5.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.buttonItem5.Image = ((System.Drawing.Image)(resources.GetObject("buttonItem5.Image")));
            this.buttonItem5.ImagePaddingHorizontal = 12;
            this.buttonItem5.ImagePaddingVertical = 10;
            this.buttonItem5.Name = "buttonItem5";
            this.buttonItem5.RibbonWordWrap = false;
            this.buttonItem5.SplitButton = true;
            this.buttonItem5.SubItemsExpandWidth = 14;
            this.buttonItem5.Text = "<div align=\"center\">Tất cả<br>hồ sơ</br></div>";
            // 
            // buttonItem6
            // 
            this.buttonItem6.BeginGroup = true;
            this.buttonItem6.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.buttonItem6.Image = ((System.Drawing.Image)(resources.GetObject("buttonItem6.Image")));
            this.buttonItem6.ImagePaddingHorizontal = 12;
            this.buttonItem6.ImagePaddingVertical = 10;
            this.buttonItem6.Name = "buttonItem6";
            this.buttonItem6.RibbonWordWrap = false;
            this.buttonItem6.SplitButton = true;
            this.buttonItem6.SubItemsExpandWidth = 14;
            this.buttonItem6.Text = "<div align=\"center\">Tất cả<br>hồ sơ</br></div>";
            // 
            // buttonItem7
            // 
            this.buttonItem7.BeginGroup = true;
            this.buttonItem7.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.buttonItem7.Image = ((System.Drawing.Image)(resources.GetObject("buttonItem7.Image")));
            this.buttonItem7.Name = "buttonItem7";
            this.buttonItem7.SubItemsExpandWidth = 24;
            this.buttonItem7.Text = "&Close";
            // 
            // galleryContainer1
            // 
            // 
            // 
            // 
            this.galleryContainer1.BackgroundStyle.Class = "RibbonFileMenuColumnTwoContainer";
            this.galleryContainer1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.galleryContainer1.EnableGalleryPopup = false;
            this.galleryContainer1.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical;
            this.galleryContainer1.MinimumSize = new System.Drawing.Size(180, 240);
            this.galleryContainer1.MultiLine = false;
            this.galleryContainer1.Name = "galleryContainer1";
            this.galleryContainer1.PopupUsesStandardScrollbars = false;
            this.galleryContainer1.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.labelItem8,
            this.buttonItem8,
            this.buttonItem9,
            this.buttonItem10,
            this.buttonItem11});
            // 
            // 
            // 
            this.galleryContainer1.TitleMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.galleryContainer1.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // labelItem8
            // 
            this.labelItem8.BorderSide = DevComponents.DotNetBar.eBorderSide.Bottom;
            this.labelItem8.BorderType = DevComponents.DotNetBar.eBorderType.Etched;
            this.labelItem8.CanCustomize = false;
            this.labelItem8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelItem8.Name = "labelItem8";
            this.labelItem8.PaddingBottom = 2;
            this.labelItem8.PaddingTop = 2;
            this.labelItem8.Stretch = true;
            this.labelItem8.Text = "Recent Documents";
            // 
            // buttonItem8
            // 
            this.buttonItem8.BeginGroup = true;
            this.buttonItem8.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.buttonItem8.Image = ((System.Drawing.Image)(resources.GetObject("buttonItem8.Image")));
            this.buttonItem8.Name = "buttonItem8";
            this.buttonItem8.SubItemsExpandWidth = 24;
            this.buttonItem8.Text = "&1. Short News 5-7.rtf";
            // 
            // buttonItem9
            // 
            this.buttonItem9.Name = "buttonItem9";
            this.buttonItem9.Text = "&2. Prospect Email.rtf";
            // 
            // buttonItem10
            // 
            this.buttonItem10.Name = "buttonItem10";
            this.buttonItem10.Text = "&3. Customer Email.rtf";
            // 
            // buttonItem11
            // 
            this.buttonItem11.Name = "buttonItem11";
            this.buttonItem11.Text = "&4. example.rtf";
            // 
            // itemContainer4
            // 
            // 
            // 
            // 
            this.itemContainer4.BackgroundStyle.Class = "RibbonFileMenuBottomContainer";
            this.itemContainer4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.itemContainer4.HorizontalItemAlignment = DevComponents.DotNetBar.eHorizontalItemsAlignment.Right;
            this.itemContainer4.Name = "itemContainer4";
            this.itemContainer4.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.buttonItem12,
            this.buttonItem13});
            // 
            // 
            // 
            this.itemContainer4.TitleMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.itemContainer4.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // buttonItem12
            // 
            this.buttonItem12.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.buttonItem12.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonItem12.Image = ((System.Drawing.Image)(resources.GetObject("buttonItem12.Image")));
            this.buttonItem12.Name = "buttonItem12";
            this.buttonItem12.SubItemsExpandWidth = 24;
            this.buttonItem12.Text = "Opt&ions";
            // 
            // buttonItem13
            // 
            this.buttonItem13.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.buttonItem13.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonItem13.Image = ((System.Drawing.Image)(resources.GetObject("buttonItem13.Image")));
            this.buttonItem13.Name = "buttonItem13";
            this.buttonItem13.SubItemsExpandWidth = 24;
            this.buttonItem13.Text = "E&xit";
            // 
            // buttonItem14
            // 
            this.buttonItem14.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.buttonItem14.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonItem14.Image = ((System.Drawing.Image)(resources.GetObject("buttonItem14.Image")));
            this.buttonItem14.Name = "buttonItem14";
            this.buttonItem14.SubItemsExpandWidth = 24;
            this.buttonItem14.Text = "E&xit";
            // 
            // fMainQLHS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1568, 863);
            this.Controls.Add(this.superTabMain);
            this.Controls.Add(this.bar1);
            this.Controls.Add(this.ribbonControlMain);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "fMainQLHS";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BOMINCEN";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.fMainQLHS_Load);
            ((System.ComponentModel.ISupportInitialize)(this.superTabMain)).EndInit();
            this.superTabMain.ResumeLayout(false);
            this.superTabControlPanel1.ResumeLayout(false);
            this.itemPanelStart.ResumeLayout(false);
            this.itemPanelStart.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).EndInit();
            this.ribbonControlMain.ResumeLayout(false);
            this.ribbonControlMain.PerformLayout();
            this.ribbonPanel3.ResumeLayout(false);
            this.ribbonPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private DevComponents.DotNetBar.RibbonPanel ribbonPanel1;
        private DevComponents.DotNetBar.RibbonBar ribbonBar1;
        private DevComponents.DotNetBar.RibbonTabItem ribbonTabItem1;
        private DevComponents.DotNetBar.StyleManager styleManager1;
        private DevComponents.DotNetBar.ButtonItem buttonItem2;
        private DevComponents.DotNetBar.ButtonItem buttonItem3;
        private DevComponents.DotNetBar.ButtonItem buttonItem4;
        private System.Windows.Forms.Timer timerHome;
        public DevComponents.DotNetBar.RibbonControl ribbonControlMain;
        private DevComponents.DotNetBar.RibbonPanel ribbonPanel3;
        private DevComponents.DotNetBar.RibbonTabItem ribbonTabItem3;
        private DevComponents.DotNetBar.RibbonBar ribbonBar2;
        private DevComponents.DotNetBar.ButtonItem btn_nhansu;
        private DevComponents.DotNetBar.Bar bar1;
        private DevComponents.DotNetBar.SuperTabControl superTabMain;
        private DevComponents.DotNetBar.SuperTabControlPanel superTabControlPanel1;
        private DevComponents.DotNetBar.SuperTabItem TabItem0;
        private DevComponents.DotNetBar.LabelItem lblTitle;
        private DevComponents.DotNetBar.LabelItem lblTime;
        private DevComponents.DotNetBar.LabelItem lblDay;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.ButtonItem btn_chuyengia;
        private DevComponents.DotNetBar.ButtonItem buttonItem5;
        private DevComponents.DotNetBar.ButtonItem buttonItem6;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private DevComponents.DotNetBar.RibbonBar ribbonBar3;
        private DevComponents.DotNetBar.ButtonItem btn_huongdansd;
        private DevComponents.DotNetBar.ButtonItem btn_thongtinpm;
        private DevComponents.DotNetBar.ApplicationButton applicationButton1;
        private DevComponents.DotNetBar.ItemContainer itemContainer1;
        private DevComponents.DotNetBar.ItemContainer itemContainer2;
        private DevComponents.DotNetBar.ItemContainer itemContainer3;
        private DevComponents.DotNetBar.ButtonItem buttonItem7;
        private DevComponents.DotNetBar.GalleryContainer galleryContainer1;
        private DevComponents.DotNetBar.LabelItem labelItem8;
        private DevComponents.DotNetBar.ButtonItem buttonItem8;
        private DevComponents.DotNetBar.ButtonItem buttonItem9;
        private DevComponents.DotNetBar.ButtonItem buttonItem10;
        private DevComponents.DotNetBar.ButtonItem buttonItem11;
        private DevComponents.DotNetBar.ItemContainer itemContainer4;
        private DevComponents.DotNetBar.ButtonItem buttonItem12;
        private DevComponents.DotNetBar.ButtonItem buttonItem13;
        private DevComponents.DotNetBar.ButtonItem buttonItem1;
        private DevComponents.DotNetBar.ButtonItem buttonItem14;
        private DevComponents.DotNetBar.ItemPanel itemPanelStart;
        private System.Windows.Forms.PictureBox pictureBox1;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX labelX4;
    }
}