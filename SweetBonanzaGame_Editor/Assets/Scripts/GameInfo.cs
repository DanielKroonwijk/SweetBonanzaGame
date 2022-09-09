using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    public class GameInfo
    {
        public string name;
        public int boardRow;
        public int boardColumn;
        public bool bonusActive;
        public int bonusSymbols;
        public int scattersForBonus;
        public bool dropInSymbols;
        public bool bonusGuarantee;
    }

    public class SetGameInfo
    {
        public static GameInfo Set()
        {
            var gameInfo = new GameInfo();
            gameInfo.name = "SweetBonanza";
            gameInfo.boardRow = 6;
            gameInfo.boardColumn = 5;
            gameInfo.bonusActive = false;
            gameInfo.bonusSymbols = 1;
            gameInfo.dropInSymbols = true;
            gameInfo.scattersForBonus = 4;

            return gameInfo;
        }
    }
}
