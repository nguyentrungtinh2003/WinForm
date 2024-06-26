using System;
using System.Drawing;
using System.Windows.Forms;

namespace Lap06GDI
{
    public partial class Form1 : Form
    {
        private Color fillcolor; //lưu trữ màu tô
        private Color bordercolor; //lưu trữ màu nét vẽ
        private Point startPoint;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnBorderColor_Click(object sender, EventArgs e)
        {
            ColorDialog dl = new ColorDialog();
            dl.FullOpen = true;
            dl.AnyColor = true;
            if (dl.ShowDialog() == DialogResult.OK)
            {
                btnBorderColor.BackColor = dl.Color;
                bordercolor = dl.Color;
            }
        }

        private void btnFillColor_Click(object sender, EventArgs e)
        {
            ColorDialog dl = new ColorDialog();
            dl.FullOpen = true;
            dl.AnyColor = true;
            if (dl.ShowDialog() == DialogResult.OK)
            {
                btnFillColor.BackColor = dl.Color;
                fillcolor = dl.Color;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            bordercolor = Color.Black;
            btnBorderColor.BackColor = bordercolor;
            fillcolor = Color.Black;
            btnFillColor.BackColor = fillcolor;
        }

        private void panelKhungVe_MouseDown(object sender, MouseEventArgs e)
        {
            startPoint = e.Location;
        }

        private void panelKhungVe_MouseUp(object sender, MouseEventArgs e)
        {
            var endPoint = e.Location;
            Graphics g = panelKhungVe.CreateGraphics();
            float borderSize = float.Parse(nudBorderSize.Value.ToString());

            if (cboType.SelectedIndex == 0) // vẽ đường thẳng
            {
                g.DrawLine(new Pen(bordercolor, borderSize), startPoint, endPoint);
            }
            else if (cboType.SelectedIndex == 1) // vẽ hình chữ nhật
            {
                float width = Math.Abs(endPoint.X - startPoint.X);
                float height = Math.Abs(endPoint.Y - startPoint.Y);
                float x = Math.Min(startPoint.X, endPoint.X);
                float y = Math.Min(startPoint.Y, endPoint.Y);

                g.DrawRectangle(new Pen(bordercolor, borderSize), x, y, width, height);
            }
            else if (cboType.SelectedIndex == 2) // vẽ hình chữ nhật có fill
            {
                float width = Math.Abs(endPoint.X - startPoint.X);
                float height = Math.Abs(endPoint.Y - startPoint.Y);
                float x = Math.Min(startPoint.X, endPoint.X);
                float y = Math.Min(startPoint.Y, endPoint.Y);

                g.FillRectangle(new SolidBrush(fillcolor), x, y, width, height);
            }
            else if (cboType.SelectedIndex == 3) // vẽ ellipse
            {
                float width = Math.Abs(endPoint.X - startPoint.X);
                float height = Math.Abs(endPoint.Y - startPoint.Y);
                float x = Math.Min(startPoint.X, endPoint.X);
                float y = Math.Min(startPoint.Y, endPoint.Y);

                g.DrawEllipse(new Pen(bordercolor, borderSize), x, y, width, height);
            }
            else if (cboType.SelectedIndex == 4) // vẽ ellipse có fill
            {
                float width = Math.Abs(endPoint.X - startPoint.X);
                float height = Math.Abs(endPoint.Y - startPoint.Y);
                float x = Math.Min(startPoint.X, endPoint.X);
                float y = Math.Min(startPoint.Y, endPoint.Y);

                g.FillEllipse(new SolidBrush(fillcolor), x, y, width, height);
            }
            else if (cboType.SelectedIndex == 5) // vẽ hình tròn
            {
                float radius = Math.Max(Math.Abs(endPoint.X - startPoint.X), Math.Abs(endPoint.Y - startPoint.Y)) / 2;
                float centerX = startPoint.X + radius;
                float centerY = startPoint.Y + radius;

                g.FillEllipse(new SolidBrush(fillcolor), centerX - radius, centerY - radius, radius * 2, radius * 2);
            }
            else if (cboType.SelectedIndex == 6) // vẽ hình tròn fill
            {
                float radius = Math.Max(Math.Abs(endPoint.X - startPoint.X), Math.Abs(endPoint.Y - startPoint.Y)) / 2;
                float centerX = startPoint.X + radius;
                float centerY = startPoint.Y + radius;

                g.FillEllipse(new SolidBrush(fillcolor), centerX - radius, centerY - radius, radius * 2, radius * 2);
            }
            else if (cboType.SelectedIndex == 7) // vẽ hình vuông
            {
                float size = Math.Min(Math.Abs(endPoint.X - startPoint.X), Math.Abs(endPoint.Y - startPoint.Y));
                float x = Math.Min(startPoint.X, endPoint.X);
                float y = Math.Min(startPoint.Y, endPoint.Y);

                g.DrawRectangle(new Pen(bordercolor, borderSize), x, y, size, size);
            }
            else if (cboType.SelectedIndex == 8) // vẽ hình vuong fill
            {
                float size = Math.Min(Math.Abs(endPoint.X - startPoint.X), Math.Abs(endPoint.Y - startPoint.Y));
                float x = Math.Min(startPoint.X, endPoint.X);
                float y = Math.Min(startPoint.Y, endPoint.Y);

                g.FillRectangle(new SolidBrush(fillcolor), x, y, size, size);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Bitmap Image|*.bmp|JPEG Image|*.jpeg|PNG Image|*.png";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (var bitmap = new Bitmap(panelKhungVe.Width, panelKhungVe.Height))
                {
                    // Tạo đối tượng Graphics từ bitmap
                    using (Graphics g = Graphics.FromImage(bitmap))
                    {
                        // Vẽ nội dung của panelKhungVe lên bitmap
                        panelKhungVe.DrawToBitmap(bitmap, new Rectangle(0, 0, panelKhungVe.Width, panelKhungVe.Height));
                    }

                    // Lưu bitmap vào tập tin hình ảnh
                    bitmap.Save(saveFileDialog.FileName);
                }
            }
        }


        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp|All Files|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;

                // Tải hình ảnh 
                Image image = Image.FromFile(filePath);

                // Hiển thị hình ảnh trên panelKhungVe
                panelKhungVe.BackgroundImage = image;
                panelKhungVe.BackgroundImageLayout = ImageLayout.Zoom; // Có thể thay đổi ImageLayout tùy theo yêu cầu của bạn
            }
        }
    }
}
