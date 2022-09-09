using System;
using System.Collections.Generic;
using System.Text;
using Information;
using InitiateSymbols;
using InitiateBoard;
using System.IO;

namespace SweetBonanzaGame
{
    public class CalculateWin
    {

        public double Calculate(GameInfo gameInfo, Symbol[] symbols, Symbol[,] gameBoard, double betSize, out List<Symbol> removeSymbol)
        {
            double totalWin = 0;
            removeSymbol = new List<Symbol>();
            for (int i = 0; i < symbols.Length-gameInfo.bonusSymbols; i++)
            {
                int count = 0;
                var symbol = symbols[i];
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

                if (count >= 8)
                {
                    if (symbol.symbolName != "scatter")
                    {
                        removeSymbol.Add(symbol);
                    }

                    var calculatePayout = new CalculatePayouts();
                    totalWin += calculatePayout.Calculate(symbols[i], count, betSize);
                }
            }

            return totalWin;
        }

        public double Calculate(GameInfo gameInfo, Symbol[] symbols, Symbol[,] gameBoard, double totalWin, double betSize, out List<Symbol> removeSymbol)
        {
            removeSymbol = new List<Symbol>();
            for (int i = 0; i < symbols.Length - gameInfo.bonusSymbols; i++)
            {
                int count = 0;
                var symbol = symbols[i];
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

                if (count >= 8)
                {
                    if (symbol.symbolName != "scatter")
                    {
                        removeSymbol.Add(symbol);
                    }

                    var calculatePayout = new CalculatePayouts();
                    totalWin += calculatePayout.Calculate(symbols[i], count, betSize);
                }
            }

            return totalWin;
        }

        public double Calculate(GameInfo gameInfo, Symbol[] symbols, Symbol[,] gameBoard, double betSize)
        {
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

                if (count >= 4)
                {
                    var calculatePayout = new CalculatePayouts();
                    totalWin += calculatePayout.Calculate(symbols[0], count, betSize);
                }

            return totalWin;
        }

    }
}
