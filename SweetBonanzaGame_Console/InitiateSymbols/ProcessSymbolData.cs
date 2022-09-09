using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitiateSymbols
{
    public class ProcessSymbolData
    {

        public List<string[]> Process(List<string> symbolReadLineData)
        {
            var orderedSymbolData = new List<string[]>();
            for(int i = 0; i < symbolReadLineData.Count; i++)
            {
                var orderedReadLine = symbolReadLineData[i].Split('|');
                orderedSymbolData.Add(orderedReadLine);
            }

            return orderedSymbolData;
        }

    }
}
