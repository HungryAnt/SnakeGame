using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GodsSnakeGame.Game
{
    enum GridType
    {
        grass,
        earth,
        sand,
    }

    class Ground
    {
        const int LIMIT_MIN_WIDTH = 6;
        const int LIMIT_MIN_HEIGHT = 4;

        public Ground(int width, int height)
        {
            if (width < LIMIT_MIN_WIDTH
                || height < LIMIT_MIN_HEIGHT)
            {
                throw new ArgumentException("Ground Init Error : grid count less than low limit.");
            }

            Width = width;
            Height = height;
            //_grids = new GridType[Height, Width];
        }

        public int Width
        {
            get;
            private set;
        }

        public int Height
        {
            get;
            private set;
        }

        //GridType[,] _grids;
    }
}
