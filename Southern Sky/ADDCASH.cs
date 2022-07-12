using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
using MySql.Data.MySqlClient;
using System.Text.RegularExpressions;

namespace Southern_Sky
{
    public partial class ADDCASH : MetroForm
    {

        public ADDCASH()
        {
            InitializeComponent();
        }
        public static string sendtext;

        private void ADDCASH_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void ADDCASH_Load(object sender, EventArgs e)
        {
            txtTotal.Text = CASHIER.sendtext;
            txtCash.Focus();
        }

        private void txtCash_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != '\b' && e.KeyChar != '.')
            {
                e.Handled = true;
            }
            if (e.KeyChar == '.' && txtCash.Text.Contains("."))
            {
                e.Handled = true;
            }
            if (Regex.IsMatch(txtCash.Text, @"\.\d\d") && e.KeyChar != 8)
            {
                e.Handled = true;
            }

            if (e.KeyChar.Equals(Convert.ToChar(13)))
            {
                btnadd_Click(sender, e);
            }
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCash.Text))
            {
                MessageBox.Show("Please Input Cash ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Double gtotal = Convert.ToDouble(txtTotal.Text.Trim());
                Double cash = Convert.ToDouble(txtCash.Text.Trim());
                if (cash < gtotal)
                {
                    MessageBox.Show("Insufficient Cash", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                else
                {
                    double cash1 = Convert.ToDouble(txtCash.Text.Trim());

                    txtCash.Text = Convert.ToString(String.Format("{0:0.00}", cash1));
                    sendtext = txtCash.Text;
                    MessageBox.Show("Cash Added " + txtCash.Text + ".", "Thankyou", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtCash_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                MessageBox.Show("Right Clicked is Disabled", "Disabled");
            }
        }

        private void txtCash_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control == true)
            {
                MessageBox.Show("Cut/Copy and Paste Option is Disabled", "Disabled");
            }
        }

        private void button_click(object sender, EventArgs e)
        {
            Button b = (Button)sender;

            if (b.Text == ".")
            {
                if (!txtCash.Text.Contains("."))
                {
                    txtCash.Text = txtCash.Text + b.Text;
                }
            }
            else
            {
                txtCash.Text = txtCash.Text + b.Text;
            }
        }
    }
}