using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Assets.Scripts
{
    public class Multiplier
    {
        public int multiplierMulti;
        public int multiplierChance;
    }

    public static class InitiateMultiplier
    {
        public static Multiplier[] Initiate()
        {
            var MultiplierReadLineData = Read();
            var orderedMultiplierData = Process(MultiplierReadLineData);
            return Assign(orderedMultiplierData);
        }

        public static List<string> Read()
        {
            var multiplierReadLineData = new List<string>();
            var reader = new StreamReader($"{GameLibrary.gameInfo.name}-MultiplierData.txt");
            while (reader.EndOfStream == false)
            {
                multiplierReadLineData.Add(reader.ReadLine());
            }

            reader.Close();
            return multiplierReadLineData;
        }

        public static List<string[]> Process(List<string> multiplierReadLineData)
        {
            var orderedMultiplierData = new List<string[]>();
            for (int i = 0; i < multiplierReadLineData.Count; i++)
            {
                var orderedReadLine = multiplierReadLineData[i].Split('|');
                orderedMultiplierData.Add(orderedReadLine);
            }

            return orderedMultiplierData;
        }

        public static Multiplier[] Assign(List<string[]> orderedMultiplierData)
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
