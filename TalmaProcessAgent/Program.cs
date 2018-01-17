using System;
using System.Windows.Forms;

namespace HermesProcessAgent
{
    static class Program
    {

        private static ProcessIcon pi;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (SingletonController.IamFirst(new SingletonController.ReceiveDelegate(Program.myReceive)))
            {
                try
                {
                    Program.pi = new ProcessIcon();
                    Program.pi.Display();
                    Application.Run();
                    Program.pi.HideIcon();
                }
                catch (Exception exception1)
                {
                    Exception exception = exception1;
                    MessageBox.Show(string.Concat("Error while initiating HermesProcessAgent: ", exception.Message), "Error");
                }
            }
            SingletonController.Cleanup();

        }

        public static void myReceive(string[] args)
        {
            Program.pi.ProcessArguments(args);
        }

    }
}
