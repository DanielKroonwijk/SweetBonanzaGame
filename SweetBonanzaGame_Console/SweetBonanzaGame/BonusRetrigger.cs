using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Information;
using InitiateBoard;
using InitiateSymbols;

namespace SweetBonanzaGame
{
    class BonusRetrigger
    {
        public double CheckIfBonusRetriggers(Symbol[] symbols, Symbol[,] gameBoard, double betSize, out bool bonusRetrigger)
        {
                bonusRetrigger = false;
                double totalWin = 0;
                int count = 0;
                var symbol = symbols[0];
                for (int column = 0; column < gameBoard.GetLength(0); column++)
                {
                    for (int row = 0; row < gameBoard.GetLength(1); row++)
                    {
                        if (gameBoard[column, row].symbolName == symbol.symbolName)
                        {
                            count++;
                        }
                    }
                }

            if (count >= 3)
            {
                bonusRetrigger = true;
                var calculatePayout = new CalculatePayouts();
                totalWin += calculatePayout.Calculate(symbols[0], count, betSize);
            }
            
            return totalWin;
        }
    }
}
