using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5week_Game_seach_Enemy
{
    internal class Player
    {
        int movePoint;// 이동량

        Pos Playerpos= new Pos();// 내 위치

        // ●
    }


    class Enemy: Player
    {
        //플레이어의 위치

        // 가는 경로

        //★
    }

    struct Pos
    {
       private int X, Y;

        public int x { get { return X; } set { X = value; } }
        public int y { get { return Y; } set { Y = value; } }
    }

}
