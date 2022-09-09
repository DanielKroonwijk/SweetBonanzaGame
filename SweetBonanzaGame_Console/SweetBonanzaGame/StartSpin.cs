using System;
using System.Collections.Generic;
using System.Text;
using Information;
using InitiateSymbols;
using InitiateMultiplier;
using InitiateBoard;

namespace SweetBonanzaGame
{
    class StartSpin
    {

        public void Start(GameInfo gameInfo, Symbol[] symbols, Multiplier[] multipliers, double betSize)
        {
            Symbol[,] gameBoard = new Symbol[gameInfo.boardColumn, gameInfo.boardRow];
            var board = new Board();
            if (gameInfo.bonusGuarantee == true)
            {
                board.InitiateBonusBuy(gameInfo, symbols, multipliers, out gameBoard);
                gameInfo.bonusGuarantee = false;
            }
            else
            {
                board.Initiate(gameInfo, symbols, multipliers, out gameBoard);
            }

            double win = 0;
            bool hit = true;
            var showBoard = new ShowBoard();
            while (hit == true)
            {
                var checkHits = new CheckHits();
                hit = checkHits.Check(gameInfo, symbols, gameBoard);
                var removeSymbol = new List<Symbol>();

                if(hit == true)
                {
                    if (win >= 1)
                    {
                        var calculateWin = new CalculateWin();
                        win = calculateWin.Calculate(gameInfo, symbols, gameBoard, win, betSize, out removeSymbol);
                    }
                    else
                    {
                        var calculateWin = new CalculateWin();
                        win = calculateWin.Calculate(gameInfo, symbols, gameBoard, betSize, out removeSymbol);
                    }

                    showBoard.Show(gameBoard, win, "Win");

                    var removeHitSymbols = new RemoveHitSymbols();
                    gameBoard = removeHitSymbols.Remove(gameBoard, removeSymbol);

                    board.Initiate(gameInfo, symbols, multipliers, gameBoard, out gameBoard);
                }
                else
                {
                    showBoard.Show(gameBoard, win, "Total Win");
                    var checkIfBonusActive = new CheckIfBonusActive();
                    win += checkIfBonusActive.Check(gameInfo, symbols, gameBoard, betSize, out gameInfo);
                    if(gameInfo.bonusActive == true)
                    {
                        gameInfo.doubleChanceActive = false;
                        Console.WriteLine("BONUS BONUS BONUS BONUS BONUS BONUS BONUS BONUS BONUS BONUS BONUS BONUS BONUS");
                        Console.WriteLine("Press ENTER to continue"); Console.ReadKey();

                        var startBonus = new StartBonus();
                        startBonus.Start(gameInfo, symbols, multipliers, betSize, win);

                        Console.WriteLine("END OF BONUS");
                        Console.WriteLine();
                        return;
                    }
                }
            }

            return;
        }

    }
}
