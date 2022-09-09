using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InitiateSymbols;

namespace InitiateBoard
{
    public class DropSymbols
    {

        public Symbol[,] Drop(Symbol[,] gameBoard)
        {

            for(int row = gameBoard.GetLength(1) -1; row > -1; row--)
            {
                for(int column = gameBoard.GetLength(0) -1; column > -1; column--)
                {
                    if (gameBoard[column, row] == null)
                    {
                        int count = 1;
                        for (; ; )
                        {
                            if ((column != 0) && (column - count > -1))
                            {
                                if (gameBoard[column - count, row] != null)
                                {
                                    gameBoard[column, row] = gameBoard[column - count, row];
                                    gameBoard[column - count, row] = null;
                                    break;
                                }
                                else
                                {
                                    count++;
                                }
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                }
            }

            return gameBoard;
        }

    }
}
