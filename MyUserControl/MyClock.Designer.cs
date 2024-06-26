namespace MyUserControl
{
    partial class MyClock
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            btnStart = new Button();
            btnLap = new Button();
            label1 = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            SuspendLayout();
            // 
            // btnStart
            // 
            btnStart.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            btnStart.Location = new Point(152, 285);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(168, 61);
            btnStart.TabIndex = 0;
            btnStart.Text = "Start";
            btnStart.UseVisualStyleBackColor = true;
         
            // 
            // btnLap
            // 
            btnLap.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            btnLap.Location = new Point(472, 285);
            btnLap.Name = "btnLap";
            btnLap.Size = new Size(176, 61);
            btnLap.TabIndex = 1;
            btnLap.Text = "Lap";
            btnLap.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(206, 149);
            label1.Name = "label1";
            label1.Size = new Size(399, 81);
            label1.TabIndex = 2;
            label1.Text = "00:00:00 000";
            // 
            // MyClock
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(label1);
            Controls.Add(btnLap);
            Controls.Add(btnStart);
            Name = "MyClock";
            Size = new Size(800, 450);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnStart;
        private Button btnLap;
        private Label label1;
        private System.Windows.Forms.Timer timer1;
    }
}
