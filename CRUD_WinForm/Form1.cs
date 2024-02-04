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

        private void buttonInsert_Click(object sender, EventArgs e)
        {
            string strConnection = "data source=murzilca;initial catalog=WinFormCRUD;Integrated Security=True;";
            SqlConnection connection = new SqlConnection(strConnection);
            string sqlString = "insert into tblStudent values ('"+textBoxName.Text+"','"+textBoxMark.Text+"')";
            SqlCommand command = new SqlCommand(sqlString, connection);
            connection.Open();
            int n = command.ExecuteNonQuery();
            if (n == 1)
                MessageBox.Show("Successfull");
            else
                MessageBox.Show("Fail");
            connection.Close();
            this.tblStudentTableAdapter.Fill(this.winFormCRUDDataSet.tblStudent);
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            string strConnection = "data source=murzilca;initial catalog=WinFormCRUD;Integrated Security=True;";
            SqlConnection connection = new SqlConnection(strConnection);
            string sqlString = "delete from tblStudent where studenId='" + labelId.Text + "'";
            SqlCommand command = new SqlCommand(sqlString, connection);
            connection.Open();
            int n = command.ExecuteNonQuery();
            if (n == 1)
                MessageBox.Show("Successfull");
            else
                MessageBox.Show("Fail");
            connection.Close();
            this.tblStudentTableAdapter.Fill(this.winFormCRUDDataSet.tblStudent);
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            string strConnection = "data source=murzilca;initial catalog=WinFormCRUD;Integrated Security=True;";
            SqlConnection connection = new SqlConnection(strConnection);
            string sqlString = "update tblStudent set marks='" + textBoxMark.Text + "', studentName='" + textBoxName.Text + "'  where studenId='" + labelId.Text + "' ";
            SqlCommand command = new SqlCommand(sqlString, connection);
            connection.Open();
            int n = command.ExecuteNonQuery();
            if (n == 1)
                MessageBox.Show("Successfull");
            else
                MessageBox.Show("Fail");
            connection.Close();
            this.tblStudentTableAdapter.Fill(this.winFormCRUDDataSet.tblStudent);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "winFormCRUDDataSet.tblStudent". При необходимости она может быть перемещена или удалена.
            this.tblStudentTableAdapter.Fill(this.winFormCRUDDataSet.tblStudent);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tblStudentBindingSource.AddNew();
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
    }
}
