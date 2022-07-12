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
using CustomizeMsgBox;
using MySql.Data.MySqlClient;

namespace Southern_Sky
{
    public partial class LOGIN : MetroForm
    {
        string cn = "Server=localhost;Database=dbpos;Uid=root;Pwd=" + "" + ";";
        public static string Username;  

        int count = 0;

        public LOGIN()
        {
            InitializeComponent();
            MOVING.Start();

        }
        private void reset()
        {
            txtusername.Text ="";
            txtpassword.Text = "";
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            string time = DateTime.Now.ToLongTimeString();
            lblTime.Text = time;
            string seconds = DateTime.Now.ToString("ss");
            clock.Value = Convert.ToInt32(seconds);
        }

        private void checkactive()
        {
            check();
        }
        private void TrackLoginAdmin()
        {
            MySqlConnection con = new MySqlConnection(cn);
            MySqlCommand cmd;
            con.Open();
            try
            {
                cmd = con.CreateCommand();
                cmd.CommandText = "Insert into trackerlog(ID,Username,Userlevel,Access,Time,Date) values (@ID,@Username,@Userlevel,@Access,@Time,'" + System.DateTime.Now.ToString("yyyy/MM/dd") + "')";
                cmd.Parameters.AddWithValue("@ID", null);
                cmd.Parameters.AddWithValue("@Username", txtusername.Text);
                cmd.Parameters.AddWithValue("@Userlevel", "Administrator");
                cmd.Parameters.AddWithValue("@Time", lblTime.Text);
                cmd.Parameters.AddWithValue("@Access", "The Administrator '" + txtusername.Text + "' has logged in");

                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                MetroFramework.MetroMessageBox.Show(this, ex.Message);
            }
        }
        public void TrackLoginCashier()
        {
            MySqlConnection con = new MySqlConnection(cn);
            MySqlCommand cmd;
            con.Open();
            try
            {
                cmd = con.CreateCommand();
                cmd.CommandText = "Insert into trackerlog(ID,Username,Userlevel,Access,Time,Date) values (@ID,@Username,@Userlevel,@Access,@Time,'" + System.DateTime.Now.ToString("yyyy/MM/dd") + "')";
                cmd.Parameters.AddWithValue("@ID", null);
                cmd.Parameters.AddWithValue("@Username", txtusername.Text);
                cmd.Parameters.AddWithValue("@Userlevel", "Administrator");
                cmd.Parameters.AddWithValue("@Time", lblTime.Text);
                cmd.Parameters.AddWithValue("@Access", "The Administrator '" + txtusername.Text + "' has logged in");

                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                MetroFramework.MetroMessageBox.Show(this, ex.Message);
            }
        }
        private void check()
        {
            MySqlConnection connection = new MySqlConnection(cn);
            MySqlCommand cmd;
            connection.Open();
            try
            {
                cmd = connection.CreateCommand();
                cmd.CommandText = "Select Username,Userlevel from login where Username = @Username and Status ='Inactive'";
                cmd.Parameters.AddWithValue("@Username", txtusername.Text);
                MySqlDataReader ProductExist = cmd.ExecuteReader();

                if (ProductExist.HasRows)
                {
                    MetroFramework.MetroMessageBox.Show(this,"This username " + txtusername.Text + " is Inactive!!");
                    reset();
                    txtusername.Focus();
                }
                else
                {
                    login();
                }
             
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
 
             }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            checkactive();
        }
        private void login()
        {
            if (txtusername.Text == "")
            {
                errorProvider1.SetError(txtusername, "PLS INPUT USERNAME!");
            }
            else
            {
                errorProvider1.SetError(txtusername, "");
            }
            if (txtpassword.Text == "")
            {
                errorProvider1.SetError(txtpassword, "PLS INPUT PASSWORD");
            }
            else
            {
                errorProvider1.SetError(txtpassword, "");
            }

            if (txtusername.Text != "" && txtpassword.Text != "")
            {

                Username = txtusername.Text;
                string Password = txtpassword.Text;
                MySqlConnection connection = new MySqlConnection(cn);
                try
                {
                   string sql = "select * from login where Username = '" + txtusername.Text + "'and Password ='" + txtpassword.Text + "'";
                   connection.Open();
                   MySqlDataAdapter sda = new MySqlDataAdapter(sql, connection);
                   DataTable dt = new DataTable();
                   sda.Fill(dt);
                   connection.Close();



                   if (dt.Rows.Count > 0)
                   {
                       for (int i = 0; i < dt.Rows.Count; i++)
                       {
                           if (dt.Rows[i]["Userlevel"].Equals("administrator"))
                           {
                               MetroFramework.MetroMessageBox.Show(this, "Login Complete, " + txtusername.Text + ".", "Login Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                               this.Hide();

                               count = 0;

                               TrackLoginAdmin();

                              
                               ADMIN b = new ADMIN();
                               b.ShowDialog();
                               

                           }
                           else if (dt.Rows[i]["Userlevel"].Equals("cashier"))
                           {
                               MetroFramework.MetroMessageBox.Show(this, "Login Complete, " + txtusername.Text + ".", "Login Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                               this.Hide();

                               count = 0;

                               TrackLoginCashier();
                               CASHIER f = new CASHIER();
                               f.pictureBox10.Visible = false;
                               f.btnclose.Visible = false;
                               f.ShowDialog();
                              
                               
                           }
                       }
                   }
                   else
                   {
                       count++;
                       MetroFramework.MetroMessageBox.Show(this, "Invalid Username/Password!! Attempt: " + count + " ", null, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                       txtpassword.ResetText();
                      
                   }
                   if (count == 2)
                   {

                       var c = MetroFramework.MetroMessageBox.Show(this, "Did you forget your password?", "Change Password", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                       
                       if (c == DialogResult.Yes)
                       {
                           FORGET_PASS ff = new FORGET_PASS();
                           ff.ShowDialog();
                       }
                       else
                       {
                           this.Hide();
                           count++;
                       }

                   }
                   else if (count == 5)
                   {
                       MetroFramework.MetroMessageBox.Show(this, "5 Attempts Detected! Application Will Close -- ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                       Application.Exit();

                   }
               }

               catch (Exception ex)
               {
                   MessageBox.Show(ex.Message);
               }
                }
            }


        private void txtusername_KeyPress(object sender, KeyPressEventArgs e)
        {
           if (char.IsPunctuation(e.KeyChar))
            e.Handled = true;
            if (e.KeyChar.Equals(Convert.ToChar(13)))
            {
                bunifuThinButton21_Click(sender, e);
            }
        }

        private void txtpassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsPunctuation(e.KeyChar))
                e.Handled = true;
            if (e.KeyChar.Equals(Convert.ToChar(13)))
            {
                bunifuThinButton21_Click(sender, e);
            }
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            var a = MetroFramework.MetroMessageBox.Show(this, "Are you sure you want to exit?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Stop);

            if (a == DialogResult.Yes)
            {
                Application.Exit();
            }

        }

        private void bunifuSeparator1_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (pictureBox1.Visible == true)
            {
                pictureBox1.Visible = false;
                pictureBox2.Visible = true;
            }
            else if (pictureBox2.Visible == true)
            {
                pictureBox2.Visible = false;
                pictureBox3.Visible = true;
            }
            else if (pictureBox3.Visible == true)
            {
                pictureBox3.Visible = false;
                pictureBox4.Visible = true;
            }
            else if (pictureBox4.Visible == true)
            {
                pictureBox4.Visible = false;
                pictureBox5.Visible = true;
            }
            else if (pictureBox5.Visible == true)
            {
                pictureBox5.Visible = false;
                pictureBox6.Visible = true;
            }
            else if (pictureBox6.Visible == true)
            {
                pictureBox6.Visible = false;
                pictureBox1.Visible = true;
            }
        }

        private void txtpassword_OnValueChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtpassword.Text))
            {
                txtpassword.isPassword = true;
            }
        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            this.Hide();
            FORGET_PASS p = new FORGET_PASS();
            p.Show();
        }

