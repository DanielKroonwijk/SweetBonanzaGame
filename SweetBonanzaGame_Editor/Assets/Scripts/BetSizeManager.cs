using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class BetSizeManager : MonoBehaviour
    {
        public Text betSizeText;
        private bool m_Switch = false;

        private void Start()
        {
            GameLibrary.betSizes = new double[] {
                0.20, 0.40, 0.60, 0.80, 1.00, 1.20, 1.40, 1.60, 1.80, 2.00, 2.40, 3.00,
                3.60, 4.00, 4.20, 4.80, 5.40, 6.00, 8.00, 10.00, 12.00, 14.00, 16.00,
                18.00, 20.00, 24.00, 30.00, 36.00, 42.00, 48.00, 50.00, 54.00, 60.00,
                70.00, 80.00, 90.00, 100.00, 120.00, 140.00, 150.00, 160.00, 180.00,
                200.00, 250.00, 300.00, 350.00, 400.00, 450.00, 500.00, 1000.00 };

            GameLibrary.betSizeID = 4;
            }

        public void UpBetSize()
        {
            if ((GameLibrary.betSizeID != GameLibrary.betSizes.Length - 1) && (GameLibrary.spinActive != true))
            {
                GameLibrary.betSizeID++;
                if (GameLibrary.doubleChanceON == false)
                {
                    betSizeText.text = $"$ {GameLibrary.betSizes[GameLibrary.betSizeID]:0.00}";
                }
                else
                {
                    betSizeText.text = $"$ {GameLibrary.betSizes[GameLibrary.betSizeID] * 1.25:0.00}";
                }
            }
        }

        public void DownBetSize()
        {
            if((GameLibrary.betSizeID != 0) && (GameLibrary.spinActive != true))
            {
                GameLibrary.betSizeID--;
                if (GameLibrary.doubleChanceON == false)
                {
                    betSizeText.text = $"$ {GameLibrary.betSizes[GameLibrary.betSizeID]:0.00}";
                }
                else
                {
                    betSizeText.text = $"$ {GameLibrary.betSizes[GameLibrary.betSizeID] * 1.25:0.00}";
                }
            }
        }

        public void UpdateBetSize()
        {
            if(m_Switch == false)
            {
                m_Switch = true;
                betSizeText.text = $"$ {GameLibrary.betSizes[GameLibrary.betSizeID] * 1.25:0.00}";
            }
            else
            {
                m_Switch = false;
                betSizeText.text = $"$ {GameLibrary.betSizes[GameLibrary.betSizeID]:0.00}";
            }
        }
    }
}
