using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Information;
using InitiateBoard;
using InitiateSymbols;
using InitiateMultiplier;

namespace SweetBonanzaGame
{
    public class StartBonus
    {

        public void Start(GameInfo gameInfo, Symbol[] symbols, Multiplier[] multipliers, double betSize, double totalWin)
        {
            gameInfo.bonusActive = true;
            int freeSpins = 10;
            for (int i = 0; i < freeSpins; i++)
            {
                var board = new Board();
                board.Initiate(gameInfo, symbols, multipliers, out Symbol[,] gameBoard);

                bool hit = true;
                var showBoard = new ShowBoard();
                double spinWin = 0;
                while (hit == true)
                {
                    var checkHits = new CheckHits();
                    hit = checkHits.Check(gameInfo, symbols, gameBoard);
                    var removeSymbol = new List<Symbol>();

                    var calculateWin = new CalculateWin();
                    spinWin += calculateWin.Calculate(gameInfo, symbols, gameBoard, betSize, out removeSymbol);

                    showBoard.Show(gameBoard, totalWin, spinWin, "Win");
                    if (hit == true)
                    {
                        var removeHitSymbols = new RemoveHitSymbols();
                        gameBoard = removeHitSymbols.Remove(gameBoard, removeSymbol);

                        board.Initiate(gameInfo, symbols, multipliers, gameBoard, out gameBoard);
                    }
                    else
                    {
                        if (spinWin > 0)
                        {
                            var useMuliplier = new UseMultiplier();
                            totalWin += useMuliplier.Use(gameInfo, symbols, gameBoard, spinWin);
                        }

                    var bonusRetriggers = new BonusRetrigger();
                        totalWin += bonusRetriggers.CheckIfBonusRetriggers(symbols, gameBoard, betSize, out bool bonusRetrigger);
                        if(bonusRetrigger == true)
                        {
                            Console.WriteLine("RETRIGGER RETRIGGER RETRIGGER RETRIGGER RETRIGGER RETRIGGER RETRIGGER RETRIGGER RETRIGGER RETRIGGER RETRIGGER RETRIGGER ");
                            freeSpins += 5;
                        }
                    }
                }

                Console.WriteLine($"Total Win:  {totalWin:0.00}");
                Console.WriteLine("Press ENTER to continue..."); Console.ReadKey();
            }

            gameInfo.bonusActive = false;
        }

    }
}
