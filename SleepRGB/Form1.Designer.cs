using Microsoft.Win32;

namespace SleepRGB
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            label1 = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            label2 = new Label();
            notifyIcon1 = new NotifyIcon(components);
            tb_OffEffect = new TextBox();
            tb_OnEffect = new TextBox();
            tb_Timeout = new TextBox();
            label3 = new Label();
            bt_Quit = new Button();
            label4 = new Label();
            pictureBox1 = new PictureBox();
            label5 = new Label();
            label6 = new Label();
            cb_Startup = new CheckBox();
            bt_Minimize = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(307, 24);
            label1.Margin = new Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new Size(145, 32);
            label1.TabIndex = 0;
            label1.Text = "Sleep Effect:";
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Interval = 1000;
            timer1.Tick += timer1_Tick;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(307, 104);
            label2.Margin = new Padding(5, 0, 5, 0);
            label2.Name = "label2";
            label2.Size = new Size(144, 32);
            label2.TabIndex = 1;
            label2.Text = "Wake Effect:";
            // 
            // notifyIcon1
            // 
            notifyIcon1.BalloonTipIcon = ToolTipIcon.Info;
            notifyIcon1.BalloonTipText = "Minimized";
            notifyIcon1.Icon = (Icon)resources.GetObject("notifyIcon1.Icon");
            notifyIcon1.Text = "SleepRGB";
            notifyIcon1.Visible = true;
            notifyIcon1.DoubleClick += notifyIcon1_DoubleClick;
            // 
            // tb_OffEffect
            // 
            tb_OffEffect.Location = new Point(458, 19);
            tb_OffEffect.Margin = new Padding(5);
            tb_OffEffect.Name = "tb_OffEffect";
            tb_OffEffect.Size = new Size(292, 39);
            tb_OffEffect.TabIndex = 2;
            tb_OffEffect.Text = "Solid Color";
            // 
            // tb_OnEffect
            // 
            tb_OnEffect.Location = new Point(458, 99);
            tb_OnEffect.Margin = new Padding(5);
            tb_OnEffect.Name = "tb_OnEffect";
            tb_OnEffect.Size = new Size(292, 39);
            tb_OnEffect.TabIndex = 3;
            tb_OnEffect.Text = "Screen Ambience";
            // 
            // tb_Timeout
            // 
            tb_Timeout.Location = new Point(611, 179);
            tb_Timeout.Margin = new Padding(5);
            tb_Timeout.Name = "tb_Timeout";
            tb_Timeout.Size = new Size(139, 39);
            tb_Timeout.TabIndex = 5;
            tb_Timeout.Text = "19";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(307, 184);
            label3.Margin = new Padding(5, 0, 5, 0);
            label3.Name = "label3";
            label3.Size = new Size(295, 32);
            label3.TabIndex = 4;
            label3.Text = "Screen Timeout (Minutes):";
            // 
            // bt_Quit
            // 
            bt_Quit.Location = new Point(307, 270);
            bt_Quit.Margin = new Padding(5);
            bt_Quit.Name = "bt_Quit";
            bt_Quit.Size = new Size(202, 46);
            bt_Quit.TabIndex = 6;
            bt_Quit.Text = "Quit Program";
            bt_Quit.UseVisualStyleBackColor = true;
            bt_Quit.Click += bt_Quit_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(197, -18);
            label4.Margin = new Padding(5, 0, 5, 0);
            label4.Name = "label4";
            label4.Size = new Size(78, 32);
            label4.TabIndex = 7;
            label4.Text = "label4";
            label4.Visible = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(46, 19);
            pictureBox1.Margin = new Padding(5);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(100, 98);
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox1.TabIndex = 8;
            pictureBox1.TabStop = false;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(20, 184);
            label5.Margin = new Padding(5, 0, 5, 0);
            label5.Name = "label5";
            label5.Size = new Size(144, 38);
            label5.TabIndex = 9;
            label5.Text = "SleepRGB";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(107, 221);
            label6.Margin = new Padding(5, 0, 5, 0);
            label6.Name = "label6";
            label6.Size = new Size(57, 32);
            label6.TabIndex = 10;
            label6.Text = "v0.1";
            // 
            // cb_Startup
            // 
            cb_Startup.AutoSize = true;
            cb_Startup.Location = new Point(20, 275);
            cb_Startup.Margin = new Padding(5);
            cb_Startup.Name = "cb_Startup";
            cb_Startup.Size = new Size(250, 36);
            cb_Startup.TabIndex = 11;
            cb_Startup.Text = "Start with Windows";
            cb_Startup.UseVisualStyleBackColor = true;
            cb_Startup.CheckedChanged += cb_Startup_CheckedChanged;
            // 
            // bt_Minimize
            // 
            bt_Minimize.Location = new Point(518, 270);
            bt_Minimize.Margin = new Padding(5);
            bt_Minimize.Name = "bt_Minimize";
            bt_Minimize.Size = new Size(234, 46);
            bt_Minimize.TabIndex = 12;
            bt_Minimize.Text = "Minimize to Tray";
            bt_Minimize.UseVisualStyleBackColor = true;
            bt_Minimize.Click += bt_Minimize_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(774, 339);
            ControlBox = false;
            Controls.Add(bt_Minimize);
            Controls.Add(cb_Startup);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(pictureBox1);
            Controls.Add(label4);
            Controls.Add(bt_Quit);
            Controls.Add(tb_Timeout);
            Controls.Add(label3);
            Controls.Add(tb_OnEffect);
            Controls.Add(tb_OffEffect);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(5);
            MaximizeBox = false;
            MdiChildrenMinimizedAnchorBottom = false;
            MinimizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SleepRGB";
            WindowState = FormWindowState.Minimized;
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            Resize += Form1_Resize;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private System.Windows.Forms.Timer timer1;
        private Label label2;
        private NotifyIcon notifyIcon1;
        private TextBox tb_OffEffect;
        private TextBox tb_OnEffect;
        private TextBox tb_Timeout;
        private Label label3;
        private Button bt_Quit;
        private Label label4;
        private PictureBox pictureBox1;
        private Label label5;
        private Label label6;
        private CheckBox cb_Startup;
        private Button bt_Minimize;
    }
}
