using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class StartBonus : MonoBehaviour
    {
        public Text WinText;
        public Text balanceText;
        public Text freeSpinsLeft;
        public Text tumbleWinText;
        public GameObject bonusAlert;
        public GameObject bonusSummary;
        public GameObject buyBonusBuyButton;
        public GameObject doubleChanceButton;
        public GameObject startSpinButton;
        public GameObject downBetsizeButton;
        public GameObject upBetSizeButton;

        private int m_SpinsLeft = 0;
        private bool m_WaitingForClick1 = false;
        private bool m_WaitingForClick2 = false;
        private bool m_WaitingForClick3 = false;
        private bool m_WaitingForClick4 = false;
        private bool m_SecondPartDone = false;
        private bool m_ThirdPartDone = false;
        private bool m_RestartLoop = false;

        public void SetupBonus()
        {
            buyBonusBuyButton.GetComponent<Button>().enabled = false;
            doubleChanceButton.GetComponent<Button>().enabled = false;
            startSpinButton.GetComponent<Button>().enabled = false;
            upBetSizeButton.GetComponent<Button>().enabled = false;
            downBetsizeButton.GetComponent<Button>().enabled = false;

            GameLibrary.gameObjectID = 0;
            m_SpinsLeft = 10;

            bonusAlert.GetComponent<MeshRenderer>().enabled = true;
            m_WaitingForClick1 = true;
        }

        public void ContinueBonus1()
        {
            if (m_SpinsLeft != 0)
            {
                m_SpinsLeft--;
                GameLibrary.newSpin = true;
                GameLibrary.gameObjectID = 0;
                GameLibrary.tumbleWin = 0;
                tumbleWinText.text = $"$ {GameLibrary.tumbleWin:0.00}";

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
            else
            {
                bonusSummary.GetComponent<MeshRenderer>().enabled = true;
                m_WaitingForClick4 = true;
            }
        }

        public void ContinueBonus2()
        {
            if (GameElements.CheckHit() == true)
            {
                GameLibrary.newSpin = false;
                tumbleWinText.text = GameElements.CalculateSymbolWin(out GameLibrary.removeSymbols);
                GameElements.RemoveSymbols();
                m_SecondPartDone = true;
            }
            else 
            {
                if (GameLibrary.tumbleWin > 0)
                {
                    GameElements.ApplyMultiplier();
                    GameLibrary.totalWin += GameLibrary.tumbleWin;
                    WinText.text = $"$ {GameLibrary.totalWin:0.00}";
                }
                if (GameElements.CheckIfBonusRetriggers() == true)
                {
                    WinText.text = $"$ {GameLibrary.totalWin:0.00}";
                    m_SpinsLeft += 5;
                    bonusAlert.GetComponent<MeshRenderer>().enabled = true;
                    m_WaitingForClick3 = true;

                }
                else
                {
                    Invoke("ContinueBonus1", 2f);
                }
            }
        }

        public void ContinueBonus3()
        {
            GameLibrary.destroySymbols = false;
            GameElements.ReAssignSymbolsID();
            GameLibrary.reAssignGameObjectID = true;
            GameElements.AddNewSymbols();
            GameLibrary.addSymbols = true;
            m_ThirdPartDone = true;
        }

        public void ContinueBonus4()
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

        private void Update()
        {
            if (GameLibrary.gameInfo.bonusActive == true)
            {
                freeSpinsLeft.text = $"{m_SpinsLeft} free spins left";
            }
            else
            {
                freeSpinsLeft.text = "";
            }

            if ((GameLibrary.gameInfo.bonusActive == true) && (GameLibrary.startBonus == true))
            {
                GameLibrary.startBonus = false;
                Invoke("SetupBonus", 3f);
            }
            else if ((m_WaitingForClick1 == true) && (Input.GetMouseButtonDown(0)))
            {
                m_WaitingForClick1 = false;
                Invoke("ContinueBonus1", 1f);
                bonusAlert.GetComponent<MeshRenderer>().enabled = false;
            }
            else if ((m_WaitingForClick2 == true) && (Input.GetMouseButtonDown(0)))
            {
                GameLibrary.spinActive = false;
                GameLibrary.balance += GameLibrary.totalWin;
                balanceText.text = $"$ {GameLibrary.balance:0.00}";
            }
            else if ((m_WaitingForClick3 == true) && (Input.GetMouseButtonDown(0)))
            {
                Invoke("ContinueBonus1", 4f);
                bonusAlert.GetComponent<MeshRenderer>().enabled = false;
            }
            else if ((m_WaitingForClick4 == true) && (Input.GetMouseButtonDown(0)))
            {
                m_WaitingForClick4 = false;
                GameLibrary.balance += GameLibrary.totalWin;
                balanceText.text = $"$ {GameLibrary.balance:0.00}";
                bonusSummary.GetComponent<MeshRenderer>().enabled = false;
                buyBonusBuyButton.GetComponent<Button>().enabled = true;
                doubleChanceButton.GetComponent<Button>().enabled = true;
                startSpinButton.GetComponent<Button>().enabled = true;
                upBetSizeButton.GetComponent<Button>().enabled = true;
                downBetsizeButton.GetComponent<Button>().enabled = true;
                GameLibrary.gameInfo.bonusActive = false;
                GameLibrary.spinActive = false;
            }
            else if ((GameLibrary.firstPartDone == true) && (GameLibrary.gameObjectID == 5 * 6) && (GameLibrary.gameInfo.bonusActive == true))
            {
                GameLibrary.allgameObjectsAssigned = false;
                GameLibrary.firstPartDone = false;
                GameLibrary.gameObjectID = 0;
                Invoke("ContinueBonus2", 2f);
            }
            else if (m_SecondPartDone == true)
            {
                GameLibrary.destroySymbols = true;
                m_SecondPartDone = false;
                Invoke("ContinueBonus3", 1f);
            }
            else if (m_ThirdPartDone == true)
            {
                m_ThirdPartDone = false;
                Invoke("ContinueBonus4", 4f);
            }
            else if (m_RestartLoop == true)
            {
                m_RestartLoop = false;
                Invoke("ContinueBonus2", 1f);
            }
        }
    }
}

