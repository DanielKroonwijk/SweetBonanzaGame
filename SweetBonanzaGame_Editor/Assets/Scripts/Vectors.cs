using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public class Vectors
    {

        public void SetSpawn(out Vector3[,] vectors)
        {
            int i = 0;
            vectors = new Vector3[GameLibrary.gameInfo.boardColumn, GameLibrary.gameInfo.boardRow];
            for(int column = 0; column < GameLibrary.gameInfo.boardColumn; column++)
            {
                for(int row = 0; row < GameLibrary.gameInfo.boardRow; row++)
                {
                    vectors[column, row] = GameObject.Find($"SpawnPoint-{i}").transform.position;
                    i++;
                }
            }
        }

        public void SetOnBoard(out Vector3[,] vectors)
        {
            int i = 0;
            vectors = new Vector3[GameLibrary.gameInfo.boardColumn, GameLibrary.gameInfo.boardRow];
            for (int column = 0; column < GameLibrary.gameInfo.boardColumn; column++)
            {
                for (int row = 0; row < GameLibrary.gameInfo.boardRow; row++)
                {
                    vectors[column, row] = GameObject.Find($"OnBoardPoint-{i}").transform.position;
                    i++;
                }
            }
        }
    }
}
