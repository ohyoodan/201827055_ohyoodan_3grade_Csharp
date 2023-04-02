using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace _5week_Game_seach_Enemy
{
         class GameLoop
        {
        static private bool isRunning=false;
        Map map = new Map();

         public void Start()
            {
                // 게임 루프가 이미 실행 중인 경우
                if (isRunning)
                {
                    return;
                }

                isRunning = true;

            // 게임 루프를 실행할 스레드 생성
            Thread thread=new Thread(GameLoop_Run);
            thread.Start();

            }

        static public void Stop()
            {
                isRunning = false;
            }

         private void GameLoop_Run()
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


         void input()
        {
            Console.ForegroundColor = ConsoleColor.Green;//색상
            Console.WriteLine("input....");
            Console.ResetColor();
            Thread.Sleep(2000);
        }
         void Render()
        {
            map.Map_out();                  
        }
         void Update()
        {
            Console.ForegroundColor = ConsoleColor.Green;//색상
            Console.WriteLine("Update");
            Console.ResetColor();
        }

         void Init()
        {map.MapCreat();
           
        }

        void shutdown()
        {

        }

    }
   
    
}
