using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace DemoAgente
{
    public partial class Form1 : Form
    {
        protected delegate bool EnumWindowsProc(IntPtr hWnd, IntPtr lParam);
        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        protected static extern int GetWindowText(IntPtr hWnd, StringBuilder strText, int maxCount);
        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        protected static extern int GetWindowTextLength(IntPtr hWnd);
        [DllImport("user32.dll")]
        protected static extern bool EnumWindows(EnumWindowsProc enumProc, IntPtr lParam);
        [DllImport("user32.dll")]
        protected static extern bool IsWindowVisible(IntPtr hWnd);

        public Form1()
        {
            InitializeComponent();
            EnumWindows(new EnumWindowsProc(EnumTheWindows), IntPtr.Zero);
        }

        //protected static bool EnumTheWindows(IntPtr hWnd, IntPtr lParam)
        //{
        //    int tamano = GetWindowTextLength(hWnd);
        //    if (tamano++ > 0 && IsWindowVisible(hWnd))
        //    {
        //        StringBuilder sb = new StringBuilder(tamano);
        //        GetWindowText(hWnd, sb, tamano);
        //        Console.WriteLine(sb.ToString());
        //    }
        //    return true;
        //}

        public bool EnumTheWindows(IntPtr hWnd, IntPtr lParam)
        {
            String salida = "";
            int tamano = GetWindowTextLength(hWnd) + 1;
            StringBuilder sb = new StringBuilder(tamano);
            GetWindowText(hWnd, sb, tamano);
            //salida += sb.ToString() + "\n";

            //label1.Text = salida;
            //label1.Text += sb.ToString() + "\n";
            listBox1.Items.Add(sb.ToString().Trim());
            BuscarAppHermes();

            return true;
        }

        private void BuscarAppHermes()
        {
            //int i = listBox1.FindStringExact("Hermes _4_6_2_48T () Release Date: 07 / 08 / 2017 11:30 Install Da - \\Remota");
            int i = 0;
            foreach (var item in listBox1.Items)
            {
                //string palabra = "Hermes _4_6_2_48T () Release Date: 07 / 08 / 2017 11:30 Install Da - \\Remota";
                if (item.ToString().Contains("Hermes"))
                {
                    i++;
                }
            }
            
            textBox1.Text = "Se encontro " + i + " Hermes";
            if (i > 1)
            {
                Process.Start("http://172.16.28.98:8989/?cmd=scl");
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            EnumWindows(new EnumWindowsProc(EnumTheWindows), IntPtr.Zero);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
