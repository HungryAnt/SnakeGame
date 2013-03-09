using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace GodsSnakeGame.Game
{
    class SnakeGame
    {
        public SnakeGame()
        {

        }

        public Rectangle DisplayRectangle
        {
            get;
            set;
        }

        Snake _snake;
        Ground _ground;

        public void Start()
        {
            InitGame(50, 30);
        }

        void InitGame(int groundWidth, int groundHeight)
        {
            _ground = new Ground(groundWidth, groundHeight);

            Point[] snakeBodyNodes = new Point[]
            {
                new Point(groundWidth/2 - 1, groundHeight/2),
                new Point(groundWidth/2, groundHeight/2),
                new Point(groundWidth/2 + 1, groundHeight/2),
            };
            _snake = new Snake(snakeBodyNodes);
        }

        bool IsInitialized()
        {
            return _snake != null && _ground != null;
        }


        public void SnakeMove(SnakeMoveDirection direction)
        {
            _snake.Move(direction);
        }


        #region 绘图相关代码

        public void Draw(Graphics g)
        {
            if (!IsInitialized())
            {
                return;
            }

            int rowCount = _ground.Height;
            int colCount = _ground.Width;

            float perGridWidth = (float)DisplayRectangle.Width / colCount;
            float perGridHeight = (float)DisplayRectangle.Height / rowCount;

            FillGround(g, rowCount, colCount, perGridWidth, perGridHeight);

            FillSnake(g, _snake.BodyNodes, perGridWidth, perGridHeight);
        }

        void FillGround(Graphics g, int rowCount, int colCount, float perGridWidth, float perGridHeight)
        {
            for (int row = 0; row < rowCount; ++row)
            {
                for (int col = 0; col < colCount; ++col)
                {
                    Brush brush = ((col + row) % 2 == 0) ? Brushes.White : Brushes.LightGreen;

                    g.FillRectangle(brush,
                        new RectangleF(
                            DisplayRectangle.Left + col * perGridWidth,
                            DisplayRectangle.Top + row * perGridHeight,
                            perGridWidth,
                            perGridHeight
                            ));
                }
            }
        }

        void FillSnake(Graphics g, IEnumerable<Point> snakeBodyNodes, float perGridWidth, float perGridHeight)
        {
            bool first = true;
            foreach (Point pt in snakeBodyNodes)
            {
                Brush brush = first ? Brushes.Red : Brushes.DarkRed;

                g.FillRectangle(brush,
                    new RectangleF(
                        DisplayRectangle.Left + pt.X * perGridWidth,
                        DisplayRectangle.Top + pt.Y * perGridHeight,
                        perGridWidth,
                        perGridHeight
                        ));

                if (first)
                {
                    first = false;
                }
            }
        }

        #endregion
    }
}
