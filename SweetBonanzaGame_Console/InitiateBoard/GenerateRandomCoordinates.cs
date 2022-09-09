using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Information;

namespace InitiateBoard
{
    class GenerateRandomCoordinates
    {

        public int[] Generate(GameInfo gameInfo, List<int[]> usedCoordinates) 
        {
            int[] coordinates = new int[2];
            bool coordinatesContainScatter = true;
            while (coordinatesContainScatter == true)
            {
                Random random = new Random();
                coordinates[0] = random.Next(0, gameInfo.boardColumn);
                coordinates[1] = random.Next(0, gameInfo.boardRow);

                int count = 0;
                for (int i = 0; i < usedCoordinates.Count; i++)
                {
                    if ((usedCoordinates[i][0] == coordinates[0]) && (usedCoordinates[i][1] == coordinates[1]))
                    {
                        break;
                    }
                    else
                    {
                        count++;
                    }
                }
                if(count == usedCoordinates.Count)
                {
                    coordinatesContainScatter = false;
                }
            }

            return coordinates;
        } 

    }
}
