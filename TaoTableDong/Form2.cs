using System;
using System.Windows.Forms;

namespace TaoTableDong
{
    public partial class Form2 : Form
    {
        public Form2(int dong, int cot)
        {
            InitializeComponent();
            TaoButton(dong, cot);
        }

        private void TaoButton(int dong, int cot)
        {
            // Tạo các button với số dòng và số cột đã được chỉ định
            int buttonWidth = 50; // Chiều rộng của mỗi button
            int buttonHeight = 30; // Chiều cao của mỗi button
            int margin = 10; // Khoảng cách giữa các button

            // Tính toán kích thước của Form
            int formWidth = cot * (buttonWidth + margin) + margin;
            int formHeight = dong * (buttonHeight + margin) + margin;
            this.Size = new System.Drawing.Size(formWidth, formHeight);

            // Tạo các button và đặt vị trí cho mỗi button
            int buttonIndex = 1;
            for (int i = 0; i < dong; i++)
            {
                for (int j = 0; j < cot; j++)
                {
                    Button button = new Button();
                    button.Text = buttonIndex.ToString();
                    button.Size = new System.Drawing.Size(buttonWidth, buttonHeight);
                    button.Location = new System.Drawing.Point(j * (buttonWidth + margin) + margin, i * (buttonHeight + margin) + margin);
                    button.Click += Button_Click;
                    this.Controls.Add(button);
                    buttonIndex++;
                }
            }
        }

        private void Button_Click(object sender, EventArgs e)
        {
            // Hiển thị vị trí của button khi được click
            Button clickedButton = sender as Button;
            MessageBox.Show("Button thu " + clickedButton.Text);
        }
    }
}
