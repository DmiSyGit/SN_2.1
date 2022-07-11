using System;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Windows.Forms;

namespace SN_1._0
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //записываем ttf из ресурсов в файл
            string fileFont = Path.GetTempFileName();
            File.WriteAllBytes(fileFont, Properties.Resources.PixelFont);
            PrivateFontCollection fontCollection = new PrivateFontCollection();
            fontCollection.AddFontFile(fileFont); // файл шрифта
            FontFamily pixelFont = fontCollection.Families[0];
            // Создаём шрифт и используем далее
            Font font = new Font(pixelFont, 90);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new logInMenu(font));
        }
    }
}
