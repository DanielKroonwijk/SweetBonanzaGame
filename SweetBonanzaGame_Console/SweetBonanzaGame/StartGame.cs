using System;
using System.Collections.Generic;
using System.Text;
using Information;
using InitiateSymbols;
using InitiateBoard;
using InitiateMultiplier;

namespace SweetBonanzaGame
{
    public class StartGame
    {

        public void Start(GameInfo gameInfo)
        {
            var initSymbols = new InitSymbols();
            initSymbols.Initiate(gameInfo, out Symbol[] symbols);

            var initMultipliers = new InitMultipliers();
            initMultipliers.Initiate(gameInfo, out Multiplier[] multipliers);

            Console.Write("Enter Betsize (0.20, 0.40, 0.60, 0.80, 1.00 --> 100, 120, 140, 160, 180, 200 (to a max of 500€): ");
            double betSize = double.Parse(Console.ReadLine());

            for (; ; )
            {
                Console.Write("Choose Option (Information, BetSize, Spin, End, Double Chance, Buy Bonus): ");
                string input = Console.ReadLine().ToLower();
                if (input == "information")
                {
                    var printSymbols = new PrintSymbols();
                    printSymbols.Print(symbols);
                }
                else if(input == "betsize")
                {
                    Console.WriteLine("Enter Betsize: (0.20, 0.40, 0.60, 0.80, 1.00 --> 100, 120, 140, 160, 180, 200 (to a max of 500€): ");
                    betSize = double.Parse(Console.ReadLine());
                }
                else if (input == "spin")
                {
                        var startSpin = new StartSpin();
                        startSpin.Start(gameInfo, symbols, multipliers, betSize);
                }
                else if (input == "end")
                {
                    return;
                }
                else if(input == "double chance")
                {
                    var scatter = symbols[0];
                    Console.Write("Set Double Chance (ON / OFF): ");
                    var input2 = Console.ReadLine().ToUpper();
                    for (; ; )
                    {
                        if ((input2 == "OFF") && (gameInfo.doubleChanceActive == false))
                        {
                            Console.WriteLine("Double Chance is already OFF!!!");
                            break;
                        }
                        else if ((input2 == "OFF") && (gameInfo.doubleChanceActive == true))
                        {
                            scatter.symbolChance = scatter.symbolChance / 2;
                            gameInfo.doubleChanceActive = false;
                            Console.WriteLine("Double Chance is now OFF");
                            break;
                        }
                        else if ((input2 == "ON") && (gameInfo.doubleChanceActive == true))
                        {
                            Console.WriteLine("Double Chance is already ON!!!");
                            break;
                        }
                        else if ((input2 == "ON") && (gameInfo.doubleChanceActive == false))
                        {
                            scatter.symbolChance = scatter.symbolChance * 2;
                            gameInfo.doubleChanceActive = true;
                            Console.WriteLine("Double Chance is now ON");
                            break;
                        }
                        else
                        {
                            Console.Write("Set Double Chance (ON / OFF): ");
                            input2 = Console.ReadLine().ToUpper();
                        }
                    }
                }
                else if(input == "buy bonus")
                {
                    if(gameInfo.doubleChanceActive == true)
                    {
                        Console.WriteLine("Disable double chance first!!!");
                    }
                    else
                    {
                        Console.Write($"Are you sure to buy the bonus for {betSize * 100} (YES / NO): ");
                        var input2 = Console.ReadLine().ToUpper();
                        if(input2 == "YES")
                        {
                            gameInfo.bonusGuarantee = true;
                            var startSpin = new StartSpin();
                            startSpin.Start(gameInfo, symbols, multipliers, betSize);
                        }
                    }
                }

                Console.WriteLine();
            }
        }
    }
}
