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
using DGVPrinterHelper;

namespace Southern_Sky
{
    public partial class PURCHASEORDER : MetroForm
    {
        string cn = "Server=localhost;Database=dbpos;Uid=root;Pwd= " + "" + ";";
        public PURCHASEORDER()
        {
            InitializeComponent();
        }

        private void metroGrid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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
        private void PURCHASEORDER_Load(object sender, EventArgs e)
        {
            show1();
            showmo();
            //show2();
            //po();

        }
        //private void savepo()
        //{
        //    MySqlConnection connection = new MySqlConnection(cn);
        //    MySqlCommand cmd;
        //    connection.Open();

        //    try
        //    {
        //        cmd = connection.CreateCommand();
        //        cmd.CommandText = "INSERT INTO po(PoNo) values (@Number)";
        //        cmd.Parameters.AddWithValue("@Number", txtnum.Text);

        //        cmd.ExecuteNonQuery();
        //        if (connection.State == ConnectionState.Open)
        //        {
        //            connection.Close();
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}
        //private void po()
        //{
        //    MySqlConnection connection = new MySqlConnection(cn);
        //    MySqlCommand cmd = new MySqlCommand("SELECT max(PoNo) + 1 as 'Pnumber' FROM  po");
        //    cmd.CommandType = CommandType.Text;
        //    cmd.Connection = connection;
        //    cmd.Connection = connection;
        //    connection.Open();


        //    try
        //    {
        //        MySqlDataReader dr = cmd.ExecuteReader();
        //        while (dr.Read())
        //        {

        //            txtnum.Text = dr.GetString("Pnumber");
        //        }
        //        dr.Close();
        //    }
        //    catch (Exception a)
        //    {
        //        MessageBox.Show(a.Message);
        //    }
        //    finally
        //    {
        //        if (connection.State == ConnectionState.Open)
        //        {
        //            connection.Close();

        //        }
        //    }
        //}
        //private void show2()
        //{
        //    MySqlConnection connection = new MySqlConnection(cn);
        //    MySqlCommand cmd = new MySqlCommand("SELECT suppliercompany FROM  supplierproduct order by suppliercompany;");
        //    cmd.CommandType = CommandType.Text;
        //    cmd.Connection = connection;
        //    cmd.Connection = connection;
        //    connection.Open();


        //    try
        //    {
        //        MySqlDataReader dr = cmd.ExecuteReader();
        //        while (dr.Read())
        //        {

        //            cmbsupplier.Items.Add(dr.GetString("suppliercompany"));
        //        }
        //        dr.Close();
        //    }
        //    catch (Exception a)
        //    {
        //        MessageBox.Show(a.Message);
        //    }
        //    finally
        //    {
        //        if (connection.State == ConnectionState.Open)
        //        {
        //            connection.Close();

        //        }
        //    }

