using System.Runtime.InteropServices;
using System.Windows.Forms;

public class PreventShutdown : Form
{
    private const int WM_QUERYENDSESSION = 0x11;
    private const int WM_ENDSESSION = 0x16;

    [DllImport("user32.dll", SetLastError = true)]
    private static extern bool ShutdownBlockReasonCreate(IntPtr hWnd, string reason);

    [DllImport("user32.dll", SetLastError = true)]
    private static extern bool ShutdownBlockReasonDestroy(IntPtr hWnd);

    public PreventShutdown()
    {
        this.Text = "Shutdown Blocker";
        this.Width = 200;
        this.Height = 200;
        this.ShowInTaskbar = false;
        FormClosing += PreventShutdown_FormClosing;

        Label label = new Label()
        {
            Text = "Schliese dieses Fenster nicht!",
            Dock = DockStyle.Fill,
            TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        };
        this.Controls.Add(label);
    }

    protected override void WndProc(ref Message m)
    {
        if (m.Msg == WM_QUERYENDSESSION || m.Msg == WM_ENDSESSION)
        {
            m.Result = IntPtr.Zero;
            return;
        }
        base.WndProc(ref m);
    }

    private void PreventShutdown_FormClosing(object sender, FormClosingEventArgs e)
    {
        if (e.CloseReason == CloseReason.WindowsShutDown || e.CloseReason == CloseReason.TaskManagerClosing)
        {
            e.Cancel = true;
            ShutdownBlockReasonCreate(this.Handle, "Shutdown blockiert von Anwendung.");
        }
    }
}