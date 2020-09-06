using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Hwnd
{
    public partial class PrinconneFrm : Form
    {
        public PrinconneFrm()
        {
            InitializeComponent();
        }

        private const string PRICONNE_WND_CLASS = "UnityWndClass";
        private const string PRICONNE_WND_NAME = "PrincessConnectReDive";

        private const string MSG_TITLE_START_GAME_FIRST = "Priconne isn't running";
        private const string MSG_MESSAGE_START_GAME_FIST = "Princess Connect Re:Dive (DMM) is not running\nPlease start game first";

        private const string MSG_TITLE_ALREADY_FULLSCREEN = "Full Screen Mode";
        private const string MSG_MESSAGE_ALREADY_FULLSCREEN = "Priconne already in fullscreen mode";

        private const string MSG_TITLE_ALREADY_WINDOW = "Window Mode";
        private const string MSG_MESSAGE_ALREADY_WINDOW = "Priconne already in window mode";

        private Win32Wrapper Win32Wrapper { get; set; } = new Win32Wrapper();
        
        private void linkBtn_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(@"https://www.youtube.com/c/TakumiProducer");
        }

        private void fullscreenBtn_Click(object sender, EventArgs e)
        {
            var princoneHwnd = Win32Wrapper.GetWindowHandle(PRICONNE_WND_CLASS, PRICONNE_WND_NAME);
            if ((int)princoneHwnd == 0)
            {
                MessageBox.Show(MSG_MESSAGE_START_GAME_FIST, MSG_TITLE_START_GAME_FIRST, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (Win32Wrapper.CheckWindowIsFullScreen(princoneHwnd))
            {
                MessageBox.Show(MSG_MESSAGE_ALREADY_FULLSCREEN, MSG_TITLE_ALREADY_FULLSCREEN, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Win32Wrapper.FullScreenWindow(princoneHwnd);
        }

        private void restoreBtn_Click(object sender, EventArgs e)
        {
            var princoneHwnd = Win32Wrapper.GetWindowHandle(PRICONNE_WND_CLASS, PRICONNE_WND_NAME);
            if ((int)princoneHwnd == 0)
            {
                MessageBox.Show(MSG_MESSAGE_START_GAME_FIST, MSG_TITLE_START_GAME_FIRST, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Win32Wrapper.RestoreWindow(princoneHwnd);
        }
    }
}
