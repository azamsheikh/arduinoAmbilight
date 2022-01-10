using System;
using System.Windows;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO.Ports;

namespace colorsandPixels
{

    public partial class Form1 : Form
    {
        public Form1()
        {
           
            InitializeComponent();
           

        }



        



        private void button1_Click(object sender, EventArgs e)
        {

           

        }

        int screenWidth = Screen.PrimaryScreen.Bounds.Width;
        int screenHeight = Screen.PrimaryScreen.Bounds.Height;
       // private object textbox1;

        private void timer1_Tick(object sender, EventArgs e)
        {
            

            if (!myport.IsOpen)
            {
                myport.Open();
            }

            textBox1.Text = myport.ReadExisting();
          



           
            
            try
            {
               

                int aa = 1;
                int bb = 2;
                for (int x = 11; x < 29; x++)
                {

                    giveAveragecolor(x, (screenWidth / 18) * aa, 0, (screenWidth / 18) * bb, screenHeight / 11);



                    aa += 1;
                    bb += 1;
                }




                ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////



                int hh = 1;
                int jj = 2;
                for (int x = 29; x < 39; x++)
                {

                    giveAveragecolor(x, (screenWidth / 18) * 17, (screenHeight / 11) * hh, screenWidth, (screenHeight / 11) * jj);



                    hh += 1;
                    jj += 1;
                }



                //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////





                int ll = 19;
                int oo = 20;
                for(int x = 39; x < 60; x++){
                    
                    giveAveragecolor(x, (screenWidth / 20) * ll, (screenHeight / 11), (screenWidth / 20) * oo, screenHeight);



                    ll -= 1;
                    oo -= 1;
                }
                ////////////////////////////////////////////////////////////////////////////////////////////
                ///


                int kk = 9;
                int ee = 10;
                for (int x = 0; x < 11; x++)
                {

                    giveAveragecolor(x, 0, (screenHeight / 11) * kk, screenWidth/20, (screenHeight / 11) * ee);



                    kk -= 1;
                    ee -= 1;
                }










                /////////////////////////////////////////////////////////////////////////////////////////////


            }

            catch (Exception ex)
            {
               
               
            }

          
        }

        public Color giveAveragecolor(int boxNumber, int x1,int y1, int x2, int y2)
        {
            if (!myport.IsOpen)
            {
                myport.Open();
            }

            int red = 0;
            int green = 0;
            int blue = 0;
            int total = 0;
            try
            {
                Rectangle bounds = Screen.GetBounds(Point.Empty);
                using (Bitmap bitmap = new Bitmap(bounds.Width, bounds.Height))
                {
                    using (Graphics g = Graphics.FromImage(bitmap))
                    {
                        g.CopyFromScreen(Point.Empty, Point.Empty, bounds.Size);
                        for (int x = x1; x < x2; x += 100)
                        {
                            for (int y = y1; y < y2; y += 100)
                            {
                                Color clr = bitmap.GetPixel(x, y);

                                red += clr.R;
                                green += clr.G;
                                blue += clr.B;

                                total++;
                            }
                        }

                        //Calculate average
                        red /= total;
                        green /= total;
                        blue /= total;


                        
                        

                    }
                }
            }

            catch
            {

            }
            myport.Write(boxNumber.ToString() + "#" + red.ToString("D3") + "," + green.ToString("D3") + "@" + blue.ToString("D3"));
            return Color.FromArgb(red, green, blue);
            

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            myport.PortName = textBox1.Text;
            myport.Open();
            timer1.Enabled = true;
        }
    }


}
