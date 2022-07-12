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

namespace Southern_Sky
{
    public partial class ADDUSER : MetroForm
    {
        string cn = "Server=localhost;Database=dbpos;Uid=root;Pwd=" + "" + ";";
        public string username = LOGIN.Username;
        public ADDUSER()
        {
            InitializeComponent();
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void btnadd_Click(object sender, EventArgs e)
        {
           
            UsernameExist();
        }
        private void UsernameExist()
        {
            MySqlConnection connection = new MySqlConnection(cn);
            MySqlCommand cmd;
            connection.Open();
            try
            {
                cmd = connection.CreateCommand();
                cmd.CommandText = "Select * from login where username = @username";
                cmd.Parameters.AddWithValue("@username", txtUsername.Text);
                MySqlDataReader Username = cmd.ExecuteReader();

                if (Username.HasRows)
                {
                    
                   MessageBox.Show("Username " + txtUsername.Text + " is already taken .", "Username Exist", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    addstaff();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void addstaff()
        {
            string password = txtPassword.Text;
            string contact = txtContactNo.Text;

            MySqlConnection connection = new MySqlConnection(cn);
            MySqlCommand cmd;
            connection.Open();

            if (txtLastname.Text == "")
            {
                errorProvider1.SetError(txtLastname, "Pls Input Lastname");
                this.errorProvider1.SetIconPadding(this.txtLastname, -20);
            }
            else
            {
                errorProvider1.SetError(txtLastname, "");
            }
            if (txtFirstname.Text == "")
            {
                errorProvider1.SetError(txtFirstname, "Pls Input Firstname");
                this.errorProvider1.SetIconPadding(this.txtFirstname, -20);
            }
            else
            {
                errorProvider1.SetError(txtFirstname, "");
            }
            if (txtMI.Text == "")
            {
                errorProvider1.SetError(txtMI, "Pls Input MiddleInitial");
                this.errorProvider1.SetIconPadding(this.txtMI, -20);
            }
            else
            {
                errorProvider1.SetError(txtMI, "");
            }
            if (txtProvince.Text == "")
            {
                errorProvider1.SetError(txtProvince, "Pls Select Province");
                this.errorProvider1.SetIconPadding(this.txtProvince, -20);
            }
            else
            {
                errorProvider1.SetError(txtProvince, "");
            }
            if (txtCity.Text == "")
            {
                errorProvider1.SetError(txtCity, "Pls Select City");
                this.errorProvider1.SetIconPadding(this.txtCity, -20);
            }
            else
            {
                errorProvider1.SetError(txtCity, "");
            }
            if (txtBarangay.Text == "")
            {
                errorProvider1.SetError(txtBarangay, "Pls Input Barangay");
                this.errorProvider1.SetIconPadding(this.txtBarangay, -20);
            }
            else
            {
                errorProvider1.SetError(txtBarangay, "");
            }
            if (txtContactNo.Text == "")
            {
                errorProvider1.SetError(txtContactNo, "Pls Input Contact No");
                this.errorProvider1.SetIconPadding(this.txtContactNo, -20);
            }
            else
            {
                errorProvider1.SetError(txtContactNo, "");
            }
            if (txtUsername.Text == "")
            {
                errorProvider1.SetError(txtUsername, "Pls Input Username");
                this.errorProvider1.SetIconPadding(this.txtUsername, -20);
            }
            else
            {
                errorProvider1.SetError(txtUsername, "");
            }
            if (cmbUserlevel.Text == "")
            {
                errorProvider1.SetError(cmbUserlevel, "Pls Select Userlevel");
                this.errorProvider1.SetIconPadding(this.cmbUserlevel, -20);
            }
            else
            {
                errorProvider1.SetError(cmbUserlevel, "");
            }
            if (txtPassword.Text == "")
            {
                errorProvider1.SetError(txtPassword, "Pls Input Password");
                this.errorProvider1.SetIconPadding(this.txtPassword, -20);
            }
            else
            {
                errorProvider1.SetError(txtPassword, "");
            }
            if (txtReTypePassword.Text == "")
            {
                errorProvider1.SetError(txtReTypePassword, "Pls Retype Password");
                this.errorProvider1.SetIconPadding(this.txtReTypePassword, -20);
            }
            else
            {
                errorProvider1.SetError(txtReTypePassword, "");
            }
            if (cmbquestion.Text == "")
            {
                errorProvider1.SetError(cmbquestion, "Pls Select Question");
                this.errorProvider1.SetIconPadding(this.cmbquestion, -20);
            }

            else
            {
                errorProvider1.SetError(cmbquestion, "");
            }
            if (txtanswer.Text == "")
            {
                errorProvider1.SetError(txtanswer, "Pls Input Answer");
                this.errorProvider1.SetIconPadding(this.txtanswer, -20);
            }
            else
            {
                errorProvider1.SetError(txtanswer, "");
            }
            if (txtPassword.Text != txtReTypePassword.Text)
            {
                MessageBox.Show("Password doesn't Match", "Important", MessageBoxButtons.RetryCancel, MessageBoxIcon.Exclamation);
                txtReTypePassword.ResetText();
            }
           
            if (txtLastname.Text != "" && txtFirstname.Text != "" && txtMI.Text != "" && txtProvince.Text != "" && txtCity.Text != "" && txtBarangay.Text != "" && txtContactNo.Text != "" && txtUsername.Text != "" && txtPassword.Text != "" && cmbUserlevel.Text != "" && cmbquestion.Text != "" && txtanswer.Text != "" && txtReTypePassword.Text != "")
            {
                if (contact.Length <= 10)
                {
                    MessageBox.Show("ContactNo must be 11 digits", "Important", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (password.Length < 8)
                {
                    errorProvider1.SetError(txtPassword, "Password must contain above 8 characters");
                }
                else
                {
                    var a = MessageBox.Show("Are you sure you want to add this user account?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (a == DialogResult.Yes)
                    {

                        try
                        {
                            cmd = connection.CreateCommand();
                            cmd.CommandText = "INSERT INTO login(ID,Lastname, Firstname, MI,Barangay, City, Province, ContactNo, Username, Userlevel, Password,Question,Answer,Status) VALUES (@ID,@Lastname,@Firstname,@MI,@Barangay,@City,@Province,@ContactNo,@Username,@Userlevel,@Password,@Question,@Answer,@Status)";
                            cmd.Parameters.AddWithValue("@ID", null);
                            cmd.Parameters.AddWithValue("@Lastname", txtLastname.Text);
                            cmd.Parameters.AddWithValue("@Firstname", txtFirstname.Text);
                            cmd.Parameters.AddWithValue("@MI", txtMI.Text);
                            cmd.Parameters.AddWithValue("@Barangay", txtBarangay.Text);
                            cmd.Parameters.AddWithValue("@City", txtCity.Text);
                            cmd.Parameters.AddWithValue("@Province", txtProvince.Text);
                            cmd.Parameters.AddWithValue("@ContactNo", txtContactNo.Text);
                            cmd.Parameters.AddWithValue("@Username", txtUsername.Text);
                            cmd.Parameters.AddWithValue("@Userlevel", cmbUserlevel.Text);
                            cmd.Parameters.AddWithValue("@Password", txtPassword.Text);
                            cmd.Parameters.AddWithValue("@Question", cmbquestion.Text);
                            cmd.Parameters.AddWithValue("@Answer", txtanswer.Text);
                            cmd.Parameters.AddWithValue("@Status", txtstatus.Text);

                            cmd.ExecuteNonQuery();

                            if (connection.State == ConnectionState.Open)
                            {
                                connection.Close();
                                MessageBox.Show("Successfully Added User " + txtFirstname.Text + ".", "User Added", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                auditadd();
                                reset();
                            }


                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);

                        }
                    }


                }
            }
        }
        private void reset()
        {
            errorProvider1.Clear();
            errorProvider1.Clear();
            errorProvider1.Clear();
            errorProvider1.Clear();
            errorProvider1.Clear();
            errorProvider1.Clear();
            errorProvider1.Clear();
            errorProvider1.Clear();
            errorProvider1.Clear();
            errorProvider1.Clear();
            errorProvider1.Clear();
            errorProvider1.Clear();
            txtID.Text = "";
            txtLastname.Text = "";
            txtFirstname.Text = "";
            txtMI.Text = "";
            txtBarangay.Text = "";
            txtProvince.Items.Clear();
            txtProvince.Items.Add("Batangas");
            txtProvince.Items.Add("Laguna");
            txtCity.Items.Clear();
            txtContactNo.Text = "";
            txtUsername.ResetText();
            cmbUserlevel.SelectedIndex = -1;
            txtPassword.ResetText();
            txtReTypePassword.ResetText();
            cmbquestion.SelectedIndex = -1;
            txtanswer.ResetText();

        }

        private void txtProvince_SelectedIndexChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            try
            {
                txtCity.Items.Clear();
                if (txtProvince.SelectedItem.ToString() == "Laguna")
                {
                    txtCity.Items.Add("Alaminos");
                    txtCity.Items.Add("Bay");
                    txtCity.Items.Add("Biñan");
                    txtCity.Items.Add("Cabuyao");
                    txtCity.Items.Add("Calamba");
                    txtCity.Items.Add("Calauan");
                    txtCity.Items.Add("Cavinti");
                    txtCity.Items.Add("Famy");
                    txtCity.Items.Add("Kalayaan");
                    txtCity.Items.Add("Liliw");
                    txtCity.Items.Add("Los Baños");
                    txtCity.Items.Add("Luisiana");
                    txtCity.Items.Add("Lumban");
                    txtCity.Items.Add("Mabitac");
                    txtCity.Items.Add("Magdalena");
                    txtCity.Items.Add("Majayjay");
                    txtCity.Items.Add("Nagcarlan");
                    txtCity.Items.Add("Paete");
                    txtCity.Items.Add("Pagsanjan");
                    txtCity.Items.Add("Pakil");
                    txtCity.Items.Add("Pangil");
                    txtCity.Items.Add("Pila");
                    txtCity.Items.Add("Rizal");
                    txtCity.Items.Add("San Pedro");
                    txtCity.Items.Add("Santa Cruz");
                    txtCity.Items.Add("Santa Maria");
                    txtCity.Items.Add("Siniloan");
                    txtCity.Items.Add("Victoria");
                }
                if (txtProvince.SelectedItem.ToString() == "Batangas")
                {
                    txtCity.Items.Add("Agoncillo");
                    txtCity.Items.Add("Alitagtag");
                    txtCity.Items.Add("Balayan");
                    txtCity.Items.Add("Balete");
                    txtCity.Items.Add("Bauan");
                    txtCity.Items.Add("Calaca");
                    txtCity.Items.Add("Calatagan");
                    txtCity.Items.Add("Cuenca");
                    txtCity.Items.Add("Lian");
                    txtCity.Items.Add("Lipa");
                    txtCity.Items.Add("Lobo");
                    txtCity.Items.Add("Mabini");
                    txtCity.Items.Add("Malvar");
                    txtCity.Items.Add("Mataas na Kahoy");
                    txtCity.Items.Add("Nasugbu");
                    txtCity.Items.Add("Padre Garcia");
                    txtCity.Items.Add("Rosario");
                    txtCity.Items.Add("San Jose");
                    txtCity.Items.Add("San Juan");
                    txtCity.Items.Add("San Luis");
                    txtCity.Items.Add("San Nicolas");
                    txtCity.Items.Add("San Pascual");
                    txtCity.Items.Add("Santa Teresita");
                    txtCity.Items.Add("Santo Tomas");
                    txtCity.Items.Add("Taal");
                    txtCity.Items.Add("Talisay");
                    txtCity.Items.Add("Taysan");
                    txtCity.Items.Add("Tanauan");
                    txtCity.Items.Add("Tingloy");
                    txtCity.Items.Add("Tuy");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtLastname_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();
        }

        private void txtFirstname_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();
        }

        private void txtMI_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();
        }

        private void txtCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();
        }

        private void txtBarangay_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();
        }

        private void txtContactNo_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();
        }

        private void cmbUserlevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            if (txtPassword.Text == "" && txtReTypePassword.Text == "")
            {
                label19.Visible = false;
            }
            else if(txtPassword.Text == txtReTypePassword.Text)
            {
                label19.Visible = true;
            }
            else if (txtPassword.Text != txtReTypePassword.Text)
            {
                label19.Visible = false;
            }
        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            reset();
        }

        private void chkshow_CheckedChanged(object sender, EventArgs e)
        {
            if (chkshow.Checked == true)
            {
                chkshow.Text = "Hide";
                txtPassword.PasswordChar = '\0';
            }
            else
            {
                chkshow.Text = "Show";
                txtPassword.PasswordChar = '*';
            }
        }

        private void txtLastname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) ||
               char.IsSymbol(e.KeyChar) ||
               char.IsPunctuation(e.KeyChar))
                e.Handled = true;
        }

