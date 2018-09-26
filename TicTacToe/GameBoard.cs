using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class GameBoard
    {
        public const int BOARD_SIZE = 3;
        public Cell[,] Board;
        /** 
        Constructor 
            */

        public GameBoard()
        {
            initializeBoard();
        }

        /**
        Initialize Board - set board fields as empty
            */
        private void initializeBoard()
        {
           Board = new Cell[BOARD_SIZE,BOARD_SIZE];
            for (int i = 0; i < BOARD_SIZE; i++)
            {
                for (int j = 0; j < BOARD_SIZE; j++)
                {
                    Board[i, j] = new Cell();
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
                    if (Board[i, j].isEmpty())
                        Console.Write((char)(ASCII_CODE_0 + fieldNumber));
                    else
                        Console.Write((char)(Board[i, j].getFieldState()));                      
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
                if (Board[verticalY, horizontalX].isEmpty())
                {
                    Board[verticalY, horizontalX].markField(player);

                }

                else
                {
                    Console.WriteLine("This place is taken. Select the field again: ");
                    putMark(player, player.takeTurn());
                }
        }

        public void clearBoard()
        {
            Console.Clear();
        }
    }
}
