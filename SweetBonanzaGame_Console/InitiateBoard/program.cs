using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InitiateSymbols;
using Information;
using InitiateMultiplier;

namespace InitiateBoard
{
    public class Board
    {

        public void Initiate(GameInfo gameInfo, Symbol[] symbols, Multiplier[] multipliers, out Symbol[,] gameBoard)
        {
            var generateRandomBoard = new GenerateRandomBoard();
            gameBoard = generateRandomBoard.Generate(gameInfo, symbols, multipliers);
        }

        public void InitiateBonusBuy(GameInfo gameInfo, Symbol[] symbols, Multiplier[] multipliers, out Symbol[,] gameBoard)
        {
            var generateRandomBoard = new GenerateRandomBoard();
            gameBoard = generateRandomBoard.GenerateWithBonusGuarantee(gameInfo, symbols, multipliers);
        }

        public void Initiate(GameInfo gameInfo, Symbol[] symbols, Multiplier[] multipliers, Symbol[,] oldGameBoard, out Symbol[,] gameBoard)
        {
            var addNewSymbols = new AddNewSymbols();
            gameBoard = addNewSymbols.Add(gameInfo, symbols, multipliers, oldGameBoard);
        }

    }
}
