using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SN_1._0
{
    public partial class menuForm : Form
    {
        SqlConnection connection;
        logInMenu formLogMenu;
        string playerName;
        public menuForm()
        {
            InitializeComponent();
        }
        public menuForm(logInMenu logMenu)
        {
            InitializeComponent();
            formLogMenu = logMenu;
        }
        public menuForm(logInMenu logMenu, SqlConnection connect, string pName, Font pixelFont)
        {
            InitializeComponent();
             
            listBoxRecords.Font = new Font(pixelFont.FontFamily, 40, FontStyle.Regular);
            startButton.Font = pixelFont;
            button1.Font = pixelFont;
            formLogMenu = logMenu;
            playerName = pName;
            connection = connect;
        }
        private void UpdateRecordsTable()
        {
            try
            {
                string sqlQuery = "SELECT * FROM playerRecords";
                SqlCommand command = new SqlCommand(sqlQuery, connection);
                SqlDataReader reader = command.ExecuteReader();
                listBoxRecords.Items.Clear();
                if (reader.HasRows) // если есть данные
                {
                    while (reader.Read()) // построчно считываем данные
                    {
                        listBoxRecords.Items.Add("record: " + reader.GetValue(1).ToString() + " nick: " + reader.GetValue(0).ToString());
                    }
                }

                reader.Close();
            }
            catch
            {
                listBoxRecords.Items.Clear();
                listBoxRecords.Items.Add("Не удалось загрузить данные");
            }
        }
        public void UpdateRecordsPlayer(int playerScore)
        {
            try
            {
                string sqlQuery = String.Format("SELECT recordPlayer FROM playerRecords WHERE namePlayer = '{0}'", playerName);
                SqlCommand command = new SqlCommand(sqlQuery, connection);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    int playerScorebd = 0;
                    while (reader.Read()) // построчно считываем данные
                    {
                        playerScorebd = reader.GetInt32(0);
                    }
                    reader.Close();
                    if (playerScorebd < playerScore)
                    {
                        string sqlQuerySecond = String.Format("UPDATE playerRecords SET recordPlayer = '{1}' WHERE namePlayer = '{0}'", playerName, playerScore);
                        command.CommandText = sqlQuerySecond;
                        command.ExecuteNonQuery();
                    }
                }
                else
                {
                    reader.Close();
                    string sqlQuerySecond = String.Format("INSERT INTO playerRecords VALUES ('{0}','{1}')", playerName, playerScore);
                    command.CommandText = sqlQuerySecond;
                    command.ExecuteNonQuery();
                }
                reader.Close();
            }
            catch 
            {
                MessageBox.Show("Неудалось занести ваш счет в таблицу рекордов.");
            }
        }
        private void menuForm_Load(object sender, EventArgs e)
        {
            
        }

        private void menuForm_Closing(object sender, FormClosingEventArgs e)
        {
            formLogMenu.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            gameForm gameForm = new gameForm(this, button1.Font);
            gameForm.Location = this.Location;
            gameForm.Show();
            this.Hide();
        }

        private void menuForm_Activated(object sender, EventArgs e)
        {
            UpdateRecordsTable();
        }

        private void printButton_Click(object sender, EventArgs e)
        {
            if(printDialogGame.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    printDocumentGame.PrintPage += new PrintPageEventHandler(PrintDocumentGame_Event);
                    printDocumentGame.DocumentName = "Document1"; //Названия документа
                    printDocumentGame.PrinterSettings = printDialogGame.PrinterSettings;//Передаем параметры
                    printDocumentGame.Print();//Начинаем процесс печати
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message); }
            }
        }
        void PrintDocumentGame_Event(object sender, PrintPageEventArgs e)
        {
            string text = "";
            Graphics g = e.Graphics;
            foreach(string itemRecords in listBoxRecords.Items)
            {
                text += itemRecords + "\n";
            }
            Font printFont = new Font(startButton.Font.FontFamily, 40, FontStyle.Regular);
            g.DrawString(text, printFont, new SolidBrush(Color.Black), 0, 0);
        }

        private void informationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            informationForm infoForm = new informationForm(this);
            infoForm.Location = this.Location;
            infoForm.Show();
            this.Hide();
        }
    }
}
