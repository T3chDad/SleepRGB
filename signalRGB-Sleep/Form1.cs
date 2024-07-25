using System;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Windows.Forms;
using System.Security.Policy;
using Microsoft.Win32;
using BlueMystic;
using IWshRuntimeLibrary;

internal struct LASTINPUTINFO
{
    public uint cbSize;
    public uint dwTime;
}

namespace signalRGB_Sleep
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            _ = new DarkModeCS(this);  // Dark mode theming
            SystemEvents.SessionSwitch += SystemEvents_SessionSwitch;  // Subscribe to the SessionSwitch event
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // Convert the timout to a uint
            uint timeout = uint.Parse(tb_Timeout.Text);
            // Save the timeout in sec to our global class
            Global.MAX_IDLE = timeout * 60;
            // Seconds since last activity
            uint IdleTime = IdleTimeFinder.GetIdleTime() / 1000;
            // Over the threshold, turn off the lights
            //  [----     Triggered by Idle Timeout      ----]    [----    Triggered by Lock     ----]
            if ((IdleTime > Global.MAX_IDLE && !Global.IS_OFF) || (Global.IS_LOCKED && !Global.IS_OFF))
            {

                // Save the current Idle Time
                Global.LAST_IDLE = IdleTime;
                // Turn lights off
                WindowsCmdCommand.Run("start signalrgb://effect/apply/" + Uri.EscapeDataString(tb_OffEffect.Text) + "?-silentlaunch-", out string output, out string error);
                // Set the flag so we know the lights are off
                Global.IS_OFF = true;
            }
            else
            {
                //  [----                   Coming back from Idle Timeout                         ----]    [----                 Coming back from Lock                  ----]
                if ((IdleTime < Global.MAX_IDLE && Global.IS_OFF && Global.LAST_IDLE > Global.MAX_IDLE) || (IdleTime < Global.MAX_IDLE && !Global.IS_LOCKED && Global.IS_OFF))
                {
                    // Turn the lights on
                    WindowsCmdCommand.Run("start signalrgb://effect/apply/" + Uri.EscapeDataString(tb_OnEffect.Text) + "?-silentlaunch-", out string output, out string error);
                    // Reset the idle time counter
                    Global.LAST_IDLE = 0;
                    // Save light state
                    Global.IS_OFF = false;
                    Global.IS_LOCKED = false;
                }
            }
            // Refresh the label with the curent seconds idle
            label4.Text = "Idle seconds: " + IdleTime.ToString();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            // Close application window to notification area icon
            if (FormWindowState.Minimized == this.WindowState)
            {
                notifyIcon1.Visible = true;
                this.Hide();
            }
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            // dbl-click on notification icon, show the application window
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // If the user hit the titlebar "X", minimize to notification icon
            if (e.CloseReason == CloseReason.UserClosing)
            {
                notifyIcon1.Visible = true;
                this.Hide();
                e.Cancel = true;
            }
            // Save the application settings
            Properties.Settings.Default.OFF_Effect = tb_OffEffect.Text;
            Properties.Settings.Default.ON_Effect = tb_OnEffect.Text;
            Properties.Settings.Default.Timeout = int.Parse(tb_Timeout.Text);
            Properties.Settings.Default.Startup = cb_Startup.Checked;
            Properties.Settings.Default.First_Run = false;
            Properties.Settings.Default.Save();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Read the application settings
            tb_OffEffect.Text = Properties.Settings.Default.OFF_Effect.ToString();
            tb_OnEffect.Text = Properties.Settings.Default.ON_Effect.ToString();
            tb_Timeout.Text = Properties.Settings.Default.Timeout.ToString();
            cb_Startup.Checked = Properties.Settings.Default.Startup;
            bool RunCheck = Properties.Settings.Default.First_Run;
            // Send application directly to notification area icon once loaded if this isn't the first time running
            if(RunCheck)
            {
                this.Show();
                this.WindowState = FormWindowState.Normal;
            }
        }

        private void bt_Quit_Click(object sender, EventArgs e)
        {
            // User hit the "Quit" button on the window, REALLY exit the appliation now.
            Application.Exit();
        }
        static void SystemEvents_SessionSwitch(object sender, SessionSwitchEventArgs e)
        {
            if (e.Reason == SessionSwitchReason.SessionLock)
            {
                Global.IS_LOCKED = true;
            }
            if (e.Reason == SessionSwitchReason.SessionUnlock)
            {
                Global.IS_LOCKED = false;
            }
        }

        private void bt_Minimize_Click(object sender, EventArgs e)
        {
            notifyIcon1.Visible = true;
            this.Hide();
        }

        private void cb_Startup_CheckedChanged(object sender, EventArgs e)
        {
            string Shortcut_Path = Environment.GetFolderPath(Environment.SpecialFolder.Startup) + @"\SignalRGB-Sleep.lnk";
            // if not checked, remove the startup shortcut
            if (!cb_Startup.Checked)
            {
                if(System.IO.File.Exists(Shortcut_Path))
                {
                    System.IO.File.Delete(Shortcut_Path);                    
                }
            }
            // if checked, create the startup shortcut
            else 
            {
                if (!System.IO.File.Exists(Shortcut_Path))
                {
                    string Startup_Path = Environment.GetFolderPath(Environment.SpecialFolder.Startup) + @"\SignalRGB-Sleep.lnk";
                    WshShell shell = new WshShell();
                    IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(Startup_Path);
                    shortcut.Description = "SignalRGB-Sleep";
                    shortcut.TargetPath = AppDomain.CurrentDomain.BaseDirectory + "SignalRGB-Sleep.exe";
                    shortcut.WorkingDirectory = AppDomain.CurrentDomain.BaseDirectory;
                    shortcut.Save();
                }
            }
        }
    }
}
public static class Global
{
    public static uint MAX_IDLE = 0;
    public static uint LAST_IDLE = 0;
    public static bool IS_OFF = false;
    public static bool IS_LOCKED = false;
}
/// <summary>
/// Helps to find the idle time, (in milliseconds) spent since the last user input
/// </summary>
public class IdleTimeFinder
{
    [DllImport("User32.dll")]
    private static extern bool GetLastInputInfo(ref LASTINPUTINFO plii);

