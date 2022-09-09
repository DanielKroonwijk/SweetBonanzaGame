using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Information;

namespace InitiateMultiplier
{
    public class GetMultiplierData
    {

        public List<string> Read(GameInfo gameInfo)
        {
            var multiplierReadLineData = new List<string>();
            var reader = new StreamReader($"{gameInfo.name}-MultiplierData.txt");
            while(reader.EndOfStream == false)
            {
                multiplierReadLineData.Add(reader.ReadLine());
            }

            reader.Close();
            return multiplierReadLineData;
        }

    }
}
