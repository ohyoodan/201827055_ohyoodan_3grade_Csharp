using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace _5week_Game_seach_Enemy
{
        static class GameLoop
        {
        static private bool isRunning;
        

        static public void Start()
            {
                // 게임 루프가 이미 실행 중인 경우
                if (isRunning)
                {
                    return;
                }

                isRunning = true;

                // 게임 루프를 실행할 스레드 생성

            }

        static public void Stop()
            {
                isRunning = false;
            }

        static private void GameLoop_Run()
            {

                Init();
                while (isRunning)
                {
                // 게임 루프 코드 작성
                input();
                Update();
                Render();
                
                }
            }


        static void input()
        {

        }
        static void Render()
        {

        }
        static void Update()
        {

        }

        static void Init()
        {

        }

    }
   

}
