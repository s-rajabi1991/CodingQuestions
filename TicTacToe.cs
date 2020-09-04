using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Xml.XPath;

namespace AmazonTopQuestions
{
    public class TicTacToe
    {
        //public int[,] Board { get; set; }
        //public int Size { get; set; }
        //public int Result { get; set; }
        ///** Initialize your data structure here. */
        //public TicTacToe(int n)
        //{
        //    Result = 0;
        //    Board = new int[n, n];
        //    Size = n;
        //}

        ///** Player {player} makes a move at ({row}, {col}).
        //    @param row The row of the board.
        //    @param col The column of the board.
        //    @param player The player, can be either 1 or 2.
        //    @return The current winning condition, can be either:
        //            0: No one wins.
        //            1: Player 1 wins.
        //            2: Player 2 wins. */
        //public int Move(int row, int col, int player)
        //{
        //    if (Result == 0)
        //    {
        //        Board[row, col] = player;

        //        if (ColumnFormed(row, player) || RowFormed(col, player))
        //            return Result;


        //        if(row == col)
        //        {
        //            if (Diagnal1Formed(player))
        //                return Result;
        //        }

        //        if (row + col == Size-1)
        //        {
        //            if (Diagnal2Formed(player))
        //                return Result;
        //        }
        //    }

        //    return Result;


        //}

        //private bool ColumnFormed(int row, int player)
        //{
        //    bool success = true;
        //    for (int j = 0; j < Size; j++)
        //    {
        //        if (Board[row, j] != player)
        //        {
        //            success = false;
        //            break;
        //        }
        //    }
        //    if (success)
        //    {
        //        Result = player;
        //        return true;
        //    }
        //    return false;
        //}

        //private bool RowFormed(int col, int player)
        //{
        //    bool success = true;

        //    for (int i = 0; i < Size; i++)
        //    {
        //        if (Board[i,col] != player)
        //        {
        //            success = false;
        //            break;
        //        }
        //    }

        //    if (success)
        //    {
        //        Result = player;
        //        return true;
        //    }
        //    return false;
        //}

        //private bool Diagnal1Formed(int player)
        //{
        //    bool success = true;

        //    for (int i = 0; i < Size; i++)
        //    {
        //        if (Board[i, i] != player)
        //        {
        //            success = false;
        //            break;
        //        }
        //    }

        //    if (success)
        //    {
        //        Result = player;
        //        return true;
        //    }
        //    return false;
        //}
        //private bool Diagnal2Formed(int player)
        //{
        //    bool success = true;

        //    for (int i = Size-1; i >= 0; i--)
        //    {
        //        if (Board[i, Size-1-i] != player)
        //        {
        //            success = false;
        //            break;
        //        }
        //    }

        //    if (success)
        //    {
        //        Result = player;
        //        return true;
        //    }
        //    return false;
        //}


        //my solution was O(n). here is a better o(1) solution:
        private int[] rows;
        private int[] cols;
        private int diagonal;
        private int antiDiagonal;

        /** Initialize your data structure here. */
        public TicTacToe(int n)
        {
            rows = new int[n];
            cols = new int[n];
        }

        /** Player {player} makes a move at ({row}, {col}).
            @param row The row of the board.
            @param col The column of the board.
            @param player The player, can be either 1 or 2.
            @return The current winning condition, can be either:
                    0: No one wins.
                    1: Player 1 wins.
                    2: Player 2 wins. */
        public int Move(int row, int col, int player)
        {
            int toAdd = player == 1 ? 1 : -1;

            rows[row] += toAdd;
            cols[col] += toAdd;
            if (row == col)
            {
                diagonal += toAdd;
            }

            if (col+row == cols.Length - 1)
            {
                antiDiagonal += toAdd;
            }

            int size = rows.Length;
            if (Math.Abs(rows[row]) == size ||
                Math.Abs(cols[col]) == size ||
                Math.Abs(diagonal) == size ||
                Math.Abs(antiDiagonal) == size)
            {
                return player;
            }

            return 0;
        }
    }

}

