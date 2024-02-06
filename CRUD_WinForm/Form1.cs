using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace CRUD_WinForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string strConnection = "data source=murzilca;initial catalog=WinFormCRUD;Integrated Security=True;";
            SqlConnection connection = new SqlConnection(strConnection);
            string searchString = $"select * from tblStudent where concat(marks, studentName) like '%" + textBox1.Text + "%'";
            SqlDataAdapter dataAdapter = new SqlDataAdapter(searchString, connection);
            DataTable dt = new DataTable();
            dataAdapter.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void sqlCommand(string sqlCommand)
        {
            string strConnection = "data source=murzilca;initial catalog=WinFormCRUD;Integrated Security=True;";
            SqlConnection connection = new SqlConnection(strConnection);
            SqlCommand command = new SqlCommand(sqlCommand, connection);
            connection.Open();
            try
            {
                command.ExecuteNonQuery();
                MessageBox.Show("successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            connection.Close();
            this.tblStudentTableAdapter.Fill(this.winFormCRUDDataSet.tblStudent);
        }

        private void buttonInsert_Click(object sender, EventArgs e)
        {
            sqlCommand("insert into tblStudent values ('" + textBoxName.Text + "','" + textBoxMark.Text + "')");
        }
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            sqlCommand("delete from tblStudent where studenId='" + labelId.Text + "'");
        }
        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            sqlCommand("update tblStudent set marks='" + textBoxMark.Text + "', studentName='" + textBoxName.Text + "'  where studenId='" + labelId.Text + "' ");
        }
        private void button1_Click(object sender, EventArgs e)
        {
            tblStudentBindingSource.AddNew();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            tblStudentTableAdapter.Fill(winFormCRUDDataSet.tblStudent);
        }
    }
}