using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Hwnd
{
    public partial class PrinconneFrm : Form
    {
        public PrinconneFrm()
        {
            InitializeComponent();
            resolutionComboBox.DataSource = ResolutionData;
            resolutionComboBox.DisplayMember = "displayName";
            resolutionComboBox.ValueMember = "resolution";
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

        private static readonly Size[] AvailableResolutions = {
            new Size(1024, 576),
            new Size(1280, 720),
            new Size(1366, 768),
            new Size(1600, 900),
            new Size(1920, 1080),
            new Size(2560, 1440),
        };

        private IEnumerable<object> ResolutionData => AvailableResolutions.Select(x => new
        {
            resolution = x,
            displayName = $"{x.Width}x{x.Height}",
        }).ToList();

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

        private void applyResolutionBtn_Click(object sender, EventArgs e)
        {
            var princoneHwnd = Win32Wrapper.GetWindowHandle(PRICONNE_WND_CLASS, PRICONNE_WND_NAME);
            if ((int)princoneHwnd == 0)
            {
                MessageBox.Show(MSG_MESSAGE_START_GAME_FIST, MSG_TITLE_START_GAME_FIRST, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!(resolutionComboBox.SelectedValue is Size newResolution)) return;
            Win32Wrapper.ResizeWindow(princoneHwnd, newResolution.Width, newResolution.Height);
        }
    }
}
