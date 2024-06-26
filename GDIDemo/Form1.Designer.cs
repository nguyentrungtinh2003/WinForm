namespace GDIDemo
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
            btnChonMau = new Button();
            panel1 = new Panel();
            txtNoiDung = new TextBox();
            btnVeChu = new Button();
            label1 = new Label();
            label2 = new Label();
            txtX = new TextBox();
            txtY = new TextBox();
            SuspendLayout();
            // 
            // btnChonMau
            // 
            btnChonMau.BackColor = SystemColors.ActiveCaptionText;
            btnChonMau.Location = new Point(26, 43);
            btnChonMau.Name = "btnChonMau";
            btnChonMau.Size = new Size(180, 59);
            btnChonMau.TabIndex = 0;
            btnChonMau.Text = "Color";
            btnChonMau.UseVisualStyleBackColor = false;
            btnChonMau.Click += btnChonMau_Click;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ButtonHighlight;
            panel1.Location = new Point(233, 43);
            panel1.Name = "panel1";
            panel1.Size = new Size(526, 343);
            panel1.TabIndex = 1;
            // 
            // txtNoiDung
            // 
            txtNoiDung.Location = new Point(27, 271);
            txtNoiDung.Name = "txtNoiDung";
            txtNoiDung.Size = new Size(179, 27);
            txtNoiDung.TabIndex = 2;
            // 
            // btnVeChu
            // 
            btnVeChu.BackColor = Color.DodgerBlue;
            btnVeChu.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnVeChu.ForeColor = SystemColors.ButtonHighlight;
            btnVeChu.Location = new Point(26, 342);
            btnVeChu.Name = "btnVeChu";
            btnVeChu.Size = new Size(180, 44);
            btnVeChu.TabIndex = 3;
            btnVeChu.Text = "Vẽ chữ";
            btnVeChu.UseVisualStyleBackColor = false;
            btnVeChu.Click += btnVeChu_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(30, 136);
            label1.Name = "label1";
            label1.Size = new Size(28, 31);
            label1.TabIndex = 4;
            label1.Text = "X";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(32, 193);
            label2.Name = "label2";
            label2.Size = new Size(27, 31);
            label2.TabIndex = 5;
            label2.Text = "Y";
            // 
            // txtX
            // 
            txtX.Location = new Point(81, 136);
            txtX.Name = "txtX";
            txtX.Size = new Size(125, 27);
            txtX.TabIndex = 6;
            // 
            // txtY
            // 
            txtY.Location = new Point(81, 190);
            txtY.Name = "txtY";
            txtY.Size = new Size(125, 27);
            txtY.TabIndex = 7;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 435);
            Controls.Add(txtY);
            Controls.Add(txtX);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnVeChu);
            Controls.Add(txtNoiDung);
            Controls.Add(panel1);
            Controls.Add(btnChonMau);
            Name = "Form1";
            Text = " ";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnChonMau;
        private Panel panel1;
        private TextBox txtNoiDung;
        private Button btnVeChu;
        private Label label1;
        private Label label2;
        private TextBox txtX;
        private TextBox txtY;
    }
}
