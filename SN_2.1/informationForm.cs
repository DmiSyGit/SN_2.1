using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SN_1._0
{
    public partial class informationForm : Form
    {
        private menuForm formMainMenu;
        public informationForm(menuForm formMain)
        {
            InitializeComponent();
            formMainMenu = formMain;
        }

        private void informationForm_Load(object sender, EventArgs e)
        {

        }

        private void informationForm_Closing(object sender, FormClosingEventArgs e)
        {
            formMainMenu.Show();
        }

        private void openUserGuide_Click(object sender, EventArgs e)
        {
            try
            {
                string fileUserGuidePath = Application.StartupPath + @"\UserGuide.pdf";
                File.WriteAllBytes(fileUserGuidePath, Properties.Resources.UserGuid);
                System.Diagnostics.Process.Start(fileUserGuidePath);
            }
            catch 
            {
                MessageBox.Show("Неудалось открыть Руководство Пользователя.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Приложение разработал Сюнин Дмитрий.\n" +
                "Студент группы ИСП 32-18");
        }
    }
}
