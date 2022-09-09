using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Information;
using InitiateSymbols;
using InitiateMultiplier;

namespace InitiateBoard
{
    public class AddNewSymbols
    {

        public Symbol[,] Add(GameInfo gameInfo, Symbol[] symbols, Multiplier[] multipliers, Symbol[,] gameBoard)
        {
            if (gameInfo.dropInSymbols == false)
            {
                for (int column = 0; column < gameInfo.boardColumn; column++)
                {
                    for (int row = 0; row < gameInfo.boardRow; row++)
                    {
                        if (gameBoard[column, row] == null)
                        {
                            var transformNumberInSymbol = new TransformNumberInSymbol();
                            var generateRandomNumber = new GenerateRandomNumber();
                            gameBoard[column, row] = transformNumberInSymbol.Transform(gameInfo, symbols, multipliers, generateRandomNumber.Generate(gameInfo, symbols, false));
                        }
                    }
                }
            }
            else
            {
                var dropSymbols = new DropSymbols();
                dropSymbols.Drop(gameBoard);
                for (int column = 0; column < gameInfo.boardColumn; column++)
                {
                    for (int row = 0; row < gameInfo.boardRow; row++)
                    {
                        if (gameBoard[column, row] == null)
                        {
                            var transformNumberInSymbol = new TransformNumberInSymbol();
                            var generateRandomNumber = new GenerateRandomNumber();
                            gameBoard[column, row] = transformNumberInSymbol.Transform(gameInfo, symbols, multipliers, generateRandomNumber.Generate(gameInfo, symbols, false));
                        }
                    }
                }
            }

            return gameBoard;
        }

    }
}
