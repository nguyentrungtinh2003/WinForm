namespace Lap06GDI
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
            splitContainer1 = new SplitContainer();
            button2 = new Button();
            button1 = new Button();
            nudBorderSize = new NumericUpDown();
            btnFillColor = new Button();
            btnBorderColor = new Button();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            cboType = new ComboBox();
            label1 = new Label();
            panelKhungVe = new Panel();
            button3 = new Button();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudBorderSize).BeginInit();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.BackColor = Color.WhiteSmoke;
            splitContainer1.Panel1.Controls.Add(button3);
            splitContainer1.Panel1.Controls.Add(button2);
            splitContainer1.Panel1.Controls.Add(button1);
            splitContainer1.Panel1.Controls.Add(nudBorderSize);
            splitContainer1.Panel1.Controls.Add(btnFillColor);
            splitContainer1.Panel1.Controls.Add(btnBorderColor);
            splitContainer1.Panel1.Controls.Add(label6);
            splitContainer1.Panel1.Controls.Add(label5);
            splitContainer1.Panel1.Controls.Add(label4);
            splitContainer1.Panel1.Controls.Add(label3);
            splitContainer1.Panel1.Controls.Add(label2);
            splitContainer1.Panel1.Controls.Add(cboType);
            splitContainer1.Panel1.Controls.Add(label1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(panelKhungVe);
            splitContainer1.Size = new Size(800, 510);
            splitContainer1.SplitterDistance = 266;
            splitContainer1.TabIndex = 0;
            // 
            // button2
            // 
            button2.BackColor = Color.CornflowerBlue;
            button2.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.ForeColor = SystemColors.ButtonHighlight;
            button2.Location = new Point(65, 448);
            button2.Name = "button2";
            button2.Size = new Size(104, 50);
            button2.TabIndex = 11;
            button2.Text = "Save";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.IndianRed;
            button1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = SystemColors.ButtonHighlight;
            button1.Location = new Point(175, 448);
            button1.Name = "button1";
            button1.Size = new Size(58, 50);
            button1.TabIndex = 10;
            button1.Text = "X";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // nudBorderSize
            // 
            nudBorderSize.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            nudBorderSize.Location = new Point(119, 227);
            nudBorderSize.Name = "nudBorderSize";
            nudBorderSize.Size = new Size(114, 38);
            nudBorderSize.TabIndex = 9;
            // 
            // btnFillColor
            // 
            btnFillColor.BackColor = SystemColors.ActiveCaptionText;
            btnFillColor.FlatStyle = FlatStyle.Flat;
            btnFillColor.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            btnFillColor.Location = new Point(119, 369);
            btnFillColor.Name = "btnFillColor";
            btnFillColor.Size = new Size(114, 31);
            btnFillColor.TabIndex = 8;
            btnFillColor.UseVisualStyleBackColor = false;
            btnFillColor.Click += btnFillColor_Click;
            // 
            // btnBorderColor
            // 
            btnBorderColor.BackColor = SystemColors.ActiveCaptionText;
            btnBorderColor.FlatStyle = FlatStyle.Flat;
            btnBorderColor.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            btnBorderColor.Location = new Point(119, 161);
            btnBorderColor.Name = "btnBorderColor";
            btnBorderColor.Size = new Size(114, 31);
            btnBorderColor.TabIndex = 7;
            btnBorderColor.UseVisualStyleBackColor = false;
            btnBorderColor.Click += btnBorderColor_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            label6.Location = new Point(23, 369);
            label6.Name = "label6";
            label6.Size = new Size(72, 31);
            label6.TabIndex = 6;
            label6.Text = "Color";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            label5.Location = new Point(23, 317);
            label5.Name = "label5";
            label5.Size = new Size(47, 31);
            label5.TabIndex = 5;
            label5.Text = "Fill";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            label4.Location = new Point(18, 220);
            label4.Name = "label4";
            label4.Size = new Size(57, 31);
            label4.TabIndex = 4;
            label4.Text = "Size";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            label3.Location = new Point(18, 161);
            label3.Name = "label3";
            label3.Size = new Size(72, 31);
            label3.TabIndex = 3;
            label3.Text = "Color";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            label2.Location = new Point(18, 113);
            label2.Name = "label2";
            label2.Size = new Size(87, 31);
            label2.TabIndex = 2;
            label2.Text = "Border";
            // 
            // cboType
            // 
            cboType.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            cboType.FormattingEnabled = true;
            cboType.Items.AddRange(new object[] { "Line", "Rectangle", "Fill Rectangle", "Ellipse", "Fill Ellipse", "Circle", "FillCircle", "Square", "FillSquare" });
            cboType.Location = new Point(12, 71);
            cboType.Name = "cboType";
            cboType.Size = new Size(221, 39);
            cboType.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            label1.Location = new Point(18, 18);
            label1.Name = "label1";
            label1.Size = new Size(64, 31);
            label1.TabIndex = 0;
            label1.Text = "Type";
            // 
            // panelKhungVe
            // 
            panelKhungVe.BackColor = SystemColors.ControlLightLight;
            panelKhungVe.Dock = DockStyle.Fill;
            panelKhungVe.Location = new Point(0, 0);
            panelKhungVe.Name = "panelKhungVe";
            panelKhungVe.Size = new Size(530, 510);
            panelKhungVe.TabIndex = 0;
            panelKhungVe.MouseDown += panelKhungVe_MouseDown;
            panelKhungVe.MouseUp += panelKhungVe_MouseUp;
            // 
            // button3
            // 
            button3.Location = new Point(12, 448);
            button3.Name = "button3";
            button3.Size = new Size(47, 50);
            button3.TabIndex = 12;
            button3.Text = "button3";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 510);
            Controls.Add(splitContainer1);
            Name = "Form1";
            Text = "My Paint";
            Load += Form1_Load;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)nudBorderSize).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private Label label2;
        private ComboBox cboType;
        private Label label1;
        private Panel panelKhungVe;
        private NumericUpDown nudBorderSize;
        private Button btnFillColor;
        private Button btnBorderColor;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Button button2;
        private Button button1;
        private Button button3;
    }
}
