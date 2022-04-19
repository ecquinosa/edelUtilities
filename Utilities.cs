using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EdelUtilities
{
    public class Utilities
    {

        private static string msgBoxHeader = "Edel Utilities";

        public static void ShowInfoMessageBox(string msg, string header = "")
        {
            System.Windows.Forms.MessageBox.Show(msg, header ?? msgBoxHeader, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
        }

        public static void ShowWarningMessageBox(string msg, string header = "")
        {
            System.Windows.Forms.MessageBox.Show(msg, header ?? msgBoxHeader , System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
        }

        public static void ShowErrorMessageBox(string msg, string header = "")
        {
            System.Windows.Forms.MessageBox.Show(msg, header ?? msgBoxHeader, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
        }
    }
}
