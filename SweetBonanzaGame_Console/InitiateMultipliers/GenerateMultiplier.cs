using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InitiateSymbols;
using Information;
namespace InitiateMultiplier
{
    public class GenerateMultiplier
    {
        public Symbol Generate(GameInfo gameInfo, Multiplier[] multipliers, Symbol unassignedMultiplier)
        {
            int count = 0;
            for(int i = 0; i < multipliers.Length; i++)
            {
                var multiplier = multipliers[i];
                count += multiplier.multiplierChance;
            }

            Random random = new Random();
            var randomNumber = random.Next(0, count - 1);

            var transformNumberInMultiplier = new TransformNumberInMultiplier();
            unassignedMultiplier = transformNumberInMultiplier.Transform(gameInfo, multipliers,unassignedMultiplier, randomNumber);

            return unassignedMultiplier;
        }

    }
}