        //}
        private void show1()
        {
            MySqlConnection connection = new MySqlConnection(cn);
            connection.Open();
            try
            {
                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT * FROM `supplierproduct` ";
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
            txtcontact.Text = metroGrid1.CurrentRow.Cells["contact"].Value.ToString();
            txtnum.Text = metroGrid1.CurrentRow.Cells["po"].Value.ToString();

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

        private void bunifuThinButton26_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void bunifuThinButton24_Click(object sender, EventArgs e)
        {
            txtID.ResetText();
            txtsupplier.ResetText();
            txtpno.ResetText();
            txtproduct.ResetText();
            txtcategory.ResetText();
            txtunit.ResetText();
            txtenter.ResetText();
            txtcontact.ResetText();
        }
        private void truncatesupplierproduct()
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(cn);
                MySqlDataAdapter da = new MySqlDataAdapter();
                connection.Open();
                da.DeleteCommand = new MySqlCommand("delete from supplierproduct where Productno ='" + txtpno.Text + "' or Productname='" + txtproduct.Text + "'", connection);
                da.DeleteCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void addtotable()
        {
            MySqlConnection connection = new MySqlConnection(cn);
            MySqlCommand cmd;
            connection.Open();

            try{

            
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
        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = new MySqlConnection(cn);
            MySqlCommand cmd;
            connection.Open();
            if (string.IsNullOrEmpty(txtID.Text))
            {
                MessageBox.Show("Please Select Order Transaction", "Important", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                var a = MessageBox.Show("Are you sure you want to order?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (a == DialogResult.Yes)
                {
                    addtotable();
                    try
                    {
                        cmd = connection.CreateCommand();
                        cmd.CommandText = "INSERT INTO orders(Supplier_id,suppliercompany,Productno,Productname,Category,Units,Quantity,ponumber,contact) VALUES (@id,@supplier,@productno,@productname,@category,@units,@quantity,@po,@contact)";
                        cmd.Parameters.AddWithValue("@id", txtID.Text);
                        cmd.Parameters.AddWithValue("@supplier", txtsupplier.Text);
                        cmd.Parameters.AddWithValue("@productno", txtpno.Text);
                        cmd.Parameters.AddWithValue("@productname", txtproduct.Text);
                        cmd.Parameters.AddWithValue("@category", txtcategory.Text);
                        cmd.Parameters.AddWithValue("@units", txtunit.Text);
                        cmd.Parameters.AddWithValue("@quantity", txtenter.Text);
                        cmd.Parameters.AddWithValue("@po", txtnum.Text);
                        cmd.Parameters.AddWithValue("@contact", txtcontact.Text);

                        cmd.ExecuteNonQuery();
                        
                        if (connection.State == ConnectionState.Open)
                        {
                            connection.Close();
                            MessageBox.Show("Successful", "Order Sent", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            showmo();
                           
                                }
                            }

                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);

                    }
                }
            }
        }
        private void reset()
        {
            txtID.ResetText();
            txtsupplier.ResetText();
            txtpno.ResetText();
            txtproduct.ResetText();
            txtcategory.ResetText();
            txtunit.ResetText();
            txtenter.ResetText();
            txtcontact.ResetText();
        }
        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = new MySqlConnection(cn);
            MySqlDataAdapter da = new MySqlDataAdapter();
            connection.Open();
            if (metroGrid2.Rows.Count == 0)
            {
                MessageBox.Show("There are no orders", "Important", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                DialogResult dg = MessageBox.Show("Are you sure you want to Cancel Order?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dg == DialogResult.Yes)
                {
                    try
                    {
                        // int userdetailsID = Convert.ToInt32(txtID.Text);
                        da.DeleteCommand = new MySqlCommand("truncate tableorder", connection);


                        da.DeleteCommand.ExecuteNonQuery();

                        MessageBox.Show("Orders Canceled ", "Cancel Order", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        show1();
                        showmo();
                        reset();
                        

                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Please Select Row to Deleted", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
               if (cmbsupplier.Text == "Supplier Company")
               {
                   MySqlConnection connection = new MySqlConnection(cn);
                   DataTable dt = new DataTable();
                   string sql = "Select * from supplierproduct WHERE suppliercompany LIKE '%" + txtsearch.Text + "%'";
                   MySqlDataAdapter da = new MySqlDataAdapter(sql, connection);
                   da.Fill(dt);
                   metroGrid1.DataSource = dt;
               }
               else if (cmbsupplier.Text == "Product Name")
               {
                   MySqlConnection connection = new MySqlConnection(cn);
                   DataTable dt = new DataTable();
                   string sql = "Select * from supplierproduct WHERE Productname LIKE '%" + txtsearch.Text + "%'";
                   MySqlDataAdapter da = new MySqlDataAdapter(sql, connection);
                   da.Fill(dt);
                   metroGrid1.DataSource = dt;
               }
               else if (cmbsupplier.Text == "P.O Number")
               {
                   MySqlConnection connection = new MySqlConnection(cn);
                   DataTable dt = new DataTable();
                   string sql = "Select * from supplierproduct WHERE po LIKE '%" + txtsearch.Text + "%'";
                   MySqlDataAdapter da = new MySqlDataAdapter(sql, connection);
                   da.Fill(dt);
                   metroGrid1.DataSource = dt;
               }
               else if (cmbsupplier.Text == "Category")
               {
                   MySqlConnection connection = new MySqlConnection(cn);
                   DataTable dt = new DataTable();
                   string sql = "Select * from supplierproduct WHERE Category LIKE '%" + txtsearch.Text + "%'";
                   MySqlDataAdapter da = new MySqlDataAdapter(sql, connection);
                   da.Fill(dt);
                   metroGrid1.DataSource = dt;
               }
               else if (cmbsupplier.Text == "Units")
               {
                   MySqlConnection connection = new MySqlConnection(cn);
                   DataTable dt = new DataTable();
                   string sql = "Select * from supplierproduct WHERE Units LIKE '%" + txtsearch.Text + "%'";
                   MySqlDataAdapter da = new MySqlDataAdapter(sql, connection);
                   da.Fill(dt);
                   metroGrid1.DataSource = dt;
               }
               else if (cmbsupplier.Text == "Quantity")
               {
                   MySqlConnection connection = new MySqlConnection(cn);
                   DataTable dt = new DataTable();
                   string sql = "Select * from supplierproduct WHERE Quantity LIKE '%" + txtsearch.Text + "%'";
                   MySqlDataAdapter da = new MySqlDataAdapter(sql, connection);
                   da.Fill(dt);
                   metroGrid1.DataSource = dt;
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
                
        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            if (metroGrid2.RowCount == 0)
            {
                MessageBox.Show("Empty", "Important", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Form1 a = new Form1();
                a.ShowDialog();
                
                deletetable();
                showmo();
                //truncatesupplierproduct();
                //show1();
                
            }

            //savepo();
            //po();
        }

        private void printdatagridview()
        {
            DGVPrinter print = new DGVPrinter();
            print.Title = "Purchase Order";
            print.SubTitle = string.Format("Date: {0}", DateTime.Now.Date.ToLongDateString());
            print.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            print.PageNumbers = true;
            print.PageNumberInHeader = false;
            print.PorportionalColumns = true;
            print.HeaderCellAlignment = StringAlignment.Near;
            print.Footer = "Souther Sky Hardware and Construction Supply";
            print.FooterSpacing = 15;
            print.printDocument.DefaultPageSettings.Landscape = true;
            print.PrintDataGridView(metroGrid2);

            show1();
            //show2();
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = new MySqlConnection(cn);
            MySqlDataAdapter da = new MySqlDataAdapter();
            connection.Open();
            DialogResult dg = MessageBox.Show("Are you sure you want to edit quantity?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dg == DialogResult.Yes)
            {
                try
                {
                    da.UpdateCommand = new MySqlCommand("update supplierproduct set Quantity=@quantity where Supplier_id='" + txtID.Text + "';", connection);
                    da.UpdateCommand.Parameters.Add("@quantity", txtenter.Text);




                    da.UpdateCommand.ExecuteNonQuery();


                    MessageBox.Show("Successfully Updated Quantity ", "Quantity Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    show1();
                    errorProvider1.Clear();
                    errorProvider1.Clear();
                    errorProvider1.Clear();

                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
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

                //MessageBox.Show(item.Substring(item.Length - 5, 5) + "PROD TOTAL: " + productTotal);




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
            ////foreach (string items in listBox1.Items)
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
                graphic.DrawString(name, new Font("Courier New", 12, FontStyle.Bold), new SolidBrush(Color.Black), startX, startY + offset);
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

        private void cmbsupplier_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
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
    }
}