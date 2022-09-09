using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitiateSymbols
{
    public class AssignSymbolData
    {

        public Symbol[] Assign(List<string[]> orderedSymbolData)
        {
            var symbols = new Symbol[orderedSymbolData.Count];
            for (int i = 0; i < orderedSymbolData.Count; i++)
            {
                var symbol = new Symbol();
                var symbolData = orderedSymbolData[i];
                symbol.symbolName = symbolData[0].ToString();
                symbol.symbolChance = int.Parse(symbolData[1]);

                var payouts = new double[symbolData.Length - 2];
                for (int p = 0; p < symbolData.Length-2; p++)
                {
                    payouts[p] = double.Parse(symbolData[p + 2].ToString());
                }

                symbol.symbolPayouts = payouts;
                symbols[i] = symbol;
            }

            return symbols;
        }

    }
}
