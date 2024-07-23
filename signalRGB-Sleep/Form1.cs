using System;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Windows.Forms;
using System.Security.Policy;

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
            if (IdleTime > Global.MAX_IDLE && !Global.IS_OFF)
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
                if (IdleTime < Global.MAX_IDLE && Global.LAST_IDLE > Global.MAX_IDLE)
                {
                    // Turn the lights on
                    WindowsCmdCommand.Run("start signalrgb://effect/apply/" + Uri.EscapeDataString(tb_OnEffect.Text) + "?-silentlaunch-", out string output, out string error);
                    // Reset the idle time counter
                    Global.LAST_IDLE = 0;
                    // Save light state
                    Global.IS_OFF = false;
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
            Properties.Settings.Default.Save();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Send application directly to notification area icon once loaded
            notifyIcon1.Visible = true;
            this.Hide();
            // Read the application settings
            tb_OffEffect.Text = Properties.Settings.Default.OFF_Effect.ToString();
            tb_OnEffect.Text = Properties.Settings.Default.ON_Effect.ToString();
            tb_Timeout.Text = Properties.Settings.Default.Timeout.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // User hit the "Exit" button on the window, REALLY exit the appliation now.
            Application.Exit();
        }
    }

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

public static class Global
{
    public static uint MAX_IDLE = 0;
    public static uint LAST_IDLE = 0;
    public static bool IS_OFF = false;
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