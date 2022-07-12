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

namespace Southern_Sky
{
    public partial class ADDPRODUCT : MetroForm
    {
        string cn = "Server=localhost;Database=dbpos;Uid=root;Pwd=" + "" + ";";
        public string username = LOGIN.Username;
        public ADDPRODUCT()
        {
            InitializeComponent();
        }
        private void reset()
        {
            txtProductName.Text = "";
            cmbCategory.SelectedIndex = -1;
            cmbunits.SelectedIndex = -1;
        }
        private void randomnumbers()
        {
            var randomNumbers = new List<int>();
            var randomGenerator = new Random();
            int initialCount = 1;

            for (int i = 0; i <= 5; i++)
            {
                while (initialCount <= 5)
                {
                    int num = randomGenerator.Next(1000, 999999);
                    if (!randomNumbers.Contains(num))
                    {
                        randomNumbers.Add(num);
                        initialCount++;
                    }
                }
            }
            randomNumbers.Sort();
            randomNumbers.ForEach(x => txtProductNo.Text = x.ToString());
        }
        private void btnadd_Click(object sender, EventArgs e)
        {
            ItemExist2();
        }

        private void ItemExist2()
        {
            MySqlConnection connection = new MySqlConnection(cn);
            MySqlCommand cmd;
            connection.Open();
            try
            {
                cmd = connection.CreateCommand();
                cmd.CommandText = "Select productname from product where productname = @ProductName";
                cmd.Parameters.AddWithValue("@ProductName", txtProductName.Text);
                MySqlDataReader ProductExist = cmd.ExecuteReader();


                if (ProductExist.HasRows)
                {
                    MessageBox.Show("Product " + txtProductName.Text + " Exist Already in Inventory", "Product Name Exist", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                else
                {
                    ItemExist();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void ItemExist()
        {
            MySqlConnection connection = new MySqlConnection(cn);
            MySqlCommand cmd;
            connection.Open();
            try
            {
                cmd = connection.CreateCommand();
                cmd.CommandText = "Select productname from addproduct where productname = @ProductName";
                cmd.Parameters.AddWithValue("@ProductName", txtProductName.Text);
                cmd.Parameters.AddWithValue("@ProductName1", txtProductName.Text);
                MySqlDataReader ProductExist = cmd.ExecuteReader();


                if (ProductExist.HasRows)
                {
                    MessageBox.Show("Product " + txtProductName.Text + " Exist Already just modify this.", "Product Name Exist", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                else
                {
                    CheckUnavailableTable();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void CheckUnavailableTable()
        {
            MySqlConnection connection = new MySqlConnection(cn);
            MySqlCommand cmd;
            connection.Open();
            try
            {
                cmd = connection.CreateCommand();
                cmd.CommandText = "Select productname from unavailable where productname = @ProductName1";
                cmd.Parameters.AddWithValue("@ProductName1", txtProductName.Text);
                MySqlDataReader ProductExist = cmd.ExecuteReader();


                if (ProductExist.HasRows)
                {
                    MessageBox.Show("Product " + txtProductName.Text + " Exist Already in Unavailable, Active this if you want.", "Product Name Exist", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                else
                {
                    AddProduct();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void AddProduct()
        {
            MySqlConnection connection = new MySqlConnection(cn);
            MySqlCommand cmd;
            connection.Open();
            if (string.IsNullOrEmpty(txtProductName.Text) || string.IsNullOrEmpty(cmbCategory.Text))
            {
                MessageBox.Show("Please fill the product information", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    cmd = connection.CreateCommand();
                    cmd.CommandText = "INSERT INTO addproduct(ProductNo,ProductName,Category,Units) values (@ProductNo,@ProductName,@Category,@Units)";
                    cmd.Parameters.AddWithValue("@ProductNo", txtProductNo.Text);
                    cmd.Parameters.AddWithValue("@ProductName", txtProductName.Text);
                    cmd.Parameters.AddWithValue("@Category", cmbCategory.Text);
                    cmd.Parameters.AddWithValue("@Units", cmbunits.Text);

                    cmd.ExecuteNonQuery();
                    if (connection.State == ConnectionState.Open)
                    {
                        connection.Close();
                        MessageBox.Show("Successfully Added Product " + txtProductName.Text + ", Go Order it from the supplier.", "Product Added", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        randomnumbers();
                        saveaudit();
                        reset();
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private void saveaudit()
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
                cmd.Parameters.AddWithValue("@Access", "The Administrator add product'" + txtProductName.Text + "'");

                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                MetroFramework.MetroMessageBox.Show(this, ex.Message);
            }
        }
        private void frmproduct_Load(object sender, EventArgs e)
        {
            randomnumbers();
            getcategory();
            txtuser.Text = username;
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

        private void btncancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtProductName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals(Convert.ToChar(13)))
            {
                btnadd_Click(sender, e);
            }
        }

        private void txtProductName_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                MessageBox.Show("Right Clicked is Disabled", "Disabled");
            }
        }

        private void txtProductName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control == true)
            {
                MessageBox.Show("Cut/Copy and Paste Option is Disabled", "Disabled");
            }  
        }

        private void ADDPRODUCT_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
        private void categoryaudit()
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
                cmd.Parameters.AddWithValue("@Access", "The Administrator add'" + txtadd.Text + "' to categories");

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
            CategoryExist();
        }
        private void CategoryExist()
        {
            MySqlConnection connection = new MySqlConnection(cn);
            MySqlCommand cmd;
            connection.Open();
            try
            {
                cmd = connection.CreateCommand();
                cmd.CommandText = "Select * from categories where category = @cat";
                cmd.Parameters.AddWithValue("@cat", txtadd.Text);
                MySqlDataReader Exist = cmd.ExecuteReader();

                if (Exist.HasRows)
                {
                    MessageBox.Show("Category " + txtadd.Text + " already exist .", "Category Exist", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtadd.ResetText();
                }
                else
                {
                    AddCategory();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void AddCategory()
        {
            MySqlConnection connection = new MySqlConnection(cn);
            MySqlCommand cmd;
            connection.Open();

            if (string.IsNullOrEmpty(txtadd.Text))
            {
                MessageBox.Show("Please fill the category textbox", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                var a = MessageBox.Show("Are you sure you want to add this category?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(a == DialogResult.Yes)
                try
                {
                    cmd = connection.CreateCommand();
                    cmd.CommandText = "INSERT INTO categories(Number,Category) values (@Number,@Category)";
                    cmd.Parameters.AddWithValue("@Number", null);
                    cmd.Parameters.AddWithValue("@Category", txtadd.Text);

                    cmd.ExecuteNonQuery();
                    if (connection.State == ConnectionState.Open)
                    {
                        connection.Close();
                        MessageBox.Show("Successfully Added Category " + txtadd.Text + ".", "Category Added", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        categoryaudit();
                        txtadd.ResetText();
                        
                        getcategory();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private void label4_Click(object sender, EventArgs e)
        {
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            string time = DateTime.Now.ToLongTimeString();
            lblTime.Text = time;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtadd_TextChanged(object sender, EventArgs e)
        {

        }
    }
}