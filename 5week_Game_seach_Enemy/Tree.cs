using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5week_Game_seach_Enemy
{
    // 최단 경로 하나만 선으로 표시 할 것
    internal class Tree
    {
        int[] Tree_ = new int[GameLoop.mapsize_row*GameLoop.mapsize_col];

        int[] visited = new int[int.MaxValue];//이동한 위치를 저장하는 배열  나중에 게임 루프로 보내 줄 것
        int visitedIdx = 0;

        public Tree()
        {
            for (int i = 0; i < Tree_.Length; i++)//초기화
            {
                //0: 이동 가능한 빈 칸 , 1: 벽 2: 적 3: 아군

                if (i==GameLoop.enemyPos)
                {
                    Tree_[i] = 2;
                }
                else if (i== GameLoop.playerPos)
                {

                    Tree_[i]=3;
                }
                else
                {
                    Tree_[i]=0;
                }



            }



        }
        int[] seach()
        {

            return Tree_;
        }

    }


    public class Node
    {
        public int num;
        Node(int num)
        {
            this.num = num;
        }
    }
    public class Edge
    {
        public Node from;
        public Node to;
        public int weight; 

        public Edge(Node from, Node to,int weight) { 
        this.from = from;
        this.to= to;
        this.weight = weight;        
        }

    }



    class MapSetting
    {
        int[] MapData;
        Random random = new Random();

        public void PosSet()
        {
            GameLoop.playerPos = random.Next(0, GameLoop.mapsize_col * GameLoop.mapsize_row);
            GameLoop.enemyPos = random.Next(0, GameLoop.mapsize_col * GameLoop.mapsize_row);
            if (GameLoop.playerPos == GameLoop.enemyPos)
            {
                PosSet();
            }
        }

        public MapSetting()
        {
            int Col = random.Next(3, 11);//3~10 이상~미만
            int Row = random.Next(3, 11);
            GameLoop.mapsize_row = Row;
            GameLoop.mapsize_col = Col;

            MapData = new int[GameLoop.mapsize_col*GameLoop.mapsize_row];

        }
        public MapSetting(int col, int row)
        {
            GameLoop.mapsize_col  = col;
            GameLoop.mapsize_row  = row;
            MapData = new int[GameLoop.mapsize_col*GameLoop.mapsize_row];
        }


        public int[] MapSetting2()
        {
            int Rock = 0;
            int[] RockPos;
            
            MapData=new int[100];
            bool T = false;
            int RockCount = 0;
            Rock=random.Next(0, (GameLoop.mapsize_row*GameLoop.mapsize_col)/2/2);//돌 갯수 맵의 1/4 이하로 생성
            RockPos=new int[Rock];
            PosSet();
            for (int i = 0; i<Rock; i++)
            {
                if (i==GameLoop.enemyPos||i==GameLoop.playerPos)
                {
                    i--;
                }
                else
                {
                    RockPos[i]=random.Next(GameLoop.mapsize_row*GameLoop.mapsize_col);
                }
            }
            Array.Sort(RockPos);
            for(int i = 0; i<GameLoop.mapsize_row*GameLoop.mapsize_col; i++)
            {
                if (i==GameLoop.playerPos)
                {
                    MapData[i]=3;
                }
                else if (i==RockPos[RockCount]&&T==false)
                {//돌 생성
                    MapData[i]=1;   
                    T= true;
                }
                else if (i==GameLoop.enemyPos)
                {
                    MapData[i]=2;
                }
                else
                {
                    MapData[i]=0;
                }
                if (T==true)
                {
                    if (RockCount<RockPos.Length-1)
                    {
                        RockCount++;
                        T= false;
                    }
                    T= false;
                }
            }


            return MapData;
        }

    }

}
