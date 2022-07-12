using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomizeMsgBox
{
    public partial class CustomizeMsgBox : Form
    {
        public CustomizeMsgBox()
        {
            InitializeComponent();
        }

        static CustomizeMsgBox MsgBox;
        private Button btnone;
        private Button btntwo;
        private Label label1;
        private Label label2;
        private Timer close;
        private IContainer components;
        private ns1.BunifuGradientPanel bunifuGradientPanel1;
        private ns1.BunifuGradientPanel bunifuGradientPanel2;
        private ns1.BunifuGradientPanel bunifuGradientPanel3;
        private ns1.BunifuGradientPanel bunifuGradientPanel4; static DialogResult result = DialogResult.No;
        public static DialogResult Show(string Text, string Caption, string btnOk, string btnCancel)
        {
            MsgBox = new CustomizeMsgBox();
            MsgBox.label2.Text = Caption;
            MsgBox.label1.Text = Text;
            MsgBox.btnone.Text = btnOk;
            MsgBox.btntwo.Text = btnCancel;
            result = DialogResult.No;
            MsgBox.ShowDialog();
            return result;

        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            close.Start();
        }

        private void btnone_Click(object sender, EventArgs e)
        {
            result = DialogResult.Yes; MsgBox.Close();
        }

        private void btntwo_Click(object sender, EventArgs e)
        {
            result = DialogResult.No; MsgBox.Close();
        }

        private void close_Tick(object sender, EventArgs e)
        {
            if (this.Opacity > 0)
            {
                this.Opacity -= 0.1;
            }
            else
            {
                this.Close();
            }
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomizeMsgBox));
            this.btnone = new System.Windows.Forms.Button();
            this.btntwo = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.close = new System.Windows.Forms.Timer(this.components);
            this.bunifuGradientPanel1 = new ns1.BunifuGradientPanel();
            this.bunifuGradientPanel2 = new ns1.BunifuGradientPanel();
            this.bunifuGradientPanel3 = new ns1.BunifuGradientPanel();
            this.bunifuGradientPanel4 = new ns1.BunifuGradientPanel();
            this.SuspendLayout();
            // 
            // btnone
            // 
            this.btnone.Location = new System.Drawing.Point(255, 134);
            this.btnone.Name = "btnone";
            this.btnone.Size = new System.Drawing.Size(75, 23);
            this.btnone.TabIndex = 0;
            this.btnone.Text = "YES";
            this.btnone.UseVisualStyleBackColor = true;
            this.btnone.Click += new System.EventHandler(this.btnone_Click);
            // 
            // btntwo
            // 
            this.btntwo.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btntwo.Location = new System.Drawing.Point(336, 133);
            this.btntwo.Name = "btntwo";
            this.btntwo.Size = new System.Drawing.Size(75, 23);
            this.btntwo.TabIndex = 1;
            this.btntwo.Text = "NO";
            this.btntwo.UseVisualStyleBackColor = true;
            this.btntwo.Click += new System.EventHandler(this.btntwo_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(35, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(35, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "label2";
            // 
            // close
            // 
            this.close.Tick += new System.EventHandler(this.close_Tick);
            // 
            // bunifuGradientPanel1
            // 
            this.bunifuGradientPanel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuGradientPanel1.BackgroundImage")));
            this.bunifuGradientPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuGradientPanel1.GradientBottomLeft = System.Drawing.Color.Red;
            this.bunifuGradientPanel1.GradientBottomRight = System.Drawing.Color.Red;
            this.bunifuGradientPanel1.GradientTopLeft = System.Drawing.Color.Red;
            this.bunifuGradientPanel1.GradientTopRight = System.Drawing.Color.Red;
            this.bunifuGradientPanel1.Location = new System.Drawing.Point(0, -9);
            this.bunifuGradientPanel1.Name = "bunifuGradientPanel1";
            this.bunifuGradientPanel1.Quality = 10;
            this.bunifuGradientPanel1.Size = new System.Drawing.Size(10, 189);
            this.bunifuGradientPanel1.TabIndex = 5;
            // 
            // bunifuGradientPanel2
            // 
            this.bunifuGradientPanel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuGradientPanel2.BackgroundImage")));
            this.bunifuGradientPanel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuGradientPanel2.GradientBottomLeft = System.Drawing.Color.Red;
            this.bunifuGradientPanel2.GradientBottomRight = System.Drawing.Color.Red;
            this.bunifuGradientPanel2.GradientTopLeft = System.Drawing.Color.Red;
            this.bunifuGradientPanel2.GradientTopRight = System.Drawing.Color.Red;
            this.bunifuGradientPanel2.Location = new System.Drawing.Point(437, -1);
            this.bunifuGradientPanel2.Name = "bunifuGradientPanel2";
            this.bunifuGradientPanel2.Quality = 10;
            this.bunifuGradientPanel2.Size = new System.Drawing.Size(10, 181);
            this.bunifuGradientPanel2.TabIndex = 6;
            // 
            // bunifuGradientPanel3
            // 
            this.bunifuGradientPanel3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuGradientPanel3.BackgroundImage")));
            this.bunifuGradientPanel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuGradientPanel3.GradientBottomLeft = System.Drawing.Color.Red;
            this.bunifuGradientPanel3.GradientBottomRight = System.Drawing.Color.Red;
            this.bunifuGradientPanel3.GradientTopLeft = System.Drawing.Color.Red;
            this.bunifuGradientPanel3.GradientTopRight = System.Drawing.Color.Red;
            this.bunifuGradientPanel3.Location = new System.Drawing.Point(10, 170);
            this.bunifuGradientPanel3.Name = "bunifuGradientPanel3";
            this.bunifuGradientPanel3.Quality = 10;
            this.bunifuGradientPanel3.Size = new System.Drawing.Size(427, 10);
            this.bunifuGradientPanel3.TabIndex = 7;
            // 
            // bunifuGradientPanel4
            // 
            this.bunifuGradientPanel4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuGradientPanel4.BackgroundImage")));
            this.bunifuGradientPanel4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuGradientPanel4.GradientBottomLeft = System.Drawing.Color.Red;
            this.bunifuGradientPanel4.GradientBottomRight = System.Drawing.Color.Red;
            this.bunifuGradientPanel4.GradientTopLeft = System.Drawing.Color.Red;
            this.bunifuGradientPanel4.GradientTopRight = System.Drawing.Color.Red;
            this.bunifuGradientPanel4.Location = new System.Drawing.Point(10, -1);
            this.bunifuGradientPanel4.Name = "bunifuGradientPanel4";
            this.bunifuGradientPanel4.Quality = 10;
            this.bunifuGradientPanel4.Size = new System.Drawing.Size(427, 10);
            this.bunifuGradientPanel4.TabIndex = 8;
            // 
            // CustomizeMsgBox
            // 
            this.AcceptButton = this.btnone;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.CancelButton = this.btntwo;
            this.ClientSize = new System.Drawing.Size(447, 181);
            this.ControlBox = false;
            this.Controls.Add(this.bunifuGradientPanel4);
            this.Controls.Add(this.bunifuGradientPanel3);
            this.Controls.Add(this.bunifuGradientPanel2);
            this.Controls.Add(this.bunifuGradientPanel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btntwo);
            this.Controls.Add(this.btnone);
            this.Name = "CustomizeMsgBox";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
