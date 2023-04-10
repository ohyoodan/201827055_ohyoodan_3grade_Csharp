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
        // 공통 데이터
        //===================================================================
        static private int PlayerPos;
        static public int  playerPos { get { return PlayerPos; } set { PlayerPos = value; } }
        static private int EnemyPos;
        static public int enemyPos { get { return EnemyPos; } set { EnemyPos = value; } }
        static private int Mapsize_row;// 맵의 행
        static public int mapsize_row { get { return Mapsize_row; } set { Mapsize_row = value; } }
        static private int Mapsize_col;// 맵의 열
        static public int mapsize_col { get { return Mapsize_col; } set { Mapsize_col = value; } }

        static public bool isRunning = false;

        static public string Input;

        static public Queue<int> Rock= new Queue<int>();//돌 맹 이
        //===================================================================



        Tree Tree;
        Thread thread;
        Map map = new Map();//Render용 맵
        
        MapSetting setting;
        Input_Key Input_Key = new Input_Key();
        private int[] MapData = new int[100]; //실제 맵 데이터
        
        int[] vis;
        bool startFirst = true;
        string s;



        public void Start()
            {
                // 게임 루프가 이미 실행 중인 경우
                if (GameLoop.isRunning)
                {
                    return;
                }

            GameLoop.isRunning = true;

            // 게임 루프를 실행할 스레드 생성
            thread=new Thread(GameLoop_Run);
            thread.Start();
            
            }

        static public void Stop()
            {
            GameLoop.isRunning = false;
            }

         private void GameLoop_Run()
            {

                Init();
                while (GameLoop.isRunning)
                {
                // 게임 루프 코드 작성
                input();  if (!GameLoop.isRunning) { break; }
                Update(); if (!GameLoop.isRunning) { break; }
                Render(); if (!GameLoop.isRunning) { break; }
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

                GameLoop.Input=Input_Key.Input_KeyRead();
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
                if (GameLoop.Input==null)
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
                switch (GameLoop.Input)
                {
                    case "1": s="적의 경로를 출력합니다."; break;
                    case "2": s="넘어가기"; break;
                    default:  s = "오류"; break;
                }

                Console.ForegroundColor = ConsoleColor.Green;//색상
                Console.WriteLine("Update");
                if (GameLoop.Input=="1")
                {   
                    Tree=new Tree();
                    //Tree.BFS(GameLoop.enemyPos);
                    vis=Tree.Out();
                    map.Seach(ref vis);
                }                
                Console.ResetColor();


            }
            
        }

         void Init()
        {   setting = new MapSetting();
            setting.MapSetting2();
            
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
