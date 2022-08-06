using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromptShootingGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GameLoop gameLoop = new GameLoop();
            StartScene startScene = new StartScene();

            // 시작화면
            startScene.Start();

            gameLoop.Awake();
            gameLoop.Start();

            while (true)
            {
                gameLoop.Update();
                gameLoop.Render();
            }
        }
    }
}
