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
using CrystalDecisions.CrystalReports.Engine;

namespace Southern_Sky
{
    public partial class Form1 : MetroForm
    {
        public Form1()
        {
            InitializeComponent();
        }
        ReportDocument crystal = new ReportDocument();
        string cn = "Server=localhost;Database=dbpos;Uid=root;Pwd=" + "" + ";";
        private void Form1_Load(object sender, EventArgs e)
        {
            oo();
        }
        private void oo()
        {
            try
            {
                DataTable dst = new DataTable();
                MySqlDataAdapter adapt = new MySqlDataAdapter("select * from rep ", cn);
                adapt.Fill(dst);
                crystal.Load(@"C:\Users\fixfone m\Desktop\SKY SYSTEM\Southern Sky\Report.rpt");
                crystal.SetDataSource(dst);
                crystalReportViewer1.ReportSource = crystal;
                crystalReportViewer1.Refresh();
            }
            catch
            {
                MessageBox.Show("Cannot Find Purchase Orders");
            }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //MySqlConnection connection = new MySqlConnection(cn);
            //MySqlDataAdapter da = new MySqlDataAdapter();
            //connection.Open();

            //try
            //{
            //    da.DeleteCommand = new MySqlCommand("truncate tableorder  ;", connection);

            //    da.DeleteCommand.ExecuteNonQuery();

            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
            //finally
            //{
            //    if (connection.State == ConnectionState.Open)
            //    {
            //        connection.Close();
                    this.Close();
                    

                }
            }
        }
//    }
//}