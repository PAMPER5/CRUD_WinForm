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
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            string strConnection = "data source=murzilca;initial catalog=WinFormCRUD;Integrated Security=True;";
            SqlConnection connection = new SqlConnection(strConnection);
            string sqlString = "delete from tblStudent where studentName='" + textBoxName.Text + "'";
            SqlCommand command = new SqlCommand(sqlString, connection);
            connection.Open();
            int n = command.ExecuteNonQuery();
            if (n == 1)
                MessageBox.Show("Successfull");
            else
                MessageBox.Show("Fail");
            connection.Close();
        }
    }
}
