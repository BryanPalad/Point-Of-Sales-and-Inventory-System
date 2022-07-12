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
using System.Text.RegularExpressions;

namespace Southern_Sky
{
    public partial class ModifyProduct : MetroForm
    {
        string cn = "Server=localhost;Database=dbpos;Uid=root;Pwd=" + "" + ";"; 
        public string username = LOGIN.Username;

        public ModifyProduct()
        {
            InitializeComponent();
        }
        private void getcategory()
        {
            MySqlConnection connection = new MySqlConnection(cn);
            MySqlCommand cmd = new MySqlCommand("SELECT Category FROM  categories;");
            cmd.CommandType = CommandType.Text;
            cmd.Connection = connection;
            cmd.Connection = connection;
            connection.Open();


            try
            {
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {

                    cmbCategory.Items.Add(dr.GetString("Category"));
                }
                dr.Close();
            }
            catch (Exception a)
            {
                MessageBox.Show(a.Message);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();

                }
            }
        }
        private void btnadd_Click(object sender, EventArgs e)
        {
           
            addtheproduct();
            }
        private void addtheproduct()
        {
            MySqlConnection connection = new MySqlConnection(cn);
            MySqlCommand cmd;
            connection.Open();


            if (string.IsNullOrEmpty(txtProductNo.Text))
            {
                MessageBox.Show("Please select product first before you add.", "Important", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (Convert.ToDouble(txtceiling.Text) < Convert.ToDouble(txtQuantity.Text))
            {
                MessageBox.Show("Quantity must be less than Ceilling Point.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else if (string.IsNullOrEmpty(txtsellingprice.Text))
            {
                MessageBox.Show("Please add mark up or select 100% if you don't want to add.", "Important", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtUnitPrice.Text == "0" || txtUnitPrice.Text == "00" || txtUnitPrice.Text == "000" || txtUnitPrice.Text == "0000" || txtUnitPrice.Text == "00000" || txtUnitPrice.Text == "000000" || txtUnitPrice.Text == "0000000" || txtUnitPrice.Text == "00000000" || txtUnitPrice.Text == "000000000" || txtUnitPrice.Text == "000000000" || txtUnitPrice.Text == "0000000000" || txtUnitPrice.Text == "00000000000")
            {
                MessageBox.Show("Please input valid price", "Important", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtUnitPrice.Text == "0." || txtUnitPrice.Text == "00." || txtUnitPrice.Text == "000." || txtUnitPrice.Text == "0000." || txtUnitPrice.Text == "00000." || txtUnitPrice.Text == "000000." || txtUnitPrice.Text == "0000000." || txtUnitPrice.Text == "00000000." || txtUnitPrice.Text == "000000000." || txtUnitPrice.Text == "000000000." || txtUnitPrice.Text == "0000000000." || txtUnitPrice.Text == "00000000000.")
            {
                MessageBox.Show("Please input valid price", "Important", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtUnitPrice.Text == "0.0" || txtUnitPrice.Text == "00.0" || txtUnitPrice.Text == "000.0" || txtUnitPrice.Text == "0000.0" || txtUnitPrice.Text == "00000.0" || txtUnitPrice.Text == "000000.0" || txtUnitPrice.Text == "0000000.0" || txtUnitPrice.Text == "00000000.0" || txtUnitPrice.Text == "000000000.0" || txtUnitPrice.Text == "000000000.0" || txtUnitPrice.Text == "0000000000.0" || txtUnitPrice.Text == "00000000000.0")
            {
                MessageBox.Show("Please input valid price", "Important", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtUnitPrice.Text == "0.00" || txtUnitPrice.Text == "00.00" || txtUnitPrice.Text == "000.00" || txtUnitPrice.Text == "0000.00" || txtUnitPrice.Text == "00000.00" || txtUnitPrice.Text == "000000.00" || txtUnitPrice.Text == "0000000.00" || txtUnitPrice.Text == "00000000.00" || txtUnitPrice.Text == "000000000.00" || txtUnitPrice.Text == "000000000.00" || txtUnitPrice.Text == "0000000000.00" || txtUnitPrice.Text == "00000000000.00")
            {
                MessageBox.Show("Please input valid price", "Important", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtQuantity.Text == "0" || txtQuantity.Text == "00" || txtQuantity.Text == "000" || txtQuantity.Text == "0000" || txtQuantity.Text == "00000" || txtQuantity.Text == "000000" || txtQuantity.Text == "0000000" || txtQuantity.Text == "00000000" || txtQuantity.Text == "000000000" || txtQuantity.Text == "000000000" || txtQuantity.Text == "0000000000" || txtQuantity.Text == "0000000000" || txtQuantity.Text == "000000000000")
            {
                MessageBox.Show("Please input valid quantity", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
            else if (string.IsNullOrEmpty(txtQuantity.Text) || string.IsNullOrEmpty(txtUnitPrice.Text))
            {
                MessageBox.Show("Please fill the product information", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult dg = MessageBox.Show("Are you sure you want to add this product '" + txtProductName.Text + "' in Product Inventory?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dg == DialogResult.Yes)
                {
                    try
                    {
                        cmd = connection.CreateCommand();
                        cmd.CommandText = "Insert into product(ProductNo,ProductName,Category,SellingPrice,Quantity,CriticalLevel1,CriticalLevel2,Units,Ceiling) select ProductNo,ProductName,Category,@SellingPrice,@Quantity,@CriticalLevel1,@CriticalLevel2,@Units,@Ceiling from modify where ProductNo = @ProductNo and ProductName = @ProductName";
                        cmd.Parameters.AddWithValue("@ProductNo", txtProductNo.Text);
                        cmd.Parameters.AddWithValue("@ProductName", txtProductName.Text);
                        cmd.Parameters.AddWithValue("@SellingPrice", txtsellingprice.Text);
                        cmd.Parameters.AddWithValue("@Quantity", txtQuantity.Text);
                        cmd.Parameters.AddWithValue("@CriticalLevel1", txtCriticalLevel1.Text);
                        cmd.Parameters.AddWithValue("@CriticalLevel2", txtCriticalLevel2.Text);
                        cmd.Parameters.AddWithValue("@Units", txtunit.Text);
                        cmd.Parameters.AddWithValue("@Ceiling", txtceiling.Text);

                        cmd.ExecuteNonQuery();
                        if (connection.State == ConnectionState.Open)
                        {
                            connection.Close();
                            addaudit();
                            remove();
                            show();

                            reset();
                            txtUnitPrice.Enabled = false;
                            txtQuantity.Enabled = false;
                            txtCriticalLevel1.ResetText();
                            txtCriticalLevel2.ResetText();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
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
                da.DeleteCommand = new MySqlCommand("delete from modify where ProductNo=" + txtProductNo.Text + ";", connection);


                da.DeleteCommand.ExecuteNonQuery();

                MessageBox.Show("Successfully Added to Product Invetory this Product " + txtProductName.Text + ".", "Product Available", MessageBoxButtons.OK, MessageBoxIcon.Information);
                show();
                reset();
                txtUnitPrice.Enabled = false;
                txtQuantity.Enabled = false;
                txtCriticalLevel1.ResetText();
                txtCriticalLevel2.ResetText();

            }
            catch (Exception)
            {
                MessageBox.Show("Please Select Product to Add in Product Inventory.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void show()
        {
            MySqlConnection connection = new MySqlConnection(cn);
            connection.Open();
            try
            {
                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT * FROM `modify` order by productname ";
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
            txtProductNo.ResetText();
            txtProductName.ResetText();
            txtQuantity.ResetText();
            txtUnitPrice.ResetText();
            txtCategory.ResetText();
            txtunit.ResetText();
            cmbmarkup.SelectedIndex = -1;
            txtceiling.ResetText();
        }

        private void metroGrid1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            reset();
            txtsellingprice.ResetText();
            cmbmarkup.Enabled = true;
            txtUnitPrice.Enabled = true;
            bunifuCheckbox1.Checked = false;
            txtQuantity.Enabled = false;
            cmbmarkup.SelectedIndex = -1;
            txtProductNo.Text = metroGrid1.CurrentRow.Cells["ProductNo"].Value.ToString();
            txtProductName.Text = metroGrid1.CurrentRow.Cells["ProductName"].Value.ToString();
            txtCategory.Text = metroGrid1.CurrentRow.Cells["Category"].Value.ToString();
            txtunit.Text = metroGrid1.CurrentRow.Cells["Units"].Value.ToString();
            txtQuantity.Text = metroGrid1.CurrentRow.Cells["Quantity"].Value.ToString();
         
            if (txtunit.Text == "Kilo")
            {
                Label8.Text = "Quantity per Kilo :";
            }
            else if (txtunit.Text == "Piece")
            {
                Label8.Text = "Quantity per Piece :";
            }
            else if (txtunit.Text == "Gallon")
            {
                Label8.Text = "Quantity per Gallon :";
            }
            else if (txtunit.Text == "Sack")
            {
                Label8.Text = "Quantity per Sack :";
            }
               if (!string.IsNullOrEmpty(txtQuantity.Text))
                            {
                                double qty = Convert.ToInt32(txtQuantity.Text);
                                double percenttotal;
                                percenttotal = (qty / 100) * 50;
                                txtCriticalLevel1.Text = Convert.ToString(percenttotal);
                            }
               if (!string.IsNullOrEmpty(txtQuantity.Text))
               {

                   
                   double qty = Convert.ToInt32(txtQuantity.Text);
                   double percenttotal;
                   percenttotal = (qty / 100) * 20;
                   txtCriticalLevel2.Text = Convert.ToString(percenttotal);

               }
               else
               {
                   txtCriticalLevel1.Text = "";
                   txtCriticalLevel2.Text = "";
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

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        //private void txtQuantity_TextChanged(object sender, EventArgs e)
        //{
        //        FSIorSSI();
        //    }
        
        //private void FSIorSSI()
        //{
               
        //    if (cmbSellingItems.SelectedIndex == 0)
        //    {
        //        try
        //        {
        //            if (!string.IsNullOrEmpty(txtQuantity.Text))
        //            {
        //                double FSI1 = Convert.ToInt32(txtFSI1.Text);
        //                double qty = Convert.ToInt32(txtQuantity.Text);
        //                double percenttotal;
        //                percenttotal = (qty / 100) * FSI1;
        //                txtCriticalLevel1.Text = Convert.ToString(percenttotal);
        //            }
        //            if (!string.IsNullOrEmpty(txtQuantity.Text))
        //            {

        //                double FSI2 = Convert.ToInt32(txtFSI2.Text);
        //                double qty = Convert.ToInt32(txtQuantity.Text);
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
        //    if (cmbSellingItems.SelectedIndex == 1)
        //    {
        //        try
        //        {
        //            if (!string.IsNullOrEmpty(txtQuantity.Text))
        //            {
        //                double SSI1 = Convert.ToInt32(txtSSI1.Text);
        //                double qty = Convert.ToInt32(txtQuantity.Text);
        //                double percenttotal;
        //                percenttotal = (qty / 100) * SSI1;
        //                txtCriticalLevel1.Text = Convert.ToString(percenttotal);
        //            }
        //            if (!string.IsNullOrEmpty(txtQuantity.Text))
        //            {
        //                double SSI2 = Convert.ToInt32(txtSSI2.Text);
        //                double qty = Convert.ToInt32(txtQuantity.Text);
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

        private void bunifuCheckbox1_OnChange(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtProductNo.Text))
            {
                MessageBox.Show("Please select product first", "Important", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                bunifuCheckbox1.Checked = false;
            }
            else if (string.IsNullOrEmpty(txtUnitPrice.Text))
            {
                MessageBox.Show("Please input valid unit price", "Important", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                bunifuCheckbox1.Checked = false;
            }
            else if (txtUnitPrice.Text == "0" || txtUnitPrice.Text == "00" || txtUnitPrice.Text == "000" || txtUnitPrice.Text == "0000" || txtUnitPrice.Text == "00000" || txtUnitPrice.Text == "000000" || txtUnitPrice.Text == "0000000" || txtUnitPrice.Text == "00000000" || txtUnitPrice.Text == "000000000" || txtUnitPrice.Text == "000000000" || txtUnitPrice.Text == "0000000000" || txtUnitPrice.Text == "00000000000")
            {
                MessageBox.Show("Please input valid price", "Important", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                bunifuCheckbox1.Checked = false;
            }
            else if (txtUnitPrice.Text == "0." || txtUnitPrice.Text == "00." || txtUnitPrice.Text == "000." || txtUnitPrice.Text == "0000." || txtUnitPrice.Text == "00000." || txtUnitPrice.Text == "000000." || txtUnitPrice.Text == "0000000." || txtUnitPrice.Text == "00000000." || txtUnitPrice.Text == "000000000." || txtUnitPrice.Text == "000000000." || txtUnitPrice.Text == "0000000000." || txtUnitPrice.Text == "00000000000.")
            {
                MessageBox.Show("Please input valid price", "Important", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                bunifuCheckbox1.Checked = false;
            }
            else if (txtUnitPrice.Text == "0.0" || txtUnitPrice.Text == "00.0" || txtUnitPrice.Text == "000.0" || txtUnitPrice.Text == "0000.0" || txtUnitPrice.Text == "00000.0" || txtUnitPrice.Text == "000000.0" || txtUnitPrice.Text == "0000000.0" || txtUnitPrice.Text == "00000000.0" || txtUnitPrice.Text == "000000000.0" || txtUnitPrice.Text == "000000000.0" || txtUnitPrice.Text == "0000000000.0" || txtUnitPrice.Text == "00000000000.0")
            {
                MessageBox.Show("Please input valid price", "Important", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                bunifuCheckbox1.Checked = false;
            }
            else if (txtUnitPrice.Text == "0.00" || txtUnitPrice.Text == "00.00" || txtUnitPrice.Text == "000.00" || txtUnitPrice.Text == "0000.00" || txtUnitPrice.Text == "00000.00" || txtUnitPrice.Text == "000000.00" || txtUnitPrice.Text == "0000000.00" || txtUnitPrice.Text == "00000000.00" || txtUnitPrice.Text == "000000000.00" || txtUnitPrice.Text == "000000000.00" || txtUnitPrice.Text == "0000000000.00" || txtUnitPrice.Text == "00000000000.00")
            {
                MessageBox.Show("Please input valid price", "Important", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                bunifuCheckbox1.Checked = false;
            }
            else if (string.IsNullOrEmpty(txtsellingprice.Text))
            {
                MessageBox.Show("Add mark up first", "Important", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                bunifuCheckbox1.Checked = false;
            }
            else
            {
                if (bunifuCheckbox1.Checked == true)
                {
                    txtUnitPrice.Enabled = false;
                    decimal testing = Convert.ToDecimal(txtUnitPrice.Text);
                    decimal test = Convert.ToDecimal(txtsellingprice.Text);
                    //decimal test = Convert.ToDecimal(lblvat.Text);
                    decimal aa = Convert.ToDecimal(0.12) * test;
                    decimal cc = test + aa;
                    txtsellingprice.Text = Convert.ToString(String.Format("{0:0.00}", cc));


                }
                else if (bunifuCheckbox1.Checked == false)
                {
                    txtsellingprice.ResetText();
                    txtUnitPrice.Enabled = true;
                }
            }
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
                cmd.Parameters.AddWithValue("@Access", "The Administrator modified '" + txtProductName.Text + "'");

                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                MetroFramework.MetroMessageBox.Show(this, ex.Message);
            }
        }
        private void ModifyProduct_Load(object sender, EventArgs e)
        {

            txtuser.Text = username;
            show();
            showpercentage();
            getcategory();

            try
            {
                txtFSI1.Text = metroGrid2.CurrentRow.Cells["FSI1"].Value.ToString();
                txtFSI2.Text = metroGrid2.CurrentRow.Cells["FSI2"].Value.ToString();
                txtSSI1.Text = metroGrid2.CurrentRow.Cells["SSI1"].Value.ToString();
                txtSSI2.Text = metroGrid2.CurrentRow.Cells["SSI2"].Value.ToString();
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
                cmd.Parameters.AddWithValue("@Access", "The Administrator removed'" + txtProductName.Text + "'");

                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                MetroFramework.MetroMessageBox.Show(this, ex.Message);
            }
        }
        private void btnunavailable_Click(object sender, EventArgs e)
        {
            delete();
        }
        private void delete()
        {
            MySqlConnection connection = new MySqlConnection(cn);
            MySqlDataAdapter da = new MySqlDataAdapter();
            connection.Open();
            DialogResult dg = MessageBox.Show("Are you sure you want to remove this product '" + txtProductName.Text + "'?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dg == DialogResult.Yes)
            {
                try
                {
                    // int userdetailsID = Convert.ToInt32(txtID.Text);
                    da.DeleteCommand = new MySqlCommand("delete from modify where ProductNo=" + txtProductNo.Text + ";", connection);


                    da.DeleteCommand.ExecuteNonQuery();

                    MessageBox.Show("Successfully Deleted this Product " + txtProductName.Text + ".", "Product Available", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    removeaudit();
                    show();
                    reset();
                    txtUnitPrice.Enabled = false;
                    txtQuantity.Enabled = false;
                    txtCriticalLevel1.ResetText();
                    txtCriticalLevel2.ResetText();

                }
                catch (Exception)
                {
                    MessageBox.Show("Please Select Product to Delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            bunifuCheckbox1.Checked = false;
            if (string.IsNullOrEmpty(txtProductNo.Text))
            {
                MessageBox.Show("Please select product first", "Important", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbmarkup.Text = "";
            }
            else if (string.IsNullOrEmpty(txtUnitPrice.Text))
            {
                MessageBox.Show("Please input valid unit price", "Important", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbmarkup.Text = "";
            }
            else if (txtUnitPrice.Text == "0" || txtUnitPrice.Text == "00" || txtUnitPrice.Text == "000" || txtUnitPrice.Text == "0000" || txtUnitPrice.Text == "00000" || txtUnitPrice.Text == "000000" || txtUnitPrice.Text == "0000000" || txtUnitPrice.Text == "00000000" || txtUnitPrice.Text == "000000000" || txtUnitPrice.Text == "000000000" || txtUnitPrice.Text == "0000000000" || txtUnitPrice.Text == "00000000000")
            {
                MessageBox.Show("Please input valid price", "Important", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbmarkup.Text = "";
            }
            else if (txtUnitPrice.Text == "0." || txtUnitPrice.Text == "00." || txtUnitPrice.Text == "000." || txtUnitPrice.Text == "0000." || txtUnitPrice.Text == "00000." || txtUnitPrice.Text == "000000." || txtUnitPrice.Text == "0000000." || txtUnitPrice.Text == "00000000." || txtUnitPrice.Text == "000000000." || txtUnitPrice.Text == "000000000." || txtUnitPrice.Text == "0000000000." || txtUnitPrice.Text == "00000000000.")
            {
                MessageBox.Show("Please input valid price", "Important", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbmarkup.Text = "";
            }
            else if (txtUnitPrice.Text == "0.0" || txtUnitPrice.Text == "00.0" || txtUnitPrice.Text == "000.0" || txtUnitPrice.Text == "0000.0" || txtUnitPrice.Text == "00000.0" || txtUnitPrice.Text == "000000.0" || txtUnitPrice.Text == "0000000.0" || txtUnitPrice.Text == "00000000.0" || txtUnitPrice.Text == "000000000.0" || txtUnitPrice.Text == "000000000.0" || txtUnitPrice.Text == "0000000000.0" || txtUnitPrice.Text == "00000000000.0")
            {
                MessageBox.Show("Please input valid price", "Important", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbmarkup.Text = "";
            }
            else if (txtUnitPrice.Text == "0.00" || txtUnitPrice.Text == "00.00" || txtUnitPrice.Text == "000.00" || txtUnitPrice.Text == "0000.00" || txtUnitPrice.Text == "00000.00" || txtUnitPrice.Text == "000000.00" || txtUnitPrice.Text == "0000000.00" || txtUnitPrice.Text == "00000000.00" || txtUnitPrice.Text == "000000000.00" || txtUnitPrice.Text == "000000000.00" || txtUnitPrice.Text == "0000000000.00" || txtUnitPrice.Text == "00000000000.00")
            {
                MessageBox.Show("Please input valid price", "Important", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbmarkup.Text = "";
            }
            else
            {
                if(string.IsNullOrEmpty(cmbmarkup.Text))
                {
                    MessageBox.Show("Please select markup percentage first", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (cmbmarkup.SelectedItem.ToString() == "5%")
                {
                    txtUnitPrice.Enabled = false;
                    decimal testing = Convert.ToDecimal(txtUnitPrice.Text);
                    decimal aa = (Convert.ToDecimal(0.05) * testing) + testing;
                    txtsellingprice.Text = Convert.ToString(String.Format("{0:0.00}", aa));
                }
                else if (cmbmarkup.SelectedItem.ToString() == "10%")
                {
                    txtUnitPrice.Enabled = false;
                    decimal testing = Convert.ToDecimal(txtUnitPrice.Text);
                    decimal aa = (Convert.ToDecimal(0.10) * testing) + testing;
                    txtsellingprice.Text = Convert.ToString(String.Format("{0:0.00}", aa));
                }
                else if (cmbmarkup.SelectedItem.ToString() == "15%")
                {
                    txtUnitPrice.Enabled = false;
                    decimal testing = Convert.ToDecimal(txtUnitPrice.Text);
                    decimal aa = (Convert.ToDecimal(0.15) * testing) + testing;
                    txtsellingprice.Text = Convert.ToString(String.Format("{0:0.00}", aa));
                }
                else if (cmbmarkup.SelectedItem.ToString() == "20%")
                {
                    txtUnitPrice.Enabled = false;
                    decimal testing = Convert.ToDecimal(txtUnitPrice.Text);
                    decimal aa = (Convert.ToDecimal(0.20) * testing) + testing;
                    txtsellingprice.Text = Convert.ToString(String.Format("{0:0.00}", aa));
                }
                else if (cmbmarkup.SelectedItem.ToString() == "25%")
                {
                    txtUnitPrice.Enabled = false;
                    decimal testing = Convert.ToDecimal(txtUnitPrice.Text);
                    decimal aa = (Convert.ToDecimal(0.25) * testing) + testing;
                    txtsellingprice.Text = Convert.ToString(String.Format("{0:0.00}", aa));
                }
                else if (cmbmarkup.SelectedItem.ToString() == "30%")
                {
                    txtUnitPrice.Enabled = false;
                    decimal testing = Convert.ToDecimal(txtUnitPrice.Text);
                    decimal aa = (Convert.ToDecimal(0.30) * testing) + testing;
                    txtsellingprice.Text = Convert.ToString(String.Format("{0:0.00}", aa));
                }
                else if (cmbmarkup.SelectedItem.ToString() == "35%")
                {
                    txtUnitPrice.Enabled = false;
                    decimal testing = Convert.ToDecimal(txtUnitPrice.Text);
                    decimal aa = (Convert.ToDecimal(0.35) * testing) + testing;
                    txtsellingprice.Text = Convert.ToString(String.Format("{0:0.00}", aa));
                }
                else if (cmbmarkup.SelectedItem.ToString() == "40%")
                {
                    txtUnitPrice.Enabled = false;
                    decimal testing = Convert.ToDecimal(txtUnitPrice.Text);
                    decimal aa = (Convert.ToDecimal(0.40) * testing) + testing;
                    txtsellingprice.Text = Convert.ToString(String.Format("{0:0.00}", aa));
                }
                else if (cmbmarkup.SelectedItem.ToString() == "45%")
                {
                    txtUnitPrice.Enabled = false;
                    decimal testing = Convert.ToDecimal(txtUnitPrice.Text);
                    decimal aa = (Convert.ToDecimal(0.45) * testing) + testing;
                    txtsellingprice.Text = Convert.ToString(String.Format("{0:0.00}", aa));
                }
                else if (cmbmarkup.SelectedItem.ToString() == "50%")
                {
                    txtUnitPrice.Enabled = false;
                    decimal testing = Convert.ToDecimal(txtUnitPrice.Text);
                    decimal aa = (Convert.ToDecimal(0.50) * testing) + testing;
                    txtsellingprice.Text = Convert.ToString(String.Format("{0:0.00}", aa));
                }
                else if (cmbmarkup.SelectedItem.ToString() == "55%")
                {
                    txtUnitPrice.Enabled = false;
                    decimal testing = Convert.ToDecimal(txtUnitPrice.Text);
                    decimal aa = (Convert.ToDecimal(0.55) * testing) + testing;
                    txtsellingprice.Text = Convert.ToString(String.Format("{0:0.00}", aa));
                }
                else if (cmbmarkup.SelectedItem.ToString() == "60%")
                {
                    txtUnitPrice.Enabled = false;
                    decimal testing = Convert.ToDecimal(txtUnitPrice.Text);
                    decimal aa = (Convert.ToDecimal(0.60) * testing) + testing;
                    txtsellingprice.Text = Convert.ToString(String.Format("{0:0.00}", aa));
                }
                else if (cmbmarkup.SelectedItem.ToString() == "65%")
                {
                    txtUnitPrice.Enabled = false;
                    decimal testing = Convert.ToDecimal(txtUnitPrice.Text);
                    decimal aa = (Convert.ToDecimal(0.15) * testing) + testing;
                    txtsellingprice.Text = Convert.ToString(String.Format("{0:0.00}", aa));
                }
                else if (cmbmarkup.SelectedItem.ToString() == "70%")
                {
                    txtUnitPrice.Enabled = false;
                    decimal testing = Convert.ToDecimal(txtUnitPrice.Text);
                    decimal aa = (Convert.ToDecimal(0.70) * testing) + testing;
                    txtsellingprice.Text = Convert.ToString(String.Format("{0:0.00}", aa));
                }
                else if (cmbmarkup.SelectedItem.ToString() == "75%")
                {
                    txtUnitPrice.Enabled = false;
                    decimal testing = Convert.ToDecimal(txtUnitPrice.Text);
                    decimal aa = (Convert.ToDecimal(0.75) * testing) + testing;
                    txtsellingprice.Text = Convert.ToString(String.Format("{0:0.00}", aa));
                }
                else if (cmbmarkup.SelectedItem.ToString() == "80%")
                {
                    txtUnitPrice.Enabled = false;
                    decimal testing = Convert.ToDecimal(txtUnitPrice.Text);
                    decimal aa = (Convert.ToDecimal(0.80) * testing) + testing;
                    txtsellingprice.Text = Convert.ToString(String.Format("{0:0.00}", aa));
                }
                else if (cmbmarkup.SelectedItem.ToString() == "85%")
                {
                    txtUnitPrice.Enabled = false;
                    decimal testing = Convert.ToDecimal(txtUnitPrice.Text);
                    decimal aa = (Convert.ToDecimal(0.85) * testing) + testing;
                    txtsellingprice.Text = Convert.ToString(String.Format("{0:0.00}", aa));
                }
                else if (cmbmarkup.SelectedItem.ToString() == "90%")
                {
                    txtUnitPrice.Enabled = false;
                    decimal testing = Convert.ToDecimal(txtUnitPrice.Text);
                    decimal aa = (Convert.ToDecimal(0.90) * testing) + testing;
                    txtsellingprice.Text = Convert.ToString(String.Format("{0:0.00}", aa));
                }
                else if (cmbmarkup.SelectedItem.ToString() == "95%")
                {
                    txtUnitPrice.Enabled = false;
                    decimal testing = Convert.ToDecimal(txtUnitPrice.Text);
                    decimal aa = (Convert.ToDecimal(0.95) * testing) + testing;
                    txtsellingprice.Text = Convert.ToString(String.Format("{0:0.00}", aa));
                }
                else if (cmbmarkup.SelectedItem.ToString() == "100%")
                {
                    txtUnitPrice.Enabled = false;
                    decimal testing = Convert.ToDecimal(txtUnitPrice.Text);
                    txtsellingprice.Text = Convert.ToString(String.Format("{0:0.00}", testing));
                }
            }
        }

        private void txtsearchname_TextChanged(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(cn);
                DataTable dt = new DataTable();
                string sql = "Select * from product WHERE ProductName LIKE '%" + txtsearchname.Text + "%' order by ProductName";
                MySqlDataAdapter da = new MySqlDataAdapter(sql, connection);
                da.Fill(dt);
                metroGrid1.DataSource = dt;
            }
            catch (Exception)
            {
                MessageBox.Show("Test");
            }
        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(cn);
                DataTable dt = new DataTable();
                string sql = "Select * from product WHERE Category LIKE '%" + cmbCategory.Text + "%' order by ProductName";
                MySqlDataAdapter da = new MySqlDataAdapter(sql, connection);
                da.Fill(dt);
                metroGrid1.DataSource = dt;
            }
            catch (Exception)
            {
                MessageBox.Show("Test");
            }
        }

        private void cmbmarkup_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtsellingprice.ResetText();
            txtUnitPrice.Enabled = true;

            if (bunifuCheckbox1.Checked == true)
            {
                bunifuCheckbox1.Checked = false;
            }
            else if(string.IsNullOrEmpty(txtUnitPrice.Text))
            {
                MessageBox.Show("Please input price first", "Important", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cmbmarkup.SelectedIndex = -1;
            }
            else if (cmbmarkup.SelectedItem.ToString() == "5%")
                {
                    txtUnitPrice.Enabled = false;
                    decimal testing = Convert.ToDecimal(txtUnitPrice.Text);
                    decimal aa = (Convert.ToDecimal(0.05) * testing) + testing;
                    txtsellingprice.Text = Convert.ToString(String.Format("{0:0.00}", aa));
                }
                else if (cmbmarkup.SelectedItem.ToString() == "10%")
                {
                    txtUnitPrice.Enabled = false;
                    decimal testing = Convert.ToDecimal(txtUnitPrice.Text);
                    decimal aa = (Convert.ToDecimal(0.10) * testing) + testing;
                    txtsellingprice.Text = Convert.ToString(String.Format("{0:0.00}", aa));
                }
                else if (cmbmarkup.SelectedItem.ToString() == "15%")
                {
                    txtUnitPrice.Enabled = false;
                    decimal testing = Convert.ToDecimal(txtUnitPrice.Text);
                    decimal aa = (Convert.ToDecimal(0.15) * testing) + testing;
                    txtsellingprice.Text = Convert.ToString(String.Format("{0:0.00}", aa));
                }
                else if (cmbmarkup.SelectedItem.ToString() == "20%")
                {
                    txtUnitPrice.Enabled = false;
                    decimal testing = Convert.ToDecimal(txtUnitPrice.Text);
                    decimal aa = (Convert.ToDecimal(0.20) * testing) + testing;
                    txtsellingprice.Text = Convert.ToString(String.Format("{0:0.00}", aa));
                }
                else if (cmbmarkup.SelectedItem.ToString() == "25%")
                {
                    txtUnitPrice.Enabled = false;
                    decimal testing = Convert.ToDecimal(txtUnitPrice.Text);
                    decimal aa = (Convert.ToDecimal(0.25) * testing) + testing;
                    txtsellingprice.Text = Convert.ToString(String.Format("{0:0.00}", aa));
                }
                else if (cmbmarkup.SelectedItem.ToString() == "30%")
                {
                    txtUnitPrice.Enabled = false;
                    decimal testing = Convert.ToDecimal(txtUnitPrice.Text);
                    decimal aa = (Convert.ToDecimal(0.30) * testing) + testing;
                    txtsellingprice.Text = Convert.ToString(String.Format("{0:0.00}", aa));
                }
                else if (cmbmarkup.SelectedItem.ToString() == "35%")
                {
                    txtUnitPrice.Enabled = false;
                    decimal testing = Convert.ToDecimal(txtUnitPrice.Text);
                    decimal aa = (Convert.ToDecimal(0.35) * testing) + testing;
                    txtsellingprice.Text = Convert.ToString(String.Format("{0:0.00}", aa));
                }
                else if (cmbmarkup.SelectedItem.ToString() == "40%")
                {
                    txtUnitPrice.Enabled = false;
                    decimal testing = Convert.ToDecimal(txtUnitPrice.Text);
                    decimal aa = (Convert.ToDecimal(0.40) * testing) + testing;
                    txtsellingprice.Text = Convert.ToString(String.Format("{0:0.00}", aa));
                }
                else if (cmbmarkup.SelectedItem.ToString() == "45%")
                {
                    txtUnitPrice.Enabled = false;
                    decimal testing = Convert.ToDecimal(txtUnitPrice.Text);
                    decimal aa = (Convert.ToDecimal(0.45) * testing) + testing;
                    txtsellingprice.Text = Convert.ToString(String.Format("{0:0.00}", aa));
                }
                else if (cmbmarkup.SelectedItem.ToString() == "50%")
                {
                    txtUnitPrice.Enabled = false;
                    decimal testing = Convert.ToDecimal(txtUnitPrice.Text);
                    decimal aa = (Convert.ToDecimal(0.50) * testing) + testing;
                    txtsellingprice.Text = Convert.ToString(String.Format("{0:0.00}", aa));
                }
                else if (cmbmarkup.SelectedItem.ToString() == "55%")
                {
                    txtUnitPrice.Enabled = false;
                    decimal testing = Convert.ToDecimal(txtUnitPrice.Text);
                    decimal aa = (Convert.ToDecimal(0.55) * testing) + testing;
                    txtsellingprice.Text = Convert.ToString(String.Format("{0:0.00}", aa));
                }
                else if (cmbmarkup.SelectedItem.ToString() == "60%")
                {
                    txtUnitPrice.Enabled = false;
                    decimal testing = Convert.ToDecimal(txtUnitPrice.Text);
                    decimal aa = (Convert.ToDecimal(0.60) * testing) + testing;
                    txtsellingprice.Text = Convert.ToString(String.Format("{0:0.00}", aa));
                }
                else if (cmbmarkup.SelectedItem.ToString() == "65%")
                {
                    txtUnitPrice.Enabled = false;
                    decimal testing = Convert.ToDecimal(txtUnitPrice.Text);
                    decimal aa = (Convert.ToDecimal(0.15) * testing) + testing;
                    txtsellingprice.Text = Convert.ToString(String.Format("{0:0.00}", aa));
                }
                else if (cmbmarkup.SelectedItem.ToString() == "70%")
                {
                    txtUnitPrice.Enabled = false;
                    decimal testing = Convert.ToDecimal(txtUnitPrice.Text);
                    decimal aa = (Convert.ToDecimal(0.70) * testing) + testing;
                    txtsellingprice.Text = Convert.ToString(String.Format("{0:0.00}", aa));
                }
                else if (cmbmarkup.SelectedItem.ToString() == "75%")
                {
                    txtUnitPrice.Enabled = false;
                    decimal testing = Convert.ToDecimal(txtUnitPrice.Text);
                    decimal aa = (Convert.ToDecimal(0.75) * testing) + testing;
                    txtsellingprice.Text = Convert.ToString(String.Format("{0:0.00}", aa));
                }
                else if (cmbmarkup.SelectedItem.ToString() == "80%")
                {
                    txtUnitPrice.Enabled = false;
                    decimal testing = Convert.ToDecimal(txtUnitPrice.Text);
                    decimal aa = (Convert.ToDecimal(0.80) * testing) + testing;
                    txtsellingprice.Text = Convert.ToString(String.Format("{0:0.00}", aa));
                }
                else if (cmbmarkup.SelectedItem.ToString() == "85%")
                {
                    txtUnitPrice.Enabled = false;
                    decimal testing = Convert.ToDecimal(txtUnitPrice.Text);
                    decimal aa = (Convert.ToDecimal(0.85) * testing) + testing;
                    txtsellingprice.Text = Convert.ToString(String.Format("{0:0.00}", aa));
                }
                else if (cmbmarkup.SelectedItem.ToString() == "90%")
                {
                    txtUnitPrice.Enabled = false;
                    decimal testing = Convert.ToDecimal(txtUnitPrice.Text);
                    decimal aa = (Convert.ToDecimal(0.90) * testing) + testing;
                    txtsellingprice.Text = Convert.ToString(String.Format("{0:0.00}", aa));
                }
                else if (cmbmarkup.SelectedItem.ToString() == "95%")
                {
                    txtUnitPrice.Enabled = false;
                    decimal testing = Convert.ToDecimal(txtUnitPrice.Text);
                    decimal aa = (Convert.ToDecimal(0.95) * testing) + testing;
                    txtsellingprice.Text = Convert.ToString(String.Format("{0:0.00}", aa));
                }
                else if (cmbmarkup.SelectedItem.ToString() == "100%")
                {
                    txtUnitPrice.Enabled = false;
                    decimal testing = Convert.ToDecimal(txtUnitPrice.Text);
                    txtsellingprice.Text = Convert.ToString(String.Format("{0:0.00}", testing));
                }
            }

        private void btnclear_Click(object sender, EventArgs e)
        {
            reset();
            txtUnitPrice.Enabled = false;
            txtQuantity.Enabled = false;
            txtCriticalLevel1.ResetText();
            txtCriticalLevel2.ResetText();
            txtceiling.ResetText();
        }
        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ModifyProduct_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void cmbSellingItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void txtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) ||
                char.IsSymbol(e.KeyChar) ||
                char.IsWhiteSpace(e.KeyChar) ||
                char.IsPunctuation(e.KeyChar))
                e.Handled = true;
            else if (e.KeyChar.Equals(Convert.ToChar(13)))
            {
                btnadd_Click(sender, e);
            }
        }

        private void txtUnitPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) ||
               char.IsSymbol(e.KeyChar) ||
               char.IsWhiteSpace(e.KeyChar))
                e.Handled = true;

            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != '\b' && e.KeyChar != '.')
            {
                e.Handled = true;
            }
            if (e.KeyChar == '.' && txtUnitPrice.Text.Contains("."))
            {
                e.Handled = true;
            }
            if (Regex.IsMatch(txtUnitPrice.Text, @"\.\d\d") && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            Settings f1 = new Settings();
            f1.ShowDialog();

            showpercentage();
            //txtFSI1.Text = metroGrid2.CurrentRow.Cells["FSI1"].Value.ToString();
            //txtFSI2.Text = metroGrid2.CurrentRow.Cells["FSI2"].Value.ToString();
            //txtSSI1.Text = metroGrid2.CurrentRow.Cells["SSI1"].Value.ToString();
            //txtSSI2.Text = metroGrid2.CurrentRow.Cells["SSI2"].Value.ToString();

            //if (cmbSellingItems.SelectedIndex == 0)
            //{

            //    txtQuantity.Text = "1";
            //    FSIorSSI();
            //    label10.Text = "" + txtFSI1.Text + "%";
            //    label11.Text = "" + txtFSI2.Text + "%";
            //}
            //if (cmbSellingItems.SelectedIndex == 1)
            //{
            //    txtQuantity.Text = "1";
            //    FSIorSSI();
            //    label10.Text = "" + txtSSI1.Text + "%";
            //    label11.Text = "" + txtSSI2.Text + "%";
            //}

        }

        private void txtceiling_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) ||
               char.IsSymbol(e.KeyChar) ||
               char.IsWhiteSpace(e.KeyChar))

                e.Handled = true;

            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != '\b' && e.KeyChar != '.')
            {
                e.Handled = true;
            }
            if (e.KeyChar == '.' && txtUnitPrice.Text.Contains("."))
            {
                e.Handled = true;
            }
            if (Regex.IsMatch(txtUnitPrice.Text, @"\.\d\d") && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void GroupBox1_Enter(object sender, EventArgs e)
        {

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

        private void txtCriticalLevel1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}