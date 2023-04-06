using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5week_Game_seach_Enemy
{   
    // 최단 경로 하나만 선으로 표시 할 것
    internal class Tree
    {
        int[] Tree_= new int[GameManager.mapsize_row*GameManager.mapsize_col];
        
        int[] visited = new int[100];//이동한 위치를 저장하는 배열  나중에 게임 루프로 보내 줄 것
        int visitedIdx  = 0;

      public  Tree()
        {
            for(int i= 0; i < Tree_.Length; i++)//초기화
            {
                //0: 이동 가능한 빈 칸 , 1: 벽 2: 적 3: 아군 4: 돌

                if (i==GameManager.enemyPos)
                {
                    Tree_[i] = 2;
                }else if(i== GameManager.playerPos)
                {

                    Tree_[i]=3;
                }//else if()
                else
                {
                    Tree_[i]=0;
                }
                

            }



        }

     public   bool IsMovable(int pos)
        {
            return pos>=0 && pos< GameManager.mapsize_col*GameManager.mapsize_row && Tree_[pos] != 1;
            // 범위 내에 있고 벽이 아니면 이동 가능
        }                                        
        
            public int[] Out()
        {
            return visited;
        }

    }

    
    class Vertex
    {
        


    }
    class edge
    {




    }
    
    
        
       

    class MapSetting
    {
        Random randomsize= new Random();
        public void PosSet()
        {
            GameManager.playerPos = randomsize.Next(0, GameManager.mapsize_col * GameManager.mapsize_row);
            GameManager.enemyPos = randomsize.Next(0, GameManager.mapsize_col * GameManager.mapsize_row);
            if (GameManager.playerPos == GameManager.enemyPos)
            {
                PosSet();
            }
        }

        public MapSetting()
        {
            int Col = randomsize.Next(3, 11);//3~10 이상~미만
            int Row = randomsize.Next(3, 11);
            GameManager.mapsize_row = Row;
            GameManager.mapsize_col = Col;
        }
        public MapSetting(int col, int row)
        {
            GameManager.mapsize_col  = col;
            GameManager.mapsize_row  = row;
        }

    }



}
