using MDL;
using SolverMethods;
using System.Diagnostics.Metrics;
using System.Threading.Tasks.Dataflow;

SudokuSolver solve = new SudokuSolver();

int[,] sudokuGrid = new int[,]
{
    {5, 3, 0, 0, 7, 0, 0, 0, 0},
    {6, 0, 0, 1, 9, 5, 0, 0, 0},
    {0, 9, 8, 0, 0, 0, 0, 6, 0},
    {8, 0, 0, 0, 6, 0, 0, 0, 3},
    {4, 0, 0, 8, 0, 3, 0, 0, 1},
    {7, 0, 0, 0, 2, 0, 0, 0, 6},
    {0, 6, 0, 0, 0, 0, 2, 8, 0},
    {0, 0, 0, 4, 1, 9, 0, 0, 5},
    {0, 0, 0, 0, 8, 0, 0, 7, 9}
};

int[,] solved = solve.Solve(sudokuGrid);

int counter = 0;
int bigCounter = 0;
foreach (int i in solved)
{
    if (counter % 9 == 0)
    {
        Console.WriteLine();
       
        if (bigCounter % 3 == 0)
        {
            Console.WriteLine("--------------------");
        }
        bigCounter++;
    }
    if (counter % 3 == 0)
    {
        Console.Write("|");

    }
    Console.Write(i + " ");

    counter++;
}

