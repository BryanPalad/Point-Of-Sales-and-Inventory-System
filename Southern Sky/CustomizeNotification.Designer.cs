namespace Southern_Sky
{
    partial class CustomizeNotification
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
            BunifuAnimatorNS.Animation animation1 = new BunifuAnimatorNS.Animation();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomizeNotification));
            this.timeout = new System.Windows.Forms.Timer(this.components);
            this.close = new System.Windows.Forms.Timer(this.components);
            this.trans = new BunifuAnimatorNS.BunifuTransition(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.message = new System.Windows.Forms.Label();
            this.icon = new System.Windows.Forms.PictureBox();
            this.btnone = new ns1.BunifuThinButton2();
            this.bunifuElipse1 = new ns1.BunifuElipse(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.icon)).BeginInit();
            this.SuspendLayout();
            // 
            // timeout
            // 
            this.timeout.Enabled = true;
            this.timeout.Interval = 5000;
            this.timeout.Tick += new System.EventHandler(this.timeout_Tick);
            // 
            // close
            // 
            this.close.Interval = 30;
            this.close.Tick += new System.EventHandler(this.close_Tick);
            // 
            // trans
            // 
            this.trans.AnimationType = BunifuAnimatorNS.AnimationType.Rotate;
            this.trans.Cursor = null;
            animation1.AnimateOnlyDifferences = true;
            animation1.BlindCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.BlindCoeff")));
            animation1.LeafCoeff = 0F;
            animation1.MaxTime = 1F;
            animation1.MinTime = 0F;
            animation1.MosaicCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.MosaicCoeff")));
            animation1.MosaicShift = ((System.Drawing.PointF)(resources.GetObject("animation1.MosaicShift")));
            animation1.MosaicSize = 0;
            animation1.Padding = new System.Windows.Forms.Padding(50);
            animation1.RotateCoeff = 1F;
            animation1.RotateLimit = 0F;
            animation1.ScaleCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.ScaleCoeff")));
            animation1.SlideCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.SlideCoeff")));
            animation1.TimeCoeff = 0F;
            animation1.TransparencyCoeff = 1F;
            this.trans.DefaultAnimation = animation1;
            // 
            // label2
            // 
            this.trans.SetDecoration(this.label2, BunifuAnimatorNS.DecorationType.None);
            this.label2.Font = new System.Drawing.Font("Century Gothic", 15F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(9, 150);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(454, 33);
            this.label2.TabIndex = 13;
            this.label2.Text = "Success";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // message
            // 
            this.message.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trans.SetDecoration(this.message, BunifuAnimatorNS.DecorationType.None);
            this.message.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.message.ForeColor = System.Drawing.Color.White;
            this.message.Location = new System.Drawing.Point(9, 183);
            this.message.Name = "message";
            this.message.Size = new System.Drawing.Size(454, 163);
            this.message.TabIndex = 12;
            this.message.Text = "Success Message";
            this.message.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // icon
            // 
            this.trans.SetDecoration(this.icon, BunifuAnimatorNS.DecorationType.None);
            this.icon.Location = new System.Drawing.Point(191, 42);
            this.icon.Name = "icon";
            this.icon.Size = new System.Drawing.Size(88, 88);
            this.icon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.icon.TabIndex = 11;
            this.icon.TabStop = false;
            this.icon.Visible = false;
            // 
            // btnone
            // 
            this.btnone.ActiveBorderThickness = 1;
            this.btnone.ActiveCornerRadius = 20;
            this.btnone.ActiveFillColor = System.Drawing.Color.SeaGreen;
            this.btnone.ActiveForecolor = System.Drawing.Color.White;
            this.btnone.ActiveLineColor = System.Drawing.Color.SeaGreen;
            this.btnone.BackColor = System.Drawing.Color.DarkGray;
            this.btnone.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnone.BackgroundImage")));
            this.btnone.ButtonText = "ThinButton";
            this.btnone.Cursor = System.Windows.Forms.Cursors.Hand;
            this.trans.SetDecoration(this.btnone, BunifuAnimatorNS.DecorationType.None);
            this.btnone.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnone.ForeColor = System.Drawing.Color.SeaGreen;
            this.btnone.IdleBorderThickness = 1;
            this.btnone.IdleCornerRadius = 20;
            this.btnone.IdleFillColor = System.Drawing.Color.White;
            this.btnone.IdleForecolor = System.Drawing.Color.SeaGreen;
            this.btnone.IdleLineColor = System.Drawing.Color.SeaGreen;
            this.btnone.Location = new System.Drawing.Point(275, 338);
            this.btnone.Margin = new System.Windows.Forms.Padding(5);
            this.btnone.Name = "btnone";
            this.btnone.Size = new System.Drawing.Size(181, 41);
            this.btnone.TabIndex = 14;
            this.btnone.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnone.Click += new System.EventHandler(this.btnone_Click);
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 5;
            this.bunifuElipse1.TargetControl = this;
            // 
            // CustomizeNotification
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(473, 389);
            this.Controls.Add(this.btnone);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.message);
            this.Controls.Add(this.icon);
            this.trans.SetDecoration(this, BunifuAnimatorNS.DecorationType.None);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CustomizeNotification";
            this.Text = "CustomizeNotification";
            this.Load += new System.EventHandler(this.CustomizeNotification_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CustomizeNotification_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.icon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timeout;
        private System.Windows.Forms.Timer close;
        private BunifuAnimatorNS.BunifuTransition trans;
        private ns1.BunifuElipse bunifuElipse1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label message;
        private System.Windows.Forms.PictureBox icon;
        private ns1.BunifuThinButton2 btnone;
    }
}