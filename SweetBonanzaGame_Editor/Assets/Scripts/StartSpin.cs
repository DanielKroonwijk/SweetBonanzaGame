using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    class StartSpin : MonoBehaviour
    {
        public Text WinText;
        public Text balanceText;
        private bool m_SecondPartDone = false;
        private bool m_ThirdPartDone = false;
        private bool m_RestartLoop = false;

        public void OnButtonClick()
        {
            if (GameLibrary.spinActive == false)
            {
                GameLibrary.spinActive = true;
                GameLibrary.gameObjectID = 0;
                GameLibrary.totalWin = 0.00;
                GameLibrary.newSpin = true;
                if (GameLibrary.doubleChanceON == false)
                {
                    GameLibrary.balance -= GameLibrary.betSizes[GameLibrary.betSizeID];
                }
                else
                {
                    GameLibrary.balance -= GameLibrary.betSizes[GameLibrary.betSizeID] * 1.25;
                }
                balanceText.text = $"$ {GameLibrary.balance:0.00}";
                WinText.text = $"$ {GameLibrary.totalWin:0.00}";


                var initGameBoard = new GenerateNewBoard();
                initGameBoard.Generate(out GameLibrary.gameBoard);
                for (int row = 0; row < GameLibrary.gameInfo.boardRow; row++)
                {
                    for (int column = GameLibrary.gameInfo.boardColumn - 1; column > -1; column--)
                    {
                        Instantiate(
                            GameLibrary.gameBoard[column, row].symbolPrefab,
                            GameLibrary.spawnVector[column, row],
                            GameLibrary.gameObjects[0].transform.rotation);
                    }
                }

                GameLibrary.firstPartDone = true; 
            }
        }

        public void ContinueSpin1()
        {
            if (GameElements.CheckHit() == true)
            {
                GameLibrary.newSpin = false;
                WinText.text = GameElements.CalculateSymbolWin(out GameLibrary.removeSymbols);
                GameElements.RemoveSymbols();
                m_SecondPartDone = true;
            }
            else if (GameElements.CheckScatters(out double scatterWin) == true)
            {
                GameLibrary.totalWin += scatterWin;
                WinText.text = $"$ {GameLibrary.totalWin:0.00}";
                GameLibrary.startBonus = true;
            }
            else
            {
                GameLibrary.spinActive = false;
                GameLibrary.balance += GameLibrary.totalWin;
                balanceText.text = $"$ {GameLibrary.balance:0.00}";
            }
        }

        public void ContinueSpin2()
        {
            GameLibrary.destroySymbols = false;
            GameElements.ReAssignSymbolsID();
            GameLibrary.reAssignGameObjectID = true;
            GameElements.AddNewSymbols();
            GameLibrary.addSymbols = true;
            m_ThirdPartDone = true;
        }

        public void ContinueSpin3()
        {
            GameLibrary.allNewSymbolsAssigned = false;
            GameLibrary.rowID = 0;
            GameLibrary.chanceGameObjectID = -1;
            GameLibrary.newGameObjectID = -1;
            GameLibrary.removeGameObjectID.Clear();
            GameLibrary.addGameObjectID.Clear();
            GameLibrary.removeSymbols.Clear();
            GameLibrary.gameObjectID = 0;
            m_RestartLoop = true;
        }

        void Update()
        {
            if ((GameLibrary.firstPartDone == true) && (GameLibrary.gameObjectID >= 30) && (GameLibrary.gameInfo.bonusActive == false))
            {
                GameLibrary.allgameObjectsAssigned = false;
                GameLibrary.firstPartDone = false;
                GameLibrary.gameObjectID = 0;
                Invoke("ContinueSpin1", 2f);
            }
            else if (m_SecondPartDone == true)
            {
                GameLibrary.destroySymbols = true;
                m_SecondPartDone = false;
                Invoke("ContinueSpin2", 1f);
            }
            else if (m_ThirdPartDone == true)
            {
                m_ThirdPartDone = false;
                Invoke("ContinueSpin3", 2f);
            }
            else if (m_RestartLoop == true)
            {
                m_RestartLoop = false;
                Invoke("ContinueSpin1", 1f);
            }
        }
    }
}
