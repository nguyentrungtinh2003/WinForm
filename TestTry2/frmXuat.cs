using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestTry2
{
    public partial class frmXuat : Form
    {
        public frmXuat()
        {
            InitializeComponent();
        }

        private void btnTinh_Click(object sender, EventArgs e)
        {
            int n;
            int sum = 0;
            string a = "";
           int.TryParse(txtN.Text, out n);
            for(int i = 1; i <= n; i++)
            {

                a += i;
                if (i < n)
                {
                    a += " + ";
                }
                sum += i;
               
            }
            txtPhep.Text = a;
            txtKQ.Text = sum.ToString();
             
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            int a, b, c;
            int.TryParse(txtA.Text, out a);
            int.TryParse(txtB.Text, out b);
            int.TryParse(txtC.Text, out c);

            // Finding the maximum value
            int max = Math.Max(a, Math.Max(b, c));

            // Finding the minimum value
            int min = Math.Min(a, Math.Min(b, c));

            // Displaying the maximum and minimum values
            txtMax.Text = max.ToString();
            txtMin.Text = min.ToString();
        }

    }
}
