using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawingApp
{
    public partial class Form1 : Form
    {
        private bool isDrawing;
        private Point lastPoint;
        private Bitmap drawingBitmap;
        private Graphics drawingGraphics;

        public Form1()
        {
            InitializeComponent();

            // Initialize the drawing bitmap and graphics
            drawingBitmap = new Bitmap(panel1.Width, panel1.Height);
            drawingGraphics = Graphics.FromImage(drawingBitmap);
            drawingGraphics.Clear(Color.White);

            // Set the initial drawing state
            isDrawing = false;
            lastPoint = Point.Empty;

            // Assign mouse event handlers
            panel1.MouseDown += panel1_MouseDown;
            panel1.MouseMove += panel1_MouseMove;
            panel1.MouseUp += panel1_MouseUp;

            // Assign the Paint event to draw the bitmap on the panel
            panel1.Paint += panel1_Paint;

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            // Draw the bitmap on the panel
            e.Graphics.DrawImageUnscaled(drawingBitmap, Point.Empty);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDrawing = true;
                lastPoint = e.Location;
            }
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDrawing)
            {
                if (lastPoint != Point.Empty)
                {
                    // Draw line on the bitmap
                    drawingGraphics.DrawLine(Pens.Black, lastPoint, e.Location);
                    lastPoint = e.Location;

                    // Invalidate the panel to trigger a repaint
                    panel1.Invalidate();
                }
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDrawing = false;
                lastPoint = Point.Empty;
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            // Clean up resources
            drawingGraphics.Dispose();
            drawingBitmap.Dispose();
            base.OnFormClosing(e);
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            drawingGraphics.Clear(Color.White);
            panel1.Invalidate();
        }
    }
}
