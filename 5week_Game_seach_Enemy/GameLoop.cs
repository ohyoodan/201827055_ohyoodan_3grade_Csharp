using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace _5week_Game_seach_Enemy
{
         class GameLoop
        {
        Tree Tree;
        Thread thread;
        Map map = new Map();
        MapSetting setting;
        Input_Key Input_Key = new Input_Key();
        int[] vis;
        bool startFirst = true;
        string s;
        public void Start()
            {
                // 게임 루프가 이미 실행 중인 경우
                if (GameManager.isRunning)
                {
                    return;
                }

            GameManager.isRunning = true;

            // 게임 루프를 실행할 스레드 생성
            thread=new Thread(GameLoop_Run);
            thread.Start();
            
            }

        static public void Stop()
            {
            GameManager.isRunning = false;
            }

         private void GameLoop_Run()
            {

                Init();
                while (GameManager.isRunning)
                {
                // 게임 루프 코드 작성
                input();  if (!GameManager.isRunning) { break; }
                Update(); if (!GameManager.isRunning) { break; }
                Render(); if (!GameManager.isRunning) { break; }
                }
                shutdown();
            }


         void input()
        {
            if (startFirst)
            {

            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;//색상
                Console.WriteLine("input....");

                Console.ResetColor();

                GameManager.Input=Input_Key.Input_KeyRead();
            }                        
            
        }
         void Render()
        {
            if (startFirst)
            {
                startFirst=false;
            }
            {
                map.Map_out();

                Console.WriteLine("====================================================================");
                if (GameManager.Input==null)
                {
                    
                }
                else
                {
                    Console.WriteLine(s);                    
                }
                
                Console.WriteLine("====================================================================");
                Console.WriteLine("1번 적의 경로를 출력합니다.");
                Console.WriteLine("2번 넘어갑니다.");
                Console.WriteLine("====================================================================");
            }
                          
        }
         void Update()
        {
            if (startFirst)
            {

            }
            else
            {
                switch (GameManager.Input)
                {
                    case "1": s="적의 경로를 출력합니다."; break;
                    case "2": s="넘어가기"; break;
                    default:  s = "오류"; break;
                }

                Console.ForegroundColor = ConsoleColor.Green;//색상
                Console.WriteLine("Update");
                if (GameManager.Input=="1")
                {   
                    Tree=new Tree();
                    //Tree.BFS(GameManager.enemyPos);
                    vis=Tree.Out();
                    map.Seach(ref vis);
                }                
                Console.ResetColor();


            }
            
        }

         void Init()
        {   setting = new MapSetting();
            setting.PosSet();            
            map.MapCreat();
        }

        void Init(int row, int col)
        {   setting= new MapSetting(row,col);
            setting.PosSet();
            map.MapCreat();
        }

      void shutdown()
        {                        
            Console.WriteLine("5초 후에 종료합니다.");
            Thread.Sleep(5000);            
            Environment.Exit(0);
        }



    }
   
    
}
