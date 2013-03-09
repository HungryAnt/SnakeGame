using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace GodsSnakeGame.Game
{
    class Snake
    {
        public Snake(IEnumerable<Point> bodyNods)
        {
            BodyNodes = new LinkedList<Point>(bodyNods);
            CheckBodyNodesCount();
        }

        void CheckBodyNodesCount()
        {
            if (BodyNodes == null)
            {
                throw new ArgumentException("Snake Error: Null nodes.");
            }

            if (BodyNodes.Count < 3)
            {
                throw new ArgumentException("Snake Error: Too few nodes.");
            }
        }

        public LinkedList<Point> BodyNodes
        {
            get;
            private set;
        }

        /// <summary>
        /// 通过前两个身体节点，获取当前蛇的移动方向
        /// </summary>
        /// <returns></returns>
        SnakeMoveDirection GetCurrentDirection()
        {
            CheckBodyNodesCount();

            SnakeMoveDirection currentDirection = SnakeMoveDirection.None;

            Point firstNode = BodyNodes.ElementAt(0);
            Point secondNode = BodyNodes.ElementAt(1);

            switch (firstNode.X - secondNode.X)
            {
                case 1:
                    currentDirection = SnakeMoveDirection.Right;
                    break;
                case 0:
                    break;
                case -1:
                    currentDirection = SnakeMoveDirection.Left;
                    break;
            }

            if (currentDirection == SnakeMoveDirection.None)
            {
                switch (firstNode.Y - secondNode.Y)
                {
                    case 1:
                        currentDirection = SnakeMoveDirection.Down;
                        break;
                    case 0:
                        break;
                    case -1:
                        currentDirection = SnakeMoveDirection.Up;
                        break;
                }
            }

            if (currentDirection == SnakeMoveDirection.None)
            {
                throw new Exception("Snake Error: cannot get available direction by first 2 body nodes.");
            }

            return currentDirection;
        }

        /// <summary>
        /// 获取有效的移动方向
        /// </summary>
        /// <returns></returns>
        SnakeMoveDirection GetAvailableNewDirection(SnakeMoveDirection newDirection)
        {
            SnakeMoveDirection currentDirection = GetCurrentDirection();

            if (newDirection == SnakeMoveDirection.None
                || (currentDirection == SnakeMoveDirection.Left && newDirection == SnakeMoveDirection.Right)
                || (currentDirection == SnakeMoveDirection.Right && newDirection == SnakeMoveDirection.Left)
                || (currentDirection == SnakeMoveDirection.Up && newDirection == SnakeMoveDirection.Down)
                || (currentDirection == SnakeMoveDirection.Down && newDirection == SnakeMoveDirection.Up)
                )
            {
                return currentDirection;
            }
            else
            {
                return newDirection;
            }
        }

        /// <summary>
        /// 依据移动方向，获取新的头部节点
        /// </summary>
        /// <param name="direction"></param>
        /// <returns></returns>
        Point GetNewHeadNode(SnakeMoveDirection direction)
        {
            Point firstNode = BodyNodes.First();
            int x = firstNode.X;
            int y = firstNode.Y;

            switch (direction)
            {
                case SnakeMoveDirection.Left:
                    --x;
                    break;
                case SnakeMoveDirection.Right:
                    ++x;
                    break;
                case SnakeMoveDirection.Up:
                    --y;
                    break;
                case SnakeMoveDirection.Down:
                    ++y;
                    break;
            }

            return new Point(x, y);
        }

        void AddNewHeadNode(Point newHeadNode)
        {
            BodyNodes.AddFirst(newHeadNode);
        }

        public void Move(SnakeMoveDirection newDirection)
        {
//             if (newDirection == SnakeMoveDirection.None)
//             {
//                 throw new ArgumentException("Snake Move Error: directon cannot be none");
//             }

            SnakeMoveDirection availableDirection = GetAvailableNewDirection(newDirection);

            Point newHeadNode = GetNewHeadNode(availableDirection);

            AddNewHeadNode(newHeadNode);
        }
    }
}
