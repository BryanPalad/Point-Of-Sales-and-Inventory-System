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
using System.Drawing.Printing;

namespace Southern_Sky
{
    public partial class Orders : MetroForm
    {
        string cn = "Server=localhost;Database=dbpos;Uid=root;Pwd= " + "" + ";";
        public string username = LOGIN.Username;
        public Orders()
        {
            InitializeComponent();
        }

        private void Orders_Load(object sender, EventArgs e)
        {
            showorders();
            showmo();
        }
        private void showmo()
        {
            MySqlConnection connection = new MySqlConnection(cn);
            connection.Open();
            try
            {
                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT * FROM `tableorder` ";
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
        private void showorders()
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
            txtcontact.Text = metroGrid1.CurrentRow.Cells["contact"].Value.ToString();

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

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        private void insertmodifyall()
        {
            MySqlConnection connection = new MySqlConnection(cn);
            MySqlCommand cmd;
            connection.Open();

            try
            {
                cmd = connection.CreateCommand();
                cmd.CommandText = "INSERT INTO modify (ProductNo,Productname,Category,Units,Quantity) VALUES (@productno,@productname,@category,@units,@quantity)";
                cmd.Parameters.AddWithValue("@productno", txtpno.Text);
                cmd.Parameters.AddWithValue("@productname", txtproduct.Text);
                cmd.Parameters.AddWithValue("@category", txtcategory.Text);
                cmd.Parameters.AddWithValue("@units", txtunit.Text);
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
        private void insertmodify()
        {
            MySqlConnection connection = new MySqlConnection(cn);
            MySqlCommand cmd;
            connection.Open();

            try
            {
                cmd = connection.CreateCommand();
                cmd.CommandText = "INSERT INTO modify (ProductNo,Productname,Category,Units,Quantity) VALUES (@productno,@productname,@category,@units,@quantity)";
                cmd.Parameters.AddWithValue("@productno", txtpno.Text);
                cmd.Parameters.AddWithValue("@productname", txtproduct.Text);
                cmd.Parameters.AddWithValue("@category", txtcategory.Text);
                cmd.Parameters.AddWithValue("@units", txtunit.Text);
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
                    receiveaudit();

                    int get = Convert.ToInt32(txtget.Text);
                    int qty = Convert.ToInt32(txtenter.Text);
                    if (qty >= get)
                    {
                        MySqlConnection connection = new MySqlConnection(cn);
                        MySqlDataAdapter da = new MySqlDataAdapter();
                        connection.Open();

                        da.UpdateCommand = new MySqlCommand("UPDATE orders set Quantity = (Quantity - '" + get + "') where productname = '" + txtproduct.Text + "';", connection);
                        da.UpdateCommand.ExecuteNonQuery();

                        MessageBox.Show("Successfully Get Item/s", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        insertmodify();
                        ordereports();
                        showorders();
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
                da.DeleteCommand = new MySqlCommand("delete from orders where Productno ='" + txtpno.Text + "' or Productname ='" + txtproduct.Text + "'", connection);
                da.DeleteCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
        private void truncatesupplierproduct()
        {
            try
            {


                MySqlConnection connection = new MySqlConnection(cn);
                MySqlDataAdapter da = new MySqlDataAdapter();
                connection.Open();
                da.DeleteCommand = new MySqlCommand("delete from supplierproduct where Productno ='" + txtpno.Text + "' or Productname ='" + txtproduct.Text + "'", connection);
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
                    receiveallaudit();
                    int qty = Convert.ToInt32(txtenter.Text);

                    MySqlConnection connection = new MySqlConnection(cn);
                    MySqlDataAdapter da = new MySqlDataAdapter();
                    connection.Open();

                    da.UpdateCommand = new MySqlCommand("UPDATE orders set Quantity = (Quantity - '" + qty + "') where productname = '" + txtproduct.Text + "';", connection);
                    da.UpdateCommand.ExecuteNonQuery();



                    MessageBox.Show("Successfully Get all Item/s", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ordereports1();
                    insertmodifyall();
                    truncate();
                    truncatesupplierproduct();
                    showorders();
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
        private void addtotable()
        {
            MySqlConnection connection = new MySqlConnection(cn);
            MySqlCommand cmd;
            connection.Open();

            try
            {


                cmd = connection.CreateCommand();
                cmd.CommandText = "INSERT INTO tableorder(Productno,Productname,Category,Units,Quantity) VALUES (@productno,@productname,@category,@units,@quantity)";
                cmd.Parameters.AddWithValue("@productno", txtpno.Text);
                cmd.Parameters.AddWithValue("@productname", txtproduct.Text);
                cmd.Parameters.AddWithValue("@category", txtcategory.Text);
                cmd.Parameters.AddWithValue("@units", txtunit.Text);
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
                da.DeleteCommand = new MySqlCommand("delete from orders where Productno ='" + txtpno.Text + "' or Productname='" + txtproduct.Text + "'", connection);
                da.DeleteCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void bunifuThinButton24_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = new MySqlConnection(cn);
            MySqlCommand cmd;
            connection.Open();

            if (string.IsNullOrEmpty(txtsupplier.Text))
            {
                MessageBox.Show("Please select supplier first", "Important", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (string.IsNullOrEmpty(txtenter.Text))
            {
                MessageBox.Show("Please enter quantity first", "Important", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                var a = MessageBox.Show("Are you sure you want to add backorder?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (a == DialogResult.Yes)
                {
                    addtotable();
                    try
                    {
                        cmd = connection.CreateCommand();
                        cmd.CommandText = "INSERT INTO backorder (Supplier_id,suppliercompany,Productno,Productname,Category,Units,Quantity,ponumber) VALUES (@id,@supplier,@productno,@productname,@category,@units,@quantity,@po)";
                        cmd.Parameters.AddWithValue("@id", txtID.Text);
                        cmd.Parameters.AddWithValue("@supplier", txtsupplier.Text);
                        cmd.Parameters.AddWithValue("@productno", txtpno.Text);
                        cmd.Parameters.AddWithValue("@productname", txtproduct.Text);
                        cmd.Parameters.AddWithValue("@category", txtcategory.Text);
                        cmd.Parameters.AddWithValue("@units", txtunit.Text);
                        cmd.Parameters.AddWithValue("@quantity", txtenter.Text);
                        cmd.Parameters.AddWithValue("@po", txtnum.Text);


                        cmd.ExecuteNonQuery();

                        if (connection.State == ConnectionState.Open)
                        {
                            connection.Close();
                            MessageBox.Show("Successful", "Back Ordered", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            showmo();
                                    //truncateorder();
                                    //txtID.ResetText();
                                    //txtsupplier.ResetText();
                                    //txtpno.ResetText();
                                    //txtproduct.ResetText();
                                    //txtcategory.ResetText();
                                    //txtunit.ResetText();
                                    //txtenter.ResetText();
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
            if (metroGrid2.Rows.Count == 0)
            {
                MessageBox.Show("Select Product First", "Important", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                //PrintDialog printDialog = new PrintDialog();
                //PrintDocument printDocument = new PrintDocument();

                //printDialog.Document = printDocument;

                //printDocument.PrintPage += new PrintPageEventHandler(print_PrintPage);

                //DialogResult result = printDialog.ShowDialog();

                //if (result == DialogResult.OK)
                //{
                //    printDocument.Print();
                //}
                //Random randomnum = new Random();
                //int number = randomnum.Next(10000, 999999999);
                //txtnum.Text = number.ToString();
                Form1 a = new Form1();
                a.ShowDialog();
                showorders();
                deletetable();
                showmo();
            }
        }
        private void deletetable()
        {

            MySqlConnection connection = new MySqlConnection(cn);
            MySqlDataAdapter da = new MySqlDataAdapter();
            connection.Open();

            try
            {
                da.DeleteCommand = new MySqlCommand("truncate tableorder  ;", connection);

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


                }
            }
        }
        private void printdatagridview()
        {

            DGVPrinter print = new DGVPrinter();
            print.Title = "Back Order List";
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

            showorders();
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

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "P.O Number")
            {
                MySqlConnection connection = new MySqlConnection(cn);
                DataTable dt = new DataTable();
                string sql = "Select * from orders WHERE ponumber LIKE '%" + txtsearch.Text + "%'";
                MySqlDataAdapter da = new MySqlDataAdapter(sql, connection);
                da.Fill(dt);
                metroGrid1.DataSource = dt;
            }
            else if (comboBox1.Text == "Supplier Company")
            {
                MySqlConnection connection = new MySqlConnection(cn);
                DataTable dt = new DataTable();
                string sql = "Select * from orders WHERE suppliercompany LIKE '%" + txtsearch.Text + "%'";
                MySqlDataAdapter da = new MySqlDataAdapter(sql, connection);
                da.Fill(dt);
                metroGrid1.DataSource = dt;
            }
            else if (comboBox1.Text == "Product Name")
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
            else if (comboBox1.Text == "Units")
            {
                MySqlConnection connection = new MySqlConnection(cn);
                DataTable dt = new DataTable();
                string sql = "Select * from orders WHERE Units LIKE '%" + txtsearch.Text + "%'";
                MySqlDataAdapter da = new MySqlDataAdapter(sql, connection);
                da.Fill(dt);
                metroGrid1.DataSource = dt;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            string time = DateTime.Now.ToLongTimeString();
            lblTime.Text = time;
        }

        private void print_PrintPage(object sender, PrintPageEventArgs e)
        {

            //this prints the reciept

            Graphics graphic = e.Graphics;

            Font font = new Font("Courier New", 12); //must use a mono spaced font as the spaces need to line up

            float fontHeight = font.GetHeight();

            int startX = 5;
            int startY = 5;
            int offset = 60;

            graphic.DrawString("  SOUTHERN SKY CONSTRUCTION SUPPLY", new Font("Century Gothic", 13, FontStyle.Bold), new SolidBrush(Color.Black), startX, startY);
            string address1 = "Dealer of Hardware,Electrical Plumbing".PadRight(10);
            graphic.DrawString(address1, new Font("Century Gothic", 11), new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + (int)fontHeight;

            string address2 = "    Paints & Construction Supplies".PadRight(10);
            graphic.DrawString(address2, new Font("Century Gothic", 11), new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + (int)fontHeight;

            string address3 = "     Purok 1 National Hi-way".PadRight(10);
            graphic.DrawString(address3, new Font("Century Gothic", 11), new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + (int)fontHeight;

            string address4 = "     Banlic Cabuyao Laguna".PadRight(10);
            graphic.DrawString(address4, new Font("Century Gothic", 11), new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + (int)fontHeight;

            string address5 = "     ANDY S. ANG - PROP VAT".PadRight(10);
            graphic.DrawString(address5, new Font("Century Gothic", 11), new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + (int)fontHeight;

            string address6 = "     Reg. TIN 261-551-382-000".PadRight(10);
            graphic.DrawString(address6, new Font("Century Gothic", 11), new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + (int)fontHeight;

            //string telno = "        Tel No: (000)0000000".PadRight(10);
            //graphic.DrawString(telno, new Font("Courier New", 11), new SolidBrush(Color.Black), startX, startY + offset);
            //offset = offset + (int)fontHeight;

            string celno = "Tel/Nos:(049) 502-7703 * (049) 304-3006".PadRight(10);
            graphic.DrawString(celno, new Font("Century Gothic", 11), new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + (int)fontHeight + 20;



            string top = "Products to Order:".PadRight(13);
            graphic.DrawString(top, new Font("Courier New", 12, FontStyle.Bold), new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + (int)fontHeight; //make the spacing consistent
            graphic.DrawString("------------------------------------", font, new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + (int)fontHeight + 5; //make the spacing consistent


            //foreach (string items in listBox1.Items)
            //{
            //    //create the string to print on the reciept
            //    string productDescription = items;
            //    string productTotal = items;

            //    //MessageBox.Show(item.Substring(item.Length - 5, 5) + "PROD TOTAL: " + productTotal);




            //    if (productDescription.Contains("  -"))
            //    {
            //        string productLine = productDescription.Substring(0, 24);

            //        graphic.DrawString(productLine, new Font("Courier New", 10, FontStyle.Italic), new SolidBrush(Color.Red), startX, startY + offset);

            //        offset = offset + (int)fontHeight + 5; //make the spacing consistent
            //    }
            //    else
            //    {
            //        string productLine = productDescription;

            //        graphic.DrawString(productLine, new Font("Courier New", 10, FontStyle.Italic), new SolidBrush(Color.Black), startX, startY + offset);

            //        offset = offset + (int)fontHeight + 5; //make the spacing consistent
            //    }

            //}
            //foreach (string items in listBox1.Items)
            //{
            //    //create the string to print on the reciept
            //    string productDescription = items;
            //    string productTotal = items;
            //    double productPrice = float.Parse(txtTotal.Text.PadRight(30));

            //    //MessageBox.Show(item.Substring(item.Length - 5, 5) + "PROD TOTAL: " + productTotal);




            //    if (productDescription.Contains("  -"))
            //    {
            //        string productLine = productDescription.Substring(0, 24);

            //        graphic.DrawString(productLine, new Font("Courier New", 8, FontStyle.Italic), new SolidBrush(Color.Red), startX, startY + offset);

            //        offset = offset + (int)fontHeight + 5; //make the spacing consistent
            //    }
            //    else
            //    {
            //        string productLine = productDescription;

            //        graphic.DrawString(productLine, new Font("Courier New", 9, FontStyle.Italic), new SolidBrush(Color.Black), startX, startY + offset);

            //        offset = offset + (int)fontHeight + 5; //make the spacing consistent
            //    }

            //}

            //_change = (cash - totalprice);

            //offset = offset + 20;


            //string totalitem = "Total Items(" + countitems + ")".PadRight(10);
            //graphic.DrawString(totalitem, new Font("Courier New", 11), new SolidBrush(Color.Black), startX, startY + offset);
            //offset = offset + 20;

            ////make some room so that the total stands out.
            ////when we have drawn all of the items add the total
            ////TotalPrice
            //if (txtCash.Text.Length >= 9)
            //{
            //    graphic.DrawString("Total Amount ".PadRight(25) + String.Format("\u20B1{0} ", totalprice), new Font("Courier New", 12, FontStyle.Bold), new SolidBrush(Color.Black), startX, startY + offset);

            //    offset = offset + 30;

            //    graphic.DrawString("CASH ".PadRight(25) + String.Format("\u20B1{0} ", cash), font, new SolidBrush(Color.Black), startX, startY + offset);
            //    offset = offset + 18;
            //    graphic.DrawString("CHANGE ".PadRight(25) + String.Format("\u20B1{0} ", _change), font, new SolidBrush(Color.Black), startX, startY + offset);
            //    offset = offset + 18; //make some room so that the total stands out.
            //    graphic.DrawString("Vat(12%) ".PadRight(25) + String.Format("\u20B1{0} ", vat12), font, new SolidBrush(Color.Black), startX, startY + offset);
            //    offset = offset + 18; //make some room so that the total stands out.
            //    graphic.DrawString("Vatable ".PadRight(25) + String.Format("\u20B1{0} ", vatable), font, new SolidBrush(Color.Black), startX, startY + offset);
            //    offset = offset + 5; //make some room so that the total stands out.
            //}
            //else if (txtCash.Text.Length >= 6)
            //{
            //    graphic.DrawString("Total Amount ".PadRight(28) + String.Format("\u20B1{0} ", totalprice), new Font("Courier New", 12, FontStyle.Bold), new SolidBrush(Color.Black), startX, startY + offset);

            //    offset = offset + 30;

            //    graphic.DrawString("CASH ".PadRight(28) + String.Format("\u20B1{0} ", cash), font, new SolidBrush(Color.Black), startX, startY + offset);
            //    offset = offset + 18;
            //    graphic.DrawString("CHANGE ".PadRight(28) + String.Format("\u20B1{0} ", _change), font, new SolidBrush(Color.Black), startX, startY + offset);
            //    offset = offset + 18; //make some room so that the total stands out.
            //    graphic.DrawString("Vat(12%) ".PadRight(28) + String.Format("\u20B1{0} ", vat12), font, new SolidBrush(Color.Black), startX, startY + offset);
            //    offset = offset + 18; //make some room so that the total stands out.
            //    graphic.DrawString("Vatable ".PadRight(28) + String.Format("\u20B1{0} ", vatable), font, new SolidBrush(Color.Black), startX, startY + offset);
            //    offset = offset + 5; //make some room so that the total stands out.
            //}
            //else if (txtCash.Text.Length < 6)
            //{
            //    graphic.DrawString("Total Amount ".PadRight(30) + String.Format("\u20B1{0} ", totalprice), new Font("Courier New", 12, FontStyle.Bold), new SolidBrush(Color.Black), startX, startY + offset);

            //    offset = offset + 30;

            //    graphic.DrawString("CASH ".PadRight(30) + String.Format("\u20B1{0} ", cash), font, new SolidBrush(Color.Black), startX, startY + offset);
            //    offset = offset + 18;
            //    graphic.DrawString("CHANGE ".PadRight(30) + String.Format("\u20B1{0} ", _change), font, new SolidBrush(Color.Black), startX, startY + offset);
            //    offset = offset + 18; //make some room so that the total stands out.
            //    graphic.DrawString("Vat(12%) ".PadRight(30) + String.Format("\u20B1{0} ", vat12), font, new SolidBrush(Color.Black), startX, startY + offset);
            //    offset = offset + 18; //make some room so that the total stands out.
            //    graphic.DrawString("Vatable ".PadRight(30) + String.Format("\u20B1{0} ", vatable), font, new SolidBrush(Color.Black), startX, startY + offset);
            //    offset = offset + 5; //make some room so that the total stands out.
            //}
            //// Spacing   

            //offset = offset + (int)fontHeight; //make the spacing consistent
            //graphic.DrawString("------------------------------------", font, new SolidBrush(Color.Black), startX, startY + offset);
            //offset = offset + (int)fontHeight + 20; //make the spacing consistent

            offset = offset + (int)fontHeight; //make the spacing consistent
            graphic.DrawString("------------------------------------", font, new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + (int)fontHeight + 5; //make the spacing consistent

            if (txtsupplier.Visible == true)
            {
                string name = "Supplier Company: " + txtsupplier.Text + "".PadRight(10);
                graphic.DrawString(name, new Font("Courier New", 12,FontStyle.Bold), new SolidBrush(Color.Black), startX, startY + offset);
                offset = offset + (int)fontHeight + 5;
            }
            else
            {
                string name = "Supplier Company:" + txtsupplier.Text.PadRight(10);
                graphic.DrawString(name, new Font("Courier New", 12, FontStyle.Bold), new SolidBrush(Color.Black), startX, startY + offset);
                offset = offset + (int)fontHeight + 5;
            }
            
            string invoiceno = "P.O Number: " + txtnum.Text + "".PadRight(10);
            graphic.DrawString(invoiceno, new Font("Courier New", 12, FontStyle.Bold), new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + (int)fontHeight + 5;

            string num = "Contact No: " + txtcontact.Text + "".PadRight(10);
            graphic.DrawString(num, new Font("Courier New", 12, FontStyle.Bold), new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + (int)fontHeight + 5;

            string Date = "Date: " + DateTime.Now.ToShortDateString() + "".PadRight(10);
            graphic.DrawString(Date, new Font("Courier New", 12, FontStyle.Bold), new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + (int)fontHeight + 5;

            string Time = "Time: " + DateTime.Now.ToShortTimeString() + "".PadRight(10);
            graphic.DrawString(Time, new Font("Courier New", 12, FontStyle.Bold), new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + (int)fontHeight + 10;


           


            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
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