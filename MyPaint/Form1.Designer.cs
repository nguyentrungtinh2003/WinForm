namespace MyPaint
{
    partial class Form1
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
            this.paintCanvas = new System.Windows.Forms.PictureBox();
            this.colorPicker = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.solidBrushRadioButton = new System.Windows.Forms.CheckBox();
            this.linearGradientBrushRadioButton = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lineRadioButton = new System.Windows.Forms.RadioButton();
            this.squareRadioButton = new System.Windows.Forms.RadioButton();
            this.circleRadioButton = new System.Windows.Forms.RadioButton();
            this.parallelogramRadioButton = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.paintCanvas)).BeginInit();
            this.SuspendLayout();
            // 
            // paintCanvas
            // 
            this.paintCanvas.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.paintCanvas.Location = new System.Drawing.Point(25, 56);
            this.paintCanvas.Name = "paintCanvas";
            this.paintCanvas.Size = new System.Drawing.Size(746, 245);
            this.paintCanvas.TabIndex = 0;
            this.paintCanvas.TabStop = false;
            this.paintCanvas.Paint += new System.Windows.Forms.PaintEventHandler(this.paintCanvas_Paint);
            this.paintCanvas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PaintCanvas_MouseDown);
            this.paintCanvas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PaintCanvas_MouseMove);
            this.paintCanvas.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PaintCanvas_MouseUp);
            // 
            // colorPicker
            // 
            this.colorPicker.BackColor = System.Drawing.Color.DodgerBlue;
            this.colorPicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colorPicker.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.colorPicker.Location = new System.Drawing.Point(550, 374);
            this.colorPicker.Name = "colorPicker";
            this.colorPicker.Size = new System.Drawing.Size(90, 51);
            this.colorPicker.TabIndex = 1;
            this.colorPicker.Text = "Color";
            this.colorPicker.UseVisualStyleBackColor = false;
            this.colorPicker.Click += new System.EventHandler(this.colorPicker_Click);
            // 
            // saveButton
            // 
            this.saveButton.BackColor = System.Drawing.Color.LightSeaGreen;
            this.saveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.saveButton.Location = new System.Drawing.Point(672, 374);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(90, 51);
            this.saveButton.TabIndex = 2;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = false;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // solidBrushRadioButton
            // 
            this.solidBrushRadioButton.AutoSize = true;
            this.solidBrushRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.solidBrushRadioButton.Location = new System.Drawing.Point(25, 392);
            this.solidBrushRadioButton.Name = "solidBrushRadioButton";
            this.solidBrushRadioButton.Size = new System.Drawing.Size(96, 33);
            this.solidBrushRadioButton.TabIndex = 3;
            this.solidBrushRadioButton.Text = "Solid";
            this.solidBrushRadioButton.UseVisualStyleBackColor = true;
            this.solidBrushRadioButton.CheckedChanged += new System.EventHandler(this.solidBrushRadioButton_CheckedChanged);
            this.solidBrushRadioButton.Click += new System.EventHandler(this.solidBrushRadioButton_CheckedChanged);
            // 
            // linearGradientBrushRadioButton
            // 
            this.linearGradientBrushRadioButton.AutoSize = true;
            this.linearGradientBrushRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linearGradientBrushRadioButton.Location = new System.Drawing.Point(127, 392);
            this.linearGradientBrushRadioButton.Name = "linearGradientBrushRadioButton";
            this.linearGradientBrushRadioButton.Size = new System.Drawing.Size(108, 33);
            this.linearGradientBrushRadioButton.TabIndex = 4;
            this.linearGradientBrushRadioButton.Text = "Linear";
            this.linearGradientBrushRadioButton.UseVisualStyleBackColor = true;
            this.linearGradientBrushRadioButton.CheckedChanged += new System.EventHandler(this.linearGradientBrushRadioButton_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Azure;
            this.label1.Location = new System.Drawing.Point(29, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 32);
            this.label1.TabIndex = 5;
            this.label1.Text = "My Paint";
            // 
            // lineRadioButton
            // 
            this.lineRadioButton.AutoSize = true;
            this.lineRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lineRadioButton.Location = new System.Drawing.Point(25, 351);
            this.lineRadioButton.Name = "lineRadioButton";
            this.lineRadioButton.Size = new System.Drawing.Size(84, 33);
            this.lineRadioButton.TabIndex = 6;
            this.lineRadioButton.TabStop = true;
            this.lineRadioButton.Text = "Line";
            this.lineRadioButton.UseVisualStyleBackColor = true;
            // 
            // squareRadioButton
            // 
            this.squareRadioButton.AutoSize = true;
            this.squareRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.squareRadioButton.Location = new System.Drawing.Point(127, 351);
            this.squareRadioButton.Name = "squareRadioButton";
            this.squareRadioButton.Size = new System.Drawing.Size(118, 33);
            this.squareRadioButton.TabIndex = 7;
            this.squareRadioButton.TabStop = true;
            this.squareRadioButton.Text = "Square";
            this.squareRadioButton.UseVisualStyleBackColor = true;
            // 
            // circleRadioButton
            // 
            this.circleRadioButton.AutoSize = true;
            this.circleRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.circleRadioButton.Location = new System.Drawing.Point(25, 307);
            this.circleRadioButton.Name = "circleRadioButton";
            this.circleRadioButton.Size = new System.Drawing.Size(103, 33);
            this.circleRadioButton.TabIndex = 8;
            this.circleRadioButton.TabStop = true;
            this.circleRadioButton.Text = "Circle";
            this.circleRadioButton.UseVisualStyleBackColor = true;
            // 
            // parallelogramRadioButton
            // 
            this.parallelogramRadioButton.AutoSize = true;
            this.parallelogramRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.parallelogramRadioButton.Location = new System.Drawing.Point(127, 307);
            this.parallelogramRadioButton.Name = "parallelogramRadioButton";
            this.parallelogramRadioButton.Size = new System.Drawing.Size(198, 33);
            this.parallelogramRadioButton.TabIndex = 9;
            this.parallelogramRadioButton.TabStop = true;
            this.parallelogramRadioButton.Text = "Parallelogram";
            this.parallelogramRadioButton.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Red;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button1.Location = new System.Drawing.Point(720, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(51, 40);
            this.button1.TabIndex = 10;
            this.button1.Text = "X";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.parallelogramRadioButton);
            this.Controls.Add(this.circleRadioButton);
            this.Controls.Add(this.squareRadioButton);
            this.Controls.Add(this.lineRadioButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.linearGradientBrushRadioButton);
            this.Controls.Add(this.solidBrushRadioButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.colorPicker);
            this.Controls.Add(this.paintCanvas);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.paintCanvas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox paintCanvas;
        private System.Windows.Forms.Button colorPicker;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.CheckBox solidBrushRadioButton;
        private System.Windows.Forms.CheckBox linearGradientBrushRadioButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton lineRadioButton;
        private System.Windows.Forms.RadioButton squareRadioButton;
        private System.Windows.Forms.RadioButton circleRadioButton;
        private System.Windows.Forms.RadioButton parallelogramRadioButton;
        private System.Windows.Forms.Button button1;
    }
}

