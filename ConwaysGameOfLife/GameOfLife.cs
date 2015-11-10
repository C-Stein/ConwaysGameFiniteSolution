using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConwaysGameOfLife
{
    public class GameOfLife : Board
    {
        public bool[,] grid;
        public int Row { get; set; }
        public int Col { get; set; }
        public GameOfLife()
        {

        }
        public GameOfLife( int row, int col)
        {
            Row = row;
            Col = col;
            grid = new bool[row, col];
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    grid[i, j] = false;
                }
            }
        }
        public int GetAliveNeighbors(int row, int col)
        {
            int neighbors = 0;
            if (grid[row - 1, col - 1])
            {
                neighbors++;
            }
            if (grid[row - 1, col])
            {
                neighbors++;
            }
            if (grid[row - 1, col + 1])
            {
                neighbors++;
            }
            if (grid[row, col - 1])
            {
                neighbors++;
            }
            if (grid[row, col + 1])
            {
                neighbors++;
            }
            if (grid[row + 1, col - 1])
            {
                neighbors++;
            }
            if (grid[row + 1, col])
            {
                neighbors++;
            }
            if (grid[row + 1, col + 1])
            {
                neighbors++;
            }
            return neighbors;
        }
        public List<List<bool>> ToList()
        {
            throw new NotImplementedException();
        }

        public bool IsEdge(int row, int col)
        {
            if (row == Row-1 || row == 0 || col == Col-1 || col == 0)
            {
                return true;
            } else
            {
                return false;
            }
        }

        public void Tick()
        {
            int row = Row;
            int col = Col;
            bool[,] newGrid = new bool[row, col];
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    if (IsEdge(i, j))
                    {
                        newGrid[i, j] = grid[i, j];
                    }
                    else
                    {
                        int neighbors = GetAliveNeighbors(i, j);
                        if (grid[i, j])
                        {
                            if (neighbors < 2 || neighbors > 3)
                            {
                                newGrid[i, j] = false;
                            }
                            else
                            {
                                newGrid[i, j] = true;
                            }
                        }
                        else if (!grid[i, j])
                        {
                            if (neighbors == 3)
                            {
                                newGrid[i, j] = true;
                            }
                            else
                            {
                                newGrid[i, j] = false;
                            }
                        }
                    }
                }
            }
            grid = newGrid;
        }
    }
}
