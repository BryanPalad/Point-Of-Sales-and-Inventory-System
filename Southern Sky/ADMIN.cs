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
using DGVPrinterHelper;
using MetroFramework.Forms;
using CustomizeMsgBox;
using Tulpep.NotificationWindow;
using System.Windows.Forms.DataVisualization.Charting;

namespace Southern_Sky
{
    public partial class ADMIN : MetroForm
    {
        string cn = "Server=localhost;Database=dbpos;Uid=root;Pwd= " + "" + ";";
        public string username = LOGIN.Username;

        public ADMIN()
        {
            InitializeComponent();

        }
        private void TrackLogoutAdmin()
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
                cmd.Parameters.AddWithValue("@Userlevel", "Administrator");
                cmd.Parameters.AddWithValue("@Access", "The Administrator '" + username + "' has logged out");
                cmd.Parameters.AddWithValue("@Time", lblTime.Text);

                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                MetroFramework.MetroMessageBox.Show(this, ex.Message);
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            string time = DateTime.Now.ToLongTimeString();
            lblTime.Text = time;
            string seconds = DateTime.Now.ToString("ss");
            clock.Value = Convert.ToInt32(seconds);
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {


        }

        private void btnuser_Click(object sender, EventArgs e)
        {


        }



        private void DATE_Tick(object sender, EventArgs e)
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

        private void btnusermanage_Click(object sender, EventArgs e)
        {



        }

        private void btnpos_Click(object sender, EventArgs e)
        {

        }

        private void btnproduct_Click(object sender, EventArgs e)
        {

        }


