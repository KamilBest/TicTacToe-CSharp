using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class GameBoard
    {
        public char[,] Board;
        private const int BOARD_SIZE = 3;
        /** 
        Constructor 
            */

        public GameBoard()
        {
            Board = new char[BOARD_SIZE,BOARD_SIZE];
            initializeBoard();
        }

        /**
        Initialize Board - set board fields as empty
            */
        private void initializeBoard()
        {
           
            for(int i=0;i<BOARD_SIZE;i++)
            {
                for (int j = 0; j < BOARD_SIZE; j++)
                {
                    Board[i, j] = (char)FIELD.FLD_EMPTY;
                }
            }
        }
      
        /**
        Draw board method
    */
        public void printBoard()
        {
            const int ASCII_CODE_0 = 48;
            int fieldNumber = 1;
            Console.WriteLine("-----");
            for (int i = 0; i < BOARD_SIZE; i++)
            {
                for (int j = 0; j < BOARD_SIZE; j++)
                {
                    if (Board[i, j] == (char)FIELD.FLD_EMPTY)
                        Console.Write((char)(ASCII_CODE_0 + fieldNumber));
                    else
                        Console.Write(Board[i, j]);
                    fieldNumber++;

                    if (j<BOARD_SIZE-1)
                    {
                        Console.Write("|");
                    }
                }
                Console.Write("\n");
            }
            Console.WriteLine("-----");
        }

        public void putMark(Player player, int fieldNumber)
        {
           
            int verticalY = (fieldNumber - 1) / 3;
            int horizontalX = (fieldNumber - 1) % 3;
            if (Board[verticalY, horizontalX] == (char)FIELD.FLD_EMPTY)
                Board[verticalY, horizontalX] = player.getSign();
            else {
                Console.WriteLine("To miejsce jest zajete. Wybierz pole jeszcze raz:");
                putMark(player, player.takeTurn());
            }
        }

        public void clearBoard()
        {
            Console.Clear();
        }

        private bool checkRowsForWin()
        {
            for(int i=0;i<BOARD_SIZE;i++)
            {
                if (checkRowCol(Board[i, 0], Board[i, 1], Board[i, 2]))
                    return true;
            }
            return false;
        }
        private bool checkColumnsForWin()
        {
            for (int i = 0; i < BOARD_SIZE; i++)
            {
                if (checkRowCol(Board[0,i], Board[1,i], Board[2,i]))
                    return true;
            }
            return false;
        }

         // Check the two diagonals to see if either is a win. Return true if either wins.
    private bool checkDiagonalsForWin()
        {
        return ((checkRowCol(Board[0,0], Board[1,1], Board[2,2]) == true) || (checkRowCol(Board[0,2], Board[1,1], Board[2,0]) == true));
        }
        
        // Check to see if all three values are the same (and not empty) indicating a win.

        private bool checkRowCol(char c1, char c2, char c3)
        {

            return (c1 != ' ') && (c1 == c2) && (c2 == c3);
        }
    
        public bool checkWin( )
        {
            return (checkRowsForWin() || checkColumnsForWin() || checkDiagonalsForWin());
        }





    }
}
