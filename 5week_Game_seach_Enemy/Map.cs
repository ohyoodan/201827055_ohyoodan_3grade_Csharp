
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

       private IMapTile[] Map_S;// 자료 구조

       

        public void MapsizeOut()
        {
            Console.WriteLine( "맵의 크기는"+GameManager.mapsize_col*GameManager.mapsize_row+" 입니다.");
        }

        public void MapCreat()
        {
            Map_S=new IMapTile[GameManager.mapsize_row*GameManager.mapsize_col];

            for (int i = 0; i < GameManager.mapsize_col * GameManager.mapsize_row; i++)
            {
                int row = i/ GameManager.mapsize_col;
                int col = i% GameManager.mapsize_col;

                Map_S[i] = new block();// if문을 이용해 돌과 판별 랜덤으로 뿌릴 것
                Map_S[i].index = i;
                Map_S[i].x = row;
                Map_S[i].y =col;
            }            

        }

        

        public void Map_out()
        {
            
            for (int row = 0; row < GameManager.mapsize_row; row++)
            {
                

                for(int col =0; col < GameManager.mapsize_col; col++)
                {
                    int index = row* GameManager.mapsize_col + col;
                    if (col==0)
                    {
                        Console.Write("\t\t\t\t\t\t");
                    }
                    if (Map_S[index].index== GameManager.playerPos)
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
