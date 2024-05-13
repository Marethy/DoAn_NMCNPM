using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.UserSkins;
using DevExpress.Skins;
using QuanLiBanVang.Form;

namespace QuanLiBanVang
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            DevExpress.LookAndFeel.UserLookAndFeel.Default.SkinName = "DevExpress Style";
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // purpose to change language DateTimePicker to Vietnamese
            // Application.CurrentCulture = new System.Globalization.CultureInfo("zh-Hans");

            //string strpath;
            //strpath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            //strpath += "\\NTS";
            //AppDomain.CurrentDomain.SetData("DataDirectory", strpath);
            //if(!System.IO.Directory.Exists(strpath))
            //    System.IO.Directory.CreateDirectory(strpath);
            //System.IO.Directory.SetCurrentDirectory(strpath);

            BonusSkins.Register();
            SkinManager.EnableFormSkins();
            Application.Run(new MainForm());
        }
    }
}
