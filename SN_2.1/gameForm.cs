using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SN_1._0
{
    public partial class gameForm : Form
    {
        snake firsty;
        bool isFrameChanged = false;
        int preOrientation;
        int countBeforeFullOffset = 0;
        int countTickHealth = 0;
        int scoreDifference = 0;
        private menuForm formMainMenu;
        bool gamePause = false;


        PictureBox snakeMain = new PictureBox();
        //objectMap.BackColor = Color.Transparent;
        
        public gameForm()
        {
            InitializeComponent();
        }
        public gameForm(menuForm formMain, Font pixelFont)
        {
            InitializeComponent();
            firsty = new snake(this);
            formMainMenu = formMain;
            labelScoreSnake.Font = new Font(pixelFont.FontFamily, 25, FontStyle.Regular);
            labelHealthSnake.Font = new Font(pixelFont.FontFamily, 25, FontStyle.Regular);
            labelGameOver.Font = pixelFont;

            snakeMain.Tag = "snake";
            snakeMain.Image = firsty.headImage;
            snakeMain.Size = new Size(32, 32);
            snakeMain.Location = new Point(-100, -100);
            this.Controls.Add(snakeMain);
            snakeMain.BringToFront();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            
            timerEat.Interval = 5000;
            timerEat.Tick += new EventHandler(UpdateEat);
            timerEat.Start();

            timerGameOver.Interval = 5000;
            timerGameOver.Tick += new EventHandler(GameOverClose);


            timerGameTick.Interval = 400;
            timerGameTick.Tick += new EventHandler(UpdatePosition);
            timerGameTick.Start();
            this.DoubleBuffered = true;
        }
        private void GameOverClose(object sender, EventArgs e)
        {
            timerGameOver.Stop();
            this.Close();
        }
        private void UpdateEat(object sender, EventArgs e)
        {
            countTickHealth++;
            if (firsty.CountEat < 1)
            {
                firsty.CreateObjects("eat");
                firsty.CountEat++;
            }
            else
            {
                firsty.CreateObjects("barrier");
            }
            if (countTickHealth > 10)
            {
                firsty.CreateObjects("heart");
                countTickHealth = 0;
            }
            if((firsty.score - scoreDifference) == 15)
            {
                scoreDifference = firsty.score;
                firsty.LockEdge();
            }
        }
        private void UpdatePosition(object sender, EventArgs e)
        {
            if (gamePause != true)
            {
                if (firsty.gameOver != true)
                {
                    if (timerGameTick.Interval > 10 && timerGameTick.Interval != 1000)
                    {
                        timerGameTick.Interval = (400 - (firsty.score * 10)) / 5;
                    }
                    pictureBox2.Invalidate();
                    Redrawing();
                    if (countBeforeFullOffset == 4)
                    {
                        //firsty.Next(this);
                        countBeforeFullOffset = 0;
                        firsty.SetSnakeImageOk();
                        firsty.orientation = preOrientation;
                        firsty.SeparateTail();
                        firsty.SavePosHeadForCol();
                        firsty.MoveTailColision();
                        firsty.TryCollisionObj();
                        isFrameChanged = true;
                    }
                    countBeforeFullOffset += firsty.MoveSnakeGlad(snake.cellSize / 4);
                    
                    firsty.GladMoveTail();
                    firsty.SavePosHead();
                   // label2.Text = "X:" + firsty.head.X.ToString() + " Y:" + firsty.head.Y.ToString() + " " + ((10011/10)%10).ToString();
                    labelHealthSnake.Text = "x " + firsty.HealthSnake.ToString();
                    labelScoreSnake.Text = "score: " + firsty.score.ToString();
                    
                }
                else
                {
                    timerEat.Stop();
                    timerGameTick.Stop();
                    labelGameOver.Visible = true;
                    pictureBox1.Visible = true;
                    pictureBox1.BringToFront();
                    labelGameOver.BringToFront();
                    labelGameOver.Text = "GAME OVER";
                    timerGameOver.Start();
                }
            }
        }
        //private void Redrawing(object sender, PaintEventArgs e)// Вызывается для перерисовки изображения(this.Invalidate())
        //{

        //    //foreach (Objects obj in firsty.objectsMap)
        //    //{
        //    //    if (obj.GetImg() != null)
        //    //    {
        //    //        e.Graphics.DrawImage(obj.GetImg(), new Point(obj.X, obj.Y));
        //    //    }
        //    //}

        //    //foreach (Coord tails in firsty.TailsGlad)
        //    //{
        //    //    e.Graphics.DrawImage(firsty.tailImage, new Point(tails.X, tails.Y));
        //    //}
        //    //e.Graphics.DrawImage(firsty.headImage, new Point(firsty.head.X, firsty.head.Y));
        //    ////e.Graphics.DrawImage(Properties.Resources.snake_dirt_footor, new Point(0, 640));
        //}

        private void Redrawing()
        {
            if (firsty.snakeImageChanged)
            {
                snakeMain.Image = firsty.headImage;
                firsty.snakeImageChanged = false;
            }
            snakeMain.Location = new Point(firsty.head.X, firsty.head.Y);
            snakeMain.BringToFront();
            pictureBoxFooter.BringToFront();
            labelHealthSnake.BringToFront();
            labelScoreSnake.BringToFront();
        }
        private void Key_DownF1(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode.ToString())
            {
                case ("Left"):
                    if (firsty.orientation != 0 && isFrameChanged)
                    {
                        preOrientation = 1;
                        isFrameChanged = false;
                    }
                    break;
                case ("Right"):
                    if (firsty.orientation != 1 && isFrameChanged)
                    {
                        preOrientation = 0;
                        isFrameChanged = false;
                    }
                    break;
                case("Down"):
                    if (firsty.orientation != 2 && isFrameChanged)
                    {
                        preOrientation = 3;
                        isFrameChanged = false;
                    }
                    break;
                case ("Up"):
                    if (firsty.orientation != 3 && isFrameChanged)
                    {
                        preOrientation = 2;
                        isFrameChanged = false;
                    }
                    break;
                case ("P"):
                    gamePause = !gamePause;
                    if(gamePause)
                    {
                        pictureBox1.Visible = true;
                        labelGameOver.Visible = true;
                        pictureBox1.BringToFront();
                        labelGameOver.BringToFront();
                        labelGameOver.Text = "PAUSE";
                    }
                    else
                    {
                        pictureBox1.Visible = false;
                        labelGameOver.Visible = false;
                    }
                    timerEat.Enabled = !timerEat.Enabled;
                    break;
                case ("Escape"):
                    this.Close();
                    break;
                //case ("E"):
                //    firsty.AddTail();
                //    firsty.score += 1;
                //    firsty.HealthSnake += 1;
                //    break;
                //case ("I"):
                //    timerGameTick.Interval = 4;
                //    break;
                //case ("O"):
                //    timerGameTick.Interval = 1000;
                //    break;
                    //case ("B"):
                    //    firsty.LockEdge();
                    //    break;
            }
        }

        private void FormGame_Closing(object sender, FormClosingEventArgs e)
        {
            
        }

        //private void pictureBox2_Paint(object sender, PaintEventArgs e)
        //{
        //    //foreach (Objects obj in firsty.objectsMap)
        //    //{
        //    //    if (obj.GetImg() != null)
        //    //    {
        //    //        e.Graphics.DrawImage(obj.GetImg(), new Point(obj.X, obj.Y));
        //    //    }
        //    //}
        //}

        private void field_Paint(object sender, PaintEventArgs e)
        {
            foreach (Coord tails in firsty.TailsGlad)
            {
                e.Graphics.DrawImage(firsty.tailImage, new Point(tails.X, tails.Y));
            }
        }

        private void FormGame_Closed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            formMainMenu.UpdateRecordsPlayer(firsty.score);
            formMainMenu.Show();
        }
    }
}
