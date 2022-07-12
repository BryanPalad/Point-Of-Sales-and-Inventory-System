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
    public partial class SupplierProduct : MetroForm
    {
        string cn = "Server=localhost;Database=dbpos;Uid=root;Pwd= " + "" + ";";
        public SupplierProduct()
        {
            InitializeComponent();
        }

        private void SupplierProduct_Load(object sender, EventArgs e)
        {
            show();
            getproduct();
            inventory();

        }
        private void inventory()
        {

        }
        private void getproduct()
        {
            MySqlConnection connection = new MySqlConnection(cn);
            connection.Open();
            try
            {
                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT * FROM `addproduct` ";
                MySqlDataAdapter adap = new MySqlDataAdapter(cmd);
                DataTable ds = new DataTable();
                adap.Fill(ds);
                metroGrid2.DataSource = ds;
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
        private void show()
        {
            MySqlConnection connection = new MySqlConnection(cn);
            connection.Open();
            try
            {
                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT * FROM `supplier` where Status='Active'";
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
        private void metroGrid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void metroGrid2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void metroGrid1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtID.Text = metroGrid1.CurrentRow.Cells["Supplier_id"].Value.ToString();
            txtsupplier.Text = metroGrid1.CurrentRow.Cells["suppliercompany"].Value.ToString();
            txtcontact.Text = metroGrid1.CurrentRow.Cells["ContactNo"].Value.ToString();
        }
        private void reset()
        {
            txtpno.ResetText();
            txtproduct.ResetText();
            txtcategory.ResetText();
            txtunit.ResetText();
            txtenter.ResetText();
        }
        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void txtsupplier_TextChanged(object sender, EventArgs e)
        {

        }

        private void metroGrid2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtproduct.Text = metroGrid2.CurrentRow.Cells["Productname"].Value.ToString();
            txtcategory.Text = metroGrid2.CurrentRow.Cells["Category"].Value.ToString();
            txtunit.Text = metroGrid2.CurrentRow.Cells["Units"].Value.ToString();
            txtpno.Text = metroGrid2.CurrentRow.Cells["ProductNo"].Value.ToString();

            if (txtunit.Text == "Kilo")
            {
                label6.Text = "Quantity per Kilo :";
            }
            else if (txtunit.Text == "Piece")
            {
                label6.Text = "Quantity per Piece :";
            }
            else if (txtunit.Text == "Gallon")
            {
                label6.Text = "Quantity per Gallon :";
            }
            else if (txtunit.Text == "Sack")
            {
                label6.Text = "Quantity per Sack :";
            }
        }
        private void deleteproduct()
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(cn);
                MySqlDataAdapter da = new MySqlDataAdapter();
                connection.Open();
                da.DeleteCommand = new MySqlCommand("delete from addproduct where Productname ='" + txtproduct.Text + "'", connection);
                da.DeleteCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnadd_Click(object sender, EventArgs e)
        {

            MySqlConnection connection = new MySqlConnection(cn);
            MySqlCommand cmd;
            connection.Open();

            if (string.IsNullOrEmpty(txtsupplier.Text))
            {
                MessageBox.Show("Please select supplier first", "Important", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (string.IsNullOrEmpty(txtproduct.Text))
            {
                MessageBox.Show("Please select product first", "Important", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (string.IsNullOrEmpty(txtnum.Text))
            {
                MessageBox.Show("Please input P.O Number first", "Important", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (string.IsNullOrEmpty(txtenter.Text))
            {
                MessageBox.Show("Please enter quantity first", "Important", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                var a = MessageBox.Show("Are you sure you want to add to supplier?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (a == DialogResult.Yes)
                {
                    try
                    {
                        cmd = connection.CreateCommand();
                        cmd.CommandText = "INSERT INTO supplierproduct (Supplier_id,suppliercompany,Productno,Productname,Category,Units,Quantity,contact,po) VALUES (@id,@supplier,@productno,@productname,@category,@units,@quantity,@contact,@po)";
                        cmd.Parameters.AddWithValue("@id", txtID.Text);
                        cmd.Parameters.AddWithValue("@supplier", txtsupplier.Text);
                        cmd.Parameters.AddWithValue("@productno", txtpno.Text);
                        cmd.Parameters.AddWithValue("@productname", txtproduct.Text);
                        cmd.Parameters.AddWithValue("@category", txtcategory.Text);
                        cmd.Parameters.AddWithValue("@units", txtunit.Text);
                        cmd.Parameters.AddWithValue("@quantity", txtenter.Text);
                        cmd.Parameters.AddWithValue("@contact", txtcontact.Text);
                        cmd.Parameters.AddWithValue("@po", txtnum.Text);

                        cmd.ExecuteNonQuery();

                        if (connection.State == ConnectionState.Open)
                        {
                            connection.Close();
                            MessageBox.Show("Successful", "Supplier Added", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            deleteproduct();
                            getproduct();
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
        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            txtsupplier.ResetText();
            txtID.ResetText();
            txtproduct.ResetText();
            txtcategory.ResetText();
            txtunit.ResetText();
            txtenter.ResetText();
            txtpno.ResetText();
            txtnum.ResetText();
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
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
            else if (comboBox1.Text == "Address")
            {
                MySqlConnection connection = new MySqlConnection(cn);
                DataTable dt = new DataTable();
                string sql = "Select * from supplier WHERE Address LIKE '%" + txtsearch.Text + "%'";
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
            else if (comboBox1.Text == "Contactno")
            {
                MySqlConnection connection = new MySqlConnection(cn);
                DataTable dt = new DataTable();
                string sql = "Select * from supplier WHERE ContactNo LIKE '%" + txtsearch.Text + "%'";
                MySqlDataAdapter da = new MySqlDataAdapter(sql, connection);
                da.Fill(dt);
                metroGrid1.DataSource = dt;
            }

        }

        private void txtsearch1_TextChanged(object sender, EventArgs e)
        {
            if (comboBox2.Text == "ProductName")
            {
                MySqlConnection connection = new MySqlConnection(cn);
                DataTable dt = new DataTable();
                string sql = "Select * from addproduct WHERE Productname LIKE '%" + txtsearch1.Text + "%'";
                MySqlDataAdapter da = new MySqlDataAdapter(sql, connection);
                da.Fill(dt);
                metroGrid2.DataSource = dt;
            }
            else if (comboBox2.Text == "Category")
            {
                MySqlConnection connection = new MySqlConnection(cn);
                DataTable dt = new DataTable();
                string sql = "Select * from addproduct WHERE Category LIKE '%" + txtsearch1.Text + "%'";
                MySqlDataAdapter da = new MySqlDataAdapter(sql, connection);
                da.Fill(dt);
                metroGrid2.DataSource = dt;
            }
            else if (comboBox2.Text == "Units")
            {
                MySqlConnection connection = new MySqlConnection(cn);
                DataTable dt = new DataTable();
                string sql = "Select * from addproduct WHERE Units LIKE '%" + txtsearch1.Text + "%'";
                MySqlDataAdapter da = new MySqlDataAdapter(sql, connection);
                da.Fill(dt);
                metroGrid2.DataSource = dt;
            }

        }

        private void metroGrid3_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtsearch2_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        private void txtenter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) ||
               char.IsPunctuation(e.KeyChar) ||
               char.IsSymbol(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtnum_KeyPress(object sender, KeyPressEventArgs e)
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