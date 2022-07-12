namespace Southern_Sky
{
    partial class UnavailableProduct
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
            BunifuAnimatorNS.Animation animation2 = new BunifuAnimatorNS.Animation();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UnavailableProduct));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.bunifuDragControl1 = new ns1.BunifuDragControl(this.components);
            this.Transition = new BunifuAnimatorNS.BunifuTransition(this.components);
            this.txtCategory = new System.Windows.Forms.Label();
            this.txtProductName = new System.Windows.Forms.Label();
            this.txtProductNo = new System.Windows.Forms.Label();
            this.Label6 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label5 = new System.Windows.Forms.Label();
            this.txtsearch = new ns1.BunifuMaterialTextbox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.metroGrid1 = new MetroFramework.Controls.MetroGrid();
            this.btnclose = new ns1.BunifuThinButton2();
            this.btnactive = new ns1.BunifuThinButton2();
            this.btnsearch = new ns1.BunifuImageButton();
            this.pictureBox10 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.bunifuGradientPanel1 = new ns1.BunifuGradientPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.bunifuGradientPanel2 = new ns1.BunifuGradientPanel();
            this.bunifuElipse1 = new ns1.BunifuElipse(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.txtuser = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.metroGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnsearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.bunifuGradientPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bunifuDragControl1
            // 
            this.bunifuDragControl1.Fixed = true;
            this.bunifuDragControl1.Horizontal = true;
            this.bunifuDragControl1.TargetControl = null;
            this.bunifuDragControl1.Vertical = true;
            // 
            // Transition
            // 
            this.Transition.AnimationType = BunifuAnimatorNS.AnimationType.HorizSlide;
            this.Transition.Cursor = null;
            animation2.AnimateOnlyDifferences = true;
            animation2.BlindCoeff = ((System.Drawing.PointF)(resources.GetObject("animation2.BlindCoeff")));
            animation2.LeafCoeff = 0F;
            animation2.MaxTime = 1F;
            animation2.MinTime = 0F;
            animation2.MosaicCoeff = ((System.Drawing.PointF)(resources.GetObject("animation2.MosaicCoeff")));
            animation2.MosaicShift = ((System.Drawing.PointF)(resources.GetObject("animation2.MosaicShift")));
            animation2.MosaicSize = 0;
            animation2.Padding = new System.Windows.Forms.Padding(0);
            animation2.RotateCoeff = 0F;
            animation2.RotateLimit = 0F;
            animation2.ScaleCoeff = ((System.Drawing.PointF)(resources.GetObject("animation2.ScaleCoeff")));
            animation2.SlideCoeff = ((System.Drawing.PointF)(resources.GetObject("animation2.SlideCoeff")));
            animation2.TimeCoeff = 0F;
            animation2.TransparencyCoeff = 0F;
            this.Transition.DefaultAnimation = animation2;
            // 
            // txtCategory
            // 
            this.txtCategory.AutoSize = true;
            this.Transition.SetDecoration(this.txtCategory, BunifuAnimatorNS.DecorationType.None);
            this.txtCategory.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.txtCategory.Location = new System.Drawing.Point(114, 82);
            this.txtCategory.Name = "txtCategory";
            this.txtCategory.Size = new System.Drawing.Size(17, 16);
            this.txtCategory.TabIndex = 77;
            this.txtCategory.Text = "C";
            // 
            // txtProductName
            // 
            this.txtProductName.AutoSize = true;
            this.Transition.SetDecoration(this.txtProductName, BunifuAnimatorNS.DecorationType.None);
            this.txtProductName.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.txtProductName.Location = new System.Drawing.Point(114, 55);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(17, 16);
            this.txtProductName.TabIndex = 76;
            this.txtProductName.Text = "N";
            // 
            // txtProductNo
            // 
            this.txtProductNo.AutoSize = true;
            this.Transition.SetDecoration(this.txtProductNo, BunifuAnimatorNS.DecorationType.None);
            this.txtProductNo.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.txtProductNo.Location = new System.Drawing.Point(114, 28);
            this.txtProductNo.Name = "txtProductNo";
            this.txtProductNo.Size = new System.Drawing.Size(25, 16);
            this.txtProductNo.TabIndex = 75;
            this.txtProductNo.Text = "No";
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Transition.SetDecoration(this.Label6, BunifuAnimatorNS.DecorationType.None);
            this.Label6.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.Label6.Location = new System.Drawing.Point(6, 28);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(82, 16);
            this.Label6.TabIndex = 69;
            this.Label6.Text = "Product No. :";
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Transition.SetDecoration(this.Label3, BunifuAnimatorNS.DecorationType.None);
            this.Label3.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.Label3.Location = new System.Drawing.Point(6, 55);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(98, 16);
            this.Label3.TabIndex = 71;
            this.Label3.Text = "Product Name :";
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Transition.SetDecoration(this.Label5, BunifuAnimatorNS.DecorationType.None);
            this.Label5.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.Label5.Location = new System.Drawing.Point(6, 82);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(69, 16);
            this.Label5.TabIndex = 70;
            this.Label5.Text = "Category :";
            // 
            // txtsearch
            // 
            this.txtsearch.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.Transition.SetDecoration(this.txtsearch, BunifuAnimatorNS.DecorationType.None);
            this.txtsearch.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtsearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtsearch.HintForeColor = System.Drawing.Color.Empty;
            this.txtsearch.HintText = "";
            this.txtsearch.isPassword = false;
            this.txtsearch.LineFocusedColor = System.Drawing.Color.Black;
            this.txtsearch.LineIdleColor = System.Drawing.Color.Gray;
            this.txtsearch.LineMouseHoverColor = System.Drawing.Color.Black;
            this.txtsearch.LineThickness = 4;
            this.txtsearch.Location = new System.Drawing.Point(56, 65);
            this.txtsearch.Margin = new System.Windows.Forms.Padding(4);
            this.txtsearch.Name = "txtsearch";
            this.txtsearch.Size = new System.Drawing.Size(231, 37);
            this.txtsearch.TabIndex = 78;
            this.txtsearch.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtsearch.Visible = false;
            this.txtsearch.OnValueChanged += new System.EventHandler(this.txtsearch_OnValueChanged);
            this.txtsearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtsearch_KeyPress);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.DarkGray;
            this.groupBox1.Controls.Add(this.txtCategory);
            this.groupBox1.Controls.Add(this.txtProductName);
            this.groupBox1.Controls.Add(this.txtProductNo);
            this.groupBox1.Controls.Add(this.Label6);
            this.groupBox1.Controls.Add(this.Label3);
            this.groupBox1.Controls.Add(this.Label5);
            this.Transition.SetDecoration(this.groupBox1, BunifuAnimatorNS.DecorationType.None);
            this.groupBox1.Font = new System.Drawing.Font("Century Gothic", 9F);
            this.groupBox1.Location = new System.Drawing.Point(16, 312);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(340, 110);
            this.groupBox1.TabIndex = 77;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Product Information";
            // 
            // metroGrid1
            // 
            this.metroGrid1.AllowUserToAddRows = false;
            this.metroGrid1.AllowUserToDeleteRows = false;
            this.metroGrid1.AllowUserToResizeRows = false;
            this.metroGrid1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.metroGrid1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.metroGrid1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.metroGrid1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(17)))), ((int)(((byte)(65)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(19)))), ((int)(((byte)(73)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.metroGrid1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.metroGrid1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Transition.SetDecoration(this.metroGrid1, BunifuAnimatorNS.DecorationType.None);
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(19)))), ((int)(((byte)(73)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.metroGrid1.DefaultCellStyle = dataGridViewCellStyle5;
            this.metroGrid1.EnableHeadersVisualStyles = false;
            this.metroGrid1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.metroGrid1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.metroGrid1.Location = new System.Drawing.Point(16, 109);
            this.metroGrid1.MultiSelect = false;
            this.metroGrid1.Name = "metroGrid1";
            this.metroGrid1.ReadOnly = true;
            this.metroGrid1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(17)))), ((int)(((byte)(65)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(19)))), ((int)(((byte)(73)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.metroGrid1.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.metroGrid1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.metroGrid1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.metroGrid1.Size = new System.Drawing.Size(341, 197);
            this.metroGrid1.Style = MetroFramework.MetroColorStyle.Red;
            this.metroGrid1.TabIndex = 72;
            this.metroGrid1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.metroGrid1_CellClick);
            this.metroGrid1.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.metroGrid1_CellEnter);
            // 
            // btnclose
            // 
            this.btnclose.ActiveBorderThickness = 1;
            this.btnclose.ActiveCornerRadius = 20;
            this.btnclose.ActiveFillColor = System.Drawing.Color.Red;
            this.btnclose.ActiveForecolor = System.Drawing.Color.Black;
            this.btnclose.ActiveLineColor = System.Drawing.Color.Black;
            this.btnclose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnclose.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnclose.BackgroundImage")));
            this.btnclose.ButtonText = "Close";
            this.btnclose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Transition.SetDecoration(this.btnclose, BunifuAnimatorNS.DecorationType.None);
            this.btnclose.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnclose.ForeColor = System.Drawing.Color.SeaGreen;
            this.btnclose.IdleBorderThickness = 1;
            this.btnclose.IdleCornerRadius = 20;
            this.btnclose.IdleFillColor = System.Drawing.Color.White;
            this.btnclose.IdleForecolor = System.Drawing.Color.Black;
            this.btnclose.IdleLineColor = System.Drawing.Color.Black;
            this.btnclose.Location = new System.Drawing.Point(238, 440);
            this.btnclose.Margin = new System.Windows.Forms.Padding(5);
            this.btnclose.Name = "btnclose";
            this.btnclose.Size = new System.Drawing.Size(116, 53);
            this.btnclose.TabIndex = 81;
            this.btnclose.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnclose.Click += new System.EventHandler(this.btnclose_Click);
            // 
            // btnactive
            // 
            this.btnactive.ActiveBorderThickness = 1;
            this.btnactive.ActiveCornerRadius = 20;
            this.btnactive.ActiveFillColor = System.Drawing.Color.Red;
            this.btnactive.ActiveForecolor = System.Drawing.Color.Black;
            this.btnactive.ActiveLineColor = System.Drawing.Color.Black;
            this.btnactive.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnactive.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnactive.BackgroundImage")));
            this.btnactive.ButtonText = "Available this product";
            this.btnactive.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Transition.SetDecoration(this.btnactive, BunifuAnimatorNS.DecorationType.None);
            this.btnactive.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnactive.ForeColor = System.Drawing.Color.SeaGreen;
            this.btnactive.IdleBorderThickness = 1;
            this.btnactive.IdleCornerRadius = 20;
            this.btnactive.IdleFillColor = System.Drawing.Color.White;
            this.btnactive.IdleForecolor = System.Drawing.Color.Black;
            this.btnactive.IdleLineColor = System.Drawing.Color.Black;
            this.btnactive.Location = new System.Drawing.Point(56, 440);
            this.btnactive.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnactive.Name = "btnactive";
            this.btnactive.Size = new System.Drawing.Size(125, 53);
            this.btnactive.TabIndex = 80;
            this.btnactive.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnactive.Click += new System.EventHandler(this.btnactive_Click);
            // 
            // btnsearch
            // 
            this.btnsearch.BackColor = System.Drawing.Color.Transparent;
            this.Transition.SetDecoration(this.btnsearch, BunifuAnimatorNS.DecorationType.None);
            this.btnsearch.Image = ((System.Drawing.Image)(resources.GetObject("btnsearch.Image")));
            this.btnsearch.ImageActive = null;
            this.btnsearch.Location = new System.Drawing.Point(14, 65);
            this.btnsearch.Name = "btnsearch";
            this.btnsearch.Size = new System.Drawing.Size(40, 38);
            this.btnsearch.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnsearch.TabIndex = 79;
            this.btnsearch.TabStop = false;
            this.btnsearch.Zoom = 10;
            this.btnsearch.Click += new System.EventHandler(this.btnsearch_Click);
            // 
            // pictureBox10
            // 
            this.pictureBox10.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox10.BackgroundImage")));
            this.pictureBox10.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Transition.SetDecoration(this.pictureBox10, BunifuAnimatorNS.DecorationType.None);
            this.pictureBox10.Location = new System.Drawing.Point(198, 452);
            this.pictureBox10.Name = "pictureBox10";
            this.pictureBox10.Size = new System.Drawing.Size(32, 30);
            this.pictureBox10.TabIndex = 83;
            this.pictureBox10.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox5.BackgroundImage")));
            this.pictureBox5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Transition.SetDecoration(this.pictureBox5, BunifuAnimatorNS.DecorationType.None);
            this.pictureBox5.Location = new System.Drawing.Point(16, 452);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(32, 30);
            this.pictureBox5.TabIndex = 82;
            this.pictureBox5.TabStop = false;
            // 
            // bunifuGradientPanel1
            // 
            this.bunifuGradientPanel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuGradientPanel1.BackgroundImage")));
            this.bunifuGradientPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuGradientPanel1.Controls.Add(this.label1);
            this.Transition.SetDecoration(this.bunifuGradientPanel1, BunifuAnimatorNS.DecorationType.None);
            this.bunifuGradientPanel1.GradientBottomLeft = System.Drawing.Color.Red;
            this.bunifuGradientPanel1.GradientBottomRight = System.Drawing.Color.White;
            this.bunifuGradientPanel1.GradientTopLeft = System.Drawing.Color.Red;
            this.bunifuGradientPanel1.GradientTopRight = System.Drawing.Color.Red;
            this.bunifuGradientPanel1.Location = new System.Drawing.Point(-2, 0);
            this.bunifuGradientPanel1.Name = "bunifuGradientPanel1";
            this.bunifuGradientPanel1.Quality = 10;
            this.bunifuGradientPanel1.Size = new System.Drawing.Size(382, 58);
            this.bunifuGradientPanel1.TabIndex = 84;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.Transition.SetDecoration(this.label1, BunifuAnimatorNS.DecorationType.None);
            this.label1.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Maroon;
            this.label1.Location = new System.Drawing.Point(64, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(257, 28);
            this.label1.TabIndex = 1;
            this.label1.Text = "Unavailable Products";
            // 
            // bunifuGradientPanel2
            // 
            this.bunifuGradientPanel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuGradientPanel2.BackgroundImage")));
            this.bunifuGradientPanel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Transition.SetDecoration(this.bunifuGradientPanel2, BunifuAnimatorNS.DecorationType.None);
            this.bunifuGradientPanel2.GradientBottomLeft = System.Drawing.Color.White;
            this.bunifuGradientPanel2.GradientBottomRight = System.Drawing.Color.Red;
            this.bunifuGradientPanel2.GradientTopLeft = System.Drawing.Color.Red;
            this.bunifuGradientPanel2.GradientTopRight = System.Drawing.Color.Red;
            this.bunifuGradientPanel2.Location = new System.Drawing.Point(-2, 501);
            this.bunifuGradientPanel2.Name = "bunifuGradientPanel2";
            this.bunifuGradientPanel2.Quality = 10;
            this.bunifuGradientPanel2.Size = new System.Drawing.Size(382, 19);
            this.bunifuGradientPanel2.TabIndex = 85;
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 20;
            this.bunifuElipse1.TargetControl = this;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // txtuser
            // 
            this.txtuser.AutoSize = true;
            this.txtuser.BackColor = System.Drawing.Color.Transparent;
            this.Transition.SetDecoration(this.txtuser, BunifuAnimatorNS.DecorationType.None);
            this.txtuser.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtuser.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.txtuser.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtuser.Location = new System.Drawing.Point(199, 60);
            this.txtuser.Name = "txtuser";
            this.txtuser.Size = new System.Drawing.Size(86, 18);
            this.txtuser.TabIndex = 107;
            this.txtuser.Text = "Time Here";
            this.txtuser.Visible = false;
            this.txtuser.Click += new System.EventHandler(this.txtuser_Click);
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.BackColor = System.Drawing.Color.Transparent;
            this.Transition.SetDecoration(this.lblTime, BunifuAnimatorNS.DecorationType.None);
            this.lblTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.lblTime.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblTime.Location = new System.Drawing.Point(291, 60);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(86, 18);
            this.lblTime.TabIndex = 106;
            this.lblTime.Text = "Time Here";
            this.lblTime.Visible = false;
            this.lblTime.Click += new System.EventHandler(this.lblTime_Click);
            // 
            // UnavailableProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 521);
            this.ControlBox = false;
            this.Controls.Add(this.txtuser);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.bunifuGradientPanel2);
            this.Controls.Add(this.bunifuGradientPanel1);
            this.Controls.Add(this.pictureBox10);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.btnclose);
            this.Controls.Add(this.btnactive);
            this.Controls.Add(this.btnsearch);
            this.Controls.Add(this.txtsearch);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.metroGrid1);
            this.Transition.SetDecoration(this, BunifuAnimatorNS.DecorationType.None);
            this.Location = new System.Drawing.Point(500, 200);
            this.Name = "UnavailableProduct";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Style = MetroFramework.MetroColorStyle.White;
            this.Load += new System.EventHandler(this.UnavailableProduct_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.metroGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnsearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.bunifuGradientPanel1.ResumeLayout(false);
            this.bunifuGradientPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ns1.BunifuDragControl bunifuDragControl1;
        private ns1.BunifuImageButton btnsearch;
        private BunifuAnimatorNS.BunifuTransition Transition;
        private System.Windows.Forms.Label txtCategory;
        private System.Windows.Forms.Label txtProductName;
        private System.Windows.Forms.Label txtProductNo;
        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Label Label5;
        private ns1.BunifuMaterialTextbox txtsearch;
        private System.Windows.Forms.GroupBox groupBox1;
        private MetroFramework.Controls.MetroGrid metroGrid1;
        private ns1.BunifuThinButton2 btnactive;
        private ns1.BunifuThinButton2 btnclose;
        private ns1.BunifuElipse bunifuElipse1;
        private System.Windows.Forms.PictureBox pictureBox10;
        private System.Windows.Forms.PictureBox pictureBox5;
        private ns1.BunifuGradientPanel bunifuGradientPanel2;
        private ns1.BunifuGradientPanel bunifuGradientPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label txtuser;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Timer timer1;
    }
}