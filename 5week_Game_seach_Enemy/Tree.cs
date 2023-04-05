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
        
        int[] visited = new int[2000];//이동한 위치를 저장하는 배열  나중에 게임 루프로 보내 줄 것
        int visitedIdx = 0;

      public  Tree()
        {
            for(int i= 0; i < Tree_.Length; i++)
            {
                //0: 이동 가능한 빈 칸 , 1: 벽 2: 적 3: 아군

                if (i==GameManager.enemyPos)
                {
                    Tree_[i] = 2;
                }else if(i== GameManager.playerPos)
                {

                    Tree_[i]=3;
                }
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
        
        // BFS 탐색
        int[] queue = new int[100];
        int front = 0, rear = 0;

        void Enqueue(int x)
        {
            queue[rear++] = x;
        }

        int Dequeue()
        {
            return queue[front++];
        }

        bool IsEmpty()
        {
            return front == rear;
        }

        public void BFS(int start)
        {
            Enqueue(start);

            while (!IsEmpty())
            {
                int pos = Dequeue();
                visited[visitedIdx++] = pos;

                // 적을 찾은 경우 탐색 중지
                if (pos ==GameManager.playerPos)
                    break;

                // 상하좌우 이동
                int[] dx = { 0, 0, -1, 1 };
                int[] dy = { -1, 1, 0, 0 };
                for (int i = 0; i < 4; i++)
                {
                    int nextPos = pos + dy[i] * 4 + dx[i];
                    if (IsMovable(nextPos) && Array.IndexOf(visited, nextPos) == -1) // 이동 가능하고 방문하지 않은 칸인 경우
                        Enqueue(nextPos);
                }
            }


        }


            public int[] Out()
        {
            return visited;
        }

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
