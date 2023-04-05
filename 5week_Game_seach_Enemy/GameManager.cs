using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5week_Game_seach_Enemy
{
    static class GameManager
    {
        static private int PlayerPos;
        static public  int playerPos { get { return PlayerPos; } set { PlayerPos = value; } }

        static private int EnemyPos;
        static public  int enemyPos { get { return EnemyPos; } set { EnemyPos = value; } }

        static private int Mapsize_row;// 맵의 행->
        static public  int mapsize_row { get { return Mapsize_row; } set { Mapsize_row = value; } }
        static private int Mapsize_col;// 맵의 열
        static public  int mapsize_col { get { return Mapsize_col; } set { Mapsize_col = value; } }


    }
}
