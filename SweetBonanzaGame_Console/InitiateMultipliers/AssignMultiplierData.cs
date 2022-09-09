using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitiateMultiplier
{
    public class AssignMultiplierData
    {

        public Multiplier[] Assign(List<string[]> orderedMultiplierData)
        {
            var multipliers = new Multiplier[orderedMultiplierData.Count];
            for (int i = 0; i < orderedMultiplierData.Count; i++)
            {
                var multiplier = new Multiplier();
                var multiplierData = orderedMultiplierData[i];
                multiplier.multiplierMulti = int.Parse(multiplierData[0]);
                multiplier.multiplierChance = int.Parse(multiplierData[1]);
                multipliers[i] = multiplier;
            }

            return multipliers;
        }

    }
}
