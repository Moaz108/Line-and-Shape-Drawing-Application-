using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WindowsFormsApp1;
using System;

using System.Drawing;
using System.Windows.Forms;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Numerics;
//using Microsoft.Xna.Framework.Graphics;



namespace LineDrawing
{

    public partial class Program : Form
    {


        private String Width;
        private bool Height;
        private TextBox x1Entry, y1Entry, x2Entry, y2Entry;

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button ddaButton;
        private Button bresenhamButton;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private Label label5;
        private Label label6;
        private Label label7;
        private Button button1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private PictureBox pictureBox2;
        private Label label8;
        private Label label9;
        private Label label10;
        private Label label11;
        private TextBox textBox4;
        private TextBox textBox5;
        private TextBox textBox6;
        private TextBox textBox7;
        private Button button2;
        private TextBox tableLabel;
        private Button button3;
        private Button button4;
        private object pictureBox1;

        public Program()
        {
            InitializeComponent();
        }

        private void ddaButton_Click_1(object sender, EventArgs e)
        {
            if (x1Entry.Text.Length == 0 || y1Entry.Text.Length == 0 || x2Entry.Text.Length == 0 || y2Entry.Text.Length == 0)
            {
                MessageBox.Show("plz enter a number", "Warning!");
                return;
            }
            int x1 = int.Parse(x1Entry.Text);
            int x2 = int.Parse(y1Entry.Text);
            int y1 = int.Parse(x2Entry.Text);
            int y2 = int.Parse(y2Entry.Text);
            PointF[] pointss = new PointF[2];
            int x11 = Convert.ToInt32(x1Entry.Text);
            int y11 = Convert.ToInt32(x2Entry.Text);
            int x22 = Convert.ToInt32(y1Entry.Text);
            int y22 = Convert.ToInt32(y2Entry.Text);
            pointss[0] = new PointF(x11, y11);
            pointss[1] = new PointF(x22, y22);
            var points = DdaAlgorithm(x1, y1, x2, y2);
            tableLabel.Text = CreateTable(points);
            DrawLineDDA(pointss);
        }

        private int AbsDiff(int a, int b) => Math.Abs(a - b);


        private PointF[] DdaAlgorithm(int x1, int y1, int x2, int y2)
        {
            int dx = x2 - x1;
            int dy = y2 - y1;
            int steps = Math.Abs(dx) > Math.Abs(dy) ? Math.Abs(dx) : Math.Abs(dy);

            PointF[] points = new PointF[steps + 1];
            points[0] = new PointF(x1, y1);

            float xIncrement = (float)dx / (float)steps;
            float yIncrement = (float)dy / (float)steps;
            float x = x1;
            float y = y1;

            for (int i = 1; i <= steps; i++)
            {
                x += xIncrement;
                y += yIncrement;
                points[i] = new PointF((int)Math.Round(x), (int)Math.Round(y));
            }

            return points;
        }


        (PointF[] Points, float[] a) BresenhamAlgorithm(int x1, int y1, int x2, int y2)
        {
            int dx = (x2 - x1);
            int dy = (y2 - y1);
            int sx = x1 < x2 ? 1 : -1;
            int sy = y1 < y2 ? 1 : -1;
            int err = -dx + 2 * dy;
            int i = 0;
            PointF[] points = new PointF[Math.Max(dx, dy) + 1];
            float[] a = new float[Math.Max(dx, dy) + 1];
            float x = x1, y = y1;
            int u = 1;
            a[0] = err;
            // points[0] = new PointF(x, y);

            while (true)
            {
                x = x + sx;
                if (x == x2 && y == y2) break;

                //int e2 = 2 * err;
                if (err >= 0)
                {
                    err = err - 2 * dx;
                    y = y + sy;
                }
                if (err < 0)
                {
                    err = err + 2 * dy;
                    y = y;
                }

                if (i >= points.Length || u >= a.Length) break; // check array bounds

                points[i] = new PointF(x, y);
                a[u] = err;
                u++;
                i++;
            }
            return (points, a);
        }
        private string CreateTable(PointF[] points)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("K | (  X  ,  Y )");
            //sb.AppendLine("--|--|--");

