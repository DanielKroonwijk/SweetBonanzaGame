using System;
using System.Collections.Generic;
using System.Text;
using Information;
using InitiateSymbols;
using InitiateBoard;

namespace SweetBonanzaGame
{
    public class CalculatePayouts
    {

        public double Calculate(Symbol symbol, int amounOfSymbol, double betSize)
        {
            var symbolPayouts = symbol.symbolPayouts;
            if (symbol.symbolName == "scatter")
            {
                if (amounOfSymbol == 4)
                {
                    return symbolPayouts[0] * betSize / 100;
                }
                else if (amounOfSymbol == 5)
                {
                    return symbolPayouts[1] * betSize / 100;
                }
                else
                {
                    return symbolPayouts[2] * betSize / 100;
                }
            }
            else
            {
                if ((amounOfSymbol >= 8) && (amounOfSymbol <= 9))
                {
                    return symbolPayouts[0] * betSize / 100;
                }
                else if ((amounOfSymbol >= 10) && (amounOfSymbol <= 11))
                {
                    return symbolPayouts[1] * betSize / 100;
                }
                else
                {
                    return symbolPayouts[2] * betSize / 100;
                }
            }
        }

    }
}
