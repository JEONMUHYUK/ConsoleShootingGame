using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromptShootingGame
{
    internal class GameLoop
    {
        #region
        // Member Valiable

        Board       board;              // 보드 객체
        Player      player;             // 플레이어 객체
        Enemy       enemy;              // 적 객체
        Bullet      bullet0;            // bullet0 객체
        Bullet      bullet1;            // bullet1 객체
        Bullet      bullet2;            // bullet2 객체
        Score       score;              // score 객체

        int         mapSize_Y;          // mapSize
        int         mapSize_X;

        int         lastTick;           // 마지막 시간을 담기위한 변수 fps관리용
        int         bulletCount;        // 불렛 카운트 변수
        #endregion

        // 0. 객체 생성.
        public void Awake()
        {
            // 콘솔창 크기 조절 & 고정
            Console.BufferWidth = Console.WindowWidth = 71;
            Console.BufferHeight = Console.WindowHeight = 71;
            Console.CursorVisible = false;                      // 커서를 안보이게 하는 함수


            board   = new Board();                              // 보드 객체 생성               
            player  = new Player();                             // 플레이어 객체 생성
            enemy   = new Enemy();                              // 적 객체 생성
            score   = new Score();                              // 스코어 객체 생성

            bullet0 = new Bullet();                             // bullets 객체 생성
            bullet1 = new Bullet();
            bullet2 = new Bullet();
        }

        // 1. 초기화
        public void Start()
        {
            mapSize_Y   = 40;                                       // 맵사이즈 초기값
            mapSize_X   = 30;
            bulletCount = 0;                                        // 불렛 카운트 초기값
            lastTick    = 0;                                        // lastTick 초기값

            board.Init();                                           // 보드 객체 초기화
            player.Init(mapSize_Y, mapSize_X);                      // 플레이어 객체 초기화
            enemy.Init(mapSize_X);                                  // 적 객체 초기화
            bullet0.Init(player, score, enemy);                     // bullets 객체 초기화
            bullet1.Init(player, score, enemy);
            bullet2.Init(player, score, enemy);
        }

        // 2. 업데이트
        public void Update()
        {
            #region FpsManager_&_Objects_Update
            int currentTick = Environment.TickCount;                // 환경시간 값.
            if (currentTick - lastTick > 1000/60)                   // 60fps
            {
                int deltaTick = currentTick - lastTick;             // objects에게 전달하기 위한 시간차 

                #region Objects_Move_Update
                enemy.Update(deltaTick);
                bullet0.Update();
                bullet1.Update();
                bullet2.Update();
                #endregion

                if (bulletCount >= 3)                               // 불렛 카운트가 3이상이면 0으로 초기화
                    bulletCount = 0;

                #region Player_Key
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo cki = Console.ReadKey();
                    switch (cki.Key)
                    {
                        case ConsoleKey.LeftArrow:                  // 플레이어 왼쪽이동
                            player.MoveReft();
                            break;
                        case ConsoleKey.RightArrow:                 // 플레이어 오른쪽이동
                            player.MoveRight();
                            break;
                        case ConsoleKey.Spacebar:                   // 플레이어 투사체 발사
                            if (bulletCount == 0)
                            {
                                bullet0.SetIsActive(true);          // 총알 객체
                            }
                            else if (bulletCount == 1)
                            {
                                bullet1.SetIsActive(true);          // 총알 객체
                            }
                            else if (bulletCount == 2)
                            {
                                bullet2.SetIsActive(true);          // 총알 객체
                            }
                            bulletCount++;                          // 스페이스바 입력시 bulletCount 증가
                            
                            break;
                    }
                }

                #endregion

                lastTick = currentTick;
            }
            #endregion
        }

        // 3. 출력
        public void Render()
        {

            Console.SetCursorPosition(0, 0);                        // 커서 고정
            score.Render();                                         // 스코어 출력

            #region Board_Render
            ConsoleColor prevColor = Console.ForegroundColor;
            for (int y = 0; y < mapSize_Y; y++)
            {
                Console.Write("      ");
                for (int x = 0; x < mapSize_X; x++)
                {

                    if (y == player.GetPosY() && x == player.GetPosX())
                    {
                        // 플레이어 출력
                        player.Render();
                    }
                    else if (enemy.GetIsActive() == true && (y == enemy.GetPosY() && x == enemy.GetPosX()))
                    {
                        // 적 출력
                        enemy.Render();
                    }
                    // 불렛 출력
                    else if ((bullet0.GetIsActive() == true && (y == bullet0.GetPosY() && x == bullet0.GetPosX())))
                    {
                        bullet0.Render();
                    }
                    else if ((bullet1.GetIsActive() == true && (y == bullet1.GetPosY() && x == bullet1.GetPosX())))
                    {
                        bullet1.Render();
                    }
                    else if ((bullet2.GetIsActive() == true && (y == bullet2.GetPosY() && x == bullet2.GetPosX())))
                    {
                        bullet2.Render();
                    }
                    else
                    {
                        // 나머지 출력
                        Console.ForegroundColor = board.GetTileColor(board.tile[y, x]);
                        Console.Write('■');

                    }

                }
                Console.WriteLine();
            }
            Console.ForegroundColor = prevColor;
            #endregion


        }
    }
}