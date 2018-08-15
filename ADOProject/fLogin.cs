using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ADOProject
{
    public partial class fLogin : Form
    {
        public fLogin()
        {
            InitializeComponent();
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            try
            {
                SQLconnect.Connect.Open();
                SqlCommand cmdDisplay = new SqlCommand("SELECT * FROM TBLOGIN WHERE USERNAME =@USERNAME AND PASSWORD =@PASSWORD", SQLconnect.Connect);
                cmdDisplay.Parameters.AddWithValue("@USERNAME", txtUsername.Text.Trim());
                cmdDisplay.Parameters.AddWithValue("@PASSWORD", txtPassword.Text.Trim());
                SqlDataReader dr;
                dr = cmdDisplay.ExecuteReader();
                if(dr.Read())
                {
                    //jika valid
                    MessageBox.Show("Welcome, " + txtUsername.Text);
                    fMenu obj = new fMenu();
                    obj.Show();
                    this.Hide();
                }
                else
                {
                    //jika invalid
                    MessageBox.Show(" Invalid Username or Password");
                }
                SQLconnect.Connect.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }
        }
    }
}
