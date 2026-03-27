using System;
namespace Snake_Game_Jan26;

public class Position
{
    private int _x;
    private int _y;
    public int X
    {
        get { return _x; }
        set { _x = value; }
    }
    public int Y
    {
        get { return _y; }
        set { _y = value; }
    }

    public Position(int x, int y)
    {
        _x = x;
        _y = y;
    }

    // Method to check if two positions are the same (useful for eating food)
    public bool Equals(Position other)
    {
        return other != null && this.X == other.X && this.Y == other.Y;
    }
}