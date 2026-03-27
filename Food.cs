using System;
using System.Drawing;

namespace Snake_Game_Jan26;

public abstract class GameObject        //base class
{
    public Position Pos { get; set; }
    public abstract void Draw(Graphics g, int cellSize);
}

public class Food : GameObject      //derived class 
{
    public Food(int x, int y)
    {
        Pos = new Position(x, y);
    }

    public override void Draw(Graphics g, int cellSize) //polymorphism for ovveride from abstract
    {
        g.FillEllipse(Brushes.Red, Pos.X * cellSize, Pos.Y * cellSize, cellSize, cellSize);
    }
}