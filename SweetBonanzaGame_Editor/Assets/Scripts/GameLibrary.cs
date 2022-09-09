using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public static class GameLibrary
    {
        public static GameInfo gameInfo;
        public static GameObject[] gameObjects;
        public static Symbol[] symbols;
        public static Symbol[,] gameBoard;
        public static Multiplier[] multipliers;
        public static Vector3[,] spawnVector;
        public static Vector3[,] onBoardVector;
        public static double[] betSizes;
        public static List<List<int>> rowGameObjectsID = new List<List<int>>();

        public static List<int> addGameObjectID = new List<int>();
        public static List<int> removeGameObjectID = new List<int>();
        public static List<Symbol> removeSymbols = new List<Symbol>();
        public static Vector3[] symbolStopPosition = new Vector3[30];
        public static int gameObjectID = 0;
        public static int newGameObjectID = -1;
        public static int chanceGameObjectID = -1;
        public static int rowID = 0;
        public static double totalWin = 0.00;
        public static double tumbleWin = 0.00;
        public static bool allgameObjectsAssigned = false;
        public static bool gameStartBoard = true;
        public static bool firstPartDone = false;
        public static bool spinActive = false;
        public static bool newSpin = true;
        public static bool reAssignGameObjectID = false;
        public static bool destroySymbols = false;
        public static bool addSymbols = false;
        public static bool assignNewSymbolID = false;
        public static bool allNewSymbolsAssigned = false;
        public static bool startBonus = false;

        public static int betSizeID;
        public static double balance = 100000.00;
        public static bool doubleChanceON = false;
    } 
}
