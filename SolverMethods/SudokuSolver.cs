using MDL;
using System.ComponentModel;
using System.ComponentModel.Design;

namespace SolverMethods
{
    public class SudokuSolver
    {
        public int[,] Solve(int[,] grid, int row = 0, int column = 0)
        {
            if (row == 9)
            {
                return grid;
            }
            else if (column == 9)
            {
                return Solve(grid, row + 1, 0);
            }
            else if (grid[row, column] != 0)
            {
                return Solve(grid, row, column + 1);
            }
            else
            {
                for (int i = 1; i <= 9; i++)
                {
                    if (IsValid(grid, row, column, i))
                    {
                        grid[row, column] = i;

                        int[,] result = Solve(grid, row, column + 1);

                        if (result != null)
                        {
                            return result;
                        }
                        else
                        {
                            grid[row, column] = 0;
                        }
                    }
                }
                return null;
            }
        }
        private bool IsValid(int[,] grid, int r, int c, int k)
        {
            bool InRow = GetRow(grid, r).Contains(k);
            bool InColumn = GetColumn(grid, c).Contains(k);

            int subGridStartRow = r / 3 * 3;
            int subGridStartColumn = c / 3 * 3;

            bool InSubGrid = false;

            for (int i = 0; i < 3; i++)
            {
                if (InSubGrid)
                {
                    break;
                }
                for (int j = 0; j < 3; j++)
                {
                    if (grid[subGridStartRow + i, subGridStartColumn + j] == k)
                    {
                        InSubGrid = true;
                        break;
                    }
                }
            }
            if (InRow || InColumn || InSubGrid)
            {
                return false;
            }
            else
            {
                return true;
            }
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