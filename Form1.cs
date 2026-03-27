using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Snake_Game_Jan26;

public partial class Form1 : Form
{
    Snake mySnake = new Snake(new Position(10, 10));
    Food myFood = new Food(15, 15); 
    int cellSize = 20;

    public Form1()
    {
        InitializeComponent();
        DoubleBuffered = true; 
        KeyPreview = true;
        this.KeyDown += Form1_KeyDown;
    }

    private void timer1_Tick(object sender, EventArgs e)
    {
        mySnake.Move();

        //if snake eats food [use (x,y) for both snake head and food position], body grows
        if (mySnake.Body[0].X == myFood.Pos.X && mySnake.Body[0].Y == myFood.Pos.Y)
        {
            mySnake.Grow();
            Random r = new Random();
            myFood = new Food(r.Next(0, 25), r.Next(2, 25));
            label1.Text="Score: " + (mySnake.Body.Count - 1);
        }

        //check if snake hits the wall
        if (mySnake.Body[0].X < 0 || mySnake.Body[0].X >= 25 ||  mySnake.Body[0].Y < 0 || mySnake.Body[0].Y >= 25)
        {
            GameOver();
        }

        this.Invalidate(); 
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        //override from food.cs
        myFood.Draw(e.Graphics, cellSize);

        //drawing snake in rectangle and green
        foreach (var p in mySnake.Body)
        {
            e.Graphics.FillRectangle(Brushes.Green, p.X * cellSize, p.Y * cellSize, cellSize, cellSize);
        }
    }
    private void Form1_KeyDown(object? sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Up && mySnake.Direction != "Down") mySnake.Direction = "Up";
        if (e.KeyCode == Keys.Down && mySnake.Direction != "Up") mySnake.Direction = "Down";
        if (e.KeyCode == Keys.Left && mySnake.Direction != "Right") mySnake.Direction = "Left";
        if (e.KeyCode == Keys.Right && mySnake.Direction != "Left") mySnake.Direction = "Right";
    }

    private void GameOver()
    {
        timer1.Stop();
        MessageBox.Show("Game Over! Score: " + (mySnake.Body.Count - 1));
        if (MessageBox.Show("Do you want to play again?", "Play Again", MessageBoxButtons.YesNo) == DialogResult.Yes)
            Application.Restart();
        else
            Application.Exit();
    }

}