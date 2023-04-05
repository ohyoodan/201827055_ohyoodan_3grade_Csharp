using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5week_Game_seach_Enemy
{   
    // 최단 경로 하나만 선으로 표시 할 것
    internal class Tree
    {


    }

    class BFS
    {


    }

    class Vertex//꼭짓점
    {

    }

    class Edge//변
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
