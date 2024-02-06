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
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void buttonReg_Click(object sender, EventArgs e)
        {
            if (textBoxLogin.Text == "" || textBoxPassCheck.Text == "" || textBoxPassword.Text == "")
            { 
                MessageBox.Show("У Вас остались пустые поля!");
            }
            else if (textBoxPassCheck.Text == textBoxPassword.Text)
            {
                string strConnection = "data source=murzilca;initial catalog=WinFormCRUD;Integrated Security=True;";
                SqlConnection connection = new SqlConnection(strConnection);
                SqlCommand command = new SqlCommand("insert into LoginsStaff values ('" + textBoxLogin.Text + "','" + textBoxPassword.Text + "')", connection);
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
            else MessageBox.Show("Пароли должны совпадать!");
            textBoxPassword.Text = "";
            textBoxPassCheck.Text = "";
        }

        private void checkBoxPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxPassword.Checked)
            {
                textBoxPassword.PasswordChar = '\0';
                textBoxPassCheck.PasswordChar = '\0';
            }
            else
            {
                textBoxPassword.PasswordChar = '*';
                textBoxPassCheck.PasswordChar = '*';
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBoxPassword.Text = "";
            textBoxPassCheck.Text = "";
            textBoxLogin.Text = "";
        }

        private void label5_Click(object sender, EventArgs e)
        {
            new AutorizationForm().Show();
            this.Hide();
        }
    }
}
