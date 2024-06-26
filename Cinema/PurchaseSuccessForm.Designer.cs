namespace Cinema
{
    partial class PurchaseSuccessForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            button1 = new Button();
            lblMessage = new Label();
            button2 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(139, 178);
            label1.Name = "label1";
            label1.Size = new Size(0, 41);
            label1.TabIndex = 0;
            // 
            // button1
            // 
            button1.BackColor = Color.Fuchsia;
            button1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = SystemColors.ButtonHighlight;
            button1.Location = new Point(-5, 1);
            button1.Name = "button1";
            button1.Size = new Size(805, 56);
            button1.TabIndex = 1;
            button1.Text = "Thông báo";
            button1.UseVisualStyleBackColor = false;
            // 
            // lblMessage
            // 
            lblMessage.AutoSize = true;
            lblMessage.BackColor = Color.Fuchsia;
            lblMessage.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblMessage.ForeColor = SystemColors.ControlLightLight;
            lblMessage.Location = new Point(110, 195);
            lblMessage.Name = "lblMessage";
            lblMessage.Size = new Size(96, 38);
            lblMessage.TabIndex = 2;
            lblMessage.Text = "label2";
            // 
            // button2
            // 
            button2.BackColor = Color.Fuchsia;
            button2.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.ForeColor = SystemColors.ControlLightLight;
            button2.Location = new Point(615, 368);
            button2.Name = "button2";
            button2.Size = new Size(124, 53);
            button2.TabIndex = 3;
            button2.Text = "Thoát";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // PurchaseSuccessForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button2);
            Controls.Add(lblMessage);
            Controls.Add(button1);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "PurchaseSuccessForm";
            Text = "PurchaseSuccessForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button button1;
        private Label lblMessage;
        private Button button2;
    }
}