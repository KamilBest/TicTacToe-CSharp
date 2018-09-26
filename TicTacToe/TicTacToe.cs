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
                Console.WriteLine("Player: {0} Enter the field in which you want to put the character: ", currentPlayer.getSign());
                try
                {
                    gameBoard.putMark(currentPlayer, playerX.takeTurn());
                    gameBoard.clearBoard();
                    moveCounter++;
                    if (currentPlayer.checkWin(gameBoard))
                    {
                        Console.WriteLine("Player: {0} won!", currentPlayer.getSign());
                        gameBoard.printBoard();
                        play = false;
                    }
                    else if (checkDraw(moveCounter))
                    {
                        Console.WriteLine("DRAW");
                        gameBoard.printBoard();
                        play = false;
                    }
                    currentPlayer = changeCurrentPlayer(currentPlayer, playerX, playerO);
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid Input. Please enter number between 1-9!");
                    Console.ReadLine();
                    Console.Clear();
                }
            }
        }
        private Player changeCurrentPlayer(Player currentPlayer, Player playerX,Player playerO)
        {
            return currentPlayer==playerX? playerO:playerX;
         
        }

        private bool checkDraw(int turnCounter)
        {
            if (turnCounter == 9)
                return true;
            return false;
        }

      

    }

}

