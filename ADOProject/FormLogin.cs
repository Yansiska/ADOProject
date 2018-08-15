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
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if ((txtUsername.Text.Length == 0) || (txtPassword.Text.Length == 0))
                {
                    MessageBox.Show("Username Or Password cannot left blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    SQLconnect.Connect.Open();
                    SqlCommand sqlInsert = new SqlCommand("INSERT INTO TBLOGIN VALUES (@USERNAME,@PASSWORD)", SQLconnect.Connect);
                    sqlInsert.Parameters.AddWithValue("@USERNAME", txtUsername.Text.Trim());
                    sqlInsert.Parameters.AddWithValue("@PASSWORD", txtPassword.Text.Trim());
                    //eksekusi baris perintah T-SQL
                    sqlInsert.ExecuteNonQuery();
                    MessageBox.Show("Data saved Succesfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtUsername.Clear();
                    txtPassword.Clear();

                    SQLconnect.Connect.Close();
                    Display();
                }

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            finally
            {
            }
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            Display();
        }

        public void Display()
        {
            try
            {
                SQLconnect.Connect.Open();
                SqlDataAdapter sqlDisplay = new SqlDataAdapter("SELECT * FROM TBLOGIN", SQLconnect.Connect);
                DataTable dt = new DataTable();
                sqlDisplay.SelectCommand.ExecuteNonQuery();
                sqlDisplay.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }
            finally
            {
                SQLconnect.Connect.Close();
            }
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                SQLconnect.Connect.Open();
                SqlCommand cmdDelete = new SqlCommand("DELETE FROM TBLOGIN WHERE USERNAME =@USERNAME", SQLconnect.Connect);
                cmdDelete.Parameters.AddWithValue("@USERNAME", txtUsername.Text.Trim());


                cmdDelete.ExecuteNonQuery();
                MessageBox.Show("Data Terhapus");

                SQLconnect.Connect.Close();
                Display();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());


            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {


            if (dataGridView1.SelectedRows.Count > 0)
            {
                txtUsername.Text = dataGridView1.SelectedRows[0].Cells
                    [0].Value.ToString();

                txtPassword.Text = dataGridView1.SelectedRows[0].Cells
                    [1].Value.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                SQLconnect.Connect.Open();
                SqlCommand cmdUpdate = new SqlCommand("UPDATE TBLOGIN SET PASSWORD = @PASSWORD WHERE USERNAME=@USERNAME", SQLconnect.Connect);

                cmdUpdate.Parameters.AddWithValue("@USERNAME", txtUsername.Text.Trim());
                cmdUpdate.Parameters.AddWithValue("@PASSWORD", txtPassword.Text.Trim());


                cmdUpdate.ExecuteNonQuery();
                MessageBox.Show("Data Terupdate");
                txtUsername.Clear();
                txtPassword.Clear();
                SQLconnect.Connect.Close();
                Display();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());


            }
        }

       /* private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            try
            {
                SQLconnect.Connect.Open();
                SqlDataAdapter sqlDisplay = new SqlDataAdapter("SELECT * FROM TBLOGIN WHERE USERNAME LIKE '%' + '"+txtUsername.Text+"' + '%'", SQLconnect.Connect);
                DataTable dt = new DataTable();
                sqlDisplay.SelectCommand.ExecuteNonQuery();
                sqlDisplay.Fill(dt);
                dataGridView1.DataSource = dt;
                SQLconnect.Connect.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());


            }
        }*/

        private void txtUsername_TextChanged_1(object sender, EventArgs e)
        {
            try
            {
                SQLconnect.Connect.Open();
                SqlDataAdapter sqlDisplay = new SqlDataAdapter("SELECT * FROM TBLOGIN WHERE USERNAME LIKE '%' + '" + txtUsername.Text + "' + '%'", SQLconnect.Connect);
                DataTable dt = new DataTable();
                sqlDisplay.SelectCommand.ExecuteNonQuery();
                sqlDisplay.Fill(dt);
                dataGridView1.DataSource = dt;
                SQLconnect.Connect.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());


            }
        }
    }
}