        private void btnlogout_Click(object sender, EventArgs e)
        {
            var a = MetroFramework.MetroMessageBox.Show(this, "Are you sure you want to logout?", "LogOut", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (a == DialogResult.Yes)
            {
                MetroFramework.MetroMessageBox.Show(this, "Successfully Log Out", "", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                this.Hide();
                TrackLogoutAdmin();
                LOGIN c = new LOGIN();
                c.Show();

            }
        }

        private void picMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnuser_Click_1(object sender, EventArgs e)
        {

            notifyIcon1.Dispose();

            //paneltransition.Hide(mainpanel);//
            Usermanagement f1 = new Usermanagement();
            f1.ShowDialog();
            //paneltransition.ShowSync(mainpanel);//
            getstocks();
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            productmenu.Show(bunifuFlatButton2, new Point(0, bunifuFlatButton2.Height));
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            notifyIcon1.Dispose();
            paneltransition.Hide(mainpanel);
            this.Hide();
            CASHIER g = new CASHIER();
            g.ShowDialog();
            paneltransition.ShowSync(mainpanel);
            getstocks();

        }

        private void bunifuFlatButton6_Click(object sender, EventArgs e)
        {

        }
        private void getstocks()
        {
            MySqlConnection connection = new MySqlConnection(cn);
            connection.Open();
            try
            {
                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT * FROM `stock`";
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
        private void ADMIN_Load(object sender, EventArgs e)
        {
            getstocks();
            txtWelcome.Text = username;
            show();
            yearlyincome();
            getTotalCount();
            todayincome();
            monthlyincome();
            yesterdayincome();
            radioButton1.Checked = true;
        }
        private void getTotalCount()
        {
            MySqlConnection connection = new MySqlConnection(cn);
            MySqlCommand cmd = new MySqlCommand("SELECT SUM(TotalPrice) AS 'Total Price' FROM sale");
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
                //PopupNotifier popup = new PopupNotifier();
                //popup.Image = Properties.Resources.Info_Popup_50px;
                //popup.TitleText = "Sales";
                //popup.ContentText = "No sale found";
                //popup.Popup();
                notifyIcon1.Visible = true;
                notifyIcon1.Icon = SystemIcons.Information;
                notifyIcon1.BalloonTipTitle = "Sales";
                notifyIcon1.BalloonTipText = "No sale found";
                notifyIcon1.BalloonTipIcon = ToolTipIcon.Error;
                notifyIcon1.ShowBalloonTip(1000);﻿
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }

            }
        }
        private void yesterdayincome()
        {
            MySqlConnection connection = new MySqlConnection(cn);
            MySqlCommand cmd = new MySqlCommand("SELECT SUM(TotalPrice) as 'Total' FROM sale where Date = '" + System.DateTime.Now.AddDays(-1).ToString("yyyy/MM/dd") + "'");
            cmd.CommandType = CommandType.Text;
            cmd.Connection = connection;
            cmd.Connection = connection;
            connection.Open();

            try
            {
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    String gprice = dr["Total"].ToString();

                    Double generatetotalprice = Convert.ToDouble(gprice);

                    txtyesterdayincome.Text = Convert.ToString(String.Format("{0:0.00}", generatetotalprice));

                }
            }
            catch (Exception)
            {
                //PopupNotifier popup = new PopupNotifier();
                //popup.Image = Properties.Resources.Info_Popup_50px;
                //popup.TitleText = "Sales";
                //popup.ContentText = "No yesterday income";
                //popup.Popup();
                notifyIcon1.Visible = true;
                notifyIcon1.Icon = SystemIcons.Exclamation;
                notifyIcon1.BalloonTipTitle = "Sales";
                notifyIcon1.BalloonTipText = "No yesterday income";
                notifyIcon1.BalloonTipIcon = ToolTipIcon.Error;
                notifyIcon1.ShowBalloonTip(1000);﻿
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }

            }
        }
        private void monthlyincome()
        {
            MySqlConnection connection = new MySqlConnection(cn);
            MySqlCommand cmd = new MySqlCommand("SELECT SUM(TotalPrice) as 'Total' FROM sale where Month(Date) = Month('" + System.DateTime.Now.ToString("yyyy/MM/dd") + "')");
            cmd.CommandType = CommandType.Text;
            cmd.Connection = connection;
            cmd.Connection = connection;
            connection.Open();

            try
            {
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    String gprice = dr["Total"].ToString();

                    Double generatetotalprice = Convert.ToDouble(gprice);

                    txtmonthly.Text = Convert.ToString(String.Format("{0:0.00}", generatetotalprice));

                }
            }
            catch (Exception)
            {
                //PopupNotifier popup = new PopupNotifier();
                //popup.Image = Properties.Resources.Info_Popup_50px;
                //popup.TitleText = "Sales";
                //popup.ContentText = "No income this Month";
                //popup.Popup();
                notifyIcon1.Visible = true;
                notifyIcon1.Icon = SystemIcons.Exclamation;
                notifyIcon1.BalloonTipTitle = "Sales";
                notifyIcon1.BalloonTipText = "No income this Month";
                notifyIcon1.BalloonTipIcon = ToolTipIcon.Error;
                notifyIcon1.ShowBalloonTip(1000);﻿
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }

            }
        }
        private void yearlyincome()
        {
            MySqlConnection connection = new MySqlConnection(cn);
            MySqlCommand cmd = new MySqlCommand("SELECT SUM(TotalPrice) as 'Total' FROM sale where YEAR(Date) = YEAR('" + System.DateTime.Now.ToString("yyyy/MM/dd") + "')");
            cmd.CommandType = CommandType.Text;
            cmd.Connection = connection;
            cmd.Connection = connection;
            connection.Open();

            try
            {
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    String gprice = dr["Total"].ToString();

                    Double generatetotalprice = Convert.ToDouble(gprice);

                    txtYearly.Text = Convert.ToString(String.Format("{0:0.00}", generatetotalprice));

                }
            }
            catch (Exception)
            {
                //PopupNotifier popup = new PopupNotifier();
                //popup.Image = Properties.Resources.Info_Popup_50px;
                //popup.TitleText = "Sales";
                //popup.ContentText = "No income this Year";
                //popup.Popup();
                notifyIcon1.Visible = true;
                notifyIcon1.Icon = SystemIcons.Exclamation;
                notifyIcon1.BalloonTipTitle = "Sales";
                notifyIcon1.BalloonTipText = "No income this Year";
                notifyIcon1.BalloonTipIcon = ToolTipIcon.Error;
                notifyIcon1.ShowBalloonTip(1000);﻿
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }

            }
        }
        private void todayincome()
        {

            MySqlConnection connection = new MySqlConnection(cn);
            MySqlCommand cmd = new MySqlCommand("SELECT SUM(TotalPrice) as 'Total' FROM sale where Date = '" + System.DateTime.Now.ToString("yyyy/MM/dd") + "'");
            cmd.CommandType = CommandType.Text;
            cmd.Connection = connection;
            cmd.Connection = connection;
            connection.Open();

            try
            {
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    String gprice = dr["Total"].ToString();

                    Double generatetotalprice = Convert.ToDouble(gprice);

                    txtdateincome.Text = Convert.ToString(String.Format("{0:0.00}", generatetotalprice));

                }
            }
            catch (Exception)
            {
                //PopupNotifier popup = new PopupNotifier();
                //popup.Image = Properties.Resources.Info_Popup_50px;
                //popup.TitleText = "Sales";
                //popup.ContentText = "No income today";
                //popup.Popup();
                notifyIcon1.Visible = true;
                notifyIcon1.Icon = SystemIcons.Exclamation;
                notifyIcon1.BalloonTipTitle = "Sales";
                notifyIcon1.BalloonTipText = "No income today";
                notifyIcon1.BalloonTipIcon = ToolTipIcon.Error;
                notifyIcon1.ShowBalloonTip(1000);﻿
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
                cmd.CommandText = "SELECT * FROM `sale`";
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
        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
        }

        private void productmenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void productmenu_ItemClicked_1(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Text == "Add Product")
            {
                notifyIcon1.Dispose();
                paneltransition.Hide(mainpanel);
                ADDPRODUCT f1 = new ADDPRODUCT();
                f1.ShowDialog();
                paneltransition.ShowSync(mainpanel);
                getstocks();
            }
            if (e.ClickedItem.Text == "Modify Added Product")
            {
                notifyIcon1.Dispose();

                paneltransition.Hide(mainpanel);
                ModifyProduct f1 = new ModifyProduct();
                f1.ShowDialog();
                getstocks();

                paneltransition.ShowSync(mainpanel);
            }
            if (e.ClickedItem.Text == "View/Edit Product")
            {
                notifyIcon1.Dispose();
                paneltransition.Hide(mainpanel);
                ViewProduct f1 = new ViewProduct();
                f1.ShowDialog();
                paneltransition.ShowSync(mainpanel);
                getstocks();
            }
        }

        private void ADMIN_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void btnsettings_Click(object sender, EventArgs e)
        {
            notifyIcon1.Dispose();

            paneltransition.Hide(mainpanel);
            Settings f2 = new Settings();
            f2.ShowDialog();
            paneltransition.ShowSync(mainpanel);
            getstocks();
        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            notifyIcon1.Dispose();

            paneltransition.Hide(mainpanel);
            LoginTrail g2 = new LoginTrail();
            g2.ShowDialog();
            paneltransition.ShowSync(mainpanel);
        }

        private void bunifuFlatButton5_Click(object sender, EventArgs e)
        {
            notifyIcon1.Dispose();

            paneltransition.Hide(mainpanel);
            Reports g2 = new Reports();
            g2.ShowDialog();
            paneltransition.ShowSync(mainpanel);
            getstocks();
        }

        private void bunifuFlatButton6_Click_1(object sender, EventArgs e)
        {
            purchaseorder.Show(bunifuFlatButton6, new Point(0, bunifuFlatButton2.Height));
        }

        private void bunifuFlatButton7_Click(object sender, EventArgs e)
        {
            notifyIcon1.Dispose();

            paneltransition.Hide(mainpanel);
            AuditTrail v2 = new AuditTrail();
            v2.ShowDialog();
            paneltransition.ShowSync(mainpanel);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            chart1.Series["Money"].Points.Clear();
            chart1.Series["Items"].Points.Clear();
            chart1.Series["Category"].Points.Clear();
            chart();
        }
        private void chart()
        {
            MySqlConnection connection = new MySqlConnection(cn);

            string sql = "SELECT ProductName, sum(TotalPrice) as TotalSales from sale group by TotalPrice desc limit 0,6;";
            MySqlCommand cmd = new MySqlCommand(sql, connection);
            MySqlDataReader dr;
            try
            {
                connection.Open();
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    this.chart1.Series["Money"].Points.AddXY(dr.GetString("ProductName"), dr.GetInt64("TotalSales"));
                    this.chart1.Series["Money"]["PixelPointWidth"] = "20";
                    ChartArea CA = chart1.ChartAreas[0];
                    CA.CursorX.IsUserSelectionEnabled = true;
                    CA.CursorX.IsUserEnabled = true;
                    //int firstDataPoint = 0;
                    //int lastDataPointInView = 10;
                    //CA.AxisX.ScaleView.Zoom(firstDataPoint, lastDataPointInView);
                    //CA.AxisX.ScaleView.SizeType = DateTimeIntervalType.Number;
                    //CA.AxisX.ScaleView.Zoomable = false;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            chart1.Series["Money"].Points.Clear();
            chart1.Series["Items"].Points.Clear();
            chart1.Series["Category"].Points.Clear();
            chart2();
        }
        private void chart2()
        {
            MySqlConnection connection = new MySqlConnection(cn);

            string sql = "SELECT ProductName, sum(Quantity) as Quantity from sale group by Quantity desc limit 0,6";
            MySqlCommand cmd = new MySqlCommand(sql, connection);
            MySqlDataReader dr;
            try
            {
                connection.Open();
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    this.chart1.Series["Items"].Points.AddXY(dr.GetString("ProductName"), dr.GetInt64("Quantity"));
                    this.chart1.Series["Items"]["PixelPointWidth"] = "20";
                    ChartArea CA = chart1.ChartAreas[0];
                    CA.CursorX.IsUserSelectionEnabled = true;
                    CA.CursorX.IsUserEnabled = true;
                    //int firstDataPoint = 0;
                    //int lastDataPointInView = 10;
                    //CA.AxisX.ScaleView.Zoom(firstDataPoint, lastDataPointInView);
                    //CA.AxisX.ScaleView.SizeType = DateTimeIntervalType.Number;
                    //CA.AxisX.ScaleView.Zoomable = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            chart1.Series["Money"].Points.Clear();
            chart1.Series["Items"].Points.Clear();
            chart1.Series["Category"].Points.Clear();
            chart3();
        }
        private void chart3()
        {
            MySqlConnection connection = new MySqlConnection(cn);

            string sql = "SELECT Category, count(Category) as Categorys from sale group by Category desc limit 0,6";
            MySqlCommand cmd = new MySqlCommand(sql, connection);
            MySqlDataReader dr;
            try
            {
                connection.Open();
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    this.chart1.Series["Category"].Points.AddXY(dr.GetString("Category"), dr.GetInt64("Categorys"));
                    this.chart1.Series["Category"]["PixelPointWidth"] = "20";
                    ChartArea CA = chart1.ChartAreas[0];
                    CA.CursorX.IsUserSelectionEnabled = true;
                    CA.CursorX.IsUserEnabled = true;
                    //int firstDataPoint = 0;
                    //int lastDataPointInView = 10;
                    //CA.AxisX.ScaleView.Zoom(firstDataPoint, lastDataPointInView);
                    //CA.AxisX.ScaleView.SizeType = DateTimeIntervalType.Number;
                    //CA.AxisX.ScaleView.Zoomable = false;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            DateSearch();
        }
        private void DateSearch()
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(cn);
                string cmd = string.Format("Select * from sale where Date between @DateFrom and @DateTo");
                MySqlDataAdapter sda = new MySqlDataAdapter(cmd, connection);
                sda.SelectCommand.Parameters.AddWithValue("@DateFrom", mtDate.Text);
                sda.SelectCommand.Parameters.AddWithValue("@DateTo", metroDateTime1.Text);
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
            print.SubTitle = string.Format("Date: {0}", DateTime.Now.Date.ToLongDateString());
            print.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            print.PageNumbers = true;
            print.PageNumberInHeader = false;
            print.PorportionalColumns = true;
            print.HeaderCellAlignment = StringAlignment.Near;
            print.Footer = "Southern Sky Construction and Hardware Supply";
            print.FooterSpacing = 15;
            print.printDocument.DefaultPageSettings.Landscape = true;
            print.PrintDataGridView(metroGrid1);
        }

        private void bunifuFlatButton1_Click_1(object sender, EventArgs e)
        {
            orders.Show(bunifuFlatButton1, new Point(0, bunifuFlatButton2.Height));
        }

        private void txtdateincome_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(this.txtdateincome, this.txtdateincome.Text);
        }

        private void txtyesterdayincome_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(this.txtyesterdayincome, this.txtyesterdayincome.Text);
        }

        private void txtmonthly_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(this.txtmonthly, this.txtmonthly.Text);
        }

        private void txtYearly_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(this.txtYearly, this.txtYearly.Text);
        }

        private void Loading_Tick(object sender, EventArgs e)
        {

        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {

            BACKUP f2 = new BACKUP();
            f2.ShowDialog();

        }

        private void purchaseorder_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

            if (e.ClickedItem.Text == "Purchase order")
            {
                notifyIcon1.Dispose();
                paneltransition.Hide(mainpanel);
                PURCHASEORDER f1 = new PURCHASEORDER();
                f1.ShowDialog();
                paneltransition.ShowSync(mainpanel);
                getstocks();
            }
            if (e.ClickedItem.Text == "Add/Update Supplier Info")
            {
                notifyIcon1.Dispose();

                paneltransition.Hide(mainpanel);
                Add_Supplier f1 = new Add_Supplier();
                f1.ShowDialog();
                getstocks();

                paneltransition.ShowSync(mainpanel);
            }
            if (e.ClickedItem.Text == "Manage Supplier")
            {
                notifyIcon1.Dispose();

                paneltransition.Hide(mainpanel);
                SupplierProduct f1 = new SupplierProduct();
                f1.ShowDialog();
                getstocks();

                paneltransition.ShowSync(mainpanel);
            }
        }

        private void purchaseorder_Opening(object sender, CancelEventArgs e)
        {

        }

        private void orders_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Text == "Receive Orders")
            {
                notifyIcon1.Dispose();
                paneltransition.Hide(mainpanel);
                Orders f1 = new Orders();
                f1.ShowDialog();
                paneltransition.ShowSync(mainpanel);
                getstocks();
            }
            if (e.ClickedItem.Text == "Order Stocks")
            {
                notifyIcon1.Dispose();

                paneltransition.Hide(mainpanel);
                ORDERSTOCKS f1 = new ORDERSTOCKS();
                f1.ShowDialog();
                getstocks();

                paneltransition.ShowSync(mainpanel);
            }
            if (e.ClickedItem.Text == "Receive Stocks")
            {
                notifyIcon1.Dispose();

                paneltransition.Hide(mainpanel);
                RECEIVESTOCKS f1 = new RECEIVESTOCKS();
                f1.ShowDialog();
                getstocks();

                paneltransition.ShowSync(mainpanel);
            }
        }
    }
}