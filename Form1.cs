using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Graph
{
    public partial class Form1 : Form
    {
        int count = 1;
        
        Bitmap bit;
        Color _color = Color.Black;
       
        float x1 = 0, y1 = 0;
        int CheckClick = 1;
        int width_pen = 5;
        Pen pen = new Pen(Color.Black,5);
        public Form1()
        {
            bit = new Bitmap(1000,1000);
            x1 = y1 = 0;
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e){}  
        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            
            if (count == 1)
            {
                
                Graphics g;
                g = Graphics.FromImage(bit);
                if (e.Button == MouseButtons.Left)
                {
                    int weight_pen = width_pen / 3;
                    g.DrawLine(pen, x1+ weight_pen, y1+ weight_pen, e.X+ weight_pen, e.Y+ weight_pen);
                    g.DrawLine(pen, x1, y1+ weight_pen, e.X, e.Y+ weight_pen);
                    g.DrawLine(pen, x1+ weight_pen, y1, e.X+ weight_pen, e.Y);
                    g.DrawLine(pen, x1, y1, e.X, e.Y);
                    canvas.Image = bit;
                }
                x1 = e.X;
                y1 = e.Y;
            }
            
        }

     
        public void PenClick(object sender, EventArgs e)
        {
            count = 1;
            CheckClick = 1;
        }

        private void Canvas_MouseDown(object sender, MouseEventArgs e)
        {
            if (count == 2)
            {
                if(CheckClick == -1)
                {                 
                    Graphics g;
                    g = Graphics.FromImage(bit);
                    if (e.Button == MouseButtons.Left)
                    {
                        g.DrawLine(pen, x1, y1, e.X, e.Y);                       
                        canvas.Image = bit;
                        x1 = e.X;
                        y1 = e.Y;
                    }
                }
                else
                {
                    x1 = e.X;
                    y1 = e.Y;
                    CheckClick *= (-1);
                }
            }           
            if (count == 3)
            {
                if (CheckClick == -1)
                {                  
                    Graphics g;
                    g = Graphics.FromImage(bit);
                    if (e.Button == MouseButtons.Left)
                    {
                        g.DrawLine(pen, x1, y1, e.X, e.Y);
                        canvas.Image = bit;
                    }
                    CheckClick *= (-1);
                }
                else
                {
                    x1 = e.X;
                    y1 = e.Y;
                    CheckClick *= (-1);
                }
                
            }            
        }    
        public void BrokenClick(object sender, EventArgs e)
        {
            count = 2;
            CheckClick = 1;
        }

        private void ChangeColor_Click(object sender, EventArgs e)
        {
            
            if (colorDialog1.ShowDialog() == DialogResult.Cancel)
                 return;
            _color = colorDialog1.Color;
            pen = new Pen(_color, width_pen);

        }   
        private void Width_Bar_Click(object sender, EventArgs e)
        {

            width_pen = Width_Bar.Value; 
            
            Number.Text = Convert.ToString(Width_Bar.Value);
            pen = new Pen(_color, width_pen);
        }

        private void LineClick(object sender, EventArgs e)
        {
            count = 3;
            CheckClick = 1;
        }
    }
}
