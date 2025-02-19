using System;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;
using System.Text;
using System.Windows.Forms;
using LineDrawing;

namespace WindowsFormsApp1
{
    public partial class Form3 : Form
    {
        public int Flag;
        public int fla = 0;
        public Point[] pointss1 = new Point[3];
        public Point[] pointss3 = new Point[3];
        public Point[] pointss2 = new Point[3];
         public Point[] pointss4 = new Point[3];
        public Point[] pointss5= new Point[3]; 
        public List<String> myArray = new List<String>();
        public int ii = 0;

        public Form3()
        {
           
            InitializeComponent();
            Bitmap bmp = new Bitmap(pictureBox2.Width, pictureBox2.Height);
            Graphics g = Graphics.FromImage(bmp);
            // Draw the x-axis and y-axis using Pen objects
            Pen axisPen = new Pen(Color.Gray, 1);
            g.DrawLine(axisPen, 0, pictureBox2.Height / 2, pictureBox2.Width, pictureBox2.Height / 2); // x-axis
            g.DrawLine(axisPen, pictureBox2.Width / 2, 0, pictureBox2.Width / 2, pictureBox2.Height); // y-axis
            Pen originPen = new Pen(Color.Red, 4);
            g.DrawEllipse(originPen, pictureBox2.Width / 2 - 2, pictureBox2.Height / 2 - 2, 4, 4);
            pictureBox2.Image = bmp;
            
          Point[] vertices = new Point[]
            {
                new Point(-50, 0),
                new Point(0, 100),
                new Point(50, 0)
            };
            DrawShape2(vertices);


        }
        

        public void button1_Click(object sender, EventArgs e)
        {
            // Set the transformation values for translation
            if (x1Entry.Text.Length == 0 || textBox1.Text.Length == 0)
            { MessageBox.Show("plz enter a number","Warning!");
                return;
            }
            float x1 = float.Parse(x1Entry.Text);
            float y2 = float.Parse(textBox1.Text);
            Flag = 0;
            Point[] vertices = new Point[]
            {
                new Point(-50, 0),
                new Point(0, 100),
                new Point(50, 0)
            };
            
            





            if (fla == 0)
            {

                pointss1 = ApplyTransformations(Flag, x1, y2, vertices);

                DrawShape(pointss1, vertices);
            }
            else if (fla == 1)
            {
                pointss1 = ApplyTransformations(Flag, x1, y2, pointss1);

                DrawShape(pointss1, vertices);
            }
            else if (fla == 2)
            {
                pointss1 = ApplyTransformations(Flag, x1, y2, pointss2);

                DrawShape(pointss1, vertices);
            }
            else if (fla == 3)
            {

                pointss1 = ApplyTransformations(Flag, x1, y2, pointss3);

                DrawShape(pointss1, vertices);
            }
            else if (fla == 4)
            {

                pointss1 = ApplyTransformations(Flag, x1, y2, pointss4);
                DrawShape(pointss1, vertices);
            }
            else if (fla == 5)
            {

                pointss1 = ApplyTransformations(Flag, x1, y2, pointss5);
                DrawShape(pointss1, vertices);
            }
            fla = 1;
            myArray.Add("Translation");
            ii++;
            

        }

        public void button3_Click(object sender, EventArgs e)
        {
            if (textBox6.Text.Length == 0 || textBox7.Text.Length == 0)
            {
                MessageBox.Show("plz enter a number", "Warning!");
                return;
            }
            // Set the transformation values for scaling
            float xx1 = float.Parse(textBox6.Text);
            float yy2 = float.Parse(textBox7.Text);
            Flag = 1;
            
            Point[] vertices = new Point[]
            {
                new Point(-50, 0),
                new Point(0, 100),
                new Point(50, 0)
            };
            
            if (fla == 0)
            {
                
                pointss3 = ApplyTransformations(Flag, xx1, yy2, vertices);
                DrawShape(pointss3, vertices);
            }
            else if (fla==1)
            {
                pointss3 = ApplyTransformations(Flag, xx1, yy2, pointss1);
                DrawShape(pointss3, vertices);
            }
            else if (fla == 2)
            {
                pointss3 = ApplyTransformations(Flag, xx1, yy2, pointss2);
                DrawShape(pointss3, vertices);
            }
            else if (fla == 3)
            {
                pointss3 = ApplyTransformations(Flag, xx1, yy2, pointss3);
                DrawShape(pointss3, vertices);
            }
            else if (fla == 4)
            {

                pointss3 = ApplyTransformations(Flag, xx1, yy2, pointss4);
                DrawShape(pointss3, vertices);
            }
            else if (fla == 5)
            {

                pointss3 = ApplyTransformations(Flag, xx1, yy2, pointss5);
                DrawShape(pointss3, vertices);
            }

            fla = 3;
            myArray.Add("Scaling");
            ii++;
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox5.Text.Length == 0 )
            {
                MessageBox.Show("plz enter a number", "Warning!");
                return;
            }
            float angle = float.Parse(textBox5.Text);
            Flag = 2;
            Point[] vertices = new Point[]
            {
                new Point(-50, 0),
                new Point(0, 100),
                new Point(50, 0)
            };
            
            
            

