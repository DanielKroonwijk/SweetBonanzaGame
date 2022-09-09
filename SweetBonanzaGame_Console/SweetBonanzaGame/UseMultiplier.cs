using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InitiateSymbols;
using InitiateMultiplier;
using Information;

namespace SweetBonanzaGame
{
    class UseMultiplier
    {

        public double Use(GameInfo gameInfo, Symbol[] symbol, Symbol[,] gameBoard, double spinWin)
        {
            int totalMultiplier = 0;
            for (int column = 0; column < gameInfo.boardColumn; column++)
            {
                for (int row = 0; row < gameInfo.boardRow; row++)
                {
                    totalMultiplier += gameBoard[column, row].multi;
                }
            }

            if (totalMultiplier > 0)
            {
                spinWin *= totalMultiplier;
            }
            return spinWin;
        }
    }
}
