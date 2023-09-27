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

namespace SRP
{
    public partial class Department : Form
    {
        public Department()
        {
            InitializeComponent();
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }
        SqlConnection conn = new SqlConnection(@"Data Source=.;Initial Catalog=StudentRequestDB;Integrated Security=True");

        private void signupbtn_Click(object sender, EventArgs e)
        {

        }

        private void Department_Load(object sender, EventArgs e)
        {
            displayData();
        }
        public void displayData()
        {
            // Create a tunel to the DB
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM department", conn);
            // Create a DS to store ur data
            DataSet ds = new DataSet();
            sda.Fill(ds, "department");
            // Display the data in the dgv
            dataGridView1.DataSource = ds.Tables["department"];
        }

        private void signupbtn_Click_1(object sender, EventArgs e)
        {
            //Create a tunnel
            SqlCommand cmd = new SqlCommand("INSERT INTO department VALUES('"+idInput.Text+"','"+departmentNameInput.Text+"','"+facultyCombo.Text+"')", conn);
            //Open the the conn
            conn.Open();
            //Execute the command
            cmd.ExecuteNonQuery();
            //Close connection
            conn.Close();
            MessageBox.Show("Saved with Success");
            displayData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Create a tunnel
            SqlCommand cmd = new SqlCommand("UPDATE department SET depName='"+departmentNameInput.Text+"',facultyid='"+facultyCombo.Text+"' WHERE id='"+idInput.Text+"'", conn);
            //Open the the conn
            conn.Open();
            //Execute the command
            cmd.ExecuteNonQuery();
            //Close connection
            conn.Close();
            MessageBox.Show("Updated with Success");
            displayData();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                idInput.Text = row.Cells[0].Value.ToString();
                departmentNameInput.Text = row.Cells[1].Value.ToString();
                facultyCombo.Text = row.Cells[2].Value.ToString();

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Create a tunnel
            SqlCommand cmd = new SqlCommand("DELETE FROM department WHERE id='"+idInput.Text+"'", conn);
            //Open the the conn
            conn.Open();
            //Execute the command
            cmd.ExecuteNonQuery();
            //Close connection
            conn.Close();
            MessageBox.Show("Deleted with Success");
            displayData();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Create a tunel to the DB
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM department WHERE id='"+textBox1.Text+"'", conn);
            // Create a DS to store ur data
            DataSet ds = new DataSet();
            sda.Fill(ds, "department");
            // Display the data in the dgv
            dataGridView1.DataSource = ds.Tables["department"];
        }

        private void button5_Click(object sender, EventArgs e)
        {
            displayData();
        }
    }
}
