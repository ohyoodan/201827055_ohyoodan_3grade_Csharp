
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

        int PlayerPos = 5;
        int EnemyPos;


        private int Mapsize_row;// 맵의 행->
        internal int mapsize_row { get { return Mapsize_row; } set { Mapsize_row = value; } }
        private int Mapsize_col;// 맵의 열
        internal int mapsize_col { get { return Mapsize_col; }set { Mapsize_col = value; } }

        Random randomsize = new Random();// 맵 사이즈 랜덤 3*3 4*4 5*5 6*6 7*7 8*8 9*9 10*10


       private IMapTile[] Map_S;// 자료 구조

       public Map()
        {   int Col= randomsize.Next(3, 11);//3~10 이상~미만
            int Row= randomsize.Next(3, 11);
            mapsize_row =Row;
            mapsize_col =Col;
        }
        Map(int col,int row)
        {
            int CoI = col;
            int Row = row;
        }        

        public void MapsizeOut()
        {
            Console.WriteLine( "맵의 크기는"+Mapsize_col*Mapsize_row+" 입니다.");
        }

        public void MapCreat()
        {
            Map_S=new IMapTile[Mapsize_row*Mapsize_col];

            for (int i = 0; i < Mapsize_col*Mapsize_row; i++)
            {
                int row = i/Mapsize_col;
                int col = i%Mapsize_col;

                Map_S[i] = new block();// if문을 이용해 돌과 판별 랜덤으로 뿌릴 것
                Map_S[i].index = i;
                Map_S[i].x = row;
                Map_S[i].y =col;
            }            

        }

        public void PosSet()
        {
            PlayerPos=randomsize.Next(0, Mapsize_col*Mapsize_row);
            EnemyPos=randomsize.Next(0, Mapsize_col*Mapsize_row);
            if (PlayerPos==EnemyPos)
            {
                PosSet();
            }
        }

        public void Map_out()
        {
            
            for (int row = 0; row < Mapsize_row; row++)
            {
                

                for(int col =0; col < Mapsize_col; col++)
                {
                    int index = row* Mapsize_col+col;
                    if (col==0)
                    {
                        Console.Write("\t\t\t\t\t\t");
                    }
                    if (Map_S[index].index==PlayerPos)
                    {
                        Map_S[index].ColorReset();
                        Map_S[index].ChangeColor("Yellow");
                        Map_S[index].PlayerOut();
                        Map_S[index].ColorReset();
                    }
                    else
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


    class block : IMapTile
    {
        
        private int Index;// 넘버
        private int X, Y;// 자신의 위치
        public int index { get { return Index; } set {  Index = value; } }
        public int x { get { return X; } set {  X = value; } }
        public int y { get { return Y; } set { Y = value; } }
        
        public virtual void Out()
        {
            
            
            Console.Write("□");

            // 리셋
        }
        public virtual void PlayerOut()
        {

            Console.Write("■");

        }

       public virtual string Outputxy()
        {
            return "현재 좌표는 X:"+x+" Y:"+y+"입니다";
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
    

    class rock:block ,IMapTile
    {
        public override void Out()
        {   Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("◆");
            Console.ResetColor();
        }
        
    }
}
