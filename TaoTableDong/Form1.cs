using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaoTableDong
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnTao_Click(object sender, EventArgs e)
        {
            // Lấy giá trị từ textbox
            int dong = Convert.ToInt32(txtDong.Text);
            int cot = Convert.ToInt32(txtCot.Text);

            // Hiển thị Form2 với bảng được tạo
            Form2 form2 = new Form2(dong, cot);
            form2.Show();

        }
    }
}