            // int i = 0;
            sb.Append("\n");
            for (int i = 0; i < points.Length; i++)
            {

                sb.Append((i).ToString());
                sb.Append(" | ");

                sb.Append(" ( ");
                sb.Append(points[i].X.ToString().PadLeft(3));
                sb.Append(" , ");
                sb.Append(points[i].Y.ToString().PadLeft(3));
                sb.Append(" ) \n");
                sb.Append("\n");
                sb.AppendLine("");


            }
            return sb.ToString();
        }

        private void InitializeComponent()
        {
            this.x1Entry = new System.Windows.Forms.TextBox();
            this.y1Entry = new System.Windows.Forms.TextBox();
            this.x2Entry = new System.Windows.Forms.TextBox();
            this.y2Entry = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ddaButton = new System.Windows.Forms.Button();
            this.bresenhamButton = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.tableLabel = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // x1Entry
            // 
            this.x1Entry.Location = new System.Drawing.Point(43, 15);
            this.x1Entry.Name = "x1Entry";
            this.x1Entry.Size = new System.Drawing.Size(124, 22);
            this.x1Entry.TabIndex = 0;
            //this.x1Entry.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.x1Entry_KeyPress);
            // 
            // y1Entry
            // 
            this.y1Entry.Location = new System.Drawing.Point(43, 71);
            this.y1Entry.Name = "y1Entry";
            this.y1Entry.Size = new System.Drawing.Size(124, 22);
            this.y1Entry.TabIndex = 2;
            this.y1Entry.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.y1Entry_KeyPress);
            // 
            // x2Entry
            // 
            this.x2Entry.Location = new System.Drawing.Point(43, 43);
            this.x2Entry.Name = "x2Entry";
            this.x2Entry.Size = new System.Drawing.Size(124, 22);
            this.x2Entry.TabIndex = 1;
            this.x2Entry.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.x2Entry_KeyPress);
            // 
            // y2Entry
            // 
            this.y2Entry.Location = new System.Drawing.Point(43, 97);
            this.y2Entry.Name = "y2Entry";
            this.y2Entry.Size = new System.Drawing.Size(124, 22);
            this.y2Entry.TabIndex = 3;
            this.y2Entry.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.y2Entry_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "X1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Y1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(25, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "X2";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(25, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Y2";
            // 
            // ddaButton
            // 
            this.ddaButton.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ddaButton.Location = new System.Drawing.Point(15, 125);
            this.ddaButton.Name = "ddaButton";
            this.ddaButton.Size = new System.Drawing.Size(152, 23);
            this.ddaButton.TabIndex = 4;
            this.ddaButton.Text = "DDA";
            this.ddaButton.UseVisualStyleBackColor = false;
            this.ddaButton.Click += new System.EventHandler(this.ddaButton_Click_1);
            // 
            // bresenhamButton
            // 
            this.bresenhamButton.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.bresenhamButton.Location = new System.Drawing.Point(15, 154);
            this.bresenhamButton.Name = "bresenhamButton";
            this.bresenhamButton.Size = new System.Drawing.Size(152, 23);
            this.bresenhamButton.TabIndex = 5;
            this.bresenhamButton.Text = "Bresenham";
            this.bresenhamButton.UseVisualStyleBackColor = false;
            this.bresenhamButton.Click += new System.EventHandler(this.bresenhamButton_Click_1);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(43, 187);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(124, 22);
            this.textBox1.TabIndex = 10;
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(43, 215);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(124, 22);
            this.textBox2.TabIndex = 11;
            this.textBox2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox2_KeyPress);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(43, 243);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(124, 22);
            this.textBox3.TabIndex = 12;
            this.textBox3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox3_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 192);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 17);
            this.label5.TabIndex = 13;
            this.label5.Text = "X";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 248);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(18, 17);
            this.label6.TabIndex = 14;
            this.label6.Text = "R";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 220);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(17, 17);
            this.label7.TabIndex = 15;
            this.label7.Text = "Y";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.button1.Location = new System.Drawing.Point(15, 271);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(152, 36);
            this.button1.TabIndex = 16;
            this.button1.Text = "Circle";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.White;
            this.pictureBox2.Location = new System.Drawing.Point(446, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(652, 543);
            this.pictureBox2.TabIndex = 17;
            this.pictureBox2.TabStop = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 426);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 17);
            this.label8.TabIndex = 18;
            this.label8.Text = "Y Rad";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 394);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(47, 17);
            this.label9.TabIndex = 19;
            this.label9.Text = "X Rad";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 360);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(46, 17);
            this.label10.TabIndex = 20;
            this.label10.Text = "Y Cen";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(12, 331);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(46, 17);
            this.label11.TabIndex = 21;
            this.label11.Text = "X Cen";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(67, 326);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(100, 22);
            this.textBox4.TabIndex = 22;
            this.textBox4.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox4_KeyPress);
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(67, 361);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(100, 22);
            this.textBox5.TabIndex = 23;
            this.textBox5.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox5_KeyPress);
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(67, 389);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(100, 22);
            this.textBox6.TabIndex = 24;
            this.textBox6.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox6_KeyPress);
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(67, 421);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(100, 22);
            this.textBox7.TabIndex = 25;
            this.textBox7.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox7_KeyPress);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.button2.Location = new System.Drawing.Point(15, 449);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(152, 36);
            this.button2.TabIndex = 26;
            this.button2.Text = "Ellispe";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // tableLabel
            // 
            this.tableLabel.Location = new System.Drawing.Point(214, 15);
            this.tableLabel.Multiline = true;
            this.tableLabel.Name = "tableLabel";
            this.tableLabel.ReadOnly = true;
            this.tableLabel.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tableLabel.Size = new System.Drawing.Size(180, 377);
            this.tableLabel.TabIndex = 28;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.button3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button3.Location = new System.Drawing.Point(1267, 12);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(203, 64);
            this.button3.TabIndex = 29;
            this.button3.Text = "Transformation";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.AutoSize = true;
            this.button4.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.button4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button4.Location = new System.Drawing.Point(1267, 569);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(203, 64);
            this.button4.TabIndex = 30;
            this.button4.Text = "Close";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // Program
            // 
            this.AutoScroll = true;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.ClientSize = new System.Drawing.Size(1563, 628);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.tableLabel);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textBox7);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.bresenhamButton);
            this.Controls.Add(this.ddaButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.y2Entry);
            this.Controls.Add(this.x2Entry);
            this.Controls.Add(this.y1Entry);
            this.Controls.Add(this.x1Entry);
            this.Name = "Program";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Program_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void bresenhamButton_Click_1(object sender, EventArgs e)
        {
            if (x1Entry.Text.Length == 0 || y1Entry.Text.Length == 0 || x2Entry.Text.Length == 0 || y2Entry.Text.Length == 0)
            {
                MessageBox.Show("plz enter a number", "Warning!");
                return;
            }
            int x1 = int.Parse(x1Entry.Text);
            int x2 = int.Parse(y1Entry.Text);
            int y1 = int.Parse(x2Entry.Text);
            int y2 = int.Parse(y2Entry.Text);
            var result = BresenhamAlgorithm(x1, y1, x2, y2);
            PointF[] pointss2 = new PointF[2];
            int x11 = Convert.ToInt32(x1Entry.Text);
            int y11 = Convert.ToInt32(x2Entry.Text);
            int x22 = Convert.ToInt32(y1Entry.Text);
            int y22 = Convert.ToInt32(y2Entry.Text);
            pointss2[0] = new PointF(x11, y11);
            pointss2[1] = new PointF(x22, y22);
            tableLabel.Text = CreateTableB(result.Points, result.a);
            DrawLineBre(pointss2);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text.Length == 0 || textBox3.Text.Length == 0 || textBox1.Text.Length == 0 )
            {
                MessageBox.Show("plz enter a number", "Warning!");
                return;
            }
            int xcenter = int.Parse(textBox1.Text);
            int ycenter = int.Parse(textBox2.Text);
            int radius = int.Parse(textBox3.Text);
            var result = MidAlgorithm(xcenter, ycenter, radius);
            tableLabel.Text = CreateTableCircle(result.Points, result.p, result.r, result.ai);
            int r = Convert.ToInt32(textBox3.Text);
            int centerX = Convert.ToInt32(textBox1.Text);
            int centerY = Convert.ToInt32(textBox2.Text);
            PointF[] pointsss = new PointF[1];
            pointsss[0] = new PointF(centerX, centerY);

            DrawCircle(pointsss, r);

        }
        private (PointF[] Points, int[] p, int r, int ai) MidAlgorithm(int xCenter, int yCenter, int radius)
        {

            //int[,] points;
            int[] t;
            PointF[] points = new PointF[radius + 1];
            //points = new int[radius + 1, 2];
            t = new int[radius + 1];
            int i = 0;
            int j = 1;
            int x = 0;
            int y = radius;
            int d = 1 - radius;
            points[0] = new PointF(x, y);
            t[0] = d;
            while (true)
            {

                if (x >= y)
                    break;


                if (d < 0)
                {
                    d += 2 * x + 3;
                    y = y;
                }
                else
                {
                    y--;
                    d += 2 * (x - y) + 3;

                }

                x++;
                points[i] = new PointF(x, y);
                if (j >= points.Length) break; // check array bounds
                t[j] = d;

                j++;
                i++;

            }










            return (points, t, radius, i);
        }

        private string CreateTableCircle(PointF[] Points, int[] p, int r, int ai)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("K | P | (  X ,  Y)");
            //sb.AppendLine("--|--|--");

            // int i = 0;
            sb.Append("\n");
            for (int i = 0; i <= ai - 1; i++)
            {
                //sb.Append((i).ToString());
                //sb.Append(" | ");
                //sb.Append(p[i].ToString().PadLeft(3));
                //sb.Append(" | ");
                //sb.Append((points[i, 0], points[i, 1]).ToString().PadLeft(3));
                //sb.Append("\n");

                sb.Append((i).ToString());
                sb.Append(" | ");
                sb.Append(p[i].ToString().PadLeft(3));
                sb.Append(" | ");
                sb.Append(" ( ");
                sb.Append(Points[i].X.ToString().PadLeft(3));
                sb.Append(" , ");
                sb.Append(Points[i].Y.ToString().PadLeft(3));
                sb.Append(" ) \n");
                sb.AppendLine("");


            }
            return sb.ToString();
        }
        private string CreateTableB(PointF[] points, float[] a)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("K | P | (  X ,  Y)");
            //sb.AppendLine("--|--|--");

            // int i = 0;
            sb.Append("\n");
            for (int i = 0; i < points.Length - 1; i++)
            {

                sb.Append((i).ToString());
                sb.Append(" | ");
                sb.Append(a[i].ToString().PadLeft(3));
                sb.Append(" | ");
                sb.Append(" ( ");
                sb.Append(points[i].X.ToString().PadLeft(3));
                sb.Append(" , ");
                sb.Append(points[i].Y.ToString().PadLeft(3));
                sb.Append(" ) \n");
                sb.AppendLine("");


            }
            return sb.ToString();
        }

      

       

      

        private void DrawLineDDA(PointF[] points)
        {
            var p = new Bitmap(pictureBox2.Width, pictureBox2.Height);
            var g = Graphics.FromImage(p);
            g.Clear(Color.White);

            // Calculate center of picture box
            int centerX = pictureBox2.Width / 2;
            int centerY = pictureBox2.Height / 2;

            // Draw x-axis
            g.DrawLine(Pens.Black, 0, centerY, pictureBox2.Width, centerY);

            // Draw y-axis
            g.DrawLine(Pens.Black, centerX, 0, centerX, pictureBox2.Height);

            double deltax = points[1].X - points[0].X;
            double deltay = points[1].Y - points[0].Y;
            double steps = Math.Max(Math.Abs(deltax), Math.Abs(deltay));
            double xinc = deltax / steps;
            double yinc = deltay / steps;
            double x = points[0].X;
            double y = points[0].Y;

            // Calculate the starting point for the line
            int startX = (int)Math.Round(centerX + x);
            int startY = (int)Math.Round(centerY - y);

            // Draw the line
            for (int i = 0; i <= steps; i++)
            {
                int endX = (int)Math.Round(centerX + x);
                int endY = (int)Math.Round(centerY - y);
                g.DrawLine(Pens.Red, startX, startY, endX, endY);
                startX = endX;
                startY = endY;
                x += xinc;
                y += yinc;
            }

            pictureBox2.Image = p;
        }

        private void DrawLineBre(PointF[] points)
        {

            int x1 = (int)points[0].X + pictureBox2.Width / 2;
            int y1 = pictureBox2.Height / 2 - (int)points[0].Y;
            int x2 = (int)points[1].X + pictureBox2.Width / 2;
            int y2 = pictureBox2.Height / 2 - (int)points[1].Y;

            Bitmap bmp = new Bitmap(pictureBox2.Width, pictureBox2.Height);

            int dx = Math.Abs(x2 - x1);
            int dy = Math.Abs(y2 - y1);

            int sx = x1 < x2 ? 1 : -1;
            int sy = y1 < y2 ? 1 : -1;

            int err = dx - dy;

            bmp.SetPixel(x1, y1, Color.Red);

            while (x1 != x2 || y1 != y2)
            {
                int e2 = err * 2;

                if (e2 > -dy)
                {
                    err -= dy;
                    x1 += sx;
                }

                if (e2 < dx)
                {
                    err += dx;
                    y1 += sy;
                }

                bmp.SetPixel(x1, y1, Color.Red);
            }
            var p = new Bitmap(pictureBox2.Width, pictureBox2.Height);
            var gg = Graphics.FromImage(p);
            gg.Clear(Color.White);
            // Draw x-axis and y-axis
            using (Graphics g = Graphics.FromImage(bmp))
            {
                Pen pen = new Pen(Color.Black);

                // Draw x-axis
                g.DrawLine(pen, new Point(0, pictureBox2.Height / 2), new Point(pictureBox2.Width, pictureBox2.Height / 2));

                // Draw y-axis
                g.DrawLine(pen, new Point(pictureBox2.Width / 2, 0), new Point(pictureBox2.Width / 2, pictureBox2.Height));
            }

            pictureBox2.Image = bmp;
        }

        private void DrawCircle(PointF[] center, int radius)
        {


            int centerX = pictureBox2.Width / 2 + (int)center[0].X;
            int centerY = pictureBox2.Height / 2 - (int)center[0].Y;

            Bitmap bmp = new Bitmap(pictureBox2.Width, pictureBox2.Height);

            int x = 0;
            int y = radius;
            int d = 1 - radius;
            int deltaE = 3;
            int deltaSE = -2 * radius + 5;
            var p = new Bitmap(pictureBox2.Width, pictureBox2.Height);
            var gg = Graphics.FromImage(p);
            gg.Clear(Color.White);
            // Draw x-axis and y-axis
            using (Graphics g = Graphics.FromImage(bmp))
            {
                Pen pen = new Pen(Color.Black);

                // Draw x-axis
                g.DrawLine(pen, new Point(0, pictureBox2.Height / 2), new Point(pictureBox2.Width, pictureBox2.Height / 2));

                // Draw y-axis
                g.DrawLine(pen, new Point(pictureBox2.Width / 2, 0), new Point(pictureBox2.Width / 2, pictureBox2.Height));
            }

            DrawCirclePoints(bmp, centerX, centerY, x, y, Color.Red);

            while (y > x)
            {
                if (d < 0)
                {
                    d += deltaE;
                    deltaE += 2;
                    deltaSE += 2;
                }
                else
                {
                    d += deltaSE;
                    deltaE += 2;
                    deltaSE += 4;
                    y--;
                }
                x++;

                DrawCirclePoints(bmp, centerX, centerY, x, y, Color.Red);
            }

            pictureBox2.Image = bmp;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox4.Text.Length == 0 || textBox5.Text.Length == 0 || textBox6.Text.Length == 0 || textBox7.Text.Length == 0)
            {
                MessageBox.Show("plz enter a number", "Warning!");
                return;
            }
            int xc = int.Parse(textBox4.Text);
            int yc = int.Parse(textBox5.Text);
            int rx = int.Parse(textBox6.Text);
            int ry = int.Parse(textBox7.Text);

            var result = midptellipse(rx, ry, xc, yc);
            tableLabel.Text = CreateTableEllipse(result);
            DrawEllipse(result, xc, yc);



        }
        List<Tuple<float, PointF>> midptellipse(float rx, float ry,
                        float xc, float yc)
        {


            List<Tuple<float, PointF>> list1 = new List<Tuple<float, PointF>>();


            float dx, dy, d1, d2, x, y;
            d2 = 0;
            x = 0;
            y = ry;

            // Initial decision parameter of region 1
            d1 = (ry * ry) - (rx * rx * ry) +
                            (0.25f * rx * rx);
            dx = 2 * ry * ry * x;
            dy = 2 * rx * rx * y;

            // For region 1
            while (dx < dy)
            {

                x++;

                if (d1 < 0)
                {
                    list1.Add(new Tuple<float, PointF>(d1, new PointF(x, y)));
                    dx = dx + (2 * ry * ry);
                    d1 = d1 + dx + (ry * ry);

                }
                else
                {

                    y--;
                    list1.Add(new Tuple<float, PointF>(d1, new PointF(x, y)));
                    dx = dx + (2 * ry * ry);
                    dy = dy - (2 * rx * rx);
                    d1 = d1 + dx - dy + (ry * ry);
                }


            }
            //  list1.Add(new Tuple<float, PointF>(d1, new PointF(x, y)));
            // Decision parameter of region 2
            d2 = ((ry * ry) * ((x + 0.5f) * (x + 0.5f)))
                + ((rx * rx) * ((y - 1) * (y - 1)))
                - (rx * rx * ry * ry);
            x++;
            // Plotting points of region 2
            while (y > 0)
            {

                y--;

                // value based on algorithm
                if (d2 < 0)
                {   
                    list1.Add(new Tuple<float, PointF>(d2, new PointF(x, y)));
                    dy = dy - (2 * rx * rx);
                    d2 = d2 + (rx * rx) - dy;
                    
                }
                else
                {

                    x++;
                    list1.Add(new Tuple<float, PointF>(d2, new PointF(x, y)));
                    dx = dx + (2 * ry * ry);
                    dy = dy - (2 * rx * rx);
                    d2 = d2 + dx - dy + (rx * rx);
                }

            }
            return list1;
        }

        private string CreateTableEllipse(List<Tuple<float, PointF>> d)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("K | P | (  X ,  Y)");
            //sb.AppendLine("--|--|--");

            int i = 0;
            sb.Append("\n");
            foreach (Tuple<float, PointF> p in d)
            {


                sb.Append((i).ToString());
                sb.Append(" | ");
                sb.Append(p.Item1.ToString().PadLeft(3));
                sb.Append(" | ");
                sb.Append(" ( ");
                sb.Append(p.Item2.X.ToString().PadLeft(3));
                sb.Append(" , ");
                sb.Append(p.Item2.Y.ToString().PadLeft(3));
                sb.Append(" ) \n");
                sb.AppendLine("");
                i++;

            }
            return sb.ToString();
        }





        private void DrawCirclePoints(Bitmap bmp, int centerX, int centerY, int x, int y, Color color)
        {
            if (centerX + x >= 0 && centerX + x < bmp.Width && centerY + y >= 0 && centerY + y < bmp.Height)
                bmp.SetPixel(centerX + x, centerY + y, color);
            if (centerX + y >= 0 && centerX + y < bmp.Width && centerY + x >= 0 && centerY + x < bmp.Height)
                bmp.SetPixel(centerX + y, centerY + x, color);
            if (centerX - y >= 0 && centerX - y < bmp.Width && centerY + x >= 0 && centerY + x < bmp.Height)
                bmp.SetPixel(centerX - y, centerY + x, color);
            if (centerX - x >= 0 && centerX - x < bmp.Width && centerY + y >= 0 && centerY + y < bmp.Height)
                bmp.SetPixel(centerX - x, centerY + y, color);
            if (centerX - x >= 0 && centerX - x < bmp.Width && centerY - y >= 0 && centerY - y < bmp.Height)
                bmp.SetPixel(centerX - x, centerY - y, color);
            if (centerX - y >= 0 && centerX - y < bmp.Width && centerY - x >= 0 && centerY - x < bmp.Height)
                bmp.SetPixel(centerX - y, centerY - x, color);
            if (centerX + y >= 0 && centerX + y < bmp.Width && centerY - x >= 0 && centerY - x < bmp.Height)
                bmp.SetPixel(centerX + y, centerY - x, color);
            if (centerX + x >= 0 && centerX + x < bmp.Width && centerY - y >= 0 && centerY - y < bmp.Height)
                bmp.SetPixel(centerX + x, centerY - y, color);
        }

        private void Program_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //private void x1Entry_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //      if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '-')
        //    {
        //        e.Handled = true;
        //    }
        //}

        private void x2Entry_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '-')
            {
                e.Handled = true;
            }
        }


        private void y1Entry_KeyPress(object sender, KeyPressEventArgs e)
        {
              if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '-')
            {
                e.Handled = true;
            }
        }

        private void y2Entry_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
              if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '-')
            {
                e.Handled = true;
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
              if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) )
            {
                e.Handled = true;
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
              if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '-')
            {
                e.Handled = true;
            }
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
              if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '-')
            {
                e.Handled = true;
            }
        }

        private void DrawEllipse(List<Tuple<float, PointF>> d, int x0, int y0)
        {


            Bitmap bmp = new Bitmap(pictureBox2.Width, pictureBox2.Height);

            int centerX = pictureBox2.Width / 2 + x0;
            int centerY = pictureBox2.Height / 2 - y0;
            var p = new Bitmap(pictureBox2.Width, pictureBox2.Height);
            var gg = Graphics.FromImage(p);
            gg.Clear(Color.White);
            // Draw x-axis and y-axis
            using (Graphics g = Graphics.FromImage(bmp))
            {
                Pen pen = new Pen(Color.Black);

                // Draw x-axis
                g.DrawLine(pen, new Point(0, pictureBox2.Height / 2), new Point(pictureBox2.Width, pictureBox2.Height / 2));

                // Draw y-axis
                g.DrawLine(pen, new Point(pictureBox2.Width / 2, 0), new Point(pictureBox2.Width / 2, pictureBox2.Height));
                //}

                //using (var g = CreateGraphics())
                //{
                for (int i = 0; i < d.Count; i++)
                {
                    var point = d[i].Item2;

                    DrawEllipsePoints(bmp, centerX, centerY, (int)point.X, (int)point.Y, Color.Red);
                }
            }
            pictureBox2.Image = bmp;
        }
        private void DrawEllipsePoints(Bitmap bmp, int centerX, int centerY, int x, int y, Color color)
        {
            if (centerX + x >= 0 && centerX + x < bmp.Width && centerY + y >= 0 && centerY + y < bmp.Height)
                bmp.SetPixel(centerX + x, centerY + y, color);
            if (centerX - x >= 0 && centerX - x < bmp.Width && centerY + y >= 0 && centerY + y < bmp.Height)
                bmp.SetPixel(centerX - x, centerY + y, color);
            if (centerX - x >= 0 && centerX - x < bmp.Width && centerY - y >= 0 && centerY - y < bmp.Height)
                bmp.SetPixel(centerX - x, centerY - y, color);
            if (centerX + x >= 0 && centerX + x < bmp.Width && centerY - y >= 0 && centerY - y < bmp.Height)
                bmp.SetPixel(centerX + x, centerY - y, color);
            //
        }


        private void button3_Click(object sender, EventArgs e)
        {
            // Create a new instance of the form
            Form3 form3 = new Form3();
            form3.TopMost = true;

            // Show the new form
            this.Hide();
            form3.ShowDialog(this);
            this.Show();

        }















       

    } 

}