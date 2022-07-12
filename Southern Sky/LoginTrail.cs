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
    public partial class LoginTrail : MetroForm
    {
        string cn = "Server=localhost;Database=dbpos;Uid=root;Pwd=" + "" + ";";
        public LoginTrail()
        {
            InitializeComponent();
        }

        private void metroGrid1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtID.Text = metroGrid1.CurrentRow.Cells["ID"].Value.ToString();
        }

        private void LoginTrail_Load(object sender, EventArgs e)
        {
            show();
        }
        private void show()
        {
            MySqlConnection connection = new MySqlConnection(cn);
            connection.Open();
            try
            {
                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT * FROM `trackerlog` ";
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

        private void btndeleteall_Click(object sender, EventArgs e)
        {
            DeleteAll();
            show();
        }
        private void DeleteAll()
        {
            MySqlConnection connection = new MySqlConnection(cn);
            MySqlDataAdapter da = new MySqlDataAdapter();
            connection.Open();
            DialogResult dg = MessageBox.Show("Are you sure you want to Delete All?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dg == DialogResult.Yes)
            {
                try
                {
                    da.DeleteCommand = new MySqlCommand("truncate trackerlog  ;", connection);

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
        }
        /* public void DateFrom()
       {
           try
           {
               MySqlConnection connection = new MySqlConnection(cn);
               string cmd = string.Format("Select * from trackerlog where Date=@Date");
               MySqlDataAdapter sda = new MySqlDataAdapter(cmd, connection);
               sda.SelectCommand.Parameters.AddWithValue("@Date", mtDateFrom.Text);
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
       } */
        public void DateSearch()
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(cn);
                string cmd = string.Format("Select * from trackerlog where Date = @DateFrom ");
                MySqlDataAdapter sda = new MySqlDataAdapter(cmd, connection);
                sda.SelectCommand.Parameters.AddWithValue("@DateFrom", mtDateFrom.Text);
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

        private void LoginTrail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = new MySqlConnection(cn);
            MySqlDataAdapter da = new MySqlDataAdapter();
            connection.Open();
            DialogResult dg = MessageBox.Show("Are you sure you want to Delete?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dg == DialogResult.Yes)
            {
                try
                {
                    // int userdetailsID = Convert.ToInt32(txtID.Text);
                    da.DeleteCommand = new MySqlCommand("delete from trackerlog where ID=" + txtID.Text + ";", connection);


                    da.DeleteCommand.ExecuteNonQuery();

                    MessageBox.Show("Successfully Deleted Log ", "Log Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    show();

                }
                catch (Exception)
                {
                    MessageBox.Show("Please Select Row to Deleted", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DateSearch();
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
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
            print.Title = "Login/Logout Trail";
            print.SubTitle = string.Format("Date: {0}", DateTime.Now.Date.ToLongDateString());
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
    }
}
