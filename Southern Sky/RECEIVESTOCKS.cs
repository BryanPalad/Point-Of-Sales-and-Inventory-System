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
    public partial class RECEIVESTOCKS : MetroForm
    {
        string cn = "Server=localhost;Database=dbpos;Uid=root;Pwd= " + "" + ";";
        public RECEIVESTOCKS()
        {
            InitializeComponent();
        }
        private void showbackorder()
        {
            MySqlConnection connection = new MySqlConnection(cn);
            connection.Open();
            try
            {
                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT * FROM `backorder` ";
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
        private void receivestock()
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
                cmd.Parameters.AddWithValue("@category", txtcategory.Text);
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
        private void ordereports()
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
                cmd.Parameters.AddWithValue("@category", txtcategory.Text);
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
            if (string.IsNullOrEmpty(txtproduct.Text))
            {
                MessageBox.Show("Please select order/s", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (string.IsNullOrEmpty(txtget.Text))
            {
                MessageBox.Show("Please input quantity", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (Convert.ToDouble(txtget.Text) >= Convert.ToDouble(txtenter.Text))
            {
                MessageBox.Show("items must be less than the quantity received", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                var a = MessageBox.Show("Are you sure you want to received " + txtget.Text + "" + txtproduct.Text + "?", "Return Items?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (a == DialogResult.Yes)
                {

                    int get = Convert.ToInt32(txtget.Text);
                    int qty = Convert.ToInt32(txtenter.Text);
                    if (qty >= get)
                    {
                        MySqlConnection connection = new MySqlConnection(cn);
                        MySqlDataAdapter da = new MySqlDataAdapter();
                        connection.Open();

                        da.UpdateCommand = new MySqlCommand("UPDATE backorder set Quantity = (Quantity - '" + get + "') where productname = '" + txtproduct.Text + "';", connection);
                        da.UpdateCommand.ExecuteNonQuery();

                        receivestock();
                        MessageBox.Show("Successfully Get Item/s", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ordereports();
                        showbackorder();
                        txtget.ResetText();
                        txtenter.ResetText();
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
                da.DeleteCommand = new MySqlCommand("delete from backorder where Productno ='" + txtpno.Text + "'", connection);
                da.DeleteCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void receiveallstock()
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
                cmd.Parameters.AddWithValue("@category", txtcategory.Text);
                cmd.Parameters.AddWithValue("@quantity", txtenter.Text);

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
        private void ordereports1()
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
                cmd.Parameters.AddWithValue("@category", txtcategory.Text);
                cmd.Parameters.AddWithValue("@quantity", txtenter.Text);

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
        private void truncateorder()
        {
            try
            {


                MySqlConnection connection = new MySqlConnection(cn);
                MySqlDataAdapter da = new MySqlDataAdapter();
                connection.Open();
                da.DeleteCommand = new MySqlCommand("delete from orders where Productno ='" + txtpno.Text + "' or Productname ='" + txtproduct.Text + "'", connection);
                da.DeleteCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtproduct.Text))
            {
                MessageBox.Show("Please select order/s", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                var a = MessageBox.Show("Are you sure you want to get all " + txtproduct.Text + "?", "Get all Items?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (a == DialogResult.Yes)
                {
                    receiveallstock();
                    int qty = Convert.ToInt32(txtenter.Text);

                    MySqlConnection connection = new MySqlConnection(cn);
                    MySqlDataAdapter da = new MySqlDataAdapter();
                    connection.Open();

                    da.UpdateCommand = new MySqlCommand("UPDATE orders set Quantity = (Quantity - '" + qty + "') where productname = '" + txtproduct.Text + "';", connection);
                    da.UpdateCommand.ExecuteNonQuery();



                    MessageBox.Show("Successfully Get all Item/s", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ordereports1();
                    truncate();
                    truncateorder();
                    showbackorder();

                    txtID.ResetText();
                    txtsupplier.ResetText();
                    txtpno.ResetText();
                    txtproduct.ResetText();
                    txtcategory.ResetText();
                    txtunit.ResetText();
                    txtenter.ResetText();
                }
            }
        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            txtID.ResetText();
            txtsupplier.ResetText();
            txtpno.ResetText();
            txtproduct.ResetText();
            txtcategory.ResetText();
            txtunit.ResetText();
            txtenter.ResetText();
        }

        private void RECEIVESTOCKS_Load(object sender, EventArgs e)
        {
            show();
        }
        private void show()
        {
            MySqlConnection connection = new MySqlConnection(cn);
            connection.Open();
            try
            {
                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT * FROM `backorder` ";
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

        private void metroGrid1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtID.Text = metroGrid1.CurrentRow.Cells["Supplier_id"].Value.ToString();
            txtsupplier.Text = metroGrid1.CurrentRow.Cells["suppliercompany"].Value.ToString();
            txtpno.Text = metroGrid1.CurrentRow.Cells["Productno"].Value.ToString();
            txtproduct.Text = metroGrid1.CurrentRow.Cells["Productname"].Value.ToString();
            txtcategory.Text = metroGrid1.CurrentRow.Cells["Category"].Value.ToString();
            txtunit.Text = metroGrid1.CurrentRow.Cells["Units"].Value.ToString();
            txtenter.Text = metroGrid1.CurrentRow.Cells["Quantity"].Value.ToString();
            txtnum.Text = metroGrid1.CurrentRow.Cells["ponumber"].Value.ToString();
            if (txtunit.Text == "Kilo")
            {
                label15.Text = "Quantity per Kilo :";
            }
            else if (txtunit.Text == "Piece")
            {
                label15.Text = "Quantity per Piece :";
            }
            else if (txtunit.Text == "Gallon")
            {
                label15.Text = "Quantity per Gallon :";
            }
            else if (txtunit.Text == "Sack")
            {
                label15.Text = "Quantity per Sack :";
            }
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "P.O Number")
            {
                MySqlConnection connection = new MySqlConnection(cn);
                DataTable dt = new DataTable();
                string sql = "Select * from backorder WHERE ponumber LIKE '%" + textBox1.Text + "%'";
                MySqlDataAdapter da = new MySqlDataAdapter(sql, connection);
                da.Fill(dt);
                metroGrid1.DataSource = dt;
            }
            else if (comboBox1.Text == "Supplier Company")
            {
                MySqlConnection connection = new MySqlConnection(cn);
                DataTable dt = new DataTable();
                string sql = "Select * from backorder WHERE suppliercompany LIKE '%" + textBox1.Text + "%'";
                MySqlDataAdapter da = new MySqlDataAdapter(sql, connection);
                da.Fill(dt);
                metroGrid1.DataSource = dt;
            }
            else if (comboBox1.Text == "Product Name")
            {
                MySqlConnection connection = new MySqlConnection(cn);
                DataTable dt = new DataTable();
                string sql = "Select * from backorder WHERE Productname LIKE '%" + textBox1.Text + "%'";
                MySqlDataAdapter da = new MySqlDataAdapter(sql, connection);
                da.Fill(dt);
                metroGrid1.DataSource = dt;
            }
            else if (comboBox1.Text == "Category")
            {
                MySqlConnection connection = new MySqlConnection(cn);
                DataTable dt = new DataTable();
                string sql = "Select * from backorder WHERE Category LIKE '%" + textBox1.Text + "%'";
                MySqlDataAdapter da = new MySqlDataAdapter(sql, connection);
                da.Fill(dt);
                metroGrid1.DataSource = dt;
            }
            else if (comboBox1.Text == "Units")
            {
                MySqlConnection connection = new MySqlConnection(cn);
                DataTable dt = new DataTable();
                string sql = "Select * from backorder WHERE Units LIKE '%" + textBox1.Text + "%'";
                MySqlDataAdapter da = new MySqlDataAdapter(sql, connection);
                da.Fill(dt);
                metroGrid1.DataSource = dt;
            }
        }

        private void txtget_Click(object sender, EventArgs e)
        {

        }

        private void txtget_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) ||
               char.IsPunctuation(e.KeyChar) ||
               char.IsSymbol(e.KeyChar))
            {
                e.Handled = true;
            }
        
        }
    }
}