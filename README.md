# Sudoku Validation Test

#Validity Code

Below is the code tha validates if given n dimentional array is valid Sudoku puzzle or not.

    private static bool ValidateSudoku(int[][] sudoku)
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
