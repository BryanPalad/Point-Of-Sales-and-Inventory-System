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
using System.Drawing.Printing;

namespace Southern_Sky
{
    public partial class CASHIER : MetroForm
    {

        string cn = "Server=localhost;Database=dbpos;Uid=root;Pwd=" + "" + ";";
        public string username = LOGIN.Username;
        public CASHIER()
        {
            InitializeComponent();
        }
        private void getnameofseller()
        {
            MySqlConnection connection = new MySqlConnection(cn);
            MySqlCommand cmd = new MySqlCommand("SELECT Firstname FROM  login where username = '" + txtWelcome.Text + "'");
            cmd.CommandType = CommandType.Text;
            cmd.Connection = connection;
            cmd.Connection = connection;
            connection.Open();


            try
            {
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {

                    lblgetname.Text = dr.GetString("Firstname");
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

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            var a = MetroFramework.MetroMessageBox.Show(this, "Are you sure you want to log out?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (a == DialogResult.Yes)
            {
                this.Hide();
                LOGIN c = new LOGIN();
                c.Show();
            }
        }

        private void MOVING_Tick(object sender, EventArgs e)
        {

        }

        private void bunifuThinButton21_Click_1(object sender, EventArgs e)
        {
            this.Hide();
        }
        private void saveinvoicenumbers()
        {
            MySqlConnection connection = new MySqlConnection(cn);
            MySqlCommand cmd;
            connection.Open();

            try
            {
                cmd = connection.CreateCommand();
                cmd.CommandText = "INSERT INTO invoicenum(invoiceno) values (@invoice)";
                cmd.Parameters.AddWithValue("@invoice", txtnum.Text);

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
        private void invoicenumbers()
        {
            MySqlConnection connection = new MySqlConnection(cn);
            MySqlCommand cmd = new MySqlCommand("SELECT max(invoiceno) + 1 as 'Invoice' FROM  invoicenum");
            cmd.CommandType = CommandType.Text;
            cmd.Connection = connection;
            cmd.Connection = connection;
            connection.Open();


            try
            {
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {

                    txtnum.Text = dr.GetString("Invoice");
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

        private void mousedown(object sender, MouseEventArgs e)
        {

        }

        private void CASHIER_Load(object sender, EventArgs e)
        {
            showproduct();
            //Random randomnum = new Random();
            //int number = randomnum.Next(10000, 999999999);
            //txtnum.Text = number.ToString();
            invoicenumbers();
            txtWelcome.Text = username;
            getProductName();
            show();
            show2();
            cmbProductName.SelectedIndex = -1;
        }
        private void show2()
        {
            MySqlConnection connection = new MySqlConnection(cn);
            connection.Open();

            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT * FROM `product` order by productname ";
            MySqlDataAdapter adap = new MySqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            adap.Fill(ds);
            metroGrid3.DataSource = ds;
        }
        private void showproduct()
        {
            MySqlConnection connection = new MySqlConnection(cn);
            connection.Open();
            try
            {
                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT * FROM `product` where quantity <> '0'";
                MySqlDataAdapter adap = new MySqlDataAdapter(cmd);
                DataTable ds = new DataTable();
                adap.Fill(ds);
                metroGrid2.DataSource = ds;
                colorload();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void colorload()
        {
            for (int i = 0; i < metroGrid2.Rows.Count; i++)
            {
                int qty = Convert.ToInt32(metroGrid2.Rows[i].Cells[4].Value);
                int qtycompare1 = Convert.ToInt32(metroGrid2.Rows[i].Cells[5].Value);
                int qtycompare2 = Convert.ToInt32(metroGrid2.Rows[i].Cells[6].Value);

                string quantity = Convert.ToString(metroGrid2.Rows[i].Cells[4].Value.ToString());
                string name = Convert.ToString(metroGrid2.Rows[i].Cells[1].Value.ToString());

                if (qty <= qtycompare1)
                {
                    metroGrid2.Rows[i].Cells[4].Style.BackColor = Color.Yellow;
                    metroGrid2.Rows[i].Cells[1].Style.BackColor = Color.Yellow;
                }
                if (qty <= qtycompare2)
                {
                    metroGrid2.Rows[i].Cells[4].Style.BackColor = Color.Red;
                    metroGrid2.Rows[i].Cells[1].Style.BackColor = Color.Red;
                }
            }
        }
        private void getvatableAndVAt()
        {
            if (string.IsNullOrEmpty(txtTotal.Text))
            {

            }
            else
            {
                Double vat = 0.00, vatable = 0.00, totalpricetopay = 0.00;
                totalpricetopay = Convert.ToDouble(txtTotal.Text);

                //0.01071428571
                vat = (0.12) * totalpricetopay;

                vatable = totalpricetopay - vat;

                Double vat1 = vat;
                Math.Round(vat1, 2, MidpointRounding.AwayFromZero);
                Double vatable1 = vatable;
                Math.Round(vatable1, 2, MidpointRounding.AwayFromZero);


                txtVat.Text = Convert.ToString(String.Format("{0:0.00}", vat1));
                txtVatable.Text = Convert.ToString(String.Format("{0:0.00}", vatable1));
            }
        }
        private void getProductName()
        {
            MySqlConnection connection = new MySqlConnection(cn);
            MySqlCommand cmd = new MySqlCommand("SELECT ProductName FROM  product where quantity <> 0 order by productname;");
            cmd.CommandType = CommandType.Text;
            cmd.Connection = connection;
            cmd.Connection = connection;
            connection.Open();


            try
            {
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {

                    cmbProductName.Items.Add(dr.GetString("ProductName"));
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
        private void show()
        {
            MySqlConnection connection = new MySqlConnection(cn);
            connection.Open();
            try
            {
                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT * FROM `pos`";
                MySqlDataAdapter adap = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adap.Fill(ds);
                metroGrid1.DataSource = ds.Tables[0].DefaultView;
                itemscount();
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
        private void getTotalCount()
        {
            MySqlConnection connection = new MySqlConnection(cn);
            MySqlCommand cmd = new MySqlCommand("SELECT SUM(TotalPrice) AS 'Total Price' FROM pos");
            cmd.CommandType = CommandType.Text;
            cmd.Connection = connection;
            cmd.Connection = connection;
            connection.Open();


            try
            {
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    String gprice = dr["Total Price"].ToString();

                    Double generatetotalprice = Convert.ToDouble(gprice);

                    txtTotal.Text = Convert.ToString(String.Format("{0:0.00}", generatetotalprice));
                }

                dr.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Please input product first", "Important", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }

            }
        }
        private void truncate()
        {
            MySqlConnection connection = new MySqlConnection(cn);
            MySqlDataAdapter da = new MySqlDataAdapter();
            connection.Open();
            try
            {
                da.DeleteCommand = new MySqlCommand("truncate pos  ;", connection);

                da.DeleteCommand.ExecuteNonQuery();

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();


                }
            }
        }
        public void reset()
        {
            txtSubTotal.Text = "";
            cmbProductName.SelectedIndex = -1;
            txtQuantity.Text = "";
            txtSellingPrice.Text = "";
            txtProductNo.Text = "";
            txtQuantityinHand.Text = "";
            txtCategory.Text = "";
        }
        public void searchbyproductname()
        {
            string productname = cmbProductName.Text;
            string qty = String.Empty;
            string price;
            MySqlConnection connection = new MySqlConnection(cn);
            connection.Open();
            try
            {

                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT Category,Quantity,SellingPrice from product WHERE  ProductName = '" + productname + "';";
                MySqlDataAdapter adap = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {

                    txtCategory.Text = dr["Category"].ToString();
                    txtSubTotal.Text = dr["SellingPrice"].ToString();
                    price = dr["SellingPrice"].ToString();
                    qty = dr["Quantity"].ToString();
                    txtQuantityinHand.Text = qty;
                    txtSellingPrice.Text = price;
                    dr.Close();



                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                    txtQuantity.Text = "1";
                }
            }
        }

        private void cmbProductName_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmbProductName.SelectionLength > 0)
            {
                searchbyproductname();
            }
        }

        private void cmbProductName_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmbProductName.SelectionLength > 0)
            {
                searchbyproductname();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtProductNo.Text))
            {
                txtProductNo.ResetText();
            }
            if (string.IsNullOrEmpty(cmbProductName.Text))
            {
                MessageBox.Show("Please fill the Product Information", "Important", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {

                txtQuantity.Enabled = true;
                searchbyproductname();
                metroGrid3.Enabled = false;

            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ProductExistUpdate();

        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = new MySqlConnection(cn);
            MySqlDataAdapter da = new MySqlDataAdapter();
            connection.Open();
            DialogResult dg = MessageBox.Show("Are you sure you want to Remove?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dg == DialogResult.Yes)
            {
                try
                {
                    addstock();
                    // int userdetailsID = Convert.ToInt32(txtID.Text);
                    da.DeleteCommand = new MySqlCommand("delete from pos where ProductNo=" + txtProductNo.Text + ";", connection);


                    da.DeleteCommand.ExecuteNonQuery();

                    MessageBox.Show("Successfully Removed Product " + cmbProductName.Text + ".", "Product Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    show();
                    showproduct();
                    getvatableAndVAt();
                    reset();
                    if (string.IsNullOrEmpty(txtTotal.Text))
                    {
                        getTotalCount();
                    }
                    else
                    {
                        txtTotal.ResetText();
                    }

                }
                catch (Exception)
                {
                    MessageBox.Show("Please Select Product to Remove", "Important", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }
            }
        }

        private void metroGrid1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtQuantity.Enabled = false;
            txtSubTotal.Text = metroGrid1.CurrentRow.Cells["TotalPrice"].Value.ToString();
            cmbProductName.Text = metroGrid1.CurrentRow.Cells["ProductName"].Value.ToString();
            txtSellingPrice.Text = metroGrid1.CurrentRow.Cells["SellingPrice"].Value.ToString();
            txtProductNo.Text = metroGrid1.CurrentRow.Cells["ProductNo"].Value.ToString();
            txtCategory.Text = metroGrid1.CurrentRow.Cells["Category"].Value.ToString();
            txtQuantity.Text = metroGrid1.CurrentRow.Cells["Quantity"].Value.ToString();
            txtQuantityinHand.ResetText();
        }
        private void addstock()
        {
            string productname = cmbProductName.Text;

            //int qtyinhand = Convert.ToInt32(txtqtyinhand.Text);
            int qty = Convert.ToInt32(txtQuantity.Text);

            Double price = Convert.ToDouble(txtSellingPrice.Text);
            Double totalprice = Convert.ToDouble(txtSubTotal.Text);

            MySqlConnection connection = new MySqlConnection(cn);
            MySqlDataAdapter da = new MySqlDataAdapter();
            connection.Open();
            try
            {

                da.UpdateCommand = new MySqlCommand("UPDATE `product` inner join pos on product.productname=pos.productname set product.Quantity=(product.Quantity+" + qty + " ) where pos.productname='" + productname + "';", connection);
                da.UpdateCommand.ExecuteNonQuery();
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
        private void lessstock()
        {

            string productname = cmbProductName.Text;

            //int qtyinhand = Convert.ToInt32(txtqtyinhand.Text);
            int qty = Convert.ToInt32(txtQuantity.Text);

            Double price = Convert.ToDouble(txtSellingPrice.Text);
            Double totalprice = Convert.ToDouble(txtSubTotal.Text);

            MySqlConnection connection = new MySqlConnection(cn);
            MySqlDataAdapter da = new MySqlDataAdapter();
            connection.Open();
            try
            {

                da.UpdateCommand = new MySqlCommand("UPDATE `product` inner join pos on product.Productname=pos.Productname set product.Quantity=(product.Quantity-" + qty + " ) where pos.Productname='" + productname + "';", connection);
                da.UpdateCommand.ExecuteNonQuery();
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

        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtQuantity.Text))
                {
                    //Double price = Convert.ToDouble(txtUnitPrice.Text);
                    //int qty = Convert.ToInt32(txtQuantity.Text);
                    //Double totalprice = price * qty;
                    //txtSubTotal.Text = totalprice.ToString();
                    double a, c;
                    int b;
                    a = Convert.ToDouble(txtSellingPrice.Text);
                    b = Convert.ToInt32(txtQuantity.Text);
                    c = a * b;
                    txtSubTotal.Text = Convert.ToString(c);
                }
                else
                {
                    txtSubTotal.Text = "";
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Overload", "Important", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void itemscount()
        {

            lblitem.Text = metroGrid1.Rows.Count.ToString("");
            lblitem.Visible = true;
            //int a, b, c;
            //a = Convert.ToInt32(lblitem.Text);
            //b = 1;
            //c = a - b;
            //lblitem.Text = Convert.ToString(c);
        }
        public static string sendtext;

        private void btnaddcash_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(lblitem.Text))
            {
                MessageBox.Show("Please input product first", "Important", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (string.IsNullOrEmpty(txtTotal.Text))
                {
                    getTotalCount();
                    getvatableAndVAt();
                }
                else
                {
                    ADDCASH f1 = new ADDCASH();
                    sendtext = txtTotal.Text;
                    f1.ShowDialog();
                    txtCash.Text = ADDCASH.sendtext;
                }
            }
        }

        private void txtCash_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCash.Text))
            {

            }
            else
            {
                Double gtotal = Convert.ToDouble(txtTotal.Text.Trim());
                Double cash = Convert.ToDouble(txtCash.Text.Trim());
                if (cash < gtotal)
                {
                    MessageBox.Show("Insufficient Cash", "Important", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                else if (cash >= gtotal)
                {
                    Double change = cash - gtotal;

                    txtChange.Text = Convert.ToString(String.Format("{0:0.00}", change));
                }
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

        private void btnclose_Click(object sender, EventArgs e)
        {
            if (metroGrid1.Rows.Count >= 1)
            {
                MessageBox.Show("Please remove the product first in the cart list", "Important", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                this.Hide();
                ADMIN f1 = new ADMIN();
                f1.ShowDialog();
            }
        }

        private void CASHIER_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void btnpayment_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtChange.Text))
            {
                MessageBox.Show("Add Cash First", "Important", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {

                endtransaction();
                //cmbProductName.Enabled = false;
            }
        }
   
        public void endtransaction()
        {
            MySqlConnection connection = new MySqlConnection(cn);
            MySqlDataAdapter da = new MySqlDataAdapter();
            connection.Open();
            DialogResult dg = MessageBox.Show("Do you want to end transaction?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dg == DialogResult.Yes)
            {
                addreports();
                saleadd();
                try
                {

                    da.DeleteCommand = new MySqlCommand("truncate pos;", connection);


                    da.DeleteCommand.ExecuteNonQuery();


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

                        MessageBox.Show("Transaction Complete", "Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        foreach (DataGridViewRow row in metroGrid1.Rows)
                        {
                            if (!row.IsNewRow)
                            {
                                listBox1.Items.Add(row.Cells[1].Value.ToString() + "  " + row.Cells[4].Value.ToString() + "  " + row.Cells[5].Value.ToString());

                            }
                        }
                        cmbProductName.Enabled = false;
                        show();
                        show2();
                        showproduct();
                        reset();
                        bunifuCheckbox1.Checked = false;
                        bunifuCheckbox2.Checked = false;
                    }
                }
            }
            else if (dg == DialogResult.No)
            {
                MessageBox.Show("Transaction Cancel", "Cancel", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public void addreports()
        {
            MySqlConnection connection = new MySqlConnection(cn);
            MySqlCommand cmd;
            connection.Open();
            try
            {

                cmd = connection.CreateCommand();
                cmd.CommandText = "INSERT INTO reports(Date,Productname,Category,Quantity,TotalPrice) select '" + System.DateTime.Now.ToString("yyyy/MM/dd") + "',ProductName,Category,Quantity,TotalPrice from pos";

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
        public void saleadd()
        {
            MySqlConnection connection = new MySqlConnection(cn);
            MySqlCommand cmd;
            connection.Open();
            try
            {
                cmd = connection.CreateCommand();
                cmd.CommandText = "Insert into sale(ProductName,Category,SellingPrice,Quantity,TotalPrice,Date) select ProductName,Category,SellingPrice,Quantity,TotalPrice, '" + System.DateTime.Now.ToString("yyyy/MM/dd") + "' from pos where ProductNo Between 1 and 99999";

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
        private void ProductAdd()
        {
            if (string.IsNullOrEmpty(txtQuantity.Text) || txtQuantity.Text == "0" || txtQuantity.Text == "00" || txtQuantity.Text == "000" || txtQuantity.Text == "0000" || txtQuantity.Text == "00000" || txtQuantity.Text == "000000" || txtQuantity.Text == "0000000" || txtQuantity.Text == "00000000")
            {
                MessageBox.Show("Please Input Quantity", "Important", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    txtQuantity.Enabled = false;
                    int qtyinhand = Convert.ToInt32(txtQuantityinHand.Text);
                    int qty = Convert.ToInt32(txtQuantity.Text);
                    if (qtyinhand >= qty)
                    {
                        String prodname = cmbProductName.Text;

                        double unitprice = Convert.ToDouble(txtSellingPrice.Text);
                        double totalp = Convert.ToDouble(txtSubTotal.Text);
                        MySqlConnection connection = new MySqlConnection(cn);
                        MySqlCommand cmd;
                        connection.Open();
                        try
                        {
                            cmd = connection.CreateCommand();
                            cmd.CommandText = "INSERT INTO pos(ProductNo,Productname,Category,Quantity,SellingPrice,TotalPrice)Values(@ProductNo,@Productname,@Category,@Quantity,@SellingPrice,@TotalPrice);";
                            cmd.Parameters.AddWithValue("@ProductNo", null);
                            cmd.Parameters.AddWithValue("@ProductName", prodname);
                            cmd.Parameters.AddWithValue("@Category", txtCategory.Text);
                            cmd.Parameters.AddWithValue("@Quantity", qty);
                            cmd.Parameters.AddWithValue("@SellingPrice", unitprice);
                            cmd.Parameters.AddWithValue("@TotalPrice", totalp);


                            cmd.ExecuteNonQuery();
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
                                MessageBox.Show("Successfully Added Product " + cmbProductName.Text + ".", "Product Added", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                show();
                                showproduct();
                                getTotalCount();
                                getvatableAndVAt();
                                lessstock();
                                reset();
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Insufficient Stocks", "Important", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtSubTotal.Text = "";
                        txtQuantity.Text = "";
                        txtSellingPrice.Text = "";
                        txtProductNo.Text = "";
                        txtQuantityinHand.Text = "";
                        txtCategory.Text = "";
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Please Input Product", "Important", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        private void ProductExistUpdate()
        {
            MySqlConnection connection = new MySqlConnection(cn);
            MySqlCommand cmd;
            connection.Open();
            try
            {
                cmd = connection.CreateCommand();
                cmd.CommandText = "Select * from pos where productname = @ProductName";
                cmd.Parameters.AddWithValue("@ProductName", cmbProductName.Text);
                MySqlDataReader ProductExist = cmd.ExecuteReader();

                if (ProductExist.HasRows)
                {
                    QuantityUpdate();
                }
                else
                {
                    ProductAdd();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void QuantityUpdate()
        {
            if (string.IsNullOrEmpty(txtQuantity.Text) || txtQuantity.Text == "0")
            {
                MessageBox.Show("Please Input Quantity", "Important", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    txtQuantity.Enabled = false;
                    int qtyinhand = Convert.ToInt32(txtQuantityinHand.Text);
                    int qty = Convert.ToInt32(txtQuantity.Text);
                    if (qtyinhand >= qty)
                    {

                        string productname = cmbProductName.Text;


                        Double price = Convert.ToDouble(txtSellingPrice.Text);
                        Double totalprice = Convert.ToDouble(txtSubTotal.Text);

                        MySqlConnection connection = new MySqlConnection(cn);
                        MySqlDataAdapter da = new MySqlDataAdapter();
                        connection.Open();
                        try
                        {

                            da.UpdateCommand = new MySqlCommand("UPDATE pos set Quantity = (Quantity + '" + qty + "'),TotalPrice = (TotalPrice + '" + totalprice + "')where productname = '" + cmbProductName.Text + "';", connection);
                            da.UpdateCommand.ExecuteNonQuery();
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
                                show();
                                showproduct();
                                MessageBox.Show("Successfully Added Quantity " + txtQuantity.Text + ".", "Quantity Added", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                getTotalCount();
                                getvatableAndVAt();
                                lessstock();

                                reset();
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Insufficient Stocks", "Important", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Please Input Product", "Important", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnlog_Click(object sender, EventArgs e)
        {
            string mbt = "Do you really want to logout this user";
            string cap = "Logout";
            MessageBoxButtons button = MessageBoxButtons.YesNo;
            MessageBoxIcon icon = MessageBoxIcon.Question;

            var LogoutMessage = MetroFramework.MetroMessageBox.Show(this, mbt, cap, button, icon);


            if (metroGrid1.Rows.Count >= 1)
            {
                MessageBox.Show("Please remove the product first in the cart list", "Important", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (LogoutMessage == DialogResult.Yes)
                {
                    LOGIN login = new LOGIN();
                    MetroFramework.MetroMessageBox.Show(this, "Successfully logout", "Logout", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.Hide();
                    login.Show();
                    TrackLogOutCashier();
                }
                if (LogoutMessage == DialogResult.No)
                {
                    MetroFramework.MetroMessageBox.Show(this, "Cancel logout", "Logout", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        public void TrackLogOutCashier()
        {
            MySqlConnection con = new MySqlConnection(cn);
            MySqlCommand cmd;
            con.Open();
            try
            {
                cmd = con.CreateCommand();
                cmd.CommandText = "Insert into trackerlog(ID,Username,Userlevel,Access,Time,Date) values (@ID,@Username,@Userlevel,@Access,@Time,'" + System.DateTime.Now.ToString("yyyy/MM/dd") + "')";
                cmd.Parameters.AddWithValue("@ID", null);
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@Userlevel", "Cashier");
                cmd.Parameters.AddWithValue("@Access", "The Cashier has logged out");
                cmd.Parameters.AddWithValue("@Time", lblTime.Text);

                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                MetroFramework.MetroMessageBox.Show(this, ex.Message);
            }
        }

        private void Time_Tick(object sender, EventArgs e)
        {
            string time = DateTime.Now.ToLongTimeString();
            lblTime.Text = time;
            string seconds = DateTime.Now.ToString("ss");
            clock.Value = Convert.ToInt32(seconds);
        }

        private void CASHIER_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }

        private void txtChange_MouseHover(object sender, EventArgs e)
        {
            tooltip.SetToolTip(this.txtChange, this.txtChange.Text);
        }

        private void txtCash_MouseHover(object sender, EventArgs e)
        {
            tooltip.SetToolTip(this.txtCash, this.txtCash.Text);
        }

        private void lblitem_MouseHover(object sender, EventArgs e)
        {
            tooltip.SetToolTip(this.txtTotal, this.txtTotal.Text);
        }

        private void txtVat_MouseHover(object sender, EventArgs e)
        {
            tooltip.SetToolTip(this.txtVat, this.txtVat.Text);
        }

        private void txtVatable_MouseHover(object sender, EventArgs e)
        {
            tooltip.SetToolTip(this.txtVatable, this.txtVatable.Text);
        }

        private void btnnewOrder_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count == 1)
            {
                DialogResult dg = MessageBox.Show("Are you sure you do not want to print the receipt?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dg == DialogResult.Yes)
                {
                    cmbProductName.Enabled = true;
                    listBox1.Items.Clear();
                    txtCash.ResetText();
                    txtChange.ResetText();
                    txtTotal.ResetText();
                    txtVat.ResetText();
                    txtVatable.ResetText();
                    cmbProductName.Items.Clear();
                    getProductName();
                    saveinvoicenumbers();
                    invoicenumbers();
                }
                else if (dg == DialogResult.No)
                {
                    MessageBox.Show("Redirecting to print button", "Print", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnprint_Click(sender, e);
                }
            }
            else if (metroGrid1.RowCount >= 1)
            {
                MessageBox.Show("Finish the first order first or remove the product in cart list", "Important", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                cmbProductName.Enabled = true;
                reset();
                listBox1.Items.Clear();
                txtCash.ResetText();
                txtChange.ResetText();
                txtTotal.ResetText();
                txtVat.ResetText();
                txtVatable.ResetText();
                cmbProductName.Items.Clear();
                getProductName();
            }
        }

        private void cmbProductName_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSubTotal.ResetText();
            txtSellingPrice.ResetText();
            txtProductNo.ResetText();
            txtQuantityinHand.ResetText();
            txtCategory.ResetText();
            txtQuantity.ResetText();
            txtQuantity.Enabled = false;
        }

        private void btnprint_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count == 0)
            {
                MessageBox.Show("Buy Product First", "Important", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                PrintDialog printDialog = new PrintDialog();
                PrintDocument printDocument = new PrintDocument();

                printDialog.Document = printDocument;

                printDocument.PrintPage += new PrintPageEventHandler(print_PrintPage);

                DialogResult result = printDialog.ShowDialog();

                if (result == DialogResult.OK)
                {
                    printDocument.Print();
                }
                //Random randomnum = new Random();
                //int number = randomnum.Next(10000, 999999999);
                //txtnum.Text = number.ToString();
                saveinvoicenumbers();
                invoicenumbers();
                listBox1.Items.Clear();
                txtCash.ResetText();
                txtTotal.ResetText();
                txtChange.ResetText();
                txtVat.ResetText();
                txtVatable.ResetText();
            }
        }

        private void print_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            decimal cash = Convert.ToDecimal(txtCash.Text);
            decimal _change = Convert.ToDecimal(txtChange.Text);
            double vat12 = Convert.ToDouble(txtVat.Text);
            double vatable = Convert.ToDouble(txtVatable.Text);
            decimal totalprice = Convert.ToDecimal(txtTotal.Text);
            string countitems;
            countitems = listBox1.Items.Count.ToString();




            //this prints the reciept

            Graphics graphic = e.Graphics;

            Font font = new Font("Courier New", 12); //must use a mono spaced font as the spaces need to line up

            float fontHeight = font.GetHeight();

            int startX = 5;
            int startY = 5;
            int offset = 60;

            graphic.DrawString("  SOUTHERN SKY CONSTRUCTION SUPPLY", new Font("Century Gothic", 13, FontStyle.Bold), new SolidBrush(Color.Black), startX, startY);
            string address1 = "Dealer of Hardware,Electrical Plumbing".PadRight(10);
            graphic.DrawString(address1, new Font("Courier New", 11), new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + (int)fontHeight;

            string address2 = "    Paints & Construction Supplies".PadRight(10);
            graphic.DrawString(address2, new Font("Courier New", 11), new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + (int)fontHeight;

            string address3 = "     Purok 1 National Hi-way".PadRight(10);
            graphic.DrawString(address3, new Font("Courier New", 11), new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + (int)fontHeight;

            string address4 = "     Banlic Cabuyao Laguna".PadRight(10);
            graphic.DrawString(address4, new Font("Courier New", 11), new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + (int)fontHeight;

            string address5 = "     ANDY S. ANG - PROP VAT".PadRight(10);
            graphic.DrawString(address5, new Font("Courier New", 11), new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + (int)fontHeight;

            string address6 = "     Reg. TIN 261-551-382-000".PadRight(10);
            graphic.DrawString(address6, new Font("Courier New", 11), new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + (int)fontHeight;

            //string telno = "        Tel No: (000)0000000".PadRight(10);
            //graphic.DrawString(telno, new Font("Courier New", 11), new SolidBrush(Color.Black), startX, startY + offset);
            //offset = offset + (int)fontHeight;

            string celno = "Tel/Nos:(049) 502-7703 * (049) 304-3006".PadRight(10);
            graphic.DrawString(celno, new Font("Courier New", 11), new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + (int)fontHeight;




            offset = offset + (int)fontHeight; //make the spacing consistent
            graphic.DrawString("------------------------------------", font, new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + (int)fontHeight + 5; //make the spacing consistent



            foreach (string items in listBox1.Items)
            {
                //create the string to print on the reciept
                string productDescription = items;
                string productTotal = items;
                double productPrice = float.Parse(txtTotal.Text.PadRight(30));

                //MessageBox.Show(item.Substring(item.Length - 5, 5) + "PROD TOTAL: " + productTotal);




                if (productDescription.Contains("  -"))
                {
                    string productLine = productDescription.Substring(0, 24);

                    graphic.DrawString(productLine, new Font("Courier New", 8, FontStyle.Italic), new SolidBrush(Color.Red), startX, startY + offset);

                    offset = offset + (int)fontHeight + 5; //make the spacing consistent
                }
                else
                {
                    string productLine = productDescription;

                    graphic.DrawString(productLine, new Font("Courier New", 9, FontStyle.Italic), new SolidBrush(Color.Black), startX, startY + offset);

                    offset = offset + (int)fontHeight + 5; //make the spacing consistent
                }

            }

            _change = (cash - totalprice);

            offset = offset + 20;


            string totalitem = "Total Items(" + countitems + ")".PadRight(10);
            graphic.DrawString(totalitem, new Font("Courier New", 11), new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + 20;

            //make some room so that the total stands out.
            //when we have drawn all of the items add the total
            //TotalPrice
            if (txtCash.Text.Length >= 9)
            {
                graphic.DrawString("Total Amount ".PadRight(25) + String.Format("\u20B1{0} ", totalprice), new Font("Courier New", 12, FontStyle.Bold), new SolidBrush(Color.Black), startX, startY + offset);

                offset = offset + 30;

                graphic.DrawString("CASH ".PadRight(25) + String.Format("\u20B1{0} ", cash), font, new SolidBrush(Color.Black), startX, startY + offset);
                offset = offset + 18;
                graphic.DrawString("CHANGE ".PadRight(25) + String.Format("\u20B1{0} ", _change), font, new SolidBrush(Color.Black), startX, startY + offset);
                offset = offset + 18; //make some room so that the total stands out.
                graphic.DrawString("Vat(12%) ".PadRight(25) + String.Format("\u20B1{0} ", vat12), font, new SolidBrush(Color.Black), startX, startY + offset);
                offset = offset + 18; //make some room so that the total stands out.
                graphic.DrawString("Vatable ".PadRight(25) + String.Format("\u20B1{0} ", vatable), font, new SolidBrush(Color.Black), startX, startY + offset);
                offset = offset + 5; //make some room so that the total stands out.
            }
            else if (txtCash.Text.Length >= 6)
            {
                graphic.DrawString("Total Amount ".PadRight(28) + String.Format("\u20B1{0} ", totalprice), new Font("Courier New", 12, FontStyle.Bold), new SolidBrush(Color.Black), startX, startY + offset);

                offset = offset + 30;

                graphic.DrawString("CASH ".PadRight(28) + String.Format("\u20B1{0} ", cash), font, new SolidBrush(Color.Black), startX, startY + offset);
                offset = offset + 18;
                graphic.DrawString("CHANGE ".PadRight(28) + String.Format("\u20B1{0} ", _change), font, new SolidBrush(Color.Black), startX, startY + offset);
                offset = offset + 18; //make some room so that the total stands out.
                graphic.DrawString("Vat(12%) ".PadRight(28) + String.Format("\u20B1{0} ", vat12), font, new SolidBrush(Color.Black), startX, startY + offset);
                offset = offset + 18; //make some room so that the total stands out.
                graphic.DrawString("Vatable ".PadRight(28) + String.Format("\u20B1{0} ", vatable), font, new SolidBrush(Color.Black), startX, startY + offset);
                offset = offset + 5; //make some room so that the total stands out.
            }
            else if (txtCash.Text.Length < 6)
            {
                graphic.DrawString("Total Amount ".PadRight(30) + String.Format("\u20B1{0} ", totalprice), new Font("Courier New", 12, FontStyle.Bold), new SolidBrush(Color.Black), startX, startY + offset);

                offset = offset + 30;

                graphic.DrawString("CASH ".PadRight(30) + String.Format("\u20B1{0} ", cash), font, new SolidBrush(Color.Black), startX, startY + offset);
                offset = offset + 18;
                graphic.DrawString("CHANGE ".PadRight(30) + String.Format("\u20B1{0} ", _change), font, new SolidBrush(Color.Black), startX, startY + offset);
                offset = offset + 18; //make some room so that the total stands out.
                graphic.DrawString("Vat(12%) ".PadRight(30) + String.Format("\u20B1{0} ", vat12), font, new SolidBrush(Color.Black), startX, startY + offset);
                offset = offset + 18; //make some room so that the total stands out.
                graphic.DrawString("Vatable ".PadRight(30) + String.Format("\u20B1{0} ", vatable), font, new SolidBrush(Color.Black), startX, startY + offset);
                offset = offset + 5; //make some room so that the total stands out.
            }
            // Spacing   

            offset = offset + (int)fontHeight; //make the spacing consistent
            graphic.DrawString("------------------------------------", font, new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + (int)fontHeight + 20; //make the spacing consistent

            if (txtWelcome.Visible == true)
            {
                string name = "Name of Seller: " + txtWelcome.Text + "".PadRight(10);
                graphic.DrawString(name, new Font("Courier New", 11), new SolidBrush(Color.Black), startX, startY + offset);
                offset = offset + (int)fontHeight + 5;
            }
            else
            {
                string name = "Name of Seller:" + txtWelcome.Text.PadRight(10);
                graphic.DrawString(name, new Font("Courier New", 11), new SolidBrush(Color.Black), startX, startY + offset);
                offset = offset + (int)fontHeight + 5;
            }

            string invoiceno = "Invoice No: " + txtnum.Text + "".PadRight(10);
            graphic.DrawString(invoiceno, new Font("Courier New", 11), new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + (int)fontHeight + 5;

            string Date = "Date: " + DateTime.Now.ToShortDateString() + "".PadRight(10);
            graphic.DrawString(Date, new Font("Courier New", 11), new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + (int)fontHeight + 5;

            string Time = "Time: " + DateTime.Now.ToShortTimeString() + "".PadRight(10);
            graphic.DrawString(Time, new Font("Courier New", 11), new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + (int)fontHeight + 50;


            graphic.DrawString("     Thank you for Shopping!,", font, new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + 18;
            graphic.DrawString("           Come Again!", font, new SolidBrush(Color.Black), startX, startY + offset);
        }

        private void txtWelcome_TextChanged(object sender, EventArgs e)
        {
            if (txtWelcome.Visible == true)
            {
                getnameofseller();
            }
        }

        private void metroGrid3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cmbProductName.Text = metroGrid3.CurrentRow.Cells["ProductName"].Value.ToString();
        }

        private void Testing_Tick(object sender, EventArgs e)
        {
            try
            {
                l3.Text = DateTime.Now.ToString("dddd"); l4.Text = DateTime.Now.ToString("dd/M/yyyy"); clock.Value = Convert.ToInt32(l3.Text);

            }
            catch (Exception)
            {
                return;
            }
        }

        private void MOVING_Tick_1(object sender, EventArgs e)
        {
            label5.Location = new Point(label5.Location.X + 5, label5.Location.Y);

            if (label5.Location.X > this.Width)
            {
                label5.Location = new Point(0 - label5.Width, label5.Location.Y);
            }
        }

        private void picMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void bunifuCheckbox1_OnChange(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbProductName.Text))
            {
                MessageBox.Show("Please select product first", "Important", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                bunifuCheckbox1.Checked = false;
            }
            else if (string.IsNullOrEmpty(txtQuantity.Text))
            {
                MessageBox.Show("Please input quantity first", "Important", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                bunifuCheckbox1.Checked = false;
            }
            else
            {
                if (bunifuCheckbox1.Checked == true)
                {
                    bunifuCheckbox2.Enabled = false;
                    decimal total = Convert.ToDecimal(txtSubTotal.Text);
                    //decimal test = Convert.ToDecimal(lblvat.Text);
                    decimal aa = Convert.ToDecimal(0.05) * total;
                    decimal cc = total - aa;
                    txtSubTotal.Text = Convert.ToString(String.Format("{0:0.00}", cc));
                }
                else
                {
                    bunifuCheckbox2.Enabled = true;
                    txtQuantity.Text = "";
                }
            }

        }

        private void bunifuCheckbox2_OnChange(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbProductName.Text))
            {
                MessageBox.Show("Please select product first", "Important", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                bunifuCheckbox2.Checked = false;
            }
            else if (string.IsNullOrEmpty(txtQuantity.Text))
            {
                MessageBox.Show("Please input quantity first", "Important", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                bunifuCheckbox1.Checked = false;
            }
            else
            {
                if (bunifuCheckbox2.Checked == true)
                {
                    bunifuCheckbox1.Enabled = false;
                    decimal total = Convert.ToDecimal(txtSubTotal.Text);
                    //decimal test = Convert.ToDecimal(lblvat.Text);
                    decimal aa = Convert.ToDecimal(0.10) * total;
                    decimal cc = total - aa;
                    txtSubTotal.Text = Convert.ToString(String.Format("{0:0.00}", cc));
                }
                else
                {
                    bunifuCheckbox1.Enabled = true;
                    txtQuantity.Text = "";
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnaddcash_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void btnnewOrder_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtQuantityinHand_Click(object sender, EventArgs e)
        {

        }

        private void txtQuantityinHand_TextChanged(object sender, EventArgs e)
        {

        }
    }
}