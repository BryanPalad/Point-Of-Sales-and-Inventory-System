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
    public partial class Add_Supplier : MetroForm
    {
        string cn = "Server=localhost;Database=dbpos;Uid=root;Pwd= " + "" + ";";
        public string username = LOGIN.Username;
        public Add_Supplier()
        {
            InitializeComponent();
        }
        private void addaudit()
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
                cmd.Parameters.AddWithValue("@Access", "The Administrator added supplier'" + txtsupplier.Text + "'");

                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                MetroFramework.MetroMessageBox.Show(this, ex.Message);
            }
        }
        private void reset()
        {
            errorProvider1.Clear();
            txtfirstname.Text = "";
            txtlastname.Text = "";
            txtaddress.Text = "";
            txtcontact.Text = "";
            txtCity.SelectedIndex = -1;
            txtsupplier.Text = "";
            txtStatus.Text = "";
            txtID.Text = "";


        }
        private void supplierexist()
        {
            MySqlConnection connection = new MySqlConnection(cn);
            MySqlCommand cmd;
            connection.Open();
            try
            {
                cmd = connection.CreateCommand();
                cmd.CommandText = "Select * from supplier where suppliercompany = @supplier";
                cmd.Parameters.AddWithValue("@supplier", txtsupplier.Text);
                MySqlDataReader Username = cmd.ExecuteReader();

                if (Username.HasRows)
                {

                    MessageBox.Show("Supplier " + txtsupplier.Text + " already exist .", "Supplier Exist", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    addsupplier();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void addsupplier()
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
                errorProvider1.SetError(txtsupplier, "Pls Input Supplier");
                this.errorProvider1.SetIconPadding(this.txtsupplier, -20);
            }
            else
            {
                errorProvider1.SetError(txtsupplier, "");
            }
            if (txtlastname.Text != "" && txtfirstname.Text != "" && txtcontact.Text != "" && txtaddress.Text != "" && txtCity.Text != "" && txtsupplier.Text != "")
            {
                try
                {
                    cmd = connection.CreateCommand();
                    cmd.CommandText = "INSERT INTO supplier(Supplier_id,Lastname, Firstname, ContactNo,Address,city,suppliercompany,Status) VALUES (@ID,@Lastname,@Firstname,@Contact,@Address,@city,@supplier,'Active')";
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
                        var a = MessageBox.Show("Are you sure you want to add this supplier?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (a == DialogResult.Yes)
                        {
                            addaudit();
                            MessageBox.Show("Successfully Added Supplier " + txtlastname.Text + ".", "User Added", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            randomnumbers();
                            reset();
                            show();
                        }


                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private void btnadd_Click(object sender, EventArgs e)
        {
            supplierexist();
        }
        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void randomnumbers()
        {
            var randomNumbers = new List<int>();
            var randomGenerator = new Random();
            int initialCount = 1;

            for (int i = 0; i <= 5; i++)
            {
                while (initialCount <= 5)
                {
                    int num = randomGenerator.Next(1000, 999999);
                    if (!randomNumbers.Contains(num))
                    {
                        randomNumbers.Add(num);
                        initialCount++;
                    }
                }
            }
            randomNumbers.Sort();
            randomNumbers.ForEach(x => txtID.Text = x.ToString());
        }
        private void btnclear_Click(object sender, EventArgs e)
        {
            txtlastname.ResetText();
            txtfirstname.ResetText();
            txtaddress.ResetText();
            txtcontact.ResetText();
            txtStatus.ResetText();
            txtCity.SelectedIndex = -1;
            txtsupplier.ResetText();

        }

        private void Add_Supplier_Load(object sender, EventArgs e)
        {
            getcategory();
            show();
            txtuser.Text = username;
        }
        private void show()
        {
            MySqlConnection connection = new MySqlConnection(cn);
            connection.Open();
            try
            {
                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT * FROM `supplier` ";
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
        private void getcategory()
        {

        }

        private void metroGrid1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtsupplier.Text = metroGrid1.CurrentRow.Cells["suppliercompany"].Value.ToString();
            txtlastname.Text = metroGrid1.CurrentRow.Cells["Lastname"].Value.ToString();
            txtfirstname.Text = metroGrid1.CurrentRow.Cells["Firstname"].Value.ToString();
            txtaddress.Text = metroGrid1.CurrentRow.Cells["Address"].Value.ToString();
            txtcontact.Text = metroGrid1.CurrentRow.Cells["ContactNo"].Value.ToString();
            txtCity.Text = metroGrid1.CurrentRow.Cells["city"].Value.ToString();
            txtStatus.Text = metroGrid1.CurrentRow.Cells["Status"].Value.ToString();
            txtID.Text = metroGrid1.CurrentRow.Cells["Supplier_id"].Value.ToString();

        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtlastname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) ||
                char.IsSymbol(e.KeyChar) ||
                char.IsPunctuation(e.KeyChar))
                e.Handled = true;
        }

        private void txtfirstname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) ||
                char.IsSymbol(e.KeyChar) ||
                char.IsPunctuation(e.KeyChar))
                e.Handled = true;
        }

        private void txtaddress_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsSymbol(e.KeyChar) ||
                char.IsPunctuation(e.KeyChar))
                e.Handled = true;
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

            }
        }

        private void txtaddress_TextChanged(object sender, EventArgs e)
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

        private void txtCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();
        }

        private void txtproduct_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtquantity_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();
        }

        private void txtsupplier_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void btnarchive_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtsupplier.Text))
            {
                MessageBox.Show("Please select user account", "Important", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else
            {
                if (txtStatus.Text == "Active")
                {
                    MySqlConnection connection = new MySqlConnection(cn);
                    MySqlCommand cmd;
                    connection.Open();
                    DialogResult dg = MessageBox.Show("Are you sure you want to change to inactive this supplier info?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dg == DialogResult.Yes)
                    {
                        try
                        {
                            // int userdetailsID = Convert.ToInt32(txtID.Text);\
                            cmd = connection.CreateCommand();
                            cmd.CommandText = "update supplier set Status='Inactive' where Supplier_id='" + txtID.Text + "'";

                            cmd.ExecuteNonQuery();

                            MessageBox.Show("Successfully Updated supplier " + txtsupplier.Text + " to Inactive.", "Supplier Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            show();
                            reset();

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
                else if (txtStatus.Text == "Inactive")
                {

                    MySqlConnection connection = new MySqlConnection(cn);
                    MySqlCommand cmd;
                    connection.Open();
                    DialogResult dg = MessageBox.Show("Are you sure you want to change to active this supplier info?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dg == DialogResult.Yes)
                    {
                        try
                        {
                            // int userdetailsID = Convert.ToInt32(txtID.Text);
                            cmd = connection.CreateCommand();
                            cmd.CommandText = "update supplier set Status='Active' where Supplier_id='" + txtID.Text + "'";

                            cmd.ExecuteNonQuery();

                            MessageBox.Show("Successfully Updated Supplier " + txtsupplier.Text + " to Active.", "Supplier Returned", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            show();
                            reset();

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
            }
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            updatesupplier();
        }
        private void checksupplier()
        {
          
        }
        private void updatesupplier()
        {
            MySqlConnection connection = new MySqlConnection(cn);
            MySqlDataAdapter da = new MySqlDataAdapter();
            connection.Open();

            if (string.IsNullOrEmpty(txtID.Text))
            {
                MessageBox.Show("Please Select Supplier to Update", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (txtcontact.Text == "")
            {
                errorProvider1.SetError(txtcontact, "required");
                this.errorProvider1.SetIconPadding(this.txtcontact, -20);
            }
            else
            {
                errorProvider1.SetError(txtcontact, "");
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
            if (txtCity.Text == "")
            {
                errorProvider1.SetError(txtCity, "required");
                this.errorProvider1.SetIconPadding(this.txtCity, -20);
            }
            else
            {
                errorProvider1.SetError(txtCity, "");
            }
            if (txtsupplier.Text != "" && txtlastname.Text != "" && txtfirstname.Text != "" && txtaddress.Text != "" && txtCity.Text != "" && txtcontact.Text != "")
            {
                DialogResult dg = MessageBox.Show("Are you sure you want to Edit?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dg == DialogResult.Yes)
                {
                    try
                    {
                        da.UpdateCommand = new MySqlCommand("update supplier set Lastname=@Lastname,Firstname=@Firstname,ContactNo=@Contact,Address=@Address,city=@City,suppliercompany=@Supplier where Supplier_id='" + txtID.Text + "';", connection);
                        da.UpdateCommand.Parameters.Add("@Lastname", MySqlDbType.VarChar).Value = txtlastname.Text;
                        da.UpdateCommand.Parameters.Add("@Firstname", MySqlDbType.VarChar).Value = txtfirstname.Text;
                        da.UpdateCommand.Parameters.Add("@Contact", MySqlDbType.VarChar).Value = txtcontact.Text;
                        da.UpdateCommand.Parameters.Add("@Address", MySqlDbType.VarChar).Value = txtaddress.Text;
                        da.UpdateCommand.Parameters.Add("@City", MySqlDbType.VarChar).Value = txtCity.Text;
                        da.UpdateCommand.Parameters.Add("@Supplier", MySqlDbType.VarChar).Value = txtsupplier.Text;
                       
                


                        da.UpdateCommand.ExecuteNonQuery();


                        MessageBox.Show("Successfully Updated Supplier " + txtsupplier.Text + ".", "Supplier Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        show();
                        reset();
                        errorProvider1.Clear();
                        errorProvider1.Clear();
                        errorProvider1.Clear();

                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }


        private void supplierExist()
        {
            
        }

        private void txtsearch_TextChanged_1(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Supplier Company")
            {
                MySqlConnection connection = new MySqlConnection(cn);
                DataTable dt = new DataTable();
                string sql = "Select * from supplier WHERE suppliercompany LIKE '%" + txtsearch.Text + "%'";
                MySqlDataAdapter da = new MySqlDataAdapter(sql, connection);
                da.Fill(dt);
                metroGrid1.DataSource = dt;
            }
            else if (comboBox1.Text == "Lastname")
            {
                MySqlConnection connection = new MySqlConnection(cn);
                DataTable dt = new DataTable();
                string sql = "Select * from supplier WHERE Lastname LIKE '%" + txtsearch.Text + "%'";
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
            else if (comboBox1.Text == "Contactno")
            {
                MySqlConnection connection = new MySqlConnection(cn);
                DataTable dt = new DataTable();
                string sql = "Select * from supplier WHERE ContactNo LIKE '%" + txtsearch.Text + "%'";
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
            else if (comboBox1.Text == "Status")
            {
                MySqlConnection connection = new MySqlConnection(cn);
                DataTable dt = new DataTable();
                string sql = "Select * from supplier WHERE Status LIKE '%" + txtsearch.Text + "%'";
                MySqlDataAdapter da = new MySqlDataAdapter(sql, connection);
                da.Fill(dt);
                metroGrid1.DataSource = dt;
            }
        }
    }
}