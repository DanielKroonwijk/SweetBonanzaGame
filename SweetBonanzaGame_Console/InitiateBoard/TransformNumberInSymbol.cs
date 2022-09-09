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
    public class TransformNumberInSymbol
    {

        public Symbol Transform(GameInfo gameinfo, Symbol[] symbols, Multiplier[] multipliers, int gameBoardNumber)
        {
            Symbol numberInSymbol = new Symbol();
            int lastHighestNumber = 0;
            for (int i = 0; i < symbols.Length; i++)
            {
                var symbol = symbols[i];
                if((gameBoardNumber >= lastHighestNumber)&&(gameBoardNumber <= symbol.symbolChance + lastHighestNumber - 1))
                {
                    numberInSymbol = symbols[i];
                    lastHighestNumber += symbol.symbolChance;
                    if (numberInSymbol.symbolName == "Multiplier")
                    {
                        var generateMultiplier = new GenerateMultiplier();
                        numberInSymbol = generateMultiplier.Generate(gameinfo, multipliers, symbols[i]);
                    }
                }
                else
                {
                    lastHighestNumber += symbol.symbolChance;
                }
            }

            return numberInSymbol;
        }

    }
}
