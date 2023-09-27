using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace SRP
{
    public partial class Signup : Form
    {
        private SqlConnection _conn;
        public Signup()
        {
            InitializeComponent();
            _conn = new SqlConnection("Data Source=.;Initial Catalog=StudentRequestDB;Integrated Security=True");
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void account_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Login loginForm = new Login();
            loginForm.ShowDialog();
            


        }


        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void passwordInput_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void emailInput_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void signupbtn_Click(object sender, EventArgs e)
        {
            String id = idInput.Text;
            String names = namesInput.Text;
            String email = emailInput.Text;
            String password1 = passwordInput1.Text;
            String password2 = passwordInput2.Text;
            
            if (id != null && names != null && email != null && password1 != null && password2 != null) 
            {
                if (password1.Equals(password2))
                {
                    try
                    {
                        this._conn.Open();
                        SqlCommand command = new SqlCommand("INSERT INTO Students VALUES (@id, @fullname, @email, @password, @dpt)", this._conn);
                        command.Parameters.AddWithValue("@id", int.Parse(id));
                        command.Parameters.AddWithValue("@fullname", names);
                        command.Parameters.AddWithValue("@email", email);
                        command.Parameters.AddWithValue("@password", password1);
                        command.Parameters.AddWithValue("@dpt", "D0001");
                        if (command.ExecuteNonQuery() == 1)
                        {
                            MessageBox.Show("Signup succefull");
                            Login loginform = new Login();
                            loginform.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("Signup Failed");
                        }
                        this._conn.Close();

                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show(""+ex);
                    }
                }
                else 
                {
                    MessageBox.Show("Password should be similar");
                }
            }
            else
            {
                MessageBox.Show("All inputs are required!!");
            }

            
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Department dptform = new Department();
            dptform.Show();
        }

        private void Signup_Load(object sender, EventArgs e)
        {
            displayDataInCombo();
            displayDataInGridView();
        }

        public void displayDataInCombo()
        {
            // Create a tunel to the DB
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM department", _conn);
            // Create a DS to store ur data
            DataSet ds = new DataSet();
            sda.Fill(ds, "department");
            // Display the data in the dgv
            departmentCombo.DataSource = ds.Tables["department"];
            departmentCombo.DisplayMember = "depName";
            departmentCombo.ValueMember = "id";
        }

        public void displayDataInGridView()
        {
            // Create a tunel to the DB
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM Students", _conn);
            // Create a DS to store ur data
            DataSet ds = new DataSet();
            sda.Fill(ds, "Students");
            // Display the data in the dgv
            dataGridView1.DataSource = ds.Tables["Students"];
        }

        private void signupbtn_Click_1(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                idInput.Text = row.Cells[0].Value.ToString();
                namesInput.Text = row.Cells[1].Value.ToString();
                emailInput.Text = row.Cells[2].Value.ToString();
                departmentCombo.Text = row.Cells[4].Value.ToString();

            }
        }
    }
}
