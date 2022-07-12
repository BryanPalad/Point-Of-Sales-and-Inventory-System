using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace Southern_Sky
{
    public partial class CustomizeNotification : Form
    {
        public CustomizeNotification(string _message, AlertType type)
        {
            InitializeComponent();
             message.Text = _message;
            switch (type)
            {
                case AlertType.success:
                    this.BackColor = Color.SeaGreen;
                    btnone.IdleFillColor = Color.FromArgb(124, 209, 249);
                   
                    label2.Text = "Success";
  
                    break;
                case AlertType.info:
                    this.BackColor = Color.Gray;
                    btnone.IdleFillColor = Color.FromArgb(124, 209, 249);
                    
                    label2.Text = "Info";
        
                    break;
                case AlertType.error:
                    this.BackColor = Color.Crimson;
                    btnone.IdleFillColor = Color.FromArgb(124, 209, 249);
                    
                    label2.Text = "Error";
                
                    break;
                case AlertType.warning:
                    this.BackColor = Color.FromArgb(255, 128, 0);
                    btnone.IdleFillColor = Color.FromArgb(124, 209, 249);
                    
                    label2.Text = "Warning";
            
                    break;

            }
        }
        public enum AlertType
        {
            success,warning,error,info,
        }

        private void CustomizeNotification_Load(object sender, EventArgs e)
        {
             trans.Show(icon);
        }
          public static void Show(string message, AlertType type)
        {
            new Southern_Sky.CustomizeNotification(message, type).ShowDialog();         
        }

        private void timeout_Tick(object sender, EventArgs e)
        {
             close.Start();
        }

        private void close_Tick(object sender, EventArgs e)
        {
             if (this.Opacity > 0)
            {
                this.Opacity -= 0.1;
            }
            else
            {
                this.Close();
            }
        }

        

        private void CustomizeNotification_KeyPress(object sender, KeyPressEventArgs e)
        {
             if (e.KeyChar.Equals(Convert.ToChar(13)))
            {
                btnone_Click(sender, e);
            }
        }

        private void btnone_Click(object sender, EventArgs e)
        {
           close.Start();
        }
    }
}