            if (fla == 0)
            {

                pointss2 = ApplyTransformations(Flag, angle, 1, vertices);
                DrawShape(pointss2, vertices);
            }
            else if (fla == 1)
            {
                pointss2 = ApplyTransformations(Flag,angle,1, pointss1);
                DrawShape(pointss2, vertices);
            }
            else if (fla == 2)
            {
                pointss2 = ApplyTransformations(Flag, angle, 1, pointss2);
                DrawShape(pointss2, vertices);
            }
            else if (fla == 3)
            {
                pointss2 = ApplyTransformations(Flag, angle, 1, pointss3);
                DrawShape(pointss2, vertices);
            }
            else if (fla == 4)
            {

                pointss2 = ApplyTransformations(Flag, angle, 1, pointss4);
                DrawShape(pointss2, vertices);
            }
            else if (fla == 5)
            {

                pointss2 = ApplyTransformations(Flag, angle, 1, pointss5);
                DrawShape(pointss2, vertices);
            }

            fla = 2;
            myArray.Add("Rotation");
            ii++;
            
        }

        public Point[] ApplyTransformations(int flag, float x, float y, Point[] vertices)
        {
            float translateX = 0;
            float translateY = 0;
            float angle = 0;
            float scaleX = 1;
            float scaleY = 1;
            int gg = 0;
            float shearingY = 1;
            float shearingX = 1;
            // Define the transformation matrices
            if (flag == 0)
            {
                translateX = x;
                translateY = y;
            }
            else if (flag == 1)
            {
                scaleX = x;
                scaleY = y;
            }
            else if (flag == 2)
            {
                angle = x;
            }
            else if (flag == 3)
            {
                gg = 1;
            }
            else if (flag == 4)
            {
                gg = 2;
                shearingY = y;
                shearingX = x;
            }

            // Convert the angle to radians
            float radians = angle * (float)Math.PI / 180.0f;

            // Apply the transformations to each vertex
            Point[] transformedVertices = new Point[vertices.Length];
            for (int i = 0; i < vertices.Length; i++)
            {
                float x1 = vertices[i].X;
                float y1 = vertices[i].Y;

                // Apply the translation transformation
                x1 += translateX;
                y1 += translateY;

                // Apply the scaling transformation
                x1 *= scaleX;
                y1 *= scaleY;

                // Apply the rotation transformation
                float x2 = x1 * (float)Math.Cos(radians) - y1 * (float)Math.Sin(radians);
                float y2 = x1 * (float)Math.Sin(radians) + y1 * (float)Math.Cos(radians);
                if(gg==1)
                {
                    x2 = -x2;
                    y2 = -y2;
                }
                if(gg==2)
                {
                    x2 += shearingY * y2;
                    y2 += shearingX * x2;
                }
                transformedVertices[i] = new Point((int)x2, (int)y2);
            }

            return transformedVertices;
        }








        public void DrawShape(Point[] vertices1, Point[] vertices2)
        {
            // Create a Bitmap object to draw on
            Bitmap bmp = new Bitmap(pictureBox2.Width, pictureBox2.Height);
            Graphics g = Graphics.FromImage(bmp);

            
            // Draw the x-axis and y-axis using Pen objects
            Pen axisPen = new Pen(Color.Gray, 1);
            g.DrawLine(axisPen, 0, pictureBox2.Height / 2, pictureBox2.Width, pictureBox2.Height / 2); // x-axis
            g.DrawLine(axisPen, pictureBox2.Width / 2, 0, pictureBox2.Width / 2, pictureBox2.Height); // y-axis
            Pen originPen = new Pen(Color.Red, 4);
            g.DrawEllipse(originPen, pictureBox2.Width / 2 - 2, pictureBox2.Height / 2 - 2, 4, 4);
            pictureBox2.Image = bmp;
            // Draw the transformed shape using a Pen object
            Pen shapePen = new Pen(Color.Black, 2);
            Point[] shiftedVertices = new Point[vertices1.Length];
            for (int i = 0; i < vertices1.Length; i++)
            {
                shiftedVertices[i] = new Point(vertices1[i].X + pictureBox2.Width / 2, pictureBox2.Height / 2 - vertices1[i].Y);
            }
            g.DrawPolygon(shapePen, shiftedVertices);

            //Draw the origin point





            // Draw the transformed shape using a Pen object
            Pen shapePen1 = new Pen(Color.Blue, 2);
            Point[] shiftedVertices1 = new Point[vertices2.Length];
            for (int i = 0; i < vertices2.Length; i++)
            {
                shiftedVertices1[i] = new Point(vertices2[i].X + pictureBox2.Width / 2, pictureBox2.Height / 2 - vertices2[i].Y);
            }
            g.DrawPolygon(shapePen1, shiftedVertices1);



            // Display the image in the PictureBox control
            pictureBox2.Image = bmp;
        }










