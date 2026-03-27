using System;
using System.Collections.Generic;
using System.Linq;

namespace Snake_Game_Jan26;

public class Snake
{
    private List<Position> _bodySegments;
    public List<Position> Body => _bodySegments;

    public string Direction { get; set; } = "Right";

    public Snake(Position start)
    {
        _bodySegments = new List<Position> { start };
    }

    public void Move()
    {
        Position head = _bodySegments[0];
        Position newHead = new Position(head.X, head.Y);

        //moving up down left right
        if (Direction == "Up") newHead.Y--;
        else if (Direction == "Down") newHead.Y++;
        else if (Direction == "Left") newHead.X--;
        else if (Direction == "Right") newHead.X++;

        // + head to the front of the list
        _bodySegments.Insert(0, newHead);
        //remove the tail to maintain length
        _bodySegments.RemoveAt(_bodySegments.Count - 1);
    }

    public void Grow()
    {
        // To grow, we simply add a segment at the current tail position
        Position tail = _bodySegments.Last();
        _bodySegments.Add(new Position(tail.X, tail.Y));
    }
}