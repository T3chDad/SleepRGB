using Microsoft.Win32;

namespace signalRGB_Sleep
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
            button1 = new Button();
            label4 = new Label();
            pictureBox1 = new PictureBox();
            label5 = new Label();
            label6 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(184, 15);
            label1.Name = "label1";
            label1.Size = new Size(87, 20);
            label1.TabIndex = 0;
            label1.Text = "\"Off\" Effect:";
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
            label2.Location = new Point(184, 57);
            label2.Name = "label2";
            label2.Size = new Size(85, 20);
            label2.TabIndex = 1;
            label2.Text = "\"On\" Effect:";
            // 
            // notifyIcon1
            // 
            notifyIcon1.BalloonTipIcon = ToolTipIcon.Info;
            notifyIcon1.BalloonTipText = "Minimized";
            notifyIcon1.Icon = (Icon)resources.GetObject("notifyIcon1.Icon");
            notifyIcon1.Text = "signalRGB - Sleep";
            notifyIcon1.Visible = true;
            notifyIcon1.DoubleClick += notifyIcon1_DoubleClick;
            // 
            // tb_OffEffect
            // 
            tb_OffEffect.Location = new Point(277, 12);
            tb_OffEffect.Name = "tb_OffEffect";
            tb_OffEffect.Size = new Size(181, 27);
            tb_OffEffect.TabIndex = 2;
            tb_OffEffect.Text = "Solid Color";
            // 
            // tb_OnEffect
            // 
            tb_OnEffect.Location = new Point(277, 54);
            tb_OnEffect.Name = "tb_OnEffect";
            tb_OnEffect.Size = new Size(181, 27);
            tb_OnEffect.TabIndex = 3;
            tb_OnEffect.Text = "Screen Ambience";
            // 
            // tb_Timeout
            // 
            tb_Timeout.Location = new Point(371, 96);
            tb_Timeout.Name = "tb_Timeout";
            tb_Timeout.Size = new Size(87, 27);
            tb_Timeout.TabIndex = 5;
            tb_Timeout.Text = "19";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(184, 99);
            label3.Name = "label3";
            label3.Size = new Size(181, 20);
            label3.TabIndex = 4;
            label3.Text = "Screen Timeout (Minutes):";
            // 
            // button1
            // 
            button1.Location = new Point(187, 147);
            button1.Name = "button1";
            button1.Size = new Size(104, 29);
            button1.TabIndex = 6;
            button1.Text = "Exit";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(330, 151);
            label4.Name = "label4";
            label4.Size = new Size(50, 20);
            label4.TabIndex = 7;
            label4.Text = "label4";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.avatar100x100;
            pictureBox1.Location = new Point(28, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(100, 100);
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox1.TabIndex = 8;
            pictureBox1.TabStop = false;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(12, 115);
            label5.Name = "label5";
            label5.Size = new Size(142, 23);
            label5.TabIndex = 9;
            label5.Text = "signalRGB-Sleep";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(66, 138);
            label6.Name = "label6";
            label6.Size = new Size(35, 20);
            label6.TabIndex = 10;
            label6.Text = "v0.1";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(475, 190);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(pictureBox1);
            Controls.Add(label4);
            Controls.Add(button1);
            Controls.Add(tb_Timeout);
            Controls.Add(label3);
            Controls.Add(tb_OnEffect);
            Controls.Add(tb_OffEffect);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MdiChildrenMinimizedAnchorBottom = false;
            MinimizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "signalRGB - Sleep";
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
        private Button button1;
        private Label label4;
        private PictureBox pictureBox1;
        private Label label5;
        private Label label6;
    }
}
