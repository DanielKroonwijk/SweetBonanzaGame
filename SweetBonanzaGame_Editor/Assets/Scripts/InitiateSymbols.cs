using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using UnityEngine;

namespace Assets.Scripts
{
    public class Symbol
    {
        public GameObject symbolPrefab;
        public int symbolChance;
        public double[] symbolPayouts;
        public int multi = 0;
    }

    public static class InitiateSymbols
    {
        public static Symbol[] Initiate()
        {
            var symbolReadLineData = Read();
            var orderedSymbolData = Process(symbolReadLineData);
            return Assign(orderedSymbolData);
        }

        public static List<string> Read()
        {
            var symbolReadLineData = new List<string>();
            var reader = new StreamReader($"{GameLibrary.gameInfo.name}-SymbolsData.txt");
            while (reader.EndOfStream == false)
            {
                symbolReadLineData.Add(reader.ReadLine());
            }

            reader.Close();
            return symbolReadLineData;
        }

        public static List<string[]> Process(List<string> symbolReadLineData)
        {
            var orderedSymbolData = new List<string[]>();
            for (int i = 0; i < symbolReadLineData.Count; i++)
            {
                var orderedReadLine = symbolReadLineData[i].Split('|');
                orderedSymbolData.Add(orderedReadLine);
            }

            return orderedSymbolData;
        }

        public static Symbol[] Assign(List<string[]> orderedSymbolData)
        {
            var symbols = new Symbol[orderedSymbolData.Count];
            for (int i = 0; i < orderedSymbolData.Count; i++)
            {
                var symbol = new Symbol();
                var symbolData = orderedSymbolData[i];
                symbol.symbolPrefab = GameLibrary.gameObjects[i];
                symbol.symbolChance = int.Parse(symbolData[1]);

                var payouts = new double[symbolData.Length - 2];
                for (int p = 0; p < symbolData.Length - 2; p++)
                {
                    payouts[p] = double.Parse(symbolData[p + 2].ToString());
                }

                symbol.symbolPayouts = payouts;
                symbols[i] = symbol;
            }

            return symbols;
        }
    }
}
