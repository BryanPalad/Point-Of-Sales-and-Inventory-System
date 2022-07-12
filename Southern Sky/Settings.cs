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
    public partial class Settings : MetroForm
    {
        string cn = "Server=localhost;Database=dbpos;Uid=root;Pwd= " + "" + ";";
        public string username = LOGIN.Username;
        public Settings()
        {
            InitializeComponent();
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            txtID.ResetText();
            txtCategory.ResetText();
            txtCategory.Enabled = true;
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtID.Text))
            {
                MessageBox.Show("Click the add new category button", "Important", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                CategoryExist();
            }
        }

        private void CategoryExist()
        {
            MySqlConnection connection = new MySqlConnection(cn);
            MySqlCommand cmd;
            connection.Open();
            try
            {
                cmd = connection.CreateCommand();
                cmd.CommandText = "Select * from categories where category = @cat";
                cmd.Parameters.AddWithValue("@cat", txtCategory.Text);
                MySqlDataReader Exist = cmd.ExecuteReader();

                if (Exist.HasRows)
                {
                    MessageBox.Show("Category " + txtCategory.Text + " already exist .", "Category Exist", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    AddCategory();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void AddCategory()
        {
            MySqlConnection connection = new MySqlConnection(cn);
            MySqlCommand cmd;
            connection.Open();

            if (string.IsNullOrEmpty(txtCategory.Text))
            {
                MessageBox.Show("Please fill the category textbox", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    cmd = connection.CreateCommand();
                    cmd.CommandText = "INSERT INTO categories(Number,Category) values (@Number,@Category)";
                    cmd.Parameters.AddWithValue("@Number", null);
                    cmd.Parameters.AddWithValue("@Category", txtCategory.Text);

                    cmd.ExecuteNonQuery();
                    if (connection.State == ConnectionState.Open)
                    {
                        save();
                        connection.Close();
                        MessageBox.Show("Successfully Added Category " + txtCategory.Text + ".", "Category Added", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtCategory.ResetText();
                        show();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private void show()
        {
            MySqlConnection connection = new MySqlConnection(cn);
            connection.Open();
            try
            {
                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT * FROM `categories` ";
                MySqlDataAdapter adap = new MySqlDataAdapter(cmd);
                DataTable ds = new DataTable();
                adap.Fill(ds);
                metroGrid1.DataSource = ds;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void showpercentage()
        {
            MySqlConnection connection = new MySqlConnection(cn);
            connection.Open();
            try
            {
                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT * FROM `percentage` ";
                MySqlDataAdapter adap = new MySqlDataAdapter(cmd);
                DataTable ds = new DataTable();
                adap.Fill(ds);
                metroGrid2.DataSource = ds;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void metroGrid1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtID.Text = metroGrid1.CurrentRow.Cells["Number"].Value.ToString();
            txtCategory.Text = metroGrid1.CurrentRow.Cells["Category"].Value.ToString();
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = new MySqlConnection(cn);
            MySqlDataAdapter da = new MySqlDataAdapter();
            connection.Open();
            DialogResult dg = MessageBox.Show("Are you sure you want to permanently remove this?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dg == DialogResult.Yes)
            {
                delete();
                try
                {
                    // int userdetailsID = Convert.ToInt32(txtID.Text);
                    da.DeleteCommand = new MySqlCommand("delete from categories where Number =" + txtID.Text + ";", connection);


                    da.DeleteCommand.ExecuteNonQuery();

                    MessageBox.Show("Successfully Removed Category " + txtCategory.Text + ".", "Category Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    show();
                    txtCategory.ResetText();
                    txtID.ResetText();
                }
                catch (Exception)
                {
                   MessageBox.Show("Please Select Product to Remove", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnsavepercent_Click(object sender, EventArgs e)
        {
            UpdatePercentage();
        }
        private void UpdatePercentage()
        {
            if (string.IsNullOrEmpty(FSI1.Text) || string.IsNullOrEmpty(FSI2.Text) || string.IsNullOrEmpty(SSI1.Text) || string.IsNullOrEmpty(SSI2.Text))
            {
                MessageBox.Show("Please fill the percentage textbox", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MySqlConnection connection = new MySqlConnection(cn);
                MySqlDataAdapter da = new MySqlDataAdapter();
                connection.Open();
                DialogResult dg = MessageBox.Show("Are you sure you want to Edit?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dg == DialogResult.Yes)
                {
                    save();
                    try
                    {
                        da.UpdateCommand = new MySqlCommand("update percentage set FSI1=@FSI1, FSI2=@FSI2, SSI1=@SSI1, SSI2=@SSI2 where ID=" + txtPercentID.Text + ";", connection);
                        da.UpdateCommand.Parameters.Add("@FSI1", MySqlDbType.VarChar).Value = FSI1.Text;
                        da.UpdateCommand.Parameters.Add("@FSI2", MySqlDbType.VarChar).Value = FSI2.Text;
                        da.UpdateCommand.Parameters.Add("@SSI1", MySqlDbType.VarChar).Value = SSI1.Text;
                        da.UpdateCommand.Parameters.Add("@SSI2", MySqlDbType.VarChar).Value = SSI2.Text;

                        da.UpdateCommand.ExecuteNonQuery();

                        MessageBox.Show("Successfully Updated Percentage.", "Percentage Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        showpercentage();
                        FSI1.ResetText();
                        FSI2.ResetText();
                        SSI1.ResetText();
                        SSI2.ResetText();
                        FSI1.Enabled = false;
                        FSI2.Enabled = false;
                        SSI1.Enabled = false;
                        SSI2.Enabled = false;
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Please Select Product to Update", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void metroGrid2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            FSI1.Enabled = true;
            FSI2.Enabled = true;
            SSI1.Enabled = true;
            SSI2.Enabled = true;
            txtPercentID.Text = metroGrid2.CurrentRow.Cells["ID"].Value.ToString();
            FSI1.Text = metroGrid2.CurrentRow.Cells["FSI1"].Value.ToString();
            FSI2.Text = metroGrid2.CurrentRow.Cells["FSI2"].Value.ToString();
            SSI1.Text = metroGrid2.CurrentRow.Cells["SSI1"].Value.ToString();
            SSI2.Text = metroGrid2.CurrentRow.Cells["SSI2"].Value.ToString();
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FSI1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) ||
           char.IsPunctuation(e.KeyChar) ||
           char.IsSymbol(e.KeyChar))
                e.Handled = true;
        }

        private void FSI2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) ||
          char.IsPunctuation(e.KeyChar) ||
          char.IsSymbol(e.KeyChar))
                e.Handled = true;
        }

        private void SSI1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) ||
          char.IsPunctuation(e.KeyChar) ||
          char.IsSymbol(e.KeyChar))
                e.Handled = true;
        }

        private void SSI2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) ||
           char.IsPunctuation(e.KeyChar) ||
           char.IsSymbol(e.KeyChar))
                e.Handled = true;
        }

        private void txtCategory_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) ||
                char.IsSymbol(e.KeyChar) ||
                char.IsPunctuation(e.KeyChar))
                e.Handled = true;
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtID.Text) || string.IsNullOrEmpty(txtCategory.Text))
            {
                MessageBox.Show("Please fill the category textbox", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MySqlConnection connection = new MySqlConnection(cn);
                MySqlDataAdapter da = new MySqlDataAdapter();
                connection.Open();
                DialogResult dg = MessageBox.Show("Are you sure you want to Edit?","Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dg == DialogResult.Yes)
                {
                    update();
                    try
                    {
                        da.UpdateCommand = new MySqlCommand("update categories set Category = @Category where Number=" + txtID.Text + ";", connection);
                        da.UpdateCommand.Parameters.Add("@Category", MySqlDbType.VarChar).Value = txtCategory.Text;

                        da.UpdateCommand.ExecuteNonQuery();

                        MessageBox.Show("Successfully Updated '" + txtCategory.Text + "' Category.", "Category Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        show();
                    }
                    catch (Exception)
                    {
                       MessageBox.Show("Please Select Category to Update", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private void save()
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
                cmd.Parameters.AddWithValue("@Access", "The Administrator saved category'" + txtCategory.Text + "'");

                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                MetroFramework.MetroMessageBox.Show(this, ex.Message);
            }
        }
        private void update()
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
                cmd.Parameters.AddWithValue("@Access", "The Administrator updated category'" + txtCategory.Text + "'");

                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                MetroFramework.MetroMessageBox.Show(this, ex.Message);
            }
        }
        private void delete()
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
                cmd.Parameters.AddWithValue("@Access", "The Administrator removed category'" + txtCategory.Text + "'");

                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                MetroFramework.MetroMessageBox.Show(this, ex.Message);
            }
        }
        private void percentage()
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
                cmd.Parameters.AddWithValue("@Access", "The Administrator updated the percentage for FSI/SSI Items");

                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                MetroFramework.MetroMessageBox.Show(this, ex.Message);
            }
        }
        private void Settings_Load(object sender, EventArgs e)
        {
            txtuser.Text = username;
            show();
            showpercentage();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            string time = DateTime.Now.ToLongTimeString();
            lblTime.Text = time;
        }
    }
}


                  
                        
                               