    [DllImport("Kernel32.dll")]
    private static extern uint GetLastError();

    public static uint GetIdleTime()
    {
        LASTINPUTINFO lastInPut = new LASTINPUTINFO();
        lastInPut.cbSize = (uint)System.Runtime.InteropServices.Marshal.SizeOf(lastInPut);
        GetLastInputInfo(ref lastInPut);

        return ((uint)Environment.TickCount - lastInPut.dwTime);
    }
    /// <summary>
    /// Get the Last input time in milliseconds
    /// </summary>
    /// <returns></returns>
    public static long GetLastInputTime()
    {
        LASTINPUTINFO lastInPut = new LASTINPUTINFO();
        lastInPut.cbSize = (uint)System.Runtime.InteropServices.Marshal.SizeOf(lastInPut);
        if (!GetLastInputInfo(ref lastInPut))
        {
            throw new Exception(GetLastError().ToString());
        }
        return lastInPut.dwTime;
    }
}

public static class WindowsCmdCommand
{
    public static void Run(string command, out string output, out string error, string directory = null)
    {
        using Process process = new Process
        {
            StartInfo = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                RedirectStandardInput = true,
                Arguments = "/c " + command,
                CreateNoWindow = true,
                WorkingDirectory = directory ?? string.Empty,
            }
        };
        process.Start();
        process.WaitForExit();
        output = process.StandardOutput.ReadToEnd();
        error = process.StandardError.ReadToEnd();
    }
}

public static class NativeMethods
{
    // Used to check if the screen saver is running
    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool SystemParametersInfo(uint uAction, uint uParam, ref bool lpvParam, int fWinIni);

    // Used to check if the workstation is locked
    [DllImport("user32", SetLastError = true)]
    private static extern IntPtr OpenDesktop(string lpszDesktop, uint dwFlags, bool fInherit, uint dwDesiredAccess);

    [DllImport("user32", SetLastError = true)]
    private static extern IntPtr OpenInputDesktop(uint dwFlags, bool fInherit, uint dwDesiredAccess);

    [DllImport("user32", SetLastError = true)]
    private static extern IntPtr CloseDesktop(IntPtr hDesktop);

    [DllImport("user32", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    private static extern bool SwitchDesktop(IntPtr hDesktop);

    // Check if the workstation has been locked.
    public static bool IsWorkstationLocked()
    {
        const int DESKTOP_SWITCHDESKTOP = 256;
        IntPtr hwnd = OpenInputDesktop(0, false, DESKTOP_SWITCHDESKTOP);
        if (hwnd == IntPtr.Zero)
        {
            // Could not get the input desktop, might be locked already?
            hwnd = OpenDesktop("Default", 0, false, DESKTOP_SWITCHDESKTOP);
        }

        // Can we switch the desktop?
        if (hwnd != IntPtr.Zero)
        {
            if (SwitchDesktop(hwnd))
            {
                // Workstation is NOT LOCKED.
                CloseDesktop(hwnd);
            }
            else
            {
                CloseDesktop(hwnd);
                // Workstation is LOCKED.
                return true;
            }
        }
        return false;
    }

    // Check if the screensaver is busy running.
    public static bool IsScreensaverRunning()
    {
        const int SPI_GETSCREENSAVERRUNNING = 114;
        bool isRunning = false;
        if (!SystemParametersInfo(SPI_GETSCREENSAVERRUNNING, 0, ref isRunning, 0))
        {
            // Could not detect screen saver status...
            return false;
        }
        if (isRunning)
        {
            // Screen saver is ON.
            return true;
        }
        // Screen saver is OFF.
        return false;
    }

}