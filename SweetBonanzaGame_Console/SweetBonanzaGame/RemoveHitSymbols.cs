using System;
using System.Collections.Generic;
using System.Text;
using Information;
using InitiateSymbols;
using InitiateBoard;

namespace SweetBonanzaGame
{
    public class RemoveHitSymbols
    {

        public Symbol[,] Remove(Symbol[,] gameBoard, List<Symbol> removeSymbol)
        {
            for (int column = 0; column < gameBoard.GetLength(0); column++)
            {
                for (int row = 0; row < gameBoard.GetLength(1); row++)
                {
                    for (int i = 0; i < removeSymbol.Count; i++)
                    {
                        if (gameBoard[column, row] == removeSymbol[i])
                        {
                            gameBoard[column, row] = null;
                        }
                    }
                }
            }

            return gameBoard;
        }

    }
}
