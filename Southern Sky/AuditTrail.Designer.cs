namespace Southern_Sky
{
    partial class AuditTrail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AuditTrail));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.bunifuDragControl1 = new ns1.BunifuDragControl(this.components);
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.mtDateFrom = new MetroFramework.Controls.MetroDateTime();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSearch = new ns1.BunifuThinButton2();
            this.btnclose = new ns1.BunifuThinButton2();
            this.btndeleteall = new ns1.BunifuThinButton2();
            this.btndelete = new ns1.BunifuThinButton2();
            this.btnprint = new ns1.BunifuThinButton2();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.txtID = new MetroFramework.Controls.MetroTextBox();
            this.metroGrid1 = new MetroFramework.Controls.MetroGrid();
            this.bunifuElipse1 = new ns1.BunifuElipse(this.components);
            this.bunifuGradientPanel2 = new ns1.BunifuGradientPanel();
            this.bunifuGradientPanel1 = new ns1.BunifuGradientPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.metroGrid1)).BeginInit();
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
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.BackColor = System.Drawing.Color.White;
            this.metroLabel3.Location = new System.Drawing.Point(6, 41);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(91, 19);
            this.metroLabel3.TabIndex = 12;
            this.metroLabel3.Text = "Choose Date :";
            // 
            // mtDateFrom
            // 
            this.mtDateFrom.CustomFormat = "yyyy/MM/dd";
            this.mtDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.mtDateFrom.Location = new System.Drawing.Point(103, 37);
            this.mtDateFrom.MinimumSize = new System.Drawing.Size(0, 29);
            this.mtDateFrom.Name = "mtDateFrom";
            this.mtDateFrom.Size = new System.Drawing.Size(200, 29);
            this.mtDateFrom.TabIndex = 10;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.metroLabel3);
            this.groupBox1.Controls.Add(this.mtDateFrom);
            this.groupBox1.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(23, 77);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(413, 90);
            this.groupBox1.TabIndex = 94;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search by Date";
            // 
            // btnSearch
            // 
            this.btnSearch.ActiveBorderThickness = 1;
            this.btnSearch.ActiveCornerRadius = 20;
            this.btnSearch.ActiveFillColor = System.Drawing.Color.Red;
            this.btnSearch.ActiveForecolor = System.Drawing.Color.Black;
            this.btnSearch.ActiveLineColor = System.Drawing.Color.Black;
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnSearch.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSearch.BackgroundImage")));
            this.btnSearch.ButtonText = "Search";
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.Color.SeaGreen;
            this.btnSearch.IdleBorderThickness = 1;
            this.btnSearch.IdleCornerRadius = 5;
            this.btnSearch.IdleFillColor = System.Drawing.Color.White;
            this.btnSearch.IdleForecolor = System.Drawing.Color.Black;
            this.btnSearch.IdleLineColor = System.Drawing.Color.Black;
            this.btnSearch.Location = new System.Drawing.Point(322, 28);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(5);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(73, 52);
            this.btnSearch.TabIndex = 77;
            this.btnSearch.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
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
            this.btnclose.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnclose.ForeColor = System.Drawing.Color.SeaGreen;
            this.btnclose.IdleBorderThickness = 1;
            this.btnclose.IdleCornerRadius = 5;
            this.btnclose.IdleFillColor = System.Drawing.Color.White;
            this.btnclose.IdleForecolor = System.Drawing.Color.Black;
            this.btnclose.IdleLineColor = System.Drawing.Color.Black;
            this.btnclose.Location = new System.Drawing.Point(606, 118);
            this.btnclose.Margin = new System.Windows.Forms.Padding(5);
            this.btnclose.Name = "btnclose";
            this.btnclose.Size = new System.Drawing.Size(73, 52);
            this.btnclose.TabIndex = 97;
            this.btnclose.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnclose.Click += new System.EventHandler(this.btnclose_Click_1);
            // 
            // btndeleteall
            // 
            this.btndeleteall.ActiveBorderThickness = 1;
            this.btndeleteall.ActiveCornerRadius = 20;
            this.btndeleteall.ActiveFillColor = System.Drawing.Color.Red;
            this.btndeleteall.ActiveForecolor = System.Drawing.Color.Black;
            this.btndeleteall.ActiveLineColor = System.Drawing.Color.Black;
            this.btndeleteall.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btndeleteall.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btndeleteall.BackgroundImage")));
            this.btndeleteall.ButtonText = "Delete All";
            this.btndeleteall.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btndeleteall.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btndeleteall.ForeColor = System.Drawing.Color.SeaGreen;
            this.btndeleteall.IdleBorderThickness = 1;
            this.btndeleteall.IdleCornerRadius = 5;
            this.btndeleteall.IdleFillColor = System.Drawing.Color.White;
            this.btndeleteall.IdleForecolor = System.Drawing.Color.Black;
            this.btndeleteall.IdleLineColor = System.Drawing.Color.Black;
            this.btndeleteall.Location = new System.Drawing.Point(525, 84);
            this.btndeleteall.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btndeleteall.Name = "btndeleteall";
            this.btndeleteall.Size = new System.Drawing.Size(73, 52);
            this.btndeleteall.TabIndex = 96;
            this.btndeleteall.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btndeleteall.Click += new System.EventHandler(this.btndeleteall_Click);
            // 
            // btndelete
            // 
            this.btndelete.ActiveBorderThickness = 1;
            this.btndelete.ActiveCornerRadius = 20;
            this.btndelete.ActiveFillColor = System.Drawing.Color.Red;
            this.btndelete.ActiveForecolor = System.Drawing.Color.Black;
            this.btndelete.ActiveLineColor = System.Drawing.Color.Black;
            this.btndelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btndelete.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btndelete.BackgroundImage")));
            this.btndelete.ButtonText = "Delete";
            this.btndelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btndelete.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btndelete.ForeColor = System.Drawing.Color.SeaGreen;
            this.btndelete.IdleBorderThickness = 1;
            this.btndelete.IdleCornerRadius = 5;
            this.btndelete.IdleFillColor = System.Drawing.Color.White;
            this.btndelete.IdleForecolor = System.Drawing.Color.Black;
            this.btndelete.IdleLineColor = System.Drawing.Color.Black;
            this.btndelete.Location = new System.Drawing.Point(444, 84);
            this.btndelete.Margin = new System.Windows.Forms.Padding(5);
            this.btndelete.Name = "btndelete";
            this.btndelete.Size = new System.Drawing.Size(73, 52);
            this.btndelete.TabIndex = 95;
            this.btndelete.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btndelete.Click += new System.EventHandler(this.btndelete_Click);
            // 
            // btnprint
            // 
            this.btnprint.ActiveBorderThickness = 1;
            this.btnprint.ActiveCornerRadius = 20;
            this.btnprint.ActiveFillColor = System.Drawing.Color.Red;
            this.btnprint.ActiveForecolor = System.Drawing.Color.Black;
            this.btnprint.ActiveLineColor = System.Drawing.Color.Black;
            this.btnprint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnprint.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnprint.BackgroundImage")));
            this.btnprint.ButtonText = "Print";
            this.btnprint.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnprint.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnprint.ForeColor = System.Drawing.Color.SeaGreen;
            this.btnprint.IdleBorderThickness = 1;
            this.btnprint.IdleCornerRadius = 5;
            this.btnprint.IdleFillColor = System.Drawing.Color.White;
            this.btnprint.IdleForecolor = System.Drawing.Color.Black;
            this.btnprint.IdleLineColor = System.Drawing.Color.Black;
            this.btnprint.Location = new System.Drawing.Point(607, 71);
            this.btnprint.Margin = new System.Windows.Forms.Padding(5);
            this.btnprint.Name = "btnprint";
            this.btnprint.Size = new System.Drawing.Size(73, 52);
            this.btnprint.TabIndex = 98;
            this.btnprint.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnprint.Click += new System.EventHandler(this.btnprint_Click);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.BackColor = System.Drawing.Color.White;
            this.metroLabel1.Location = new System.Drawing.Point(442, 148);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(47, 19);
            this.metroLabel1.TabIndex = 93;
            this.metroLabel1.Text = "Log ID";
            // 
            // txtID
            // 
            // 
            // 
            // 
            this.txtID.CustomButton.Image = null;
            this.txtID.CustomButton.Location = new System.Drawing.Point(81, 1);
            this.txtID.CustomButton.Name = "";
            this.txtID.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtID.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtID.CustomButton.TabIndex = 1;
            this.txtID.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtID.CustomButton.UseSelectable = true;
            this.txtID.CustomButton.Visible = false;
            this.txtID.Lines = new string[0];
            this.txtID.Location = new System.Drawing.Point(495, 144);
            this.txtID.MaxLength = 32767;
            this.txtID.Name = "txtID";
            this.txtID.PasswordChar = '\0';
            this.txtID.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtID.SelectedText = "";
            this.txtID.SelectionLength = 0;
            this.txtID.SelectionStart = 0;
            this.txtID.Size = new System.Drawing.Size(103, 23);
            this.txtID.TabIndex = 92;
            this.txtID.UseSelectable = true;
            this.txtID.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtID.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroGrid1
            // 
            this.metroGrid1.AllowUserToAddRows = false;
            this.metroGrid1.AllowUserToDeleteRows = false;
            this.metroGrid1.AllowUserToResizeColumns = false;
            this.metroGrid1.AllowUserToResizeRows = false;
            this.metroGrid1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.metroGrid1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.metroGrid1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.metroGrid1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(17)))), ((int)(((byte)(65)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(19)))), ((int)(((byte)(73)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.metroGrid1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.metroGrid1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(19)))), ((int)(((byte)(73)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.metroGrid1.DefaultCellStyle = dataGridViewCellStyle2;
            this.metroGrid1.EnableHeadersVisualStyles = false;
            this.metroGrid1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.metroGrid1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.metroGrid1.Location = new System.Drawing.Point(23, 173);
            this.metroGrid1.Name = "metroGrid1";
            this.metroGrid1.ReadOnly = true;
            this.metroGrid1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(17)))), ((int)(((byte)(65)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(19)))), ((int)(((byte)(73)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.metroGrid1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.metroGrid1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.metroGrid1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.metroGrid1.Size = new System.Drawing.Size(658, 349);
            this.metroGrid1.Style = MetroFramework.MetroColorStyle.Red;
            this.metroGrid1.TabIndex = 91;
            this.metroGrid1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.metroGrid1_CellClick);
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 20;
            this.bunifuElipse1.TargetControl = this;
            // 
            // bunifuGradientPanel2
            // 
            this.bunifuGradientPanel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuGradientPanel2.BackgroundImage")));
            this.bunifuGradientPanel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuGradientPanel2.GradientBottomLeft = System.Drawing.Color.White;
            this.bunifuGradientPanel2.GradientBottomRight = System.Drawing.Color.Red;
            this.bunifuGradientPanel2.GradientTopLeft = System.Drawing.Color.Red;
            this.bunifuGradientPanel2.GradientTopRight = System.Drawing.Color.Red;
            this.bunifuGradientPanel2.Location = new System.Drawing.Point(0, 540);
            this.bunifuGradientPanel2.Name = "bunifuGradientPanel2";
            this.bunifuGradientPanel2.Quality = 10;
            this.bunifuGradientPanel2.Size = new System.Drawing.Size(707, 32);
            this.bunifuGradientPanel2.TabIndex = 100;
            // 
            // bunifuGradientPanel1
            // 
            this.bunifuGradientPanel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuGradientPanel1.BackgroundImage")));
            this.bunifuGradientPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuGradientPanel1.Controls.Add(this.label1);
            this.bunifuGradientPanel1.GradientBottomLeft = System.Drawing.Color.Red;
            this.bunifuGradientPanel1.GradientBottomRight = System.Drawing.Color.White;
            this.bunifuGradientPanel1.GradientTopLeft = System.Drawing.Color.Red;
            this.bunifuGradientPanel1.GradientTopRight = System.Drawing.Color.Red;
            this.bunifuGradientPanel1.Location = new System.Drawing.Point(0, -10);
            this.bunifuGradientPanel1.Name = "bunifuGradientPanel1";
            this.bunifuGradientPanel1.Quality = 10;
            this.bunifuGradientPanel1.Size = new System.Drawing.Size(707, 63);
            this.bunifuGradientPanel1.TabIndex = 99;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(290, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 28);
            this.label1.TabIndex = 91;
            this.label1.Text = "AUDIT TRAIL";
            // 
            // AuditTrail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(707, 563);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnclose);
            this.Controls.Add(this.btndeleteall);
            this.Controls.Add(this.btndelete);
            this.Controls.Add(this.btnprint);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.metroGrid1);
            this.Controls.Add(this.bunifuGradientPanel2);
            this.Controls.Add(this.bunifuGradientPanel1);
            this.Location = new System.Drawing.Point(340, 165);
            this.Name = "AuditTrail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Style = MetroFramework.MetroColorStyle.White;
            this.Load += new System.EventHandler(this.AuditTrail_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.metroGrid1)).EndInit();
            this.bunifuGradientPanel1.ResumeLayout(false);
            this.bunifuGradientPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ns1.BunifuDragControl bunifuDragControl1;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroDateTime mtDateFrom;
        private System.Windows.Forms.GroupBox groupBox1;
        private ns1.BunifuThinButton2 btnSearch;
        private ns1.BunifuThinButton2 btnclose;
        private ns1.BunifuThinButton2 btndeleteall;
        private ns1.BunifuThinButton2 btndelete;
        private ns1.BunifuThinButton2 btnprint;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroTextBox txtID;
        private MetroFramework.Controls.MetroGrid metroGrid1;
        private ns1.BunifuElipse bunifuElipse1;
        private ns1.BunifuGradientPanel bunifuGradientPanel2;
        private ns1.BunifuGradientPanel bunifuGradientPanel1;
        private System.Windows.Forms.Label label1;


    }
}