        private void Testing_Tick(object sender, EventArgs e)
        {
            try
            {
                l3.Text = DateTime.Now.ToString("dddd"); l4.Text = DateTime.Now.ToString("dd/M/yyyy"); clock.Value = Convert.ToInt32(l3.Text);

            }
            catch (Exception)
            {
                return;
            }
        }

        private void chkshow_CheckedChanged(object sender, EventArgs e)
        {
            if (chkshow.Checked == true)
            {
                chkshow.Text = "Hide";
                txtpassword.isPassword = false;
            }
            else
            {
                chkshow.Text = "Show";
                txtpassword.isPassword = true;
            }

        }

        private void MOVING_Tick(object sender, EventArgs e)
        {
            //label1.Location = new Point(label1.Location.X + 5, label1.Location.Y);

            //if (label1.Location.X > this.Width)
          //  {
            //    label1.Location = new Point(0 - label1.Width, label1.Location.Y);
           // }

        }

        private void LOGIN_Load(object sender, EventArgs e)
        {
            txtusername.Select();
        }

        private void chkshow_KeyPress(object sender, KeyPressEventArgs e)
        {
             if (e.KeyChar.Equals(Convert.ToChar(13)))
            {
                bunifuThinButton21_Click(sender, e);
            }
        }

        private void txtusername_OnValueChanged(object sender, EventArgs e)
        {

        }
        }
    }
