using ESPEJIC.Archive_forms;
using ESPEJIC.Ficher_a_imprimer;
using ESPEJIC.UserControl_Archive;
using ESPEJIC.UserControl_Formatteur;
using ESPEJIC.UserControl_Note;
using ESPEJIC.UserControl_Paiment;
using ESPIGIC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ESPEJIC
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Menu());
        }
    }
}
