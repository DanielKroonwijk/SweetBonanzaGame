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
    public class GenerateRandomBoard
    {

        public Symbol[,] Generate(GameInfo gameInfo, Symbol[] symbols, Multiplier[]multipliers)
        {
            var gameBoardNumber = 0;
            var gameBoardSymbols = new Symbol[gameInfo.boardColumn, gameInfo.boardRow];
            for(int column = 0; column < gameInfo.boardColumn; column++)
            {
                for(int row = 0; row < gameInfo.boardRow; row++)
                {
                    var generateRandomNumber = new GenerateRandomNumber();
                    var transformNumberInSymbol = new TransformNumberInSymbol();
                    gameBoardNumber = generateRandomNumber.Generate(gameInfo, symbols, false);
                    gameBoardSymbols[column, row] = transformNumberInSymbol.Transform(gameInfo, symbols, multipliers, gameBoardNumber);
                }
            }

            return gameBoardSymbols;
        }

        public Symbol[,] GenerateWithBonusGuarantee(GameInfo gameInfo, Symbol[] symbols, Multiplier[] multipliers)
        {
            var gameBoardNumber = 0;
            var gameBoardSymbols = new Symbol[gameInfo.boardColumn, gameInfo.boardRow];
            List<int[]> usedCoordinates = new List<int[]>();
            for (int i = 0; i < gameInfo.scattersForBonus; i++)
            {
                var generateRandomCoordinates = new GenerateRandomCoordinates();
                usedCoordinates.Add(generateRandomCoordinates.Generate(gameInfo, usedCoordinates));
                gameBoardSymbols[usedCoordinates[i][0], usedCoordinates[i][1]] = symbols[0];
            }

            for (int column = 0; column < gameInfo.boardColumn; column++)
            {
                for (int row = 0; row < gameInfo.boardRow; row++)
                {
                    if (gameBoardSymbols[column, row] == null)
                    {
                        var generateRandomNumber = new GenerateRandomNumber();
                        var transformNumberInSymbol = new TransformNumberInSymbol();
                        gameBoardNumber = generateRandomNumber.Generate(gameInfo, symbols, true);
                        gameBoardSymbols[column, row] = transformNumberInSymbol.Transform(gameInfo, symbols, multipliers, gameBoardNumber);
                    }
                }
            }

            return gameBoardSymbols;
        }

    }
}