        public void DrawShape2(Point[] vertices)
        {
            // Create a Bitmap object to draw on
            Bitmap bmp = new Bitmap(pictureBox2.Width, pictureBox2.Height);
            Graphics g = Graphics.FromImage(bmp);


            // Draw the x-axis and y-axis using Pen objects
            Pen axisPen = new Pen(Color.Gray, 1);
            g.DrawLine(axisPen, 0, pictureBox2.Height / 2, pictureBox2.Width, pictureBox2.Height / 2); // x-axis
            g.DrawLine(axisPen, pictureBox2.Width / 2, 0, pictureBox2.Width / 2, pictureBox2.Height); // y-axis
            Pen originPen = new Pen(Color.Red, 4);
            g.DrawEllipse(originPen, pictureBox2.Width / 2 - 2, pictureBox2.Height / 2 - 2, 4, 4);
            pictureBox2.Image = bmp;
            // Draw the transformed shape using a Pen object
            Pen shapePen = new Pen(Color.Blue, 2);
            Point[] shiftedVertices = new Point[vertices.Length];
            for (int i = 0; i < vertices.Length; i++)
            {
                shiftedVertices[i] = new Point(vertices[i].X + pictureBox2.Width / 2, pictureBox2.Height / 2 - vertices[i].Y);
            }
            g.DrawPolygon(shapePen, shiftedVertices);

            // Draw the origin point


            // Display the image in the PictureBox control
            pictureBox2.Image = bmp;
        }






        private string ShowSeq(List<String> a)
        {
            StringBuilder sb = new StringBuilder();

            //sb.AppendLine("--|--|--");
          
            
            sb.Append("\n");
            for(int i=0;i<a.Count;i++)
            {


                sb.AppendLine(a[i]);
                
               

            }
            return sb.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (myArray.Count == 0 )
            {
                MessageBox.Show("No actions done", "Warning!");
                return;
            }
            tableLabel.Text = ShowSeq(myArray);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            float xr =1;
                float yr = 1;
            Flag = 3;
            Point[] vertices = new Point[]
   {
                new Point(-50, 0),
                new Point(0, 100),
                new Point(50, 0)
   };
            if (fla == 0)
            {

                pointss4 = ApplyTransformations(Flag, xr, yr, vertices);
                DrawShape(pointss4, vertices);
            }
           else if (fla == 1)
            {

                pointss4 = ApplyTransformations(Flag, xr, yr, pointss1);
                DrawShape(pointss4, vertices);
            }
            else if (fla == 2)
            {

                pointss4 = ApplyTransformations(Flag, xr, yr, pointss2);
                DrawShape(pointss4, vertices);
            }

            else if (fla == 3)
            {

                pointss4 = ApplyTransformations(Flag, xr, yr, pointss3);
                DrawShape(pointss4, vertices);
            }
            else if (fla == 4)
            {

                pointss4 = ApplyTransformations(Flag, xr, yr, pointss4);
                DrawShape(pointss4, vertices);
            }

            else if (fla == 5)
            {

                pointss4 = ApplyTransformations(Flag, xr, yr, pointss5);
                DrawShape(pointss4, vertices);
            }

          


            fla = 4;
            myArray.Add("Reflection");
            ii++;

        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (textBox4.Text.Length == 0 || textBox8.Text.Length == 0)
            {
                MessageBox.Show("plz enter a number", "Warning!");
                return;
            }
            float xs = float.Parse(textBox4.Text);
            float ys = float.Parse(textBox8.Text);
            Flag = 4;
            Point[] vertices = new Point[]
   {
                new Point(-50, 0),
                new Point(0, 100),
                new Point(50, 0)
   };
            if (fla == 0)
            {

                pointss5 = ApplyTransformations(Flag, xs, ys, vertices);
                DrawShape(pointss5, vertices);
            }
            else if (fla == 1)
            {

                pointss5 = ApplyTransformations(Flag, xs, ys, pointss1);
                DrawShape(pointss5, vertices);
            }
            else if (fla == 2)
            {

                pointss5 = ApplyTransformations(Flag, xs, ys, pointss2);
                DrawShape(pointss5, vertices);
            }

            else if (fla == 3)
            {

                pointss5 = ApplyTransformations(Flag, xs, ys, pointss3);
                DrawShape(pointss5, vertices);
            }

            else if (fla == 4)
            {

                pointss5 = ApplyTransformations(Flag, xs, ys, pointss4);
                DrawShape(pointss5, vertices);
            }
            else if (fla == 5)
            {

                pointss5 = ApplyTransformations(Flag, xs, ys, pointss5);
                DrawShape(pointss5, vertices);
            }
            fla = 5;
            myArray.Add("Shearing");
            ii++;
        }

    
        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void x1Entry_KeyPress(object sender, KeyPressEventArgs e)
        {
              if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '-')
            {
                e.Handled = true;
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
              if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '-')
            {
                e.Handled = true;
            }
        }

       

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
              if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '-')
            {
                e.Handled = true;
            }
        }

        //private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //      if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '-')
        //    {
        //        e.Handled = true;
        //    }
        //}

        //private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //      if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '-')
        //    {
        //        e.Handled = true;
        //    }
        //}

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
              if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '-')
            {
                e.Handled = true;
            }
        }

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
              if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '-')
            {
                e.Handled = true;
            }
        }
    }
}
