using System;
using System.Windows.Forms;
using IW4WeaponsEditor;

namespace IW4WeaponsEditor
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());  // Entry point to start Form1
        }
    }
}
