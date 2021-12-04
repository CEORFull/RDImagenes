using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication21
{
    public partial class Form1 : Form
    {
        int cR, cG, cB;

        List<int[]> list = new List<int[]>();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();  
            Bitmap bmp = new Bitmap(openFileDialog1.FileName);
            pictureBox1.Image = bmp;
            pictureBox2.Image = bmp;
        }
       

        /*private void button2_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(pictureBox1.Image);
            Color c = new Color();
            c = bmp.GetPixel(10,10);
            textBox1.Text = c.R.ToString();
            //textBox2.Text = c.G.ToString();
            textBox3.Text = c.B.ToString();
        }*/

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            /*Bitmap bmp = new Bitmap(pictureBox1.Image);
            Color c = new Color();
            c = bmp.GetPixel(e.X, e.Y);
            textBox1.Text = c.R.ToString();
            textBox2.Text = c.G.ToString();
            textBox3.Text = c.B.ToString();
            cR = c.R;
            cG = c.G;
            cB = c.B;*/
            Bitmap bmp = new Bitmap(pictureBox1.Image);
            Color c = new Color();
            int x, y, mR=0, mG=0, mB=0;
            x = e.X; y = e.Y;
            for (int i = x; i < x + 10;i++)
                for (int j = y; j < y + 10; j++)
                {
                    c = bmp.GetPixel(i, j);
                    mR = mR + c.R;
                    mG = mG + c.G;
                    mB = mB + c.B;
                }
            mR = mR / 100;
            mG = mG / 100;
            mB = mB / 100;
            cR = mR;
            cG = mG;
            cB = mB;
            textBox1.Text = cR.ToString();
            textBox2.Text = cG.ToString();
            textBox3.Text = cB.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            list.Clear();
            Bitmap bmp = new Bitmap(pictureBox1.Image);
            pictureBox2.Image = bmp;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            int[] rgb = new int[3];
            rgb[0] = cR;
            rgb[1] = cG;
            rgb[2] = cB;

            list.Add(rgb);
            pictureBox2.Image = pictureBox1.Image;

        }


        private void button6_Click(object sender, EventArgs e)
        {
            Color[] paleta = new Color[10];

            paleta[0]= Color.FromArgb(0, 255, 255);
            paleta[1]= Color.FromArgb(56, 78, 21);
            paleta[2]= Color.FromArgb(255, 0, 0);
            paleta[3]= Color.FromArgb(0, 255, 0);
            paleta[4]= Color.FromArgb(0, 0, 255);
            paleta[5]= Color.FromArgb(255, 0, 255);
            paleta[6]= Color.FromArgb(0, 0, 0);
            paleta[7] = Color.FromArgb(46, 89, 120);
            paleta[8] = Color.FromArgb(25, 30, 50);
            paleta[9] = Color.FromArgb(100, 85, 0);

            
            List<int> control = new List<int>();
            control.Add(1000);

            int meR, meG, meB;
            Bitmap bmp = new Bitmap(pictureBox1.Image);
            Bitmap cpoa = new Bitmap(bmp.Width, bmp.Height);
            Color c = new Color();

            foreach(var col in list)
            {
                Random rnd = new Random();
                int ran = rnd.Next(0, 9);
                foreach(int cn in control)
                {
                    if(cn == ran)
                    {
                        ran = rnd.Next(0, 9);
                    }
                    else 
                    {
                        control.Add(ran);
                        break;
                    }
                }
                Color pincel = paleta[ran];
                for (int i = 0; i < bmp.Width - 10; i += 10)
                {
                    for (int j = 0; j < bmp.Height - 10; j += 10)
                    {
                        meR = 0;
                        meG = 0;
                        meB = 0;

                        for (int k = i; k < i + 10; k++)
                            for (int l = j; l < j + 10; l++)
                            {
                                c = bmp.GetPixel(k, l);
                                meR = meR + c.R;
                                meG = meG + c.G;
                                meB = meB + c.B;
                            }
                        meR = meR / 100;
                        meG = meG / 100;
                        meB = meB / 100;

                        if (((col[0] - 10) < meR) && (meR < (col[0] + 10)) && ((col[1] - 10) < meG) && (meG < (col[1] + 10)) && ((col[2] - 10) < meB) && (meB < (col[2] + 10)))
                            for (int k = i; k < i + 10; k++)
                                for (int l = j; l < j + 10; l++)
                                {
                                    cpoa.SetPixel(k, l, pincel);
                                }

                        else
                            for (int k = i; k < i + 10; k++)
                                for (int l = j; l < j + 10; l++)
                                {
                                    c = bmp.GetPixel(k, l);
                                    cpoa.SetPixel(k, l, c);
                                }
                    }
                    
                }
                pictureBox2.Image = cpoa;

                bmp = new Bitmap(pictureBox2.Image);
                cpoa = new Bitmap(bmp.Width, bmp.Height);
                control.Clear();
            }


        }

       
    }
}
