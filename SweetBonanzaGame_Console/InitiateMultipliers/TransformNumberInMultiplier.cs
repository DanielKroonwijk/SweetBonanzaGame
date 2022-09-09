using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InitiateMultiplier;
using Information;
using InitiateSymbols;

namespace InitiateMultiplier
{
    public class TransformNumberInMultiplier
    {

        public Symbol Transform(GameInfo gameinfo, Multiplier[] multiplier, Symbol symbol, int randomNumber)
        {
            int lastHighestNumber = 0;
            for (int i = 0; i < multiplier.Length; i++)
            {
                var multi = multiplier[i];
                if((randomNumber >= lastHighestNumber)&&(randomNumber <= multi.multiplierChance + lastHighestNumber - 1))
                {
                    symbol.multi = multi.multiplierMulti;
                    lastHighestNumber += multi.multiplierChance;
                }
                else
                {
                    lastHighestNumber += multi.multiplierChance;
                }
            }

            return symbol;
        }

    }
}
