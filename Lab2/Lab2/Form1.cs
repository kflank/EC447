using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace Lab2
{
    public partial class Form1 : Form
    {
        public ArrayList coordinates = new ArrayList();
        public int clicked = 0;

        public Form1()
        {
            InitializeComponent();
        }
        

        
        


        






        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            const int WIDTH = 15;
            const int HEIGHT = 15;

            Graphics g = e.Graphics;
            foreach (Point p in this.coordinates)
            {
                g.FillEllipse(Brushes.Red,
                    p.X - WIDTH/2, p.Y - HEIGHT/2, WIDTH, HEIGHT);
            }
        }

        private void Form1_MouseClick_1(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point p = new Point(e.X, e.Y);
                coordinates.Add(p);
                Invalidate();
            }
            if (e.Button == MouseButtons.Right)
            {
                coordinates.Clear();
                Invalidate();
            }
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            clicked = clicked + 1;
             //true means button has been clicked should be set to Hide Lines 
            Graphics MyInstacne = this.CreateGraphics();
            Pen pen = new Pen(Color.Black,2);
            //Graphics g = e.Graphics;
            if (clicked % 2 == 1)
            {
                for (int i = 0; i < this.coordinates.Count - 1; i++)
                {
                    MyInstacne.DrawLine(pen, (Point)coordinates[i], (Point)coordinates[i + 1]);
                    button1.Text = "Hide Lines";
                }
            }
            else if (clicked % 2 == 0)
            {
                
                Invalidate();
                button1.Text = "Show Lines";

            }

        }
    }
    
        
}
