using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromptShootingGame
{
    internal class Player
    {
        #region Member_Valable
        // Member Valiable
        int pos_Y;
        int pos_X;
        int mapSize_X;

        #endregion

        #region Get_Set_Function
        // 플레이어 위치값 읽기전용
        public int GetPosY() { return pos_Y; }
        public int GetPosX() { return pos_X; }
        #endregion

        public void Init(int mapSize_Y, int mapSize_X)
        { 
            //  Initialize
            pos_Y = mapSize_Y - 3;              // 플레이어 초기값
            pos_X = mapSize_X/2;                

            this. mapSize_X = mapSize_X;        // 맵 가로 사이즈
        }

        #region Player_Move_Function
        public void MoveReft()
        { 
            pos_X--;                            // 함수 호출시 플레이어 위치값 x -=1;
            if (pos_X < 1)                      // 위치제한 X가 1보다 작을 때 플레이어 X값 1로 선언
            {
                pos_X = 1;
            }
        }
        public void MoveRight()                 // 함수 호출시 플레이어 위치값 x +=1;
        {
            pos_X++;                            // 위치제한 X가 mapSizeX - 2 보다 작을 때 플레이어 X값 mapSize-2로 선언
            if (pos_X > mapSize_X - 2)
            {
                pos_X = mapSize_X - 2;
            }
        }
        #endregion
        public void Render()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("▲");
            Console.ResetColor();
        }

        


       
    }
}
