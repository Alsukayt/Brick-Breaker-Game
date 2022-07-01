using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace Brick_Breaker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            sound2.PlayLooping();
        }

        SoundPlayer sound1 = new SoundPlayer(@"C:\Users\Moham\OneDrive\Desktop\snowball.wav");
        SoundPlayer sound2 = new SoundPlayer(@"C:\Users\Moham\OneDrive\Desktop\Alarm01.wav");



            int ballx = 4;
            int bally = 4;
            int score = 0;



        private void Game_Over()
        {
            if(score > 39)
            {
                timer1.Stop();
                sound2.Stop();
                MessageBox.Show("You WoN ;)");

               
            }
            if (Ball.Top + Ball.Height > ClientSize.Height)
            {
                timer1.Stop();
                sound2.Stop();
                MessageBox.Show("Game Over");
            }
        }


        private void Get_Score()
        {
            foreach(Control x in this.Controls)
            {
                if(x is PictureBox && x.Tag == "Block"){

                    if (Ball.Bounds.IntersectsWith(x.Bounds))
                    {
                        Controls.Remove(x);
                        bally = - bally;
                        score++;
                        label1.Text = score + "score"  ;
                        sound1.Play();
                        sound2.PlayLooping();
                    }
                }
            }
        }

        private void Ball_Movement()
        {
            Ball.Left += ballx;
            Ball.Top += bally;

            if (Ball.Left + Ball.Width > ClientSize.Width || Ball.Left < 0)
            {
                ballx = -ballx;
            }
            if (Ball.Top < 0 || Ball.Bounds.IntersectsWith(Player.Bounds))
            {
                bally = -bally;
            }

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Left && Player.Left > 0)
            {
                Player.Left -= 5;
            }
            if (e.KeyCode == Keys.Right && Player.Right < 370)
            {
                Player.Left += 5;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Ball_Movement();
            Get_Score();
            Game_Over();
        }
    }
}
