using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public class SymbolController : MonoBehaviour
    {
        private GameObject m_GameObjectOld;
        private GameObject m_GameObjectNew;
        private int m_Count = 1;
        private bool m_Busy = false;

        private void Update()
        {
            if ((GameLibrary.allgameObjectsAssigned == true) && (m_Busy != true))
            {
                m_GameObjectNew = GameObject.Find($"TargetGameObject{GameLibrary.gameObjectID}");
                m_GameObjectOld = GameObject.Find($"TargetGameObject{GameLibrary.gameObjectID + 100}");

                if ((m_GameObjectNew != null) && (m_GameObjectOld != null) && (m_GameObjectNew.GetComponent<Rigidbody2D>() == null) && (m_GameObjectOld.GetComponent<Rigidbody2D>() == null))
                {
                    m_Busy = true;
                    GameLibrary.symbolStopPosition[GameLibrary.gameObjectID] = m_GameObjectOld.transform.position;
                    GameLibrary.gameObjectID++;

                    m_GameObjectOld.AddComponent<Rigidbody2D>();
                    m_GameObjectNew.AddComponent<Rigidbody2D>();
                }
            }
            else if ((GameLibrary.allNewSymbolsAssigned == true) && (m_Busy != true))
            {
                m_GameObjectNew = GameObject.Find($"TargetGameObject{GameLibrary.gameObjectID}");

                if ((m_GameObjectNew != null) && (m_GameObjectNew.GetComponent<Rigidbody2D>() == null) && (m_GameObjectNew.transform.position.y > GameLibrary.symbolStopPosition[GameLibrary.gameObjectID].y))
                {
                    m_Busy = true;
                    GameLibrary.gameObjectID++;

                    m_GameObjectNew.AddComponent<Rigidbody2D>();
                }
                else if ((m_GameObjectNew != null) && (m_GameObjectNew.transform.position.y <= GameLibrary.symbolStopPosition[GameLibrary.gameObjectID].y))
                {
                    m_Busy = true;
                    GameLibrary.gameObjectID++;
                }
            }
            else if (GameLibrary.reAssignGameObjectID == true)
            {
                var newGameObject = GameObject.Find($"TargetGameObject{GameLibrary.gameObjectID}");
                if ((newGameObject == null) && (GameLibrary.rowID != 6))
                {
                    GameLibrary.newGameObjectID = GameLibrary.gameObjectID;
                    var chanceGameObject = GameObject.Find($"TargetGameObject{GameLibrary.gameObjectID + m_Count}");
                    if ((chanceGameObject != null) && (GameLibrary.rowGameObjectsID[GameLibrary.rowID].Contains(GameLibrary.gameObjectID + m_Count) == true))
                    {
                        GameLibrary.chanceGameObjectID = GameLibrary.gameObjectID + m_Count;
                    }
                    else
                    {
                        m_Count++;
                    }

                    if ((GameLibrary.rowGameObjectsID[GameLibrary.rowID].Contains(GameLibrary.gameObjectID + m_Count) == false))
                    {
                        m_Count = 1;
                        GameLibrary.rowID++;
                        if (GameLibrary.rowID != 6)
                        {
                            var rowIDs = GameLibrary.rowGameObjectsID[GameLibrary.rowID];
                            GameLibrary.gameObjectID = rowIDs[0];
                        }
                    }
                }
                else if (GameLibrary.rowID == 6)
                {
                    GameLibrary.reAssignGameObjectID = false;
                    GameLibrary.gameObjectID = 0;
                }
                else
                {
                    m_Count = 1;
                    GameLibrary.gameObjectID++;
                }
            }
            else if ((GameLibrary.addSymbols == true) && (m_Busy != true))
            {
                m_Busy = true;
                int count = 0;
                int spawnColumn;
                GameLibrary.newGameObjectID = 0;
                GameLibrary.assignNewSymbolID = true;
                for (int row = 0; row < GameLibrary.gameInfo.boardRow; row++)
                {
                    spawnColumn = GameLibrary.gameInfo.boardColumn - 1;
                    for (int column = GameLibrary.gameInfo.boardColumn - 1; column > -1; column--)
                    {
                        var newGameObject = GameObject.Find($"TargetGameObject{GameLibrary.gameObjectID}");
                        if (newGameObject == null)
                        {
                            GameLibrary.addGameObjectID.Add(count);

                            Instantiate(
                                GameLibrary.gameBoard[column, row].symbolPrefab,
                                GameLibrary.spawnVector[spawnColumn, row],
                                GameLibrary.gameObjects[0].transform.rotation);

                            spawnColumn--;
                        }
                        GameLibrary.gameObjectID++;
                        count++;
                    }
                }
                GameLibrary.gameObjectID = 0;
                GameLibrary.addSymbols = false;
            } 

            m_Busy = false;
        }  
    }
}
