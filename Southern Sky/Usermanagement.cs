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
    public partial class Usermanagement : MetroForm
    {
        string cn = "Server=localhost;Database=dbpos;Uid=root;Pwd=" + "" + ";";
        public string username = LOGIN.Username;
        public Usermanagement()
        {
            InitializeComponent();
        }

        private void Usermanagement_Load(object sender, EventArgs e)
        {
            show();
            txtuser.Text = username;
        }  
        private void updateaudit()
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
                cmd.Parameters.AddWithValue("@Access", "The Administrator updated user'" + txtUsername.Text + "'");

                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                MetroFramework.MetroMessageBox.Show(this, ex.Message);
            }
        }
        private void auditstatus()
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
                cmd.Parameters.AddWithValue("@Access", "The Administrator updated user'" + txtUsername.Text + "'status");

                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                MetroFramework.MetroMessageBox.Show(this, ex.Message);
            }
        }
        private void show()
        {
            MySqlConnection connection = new MySqlConnection(cn);
            connection.Open();
            try
            {
                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT * FROM `login` ";
                MySqlDataAdapter adap = new MySqlDataAdapter(cmd);
                DataTable ds = new DataTable();
                adap.Fill(ds);
                metroGrid1.DataSource = ds;
                staffcount();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }
        private void staffcount()
        {
            lblitem.Visible = true;
            lblitem.Text = metroGrid1.Rows.Count.ToString("");
            //int a, b, c;
            //a = Convert.ToInt32(lblitem.Text);
            //b = 1;
            //c = a - b;
            //lblitem.Text = Convert.ToString(c);
        }

        private void metroGrid1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtID.Text = metroGrid1.CurrentRow.Cells["ID"].Value.ToString();
            txtLastname.Text = metroGrid1.CurrentRow.Cells["Lastname"].Value.ToString();
            txtFirstname.Text = metroGrid1.CurrentRow.Cells["Firstname"].Value.ToString();
            txtMI.Text = metroGrid1.CurrentRow.Cells["MI"].Value.ToString();
            txtBarangay.Text = metroGrid1.CurrentRow.Cells["Barangay"].Value.ToString();
            txtProvince.Text = metroGrid1.CurrentRow.Cells["Province"].Value.ToString();
            txtCity.Text = metroGrid1.CurrentRow.Cells["City"].Value.ToString();
            txtContactNo.Text = metroGrid1.CurrentRow.Cells["ContactNo"].Value.ToString();
            txtUsername.Text = metroGrid1.CurrentRow.Cells["Username"].Value.ToString();
            txtuserlevel.Text = metroGrid1.CurrentRow.Cells["Userlevel"].Value.ToString();
            txtPassword.Text = metroGrid1.CurrentRow.Cells["Password"].Value.ToString();
            cmbquestion.Text = metroGrid1.CurrentRow.Cells["Question"].Value.ToString();
            txtanswer.Text = metroGrid1.CurrentRow.Cells["Answer"].Value.ToString();
            txtStatus.Text = metroGrid1.CurrentRow.Cells["Status"].Value.ToString();

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
            txtID.Text = "";
            txtLastname.Text = "";
            txtFirstname.Text = "";
            txtMI.Text = "";
            txtBarangay.Text = "";
            txtContactNo.Text = "";
            txtUsername.Text = "";
            txtuserlevel.Text = "";
            txtPassword.Text = "";
            cmbquestion.SelectedIndex = -1;
            txtanswer.Text = "";
            txtStatus.ResetText();
            txtProvince.Items.Clear();
            txtProvince.Items.Add("Batangas");
            txtProvince.Items.Add("Laguna");
            txtCity.Items.Clear();
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
    char.IsSymbol(e.KeyChar) || char.IsPunctuation(e.KeyChar))
                e.Handled = true;
        }

        private void txtBarangay_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsSymbol(e.KeyChar))
                e.Handled = true;
        }

        private void txtCity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsSymbol(e.KeyChar) || char.IsNumber(e.KeyChar))
                e.Handled = true;
        }

        private void txtUsername_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsSymbol(e.KeyChar) ||
               char.IsPunctuation(e.KeyChar) || char.IsWhiteSpace(e.KeyChar))
                e.Handled = true;
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsSymbol(e.KeyChar) ||
                char.IsPunctuation(e.KeyChar) || char.IsWhiteSpace(e.KeyChar))
                e.Handled = true;
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            ADDUSER aa = new ADDUSER();
            aa.ShowDialog();
            show();
        }
        private void NameExist()
        {
            MySqlConnection connection = new MySqlConnection(cn);
            MySqlCommand cmd;
            connection.Open();
            try
            {
                cmd = connection.CreateCommand();
                cmd.CommandText = "Select username from login where username = @username";
                cmd.Parameters.AddWithValue("@username", txtUsername.Text);
                MySqlDataReader ProductExist = cmd.ExecuteReader();


                if (ProductExist.HasRows)
                {
                    MessageBox.Show("Username " + txtUsername.Text + " Exist Already.", "Username Exist", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    updateuser();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void updateuser()
        {
            string password = txtPassword.Text;
            MySqlConnection connection = new MySqlConnection(cn);
            MySqlDataAdapter da = new MySqlDataAdapter();
            connection.Open();

            if (string.IsNullOrEmpty(txtID.Text))
            {
                MessageBox.Show("Please Select User Account to Update", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (txtLastname.Text == "")
            {
                errorProvider1.SetError(txtLastname, "required");
                this.errorProvider1.SetIconPadding(this.txtLastname, -20);
            }
            else
            {
                errorProvider1.SetError(txtLastname, "");
            }
            if (txtFirstname.Text == "")
            {
                errorProvider1.SetError(txtFirstname, "required");
                this.errorProvider1.SetIconPadding(this.txtFirstname, -20);
            }
            else
            {
                errorProvider1.SetError(txtFirstname, "");
            }
            if (txtMI.Text == "")
            {
                errorProvider1.SetError(txtMI, "required");
                this.errorProvider1.SetIconPadding(this.txtMI, -20);
            }
            else
            {
                errorProvider1.SetError(txtMI, "");
            }
            if (txtProvince.Text == "")
            {
                errorProvider1.SetError(txtProvince, "required");
                this.errorProvider1.SetIconPadding(this.txtProvince, -20);
            }
            else
            {
                errorProvider1.SetError(txtProvince, "");
            }
            if (txtCity.Text == "")
            {
                errorProvider1.SetError(txtCity, "required");
                this.errorProvider1.SetIconPadding(this.txtCity, -20);
            }
            else
            {
                errorProvider1.SetError(txtCity, "");
            }
            if (txtBarangay.Text == "")
            {
                errorProvider1.SetError(txtBarangay, "required");
                this.errorProvider1.SetIconPadding(this.txtBarangay, -20);
            }
            else
            {
                errorProvider1.SetError(txtBarangay, "");
            }
            if (txtContactNo.Text == "")
            {
                errorProvider1.SetError(txtContactNo, "required");
                this.errorProvider1.SetIconPadding(this.txtContactNo, -20);
            }
            else
            {
                errorProvider1.SetError(txtContactNo, "");
            }
            if (txtUsername.Text == "")
            {
                errorProvider1.SetError(txtUsername, "required");
                this.errorProvider1.SetIconPadding(this.txtUsername, -20);
            }
            else
            {
                errorProvider1.SetError(txtUsername, "");
            }
            if (txtuserlevel.Text == "")
            {
                errorProvider1.SetError(txtuserlevel, "required");
                this.errorProvider1.SetIconPadding(this.txtuserlevel, -20);
            }
            else
            {
                errorProvider1.SetError(txtuserlevel, "");
            }
            if (txtPassword.Text == "")
            {
                errorProvider1.SetError(txtPassword, "required");
                this.errorProvider1.SetIconPadding(this.txtPassword, -20);
            }
            else
            {
                errorProvider1.SetError(txtPassword, "");
            }
            if (cmbquestion.Text == "")
            {
                errorProvider1.SetError(cmbquestion, "required");
                this.errorProvider1.SetIconPadding(this.cmbquestion, -20);
            }
            else
            {
                errorProvider1.SetError(cmbquestion, "");
            }
            if (txtanswer.Text == "")
            {
                errorProvider1.SetError(txtanswer, "required");
                this.errorProvider1.SetIconPadding(this.txtanswer, -20);
            }
            else
            {
                errorProvider1.SetError(txtanswer, "");
            }
            if (txtLastname.Text != "" && txtFirstname.Text != "" && txtMI.Text != "" && txtProvince.Text != "" && txtCity.Text != "" && txtBarangay.Text != "" && txtContactNo.Text != "" && txtUsername.Text != "" && txtPassword.Text != "" && txtuserlevel.Text != "" && cmbquestion.Text != "" && txtanswer.Text != "")
            {
                if (password.Length > 8)
                {
                    DialogResult dg = MessageBox.Show("Are you sure you want to Edit?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dg == DialogResult.Yes)
                    {
                        try
                        {
                            da.UpdateCommand = new MySqlCommand("update login set Lastname=@Lastname, Firstname=@Firstname,MI=@MI,Barangay=@Barangay,City=@City,Province=@Province,ContactNo=@ContactNo,Username=@Username,Password=@Password,Question=@Question,Answer=@Answer where ID=" + txtID.Text + ";", connection);
                            da.UpdateCommand.Parameters.Add("@Lastname", MySqlDbType.VarChar).Value = txtLastname.Text;
                            da.UpdateCommand.Parameters.Add("@Firstname", MySqlDbType.VarChar).Value = txtFirstname.Text;
                            da.UpdateCommand.Parameters.Add("@MI", MySqlDbType.VarChar).Value = txtMI.Text;
                            da.UpdateCommand.Parameters.Add("@Barangay", MySqlDbType.VarChar).Value = txtBarangay.Text;
                            da.UpdateCommand.Parameters.Add("@City", MySqlDbType.VarChar).Value = txtCity.Text;
                            da.UpdateCommand.Parameters.Add("@Province", MySqlDbType.VarChar).Value = txtProvince.Text;
                            da.UpdateCommand.Parameters.Add("@ContactNo", MySqlDbType.VarChar).Value = txtContactNo.Text;
                            da.UpdateCommand.Parameters.Add("@Username", MySqlDbType.VarChar).Value = txtUsername.Text;
                            da.UpdateCommand.Parameters.Add("@Userlevel", MySqlDbType.VarChar).Value = txtuserlevel.Text;
                            da.UpdateCommand.Parameters.Add("@Password", MySqlDbType.VarChar).Value = txtPassword.Text;
                            da.UpdateCommand.Parameters.Add("@Question", MySqlDbType.VarChar).Value = cmbquestion.Text;
                            da.UpdateCommand.Parameters.Add("@Answer", MySqlDbType.VarChar).Value = txtanswer.Text;


                            da.UpdateCommand.ExecuteNonQuery();


                            MessageBox.Show("Successfully Updated User " + txtFirstname.Text + ".", "User Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            updateaudit();
                            show();
                            reset();
                            errorProvider1.Clear();
                            errorProvider1.Clear();
                            errorProvider1.Clear();

                        }

                        catch (Exception)
                        {
                            MessageBox.Show("Please Select Row to Update", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    errorProvider1.SetError(txtPassword, "Password must contain above 8 characters");
                    this.errorProvider1.SetIconPadding(this.txtPassword, -20);
                }
            }
        }
        private void btnupdate_Click(object sender, EventArgs e)
        {
            CheckName();
        }
        private void CheckName()
        {
            MySqlConnection connection = new MySqlConnection(cn);
            MySqlCommand cmd;
            connection.Open();
            try
            {
                cmd = connection.CreateCommand();
                cmd.CommandText = "Select username from login where username = @username and ID = '" + txtID.Text + "'";
                cmd.Parameters.AddWithValue("@username", txtUsername.Text);
                MySqlDataReader ProductExist = cmd.ExecuteReader();


                if (ProductExist.HasRows)
                {
                    updateuser();
                }
                else
                {
                    NameExist();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            if (txtLastname.Text == "" && txtFirstname.Text == "" && txtMI.Text == "" && txtProvince.Text == "" && txtCity.Text == "" && txtBarangay.Text == "" && txtContactNo.Text == "" && txtUsername.Text == "" && txtuserlevel.Text == "" && txtPassword.Text == "" && cmbquestion.Text == "" && txtanswer.Text == "")
            {
                MessageBox.Show("There are no user to be clear", "Please select user!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                DialogResult a = MessageBox.Show("Are you sure you want to clear?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                reset();
            }
        }

        private void metroGrid1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 10 && e.Value != null)
            {
                e.Value = new String('*', e.Value.ToString().Length);
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
          
        }
        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();
        }

        private void txtuserlevel_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();
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

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void btnarchive_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "1")
            {
                MessageBox.Show("You can't change to inactive this user ADMIN account!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (string.IsNullOrEmpty(txtID.Text))
            {
                MessageBox.Show("Please select user account", "Important", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else
            {
                if (txtStatus.Text == "Active")
                {
                    MySqlConnection connection = new MySqlConnection(cn);
                    MySqlDataAdapter da = new MySqlDataAdapter();
                    connection.Open();
                    DialogResult dg = MessageBox.Show("Are you sure you want to change to inactive this user account?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dg == DialogResult.Yes)
                    {
                        try
                        {
                            // int userdetailsID = Convert.ToInt32(txtID.Text);
                            da.UpdateCommand = new MySqlCommand("update login set Status='Inactive' where ID=" + txtID.Text + ";", connection);

                            da.UpdateCommand.ExecuteNonQuery();

                            MessageBox.Show("Successfully Update User " + txtFirstname.Text + " to Inactive.", "User Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                           
                            show();
                            auditstatus();
                            reset();

                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Please Select User", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else if (txtStatus.Text == "Inactive")
                {

                    MySqlConnection connection = new MySqlConnection(cn);
                    MySqlDataAdapter da = new MySqlDataAdapter();
                    connection.Open();
                    DialogResult dg = MessageBox.Show("Are you sure you want to change to active this user account?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dg == DialogResult.Yes)
                    {
                        try
                        {
                            // int userdetailsID = Convert.ToInt32(txtID.Text);
                            da.UpdateCommand = new MySqlCommand("update login set Status='Active' where ID=" + txtID.Text + ";", connection);

                            da.UpdateCommand.ExecuteNonQuery();

                            MessageBox.Show("Successfully Update User " + txtFirstname.Text + " to Active.", "User Returned", MessageBoxButtons.OK, MessageBoxIcon.Information);
                           
                            show();
                            auditstatus();
                            reset();

                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Please Select User", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            if (txtsearch.Visible == false)
            {
                Transition.ShowSync(txtsearch);
            }
            else
            {
                Transition.HideSync(txtsearch);
            }
        }

        private void txtsearch_OnValueChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Lastname")
            {
                MySqlConnection connection = new MySqlConnection(cn);
                DataTable dt = new DataTable();
                string sql = "Select * from login WHERE Lastname LIKE '%" + txtsearch.Text + "%'";
                MySqlDataAdapter da = new MySqlDataAdapter(sql, connection);
                da.Fill(dt);
                metroGrid1.DataSource = dt;
            }
            else if (comboBox1.Text == "Firstname")
            {
                MySqlConnection connection = new MySqlConnection(cn);
                DataTable dt = new DataTable();
                string sql = "Select * from login WHERE Firstname LIKE '%" + txtsearch.Text + "%'";
                MySqlDataAdapter da = new MySqlDataAdapter(sql, connection);
                da.Fill(dt);
                metroGrid1.DataSource = dt;
            }
            else if (comboBox1.Text == "MI")
            {
                MySqlConnection connection = new MySqlConnection(cn);
                DataTable dt = new DataTable();
                string sql = "Select * from login WHERE MI LIKE '%" + txtsearch.Text + "%'";
                MySqlDataAdapter da = new MySqlDataAdapter(sql, connection);
                da.Fill(dt);
                metroGrid1.DataSource = dt;
            }
            else if (comboBox1.Text == "Province")
            {
                MySqlConnection connection = new MySqlConnection(cn);
                DataTable dt = new DataTable();
                string sql = "Select * from login WHERE Province LIKE '%" + txtsearch.Text + "%'";
                MySqlDataAdapter da = new MySqlDataAdapter(sql, connection);
                da.Fill(dt);
                metroGrid1.DataSource = dt;
            }
            else if (comboBox1.Text == "City")
            {
                MySqlConnection connection = new MySqlConnection(cn);
                DataTable dt = new DataTable();
                string sql = "Select * from login WHERE City LIKE '%" + txtsearch.Text + "%'";
                MySqlDataAdapter da = new MySqlDataAdapter(sql, connection);
                da.Fill(dt);
                metroGrid1.DataSource = dt;
            }
            else if (comboBox1.Text == "Barangay")
            {
                MySqlConnection connection = new MySqlConnection(cn);
                DataTable dt = new DataTable();
                string sql = "Select * from login WHERE Barangay LIKE '%" + txtsearch.Text + "%'";
                MySqlDataAdapter da = new MySqlDataAdapter(sql, connection);
                da.Fill(dt);
                metroGrid1.DataSource = dt;
            }
            else if (comboBox1.Text == "Contact No")
            {
                MySqlConnection connection = new MySqlConnection(cn);
                DataTable dt = new DataTable();
                string sql = "Select * from login WHERE ContactNo LIKE '%" + txtsearch.Text + "%'";
                MySqlDataAdapter da = new MySqlDataAdapter(sql, connection);
                da.Fill(dt);
                metroGrid1.DataSource = dt;
            }
            else if (comboBox1.Text == "Username")
            {
                MySqlConnection connection = new MySqlConnection(cn);
                DataTable dt = new DataTable();
                string sql = "Select * from login WHERE Username LIKE '%" + txtsearch.Text + "%'";
                MySqlDataAdapter da = new MySqlDataAdapter(sql, connection);
                da.Fill(dt);
                metroGrid1.DataSource = dt;
            }
            else if (comboBox1.Text == "Password")
            {
                MySqlConnection connection = new MySqlConnection(cn);
                DataTable dt = new DataTable();
                string sql = "Select * from login WHERE Password LIKE '%" + txtsearch.Text + "%'";
                MySqlDataAdapter da = new MySqlDataAdapter(sql, connection);
                da.Fill(dt);
                metroGrid1.DataSource = dt;
            }
            else if (comboBox1.Text == "Userlevel")
            {
                MySqlConnection connection = new MySqlConnection(cn);
                DataTable dt = new DataTable();
                string sql = "Select * from login WHERE Userlevel LIKE '%" + txtsearch.Text + "%'";
                MySqlDataAdapter da = new MySqlDataAdapter(sql, connection);
                da.Fill(dt);
                metroGrid1.DataSource = dt;
            }
        }

        private void txtContactNo_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            string time = DateTime.Now.ToLongTimeString();
            lblTime.Text = time;
        }
    }
}