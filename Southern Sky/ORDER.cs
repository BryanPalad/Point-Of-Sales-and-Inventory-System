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
    public partial class ORDER : MetroForm
    {
        string cn = "Server=localhost;Database=dbpos;Uid=root;Pwd= " + "" + ";";
        public string username = LOGIN.Username;
        public ORDER()
        {
            InitializeComponent();
        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void metroGrid1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtlastname.Text = metroGrid1.CurrentRow.Cells["Lastname"].Value.ToString();
            txtfirstname.Text = metroGrid1.CurrentRow.Cells["Firstname"].Value.ToString();
            txtaddress.Text = metroGrid1.CurrentRow.Cells["Address"].Value.ToString();
            txtcontact.Text = metroGrid1.CurrentRow.Cells["ContactNo"].Value.ToString();
            txtproduct.Text = metroGrid1.CurrentRow.Cells["Productname"].Value.ToString();
            cmbcategory.Text = metroGrid1.CurrentRow.Cells["Category"].Value.ToString();
            txtquantity.Text = metroGrid1.CurrentRow.Cells["Quantity"].Value.ToString();
            txtCity.Text = metroGrid1.CurrentRow.Cells["city"].Value.ToString();
            txtsupplier.Text = metroGrid1.CurrentRow.Cells["suppliercompany"].Value.ToString();
        }

        private void ORDER_Load(object sender, EventArgs e)
        {
            txtuser.Text = username;
            show1();
        }
        private void show1()
        {
            MySqlConnection connection = new MySqlConnection(cn);
            connection.Open();
            try
            {
                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT * FROM `orders` ";
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

        private void btnclear_Click(object sender, EventArgs e)
        {
            txtlastname.ResetText();
            txtfirstname.ResetText();
            txtaddress.ResetText();
            txtcontact.ResetText();
            txtproduct.ResetText();
            txtquantity.ResetText();
            cmbcategory.ResetText();
            txtCity.SelectedIndex = -1;
            txtsupplier.ResetText();
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "ProductName")
            {
                MySqlConnection connection = new MySqlConnection(cn);
                DataTable dt = new DataTable();
                string sql = "Select * from orders WHERE Productname LIKE '%" + txtsearch.Text + "%'";
                MySqlDataAdapter da = new MySqlDataAdapter(sql, connection);
                da.Fill(dt);
                metroGrid1.DataSource = dt;
            }
            else if (comboBox1.Text == "Category")
            {
                MySqlConnection connection = new MySqlConnection(cn);
                DataTable dt = new DataTable();
                string sql = "Select * from orders WHERE Category LIKE '%" + txtsearch.Text + "%'";
                MySqlDataAdapter da = new MySqlDataAdapter(sql, connection);
                da.Fill(dt);
                metroGrid1.DataSource = dt;
            }
            else if (comboBox1.Text == "Quantity")
            {
                MySqlConnection connection = new MySqlConnection(cn);
                DataTable dt = new DataTable();
                string sql = "Select * from orders WHERE Quantity LIKE '%" + txtsearch.Text + "%'";
                MySqlDataAdapter da = new MySqlDataAdapter(sql, connection);
                da.Fill(dt);
                metroGrid1.DataSource = dt;
            }
        }

        private void metroGrid1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            txtlastname.Text = metroGrid1.CurrentRow.Cells["Lastname"].Value.ToString();
            txtfirstname.Text = metroGrid1.CurrentRow.Cells["Firstname"].Value.ToString();
            txtaddress.Text = metroGrid1.CurrentRow.Cells["Address"].Value.ToString();
            txtcontact.Text = metroGrid1.CurrentRow.Cells["ContactNo"].Value.ToString();
            txtproduct.Text = metroGrid1.CurrentRow.Cells["Productname"].Value.ToString();
            cmbcategory.Text = metroGrid1.CurrentRow.Cells["Category"].Value.ToString();
            txtquantity.Text = metroGrid1.CurrentRow.Cells["Quantity"].Value.ToString();
            txtCity.Text = metroGrid1.CurrentRow.Cells["city"].Value.ToString();
            txtsupplier.Text = metroGrid1.CurrentRow.Cells["suppliercompany"].Value.ToString();
        }

        private void metroGrid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        public void ordereports1()
        {
            MySqlConnection connection = new MySqlConnection(cn);
            MySqlCommand cmd;
            connection.Open();
            try
            {

                cmd = connection.CreateCommand();
                cmd.CommandText = "INSERT INTO ordereports(Date,suppliercompany,Productname,Category,QuantityReceived)  values(@date,@supplier,@product,@category,@quantity)";
                cmd.Parameters.AddWithValue("@date", System.DateTime.Now.ToString("yyyy/MM/dd"));
                cmd.Parameters.AddWithValue("@supplier", txtsupplier.Text);
                cmd.Parameters.AddWithValue("@product", txtproduct.Text);
                cmd.Parameters.AddWithValue("@category", cmbcategory.Text);
                cmd.Parameters.AddWithValue("@quantity", txtquantity.Text);

                cmd.ExecuteNonQuery();
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void ordereports()
        {
            MySqlConnection connection = new MySqlConnection(cn);
            MySqlCommand cmd;
            connection.Open();
            try
            {

                cmd = connection.CreateCommand();
                cmd.CommandText = "INSERT INTO ordereports(Date,suppliercompany,Productname,Category,QuantityReceived)  values(@date,@supplier,@product,@category,@quantity)";
                cmd.Parameters.AddWithValue("@date", System.DateTime.Now.ToString("yyyy/MM/dd"));
                cmd.Parameters.AddWithValue("@supplier", txtsupplier.Text);
                cmd.Parameters.AddWithValue("@product", txtproduct.Text);
                cmd.Parameters.AddWithValue("@category", cmbcategory.Text);
                cmd.Parameters.AddWithValue("@quantity", txtget.Text);

                cmd.ExecuteNonQuery();
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void receiveallstock()
        {
            MySqlConnection connection = new MySqlConnection(cn);
            MySqlCommand cmd;
            connection.Open();
            try
            {

                cmd = connection.CreateCommand();
                cmd.CommandText = "INSERT INTO stock(ID,Productname,Category,Quantity)values(@id,@product,@category,@quantity)";
                cmd.Parameters.AddWithValue("@id", null);
                cmd.Parameters.AddWithValue("@product", txtproduct.Text);
                cmd.Parameters.AddWithValue("@category", cmbcategory.Text);
                cmd.Parameters.AddWithValue("@quantity", txtquantity.Text);

                cmd.ExecuteNonQuery();
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void receivestock()
        {

            MySqlConnection connection = new MySqlConnection(cn);
            MySqlCommand cmd;
            connection.Open();
            try
            {

                cmd = connection.CreateCommand();
                cmd.CommandText = "INSERT INTO stock(ID,Productname,Category,Quantity)values(@id,@product,@category,@quantity)";
                cmd.Parameters.AddWithValue("@id",null);
                cmd.Parameters.AddWithValue("@product", txtproduct.Text);
                cmd.Parameters.AddWithValue("@category", cmbcategory.Text);
                cmd.Parameters.AddWithValue("@quantity", txtget.Text);

                cmd.ExecuteNonQuery();
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtproduct.Text) || string.IsNullOrEmpty(cmbcategory.Text))
            {
               MessageBox.Show("Please select order/s", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if(string.IsNullOrEmpty(txtget.Text))
            {
                MessageBox.Show("Please input quantity", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (Convert.ToDouble(txtget.Text) >= Convert.ToDouble(txtquantity.Text))
            {
                MessageBox.Show("items must be less than the quantity received", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                var a = MessageBox.Show("Are you sure you want to received " + txtget.Text + "" + txtproduct.Text + "?", "Return Items?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (a == DialogResult.Yes)
                {
                    receiveaudit();
                    
                    int get = Convert.ToInt32(txtget.Text);
                    int qty = Convert.ToInt32(txtquantity.Text);
                    if (qty >= get)
                    {
                        MySqlConnection connection = new MySqlConnection(cn);
                        MySqlDataAdapter da = new MySqlDataAdapter();
                        connection.Open();

                        da.UpdateCommand = new MySqlCommand("UPDATE orders set Quantity = (Quantity - '" + get + "') where productname = '" + txtproduct.Text + "';", connection);
                        da.UpdateCommand.ExecuteNonQuery();

                        receivestock();
                        ordereports();
                        MessageBox.Show("Successfully Get Item/s", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        show1();
                        txtget.ResetText();        
                    }
                }
            }
        }
        private void truncate()
        {
            try
            {


                MySqlConnection connection = new MySqlConnection(cn);
                MySqlDataAdapter da = new MySqlDataAdapter();
                connection.Open();
                da.DeleteCommand = new MySqlCommand("delete from orders where Lastname ='" + txtlastname.Text + "'", connection);
                da.DeleteCommand.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            
            if (string.IsNullOrEmpty(txtproduct.Text) || string.IsNullOrEmpty(cmbcategory.Text))
            {
               MessageBox.Show("Please select order/s", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                var a = MessageBox.Show("Are you sure you want to get all " + txtproduct.Text + "?", "Get all Items?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (a == DialogResult.Yes)
                {
                    receiveallstock();
                    receiveallaudit();
                    int qty = Convert.ToInt32(txtquantity.Text);
          
                        MySqlConnection connection = new MySqlConnection(cn);
                        MySqlDataAdapter da = new MySqlDataAdapter();
                        connection.Open();

                        da.UpdateCommand = new MySqlCommand("UPDATE orders set Quantity = (Quantity - '" + qty + "') where productname = '" + txtproduct.Text + "';", connection);
                        da.UpdateCommand.ExecuteNonQuery();
                       

                        
                        MessageBox.Show("Successfully Get all Item/s", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        truncate();
                        ordereports1();
                        show1();
                        txtlastname.ResetText();
                        txtfirstname.ResetText();
                        txtaddress.ResetText();
                        txtcontact.ResetText();
                        txtproduct.ResetText();
                        txtquantity.ResetText();
                        cmbcategory.ResetText();
                        txtCity.SelectedIndex = -1;
                        txtsupplier.ResetText();
                            
                    }
                }
            }
        private void receiveallaudit()
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
                cmd.Parameters.AddWithValue("@Access", "The Administrator get all items from'" + txtsupplier.Text + "'");

                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                MetroFramework.MetroMessageBox.Show(this, ex.Message);
            }
        }
        private void receiveaudit()
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
                cmd.Parameters.AddWithValue("@Access", "The Administrator get items from'" + txtsupplier.Text + "'");

                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                MetroFramework.MetroMessageBox.Show(this, ex.Message);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            string time = DateTime.Now.ToLongTimeString();
            lblTime.Text = time;
        }

        private void txtuser_Click(object sender, EventArgs e)
        {

        }

        private void lblTime_Click(object sender, EventArgs e)
        {

        }
        }
    }