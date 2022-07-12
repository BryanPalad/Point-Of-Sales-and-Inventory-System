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
    public partial class StockIn : MetroForm
    {
        string cn = "Server=localhost;Database=dbpos;Uid=root;Pwd=" + "" + ";";
        public string username = LOGIN.Username;
        public StockIn()
        {
            InitializeComponent();
        }
        private void stocksaudit()
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
                cmd.Parameters.AddWithValue("@Access", "The Administrator add stocks in product'" + lblProductName.Text + "'");

                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                MetroFramework.MetroMessageBox.Show(this, ex.Message);
            }
        }
        private void getstocks()
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(cn);
                MySqlDataAdapter da = new MySqlDataAdapter();
                connection.Open();
                da.DeleteCommand = new MySqlCommand("delete from stock where ID ='" + txtID.Text + "'", connection);
                da.DeleteCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void updatestock()
        {
            int get = Convert.ToInt32(txtQuantity.Text);
            int qty = Convert.ToInt32(txtenterstock.Text);
            if (qty >= get)
            {
                MySqlConnection connection = new MySqlConnection(cn);
                MySqlDataAdapter da = new MySqlDataAdapter();
                connection.Open();

                da.UpdateCommand = new MySqlCommand("UPDATE stock set Quantity = (Quantity - '" + get + "') where ID = '" + txtID.Text + "';", connection);
                da.UpdateCommand.ExecuteNonQuery();
            }
        }
        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = new MySqlConnection(cn);
            MySqlCommand cmd;
            connection.Open();

            if (txtQuantity.Text == "0" || txtQuantity.Text == "00" || txtQuantity.Text == "000" || txtQuantity.Text == "0000" || txtQuantity.Text == "00000" || txtQuantity.Text == "000000" || txtQuantity.Text == "0000000" || txtQuantity.Text == "00000000" || txtQuantity.Text == "000000000" || txtQuantity.Text == "000000000" || txtQuantity.Text == "0000000000" || txtQuantity.Text == "0000000000" || txtQuantity.Text == "000000000000")
            {
                MessageBox.Show("Please input valid quantity", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (string.IsNullOrEmpty(txtQuantity.Text))
            {
                MessageBox.Show("Please enter quantity of stocks", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (string.IsNullOrEmpty(txtQuantity.Text) && string.IsNullOrEmpty(lblTotalStocks.Text))
            {
                MessageBox.Show("Please enter quantity.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else if (Convert.ToDouble(txtceiling.Text) < Convert.ToDouble(lblTotalStocks.Text))
            {
                MessageBox.Show("Quantity must be less than Ceilling Point.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                txtQuantity.Text = "";
            }
            else if (Convert.ToDouble(txtq.Text) == Convert.ToDouble(txtenterstock.Text))
            {
                addstock();
                getstocks();
                this.Close();
            }
            else
            {
                try
                {
                    cmd = connection.CreateCommand();
                    cmd.CommandText = "Insert into stockin (stockin_id,ProductName,Quantity,Category,Date) values (@Stock,@ProductName,@Quantity,@Category,'" + System.DateTime.Now.ToString("yyyy/MM/dd") + "')";
                    cmd.Parameters.AddWithValue("@Stock", null);
                    cmd.Parameters.AddWithValue("@ProductName", lblProductName.Text);
                    cmd.Parameters.AddWithValue("@Category", lblCategory.Text);
                    cmd.Parameters.AddWithValue("@Quantity", txtQuantity.Text);

                    cmd.ExecuteNonQuery();
                    if (connection.State == ConnectionState.Open)
                    {
                        updatestock();
                        stocksaudit();
                        connection.Close();
                        addstock();
                        showstocks();
                        txtenterstock.ResetText();
                        txtQuantity.ResetText();
                        txtq.ResetText();
                        this.Close();
                    }
                   
                   
                }
                catch (Exception)
                {
                    MessageBox.Show("Okay");
                }
            }
        }
        private void addstock()
        {
            MySqlConnection connection = new MySqlConnection(cn);
            MySqlDataAdapter da = new MySqlDataAdapter();
            connection.Open();
            DialogResult dg =MessageBox.Show("Are you sure you want to stock in?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dg == DialogResult.Yes)
            {
                try
                {
                    da.UpdateCommand = new MySqlCommand("update product set Quantity=@Quantity,CriticalLevel1=@Level1,CriticalLevel2=@Level2 where ProductNo=" + txtProductNo.Text + ";", connection);
                    da.UpdateCommand.Parameters.Add("@Quantity", MySqlDbType.VarChar).Value = lblTotalStocks.Text;
                    da.UpdateCommand.Parameters.Add("@Level1", MySqlDbType.VarChar).Value = txtCriticalLevel1.Text;
                    da.UpdateCommand.Parameters.Add("@Level2", MySqlDbType.VarChar).Value = txtCriticalLevel2.Text;

                    da.UpdateCommand.ExecuteNonQuery();

                    MessageBox.Show("Stock in Added '" + txtQuantity.Text + "' to " + lblProductName.Text + " Complete.", "Stock In", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // reset();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private void showstocks()
        {
            MySqlConnection connection = new MySqlConnection(cn);
            connection.Open();
            try
            {
                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT * FROM stock where Productname = '"+lblProductName.Text+ "'";
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

        private void StockIn_Load(object sender, EventArgs e)
        {
            showstocks();
            txtuser.Text = username;
            showpercentage();


            //try
            //{
            //    txtFSI1.Text = metroGrid1.CurrentRow.Cells["FSI1"].Value.ToString();
            //    txtFSI2.Text = metroGrid1.CurrentRow.Cells["FSI2"].Value.ToString();
            //    txtSSI1.Text = metroGrid1.CurrentRow.Cells["SSI1"].Value.ToString();
            //    txtSSI2.Text = metroGrid1.CurrentRow.Cells["SSI2"].Value.ToString();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
            //if (lblFSIorSSI.Text == "Fast Selling Item")
            //{
            //    label12.Text = "" + txtFSI1.Text + "%";
            //    label11.Text = "" + txtFSI2.Text + "%";
            //}
            //if (lblFSIorSSI.Text == "Slow Selling Item")
            //{
            //    label12.Text = "" + txtSSI1.Text + "%";
            //    label11.Text = "" + txtSSI2.Text + "%";
            //}
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
                metroGrid1.DataSource = ds;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtQuantity.Text))
                {
                    int a, b, c;
                    a = Convert.ToInt32(txtStocks.Text);
                    b = Convert.ToInt32(txtQuantity.Text);
                    c = a + b;
                    lblTotalStocks.Text = Convert.ToString(c);
                }
                else
                {
                    lblTotalStocks.Text = "";
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Stock Limit", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) ||
               char.IsSymbol(e.KeyChar) ||
               char.IsWhiteSpace(e.KeyChar) ||
               char.IsPunctuation(e.KeyChar))
                e.Handled = true;
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void product()
        {
            MySqlConnection connection = new MySqlConnection(cn);
            MySqlCommand cmd;
            connection.Open();
            try
            {
                cmd = connection.CreateCommand();
                cmd.CommandText = "Insert into product(ProductName,Category,UnitPrice,Quantity,CriticalLevel1,CriticalLevel2,FSIorSSI) select ProductName,Category,UnitPrice,Quantity,CriticalLevel1,CriticalLevel2,FSIorSSI from stockout where stockout_id = @Stock";
                cmd.Parameters.AddWithValue("@Stock", txtProductNo.Text);

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
       // private void FSIorSSI()
       // {
       //      if (lblFSIorSSI.Text == "Fast Selling Item")
       //    {
       //        try
       //        {
       //            if (!string.IsNullOrEmpty(lblTotalStocks.Text))
       //            {
       //                double FSI1 = Convert.ToInt32(txtFSI1.Text);
       //                double qty = Convert.ToInt32(lblTotalStocks.Text);
       //                double percenttotal;
       //                percenttotal = (qty / 100) * FSI1;
       //                txtCriticalLevel1.Text = Convert.ToString(percenttotal);
       //            }
       //            if (!string.IsNullOrEmpty(lblTotalStocks.Text))
       //            {
       //                double FSI2 = Convert.ToInt32(txtFSI2.Text);
       //                double qty = Convert.ToInt32(lblTotalStocks.Text);
       //                double percenttotal;
       //                percenttotal = (qty / 100) * FSI2;
       //                txtCriticalLevel2.Text = Convert.ToString(percenttotal);
       //            }
       //            else
       //            {
       //                txtCriticalLevel1.Text = "";
       //                txtCriticalLevel2.Text = "";
       //            }
       //        }
       //        catch (Exception ex)
       //        {
       //            MessageBox.Show(ex.Message);
       //        }
       //    }
       //    if (lblFSIorSSI.Text == "Slow Selling Item")
       //    {
       //        try
       //        {
       //            if (!string.IsNullOrEmpty(lblTotalStocks.Text))
       //            {
       //                double SSI1 = Convert.ToInt32(txtSSI1.Text);
       //                double qty = Convert.ToInt32(lblTotalStocks.Text);
       //                double percenttotal;
       //                percenttotal = (qty / 100) * SSI1;
       //                txtCriticalLevel1.Text = Convert.ToString(percenttotal);
       //            }
       //            if (!string.IsNullOrEmpty(lblTotalStocks.Text))
       //            {
       //                double SSI2 = Convert.ToInt32(txtSSI2.Text);
       //                double qty = Convert.ToInt32(lblTotalStocks.Text);
       //                double percenttotal;
       //                percenttotal = (qty / 100) * SSI2;
       //                txtCriticalLevel2.Text = Convert.ToString(percenttotal);
       //            }
       //            else
       //            {
       //                txtCriticalLevel1.Text = "";
       //                txtCriticalLevel2.Text = "";
       //            }
       //        }
       //        catch (Exception ex)
       //        {
       //            MessageBox.Show(ex.Message);
       //        }
       //    }
       //}

        //private void lblTotalStocks_TextChanged(object sender, EventArgs e)
        //{
        //    FSIorSSI();
        //}
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

        private void Label6_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            string time = DateTime.Now.ToLongTimeString();
            lblTime.Text = time;
        }

        private void metroGrid2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtq.Text = metroGrid2.CurrentRow.Cells["Quantity"].Value.ToString();
            txtID.Text = metroGrid2.CurrentRow.Cells["ID"].Value.ToString();
        }

        private void bunifuThinButton24_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtenterstock.Text))
            {
                MessageBox.Show("Please Enter Stock First", "Important", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if(Convert.ToDouble(txtq.Text) < Convert.ToDouble(txtenterstock.Text))
            {
                MessageBox.Show("Stock must be less than or equal to quantity", "Error",MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                txtQuantity.Text = txtenterstock.Text;
                double pepe = Convert.ToDouble(txtenterstock.Text);
                double pepenialdrin = Convert.ToDouble(txtStocks.Text);
                double totalpepe = pepenialdrin + pepe;
                lblTotalStocks.Text = totalpepe.ToString();

                double qty = Convert.ToInt32(lblTotalStocks.Text);
                double percenttotal;
                percenttotal = (qty / 100) * 50;
                txtCriticalLevel1.Text = Convert.ToString(percenttotal);

                double bb = Convert.ToInt32(lblTotalStocks.Text);
                double percent;
                percent = (qty / 100) * 20;
                txtCriticalLevel2.Text = Convert.ToString(percent);


            }
            
        }
        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            metroGrid2.Enabled = true;
            txtenterstock.Enabled = true;
        }

        private void txtceiling_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuThinButton23_Click_1(object sender, EventArgs e)
        {

        }

    }
}