        private void txtFirstname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) ||
               char.IsSymbol(e.KeyChar) ||
               char.IsPunctuation(e.KeyChar))
                e.Handled = true;
        }

        private void txtMI_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) ||
               char.IsSymbol(e.KeyChar))
                e.Handled = true;
        }

        private void txtBarangay_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsSymbol(e.KeyChar))
                e.Handled = true;
        }

        private void txtContactNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) ||
                char.IsPunctuation(e.KeyChar) ||
                char.IsSymbol(e.KeyChar))
            {

                e.Handled = true;
                errorProvider1.SetError(txtContactNo, "Digits Only!!!");
                this.errorProvider1.SetIconPadding(this.txtContactNo, -20);
            }

        }

        private void txtUsername_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsSymbol(e.KeyChar) ||
              char.IsPunctuation(e.KeyChar) || char.IsWhiteSpace(e.KeyChar))
                e.Handled = true;
        }

        private void cmbquestion_SelectedIndexChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();
        }

        private void txtanswer_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();
        }

        private void txtanswer_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsSymbol(e.KeyChar) ||
               char.IsPunctuation(e.KeyChar))
                e.Handled = true;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                checkBox1.Text = "Hide";
                txtReTypePassword.PasswordChar = '\0';
            }
            else
            {
                checkBox1.Text = "Show";
                txtReTypePassword.PasswordChar = '*';
            }
        }

        private void txtReTypePassword_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            if (txtPassword.Text == "" && txtReTypePassword.Text == "")
            {
                label19.Visible = false;
            }
            else if (txtPassword.Text == txtReTypePassword.Text)
            {
                label19.Visible = true;
            }
            else if(txtPassword.Text != txtReTypePassword.Text)
            {
                label19.Visible = false;
            }
        }
        private void auditadd()
        {
            MySqlConnection con = new MySqlConnection(cn);
            MySqlCommand cmd;
            con.Open();
            try
            {
                cmd = con.CreateCommand();
                cmd.CommandText = "Insert into audit(ID,Username,Userlevel,Access,Time,Date) values (@ID,@Username,@Userlevel,@Access,@Time,'" + System.DateTime.Now.ToString("yyyy/MM/dd") + "')";
                cmd.Parameters.AddWithValue("@ID", null);
                cmd.Parameters.AddWithValue("@Username", txtuser.Text);
                cmd.Parameters.AddWithValue("@Userlevel", "Administrator");
                cmd.Parameters.AddWithValue("@Time", lblTime.Text);
                cmd.Parameters.AddWithValue("@Access", "The Administrator has added user'" + txtUsername.Text + "'");

                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                MetroFramework.MetroMessageBox.Show(this, ex.Message);
            }
        }
        private void ADDUSER_Load(object sender, EventArgs e)
        {
            txtuser.Text = username;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            string time = DateTime.Now.ToLongTimeString();
            lblTime.Text = time;
        }

        private void lblTime_Click(object sender, EventArgs e)
        {

        }

        private void txtuser_Click(object sender, EventArgs e)
        {

        }
    }
}