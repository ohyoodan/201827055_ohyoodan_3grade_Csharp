﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace _5week_Game_seach_Enemy
{//Map 안에는 블록 클래스가 맵 사이즈 만큼 있음 각자 호출 받아 확인
    
    internal class Map
    {   //플레이어 위치 적 위치  적 갯수 //돌의 위치

        private int Rocknum;// 돌의 개수;
        public int rocknum { get { return Rocknum; } set { Rocknum = value; } }

        private int rockcount = 0;

        Random randomsize = new Random();// 맵 사이즈 랜덤 3*3 4*4 5*5 6*6 7*7 8*8 9*9 10*10

       private block[] Map_S;// 자료 구조
       
        
       

        public void MapsizeOut()
        {
            Console.WriteLine( "맵의 크기는"+GameLoop.mapsize_col*GameLoop.mapsize_row+" 입니다.");
        }

        public void MapCreat()
        {
            Map_S=new block[GameLoop.mapsize_row*GameLoop.mapsize_col];

            for (int i = 0; i < GameLoop.mapsize_col * GameLoop.mapsize_row; i++)
            {
                int row = i/ GameLoop.mapsize_col;
                int col = i% GameLoop.mapsize_col;

                Map_S[i] = new block();
                Map_S[i].index = i;
                Map_S[i].x = row;
                Map_S[i].y =col;
            }            

        }        
    
        

        public void Map_out(int[] Map, int[] vis)
        {
            int visCount = 0;
            Array.Sort(vis);
            foreach (int i in vis)
            {                                                
                    Map[i]=4;                                
            }
            Map[GameLoop.enemyPos]=2;
            Map[GameLoop.playerPos]=3;
            for (int row = 0; row < GameLoop.mapsize_row; row++)
            {
                

                for(int col =0; col < GameLoop.mapsize_col; col++)
                {
                    int index = row* GameLoop.mapsize_col + col;                                        
                    if (col==0)
                    {
                        Console.Write("\t\t\t\t\t\t");
                    }
                    if (Map[index]==3)//플레이어 표시
                    {
                        Map_S[index].ColorReset();
                        Map_S[index].ChangeColor("Yellow");
                        Map_S[index].PlayerOut();
                        Map_S[index].ColorReset();
                    }
                    else if (Map[index]==2)//적
                    {
                        Map_S[index].ColorReset();
                        Map_S[index].ChangeColor("Red");
                        Map_S[index].EnemyOut();
                        Map_S[index].ColorReset();
                    }else if (Map[index]==1)//돌
                    {
                        Map_S[index].ColorReset();
                        Map_S[index].ChangeColor("Cyan");
                        Map_S[index].RockOut();
                        Map_S[index].ColorReset();
                    }
                    else if (Map[index]==4)
                    {   
                        Map_S[index].ColorReset();
                        Map_S[index].ChangeColor("Red");
                        Map_S[index].Out();//배열에 맞는 순으로 꺼내기
                        Map_S[index].ColorReset();
                        visCount++;
                    }
                    else if (Map[index]==0)
                    {
                        Map_S[index].ColorReset();
                        Map_S[index].ChangeColor("Green");
                        Map_S[index].Out();//배열에 맞는 순으로 꺼내기
                        Map_S[index].ColorReset();
                    }
                    

                }

                Console.WriteLine();

            }
            
        }

        public void Map_out(int[] Map)
        {
            for(int i=0; i<Map.Length; i++)
            {
                if (Map[i] == 4)
                {
                    Map[i] = 0;
                }
            }


            for (int row = 0; row < GameLoop.mapsize_row; row++)
            {


                for (int col = 0; col < GameLoop.mapsize_col; col++)
                {
                    int index = row* GameLoop.mapsize_col + col;
                                                            
                    if (col==0)
                    {
                        Console.Write("\t\t\t\t\t\t");
                    }
                    if (Map[index]==3)//플레이어 표시
                    {
                        Map_S[index].ColorReset();
                        Map_S[index].ChangeColor("Yellow");
                        Map_S[index].PlayerOut();
                        Map_S[index].ColorReset();
                    }
                    else if (Map[index]==2)//적
                    {
                        Map_S[index].ColorReset();
                        Map_S[index].ChangeColor("Red");
                        Map_S[index].EnemyOut();
                        Map_S[index].ColorReset();
                    }
                    else if (Map[index]==1)//돌
                    {
                        Map_S[index].ColorReset();
                        Map_S[index].ChangeColor("Cyan");
                        Map_S[index].RockOut();
                        Map_S[index].ColorReset();
                    }                    
                    else if (Map[index]==0)
                    {
                        Map_S[index].ColorReset();
                        Map_S[index].ChangeColor("Green");
                        Map_S[index].Out();//배열에 맞는 순으로 꺼내기
                        Map_S[index].ColorReset();
                    }
                }
                Console.WriteLine();
            }

        }

    }


    class block 
    {
        
        private int Index;// 넘버
        private int X, Y;// 자신의 위치
        public int index { get { return Index; } set {  Index = value; } }
        public int x { get { return X; } set {  X = value; } }
        public int y { get { return Y; } set { Y = value; } }
        
        public  void Out()
        {                        
            Console.Write("□");            
        }
        public  void PlayerOut()
        {
            Console.Write("P ");
        }
        public void EnemyOut()
        {
            Console.Write("E ");
        } 
       public  string Outputxy()
        {
            return "현재 좌표는 X:"+x+" Y:"+y+"입니다";
        }
        public void RockOut()
        {
            Console.Write("■");
        }

        public void ChangeColor(string s)
        {
            switch (s)
            {
                case "Green":
                    Console.ForegroundColor = ConsoleColor.Green;//색상
                    break;
                case "Red":
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case "Yellow":
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case "Cyan":
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    break;
                default:
                    break;
            }
            
        }

        public void ColorReset()
        {
            Console.ResetColor();
        }

    }
    
    
    
}
