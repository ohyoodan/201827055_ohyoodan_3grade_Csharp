
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace _5week_Game_seach_Enemy
{
    
    internal class Map
    {   //플레이어 위치 적 위치  적 갯수 

        private int Rocknum;// 돌의 개수;
        public int rocknum { get { return Rocknum; } set { Rocknum = value; } }
        
                    
        // 돌의 위치


        private int Mapsize;// 맵의 크기
        internal int mapsize { get { return Mapsize; } set { Mapsize = value; } }
        Random randomsize;// 맵 사이즈 랜덤 2*2 3*3 4*4 5*5 6*6 7*7 8*8 9*9 10*10


        block[] Map_S;// 자료 구조

        Map()
        {   int ex= randomsize.Next(2, 10);
            mapsize = ex;
        }
        Map(int size)
        {
            mapsize = size;
        }

        public void MapsizeOut()
        {
            Console.WriteLine(mapsize + "입니다.");
        }

        void MapCreat(int size)
        {
            int Test = size * size;

            for(int i = 0; i < Test; i++)
            {
                Map_S = new block[i];// if문을 이용해 돌과 판별 랜덤으로 뿌릴 것
                Map_S[i].index = i;
                Map_S[i].x = i;
                Map_S[i].y = i;
            }

        }
        void Map_out(int size)
        {
            
            for (int i = 0; i < size; i++)
            {
                Console.Write("┏");
                Console.Write("  ");
                for (int j = 0; j < size; j++)
                {
                    Console.Write("□");
                }
                Console.WriteLine();
            }

        }
        
    }


    class block 
    {
        private int Index;// 넘버
        private int X, Y;// 자신의 위치
        internal int index { get { return Index; } set {  Index = value; } }
        internal int x { get { return X; } set {  X = value; } }
        internal int y { get { return Y; } set { Y = value; } }
    }
    

    class rock:block
    {
       
    }
}
