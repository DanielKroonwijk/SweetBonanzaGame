using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    class GenerateNewBoard
    {
        public void Generate(out Symbol[,] gameBoard)
        {
            gameBoard = Board();
        }

        public Symbol[,] Board()
        {
            var gameBoardNumber = 0;
            var gameBoardSymbols = new Symbol[GameLibrary.gameInfo.boardColumn, GameLibrary.gameInfo.boardRow];
            for (int column = 0; column < GameLibrary.gameInfo.boardColumn; column++)
            {
                for (int row = 0; row < GameLibrary.gameInfo.boardRow; row++)
                {
                    gameBoardNumber = RandomNumber();
                    gameBoardSymbols[column, row] = TransformNumber(gameBoardNumber);
                }
            }

            return gameBoardSymbols;
        }

        public int RandomNumber()
        {

            int chance = 0;
            if (GameLibrary.gameInfo.bonusActive != true)
            {
                for (int i = 0; i < GameLibrary.symbols.Length - GameLibrary.gameInfo.bonusSymbols; i++)
                {
                    var symbol = GameLibrary.symbols[i];
                    chance += symbol.symbolChance;
                }
            }
            else
            {
                for (int i = 0; i < GameLibrary.symbols.Length; i++)
                {
                    var symbol = GameLibrary.symbols[i];
                    chance += symbol.symbolChance;
                }
            }

            int randomNumber;

            randomNumber = Random.Range(0, chance - 1);

            return randomNumber;
        }

        public Symbol TransformNumber(int gameBoardNumber)
        {
            Symbol numberInSymbol = new Symbol();
            int lastHighestNumber = 0;
            for (int i = 0; i < GameLibrary.symbols.Length; i++)
            {
                var symbol = GameLibrary.symbols[i];
                if ((gameBoardNumber >= lastHighestNumber) && (gameBoardNumber <= symbol.symbolChance + lastHighestNumber - 1))
                {
                    numberInSymbol = GameLibrary.symbols[i];
                    lastHighestNumber += symbol.symbolChance;
                }
                else
                {
                    lastHighestNumber += symbol.symbolChance;
                }
            }

            if (numberInSymbol.symbolPrefab == GameLibrary.symbols[GameLibrary.symbols.Length - 1].symbolPrefab)
            {
                numberInSymbol = GameElements.GetMultiplier(numberInSymbol);
            }

            return numberInSymbol;
        }
    }
}
