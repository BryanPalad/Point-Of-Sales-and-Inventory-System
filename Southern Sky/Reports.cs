using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using DGVPrinterHelper;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using MetroFramework.Forms;

namespace Southern_Sky
{
    public partial class Reports : MetroForm
    {
        string cn = "Server=localhost;Database=dbpos;Uid=root;Pwd=" + "" + ";";
        public Reports()
        {
            InitializeComponent();
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Reports_Load(object sender, EventArgs e)
        {
            showreport();
            showorders();
            showdefect();
            showfastitems();
            showslowitems();
        }
        private void showslowitems()
        {
            MySqlConnection connection = new MySqlConnection(cn);
            connection.Open();
            try
            {
                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "Select ProductNo,ProductName,Category,Units from product where Quantity >= CriticalLevel1";
                MySqlDataAdapter adap = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adap.Fill(ds);
                metroGrid5.DataSource = ds.Tables[0].DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void showfastitems()
        {
            MySqlConnection connection = new MySqlConnection(cn);
            connection.Open();
            try
            {
                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "Select ProductNo,ProductName,Category,Units from product where Quantity <= CriticalLevel1;";
                MySqlDataAdapter adap = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adap.Fill(ds);
                metroGrid4.DataSource = ds.Tables[0].DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void showdefect()
        {
            MySqlConnection connection = new MySqlConnection(cn);
            connection.Open();
            try
            {
                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT * FROM `defect` ";
                MySqlDataAdapter adap = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adap.Fill(ds);
                metroGrid3.DataSource = ds.Tables[0].DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void showorders()
        {
            MySqlConnection connection = new MySqlConnection(cn);
            connection.Open();
            try
            {
                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT * FROM `ordereports` ";
                MySqlDataAdapter adap = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adap.Fill(ds);
                metroGrid2.DataSource = ds.Tables[0].DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void showreport()
        {
            MySqlConnection connection = new MySqlConnection(cn);
            connection.Open();
            try
            {
                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT * FROM `reports` ";
                MySqlDataAdapter adap = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adap.Fill(ds);
                metroGrid1.DataSource = ds.Tables[0].DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DateSearch();
        }
        private void DateSearch()
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(cn);
                string cmd = string.Format("Select * from reports where Date between @DateFrom and @DateTo");
                MySqlDataAdapter sda = new MySqlDataAdapter(cmd, connection);
                sda.SelectCommand.Parameters.AddWithValue("@DateFrom", mtDateFrom.Text);
                sda.SelectCommand.Parameters.AddWithValue("@DateTo", metroDateTime4.Text);
                MySqlCommandBuilder mcb = new MySqlCommandBuilder(sda);
                connection.Open();
                DataSet dt = new DataSet();
                sda.Fill(dt);
                metroGrid1.DataSource = dt.Tables[0].DefaultView;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnprint_Click(object sender, EventArgs e)
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
            DGVPrinter print = new DGVPrinter();
            print.Title = "Sales Report";
            print.SubTitle = string.Format("Dealer of Hardware, Electrical Plumbing \n Paints & Construction Supplier \n Purok 1 National Highway Banlic Cabuyao Laguna \n (049)502-7003 \n Prepared By : ANDY ANG \n" + "Date: {0}\n", DateTime.Now.Date.ToLongDateString());
            print.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            print.PageNumbers = true;
            print.PageNumberInHeader = false;
            print.PorportionalColumns = true;
            print.HeaderCellAlignment = StringAlignment.Near;
            print.Footer = "Southern Sky Hardware and Construction Supply";
            print.FooterSpacing = 15;
            print.printDocument.DefaultPageSettings.Landscape = true;
            print.PrintDataGridView(metroGrid1);
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            panel1.BringToFront();
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            panel2.BringToFront();
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            panel3.BringToFront();
        }

        private void metroGrid2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void bunifuThinButton27_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuThinButton27_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuThinButton24_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuThinButton28_Click(object sender, EventArgs e)
        {
            if (metroGrid3.RowCount == 0)
            {
                MessageBox.Show("Empty", "Important", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                printdatagridview1();
            }
        }
        private void printdatagridview1()
        {
            DGVPrinter print = new DGVPrinter();
            print.Title = "Defect Items Report";
            print.SubTitle = string.Format("Dealer of Hardware, Electrical Plumbing \n Paints & Construction Supplier \n Purok 1 National Highway Banlic Cabuyao Laguna \n (049)502-7003 \n Prepared By : ANDY ANG \n" + "Date: {0}\n", DateTime.Now.Date.ToLongDateString());
            print.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            print.PageNumbers = true;
            print.PageNumberInHeader = false;
            print.PorportionalColumns = true;
            print.HeaderCellAlignment = StringAlignment.Near;
            print.Footer = "Southern Sky Hardware and Construction Supply";
            print.FooterSpacing = 15;
            print.printDocument.DefaultPageSettings.Landscape = true;
            print.PrintDataGridView(metroGrid3);
        }

        private void bunifuThinButton25_Click(object sender, EventArgs e)
        {
            if (metroGrid2.RowCount == 0)
            {
                MessageBox.Show("Empty", "Important", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                printdatagridview2();
            }
        }
        private void printdatagridview2()
        {
            DGVPrinter print = new DGVPrinter();
            print.Title = "Orders Report";
            print.SubTitle = string.Format("Dealer of Hardware, Electrical Plumbing \n Paints & Construction Supplier \n Purok 1 National Highway Banlic Cabuyao Laguna \n (049)502-7003 \n Prepared By : ANDY ANG \n" + "Date: {0}\n", DateTime.Now.Date.ToLongDateString());
            print.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            print.PageNumbers = true;
            print.PageNumberInHeader = false;
            print.PorportionalColumns = true;
            print.HeaderCellAlignment = StringAlignment.Near;
            print.Footer = "Southern Sky Hardware and Construction Supply";
            print.FooterSpacing = 15;
            print.printDocument.DefaultPageSettings.Landscape = true;
            print.PrintDataGridView(metroGrid2);
        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(cn);
                string cmd = string.Format("Select * from ordereports where Date between @DateFrom and @DateTo");
                MySqlDataAdapter sda = new MySqlDataAdapter(cmd, connection);
                sda.SelectCommand.Parameters.AddWithValue("@DateFrom", metroDateTime1.Text);
                sda.SelectCommand.Parameters.AddWithValue("@DateTo", metroDateTime3.Text);
                MySqlCommandBuilder mcb = new MySqlCommandBuilder(sda);
                connection.Open();
                DataSet dt = new DataSet();
                sda.Fill(dt);
                metroGrid2.DataSource = dt.Tables[0].DefaultView;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void bunifuThinButton26_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(cn);
                string cmd = string.Format("Select * from defect where Date between @DateFrom and @DateTo");
                MySqlDataAdapter sda = new MySqlDataAdapter(cmd, connection);
                sda.SelectCommand.Parameters.AddWithValue("@DateFrom", metroDateTime2.Text);
                sda.SelectCommand.Parameters.AddWithValue("@DateTo", metroDateTime5.Text);
                MySqlCommandBuilder mcb = new MySqlCommandBuilder(sda);
                connection.Open();
                DataSet dt = new DataSet();
                sda.Fill(dt);
                metroGrid3.DataSource = dt.Tables[0].DefaultView;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void bunifuThinButton29_Click(object sender, EventArgs e)
        {
            panel4.BringToFront();
        }

        private void bunifuThinButton211_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void bunifuThinButton210_Click(object sender, EventArgs e)
        {

        }

        private void bunifuThinButton213_Click(object sender, EventArgs e)
        {
            panel5.BringToFront();
        }

        private void bunifuThinButton215_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuThinButton212_Click(object sender, EventArgs e)
        {

            if (metroGrid1.RowCount == 0)
            {
                MessageBox.Show("Empty", "Important", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                printdatagridview4();
            }
        }
        private void printdatagridview4()
        {
            DGVPrinter print = new DGVPrinter();
            print.Title = "Slow Selling Items Report";
            print.SubTitle = string.Format("Dealer of Hardware, Electrical Plumbing \n Paints & Construction Supplier \n Purok 1 National Highway Banlic Cabuyao Laguna \n (049)502-7003 \n Prepared By : ANDY ANG \n" + "Date: {0}\n", DateTime.Now.Date.ToLongDateString());
            print.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            print.PageNumbers = true;
            print.PageNumberInHeader = false;
            print.PorportionalColumns = true;
            print.HeaderCellAlignment = StringAlignment.Near;
            print.Footer = "Southern Sky Hardware and Construction Supply";
            print.FooterSpacing = 15;
            print.printDocument.DefaultPageSettings.Landscape = true;
            print.PrintDataGridView(metroGrid4);
        }

        private void bunifuThinButton216_Click(object sender, EventArgs e)
        {
            if (metroGrid1.RowCount == 0)
            {
                MessageBox.Show("Empty", "Important", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                printdatagridview5();
            }
        }
        private void printdatagridview5()
        {
            DGVPrinter print = new DGVPrinter();
            print.Title = "Fast Selling Items Report";
            print.SubTitle = string.Format("Dealer of Hardware, Electrical Plumbing \n Paints & Construction Supplier \n Purok 1 National Highway Banlic Cabuyao Laguna \n (049)502-7003 \n Prepared By : ANDY ANG \n" + "Date: {0}\n", DateTime.Now.Date.ToLongDateString());
            print.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            print.PageNumbers = true;
            print.PageNumberInHeader = false;
            print.PorportionalColumns = true;
            print.HeaderCellAlignment = StringAlignment.Near;
            print.Footer = "Southern Sky Hardware and Construction Supply";
            print.FooterSpacing = 15;
            print.printDocument.DefaultPageSettings.Landscape = true;
            print.PrintDataGridView(metroGrid5);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuThinButton214_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(cn);
                DataTable dt = new DataTable();
                string sql = "Select * from product WHERE ProductName LIKE '%" + textBox2.Text + "%' or Category LIKE '%" + textBox2.Text + "%' or Units LIKE '%" + textBox2.Text + "%' order by ProductName";
                MySqlDataAdapter da = new MySqlDataAdapter(sql, connection);
                da.Fill(dt);
                metroGrid4.DataSource = dt;
            }
            catch (Exception)
            {
                MessageBox.Show("Test");
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(cn);
                DataTable dt = new DataTable();
                string sql = "Select * from product WHERE ProductName LIKE '%" + textBox1.Text + "%' or Category LIKE '%" + textBox1.Text + "%' or Units LIKE '%" + textBox1.Text + "%' order by ProductName";
                MySqlDataAdapter da = new MySqlDataAdapter(sql, connection);
                da.Fill(dt);
                metroGrid5.DataSource = dt;
            }
            catch (Exception)
            {
                MessageBox.Show("Test");
            }

        }
    }
}