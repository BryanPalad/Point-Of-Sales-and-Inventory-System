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
using DGVPrinterHelper;

namespace Southern_Sky
{
    public partial class ORDERSTOCKS : MetroForm
    {
        string cn = "Server=localhost;Database=dbpos;Uid=root;Pwd= " + "" + ";";
        public ORDERSTOCKS()
        {
            InitializeComponent();
        }

        private void ORDERSTOCKS_Load(object sender, EventArgs e)
        {
            show();
            show1();
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
        private void show1()
        {
            MySqlConnection connection = new MySqlConnection(cn);
            connection.Open();
            try
            {
                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT ProductNo,ProductName,Category,Quantity,Units from product";
                MySqlDataAdapter adap = new MySqlDataAdapter(cmd);
                DataTable ds = new DataTable();
                adap.Fill(ds);
                metroGrid3.DataSource = ds;
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

        private void txtsearch2_TextChanged(object sender, EventArgs e)
        {
            if (comboBox3.Text == "Productname")
            {
                MySqlConnection connection = new MySqlConnection(cn);
                DataTable dt = new DataTable();
                string sql = "Select * from product WHERE ProductName LIKE '%" + txtsearch2.Text + "%'";
                MySqlDataAdapter da = new MySqlDataAdapter(sql, connection);
                da.Fill(dt);
                metroGrid3.DataSource = dt;
            }
            else if (comboBox3.Text == "Category")
            {
                MySqlConnection connection = new MySqlConnection(cn);
                DataTable dt = new DataTable();
                string sql = "Select * from product WHERE Category LIKE '%" + txtsearch2.Text + "%'";
                MySqlDataAdapter da = new MySqlDataAdapter(sql, connection);
                da.Fill(dt);
                metroGrid3.DataSource = dt;
            }
            else if (comboBox3.Text == "Units")
            {
                MySqlConnection connection = new MySqlConnection(cn);
                DataTable dt = new DataTable();
                string sql = "Select * from product WHERE Units LIKE '%" + txtsearch2.Text + "%'";
                MySqlDataAdapter da = new MySqlDataAdapter(sql, connection);
                da.Fill(dt);
                metroGrid3.DataSource = dt;
            }
            else if (comboBox3.Text == "Quantity")
            {
                MySqlConnection connection = new MySqlConnection(cn);
                DataTable dt = new DataTable();
                string sql = "Select * from product WHERE Quantity LIKE '%" + txtsearch2.Text + "%'";
                MySqlDataAdapter da = new MySqlDataAdapter(sql, connection);
                da.Fill(dt);
                metroGrid3.DataSource = dt;
            }
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

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void metroGrid1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtID.Text = metroGrid1.CurrentRow.Cells["Supplier_id"].Value.ToString();
            txtsupplier.Text = metroGrid1.CurrentRow.Cells["suppliercompany"].Value.ToString();
        }

        private void metroGrid3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtproduct.Text = metroGrid3.CurrentRow.Cells["ProductName"].Value.ToString();
            txtcategory.Text = metroGrid3.CurrentRow.Cells["Category"].Value.ToString();
            txtunit.Text = metroGrid3.CurrentRow.Cells["Units"].Value.ToString();
            txtpno.Text = metroGrid3.CurrentRow.Cells["Productno"].Value.ToString();

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

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            txtID.ResetText();
            txtsupplier.ResetText();
            txtproduct.ResetText();
            txtcategory.ResetText();
            txtunit.ResetText();
            txtenter.ResetText();
            txtpno.ResetText();
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
            else if(string.IsNullOrEmpty(txtpno.Text))
            {
                MessageBox.Show("Please select product first", "Important", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (string.IsNullOrEmpty(txtenter.Text))
            {
                MessageBox.Show("Please enter quantity first", "Important", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                var a = MessageBox.Show("Are you sure you want to order stocks?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (a == DialogResult.Yes)
                {

                    try
                    {
                        cmd = connection.CreateCommand();
                        cmd.CommandText = "INSERT INTO backorder (Supplier_id,suppliercompany,Productno,Productname,Category,Units,Quantity) VALUES (@id,@supplier,@productno,@productname,@category,@units,@quantity)";
                        cmd.Parameters.AddWithValue("@id", txtID.Text);
                        cmd.Parameters.AddWithValue("@supplier", txtsupplier.Text);
                        cmd.Parameters.AddWithValue("@productno", txtpno.Text);
                        cmd.Parameters.AddWithValue("@productname", txtproduct.Text);
                        cmd.Parameters.AddWithValue("@category", txtcategory.Text);
                        cmd.Parameters.AddWithValue("@units", txtunit.Text);
                        cmd.Parameters.AddWithValue("@quantity", txtenter.Text);

                        cmd.ExecuteNonQuery();

                        if (connection.State == ConnectionState.Open)
                        {
                            connection.Close();
                            MessageBox.Show("Successful", "Stocks Ordered", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    txtID.ResetText();
                                    txtsupplier.ResetText();
                                    txtpno.ResetText();
                                    txtproduct.ResetText();
                                    txtcategory.ResetText();
                                    txtunit.ResetText();
                                    txtenter.ResetText();
                                }
                            }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);

                    }
                }
            }
        }

        private void bunifuThinButton25_Click(object sender, EventArgs e)
        {
           
        }
        private void printdatagridview()
        {

        }
    }
}