﻿using System;
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

        static public string InputData;
        //===================================================================



        Graph Graph;//맵 데이터 그래프화
        Thread thread;
        Map map = new Map();//Render용 맵
        
        MapSetting setting;
        Input_Key Input_Key = new Input_Key();
        private int[] MapData; //실제 맵 데이터
        static public int[] vis;//최단거리
        
        bool startFirst = true;// 처음 시작
        string s;//임시 문자열



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

            public void Stop()
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

                GameLoop.InputData=Input_Key.Input_KeyRead();
            }                        
            
        }
         void Render()
        {
            if (startFirst)
            {
                startFirst=false;
            }
            {
                if (GameLoop.InputData=="1") 
                {
                    map.Map_out(MapData, vis);
                }
                else
                {
                    map.Map_out(MapData);
                }
                

                Console.WriteLine("====================================================================");
                if (GameLoop.InputData==null)
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
                switch (GameLoop.InputData)
                {
                    case "1": s="적의 경로를 출력합니다."; break;
                    case "2": s="넘어가기"; break;
                    default:  s = "오류"; break;
                }

                Console.ForegroundColor = ConsoleColor.Green;//색상
                Console.WriteLine("Update");
                if (GameLoop.InputData=="1")
                {   
                    Graph=new Graph(MapData);
                   vis=Graph.ShortestPath(PlayerPos, EnemyPos);                    
                   
                }                
                Console.ResetColor();


            }
            
        }

         void Init()//구현 맵랜덤사이즈 설정
        {   setting = new MapSetting();//맵 크기 랜덤
            MapData=setting.MapSetting2();//맵 안에 돌과 플레이어, 적 설정
            
            map.MapCreat();//랜더링용 맵 제작
        }

        void Init(int row, int col)// 미 구현 맵사이즈 설정
        {   setting= new MapSetting(row,col);
            
            map.MapCreat();
        }

      void shutdown()
        {                        
            Console.WriteLine("5초 후에 종료합니다.");
            Thread.Sleep(5000);            
            Environment.Exit(0);//종료
        }



    }
   
    
}
