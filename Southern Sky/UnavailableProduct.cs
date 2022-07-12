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
    public partial class UnavailableProduct : MetroForm
    {
        string cn = "Server=localhost;Database=dbpos;Uid=root;Pwd=" + "" + ";";
        public string username = LOGIN.Username;
        public UnavailableProduct()
        {
            InitializeComponent();
        }
        private void audit()
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
                cmd.Parameters.AddWithValue("@Access", "The Administrator available the product'" + txtProductName.Text + "'");

                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                MetroFramework.MetroMessageBox.Show(this, ex.Message);
            }
        }

        private void btnactive_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtProductNo.Text))
            {
                MessageBox.Show("Please select product to unavailable.", "Important", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                available();
            }
        }
        private void available()
        {
            MySqlConnection connection = new MySqlConnection(cn);
            MySqlCommand cmd;
            connection.Open();
            DialogResult dg = MessageBox.Show("Are you sure you want to available this Product '" + txtProductName.Text + "'?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dg == DialogResult.Yes)
            {
                try
                {
                    cmd = connection.CreateCommand();
                    cmd.CommandText = "Insert into product(ProductNo,ProductName,Category,SellingPrice,Quantity,CriticalLevel1,CriticalLevel2,Units,Ceiling) select ProductNo,ProductName,Category,SellingPrice,Quantity,CriticalLevel1,CriticalLevel2,Units,Ceiling from unavailable where ProductNo = @ProductNo and ProductName = @ProductName";
                    cmd.Parameters.AddWithValue("@ProductNo", txtProductNo.Text);
                    cmd.Parameters.AddWithValue("@ProductName", txtProductName.Text);

                    cmd.ExecuteNonQuery();
                    if (connection.State == ConnectionState.Open)
                    {
                        audit();
                        connection.Close();
                        remove();
                        show();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private void remove()
        {
            MySqlConnection connection = new MySqlConnection(cn);
            MySqlDataAdapter da = new MySqlDataAdapter();
            connection.Open();
            try
            {
                // int userdetailsID = Convert.ToInt32(txtID.Text);
                da.DeleteCommand = new MySqlCommand("delete from unavailable where ProductNo=" + txtProductNo.Text + ";", connection);


                da.DeleteCommand.ExecuteNonQuery();

                MessageBox.Show("Successfully Available this Product " + txtProductName.Text + ".", "Product Available", MessageBoxButtons.OK, MessageBoxIcon.Information);
                show();
                reset();

            }
            catch (Exception)
            {
               MessageBox.Show("Please Select Product to Remove", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UnavailableProduct_Load(object sender, EventArgs e)
        {
            txtuser.Text = username;
            show();
        }
        private void show()
        {
            MySqlConnection connection = new MySqlConnection(cn);
            connection.Open();
            try
            {
                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT ProductNo,ProductName,Category FROM `unavailable` order by productname ";
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
        private void reset()
        {
            txtCategory.ResetText();
            txtProductName.ResetText();
            txtProductNo.ResetText();
        }
        private void keydown(object sender, KeyEventArgs e)
        {
            if (e.Control == true)
            {
                MessageBox.Show("Cut/Copy and Paste Option is Disabled", "Disabled");
            }
        }

        private void mousedown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                MessageBox.Show("Right Clicked is Disabled", "Disabled");
            }
        }

        private void metroGrid1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtProductNo.Text = metroGrid1.CurrentRow.Cells["ProductNo"].Value.ToString();
            txtProductName.Text = metroGrid1.CurrentRow.Cells["ProductName"].Value.ToString();
            txtCategory.Text = metroGrid1.CurrentRow.Cells["Category"].Value.ToString();
        }

        private void btnsearch_Click(object sender, EventArgs e)
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
            try
            {
                MySqlConnection connection = new MySqlConnection(cn);
                DataTable dt = new DataTable();
                string sql = "Select * from product WHERE ProductName LIKE '%" + txtsearch.Text + "%' or Category LIKE '%" + txtsearch.Text + "%' or ProductNo  LIKE '%" + txtsearch.Text + "%'";
                MySqlDataAdapter da = new MySqlDataAdapter(sql, connection);
                da.Fill(dt);
                metroGrid1.DataSource = dt;
            }
            catch (Exception)
            {
                MessageBox.Show("Test");
            }
        }

        private void metroGrid1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            txtProductNo.Text = metroGrid1.CurrentRow.Cells["ProductNo"].Value.ToString();
            txtProductName.Text = metroGrid1.CurrentRow.Cells["ProductName"].Value.ToString();
            txtCategory.Text = metroGrid1.CurrentRow.Cells["Category"].Value.ToString();
        }

        private void txtsearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsSymbol(e.KeyChar) ||
               char.IsPunctuation(e.KeyChar))
                e.Handled = true;
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
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
