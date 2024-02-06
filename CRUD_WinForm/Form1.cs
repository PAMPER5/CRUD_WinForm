using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CRUD_WinForm
{
    public partial class Form1 : Form
    {
        string id;
        public Form1()
        {
            InitializeComponent();
        }
        //вызов sql запросов
        private void sqlCommand(string sqlCommand)
        {
            string strConnection = "data source=murzilca;initial catalog=WinFormCRUD;Integrated Security=True;";
            SqlConnection connection = new SqlConnection(strConnection);
            SqlCommand command = new SqlCommand(sqlCommand, connection);
            connection.Open();
            try
            {
                command.ExecuteNonQuery();
                MessageBox.Show("Успешно");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
            connection.Close();
        }
        //обновление DataGridView
        private void outputDataGridView(DataGridView dataGridView, string sqlCommand)
        {
            string strConnection = "data source=murzilca;initial catalog=WinFormCRUD;Integrated Security=True;";
            SqlConnection connection = new SqlConnection(strConnection);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand, connection);
            DataTable dt = new DataTable();
            dataAdapter.Fill(dt);
            dataGridView.DataSource = dt;
            dataGridView.Columns[0].Visible = false;
        }


        #region CRUD tblStudent
        public void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                textBoxName.Text = row.Cells[1].Value.ToString();
                textBoxMark.Text = row.Cells[2].Value.ToString();
                id = row.Cells[0].Value.ToString();
            }
        }
        private void buttonInsert_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Вы уверены, что хотите добавить запись?", "Добавление", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                sqlCommand("insert into tblStudent values ('" + textBoxName.Text + "','" + textBoxMark.Text + "')");
                outputDataGridView(dataGridView1, "select * from tblStudent");
            }
        }
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Вы уверены, что хотите удалить запись?", "Удаление", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                sqlCommand($"delete from tblStudent where studenId='{id}'");
                outputDataGridView(dataGridView1, "select * from tblStudent");
            }
        }
        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Вы уверены, что хотите изменить запись?", "Изменение", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                sqlCommand("update tblStudent set marks='" + textBoxMark.Text + "', studentName='" + textBoxName.Text + "'  where studenId='" + id + "'");
                outputDataGridView(dataGridView1, "select * from tblStudent");
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            outputDataGridView(dataGridView1, "select * from tblStudent");
        }
        #endregion
    }
}