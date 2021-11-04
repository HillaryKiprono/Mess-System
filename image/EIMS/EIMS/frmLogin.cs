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

namespace EIMS
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            gboLogin.Left = (this.Width - gboLogin.Width) / 2;
            gboLogin.Top = (this.Height - gboLogin.Height) / 2;
            txtUsername.Focus();
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtUsername.Text = "";
            txtPassword.Text = "";
            txtUsername.Focus();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text == "")
            {
                MessageBox.Show("Ensure all fields are filled!", "EIMS Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUsername.Focus();
                
            }
            else if (txtPassword.Text == "")
            {
                MessageBox.Show("Ensure all fields are filled!", "EIMS Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Focus();

            }
            else
            {
                try
                {
                    conn connect = new conn();
                    string query = "SELECT * FROM  user WHERE  Username='" + txtUsername.Text.ToString() + "' AND Passsword='" + txtPassword.Text.ToString() + "' AND Status=1";
                    //open connection
                    if (connect.OpenConnection() == true)
                    {
                        //create command and assign the query and connection from the constructor
                        MySqlCommand cmd = new MySqlCommand(query, connect.connection);
                        MySqlDataReader dataReader = cmd.ExecuteReader();

                        //Read the data and store them in the list
                        if (dataReader.Read())
                        {
                            dashboard das = new dashboard();
                            das.Visible = true;
                            this.Hide();
                        }
                        else
                        {
                            txtUsername.Text = "";
                            txtPassword.Text = "";
                            txtUsername.Focus();
                            MessageBox.Show("Password/Username Mismatch!");

                        }
                        connect.CloseConnection();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("" + ex);
                }
                

            }
        }
    }
}
