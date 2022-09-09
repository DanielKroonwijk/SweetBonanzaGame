using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts 
{
    public class DoubleChanceButton : MonoBehaviour 
    {

        public Material doubleChanceMaterial;
        private bool m_Switch = false;

        private void Start()
        {
            doubleChanceMaterial.color = Color.green;
        }

        public void DoubleChance()
        {
            if(m_Switch == false)
            {
                m_Switch = true;
                GameLibrary.symbols[0].symbolChance *= 2;
                doubleChanceMaterial.color = Color.red;
                GameLibrary.doubleChanceON = true;
                
            }
            else if(m_Switch == true)
            {
                m_Switch = false;
                GameLibrary.symbols[0].symbolChance /= 2;
                doubleChanceMaterial.color = Color.green;
                GameLibrary.doubleChanceON = false;
            }
        }

        private void OnApplicationQuit()
        {
            if(m_Switch == true)
            {
                DoubleChance();
            }
        }
    }
}
