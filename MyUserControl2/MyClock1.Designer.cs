namespace MyUserControl2
{
    partial class MyClock1
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
            btnlap = new Button();
            lblDongHo = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            SuspendLayout();
            // 
            // btnStart
            // 
            btnStart.Location = new Point(99, 202);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(190, 55);
            btnStart.TabIndex = 0;
            btnStart.Text = "Start";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click;
            // 
            // btnlap
            // 
            btnlap.Location = new Point(469, 202);
            btnlap.Name = "btnlap";
            btnlap.Size = new Size(172, 55);
            btnlap.TabIndex = 1;
            btnlap.Text = "Lap";
            btnlap.UseVisualStyleBackColor = true;
            btnlap.Click += btnlap_Click;
            // 
            // lblDongHo
            // 
            lblDongHo.AutoSize = true;
            lblDongHo.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDongHo.Location = new Point(253, 102);
            lblDongHo.Name = "lblDongHo";
            lblDongHo.Size = new Size(263, 54);
            lblDongHo.TabIndex = 2;
            lblDongHo.Text = "00:00:00 000";
            // 
            // UserControl1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lblDongHo);
            Controls.Add(btnlap);
            Controls.Add(btnStart);
            Name = "UserControl1";
            Size = new Size(800, 450);
            Load += UserControl1_Load;
            DoubleClick += btnStart_Click;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnStart;
        private Button btnlap;
        private Label lblDongHo;
        private System.Windows.Forms.Timer timer1;
    }
}
