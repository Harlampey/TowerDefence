using System.Collections.Generic;
using UnityEngine;

public class PathGenerator
{
    private int _width, _height;
    private List<Vector2Int> pathCells;

    public PathGenerator(int width, int height)
    {
        _width = width;
        _height = height;
    }

    public List<Vector2Int> GeneratePath()
    {
        pathCells = new List<Vector2Int>();

        int y = (int)_height / 2;
        int x = 0;

        while (x < _width)
        {
            pathCells.Add(new Vector2Int(x, y));

            bool validMove = false;

            while (!validMove)
            {
                int move = Random.Range(0, 3);

                if (move == 0 || x % 2 == 0 || x > (_width - 2))
                {
                    x++;
                    validMove = true;
                }
                else if (move == 1 && CellIsEmpty(x, y + 1) && y < (_height - 2))
                {
                    y++;
                    validMove = true;
                }
                else if (move == 2 && CellIsEmpty(x, y - 1) && y > 1)
                {
                    y--;
                    validMove = true;
                }
            }
        }

        return pathCells;
    }

    public bool CellIsEmpty(int x, int y)
    {
        return !pathCells.Contains(new Vector2Int(x, y));
    }

    public bool CellIsTaken(int x, int y)
    {
        return pathCells.Contains(new Vector2Int(x, y));
    }

    public int getCellNeighbourValue(int x, int y)
    {
        int result = 0;

        if (CellIsTaken(x, y - 1))
        {
            result += 1;
        }
        if (CellIsTaken(x - 1, y))
        {
            result += 2;
        }
        if (CellIsTaken(x + 1, y))
        {
            result += 4;
        }
        if (CellIsTaken(x, y + 1))
        {
            result += 8;
        }

        return result;
    }
}