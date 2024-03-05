using MDL;
using System.ComponentModel;
using System.ComponentModel.Design;

namespace SolverMethods
{
    public class SudokuSolver
    {
        public bool Solve(int[,] grid, int r = 0, int c = 0)
        {
            if (r == 9)
            {
                return true;
            }
            else if(c == 9)
            {
                return Solve(grid, r + 1, 0);
            }
            else if(grid[r,c] != 0)
            {
                return Solve(grid, r, c + 1);
            }
            else
            {
                for(int i = 0; i < 10; i++)
                {
                  if (IsValid(grid,r,c,i))
                    {
                        grid[r, c] = i;
                        if (Solve(grid, r, c + 1))
                        {
                            return true;
                        }
                        else
                        {
                            grid[r, c] = 0;
                        }

                    }
                }
                return false;

            }
        }

        private bool IsValid(int[,] grid, int r, int c, int k)
        {
            //k is not found in grid[r]
            bool notInRow = !GetRow(grid, r).Contains(k);

            //k is not found in grid[c]
            bool notInColumn = !GetColumn(grid,r).Contains(k);

            //k is not found in the current subgrid;
            //subgrid found by grid[i][j] i = (r//3*3, r//3*3+3), j = (c//3*3, c//3*3+3) 

            int subGridStartRow = r/3*3;
            int subGridStartColumn = c/3*3;
            bool notInSubGrid = true;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (grid[subGridStartRow+i,subGridStartColumn+j] == k)
                    {
                        break;
                    }
                }
                if (!notInSubGrid)
                {
                    break;
                }
            }
            return notInRow && notInColumn && notInSubGrid;
        }
        int[] GetColumn(int[,] matrix, int columnNumber)
        {
            return Enumerable.Range(0, matrix.GetLength(0))
                    .Select(x => matrix[x, columnNumber])
                    .ToArray();
        }
        int[] GetRow(int[,] matrix, int rowNumber)
        {
            return Enumerable.Range(0, matrix.GetLength(1))
                    .Select(x => matrix[rowNumber, x])
                    .ToArray();
        }
    }
}