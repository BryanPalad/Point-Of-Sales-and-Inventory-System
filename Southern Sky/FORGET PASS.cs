using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using MetroFramework.Forms;
namespace Southern_Sky
{
    public partial class FORGET_PASS : MetroForm
    {
        string cn = "Server=localhost;Database=dbpos;Uid=root;Pwd= " + "" + ";";
        public static string Username;
        public FORGET_PASS()
        {
            InitializeComponent();
        }
        private void chkshow_CheckedChanged(object sender, EventArgs e)
        {
            if (chkshow.Checked == true)
            {
                chkshow.Text = ("Hide");
                txtpass.isPassword = false;
            }
            else
            {
                chkshow.Text = ("Show");
                txtpass.isPassword = true;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                checkBox1.Text = ("Hide");
                txtconfirm.isPassword = false;
            }
            else
            {
                checkBox1.Text = ("Show");
                txtconfirm.isPassword = true;
            }
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            this.Hide();
            LOGIN l = new LOGIN();
            l.Show();
        }
        private void txtpass_OnValueChanged_1(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtpass.Text))
            {
                txtpass.isPassword = true;
            }
        }

        private void txtconfirm_OnValueChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtconfirm.Text))
            {
                txtconfirm.isPassword = true;
            }
        }

        private void bunifuThinButton21_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            LOGIN a = new LOGIN();
            a.Show();
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            changepass1();
        }
        private void changepass1()
        {

            MySqlConnection connection = new MySqlConnection(cn);
            MySqlCommand cmd;
            connection.Open();

            try
            {
                cmd = connection.CreateCommand();
                cmd.CommandText = "Select * from login where username = @username";
                cmd.Parameters.AddWithValue("@username", txtusername.Text);
                MySqlDataReader ProductExist = cmd.ExecuteReader();

                if (ProductExist.HasRows)
                {
                    question();
                }
                else
                {
                    MessageBox.Show("The username you’ve entered doesn’t match any account", "Check Username", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtusername.ResetText();
                    txtpass.ResetText();
                    txtconfirm.ResetText();
                    cmbquestion.SelectedIndex = -1;
                    txtanswer.ResetText();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void question()
        {
            MySqlConnection connection = new MySqlConnection(cn);
            MySqlCommand cmd;
            connection.Open();

           
            try
            {
                cmd = connection.CreateCommand();
                cmd.CommandText = "Select * from login where question = @question and username = @username";
                cmd.Parameters.AddWithValue("@question", cmbquestion.Text);
                cmd.Parameters.AddWithValue("@username", txtusername.Text);
                MySqlDataReader ProductExist = cmd.ExecuteReader();

                if (ProductExist.HasRows)
                {
                    answer();
                }
                else
                {
                    MessageBox.Show("Incorrect Question or Answer, please try again", "User Exist", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbquestion.SelectedIndex = -1;
                    txtanswer.ResetText();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void answer()
        {
            MySqlConnection connection = new MySqlConnection(cn);
            MySqlCommand cmd;
            connection.Open();

            try
            {
                cmd = connection.CreateCommand();
                cmd.CommandText = "Select * from login where answer = @answer and username = @username";
                cmd.Parameters.AddWithValue("@answer", txtanswer.Text);
                cmd.Parameters.AddWithValue("@username", txtusername.Text);
                MySqlDataReader ProductExist = cmd.ExecuteReader();

                if (ProductExist.HasRows)
                {
                    updatepassuser();
                }
                else
                {
                    MessageBox.Show("Incorrect Question or Answer, please try again", "User Exist", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbquestion.SelectedIndex = -1;
                    txtanswer.ResetText();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void updatepassuser()
        {
            string password = txtpass.Text;
            MySqlConnection connection = new MySqlConnection(cn);
            MySqlDataAdapter da = new MySqlDataAdapter();
            connection.Open();

            if (string.IsNullOrEmpty(txtusername.Text) || string.IsNullOrEmpty(txtpass.Text) || string.IsNullOrEmpty(txtconfirm.Text))
            {
                MessageBox.Show("Please fill up the username, new password, confirm", "Important", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (txtpass.Text != txtconfirm.Text)
            {
                MessageBox.Show("Password Mismatch", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (password.Length > 8)
                {
                    DialogResult dg = MessageBox.Show("Are you sure you want to change this pass?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dg == DialogResult.Yes)
                    {
                        try
                        {
                            da.UpdateCommand = new MySqlCommand("update login set password = '" + txtpass.Text + "' where username = '" + txtusername.Text + "';", connection);

                            da.UpdateCommand.ExecuteNonQuery();

                            MessageBox.Show("Successfully Updated " + txtusername.Text + " User .", "User Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtpass.ResetText();
                            txtconfirm.ResetText();
                            txtusername.ResetText();
                            cmbquestion.SelectedIndex = -1;
                            txtanswer.ResetText();

    
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                    if (dg == DialogResult.No)
                    {
                       MessageBox.Show("User change password cancel", "Cancel Changing Password", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtusername.ResetText();
                        txtpass.ResetText();
                        txtconfirm.ResetText();
                        txtusername.ResetText();

                    }
                }
                else
                {
                    MessageBox.Show("Password must contain above 8 letters or numbers", "Important", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void txtusername_OnValueChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtusername.Text))
            {
                lblcheckusername.Text = "None";
            }
            else
            {
                labelcheckuser();
            }
        }

        private void labelcheckuser()
        {
            MySqlConnection connection = new MySqlConnection(cn);
            MySqlCommand cmd;
            connection.Open();

            try
            {
                cmd = connection.CreateCommand();
                cmd.CommandText = "Select * from login where username = @username";
                cmd.Parameters.AddWithValue("@username", txtusername.Text);
                MySqlDataReader ProductExist = cmd.ExecuteReader();

                if (ProductExist.HasRows)
                {
                    lblcheckusername.Text = "Username Exist";
                }
                else
                {
                    lblcheckusername.Text = "Username doesn't Exist";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FORGET_PASS_Load(object sender, EventArgs e)
        {

        }

        private void txtpass_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtpass.Focus();
        }

        private void txtconfirm_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtconfirm.Focus();
        }
    }
}
             