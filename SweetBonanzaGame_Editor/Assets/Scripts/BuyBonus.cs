using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace Assets.Scripts
{
    public class BuyBonus : MonoBehaviour
    {
        public GameObject confirmBuyBonus;
        public GameObject yesButton;
        public GameObject noButton;
        public GameObject yesGameObject;
        public GameObject noGameObject;
        public Text WinText;
        public Text balanceText;

        public void OnBuyButtonClick()
        {
            if (GameLibrary.doubleChanceON == false)
            {
                confirmBuyBonus.GetComponent<MeshRenderer>().enabled = true;
                yesButton.GetComponent<Button>().enabled = true;
                noButton.GetComponent<Button>().enabled = true;
                yesGameObject.GetComponent<MeshRenderer>().enabled = true;
                noGameObject.GetComponent<MeshRenderer>().enabled = true;
            }
        }

        public void OnYesClick()
        {
            confirmBuyBonus.GetComponent<MeshRenderer>().enabled = false;
            yesButton.GetComponent<Button>().enabled = false;
            noButton.GetComponent<Button>().enabled = false;
            yesGameObject.GetComponent<MeshRenderer>().enabled = false;
            noGameObject.GetComponent<MeshRenderer>().enabled = false;

            GameLibrary.spinActive = true;
            GameLibrary.gameObjectID = 0;
            GameLibrary.totalWin = 0.00;
            GameLibrary.newSpin = true;
            if (GameLibrary.doubleChanceON == false)
            {
                GameLibrary.balance -= GameLibrary.betSizes[GameLibrary.betSizeID] * 100;
            }
            balanceText.text = $"$ {GameLibrary.balance:0.00}";
            WinText.text = $"$ {GameLibrary.totalWin:0.00}";

            GameLibrary.gameBoard = GameElements.BonusGuarantee();
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

        public void OnNoClick()
        {
            confirmBuyBonus.GetComponent<MeshRenderer>().enabled = false;
            yesButton.GetComponent<Button>().enabled = false;
            noButton.GetComponent<Button>().enabled = false;
            yesGameObject.GetComponent<MeshRenderer>().enabled = false;
            noGameObject.GetComponent<MeshRenderer>().enabled = false;
        }
    }
}
