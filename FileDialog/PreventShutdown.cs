using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace ShutdownBlocker
{
    public static class PreventShutdown
    {
        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new HiddenForm());
        }
    }

    public class HiddenForm : Form
    {
        private const int WM_QUERYENDSESSION = 0x11;
        private const int WM_ENDSESSION = 0x16;

        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool ShutdownBlockReasonCreate(IntPtr hWnd, string pwszReason);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool ShutdownBlockReasonDestroy(IntPtr hWnd);

        public HiddenForm()
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.ShowInTaskbar = false;
            this.WindowState = FormWindowState.Minimized;

            this.Load += HiddenForm_Load;
            this.Shown += HiddenForm_Shown;
        }

        private void HiddenForm_Load(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void HiddenForm_Shown(object sender, EventArgs e)
        {
            ShutdownBlockReasonCreate(this.Handle, "Herunterfahren wird durch diese Anwendung verhindert.");
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.WindowsShutDown)
            {
                e.Cancel = true; 
            }
            base.OnFormClosing(e);
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_QUERYENDSESSION)
            {
                m.Result = IntPtr.Zero;
                return; // Wichtiger: Nicht an die Basisklasse weiterreichen!
            }
            base.WndProc(ref m);
        }

        protected override void Dispose(bool disposing)
        {
            ShutdownBlockReasonDestroy(this.Handle);
            base.Dispose(disposing);
        }
    }
}
