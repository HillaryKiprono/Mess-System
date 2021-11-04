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
    public partial class frmUniversity : Form
    {
        string query;
        string uniCode;
        public frmUniversity()
        {
            InitializeComponent();
        }

        private void frmUniversity_Load(object sender, EventArgs e)
        {
            gboUniversity.Left = (this.Width - gboUniversity.Width) / 2;
            gboUniversity.Top = (this.Height - gboUniversity.Height) / 2;

            cboUniversityCode.Visible = false;
            GetUniversityCode();
            gboSearch.Visible = false;
            gboData.Visible = false;
        }
        private void GetUniversityCode()
        {
            conn connect= new conn();
            if (connect.OpenConnection() == true)
            {
                query = "SELECT * FROM university ORDER BY University_Code ASC";
                MySqlCommand cmd = new MySqlCommand(query, connect.connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                //Read the data and store them in the list
                this.cboUniversityCode.Items.Clear();
                while (dataReader.Read())
                {
                    if (dataReader["University_Code"].ToString().Replace(" ", "") != "")
                    {
                        this.cboUniversityCode.Items.Add(dataReader["University_Code"].ToString());
                    }
                }
                connect.CloseConnection();



            }
        }
        private void btnQuit_Click(object sender, EventArgs e)
        {
           
            if (MessageBox.Show("Are you sure you want to exit?", "EIMS Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                this.Dispose();
            }

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            Reset();
        }
        private void Reset()
        {
            txtUniversityCode.Text = "";
            txtUniversityName.Text = "";
            txtLocation.Text = "";
            txtPostalCode.Text = "";
            txtTown.Text = "";
            txtZipCode.Text = "";
            if (cboUniversityCode.Visible == true)
            {
                cboUniversityCode.Focus();
            }
            else
            {
                txtUniversityCode.Focus();
            }
            GetUniversityCode();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtUniversityCode.Text == "" && cboUniversityCode.Visible==false)
            {
                MessageBox.Show("Ensure all fields are filled!", "EIMS Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUniversityCode.Focus();
                
            }
            else if (cboUniversityCode.Text == "" && cboUniversityCode.Visible==true)
            {
                MessageBox.Show("Ensure all fields are filled!", "EIMS Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cboUniversityCode.Focus();
                
            }
            else if (txtUniversityName.Text == "")
            {
                MessageBox.Show("Ensure all fields are filled!", "EIMS Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUniversityName.Focus();

            }
            else if (txtLocation.Text == "")
            {
                MessageBox.Show("Ensure all fields are filled!", "EIMS Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtLocation.Focus();

            }
            else if (txtPostalCode.Text == "")
            {
                MessageBox.Show("Ensure all fields are filled!", "EIMS Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPostalCode.Focus();

            }
            else if (txtTown.Text == "")
            {
                MessageBox.Show("Ensure all fields are filled!", "EIMS Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTown.Focus();

            }
            else if (txtZipCode.Text == "")
            {
                MessageBox.Show("Ensure all fields are filled!", "EIMS Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtZipCode.Focus();

            }
            else
            {
                if (cboUniversityCode.Visible==true)
                {
                    query = "UPDATE university SET University_Code='" + cboUniversityCode.Text + "',University_Name='" + txtUniversityName.Text + "' ,Location='" + txtLocation.Text + "',Postal_Code='" + txtPostalCode.Text + "',Zip_Code='" + txtZipCode.Text + "',Town='" + txtTown.Text + "' WHERE University_Code='"+ uniCode +"'";
                
                }
                else
                {
                    query = "INSERT INTO university(University_Code,University_Name,Location,Postal_Code,Zip_Code,Town) VALUES('" + txtUniversityCode.Text + "','" + txtUniversityName.Text + "', '" + txtLocation.Text + "','" + txtPostalCode.Text + "','" + txtZipCode.Text + "','" + txtTown.Text + "')";
                }
                try
                {
                    conn connect = new conn();
                    if (connect.OpenConnection() == true)
                    {
                        MySqlCommand cmd = new MySqlCommand(query, connect.connection);
                        cmd.ExecuteNonQuery();
                        connect.CloseConnection();
                        MessageBox.Show("Record Successfully saved!", "EIMS Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Reset();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("" + ex);
                }




            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            cboUniversityCode.Visible = true;
            Reset();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            cboUniversityCode.Visible = false;
            Reset();
        }

        private void cboUniversityCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboUniversityCode.Text == "")
            {
                MessageBox.Show("Ensure all fields are filled", "EIMS Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cboUniversityCode.Focus();
            }
            else
            {
                conn connect = new conn();
                if (connect.OpenConnection() == true)
                {
                    query = "SELECT * FROM university WHERE University_Code LIKE '"+ cboUniversityCode.Text +"' ORDER BY University_Code ASC";
                    MySqlCommand cmd = new MySqlCommand(query, connect.connection);
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    //Read the data and store them in the list
                    if (dataReader.Read())
                    {
                        
                         this.txtUniversityName.Text=dataReader["University_Name"].ToString();
                         this.txtLocation.Text = dataReader["Location"].ToString();
                         this.txtPostalCode.Text = dataReader["Postal_Code"].ToString();
                         this.txtZipCode.Text = dataReader["Zip_Code"].ToString();
                         this.txtTown.Text = dataReader["Town"].ToString();
                         uniCode = dataReader["University_Code"].ToString();
                    }
                    connect.CloseConnection();



                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (cboUniversityCode.Visible == false)
            {
                MessageBox.Show("Select Details to Edit");
                cboUniversityCode.Visible = true;
            }
            else
            {
                query = "DELETE FROM university WHERE University_Code='"+ cboUniversityCode.Text +"'";
                try
                {
                    conn connect = new conn();
                    if (connect.OpenConnection() == true)
                    {
                        MySqlCommand cmd = new MySqlCommand(query, connect.connection);
                        cmd.ExecuteNonQuery();
                        connect.CloseConnection();
                        MessageBox.Show("Record Successfully deleted!", "EIMS Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Reset();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("" + ex);
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            gboSearch.Visible = true;
        }

        private void btnSearchQuit_Click(object sender, EventArgs e)
        {
            gboSearch.Visible = false;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            cboUniversityCode.Visible = true;
            cboUniversityCode.Text = this.dataGridView1.Rows[this.dataGridView1.CurrentCell.RowIndex].Cells[0].Value.ToString();

            uniCode = this.dataGridView1.Rows[this.dataGridView1.CurrentCell.RowIndex].Cells[0].Value.ToString();
            gboSearch.Visible = false;
            gboData.Visible = false;

        }

        private void btnAdvSearch_Click(object sender, EventArgs e)
        {
            if (cboCriteria.Text == "")
            {
                MessageBox.Show("Ensure all fields are filled");
                cboCriteria.Focus();
            }
            else if (txtSearch.Text == "")
            {
                MessageBox.Show("Ensure all fields are filled");
                txtSearch.Focus();
            }
            else
            {
                if (cboCriteria.Text == "University Code")
                {
                    query = "SELECT * FROM university WHERE University_Code LIKE '" + "%" +txtSearch.Text + "%" +"'";
                }
                else if (cboCriteria.Text == "University Name")
                {
                    query = "SELECT * FROM university WHERE University_Name LIKE '" + "%" + txtSearch.Text + "%" + "'";
                }
                else if (cboCriteria.Text == "Location")
                {
                    query = "SELECT * FROM university WHERE Location LIKE '" + "%" + txtSearch.Text + "%" + "'";
                }
                else if (cboCriteria.Text == "Town")
                {
                    query = "SELECT * FROM university WHERE Town LIKE '" + "%" + txtSearch.Text + "%" + "'";
                }
                else
                {
                    query = "SELECT * FROM university";
                }
                conn connect = new conn();
                if (connect.OpenConnection() == true)
                {
                    
                    MySqlCommand cmd = new MySqlCommand(query, connect.connection);
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    //Read the data and store them in the list
                    this.dataGridView1.Rows.Clear();
                    while (dataReader.Read())
                    {

                        string[] row = new string[] { dataReader["University_Code"].ToString(), dataReader["University_Name"].ToString(), dataReader["Location"].ToString(), dataReader["Town"].ToString()};
                        dataGridView1.Rows.Add(row);
                    }
                    connect.CloseConnection();
                    gboSearch.Visible = false;
                    gboData.Visible = true;



                }
            }
        }
        private void btnQuitData_Click(object sender, EventArgs e)
        {
            gboData.Visible = false;
        }
    }
}
