using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Point
{
    public int x;
    public int y;

    public Point(int nx, int ny)
    {
        x = nx;
        y = ny;
    }

    //For addition of a point with a integer
    public void add(Point p)
    {
        x += p.x;
        y += p.y;
    }
    //For multiplication of a point with a integer
    public void mult(int m)
    {
        x *= m;
        y *= m;
    }


    //Return coordinates as a Vector
    public Vector2 toVector()
    {
        return new Vector2(x, y);
    }
    //check if Point has the same coordinates
    public bool equals(Point p)
    {
        return (x == p.x && y == p.y);
    }

    public static Point fromVector(Vector2 v)
    {
        return new Point((int)v.x, (int)v.y);
    }
    //Incase we cast from a vector3
    public static Point fromVector(Vector3 v)
    {
        return new Point((int)v.x, (int)v.y);
    }
    //For addition of a point with a integer
    public static Point add(Point p, Point o)
    {
        return new Point(p.x + o.x, p.y + o.y);
    }
    //For multiplication of a point with a integer
    public static Point mult(Point p, int m)
    {
        return new Point(p.x * m, p.y * m);
    }
    //Set a point equal to another.
    public static Point clone(Point p)
    {
        return new Point(p.x, p.y);
    }


    //get a zero vector
    public static Point zero
    {
        get{ return new Point(0, 0); }
    }
    //get a up vector
    public static Point up
    {
        get { return new Point(0, 1); }
    }
    //get a down vector
    public static Point down
    {
        get { return new Point(0, -1); }
    }
    //get a left vector
    public static Point left
    {
        get { return new Point(-1, 0); }
    }
    //get a right vector
    public static Point right
    {
        get { return new Point(1, 0); }
    }
}
