using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cinema
{
    public partial class PurchaseSuccessForm : Form
    {
        public PurchaseSuccessForm(int selectedSeatCount)
        {
            InitializeComponent();
            lblMessage.Text = $"Bạn đã mua thành công {selectedSeatCount - 1} ghế !";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
