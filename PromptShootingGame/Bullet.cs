using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromptShootingGame
{
    internal class Bullet
    {
        #region Member Valiable
        Score       score;          // 스코어 객체
        Enemy       enemy;          // 적 객체
        Player      player;         // 플레이어 객체

        int         pos_Y;          // bulletPosY
        int         pos_X;          // bulletPosX

        bool        isActive;       // 활성화 체크
        #endregion

        #region Get_Set_Functions
        public int GetPosY() { return pos_Y; }                                  // bulletPosY 읽기전용          
        public int GetPosX() { return pos_X; }                                  // bulletPosX 읽기전용
        public bool GetIsActive() { return isActive; }                          // isActive 읽기전용
        public void SetIsActive(bool isActive) { this.isActive = isActive; }    // isActive 쓰기전용              
        #endregion

        
        public void Init(Player player, Score score, Enemy enemy)
        {
            //Initialize
            this.player     = player;               // 플레이어 객체

            pos_Y           = player.GetPosY();     // 플레이어 위치값을 가쳐와 불렛의 초기값을 갖는다.
            pos_X           = player.GetPosX();     

            this.score      = score;                // 스코어 객체
            this.enemy      = enemy;                // 적 객체

            isActive        = false;                // isActive는 false로 default
        }

        public void Update()
        {
            if (!isActive)
            { 
                // !isActive 일때 플레이어x값 추적
                pos_X = player.GetPosX();                               // isActive = false일때 x값을 플레이어x값과 맞춰준다.
            }
            else
            {   
                --pos_Y;                                                //isActive = true 일때 y값 감소

                // 불렛 위치 제한
                if (pos_Y <= 1)
                { 
                    isActive = false;                                   // 총알이 y >=1이 된다면 isActive = false
                    Init(player, score, enemy);                         // 다시 초기화 시켜준다.
                }
            }

            #region bullet_&_Enemy_collision_determination
            // 투사체와 적의 충돌 판정
            if (pos_Y == enemy.GetPosY() &&
                (pos_X == enemy.GetPosX()))
            {
                // 적과 불렛이 충돌한다면 점수 100 올리고 적 출력 삭제후 다시 생성
                score.SetScore(100);
                isActive = false;
                enemy.SetIsActive(false);
                enemy.Init(30);
                enemy.SetIsActive(true);
            }
            #endregion
        }

        public void Render()
        {
            if (!isActive) return;                                      // isActive가 false이면 출력하지 않는다.
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("＊");
            Console.ResetColor();
        }
    }
}
