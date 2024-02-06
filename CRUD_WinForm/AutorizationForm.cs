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

namespace CRUD_WinForm
{
    public partial class AutorizationForm : Form
    {
        public AutorizationForm()
        {
            InitializeComponent();
        }

        private void buttonLog_Click(object sender, EventArgs e)
        {
            string strConnection = "data source=murzilca;initial catalog=WinFormCRUD;Integrated Security=True;";
            SqlConnection connection = new SqlConnection(strConnection);
            SqlCommand command = new SqlCommand("select * from LoginsStaff where login = '" + textBoxLogin.Text + "' and password= '" + textBoxPassword.Text + "'", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                new Form1().Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Неверные данные!");
                textBoxPassword.Text = "";
                textBoxLogin.Text = "";
            }
            connection.Close();
        }

        private void checkBoxPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxPassword.Checked)
            {
                textBoxPassword.PasswordChar = '\0';
            }
            else
            {
                textBoxPassword.PasswordChar = '*';
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBoxPassword.Text = "";
            textBoxLogin.Text = "";
        }

        private void label5_Click(object sender, EventArgs e)
        {
            new RegisterForm().Show();
            this.Hide();
        }
    }
}
