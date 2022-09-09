using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Information;

namespace InitiateSymbols
{
    public class InitSymbols
    {
        
        public void Initiate(GameInfo gameInfo, out Symbol[] symbols)
        {
            var getSymbolData = new GetSymbolData();
            var symbolReadLineData = getSymbolData.Read(gameInfo);

            var proccesSymbolData = new ProcessSymbolData();
            var orderedSymbolData = proccesSymbolData.Process(symbolReadLineData);

            var assignSymbolData = new AssignSymbolData();
            symbols = assignSymbolData.Assign(orderedSymbolData);

            /*
            var printSymbols = new PrintSymbols();
            printSymbols.Print(symbols);
            */

        }

    }
}
