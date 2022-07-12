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

        static CustomizeMsgBox MsgBox; static DialogResult result = DialogResult.No;
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
    }
}
