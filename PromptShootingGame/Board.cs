using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromptShootingGame
{
    internal class Board
    {
        #region Member Valiable
        // Member Valable

        int         mapSize_Y =         40;                 // 맵 높이
        int         mapSize_X =         30;                 // 맵 길이


        public      TileType[,]         tile;               // 2차원 배열 tile 선언(맵생성때 미리 할당할 값)
        #endregion

        public int GetMapY() { return mapSize_Y; }          // 읽기 전용 맵 크기 Y,X
        public int GetMapX() { return mapSize_X; }


        public enum TileType                                // 타일타입 정의
        {
            Empty,                                          // 갈 수 있는 타일
            Wall,                                           // 갈 수 없는 타일
        }


        public void Init()
        {
            //Initialize
            tile = new TileType[mapSize_Y, mapSize_X];                          // 맵 크기만큼 이차원 배열 크기 할당.

            for (int y = 0; y < mapSize_Y; y++)
            {
                for (int x = 0; x < mapSize_X; x++)
                {
                    if (x == 0 || x == 30-1|| y == 0 || y == 40-1)
                        tile[y, x] = TileType.Wall;                            // 가장 자리의 타일들을 벽으로 정의
                    else
                        tile[y, x] = TileType.Empty;                           // 가장 자리가 아닌 타일들은 갈 수 있는 곳으로 정의
                }
            }

        }


        public ConsoleColor GetTileColor(TileType type)
        {
            switch (type)
            {
                case TileType.Empty:                            // 갈 수 있는 곳이면 검은색 리턴
                    return ConsoleColor.Black;
                case TileType.Wall:                             // 갈 수 없는 벽이면 청록색 리턴
                    return ConsoleColor.Cyan;
                default:                                        // 디폴트는 검은색 리턴
                    return ConsoleColor.Black;
            }
        }



    }
}
