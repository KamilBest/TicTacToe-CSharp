using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class TicTacToe
    {
        public TicTacToe()
        {
            play();
        }

        public void play()
        {
            GameBoard gameBoard = new GameBoard();
            Player playerX = new Player('X');
            Player playerO = new Player('O');
            Player currentPlayer = playerX;
            int moveCounter = 0;
            bool play = true;
            while (play)
            {
                gameBoard.printBoard();
                Console.WriteLine("Graczu: {0} Podaj pole, w ktorym chcesz umiescic znak: ", currentPlayer.getSign());
                gameBoard.putMark(currentPlayer, playerX.takeTurn());
                gameBoard.clearBoard();
                moveCounter++;
                if(gameBoard.checkWin())
                {
                    Console.Write("Gracz: {0} wygrał!", currentPlayer.getSign());
                    gameBoard.printBoard();
                    play = false;
                }
                else if (checkDraw(moveCounter))
                {
                    Console.Write("REMIS");
                    gameBoard.printBoard();
                    play = false;
                }
                currentPlayer = changeCurrentPlayer(currentPlayer, playerX, playerO);



            }
        }
        private Player changeCurrentPlayer(Player currentPlayer, Player playerX,Player playerO)
        {
            if (currentPlayer == playerX)
                currentPlayer = playerO;
            else
                currentPlayer = playerX;
            return currentPlayer;
        }

        private bool checkDraw(int turnCounter)
        {
            if (turnCounter == 9)
                return true;
            return false;
        }

      

    }

}

