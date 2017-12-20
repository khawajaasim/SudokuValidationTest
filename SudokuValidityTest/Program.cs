using System;
using System.Linq;

namespace SudokuValidityTest
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] goodSudoku1 = {
                new int[] {7,8,4,  1,5,9,  3,2,6},
                new int[] {5,3,9,  6,7,2,  8,4,1},
                new int[] {6,1,2,  4,3,8,  7,5,9},

                new int[] {9,2,8,  7,1,5,  4,6,3},
                new int[] {3,5,7,  8,4,6,  1,9,2},
                new int[] {4,6,1,  9,2,3,  5,8,7},

                new int[] {8,7,6,  3,9,4,  2,1,5},
                new int[] {2,4,3,  5,6,1,  9,7,8},
                new int[] {1,9,5,  2,8,7,  6,3,4}
            };


            int[][] goodSudoku2 = {
                new int[] {1,4, 2,3},
                new int[] {3,2, 4,1},

                new int[] {4,1, 3,2},
                new int[] {2,3, 1,4}
            };

            int[][] badSudoku1 =  {
                new int[] {1,2,3, 4,5,6, 7,8,9},
                new int[] {1,2,3, 4,5,6, 7,8,9},
                new int[] {1,2,3, 4,5,6, 7,8,9},

                new int[] {1,2,3, 4,5,6, 7,8,9},
                new int[] {1,2,3, 4,5,6, 7,8,9},
                new int[] {1,2,3, 4,5,6, 7,8,9},

                new int[] {1,2,3, 4,5,6, 7,8,9},
                new int[] {1,2,3, 4,5,6, 7,8,9},
                new int[] {1,2,3, 4,5,6, 7,8,9}
            };

            int[][] badSudoku2 = {
                new int[] {1,2,3,4,5},
                new int[] {1,2,3,4},
                new int[] {1,2,3,4},
                new int[] {1}
            };
            bool goodSudoku = ValidateArray(goodSudoku1);
            bool anotherGoodSudoku = ValidateArray(goodSudoku2);
            bool badSudoku = ValidateArray(badSudoku1);
            bool anotherBadSudoku = ValidateArray(badSudoku2);
        }

        private static bool ValidateArray(int[][] sudoku)
        {
            #region NxN check
            for (int i = 0; i < sudoku.Length - 1; i++)
            {
                if (sudoku.Length != sudoku[i].Length)
                {
                    return false;
                }
                if (sudoku[i].Length != sudoku[i + 1].Length)
                {
                    return false;
                }
            }
            #endregion
            #region check for duplicates in rows

            for (int i = 0; i < sudoku.Length - 1; i++)
            {
                var check = sudoku[i].Count(s => s < 0 || s > sudoku.Length);
                if (!(sudoku[i].Count(s => s < 0 || s > sudoku.Length) <= 0))
                {
                    return false;
                }
                var rowDup = (sudoku[i].Distinct().Count() != sudoku.Length);
                if (rowDup)
                {
                    return false;
                }
                var results = sudoku.Select(c => c.Skip(i).FirstOrDefault());
                var colLenth = results.ToArray().Length;
                for (int j = 0; j < colLenth; j++)
                {
                    var columnDup = (results.ToArray().Distinct().Count() != colLenth);
                    if (columnDup)
                    {
                        return false;
                    }
                }
            }
            #endregion
            return true;
        }
    }
}
