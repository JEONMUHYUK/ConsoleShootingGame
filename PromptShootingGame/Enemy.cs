using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromptShootingGame
{
    internal class Enemy
    {
        #region Member Valiable
        int     pos_Y;              // 적 위치 Y
        int     pos_X;              // 적 위치 X

        int     mapSize_X;          // 맵 가로크기

        int     sumTick;            // currentTick - lastTick을 더해줄 변수

        bool    isActive;           // 적 활성화 체크

        Random rand;                // 랜덤 변수
        #endregion

        #region Get_Set_Function
        public int GetPosY() { return pos_Y; }                                  // 적 위치값 Y 읽기전용
        public int GetPosX() { return pos_X; }                                  // 적 위치값 X 읽기전용
        public bool GetIsActive() { return isActive; }                          // 적 활성화 읽기전용

        public void SetIsActive(bool isActive) { this.isActive = isActive; }    // 적 활성화 쓰기전용

        #endregion
        public void Init(int mapSize_X)
        { 
            // Initialize
            rand = new Random();                    // 랜덤변수

            this.mapSize_X = mapSize_X;             // 맵 가로크기

            pos_Y = 3;                              // 적 Y 초기값
            pos_X = rand.Next(1, mapSize_X-2);      // 적 X 초기값

            sumTick = 0;                            // currentTick - lastTick을 더해줄 변수
            isActive = true;                        // 적 활성화 초기값
        
        }

        public void Update(int deltaTick)
        {
            sumTick += deltaTick;                       // sumTick에 currntTick - lastTick 값을 다시 쌓아준다.
            if (sumTick > 1000)                         // 쌓아준 값이 1000을 초과할 때만 이동
            {
                if (pos_X > mapSize_X)                  // 적 위치 값 제한
                {
                    pos_X = mapSize_X - 2;
                }
                else if (pos_X < 2)
                {
                    pos_X = 2;
                }
                else pos_X += rand.Next(-1, 2);         // 적 이동값
                sumTick = 0;                            // sumTick 초기화
            }
        }

        public void Render()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("▼");
            Console.ResetColor();
        }

    }
}
