using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleSnake.GameObjects
{
    public class Snake : Point
    {
        private const char SnakeSymbol = '\u25CF';

        private readonly Food[] food;
        private readonly Queue<Point> snakeElements;
        private readonly Wall wall;

        private int foodIndex = new Random().Next(0, 3);


        public Snake(Wall wall, int leftX, int topY)
            : base(leftX, topY)
        {
            this.wall = wall;

            this.snakeElements = new Queue<Point>();

            this.food = new Food[]
            {
                new FoodAsterisk(this.wall),
                new FoodDollar(this.wall),
                new FoodHash(this.wall),
            };
            this.CreatSnake();

            this.food[this.foodIndex].SetRandomPosition(this.snakeElements);

        }

        public int Length
            => this.snakeElements.Count;

        public bool IsMoving(Point direction)
        {
            var currentSnakeHead = this.snakeElements.Last();

            GetNextPoint(currentSnakeHead, direction);

            if (IsWallPoint())
            {
                return false;
            }

            if (IsPointOfSnake())
            {
                return false;
            }

            Point newHead = CreateNewHead();

            if (this.food[foodIndex].IsFoodPoint(newHead))
            {
                this.Eat(direction, newHead);
            }

            RemoveTail();

            return true;
        }

        private void RemoveTail()
        {
            var tail = this.snakeElements.Dequeue();
            tail.Draw(' ');
        }

        private Point CreateNewHead()
        {
            var newHead = new Point(this.LeftX, this.TopY);
            newHead.Draw(SnakeSymbol);
            this.snakeElements.Enqueue(newHead);
            return newHead;
        }

        private void Eat(Point direction, Point newHead)
        {
            for (int i = 0; i < this.food[foodIndex].FoodPoints; i++)
            {
                this.GetNextPoint(newHead, direction);

                newHead = new Point(this.LeftX, this.TopY);
                newHead.Draw(SnakeSymbol);

                this.snakeElements.Enqueue(newHead);

            }
            this.food[this.foodIndex].SetRandomPosition(this.snakeElements);
        }

        private bool IsPointOfSnake()
            => this.snakeElements.Any(x => x.LeftX == this.LeftX && x.TopY == this.TopY);

        private bool IsWallPoint()
            => this.LeftX == 0 || this.TopY == 0 ||
            this.LeftX == this.wall.LeftX - 1 ||
            this.TopY == this.wall.TopY - 1;

        private void GetNextPoint(Point head, Point direction)
        {
            this.LeftX = head.LeftX + direction.LeftX;
            this.TopY = head.TopY + direction.TopY;
        }

        private void CreatSnake()
        {
            for (int i = 0; i < 6; i++)
            {
                var point = new Point(this.LeftX + i, this.TopY);
                point.Draw(SnakeSymbol);

                snakeElements.Enqueue(point);
            }
        }
    }
}
