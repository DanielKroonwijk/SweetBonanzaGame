using System;
using System.Collections.Generic;
using System.Text;
using Information;
using InitiateSymbols;
using InitiateBoard;

namespace SweetBonanzaGame
{
    class ShowBoard
    {

        public void Show(Symbol[,] gameBoard, double win, string winText)
        {
            Console.WriteLine();
            for (int column = 0; column < gameBoard.GetLength(0); column++)
            {
                Console.WriteLine();
                for (int row = 0; row < gameBoard.GetLength(1); row++)
                {
                    if (gameBoard[column, row].symbolName == "scatter")
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("|  SC  |");
                        Console.ResetColor();
                    }
                    else if (gameBoard[column, row].symbolName == "Red-Premium")
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.Write("|  RP  |");
                        Console.ResetColor();
                    }
                    else if (gameBoard[column, row].symbolName == "Pink-Premium")
                    {
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        Console.Write("|  PP  |");
                        Console.ResetColor();
                    }
                    else if (gameBoard[column, row].symbolName == "Green-Premium")
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.Write("|  GP  |");
                        Console.ResetColor();
                    }
                    else if (gameBoard[column, row].symbolName == "Blue-Premium")
                    {
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        Console.Write("|  BP  |");
                        Console.ResetColor();
                    }
                    else if (gameBoard[column, row].symbolName == "Red-Low")
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("|  RL  |");
                        Console.ResetColor();
                    }
                    else if (gameBoard[column, row].symbolName == "Pink-Low")
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write("|  PL  |");
                        Console.ResetColor();
                    }
                    else if (gameBoard[column, row].symbolName == "Green-Low")
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("|  GL  |");
                        Console.ResetColor();
                    }
                    else if (gameBoard[column, row].symbolName == "Blue-Low")
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write("|  BL  |");
                        Console.ResetColor();
                    }
                    else if (gameBoard[column, row].symbolName == "Yellow-Low")
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("|  YL  |");
                        Console.ResetColor();
                    }
                    else if (gameBoard[column, row].symbolName == "Multiplier")
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.Write("|  MU  |");
                        Console.ResetColor();
                    }
                }
            }

            Console.WriteLine();
            Console.WriteLine($"{winText}: €{win:0.00}");
        }

        public void Show(Symbol[,] gameBoard, double win, double spinWin, string winText)
        {
            Console.WriteLine();
            for (int column = 0; column < gameBoard.GetLength(0); column++)
            {
                Console.WriteLine();
                for (int row = 0; row < gameBoard.GetLength(1); row++)
                {
                    if (gameBoard[column, row].symbolName == "scatter")
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("|  SC  |");
                        Console.ResetColor();
                    }
                    else if (gameBoard[column, row].symbolName == "Red-Premium")
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.Write("|  RP  |");
                        Console.ResetColor();
                    }
                    else if (gameBoard[column, row].symbolName == "Pink-Premium")
                    {
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        Console.Write("|  PP  |");
                        Console.ResetColor();
                    }
                    else if (gameBoard[column, row].symbolName == "Green-Premium")
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.Write("|  GP  |");
                        Console.ResetColor();
                    }
                    else if (gameBoard[column, row].symbolName == "Blue-Premium")
                    {
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        Console.Write("|  BP  |");
                        Console.ResetColor();
                    }
                    else if (gameBoard[column, row].symbolName == "Red-Low")
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("|  RL  |");
                        Console.ResetColor();
                    }
                    else if (gameBoard[column, row].symbolName == "Pink-Low")
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write("|  PL  |");
                        Console.ResetColor();
                    }
                    else if (gameBoard[column, row].symbolName == "Green-Low")
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("|  GL  |");
                        Console.ResetColor();
                    }
                    else if (gameBoard[column, row].symbolName == "Blue-Low")
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write("|  BL  |");
                        Console.ResetColor();
                    }
                    else if (gameBoard[column, row].symbolName == "Yellow-Low")
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("|  YL  |");
                        Console.ResetColor();
                    }
                    else if (gameBoard[column, row].symbolName == "Multiplier")
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.Write("|  MU  |");
                        Console.ResetColor();
                    }
                }
            }

            Console.WriteLine();
            Console.WriteLine($"{winText}: €{win:0.00} --- Spin win: €{spinWin:0.00}");
        }
    }
}
