using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Information;

namespace InitiateSymbols
{
    public class GetSymbolData
    {

        public List<string> Read(GameInfo gameInfo)
        {
            var symbolReadLineData = new List<string>();
            var reader = new StreamReader($"{gameInfo.name}-SymbolsData.txt");
            while(reader.EndOfStream == false)
            {
                symbolReadLineData.Add(reader.ReadLine());
            }

            reader.Close();
            return symbolReadLineData;
        }

    }
}
