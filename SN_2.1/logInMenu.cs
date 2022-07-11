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

namespace SN_1._0
{
    public partial class logInMenu : Form
    {
        static string pyt = Application.StartupPath;
        string sql = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + pyt + "\\gameBase.mdf;Integrated Security=True;";
        Font pixelFont;
        SqlConnection connection;
        public logInMenu(Font Font)
        {
            InitializeComponent();
            textBoxNickName.ShortcutsEnabled = false;
            labelNameGame.Font = Font;
            textBoxNickName.Font = Font;
            logInButton.Font = Font;
            pixelFont = Font;
        }

        private void nickName_Enter(object sender, EventArgs e)
        {
            if (textBoxNickName.Text == "nickname")
            {
                textBoxNickName.Text = "";
            }
        }


        private void nickName_Leave(object sender, EventArgs e)
        {
            if (textBoxNickName.Text == "")
            {
                textBoxNickName.Text = "nickname";
            }
        }

        private void LogInButton_Click(object sender, EventArgs e)
        {
            if (textBoxNickName.Text != "nickname")
            {
                try
                {
                    connection = new SqlConnection(sql);
                    connection.Open();
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 15350)
                    {
                        MessageBox.Show("Внимание! \nБаза данных не подключена, список рекордов не будет доступен.\nВаш рекорд не занесется в базу данных!");
                    }
                    else
                    {
                        MessageBox.Show("Внимание! \nТребуется обновление localdb.\nВаш рекорд не занесется в базу данных!");
                    }
                }

                menuForm newForm = new menuForm(this, connection, textBoxNickName.Text, pixelFont);
                newForm.Location = this.Location;
                newForm.Show();
                this.Hide();
            }
        }

        private void nickName_TextChanged(object sender, EventArgs e)
        {
            if(textBoxNickName.Text.Length > 10)
            {
                textBoxNickName.Text = textBoxNickName.Text.Remove(textBoxNickName.Text.Length - 1, 1);
            }
        }

        private void nickName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 48 && e.KeyChar <= 57) || (e.KeyChar >= 65 && e.KeyChar <= 90) || (e.KeyChar >= 97 && e.KeyChar <= 122) || e.KeyChar == 8)
            {
                e.Handled = false;
            }
            else e.Handled = true;
            /*if (!Char.IsLetter(e.KeyChar) && e.KeyChar != 8)
                e.Handled = true;*/
        }

        private void logInMenu_Load(object sender, EventArgs e)
        {

        }
    }
}
