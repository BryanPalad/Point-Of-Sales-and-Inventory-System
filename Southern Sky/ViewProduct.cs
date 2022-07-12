using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using MetroFramework.Forms;
using DGVPrinterHelper;
using System.Text.RegularExpressions;

namespace Southern_Sky
{
    public partial class ViewProduct : MetroForm
    {
        string cn = "Server=localhost;Database=dbpos;Uid=root;Pwd=" + "" + ";";
        public string username = LOGIN.Username;
        public ViewProduct()
        {
            InitializeComponent();
        }

        private void metroGrid1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            reset();
            txtProductName.Enabled = true;
            cmbCategory.Enabled = true;
            txtSellingPrice.Enabled = true;
            txtProductNo.Text = metroGrid1.CurrentRow.Cells["ProductNo"].Value.ToString();
            txtProductName.Text = metroGrid1.CurrentRow.Cells["ProductName"].Value.ToString();
            cmbCategory.Text = metroGrid1.CurrentRow.Cells["Category"].Value.ToString();
            txtSellingPrice.Text = metroGrid1.CurrentRow.Cells["SellingPrice"].Value.ToString();
            txtStocks.Text = metroGrid1.CurrentRow.Cells["Quantity"].Value.ToString();
            txtunit.Text = metroGrid1.CurrentRow.Cells["Units"].Value.ToString();
            txtceiling.Text = metroGrid1.CurrentRow.Cells["Ceiling"].Value.ToString();

        }
        private void reset()
        {
            txtProductNo.Text = "";
            txtProductName.Text = "";
            cmbCategory.SelectedIndex = -1;
            txtSellingPrice.Text = "";
            txtStocks.Text = "";
            txtceiling.Text = "";
            txtreturn.ResetText();
            txtunit.Text = "";
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            Checkname();
        }
        private void Checkname()
        {
            MySqlConnection connection = new MySqlConnection(cn);
            MySqlCommand cmd;
            connection.Open();
            try
            {
                cmd = connection.CreateCommand();
                cmd.CommandText = "Select productname from product where ProductName = @ProductName and ProductNo = '" + txtProductNo.Text + "' union Select productname from unavailable where productname = @ProductName1 and ProductNo = '" + txtProductNo.Text + "'";
                cmd.Parameters.AddWithValue("@ProductName", txtProductName.Text);
                cmd.Parameters.AddWithValue("@ProductName1", txtProductName.Text);
                MySqlDataReader ProductExist = cmd.ExecuteReader();


                if (ProductExist.HasRows)
                {
                    updateproduct();
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
        private void updateproduct()
        {

            if (txtSellingPrice.Text == "0" || txtSellingPrice.Text == "00" || txtSellingPrice.Text == "000" || txtSellingPrice.Text == "0000" || txtSellingPrice.Text == "00000" || txtSellingPrice.Text == "000000" || txtSellingPrice.Text == "0000000" || txtSellingPrice.Text == "00000000" || txtSellingPrice.Text == "000000000" || txtSellingPrice.Text == "000000000" || txtSellingPrice.Text == "0000000000")
            {
                MessageBox.Show("Please input valid unit price", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtSellingPrice.Text == "0.0" || txtSellingPrice.Text == "00.0" || txtSellingPrice.Text == "000.0" || txtSellingPrice.Text == "0000.0" || txtSellingPrice.Text == "00000.0" || txtSellingPrice.Text == "000000.0" || txtSellingPrice.Text == "0000000.0" || txtSellingPrice.Text == "00000000.0" || txtSellingPrice.Text == "000000000.0" || txtSellingPrice.Text == "000000000.0" || txtSellingPrice.Text == "0000000000.0" || txtSellingPrice.Text == "00000000000.0")
            {
                MessageBox.Show("Please input valid price", "Important", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtSellingPrice.Text == "0." || txtSellingPrice.Text == "00." || txtSellingPrice.Text == "000." || txtSellingPrice.Text == "0000." || txtSellingPrice.Text == "00000." || txtSellingPrice.Text == "000000." || txtSellingPrice.Text == "0000000." || txtSellingPrice.Text == "00000000." || txtSellingPrice.Text == "000000000." || txtSellingPrice.Text == "000000000." || txtSellingPrice.Text == "0000000000." || txtSellingPrice.Text == "00000000000.")
            {
                MessageBox.Show("Please input valid price", "Important", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtSellingPrice.Text == "0.00" || txtSellingPrice.Text == "00.00" || txtSellingPrice.Text == "000.00" || txtSellingPrice.Text == "0000.00" || txtSellingPrice.Text == "00000.00" || txtSellingPrice.Text == "000000.00" || txtSellingPrice.Text == "0000000.00" || txtSellingPrice.Text == "00000000.00" || txtSellingPrice.Text == "000000000.00" || txtSellingPrice.Text == "000000000.00" || txtSellingPrice.Text == "0000000000.00" || txtSellingPrice.Text == "00000000000.00")
            {
                MessageBox.Show("Please input valid price", "Important", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (string.IsNullOrEmpty(cmbCategory.Text) || string.IsNullOrEmpty(txtProductName.Text) || string.IsNullOrEmpty(txtSellingPrice.Text))
            {
                MessageBox.Show("Please fill all the product information.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MySqlConnection connection = new MySqlConnection(cn);
                MySqlDataAdapter da = new MySqlDataAdapter();
                connection.Open();
                DialogResult dg = MessageBox.Show("Are you sure you want to Edit?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dg == DialogResult.Yes)
                {
                    try
                    {
                        da.UpdateCommand = new MySqlCommand("update product set ProductName=@ProductName, Category=@Category, SellingPrice=@SellingPrice where ProductNo=" + txtProductNo.Text + ";", connection);
                        da.UpdateCommand.Parameters.Add("@ProductName", MySqlDbType.VarChar).Value = txtProductName.Text;
                        da.UpdateCommand.Parameters.Add("@Category", MySqlDbType.VarChar).Value = cmbCategory.Text;
                        da.UpdateCommand.Parameters.Add("@SellingPrice", MySqlDbType.VarChar).Value = txtSellingPrice.Text;


                        da.UpdateCommand.ExecuteNonQuery();

                        MessageBox.Show("Successfully Updated Product " + txtProductName.Text + ".", "Product Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        updateaudit();
                        show();
                        reset();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Please Select Product to Update", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                cmd.CommandText = "Select productname from product where productname = @ProductName union Select productname from unavailable where productname = @ProductName1 union Select productname from addproduct where productname = @ProductName2";
                cmd.Parameters.AddWithValue("@ProductName", txtProductName.Text);
                cmd.Parameters.AddWithValue("@ProductName1", txtProductName.Text);
                cmd.Parameters.AddWithValue("@ProductName2", txtProductName.Text);
                MySqlDataReader ProductExist = cmd.ExecuteReader();


                if (ProductExist.HasRows)
                {
                    MessageBox.Show("This Product " + txtProductName.Text + " name is already exist \r\nPlease Check in Inventory, Unavailable and Modify Product.", "Product Name Exist", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    updateproduct();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void show()
        {
            MySqlConnection connection = new MySqlConnection(cn);
            connection.Open();
            try
            {
                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT * FROM `product` order by productname ";
                MySqlDataAdapter adap = new MySqlDataAdapter(cmd);
                DataTable ds = new DataTable();
                adap.Fill(ds);
                metroGrid1.DataSource = ds;
                if (metroGrid1.Rows.Count >= 1)
                {
                    colorload();
                    itemscount();
                    colorcount();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void colorload()
        {
            for (int i = 0; i < metroGrid1.Rows.Count; i++)
            {
                int qty = Convert.ToInt32(metroGrid1.Rows[i].Cells[4].Value);
                int qtycompare1 = Convert.ToInt32(metroGrid1.Rows[i].Cells[5].Value);
                int qtycompare2 = Convert.ToInt32(metroGrid1.Rows[i].Cells[6].Value);

                string quantity = Convert.ToString(metroGrid1.Rows[i].Cells[4].Value.ToString());
                string name = Convert.ToString(metroGrid1.Rows[i].Cells[1].Value.ToString());

                if (qty <= qtycompare2)
                {
                    metroGrid1.Rows[i].Cells[4].Style.BackColor = Color.Red;
                    metroGrid1.Rows[i].Cells[1].Style.BackColor = Color.Red;
                }
                else if (qty <= qtycompare1)
                {
                    metroGrid1.Rows[i].Cells[4].Style.BackColor = Color.Yellow;
                    metroGrid1.Rows[i].Cells[1].Style.BackColor = Color.Yellow;
                }

            }
        }
        private void itemscount()
        {
            lblitem.Text = metroGrid1.Rows.Count.ToString("");
            lblitem.Visible = true;
        }
        private void colorcount()
        {
            int red = 0;
            int yellow = 0;
            foreach (DataGridViewRow Myrow in metroGrid1.Rows)
            {
                if (Myrow.Cells[4].Style.BackColor == Color.Yellow)
                {
                    yellow++;
                }
                if (Myrow.Cells[4].Style.BackColor == Color.Red)
                {
                    red++;
                }
            }
            lblwarningpoint.Text = yellow.ToString() + " Items";
            lblreorderpoint.Text = red.ToString() + " Items";
        }

        private void bunifuMaterialTextbox1_OnValueChanged(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(cn);
                DataTable dt = new DataTable();
                string sql = "Select * from product WHERE ProductName LIKE '%" + txtsearch.Text + "%' or Quantity LIKE '%" + txtsearch.Text + "%' or Category LIKE '%" + txtsearch.Text + "%' or SellingPrice LIKE '%" + txtsearch.Text + "%'  order by ProductName";
                MySqlDataAdapter da = new MySqlDataAdapter(sql, connection);
                da.Fill(dt);
                metroGrid1.DataSource = dt;
                colorload();
                itemscount();
                colorcount();
            }
            catch (Exception)
            {
                MessageBox.Show("Test");
            }
        }

        private void metroGrid1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            txtProductName.Enabled = true;
            cmbCategory.Enabled = true;
            txtSellingPrice.Enabled = true;
            //bunifuCheckbox1.Checked = false;
            txtProductNo.Text = metroGrid1.CurrentRow.Cells["ProductNo"].Value.ToString();
            txtProductName.Text = metroGrid1.CurrentRow.Cells["ProductName"].Value.ToString();
            cmbCategory.Text = metroGrid1.CurrentRow.Cells["Category"].Value.ToString();
            txtSellingPrice.Text = metroGrid1.CurrentRow.Cells["SellingPrice"].Value.ToString();
            txtStocks.Text = metroGrid1.CurrentRow.Cells["Quantity"].Value.ToString();
            txtunit.Text = metroGrid1.CurrentRow.Cells["Units"].Value.ToString();
            txtceiling.Text = metroGrid1.CurrentRow.Cells["Ceiling"].Value.ToString();
        }

        private void metroGrid1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            itemscount();
            colorload();
            colorcount();
        }

        private void ViewProduct_Load(object sender, EventArgs e)
        {
            txtuser.Text = username;
            txtProductName.Enabled = false;
            cmbCategory.Enabled = false;
            txtSellingPrice.Enabled = false;
            show();
            getcategory();
            //getmarkup();
            if (metroGrid1.Rows.Count >= 1)
            {
                notification();
            }
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
                cmd.Parameters.AddWithValue("@Access", "The Administrator updated '" + txtProductName.Text + "'");

                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                MetroFramework.MetroMessageBox.Show(this, ex.Message);
            }
        }
        private void getcategory()
        {
            MySqlConnection connection = new MySqlConnection(cn);
            MySqlCommand cmd = new MySqlCommand("SELECT Category FROM  categories order by Category;");
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
        private void unaudit()
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
                cmd.Parameters.AddWithValue("@Access", "The Administrator unavailable '" + txtProductName.Text + "'");

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
            if (string.IsNullOrEmpty(txtProductNo.Text))
            {
                MessageBox.Show("Please select product to unavailable.", "Important", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (txtStocks.Text == "0")
                {
                    unavailable();
                }
                else
                {
                    MessageBox.Show("This product '" + txtProductName.Text + "' has '" + txtStocks.Text + "' stocks", "Important", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void unavailable()
        {
            MySqlConnection connection = new MySqlConnection(cn);
            MySqlCommand cmd;
            connection.Open();
            DialogResult dg = MessageBox.Show("Are you sure you want to unavailable this Product '" + txtProductName.Text + "'?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dg == DialogResult.Yes)
            {
                unaudit();
                try
                {
                    cmd = connection.CreateCommand();
                    cmd.CommandText = "Insert into unavailable(ProductNo,ProductName,Category,SellingPrice,Quantity,CriticalLevel1,CriticalLevel2,Units,Ceiling) select ProductNo,ProductName,Category,SellingPrice,Quantity,CriticalLevel1,CriticalLevel2,Units,Ceiling from product where ProductNo = @ProductNo";
                    cmd.Parameters.AddWithValue("@ProductNo", txtProductNo.Text);

                    cmd.ExecuteNonQuery();
                    if (connection.State == ConnectionState.Open)
                    {
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
                da.DeleteCommand = new MySqlCommand("delete from product where productno=" + txtProductNo.Text + ";", connection);


                da.DeleteCommand.ExecuteNonQuery();

                MessageBox.Show("Successfully Unavailable this Product " + txtProductName.Text + ".", "Product Unavailable", MessageBoxButtons.OK, MessageBoxIcon.Information);
                show();
                reset();

            }
            catch (Exception)
            {
                MessageBox.Show("Please Select Product to Unavailable", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void notification()
        {
            for (int i = 0; i < metroGrid1.Rows.Count; i++)
            {
                int qty = Convert.ToInt32(metroGrid1.Rows[i].Cells[4].Value);
                int qtycompare1 = Convert.ToInt32(metroGrid1.Rows[i].Cells[5].Value);
                int qtycompare2 = Convert.ToInt32(metroGrid1.Rows[i].Cells[6].Value);

                string quantity = Convert.ToString(metroGrid1.Rows[i].Cells[4].Value.ToString());
                string name = Convert.ToString(metroGrid1.Rows[i].Cells[1].Value.ToString());

                if (qty <= qtycompare2)
                {

                    notifyIcon1.Icon = SystemIcons.Information;
                    notifyIcon1.BalloonTipTitle = "Product at Re-Ordering Point";
                    notifyIcon1.BalloonTipText = "This product '" + name + "' has only have '" + quantity + "' quantity, You need to Re-Order stock.";
                    notifyIcon1.BalloonTipIcon = ToolTipIcon.Error;
                    notifyIcon1.ShowBalloonTip(1000);﻿  
                }
                else if (qty <= qtycompare1)
                {

                    notifyIcon1.Icon = SystemIcons.Information;
                    notifyIcon1.BalloonTipTitle = "Product at Warning Point";
                    notifyIcon1.BalloonTipText = "This product '" + name + "' has only have '" + quantity + "' quantity.";
                    notifyIcon1.BalloonTipIcon = ToolTipIcon.Warning;
                    notifyIcon1.ShowBalloonTip(1000);﻿     
                }

            }
        }

        private void btnstockin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtProductNo.Text))
            {
                MessageBox.Show("Please Select Product to Stock", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                StockIn f1 = new StockIn();
                f1.txtProductNo.Text = metroGrid1.CurrentRow.Cells["ProductNo"].Value.ToString();
                f1.lblProductName.Text = metroGrid1.CurrentRow.Cells["ProductName"].Value.ToString();
                f1.lblCategory.Text = metroGrid1.CurrentRow.Cells["Category"].Value.ToString();
                f1.lblUnitPrice.Text = metroGrid1.CurrentRow.Cells["SellingPrice"].Value.ToString();
                f1.txtStocks.Text = metroGrid1.CurrentRow.Cells["Quantity"].Value.ToString();
                f1.txtunit.Text = metroGrid1.CurrentRow.Cells["Units"].Value.ToString();
                f1.txtceiling.Text = metroGrid1.CurrentRow.Cells["Ceiling"].Value.ToString();
                f1.ShowDialog();
                show();
                reset();
            }
        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            reset();
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void btnunavailableproductlist_Click(object sender, EventArgs e)
        {
            UnavailableProduct d = new UnavailableProduct();
            d.ShowDialog();
            show();
        }

        private void txtProductName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsSymbol(e.KeyChar) || (e.KeyChar == '\''))
            {
                e.Handled = true;
            }
        }

        private void txtsearch_OnValueChanged(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(cn);
                DataTable dt = new DataTable();
                string sql = "Select * from product WHERE ProductName LIKE '%" + txtsearch.Text + "%' or Quantity LIKE '%" + txtsearch.Text + "%' or Category LIKE '%" + txtsearch.Text + "%' or SellingPrice LIKE '%" + txtsearch.Text + "%'  order by ProductName";
                MySqlDataAdapter da = new MySqlDataAdapter(sql, connection);
                da.Fill(dt);
                metroGrid1.DataSource = dt;
                colorload();
                itemscount();
                colorcount();
            }
            catch (Exception)
            {
                MessageBox.Show("Test");
            }
        }

        private void btnsearch_Click_1(object sender, EventArgs e)
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
        private void printaudit()
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
                cmd.Parameters.AddWithValue("@Access", "The Administrator prints all the products ");

                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                MetroFramework.MetroMessageBox.Show(this, ex.Message);
            }
        }
        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            if (metroGrid1.RowCount == 0)
            {
                MessageBox.Show("Empty", "Important", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                printdatagridview();
            }
        }
        private void printdatagridview()
        {
            printaudit();
            DGVPrinter print = new DGVPrinter();
            print.Title = "Product List";
            print.SubTitle = string.Format("Date: {0}", DateTime.Now.Date.ToLongDateString());
            print.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            print.PageNumbers = true;
            print.PageNumberInHeader = false;
            print.PorportionalColumns = true;
            print.HeaderCellAlignment = StringAlignment.Near;
            print.Footer = "Souther Sky Hardware and Construction Supply";
            print.FooterSpacing = 15;
            print.printDocument.DefaultPageSettings.Landscape = true;
            print.PrintDataGridView(metroGrid1);
        }
        public void defectreports()
        {
            MySqlConnection connection = new MySqlConnection(cn);
            MySqlCommand cmd;
            connection.Open();
            try
            {
                cmd = connection.CreateCommand();
                cmd.CommandText = "INSERT INTO defect(Date,Productname,Category,Quantity) values('" + System.DateTime.Now.ToString("yyyy/MM/dd") + "',@PN,@C,@Q)";
                cmd.Parameters.AddWithValue("@PN", txtProductName.Text);
                cmd.Parameters.AddWithValue("@C", cmbCategory.Text);
                cmd.Parameters.AddWithValue("@Q", txtreturn.Text);
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
        private void returnaudit()
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
                cmd.Parameters.AddWithValue("@Access", "The Administrator returned '" + txtProductName.Text + "'");

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
            if (string.IsNullOrEmpty(txtProductName.Text) || string.IsNullOrEmpty(cmbCategory.Text))
            {
                MessageBox.Show("Please select product", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (string.IsNullOrEmpty(txtreturn.Text))
            {
                MessageBox.Show("Please enter quantity to return", "Return?", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (Convert.ToDouble(txtreturn.Text) >= Convert.ToDouble(txtStocks.Text))
            {
                MessageBox.Show("Defect items must be less than the stocks", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                var a = MessageBox.Show("Are you sure you want to return " + txtreturn.Text + "" + txtProductName.Text + "?", "Return Items?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (a == DialogResult.Yes)
                {
                    notification();
                    returnaudit();
                    defectreports();
                    int stocks = Convert.ToInt32(txtStocks.Text);
                    int qty = Convert.ToInt32(txtreturn.Text);
                    if (stocks >= qty)
                    {
                        MySqlConnection connection = new MySqlConnection(cn);
                        MySqlDataAdapter da = new MySqlDataAdapter();
                        connection.Open();

                        da.UpdateCommand = new MySqlCommand("UPDATE product set Quantity = (Quantity - '" + qty + "') where productname = '" + txtProductName.Text + "';", connection);
                        da.UpdateCommand.ExecuteNonQuery();

                        MessageBox.Show("Successfully Returned Item/s", "Changed Item", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtreturn.ResetText();
                        show();
                    }
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            string time = DateTime.Now.ToLongTimeString();
            lblTime.Text = time;
        }

        private void txtsearch_OnValueChanged_1(object sender, EventArgs e)
        {

        }
        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "ProductName")
            {
                MySqlConnection connection = new MySqlConnection(cn);
                DataTable dt = new DataTable();
                string sql = "Select * from product WHERE ProductName LIKE '%" + txtsearch.Text + "%'";
                MySqlDataAdapter da = new MySqlDataAdapter(sql, connection);
                da.Fill(dt);
                metroGrid1.DataSource = dt;
            }
            else if (comboBox1.Text == "Category")
            {
                MySqlConnection connection = new MySqlConnection(cn);
                DataTable dt = new DataTable();
                string sql = "Select * from product WHERE Category LIKE '%" + txtsearch.Text + "%'";
                MySqlDataAdapter da = new MySqlDataAdapter(sql, connection);
                da.Fill(dt);
                metroGrid1.DataSource = dt;
            }
            else if (comboBox1.Text == "Quantity")
            {
                MySqlConnection connection = new MySqlConnection(cn);
                DataTable dt = new DataTable();
                string sql = "Select * from product WHERE Quantity LIKE '%" + txtsearch.Text + "%'";
                MySqlDataAdapter da = new MySqlDataAdapter(sql, connection);
                da.Fill(dt);
                metroGrid1.DataSource = dt;
            }
            else if (comboBox1.Text == "SellingPrice")
            {
                MySqlConnection connection = new MySqlConnection(cn);
                DataTable dt = new DataTable();
                string sql = "Select * from product WHERE SellingPrice LIKE '%" + txtsearch.Text + "%'";
                MySqlDataAdapter da = new MySqlDataAdapter(sql, connection);
                da.Fill(dt);
                metroGrid1.DataSource = dt;
            }
            else if (comboBox1.Text == "Units")
            {
                MySqlConnection connection = new MySqlConnection(cn);
                DataTable dt = new DataTable();
                string sql = "Select * from product WHERE Units LIKE '%" + txtsearch.Text + "%'";
                MySqlDataAdapter da = new MySqlDataAdapter(sql, connection);
                da.Fill(dt);
                metroGrid1.DataSource = dt;
            }
            else if (comboBox1.Text == "Ceiling")
            {
                MySqlConnection connection = new MySqlConnection(cn);
                DataTable dt = new DataTable();
                string sql = "Select * from product WHERE Ceiling LIKE '%" + txtsearch.Text + "%'";
                MySqlDataAdapter da = new MySqlDataAdapter(sql, connection);
                da.Fill(dt);
                metroGrid1.DataSource = dt;
            }
        }
    }
}