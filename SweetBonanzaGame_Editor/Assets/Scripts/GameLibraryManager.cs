using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class GameLibraryManager : MonoBehaviour
    {
        public InititiateGameObjects initGameObjects;
        public Text balanceText;

        void Start()
        {
            Time.timeScale = 1.5f;

            balanceText.text = $"$ {GameLibrary.balance:0.00}";

            initGameObjects.Initiate(out GameLibrary.gameObjects);

            GameLibrary.gameInfo = SetGameInfo.Set();

            var vectors = new Vectors();
            vectors.SetSpawn(out GameLibrary.spawnVector);
            vectors.SetOnBoard(out GameLibrary.onBoardVector);

            GameLibrary.symbols = InitiateSymbols.Initiate();
            GameLibrary.multipliers = InitiateMultiplier.Initiate();

            int count = 0;
            for (int row = 0; row < GameLibrary.gameInfo.boardRow; row++)
            {
                var iDList = new List<int>();
                for (int column = GameLibrary.gameInfo.boardColumn -1; column > -1; column--)
                {
                    iDList.Add(count);
                    count++;
                }

                GameLibrary.rowGameObjectsID.Add(iDList);
            }

            var initGameBoard = new GenerateNewBoard();
            initGameBoard.Generate(out GameLibrary.gameBoard);
            while(GameElements.CheckHit() == true) 
            {
                initGameBoard.Generate(out GameLibrary.gameBoard);
            }

            for (int row = 0; row < GameLibrary.gameInfo.boardRow; row++)
            {
                for (int column = GameLibrary.gameInfo.boardColumn - 1; column > -1; column--)
                {
                    Instantiate(
                        GameLibrary.gameBoard[column, row].symbolPrefab,
                        GameLibrary.onBoardVector[column, row],
                        GameLibrary.gameObjects[0].transform.rotation);
                }
            }

            GameLibrary.startBonus = true; //
            GameLibrary.gameStartBoard = false;
        }
    } 
}
