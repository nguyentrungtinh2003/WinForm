using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MyPaint
{
    public partial class Form1 : Form
    {
        private List<Shape> shapes = new List<Shape>();
        private Shape currentShape;
        private Color currentColor = Color.Black;
        private BrushType currentBrushType = BrushType.Solid;
        private ShapeType currentShapeType = ShapeType.Line;

        public Form1()
        {
            InitializeComponent();
            InitializePaintCanvas();
        }

        private void InitializePaintCanvas()
        {
            paintCanvas.BackColor = Color.White;
            paintCanvas.MouseDown += PaintCanvas_MouseDown;
            paintCanvas.MouseMove += PaintCanvas_MouseMove;
            paintCanvas.MouseUp += PaintCanvas_MouseUp;

            // Thêm các RadioButton từ Toolbox và gán sự kiện CheckedChanged
            lineRadioButton.CheckedChanged += RadioButton_CheckedChanged;
            circleRadioButton.CheckedChanged += RadioButton_CheckedChanged;
            squareRadioButton.CheckedChanged += RadioButton_CheckedChanged;
            parallelogramRadioButton.CheckedChanged += RadioButton_CheckedChanged;
        }

        private void PaintCanvas_MouseDown(object sender, MouseEventArgs e)
        {
            switch (currentBrushType)
            {
                case BrushType.Solid:
                    switch (currentShapeType)
                    {
                        case ShapeType.Line:
                            currentShape = new SolidLine(currentColor);
                            break;
                        case ShapeType.Circle:
                            currentShape = new SolidCircle(currentColor);
                            break;
                        case ShapeType.Square:
                            currentShape = new SolidSquare(currentColor);
                            break;
                        case ShapeType.Parallelogram:
                            currentShape = new SolidParallelogram(currentColor);
                            break;
                    }
                    break;
                    // Xử lý cho các loại Brush khác nếu cần
            }
            currentShape.StartPoint = e.Location;
        }

        private void PaintCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (currentShape != null && e.Button == MouseButtons.Left)
            {
                currentShape.EndPoint = e.Location;
                paintCanvas.Invalidate();
            }
        }

        private void PaintCanvas_MouseUp(object sender, MouseEventArgs e)
        {
            if (currentShape != null)
            {
                currentShape.EndPoint = e.Location;
                shapes.Add(currentShape);
                currentShape = null;
                paintCanvas.Invalidate();
            }
        }

        private void paintCanvas_Paint(object sender, PaintEventArgs e)
        {
            foreach (var shape in shapes)
            {
                shape.Draw(e.Graphics);
            }
            if (currentShape != null)
            {
                currentShape.Draw(e.Graphics);
            }
        }

        private void colorPicker_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                currentColor = colorDialog.Color;
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Bitmap Image|*.bmp|JPEG Image|*.jpeg|PNG Image|*.png";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (var bitmap = new Bitmap(paintCanvas.Width, paintCanvas.Height))
                {
                    paintCanvas.DrawToBitmap(bitmap, new Rectangle(0, 0, paintCanvas.Width, paintCanvas.Height));
                    bitmap.Save(saveFileDialog.FileName);
                }
            }
        }

        private void solidBrushRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (solidBrushRadioButton.Checked)
            {
                currentBrushType = BrushType.Solid;
                paintCanvas.Invalidate();
            }
        }

       

        private void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioButton = sender as RadioButton;
            if (radioButton.Checked)
            {
                if (radioButton == lineRadioButton)
                    currentShapeType = ShapeType.Line;
                else if (radioButton == circleRadioButton)
                    currentShapeType = ShapeType.Circle;
                else if (radioButton == squareRadioButton)
                    currentShapeType = ShapeType.Square;
                else if (radioButton == parallelogramRadioButton)
                    currentShapeType = ShapeType.Parallelogram;
            }
        }

        // Các class con cho mỗi loại hình vẽ
        // Code các class SolidCircle, SolidSquare, SolidParallelogram, SolidLine
        // tương tự như trong mã của bạn

        // Enum cho loại hình vẽ và loại brush
        class SolidLine : Shape
        {
            public SolidLine(Color color) : base(color) { }

            public override void Draw(Graphics g)
            {
                using (var pen = new Pen(Color))
                {
                    g.DrawLine(pen, StartPoint, EndPoint);
                }
            }
        }
        class SolidCircle : Shape
        {
            public SolidCircle(Color color) : base(color) { }

            public override void Draw(Graphics g)
            {
                int diameter = Math.Max(Math.Abs(EndPoint.X - StartPoint.X), Math.Abs(EndPoint.Y - StartPoint.Y));
                int radius = diameter / 2;
                int centerX = Math.Min(StartPoint.X, EndPoint.X) + radius;
                int centerY = Math.Min(StartPoint.Y, EndPoint.Y) + radius;
                g.FillEllipse(new SolidBrush(Color), centerX - radius, centerY - radius, diameter, diameter);
            }
        }

        class SolidSquare : Shape
        {
            public SolidSquare(Color color) : base(color) { }

            public override void Draw(Graphics g)
            {
                int width = Math.Abs(EndPoint.X - StartPoint.X);
                int height = Math.Abs(EndPoint.Y - StartPoint.Y);
                int size = Math.Min(width, height);
                int startX = Math.Min(StartPoint.X, EndPoint.X);
                int startY = Math.Min(StartPoint.Y, EndPoint.Y);
                g.FillRectangle(new SolidBrush(Color), startX, startY, size, size);
            }
        }

        class SolidParallelogram : Shape
        {
            public SolidParallelogram(Color color) : base(color) { }

            public override void Draw(Graphics g)
            {
                Point[] points = new Point[4];
                points[0] = StartPoint;
                points[1] = new Point(EndPoint.X, StartPoint.Y);
                points[2] = EndPoint;
                points[3] = new Point(StartPoint.X, EndPoint.Y);
                g.FillPolygon(new SolidBrush(Color), points);
            }
        }


        enum ShapeType
        {
            Line,
            Circle,
            Square,
            Parallelogram
        }

        enum BrushType
        {
            Solid,
            LinearGradient
            // Có thể mở rộng thêm loại brush khác nếu cần
        }

        // Abstract class cho một hình vẽ
        abstract class Shape
        {
            public Point StartPoint { get; set; }
            public Point EndPoint { get; set; }
            public Color Color { get; }

            protected Shape(Color color)
            {
                Color = color;
            }

            public abstract void Draw(Graphics g);
        }

        private void linearGradientBrushRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (linearGradientBrushRadioButton.Checked)
            {
                currentBrushType = BrushType.LinearGradient;
                paintCanvas.Invalidate();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
