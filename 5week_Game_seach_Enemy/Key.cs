using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5week_Game_seach_Enemy
{    
     class Input_Key
    {
         public string Input_KeyRead()
        {
            string s = "";
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                    if (keyInfo.Key == ConsoleKey.Escape)
                    {

                        GameLoop.isRunning=false;
                        break; // ESC 키를 누르면 반복문을 종료합니다.그리고 시스템을 종료합니다.
                    }
                    else if (keyInfo.Key==ConsoleKey.Enter)
                    {
                        break;//Enter 키를 누르면 반복문을 종료합니다.
                    }
                    else if (keyInfo.Key==ConsoleKey.Backspace)
                    {
                        if (s.Length>0)
                        {
                            s= s.Substring(0, s.Length - 1);

                            Console.Write("\b \b");
                        }

                    }
                    else
                    {
                        s+=keyInfo.KeyChar;
                        Console.Write(keyInfo.KeyChar);

                    }
                }

            }
            Console.WriteLine();
            return s;
        }


    }
}
