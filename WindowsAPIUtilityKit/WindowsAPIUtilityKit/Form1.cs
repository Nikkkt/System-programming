using System.Runtime.InteropServices;

namespace WindowsAPIUtilityKit
{
    public partial class Form1 : Form
    {
        const int WM_SETTEXT = 0x000C;
        const int WM_CLOSE = 0x0010;
        const int WM_GETTEXTLENGTH = 0x000E;

        [DllImport("user32.dll")]
        public static extern int MessageBox(int hWnd, string lpText, string lpCaption, int uType);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, string lParam);

        [DllImport("kernel32.dll")]
        public static extern bool Beep(int dwFreq, int dwDuration);

        [DllImport("user32.dll")]
        public static extern bool MessageBeep(int uType);

        public Form1()
        {
            InitializeComponent();

            MessageBox(0, "Info:\nMy name is Nikita", "1", 0);
            MessageBox(0, "Info:\nI am 18 y.o.", "2", 0);
            MessageBox(0, "Info:\nI am studying in Ihor Sikorskyi KPI", "3", 0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            IntPtr windowHandle = FindWindow(null, textBox1.Text);

            if (windowHandle != IntPtr.Zero) SendMessage(windowHandle, WM_SETTEXT, IntPtr.Zero, textBox2.Text);
            else MessageBox(0, "Window not found", "Error", 0);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            IntPtr windowHandle = FindWindow(null, textBox1.Text);

            if (windowHandle != IntPtr.Zero) SendMessage(windowHandle, WM_CLOSE, IntPtr.Zero, null);
            else MessageBox(0, "Window not found", "Error", 0);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            IntPtr windowHandle = FindWindow(null, textBox1.Text);
            int textLength = 0;

            if (windowHandle != IntPtr.Zero) { textLength = SendMessage(windowHandle, WM_GETTEXTLENGTH, IntPtr.Zero, null); label4.Text = textLength.ToString(); }
            else MessageBox(0, "Window not found", "Error", 0);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Random random = new Random();

            for (int i = 0; i < random.Next(1, 3); i++)
            {
                Beep(500, 500);
                Thread.Sleep(1000);

                MessageBeep(0);
                Thread.Sleep(1000);

                Beep(1000, 500);
                Thread.Sleep(1000);

                MessageBeep(0);
                Thread.Sleep(1000);
            }
        }

        private void Form1_Load(object sender, EventArgs e) { }
    }
}
