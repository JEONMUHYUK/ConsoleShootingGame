using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace PromptShootingGame
{
    internal class Score
    {
        //Member Valiable
        int score;
        public void Init() { score = 0; }       // score 초기값

        // 투사체와 적이 충돌하였을 때 스코어 값을 받아서 갱신한다.
        public void SetScore(int score) { this.score += score; }

        public void Render()
        {
            Console.WriteLine($@"            




                                Score : {score}
                                        
                
");
        
        }
    }
}
