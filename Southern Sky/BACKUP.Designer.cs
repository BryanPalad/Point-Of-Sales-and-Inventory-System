namespace Southern_Sky
{
    partial class BACKUP
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BACKUP));
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.sep = new ns1.BunifuSeparator();
            this.lblstatus = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.btnrestore = new ns1.BunifuFlatButton();
            this.btnbackup = new ns1.BunifuFlatButton();
            this.txtrestorefile = new MetroFramework.Controls.MetroTextBox();
            this.txtbackuppath = new MetroFramework.Controls.MetroTextBox();
            this.bunifuGradientPanel1 = new ns1.BunifuGradientPanel();
            this.bunifuGradientPanel2 = new ns1.BunifuGradientPanel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.bunifuGradientPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(23, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(268, 23);
            this.label1.TabIndex = 4;
            this.label1.Text = "DATABASE CONFIGURATION";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.ErrorImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.ErrorImage")));
            this.pictureBox1.Image = global::Southern_Sky.Properties.Resources.Delete_52px1;
            this.pictureBox1.Location = new System.Drawing.Point(294, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(27, 28);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 72;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // sep
            // 
            this.sep.BackColor = System.Drawing.Color.Transparent;
            this.sep.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.sep.LineThickness = 5;
            this.sep.Location = new System.Drawing.Point(0, 184);
            this.sep.Name = "sep";
            this.sep.Size = new System.Drawing.Size(324, 10);
            this.sep.TabIndex = 68;
            this.sep.Transparency = 255;
            this.sep.Vertical = false;
            // 
            // lblstatus
            // 
            this.lblstatus.AutoSize = true;
            this.lblstatus.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblstatus.ForeColor = System.Drawing.Color.Black;
            this.lblstatus.Location = new System.Drawing.Point(96, 320);
            this.lblstatus.Name = "lblstatus";
            this.lblstatus.Size = new System.Drawing.Size(42, 16);
            this.lblstatus.TabIndex = 71;
            this.lblstatus.Text = "None";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(36, 320);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 16);
            this.label2.TabIndex = 70;
            this.label2.Text = "Status :";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btnrestore
            // 
            this.btnrestore.Activecolor = System.Drawing.Color.Red;
            this.btnrestore.BackColor = System.Drawing.Color.White;
            this.btnrestore.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnrestore.BorderRadius = 0;
            this.btnrestore.ButtonText = "Restore DataBase";
            this.btnrestore.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnrestore.DisabledColor = System.Drawing.Color.Gray;
            this.btnrestore.Iconcolor = System.Drawing.Color.Transparent;
            this.btnrestore.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnrestore.Iconimage")));
            this.btnrestore.Iconimage_right = null;
            this.btnrestore.Iconimage_right_Selected = null;
            this.btnrestore.Iconimage_Selected = null;
            this.btnrestore.IconMarginLeft = 0;
            this.btnrestore.IconMarginRight = 0;
            this.btnrestore.IconRightVisible = true;
            this.btnrestore.IconRightZoom = 0D;
            this.btnrestore.IconVisible = true;
            this.btnrestore.IconZoom = 90D;
            this.btnrestore.IsTab = false;
            this.btnrestore.Location = new System.Drawing.Point(36, 252);
            this.btnrestore.Name = "btnrestore";
            this.btnrestore.Normalcolor = System.Drawing.Color.White;
            this.btnrestore.OnHovercolor = System.Drawing.Color.Red;
            this.btnrestore.OnHoverTextColor = System.Drawing.Color.Black;
            this.btnrestore.selected = false;
            this.btnrestore.Size = new System.Drawing.Size(241, 48);
            this.btnrestore.TabIndex = 3;
            this.btnrestore.Text = "Restore DataBase";
            this.btnrestore.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnrestore.Textcolor = System.Drawing.Color.Black;
            this.btnrestore.TextFont = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnrestore.Click += new System.EventHandler(this.btnrestore_Click);
            // 
            // btnbackup
            // 
            this.btnbackup.Activecolor = System.Drawing.Color.Red;
            this.btnbackup.BackColor = System.Drawing.Color.White;
            this.btnbackup.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnbackup.BorderRadius = 0;
            this.btnbackup.ButtonText = "Backup DataBase";
            this.btnbackup.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnbackup.DisabledColor = System.Drawing.Color.Gray;
            this.btnbackup.Iconcolor = System.Drawing.Color.Transparent;
            this.btnbackup.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnbackup.Iconimage")));
            this.btnbackup.Iconimage_right = null;
            this.btnbackup.Iconimage_right_Selected = null;
            this.btnbackup.Iconimage_Selected = null;
            this.btnbackup.IconMarginLeft = 0;
            this.btnbackup.IconMarginRight = 0;
            this.btnbackup.IconRightVisible = true;
            this.btnbackup.IconRightZoom = 0D;
            this.btnbackup.IconVisible = true;
            this.btnbackup.IconZoom = 90D;
            this.btnbackup.IsTab = false;
            this.btnbackup.Location = new System.Drawing.Point(39, 105);
            this.btnbackup.Name = "btnbackup";
            this.btnbackup.Normalcolor = System.Drawing.Color.White;
            this.btnbackup.OnHovercolor = System.Drawing.Color.Red;
            this.btnbackup.OnHoverTextColor = System.Drawing.Color.Black;
            this.btnbackup.selected = false;
            this.btnbackup.Size = new System.Drawing.Size(241, 48);
            this.btnbackup.TabIndex = 2;
            this.btnbackup.Text = "Backup DataBase";
            this.btnbackup.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnbackup.Textcolor = System.Drawing.Color.Black;
            this.btnbackup.TextFont = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnbackup.Click += new System.EventHandler(this.btnbackup_Click);
            // 
            // txtrestorefile
            // 
            // 
            // 
            // 
            this.txtrestorefile.CustomButton.Image = null;
            this.txtrestorefile.CustomButton.Location = new System.Drawing.Point(219, 1);
            this.txtrestorefile.CustomButton.Name = "";
            this.txtrestorefile.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtrestorefile.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtrestorefile.CustomButton.TabIndex = 1;
            this.txtrestorefile.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtrestorefile.CustomButton.UseSelectable = true;
            this.txtrestorefile.Lines = new string[0];
            this.txtrestorefile.Location = new System.Drawing.Point(36, 223);
            this.txtrestorefile.MaxLength = 32767;
            this.txtrestorefile.Name = "txtrestorefile";
            this.txtrestorefile.PasswordChar = '\0';
            this.txtrestorefile.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtrestorefile.SelectedText = "";
            this.txtrestorefile.SelectionLength = 0;
            this.txtrestorefile.SelectionStart = 0;
            this.txtrestorefile.ShowButton = true;
            this.txtrestorefile.Size = new System.Drawing.Size(241, 23);
            this.txtrestorefile.TabIndex = 1;
            this.txtrestorefile.UseSelectable = true;
            this.txtrestorefile.WaterMark = "Select .sql File to Restore >";
            this.txtrestorefile.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtrestorefile.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.txtrestorefile.ButtonClick += new MetroFramework.Controls.MetroTextBox.ButClick(this.txtrestorefile_ButtonClick);
            // 
            // txtbackuppath
            // 
            // 
            // 
            // 
            this.txtbackuppath.CustomButton.Image = null;
            this.txtbackuppath.CustomButton.Location = new System.Drawing.Point(219, 1);
            this.txtbackuppath.CustomButton.Name = "";
            this.txtbackuppath.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtbackuppath.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtbackuppath.CustomButton.TabIndex = 1;
            this.txtbackuppath.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtbackuppath.CustomButton.UseSelectable = true;
            this.txtbackuppath.Lines = new string[0];
            this.txtbackuppath.Location = new System.Drawing.Point(39, 76);
            this.txtbackuppath.MaxLength = 32767;
            this.txtbackuppath.Name = "txtbackuppath";
            this.txtbackuppath.PasswordChar = '\0';
            this.txtbackuppath.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtbackuppath.SelectedText = "";
            this.txtbackuppath.SelectionLength = 0;
            this.txtbackuppath.SelectionStart = 0;
            this.txtbackuppath.ShowButton = true;
            this.txtbackuppath.Size = new System.Drawing.Size(241, 23);
            this.txtbackuppath.TabIndex = 0;
            this.txtbackuppath.UseSelectable = true;
            this.txtbackuppath.WaterMark = "Select Path Click the Button >";
            this.txtbackuppath.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtbackuppath.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.txtbackuppath.ButtonClick += new MetroFramework.Controls.MetroTextBox.ButClick(this.txtbackuppath_ButtonClick);
            // 
            // bunifuGradientPanel1
            // 
            this.bunifuGradientPanel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuGradientPanel1.BackgroundImage")));
            this.bunifuGradientPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuGradientPanel1.Controls.Add(this.pictureBox1);
            this.bunifuGradientPanel1.Controls.Add(this.label1);
            this.bunifuGradientPanel1.GradientBottomLeft = System.Drawing.Color.Red;
            this.bunifuGradientPanel1.GradientBottomRight = System.Drawing.Color.Red;
            this.bunifuGradientPanel1.GradientTopLeft = System.Drawing.Color.Red;
            this.bunifuGradientPanel1.GradientTopRight = System.Drawing.Color.White;
            this.bunifuGradientPanel1.Location = new System.Drawing.Point(0, 0);
            this.bunifuGradientPanel1.Name = "bunifuGradientPanel1";
            this.bunifuGradientPanel1.Quality = 10;
            this.bunifuGradientPanel1.Size = new System.Drawing.Size(324, 45);
            this.bunifuGradientPanel1.TabIndex = 73;
            // 
            // bunifuGradientPanel2
            // 
            this.bunifuGradientPanel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuGradientPanel2.BackgroundImage")));
            this.bunifuGradientPanel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuGradientPanel2.GradientBottomLeft = System.Drawing.Color.White;
            this.bunifuGradientPanel2.GradientBottomRight = System.Drawing.Color.Red;
            this.bunifuGradientPanel2.GradientTopLeft = System.Drawing.Color.Red;
            this.bunifuGradientPanel2.GradientTopRight = System.Drawing.Color.Red;
            this.bunifuGradientPanel2.Location = new System.Drawing.Point(0, 339);
            this.bunifuGradientPanel2.Name = "bunifuGradientPanel2";
            this.bunifuGradientPanel2.Quality = 10;
            this.bunifuGradientPanel2.Size = new System.Drawing.Size(324, 45);
            this.bunifuGradientPanel2.TabIndex = 74;
            // 
            // BACKUP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(324, 381);
            this.Controls.Add(this.bunifuGradientPanel2);
            this.Controls.Add(this.bunifuGradientPanel1);
            this.Controls.Add(this.lblstatus);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.sep);
            this.Controls.Add(this.btnrestore);
            this.Controls.Add(this.btnbackup);
            this.Controls.Add(this.txtrestorefile);
            this.Controls.Add(this.txtbackuppath);
            this.Name = "BACKUP";
            this.Style = MetroFramework.MetroColorStyle.White;
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.bunifuGradientPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ns1.BunifuFlatButton btnbackup;
        private ns1.BunifuFlatButton btnrestore;
        private System.Windows.Forms.Label label1;
        private ns1.BunifuSeparator sep;
        private System.Windows.Forms.Label lblstatus;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private MetroFramework.Controls.MetroTextBox txtrestorefile;
        private MetroFramework.Controls.MetroTextBox txtbackuppath;
        private ns1.BunifuGradientPanel bunifuGradientPanel1;
        private ns1.BunifuGradientPanel bunifuGradientPanel2;
    }
}