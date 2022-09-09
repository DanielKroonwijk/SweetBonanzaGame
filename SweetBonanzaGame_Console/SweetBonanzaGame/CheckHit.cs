using System;
using System.Collections.Generic;
using System.Text;
using Information;
using InitiateSymbols;
using InitiateBoard;

namespace SweetBonanzaGame
{
    class CheckHits
    {

        public bool Check(GameInfo gameInfo, Symbol[] symbols, Symbol[,] gameBoard)
        {
            for(int i = 0; i < symbols.Length-gameInfo.bonusSymbols; i++)
            {
                int count = 0;
                var symbol = symbols[i];
                for (int column = 0; column < gameBoard.GetLength(0); column++)
                {
                    for (int row = 0; row < gameBoard.GetLength(1); row++)
                    {
                        if(gameBoard[column, row].symbolName == symbol.symbolName)
                        {
                            count++;
                            if ((count >= 8)&&(symbol.symbolName != "scatter"))
                            {
                                return true;
                            }
                        }
                    }
                }
            }

            return false;
        }

    }
}
