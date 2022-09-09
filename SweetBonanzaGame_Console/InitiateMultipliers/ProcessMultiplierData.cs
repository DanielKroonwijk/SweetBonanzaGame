using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitiateMultiplier
{
    public class ProcessMultiplierData
    {

        public List<string[]> Process(List<string> multiplierReadLineData)
        {
            var orderedMultiplierData = new List<string[]>();
            for(int i = 0; i < multiplierReadLineData.Count; i++)
            {
                var orderedReadLine = multiplierReadLineData[i].Split('|');
                orderedMultiplierData.Add(orderedReadLine);
            }

            return orderedMultiplierData;
        }

    }
}
