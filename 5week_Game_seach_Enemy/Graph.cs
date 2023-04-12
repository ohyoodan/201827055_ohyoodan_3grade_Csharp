using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.ComponentModel;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.ValueTuple;

namespace _5week_Game_seach_Enemy
{
   
    //const int INS = int.MaxValue;//무한

    // 최단 경로 하나만 선으로 표시 할 것
    internal class Graph
    {
        int[] Map;//노드의 갯수
        int Node;
        List<List<(int, int)>> adjList;//인접리스트
        
        public Graph(int[] Map)
        {
            this.Map=Map;
            Node=Map.Length;
            adjList = new List<List<(int, int)>>(Node);

            for(int i=0;i<Node; i++)
            {
                adjList.Add(new List<(int, int)>());
            }

            for(int i=0; i<GameLoop.mapsize_row; i++)
            {
                for (int j = 0; j<GameLoop.mapsize_col; j++)
                {
                    int curr = i * GameLoop.mapsize_col + j;

                    if (Map[curr] != 1)
                    {
                        // 현재 위치가 벽이 아니면 상하좌우를 확인하며 간선 추가
                        if (i > 0 && Map[curr - GameLoop.mapsize_col] != 1)
                        {
                            AddEdge(curr, curr - GameLoop.mapsize_col, 1);
                        }
                        if (i < GameLoop.mapsize_row - 1 && Map[curr + GameLoop.mapsize_col] != 1)
                        {
                            AddEdge(curr, curr + GameLoop.mapsize_col, 1);
                        }
                        if (j > 0 && Map[curr - 1] != 1)
                        {
                            AddEdge(curr, curr - 1, 1);
                        }
                        if (j < GameLoop.mapsize_col - 1 && Map[curr + 1] != 1)
                        {
                            AddEdge(curr, curr + 1, 1);
                        }

                    }
                }
            }

        }
           
        
        public void AddEdge(int u,int v,int w)
        {// u에서 v로 가는 가중치 w의 간선 추가
            adjList[u].Add((v, w));
            adjList[v].Add((u, w));
        }

        public int[] ShortestPath(int start, int end)
        {
            // 시작 노드에서부터의 최단 경로 배열
            int[] dist = new int[Node];
            bool[] visited = new bool[Node];
            int?[] prev = new int? [Node ];
            for (int i = 0; i < Node; i++)
            {
                dist[i] = int.MaxValue;
            }
            dist[start] = 0;

            // 우선순위 큐에 (노드, 시작점으로부터의 거리) 삽입
            PriorityQueue<(int, int), int> pq = new PriorityQueue<(int, int), int>();
            pq.Enqueue((start, 0), 0);

            while (pq.Count > 0)
            {
                // 가장 가까운 노드와 거리 추출
                (int u, int d) = pq.Dequeue();

                if (d > dist[u])
                {
                    // 이미 최단 경로를 구한 노드는 skip
                    continue;
                }

                if (u == end)
                {
                    // 목적지에 도착한 경우
                    break;
                }

                // u와 인접한 노드들의 최단 거리 갱신
                foreach ((int v, int w) in adjList[u])
                {                    
                    int newDist = dist[u] + w;
                    if (newDist < dist[v])
                    {
                        dist[v] = newDist;
                        prev[v]=u;
                        pq.Enqueue((v, newDist), newDist);
                    }
                }
            }
            if (prev[end]==null)
            {//시작에서 도달 불가
                return null;
            }


            List<int> Path = new List<int>();
            int curr = end;
            while (curr !=start)
            {
                Path.Add(curr);
                curr= prev[curr].Value;
            }
            Path.Add(start);Path.Reverse();

            return Path.ToArray();//언박싱 일어날 것으로 추정
        }

        


        int[] Out()
        {
            
            return Map;            
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
            
            int[] RockPos;            
            MapData=new int[100];
            int RockCount =random.Next(1, (GameLoop.mapsize_row*GameLoop.mapsize_col)/2/2);//돌 갯수 맵의 1/4 이하로 생성

            RockPos=new int[RockCount];

            PosSet();
            for (int i = 0; i<RockCount; i++)
            {                
                int ram=random.Next(GameLoop.mapsize_row*GameLoop.mapsize_col);
                if (RockPos.Contains(ram))
                {
                    i--;
                }
                else
                {
                    RockPos[i]=ram;                    
                }                
            }
            
            Array.Sort(RockPos);
            
            
            for(int i = 0; i<GameLoop.mapsize_row*GameLoop.mapsize_col; i++)//맵 초기화
            {//돌 1 , 플레이어 3 , 적 2                                          
                    MapData[i]=0;                                
            }
            foreach (int f in RockPos)//돌
            {                
                MapData[f] = 1;
            }
            MapData[GameLoop.playerPos]=3;
            MapData[GameLoop.enemyPos]=2;
            return MapData;
        }

    }

}
