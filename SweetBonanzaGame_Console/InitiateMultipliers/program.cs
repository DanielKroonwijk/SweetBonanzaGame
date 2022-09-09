using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Information;

namespace InitiateMultiplier
{
    public class InitMultipliers
    {
        
        public void Initiate(GameInfo gameInfo, out Multiplier[] multipliers)
        {
            var getMultiplierData = new GetMultiplierData();
            var MultiplierReadLineData = getMultiplierData.Read(gameInfo);

            var proccesMultiplierData = new ProcessMultiplierData();
            var orderedMultiplierData = proccesMultiplierData.Process(MultiplierReadLineData);

            var assignMultiplierData = new AssignMultiplierData();
            multipliers = assignMultiplierData.Assign(orderedMultiplierData);
        }

    }
}
