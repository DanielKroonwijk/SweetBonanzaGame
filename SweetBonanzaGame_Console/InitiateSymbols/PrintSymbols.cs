using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitiateSymbols
{
    public class PrintSymbols
    {

        public void Print(Symbol[] symbols)
        {
            for(int i = 0; i < symbols.Length; i++)
            {
                var symbol = symbols[i];
                Console.Write($"{symbol.symbolName} --- ");
                Console.Write($"{symbol.symbolChance} --- ");

                var payouts = symbol.symbolPayouts;
                for(int p = 0; p < payouts.Length; p++)
                {
                    Console.Write($"{payouts[p]} --- ");
                }

                Console.WriteLine();
            }
        }

    }
}
