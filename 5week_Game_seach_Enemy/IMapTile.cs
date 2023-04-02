using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5week_Game_seach_Enemy
{
    public interface IMapTile
    {
        int index { get; set; }
        int x { get; set; }
        int y { get; set; }


        void ChangeColor();
        void Out();
        

    }
}
