using GeometricShapes.Core;
using GeometricShapes.DataAccess;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CoreRectangle = GeometricShapes.Core.Rectangle;


namespace GeometricShapes.UI
{
    public partial class Form1 : Form
    {
        private GraphicTool _graphicTool;
        private Shape _selectedShape;
        private Point _lastMousePos;
        private bool _isMoving = false;
        private bool _isResizing = false;
        private Color _currentColor = Color.Blue;
        public Form1()
        {
            InitializeComponent();
            InitializeComponents();
            InitializeGraphicTool();
        }
        private void InitializeComponents()
        {
           
            drawingPanel.BackColor = Color.White;
            drawingPanel.Paint += DrawingPanel_Paint;
            drawingPanel.MouseDown += DrawingPanel_MouseDown;
            drawingPanel.MouseMove += DrawingPanel_MouseMove;
            drawingPanel.MouseUp += DrawingPanel_MouseUp;
            drawingPanel.AllowDrop = true;

           
            shapeTypeComboBox.Items.AddRange(new object[] { "Circle", "Rectangle", "Triangle" });
            shapeTypeComboBox.SelectedIndex = 0;

           
            btnColor.Click += BtnColor_Click;
            btnSave.Click += BtnSave_Click;
            btnLoad.Click += BtnLoad_Click;
            btnClear.Click += BtnClear_Click;
        }
        private void InitializeGraphicTool()
        {
            var repository = new ShapeRepository();
            _graphicTool = new GraphicTool(repository);
        }
        private void DrawingPanel_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            _graphicTool.DrawAllShapes(e.Graphics);

           
            if (_selectedShape != null)
            {
                var pen = new Pen(Color.Red, 2) { DashStyle = System.Drawing.Drawing2D.DashStyle.Dash };

                if (_selectedShape is Circle circle)
                {
                    e.Graphics.DrawEllipse(pen, circle.X - circle.Radius, circle.Y - circle.Radius,
                                         circle.Radius * 2, circle.Radius * 2);
                }
                else if (_selectedShape is Core.Rectangle rect)
                {
                    e.Graphics.DrawRectangle(pen, rect.X, rect.Y, rect.Width, rect.Height);
                }
                else if (_selectedShape is Triangle triangle)
                {
                    e.Graphics.DrawPolygon(pen, triangle.Points);
                }
            }
        }
        private void DrawingPanel_MouseDown(object sender, MouseEventArgs e)
        {
            _lastMousePos = e.Location;
            _selectedShape = _graphicTool.Shapes.LastOrDefault(shape => IsPointInShape(e.Location, shape));

            if (_selectedShape != null)
            {
                if (e.Button == MouseButtons.Right)
                {
                    _isResizing = true;
                }
                else
                {
                    _isMoving = true;
                }
            }
            else if (e.Button == MouseButtons.Left)
            {
                CreateNewShape(e.Location);
            }
        }
        private void DrawingPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (_selectedShape == null) return;

            var deltaX = e.X - _lastMousePos.X;
            var deltaY = e.Y - _lastMousePos.Y;

            if (_isMoving)
            {
                _selectedShape.Move(deltaX, deltaY);
            }
            else if (_isResizing)
            {
                float factor = 1 + (deltaX + deltaY) / 100f;
                _selectedShape.Resize(factor);
            }

            _lastMousePos = e.Location;
            drawingPanel.Invalidate();
        }
        private void DrawingPanel_MouseUp(object sender, MouseEventArgs e)
        {
            _isMoving = false;
            _isResizing = false;
        }
        private bool PointInTriangle(Point pt, Point v1, Point v2, Point v3)
        {
            float d1 = (pt.X - v3.X) * (v2.Y - v3.Y) - (v2.X - v3.X) * (pt.Y - v3.Y);
            float d2 = (pt.X - v1.X) * (v3.Y - v1.Y) - (v3.X - v1.X) * (pt.Y - v1.Y);
            float d3 = (pt.X - v2.X) * (v1.Y - v2.Y) - (v1.X - v2.X) * (pt.Y - v2.Y);

            bool hasNeg = (d1 < 0) || (d2 < 0) || (d3 < 0);
            bool hasPos = (d1 > 0) || (d2 > 0) || (d3 > 0);

            return !(hasNeg && hasPos);
        }
        private bool IsPointInShape(Point point, Shape shape)
        {
            if (shape is Circle circle)
            {
                return Math.Pow(point.X - circle.X, 2) + Math.Pow(point.Y - circle.Y, 2) <= Math.Pow(circle.Radius, 2);
            }
            else if (shape is Core.Rectangle rect)
            {
                return point.X >= rect.X && point.X <= rect.X + rect.Width &&
                       point.Y >= rect.Y && point.Y <= rect.Y + rect.Height;
            }
            else if (shape is Triangle triangle)
            {
                return PointInTriangle(point, triangle.Points[0], triangle.Points[1], triangle.Points[2]);
            }
            return false;
        }
        private void CreateNewShape(Point location)
        {
            Shape newShape = null;
            int size = 40; 

            switch (shapeTypeComboBox.SelectedItem.ToString())
            {
                case "Circle":
                    newShape = new Circle(location.X, location.Y, size) { FillColor = _currentColor };
                    break;
                case "Rectangle":
                    newShape = new Core.Rectangle(location.X, location.Y, size * 2, size) { FillColor = _currentColor };
                    break;
                case "Triangle":
                    newShape = new Triangle(location.X, location.Y, size * 2, size * 2) { FillColor = _currentColor };
                    break;
            }

            if (newShape != null)
            {
                _graphicTool.AddShape(newShape);
                drawingPanel.Invalidate();
            }
        }
        private void BtnColor_Click(object sender, EventArgs e)
        {
            var colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                _currentColor = colorDialog.Color;
                colorPanel.BackColor = _currentColor;
            }
        }
        private void BtnSave_Click(object sender, EventArgs e)
        {
            _graphicTool.SaveShapes();
            MessageBox.Show("Formele au fost salvate cu succes!");
        }
        private void BtnLoad_Click(object sender, EventArgs e)
        {
            _graphicTool.LoadShapes();
            drawingPanel.Invalidate();
            MessageBox.Show("Formele au fost încărcate cu succes!");
        }
        private void BtnClear_Click(object sender, EventArgs e)
        {
            _graphicTool.Shapes.Clear();
            drawingPanel.Invalidate();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            colorPanel.BackColor = _currentColor;
        }
    }
}
