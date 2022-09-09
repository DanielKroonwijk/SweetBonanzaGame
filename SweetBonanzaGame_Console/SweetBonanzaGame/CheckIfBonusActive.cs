using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InitiateSymbols;
using Information;
using InitiateBoard;

namespace SweetBonanzaGame
{
    class CheckIfBonusActive
    {

        public double Check(GameInfo gameInfo, Symbol[]symbols, Symbol[,] gameBoard, double betSize, out GameInfo updatedGameInfo)
        {
            updatedGameInfo = gameInfo;
            int count = 0;
            var symbol = symbols[0];
            for (int column = 0; column < gameBoard.GetLength(0); column++)
            {
                for (int row = 0; row < gameBoard.GetLength(1); row++)
                {
                    if (gameBoard[column, row].symbolName == symbol.symbolName)
                    {
                        count++;
                        if (count >= 4)
                        {
                            var calculateWin = new CalculateWin();
                            double win = calculateWin.Calculate(gameInfo, symbols, gameBoard, betSize);
                            updatedGameInfo.bonusActive = true;

                            return win;
                        }
                    }
                }
            }

            return 0;
        }

    }
}
