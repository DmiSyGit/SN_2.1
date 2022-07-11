using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SN_1._0
{
    class Coord
    {
        public int X;
        public int Y;

        public Coord(int x, int y)
        {
            X = x;
            Y = y;
        }
        public Coord()
        {
            X = -32;
            Y = 320;
        }
    }
    //class Objects
    //{
    //    public int X;
    //    public int Y;
    //    private int type;/* типа обьекта(0 - еда прибавляющая одно звено, 
    //                                  * 1 - барьер, 
    //                                  * 2 - сердце, 
    //                                  * 3 - ограждение границ колизия, 
    //                                  * 4 - ограждение левой границы(только изображение))
        
    //                      */
    //    //Random randomImgEat = new Random();
    //    private Image snakeEat = Properties.Resources.snakeEat2;
    //    private Image snakeBarrier = Properties.Resources.barrier;

    //    public int Type { get => type; set => type = value; }

    //    //public Image img;

    //    public Objects(int x, int y, int type)
    //    {
    //        X = x;
    //        Y = y;
    //        this.Type = type;
    //    }

    //    public Image GetImg()
    //    {
    //        switch (this.Type)
    //        {
    //            case 0:
    //                return snakeEat;
    //            case 1:
    //                return snakeBarrier;
    //            case 2:
    //                return Properties.Resources.snakeHealth;
    //            case 4:
    //                return Properties.Resources.snakeEat2;
    //        }
    //        return null;
    //    }
    //    public void ActionOnObjects(snake sn)
    //    {
    //        switch (this.Type)
    //        {
    //            case 0:
    //               // sn.AddTail();
    //                sn.score += 1;
    //                sn.CountEat -= 1;
    //                break;
    //            case 1:
    //                if (sn.HealthSnake > 1)
    //                {
    //                    sn.HealthSnake--;
    //                }
    //                else
    //                {
    //                    sn.gameOver = true;
    //                }
    //                break;
    //            case 2:
    //                sn.HealthSnake ++;
    //                break;
    //            case 3:
    //                sn.gameOver = true;
    //                break;
    //        }
    //    }
        
    //}
    class snake
    {
        public Image headImage = Properties.Resources.snakeMain;
        public Image tailImage = Properties.Resources.snake_tale2;
        public bool snakeImageChanged = false;
        public bool snakeImageOk = true;
        Random random = new Random();
        public Coord head = new Coord();// координаты головы змейки(в данный момент)
        public List<Coord> tailsColision = new List<Coord> { };// список координат элементов хвоста 
        List<Coord> headEarlier = new List<Coord> { };// координаты головы змейки(за все прошедшее время)
        List<Coord> headEarlierForCol = new List<Coord> { };// координаты головы змейки(за все прошедшее время)
        public int score = 0;// игровой счет
        public static int cellSize = Properties.Resources.snake_main.Width;// размер клетки поля в пикселях(установлен размер картинки) 
        public int orientation = 0;// направление змейки(0 - вправо, 1 - влево, 2 - вверх, 3 - вниз)
        private int countEat = 0;// количество созданной еды
        public int maxHeightCells, maxWidthCells;
        int healthSnake = 1;
        public bool gameOver = false;// Состояние игры
        private int Height = 640, Width = 800;// Размеры поля
        private int blockedEdges = 10000;// Какая грань заблокирована(10000 - никакая, 10001 - левая, 10010 - правая, 10100 - верхняя, 11000 - нижняя)
        private List<Coord> tailsGlad = new List<Coord> { };// список координат элементов хвоста 
        Form form;

        public snake(Form form)
        {
            this.form = form;
        }

        // Инкапсуляция
        public int HealthSnake { get => healthSnake; set => healthSnake = value; }
        public int CountEat { get => countEat; set => countEat = value; }
        internal List<Coord> TailsGlad { get => tailsGlad; set => tailsGlad = value; }

        public void SetSnakeImageOk()
        {
            if (!snakeImageOk)
            {
                this.headImage = Properties.Resources.snakeMain;
                this.snakeImageChanged = true;
                this.snakeImageOk = true;
            }
        }

        // двигает голову змейки взависимости от направления 
        public int MoveSnakeGlad(int offcet)
        {
            maxHeightCells = (Height / cellSize);
            maxWidthCells = (Width / cellSize);
            switch (orientation)
            {
                case 0:
                    head.X += offcet;
                    break;
                case 1:
                    head.X -= offcet;
                    break;
                case 2:
                    head.Y -= offcet;
                    break;
                case 3:
                    head.Y += offcet;
                    break;
            }
            if (head.X >= Width)
            {
                head.X = -32;
                return -3;
            }
            else if (head.Y >= Height)
            {
                head.Y = -32;
                return -3;
            }
            else if (head.X <= -32)
            {
                head.X = maxWidthCells * cellSize;
                return -3;
            }
            else if (head.Y <= -32)
            {
                head.Y = maxHeightCells * cellSize;
                return -3;
            }
            return 1;
        }
        // сохраняет последние позиций головы c запасом
        public void SavePosHead()
        {
            if (headEarlier.Count <= (score + 3)*4)
            {
                headEarlier.Insert(0, new Coord(head.X, head.Y));
            }
            else
            {
                headEarlier.Insert(0, new Coord(head.X, head.Y));
                headEarlier.RemoveAt(headEarlier.Count - 1);
            }
        }
   
        // добавляет в координаты 0:0 частичку хвоста(потом установит ей последнюю координату головы)
        public void AddTail()
        {
            TailsGlad.Insert(0, new Coord());
            tailsColision.Insert(0, new Coord());
        }

        // добавляет обьект карты в качестве PictureBox с указаным типом, в указанных координатах
        public void AddObject(string typeObject, int x, int y)
        {
            PictureBox objectMap = new PictureBox();
            objectMap.BackColor = Color.Transparent;
            objectMap.Tag = typeObject;
            switch (typeObject)
            {
                case "eat":
                    objectMap.Image = Properties.Resources.snakeEat5;
                    break;
                case "barrier":
                    objectMap.Image = Properties.Resources.barrier;
                    break;
                case "heart":
                    objectMap.Image = Properties.Resources.snakeHealth;
                    break;
            }
            objectMap.Size = new Size(32, 32);
            objectMap.Location = new Point(x, y);
            form.Controls.Add(objectMap);
            objectMap.BringToFront();
        }

        // совершает действие в зависимости от типа обьекта
        void ActionOnObject(PictureBox objectMap)
        {
                switch (objectMap.Tag.ToString())
                {
                    case "eat":
                        AddTail();
                        this.score += 1;
                        this.CountEat -= 1;
                        break;
                    case "barrier":
                        if (this.HealthSnake > 1)
                        {
                            this.headImage = Properties.Resources.snakeMainDamage;
                            this.HealthSnake--;
                            this.snakeImageOk = false;
                            this.snakeImageChanged = true;
                        }
                        else
                        {
                            this.gameOver = true;
                        }
                        break;
                    case "heart":
                        HealthSnake++;
                        break;
                    default:
                        return;
                }
                form.Controls.Remove(objectMap);
        }

        public void GladMoveTail()
        {
            for (int i = 0; i < TailsGlad.Count; i++)
            {
                TailsGlad[i].X = headEarlier[(i + 1) * 4].X;
                TailsGlad[i].Y = headEarlier[(i + 1) * 4].Y;
            }
        }



        // сохраняет последние позиции головы для колизии c запасом
        public void SavePosHeadForCol()
        {
            if (headEarlierForCol.Count <= score + 4)
            {
                headEarlierForCol.Insert(0, new Coord(head.X, head.Y));
            }
            else
            {
                headEarlierForCol.Insert(0, new Coord(head.X, head.Y));
                headEarlierForCol.RemoveAt(headEarlierForCol.Count - 1);
            }
        }
        // двигает хвост
        public void MoveTailColision()
        {
                for (int i = 0; i < tailsColision.Count; i++)
                {
                    tailsColision[i].X = headEarlierForCol[i+1].X;
                    tailsColision[i].Y = headEarlierForCol[i+1].Y;
                }
        }
        // проверка на столкновение с хвостом(возвращает индекс частички хвости или -1)
        int TryCollisionTail()
        {
            for (int i = 0; i < tailsColision.Count; i++)
            {
                if (tailsColision[i].X == head.X && tailsColision[i].Y == head.Y)
                {
                    return i;
                }
            }
            return -1;
        }


        // проверка на столкновение с обьектом(выполняет действие связанное с этим обьектом, удаляет из коллекции обьектов)
        public void TryCollisionObj()
        {
            foreach (Control control in form.Controls )
            {
                PictureBox objectMap = control as PictureBox;
                if(objectMap != null && objectMap.Tag != null)
                {
                    if (objectMap.Location.X == head.X && objectMap.Location.Y == head.Y)
                    {
                        ActionOnObject(objectMap);
                    }
                }
            }
        }
        // переобразует частички хвоста в барьеры
        void TailToBarrier(int index)
        {
            if (index != -1 && index != 0)
            {
                for (int i = index + 1; i < tailsColision.Count; i++)
                {
                    AddObject("barrier", tailsColision[i].X, tailsColision[i].Y);
                }

            }
        }
        // разделяет хвост в месте столкновения и вызывает Tail_to_Barrier
        public void SeparateTail()
        {
            int ind = TryCollisionTail();
            TailToBarrier(ind);
            if (ind != -1 && ind != 0)
            {
                while (ind != tailsColision.Count - 1)
                {
                    tailsColision.RemoveAt(ind);
                    TailsGlad.RemoveAt(ind);
                    score -= 1;
                }
            }
        }
        // создает обьект в противоположной 1/4 части поля (0 - еда, 1 - препятствие, 2 - сердечко)
        public void CreateObjects(string objType)
        {
            int x = -1, y = -1;
            while (!IsCellNull(new Coord(x, y)))
            {
                if (head.X / cellSize < maxWidthCells / 2)
                {
                    x = cellSize * random.Next(maxWidthCells / 2, maxWidthCells - 1);
                }
                else
                {
                    x = cellSize * random.Next(0, maxWidthCells / 2);
                }
                if (head.Y / cellSize < maxHeightCells / 2)
                {
                    y = cellSize * random.Next(maxHeightCells / 2, maxHeightCells - 2);
                }
                else
                {
                    y = cellSize * random.Next(0, maxHeightCells / 2);
                }
            }
            AddObject(objType, x, y);
        }
        // проверяет свободна ли ячейка
        public bool IsCellNull(Coord cell_coord)
        {
            if (cell_coord.X == -1) return false;
            // обьекты карты
            foreach (Control control in form.Controls)
            {
                PictureBox objectMap = control as PictureBox;
                if (objectMap != null && objectMap.Tag != null)
                {
                    if (objectMap.Location.X == cell_coord.X && objectMap.Location.Y == cell_coord.Y)
                    {
                        return false;
                    }
                }
            }
            // хвост змейки
            for (int i = 0; i < tailsColision.Count; i++)
            {
                if (tailsColision[i].X == cell_coord.X && tailsColision[i].Y == cell_coord.Y)
                {
                    return false;
                }
            }
            return true;

        }
        // блокирует преградами одну из сторон поля
        public void LockEdge()
        {
            switch (random.Next(0, 4))
            {
                case 0:
                    if (blockedEdges % 10 != 1)
                    {
                        for (int x = 0; x < Width; x += cellSize)
                        {
                                if (IsCellNull(new Coord(x, 0)))
                                {
                                    AddObject("barrier", x, 0);
                                }
                        }
                        blockedEdges += 1;
                    }
                        break;
                case 1:
                    if ((blockedEdges / 10) % 10 != 1)
                    {
                        for (int y = 0; y < Height; y += cellSize)
                        {
                            if (IsCellNull(new Coord(0, y)))
                            {
                                AddObject("barrier", 0, y);
                            }
                        }
                        blockedEdges += 10;
                    }
                    break;
                case 2:
                    if ((blockedEdges / 100) % 10 != 1)
                    {
                        for (int x = 0; x < Width; x += cellSize)
                        {
                            if (IsCellNull(new Coord(x, Height - cellSize)))
                            {
                                AddObject("barrier", x, Height - cellSize);
                            }
                        }
                        blockedEdges += 100;
                    }
                    break;
                case 3:
                    if ((blockedEdges / 1000) % 10 != 1)
                    {
                        for (int y = 0; y < Height; y += cellSize)
                        {
                            if (IsCellNull(new Coord(Width - cellSize, y)))
                            {
                                AddObject("barrier", Width - cellSize, y);
                            }
                        }
                        blockedEdges += 1000;
                    }
                    break;
            }
        }
        public void Next()
        {
        }
    }
}
