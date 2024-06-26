using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestTry
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtN.Text, out int N) && double.TryParse(txtX.Text, out double X))
            {
                string resultS1 = ""; // Chuỗi kết quả cho txtS1
                string resultS2 = ""; // Chuỗi kết quả cho txtS2
                string resultS3 = ""; // Chuỗi kết quả cho txtS3
                double resultS4 = 0; // Kết quả cho txtS4

                for (int i = 1; i <= N; i++)
                {
                    resultS1 += $"{(i > 1 ? "+" : "")}X^{i}";
                    resultS2 += $"{(i > 1 ? "+" : "")}{X}^{i}"; // Xây dựng chuỗi cho txtS1
                    resultS3 += $"{(i > 1 ? "+" : "")}{Math.Pow(X, i)}"; // Xây dựng chuỗi cho txtS2
                   // Xây dựng phần tử cho txtS3
                    if (i < N) // Kiểm tra xem i có phải là phần tử cuối cùng không để thêm dấu "="
                        resultS3 += "";
                }

               ; // Thêm kết quả cuối cùng vào txtS3

                for(int i = 1; i <= N; i++)
                {
                    resultS4 += Math.Pow(X, i); 
                }
                // Tính tổng cho txtS4

                txtS1.Text = resultS1; // Gán chuỗi kết quả cho txtS1
                txtS2.Text = resultS2; // Gán chuỗi kết quả cho txtS2
                txtS3.Text = resultS3; // Gán chuỗi kết quả cho txtS3
                txtS4.Text = resultS4.ToString(); // Gán kết quả cho txtS4
            }
            else
            {
                MessageBox.Show("Vui lòng nhập số nguyên dương cho N và số thực cho X.");
            }
        }
    }
}
