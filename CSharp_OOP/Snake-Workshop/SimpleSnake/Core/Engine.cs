﻿using SimpleSnake.Enums;
using SimpleSnake.GameObjects;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;

namespace SimpleSnake.Core
{
    public class Engine
    {
        private Direction direction;
        private Snake snake;
        private Wall wall;
        private int sleepTime = 100;
        private Point[] directionPoints;

        public Engine(Snake snake, Wall wall)
        {
            this.snake = snake;
            this.wall = wall;

            this.direction = Direction.Right;

            this.directionPoints = new Point[]
            {
                new Point(1,0),
                new Point(-1,0),
                new Point(0,1),
                new Point(0,-1)
            };
        }

        public void Run()
        {
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    GetNextDirection();

                }

                var canMove = this.snake.IsMoving(this.directionPoints[(int)this.direction]);

                if (!canMove)
                {
                    Console.SetCursorPosition(0, this.wall.TopY + 2);

                    File.AppendAllText("../../../Database/scores.txt", $"Yovko - {this.snake.Length} - {DateTime.Now.ToString("MM/dd/yyyy HH:mm")}{Environment.NewLine}");

                    var result = File.ReadAllText("../../../Database/scores.txt");

                    Console.WriteLine(result);

                    Console.WriteLine("Oh nooooo");
                    Thread.Sleep(2000);

                    StartUp.Main();
                }

                Thread.Sleep(sleepTime);
            }
        }

        private void GetNextDirection()
        {
            ConsoleKeyInfo input = Console.ReadKey();

            if (input.Key == ConsoleKey.LeftArrow)
            {
                if (this.direction != Direction.Right)
                {
                    direction = Direction.Left;
                }
            }
            else if (input.Key == ConsoleKey.RightArrow)
            {
                if (this.direction != Direction.Left)
                {
                    direction = Direction.Right;
                }
            }
            else if (input.Key == ConsoleKey.UpArrow)
            {
                if (this.direction != Direction.Down)
                {
                    direction = Direction.Up;
                }
            }
            else if (input.Key == ConsoleKey.DownArrow)
            {
                if (this.direction != Direction.Up)
                {
                    direction = Direction.Down;
                }
            }
        }
    }
}
