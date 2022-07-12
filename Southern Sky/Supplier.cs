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
    public partial class Supplier : MetroForm
    {
        string cn = "Server=localhost;Database=dbpos;Uid=root;Pwd= " + "" + ";";
        public string username = LOGIN.Username;
        public Supplier()
        {
            InitializeComponent();
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
                cmd.Parameters.AddWithValue("@Access", "The Administrator updated supplier'" + txtsupplier.Text + "'");

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
                cmd.CommandText = "SELECT * FROM `supplierproduct` ";
                MySqlDataAdapter adap = new MySqlDataAdapter(cmd);
                DataTable ds = new DataTable();
                adap.Fill(ds);
                metroGrid1.DataSource = ds;
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
        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            Add_Supplier aa = new Add_Supplier();
            aa.ShowDialog();
            show();
        }

        private void metroGrid1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void Supplier_Load(object sender, EventArgs e)
        {
            txtuser.Text = username;
            show();
            getcategory();
        }
        private void getcategory()
        {
            
        }
        private void bunifuThinButton24_Click(object sender, EventArgs e)
        {
            txtlastname.Text = "";
            txtfirstname.Text = "";
            txtaddress.Text ="";
            txtcontact.Text = "";
            txtCity.SelectedIndex = -1;
            txtsupplier.Text = "";
            txtStatus.ResetText();
        }
        private void reset()
        {
            errorProvider1.Clear();
            txtfirstname.Text = "";
            txtlastname.Text = "";
            txtaddress.Text = "";
            txtcontact.Text = "";
            txtCity.Text = "";
            txtsupplier.Text = "";
            txtCity.SelectedIndex = -1;
        }
        private void bunifuThinButton26_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
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
                cmd.CommandText = "Select Lastname from supplier where Lastname = @lastname and Supplier_id = '" + txtID.Text + "'";
                cmd.Parameters.AddWithValue("@lastname", txtlastname.Text);
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
        private void updateuser()
        {
            MySqlConnection connection = new MySqlConnection(cn);
            MySqlDataAdapter da = new MySqlDataAdapter();
            connection.Open();
            if(string.IsNullOrEmpty(txtID.Text))
            {
                MessageBox.Show("Please select user to update", "Important", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            if (txtlastname.Text == "")
            {
                errorProvider1.SetError(txtlastname, "required");
                this.errorProvider1.SetIconPadding(this.txtlastname, -20);
            }
            else
            {
                errorProvider1.SetError(txtlastname, "");
            }
            if (txtfirstname.Text == "")
            {
                errorProvider1.SetError(txtfirstname, "required");
                this.errorProvider1.SetIconPadding(this.txtfirstname, -20);
            }
            else
            {
                errorProvider1.SetError(txtfirstname, "");
            }
            if (txtaddress.Text == "")
            {
                errorProvider1.SetError(txtaddress, "required");
                this.errorProvider1.SetIconPadding(this.txtaddress, -20);
            }
            else
            {
                errorProvider1.SetError(txtaddress, "");
            }
            if (txtcontact.Text == "")
            {
                errorProvider1.SetError(txtcontact, "required");
                this.errorProvider1.SetIconPadding(this.txtcontact, -20);
            }
            else
            {
                errorProvider1.SetError(txtcontact, "");
            }

            
            
            if (txtsupplier.Text == "")
            {
                errorProvider1.SetError(txtsupplier, "required");
                this.errorProvider1.SetIconPadding(this.txtsupplier, -20);
            }
            else
            {
                errorProvider1.SetError(txtsupplier, "");
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
           
            if (txtlastname.Text != "" && txtfirstname.Text != "" && txtcontact.Text != "" && txtaddress.Text != ""  && txtCity.Text != "")
            {
                DialogResult dg =MessageBox.Show("Are you sure you want to Edit?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dg == DialogResult.Yes)
                {
                    try
                    {
                        da.UpdateCommand = new MySqlCommand("update supplier set Lastname=@lastname, Firstname=@Firstname,Address=@Address,ContactNo=@Contact,ProductName=@Product,Category=@Category,Quantity=@Quantity,city=@city,suppliercompany=@supplier where Supplier_id=" + txtID.Text + ";", connection);
                        da.UpdateCommand.Parameters.Add("@lastname", MySqlDbType.VarChar).Value = txtlastname.Text;
                        da.UpdateCommand.Parameters.Add("@Firstname", MySqlDbType.VarChar).Value = txtfirstname.Text;
                        da.UpdateCommand.Parameters.Add("@Address", MySqlDbType.VarChar).Value = txtaddress.Text;
                        da.UpdateCommand.Parameters.Add("@Contact", MySqlDbType.VarChar).Value = txtcontact.Text;
                        da.UpdateCommand.Parameters.Add("@city", MySqlDbType.VarChar).Value = txtCity.Text;
                        da.UpdateCommand.Parameters.Add("@supplier", MySqlDbType.VarChar).Value = txtsupplier.Text;

                        da.UpdateCommand.ExecuteNonQuery();

                        MessageBox.Show("Successfully Updated User " + txtfirstname.Text + ".", "User Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
    }
        private void NameExist()
        {
            MySqlConnection connection = new MySqlConnection(cn);
            MySqlCommand cmd;
            connection.Open();
            try
            {
                cmd = connection.CreateCommand();
                cmd.CommandText = "Select Lastname from supplier where Lastname = @lastname";
                cmd.Parameters.AddWithValue("@lastname", txtlastname.Text);
                MySqlDataReader ProductExist = cmd.ExecuteReader();


                if (ProductExist.HasRows)
                {
                   MessageBox.Show("Username " + txtlastname.Text + " Exist Already.", "Username Exist", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
        private void removeaudit()
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
                cmd.Parameters.AddWithValue("@Access", "The Administrator removed supplier'" + txtlastname.Text + "'");

                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                MetroFramework.MetroMessageBox.Show(this, ex.Message);
            }
        }

        private void bunifuThinButton25_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = new MySqlConnection(cn);
            MySqlDataAdapter da = new MySqlDataAdapter();
            connection.Open();
            DialogResult dg = MessageBox.Show("Are you sure you want to Remove this Supplier?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dg == DialogResult.Yes)
            {
                try
                {
                    // int userdetailsID = Convert.ToInt32(txtID.Text);
                    da.DeleteCommand = new MySqlCommand("delete from supplier where Supplier_id=" + txtID.Text + ";", connection);


                    da.DeleteCommand.ExecuteNonQuery();

                    MessageBox.Show("Successfully Deleted Supplier", "Supplier Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    removeaudit();
                    show();

                }
                catch (Exception)
                {
                    MessageBox.Show("Please Select Supplier to Delete", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Lastname")
            {
                MySqlConnection connection = new MySqlConnection(cn);
                DataTable dt = new DataTable();
                string sql = "Select * from supplier WHERE Lastname LIKE '%" + txtsearch.Text + "%'";
                MySqlDataAdapter da = new MySqlDataAdapter(sql, connection);
                da.Fill(dt);
                metroGrid1.DataSource = dt;
            }
            else if (comboBox1.Text == "Supplier Company")
            {
                MySqlConnection connection = new MySqlConnection(cn);
                DataTable dt = new DataTable();
                string sql = "Select * from supplier WHERE suppliercompany LIKE '%" + txtsearch.Text + "%'";
                MySqlDataAdapter da = new MySqlDataAdapter(sql, connection);
                da.Fill(dt);
                metroGrid1.DataSource = dt;
            }
            else if (comboBox1.Text == "Firstname")
            {
                MySqlConnection connection = new MySqlConnection(cn);
                DataTable dt = new DataTable();
                string sql = "Select * from supplier WHERE Firstname LIKE '%" + txtsearch.Text + "%'";
                MySqlDataAdapter da = new MySqlDataAdapter(sql, connection);
                da.Fill(dt);
                metroGrid1.DataSource = dt;
            }
            else if (comboBox1.Text == "Address")
            {
                MySqlConnection connection = new MySqlConnection(cn);
                DataTable dt = new DataTable();
                string sql = "Select * from supplier WHERE Address LIKE '%" + txtsearch.Text + "%'";
                MySqlDataAdapter da = new MySqlDataAdapter(sql, connection);
                da.Fill(dt);
                metroGrid1.DataSource = dt;
            }
            else if (comboBox1.Text == "ContactNo")
            {
                MySqlConnection connection = new MySqlConnection(cn);
                DataTable dt = new DataTable();
                string sql = "Select * from supplier WHERE ContactNo LIKE '%" + txtsearch.Text + "%'";
                MySqlDataAdapter da = new MySqlDataAdapter(sql, connection);
                da.Fill(dt);
                metroGrid1.DataSource = dt;
            }
            else if (comboBox1.Text == "Productname")
            {
                MySqlConnection connection = new MySqlConnection(cn);
                DataTable dt = new DataTable();
                string sql = "Select * from supplier WHERE ProductName LIKE '%" + txtsearch.Text + "%'";
                MySqlDataAdapter da = new MySqlDataAdapter(sql, connection);
                da.Fill(dt);
                metroGrid1.DataSource = dt;
            }
            else if (comboBox1.Text == "Category")
            {
                MySqlConnection connection = new MySqlConnection(cn);
                DataTable dt = new DataTable();
                string sql = "Select * from supplier WHERE Category LIKE '%" + txtsearch.Text + "%'";
                MySqlDataAdapter da = new MySqlDataAdapter(sql, connection);
                da.Fill(dt);
                metroGrid1.DataSource = dt;
            }
            else if (comboBox1.Text == "Quantity")
            {
                MySqlConnection connection = new MySqlConnection(cn);
                DataTable dt = new DataTable();
                string sql = "Select * from supplier WHERE Quantity LIKE '%" + txtsearch.Text + "%'";
                MySqlDataAdapter da = new MySqlDataAdapter(sql, connection);
                da.Fill(dt);
                metroGrid1.DataSource = dt;
            }
            else if (comboBox1.Text == "City")
            {
                MySqlConnection connection = new MySqlConnection(cn);
                DataTable dt = new DataTable();
                string sql = "Select * from supplier WHERE city LIKE '%" + txtsearch.Text + "%'";
                MySqlDataAdapter da = new MySqlDataAdapter(sql, connection);
                da.Fill(dt);
                metroGrid1.DataSource = dt;
            }
        }

        private void txtlastname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsSymbol(e.KeyChar) ||
              char.IsPunctuation(e.KeyChar) || char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
                errorProvider1.SetError(txtcontact, "Characters Only!!!");
                this.errorProvider1.SetIconPadding(this.txtcontact, -20);
            }
        }

        private void txtfirstname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsSymbol(e.KeyChar) ||
              char.IsPunctuation(e.KeyChar) || char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
                errorProvider1.SetError(txtcontact, "Characters Only!!!");
                this.errorProvider1.SetIconPadding(this.txtcontact, -20);
            }
        }

        private void txtaddress_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsSymbol(e.KeyChar) ||
              char.IsPunctuation(e.KeyChar))
            {
                e.Handled = true;
                errorProvider1.SetError(txtaddress, "Characters Only!!!");
                this.errorProvider1.SetIconPadding(this.txtaddress, -20);
            }
        }

        private void txtcontact_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) ||
                char.IsPunctuation(e.KeyChar) ||
                char.IsSymbol(e.KeyChar))
            {

                e.Handled = true;
                errorProvider1.SetError(txtcontact, "Digits Only!!!");
                this.errorProvider1.SetIconPadding(this.txtcontact, -20);
            }
        }

        private void txttotal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) ||
                char.IsPunctuation(e.KeyChar) ||
                char.IsSymbol(e.KeyChar))
            {

                e.Handled = true;
                errorProvider1.SetError(txtcontact, "Digits Only!!!");
                this.errorProvider1.SetIconPadding(this.txtcontact, -20);
            }
        }

        private void txtquantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) ||
                char.IsPunctuation(e.KeyChar) ||
                char.IsSymbol(e.KeyChar))
            {

                e.Handled = true;
                errorProvider1.SetError(txtcontact, "Digits Only!!!");
                this.errorProvider1.SetIconPadding(this.txtcontact, -20);
            }
        }
        private void orderaudit()
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
                cmd.Parameters.AddWithValue("@Access", "The Administrator order'" + txtsupplier.Text + "' to '" + txtlastname.Text + "'");

                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                MetroFramework.MetroMessageBox.Show(this, ex.Message);
            }
        }
        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = new MySqlConnection(cn);
            MySqlCommand cmd;
            connection.Open();
            if (txtlastname.Text == "")
            {
                errorProvider1.SetError(txtlastname, "Pls Input Lastname");
                this.errorProvider1.SetIconPadding(this.txtlastname, -20);
            }
            else
            {
                errorProvider1.SetError(txtlastname, "");
            }
            if (txtfirstname.Text == "")
            {
                errorProvider1.SetError(txtfirstname, "Pls Input Firstname");
                this.errorProvider1.SetIconPadding(this.txtfirstname, -20);
            }
            else
            {
                errorProvider1.SetError(txtfirstname, "");
            }
            if (txtcontact.Text == "")
            {
                errorProvider1.SetError(txtcontact, "Pls Input ContactNo");
                this.errorProvider1.SetIconPadding(this.txtcontact, -20);
            }
            else
            {
                errorProvider1.SetError(txtcontact, "");
            }
            if (txtaddress.Text == "")
            {
                errorProvider1.SetError(txtaddress, "Pls Input Address");
                this.errorProvider1.SetIconPadding(this.txtaddress, -20);
            }
            else
            {
                errorProvider1.SetError(txtaddress, "");
            }
            
            if (txtCity.Text == "")
            {
                errorProvider1.SetError(txtCity, "Pls select city");
                this.errorProvider1.SetIconPadding(this.txtCity, -20);
            }
            else
            {
                errorProvider1.SetError(txtCity, "");
            }
            if (txtsupplier.Text == "")
            {
                errorProvider1.SetError(txtsupplier, "Pls input supplier");
                this.errorProvider1.SetIconPadding(this.txtsupplier, -20);
            }
            else
            {
                errorProvider1.SetError(txtsupplier, "");
            }
            if (txtlastname.Text != "" && txtfirstname.Text != "" && txtcontact.Text != "" && txtaddress.Text != ""  && txtCity.Text != "" && txtsupplier.Text != "")
            {
                try
                {
                    cmd = connection.CreateCommand();
                    cmd.CommandText = "INSERT INTO orders(Supplier_id,Lastname, Firstname, ContactNo,Address,Productname,Category,Quantity,city,suppliercompany) VALUES (@ID,@Lastname,@Firstname,@Contact,@Address,@Product,@Category,@Quantity,@city,@supplier)";
                    cmd.Parameters.AddWithValue("@ID", null);
                    cmd.Parameters.AddWithValue("@Lastname", txtlastname.Text);
                    cmd.Parameters.AddWithValue("@Firstname", txtfirstname.Text);
                    cmd.Parameters.AddWithValue("@Contact", txtcontact.Text);
                    cmd.Parameters.AddWithValue("@Address", txtaddress.Text);
                    cmd.Parameters.AddWithValue("@city", txtCity.Text);
                    cmd.Parameters.AddWithValue("@supplier", txtsupplier.Text);
                    cmd.ExecuteNonQuery();

                    if (connection.State == ConnectionState.Open)
                    {
                        connection.Close();
                        var a = MessageBox.Show("Are you sure you want to order?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (a == DialogResult.Yes)
                        {
                            MessageBox.Show("Order Sent to" + txtlastname.Text + ".", "Order", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            orderaudit();
                            reset();
                        }


                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void Label8_Click(object sender, EventArgs e)
        {

        }

        private void metroGrid1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            string time = DateTime.Now.ToLongTimeString();
            lblTime.Text = time;
        }

        private void txtsupplier_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();
        }

        private void txtlastname_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();
        }

        private void txtfirstname_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();
        }

        private void txtcontact_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();
        }

        private void txtaddress_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();
        }

        private void txtCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();
        }

        private void txtproduct_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();
        }

        private void cmbcategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();
        }

        private void txtquantity_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();
        }
    }
}