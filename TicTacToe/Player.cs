using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class Player
    {
        char sign;
        /**
        constructor
        */
        public Player(char playerSign)
        {
            sign = playerSign;
        }

        /**
           get player sign
        */
        public char getSign()
        {
            return sign;
        }

        /**
            Read field from player.
        */
        public int takeTurn()
        {
            int fieldNumber = int.Parse(Console.ReadLine());
            return fieldNumber;
        }

        /**
            Check all rows for win
        */
        private bool checkRowsForWin(GameBoard gameBoard)
        {
            for (int i = 0; i < GameBoard.BOARD_SIZE; i++)
            {
                if (checkRowCol(gameBoard.Board[i, 0].getFieldState(), gameBoard.Board[i, 1].getFieldState(), gameBoard.Board[i, 2].getFieldState()))
                    return true;
            }
            return false;
        }
        /**
           Check all columns for win
       */
        private bool checkColumnsForWin(GameBoard gameBoard)
        {
            for (int i = 0; i < GameBoard.BOARD_SIZE; i++)
            {
                if (checkRowCol(gameBoard.Board[0, i].getFieldState(), gameBoard.Board[1, i].getFieldState(), gameBoard.Board[2, i].getFieldState()))
                    return true;
            }
            return false;
        }

        /** 
        Check the two diagonals to see if either is a win. Return true if either wins.
        
            */    
    private bool checkDiagonalsForWin(GameBoard gameBoard)
        {
            return ((checkRowCol(gameBoard.Board[0, 0].getFieldState(), gameBoard.Board[1, 1].getFieldState(), gameBoard.Board[2, 2].getFieldState()) == true) || (checkRowCol(gameBoard.Board[0, 2].getFieldState(), gameBoard.Board[1, 1].getFieldState(), gameBoard.Board[2, 0].getFieldState()) == true));
        }

        /**
        Check to see if all three values are the same (and not empty) indicating a win.
    */
        private bool checkRowCol(FIELD c1, FIELD c2, FIELD c3)
        {

            return (c1!=FIELD.FLD_EMPTY) && (c1 == c2) && (c2 == c3);
        }

        /**
        Check to see if all three conditions are true indicating win.
    */
        public bool checkWin(GameBoard gameBoard)
        {
            return (checkRowsForWin(gameBoard) || checkColumnsForWin(gameBoard) || checkDiagonalsForWin(gameBoard));
        }

    }
}
