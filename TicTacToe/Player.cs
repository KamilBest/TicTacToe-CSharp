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


        public Player(char playerSign)
        {
            sign = playerSign;
        }

        public char getSign()
        {
            return sign;
        }

        public int takeTurn()
        {
            int fieldNumber = int.Parse(Console.ReadLine());
            return fieldNumber;
        }
    }
}
