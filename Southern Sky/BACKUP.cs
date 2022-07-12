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


namespace Southern_Sky
{
    public partial class BACKUP : MetroForm
    {
        public BACKUP()
        {
            InitializeComponent();
        }
        private void BackupDatabase()
        {
             DateTime Time = DateTime.Now;
            int year = Time.Year;
            int month = Time.Month;
            int day = Time.Day;

            string cn = "Server=localhost;Database=dbpos;Uid=root;Pwd= " + "" + ";";
            string file = txtbackuppath.Text + "\\BackupDatabase " + year + "-" + month + "-" + day + ".sql";
            lblstatus.ForeColor = Color.Green;
            lblstatus.Text = "Backing up Database...";
            using (MySqlConnection conn = new MySqlConnection(cn))
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    using (MySqlBackup mb = new MySqlBackup(cmd))
                    {
                        try
                        {
                            cmd.Connection = conn;
                            conn.Open();
                            mb.ExportToFile(file);
                            conn.Close();
                            lblstatus.ForeColor = Color.Green;
                            lblstatus.Text = "Success Backup";
                        }
                        catch (Exception)
                        {
                            lblstatus.ForeColor = Color.Red;
                            lblstatus.Text = "Please select path";
                        }
                    }
                }
            }
        }
            private void RestoreDatabase()
        {
                 string cn = "Server=localhost;Database=Project;Uid=root;Pwd= " + "" + ";";
            string file = txtrestorefile.Text;
            lblstatus.ForeColor = Color.Green;
            lblstatus.Text = "Restoring Database...";
            using (MySqlConnection conn = new MySqlConnection(cn))
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    using (MySqlBackup mb = new MySqlBackup(cmd))
                    {
                        try
                        {
                            cmd.Connection = conn;
                            conn.Open();
                            mb.ImportFromFile(file);
                            conn.Close();
                            lblstatus.ForeColor = Color.Green;
                            lblstatus.Text = "Success Restoring";
                        }
                        catch(Exception)
                        {
                            lblstatus.ForeColor = Color.Red;
                            lblstatus.Text = "Please check the .sql file";
                        }
                    }
                }
            }
        }

        private void btnbackup_Click(object sender, EventArgs e)
        {
            lblstatus.ResetText();
            if (string.IsNullOrEmpty(txtbackuppath.Text))
            {
                lblstatus.ForeColor = Color.Red;
                lblstatus.Text = "Please Select Path";
            }
            else
            {
                BackupDatabase();

            }
        }

        private void btnrestore_Click(object sender, EventArgs e)
        {
             lblstatus.ResetText();
            if (string.IsNullOrEmpty(txtrestorefile.Text))
            {
                lblstatus.ForeColor = Color.Red;
                lblstatus.Text = "Please select .sql file to restore";
            }
            else
            {
                RestoreDatabase();
            }
        }

        private void txtbackuppath_ButtonClick(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                txtbackuppath.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void txtrestorefile_ButtonClick(object sender, EventArgs e)
        {
             if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtrestorefile.Text = openFileDialog1.FileName;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

        
     
