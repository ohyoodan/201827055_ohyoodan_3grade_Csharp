
using System;
using System.Collections.Generic;

int mapsize_row =10;
int mapsize_col = 10;


bool a, s, d, f=false;
for (int row = 0; row < mapsize_row; row++)
{


    for (int col = 0; col < mapsize_col; col++)
    {
        a = false;s=false;d=false;f=false;

        if (row==0) {
            
            a = true;
        }
        if(col==0)
        {
            s = true;
        }
        if(col==mapsize_col-1)
        {
            d= true;
        }
        if (row==mapsize_row-1)
        {
            f= true;
        }
        if (a)
        {
            Console.ForegroundColor = ConsoleColor.Green;//색상
            Console.Write("●");
        }else if(s){
            Console.ForegroundColor = ConsoleColor.Green;//색상
            Console.Write("●");
        }else if (d)
        {
            Console.ForegroundColor = ConsoleColor.Green;//색상
            Console.Write("●");
        }else if (f)
        {
            Console.ForegroundColor = ConsoleColor.Green;//색상
            Console.Write("●");
        }else if (s||d)
        {
            Console.ForegroundColor = ConsoleColor.Green;//색상
            Console.Write("●");
        }else if (f||s)
        {
            Console.ForegroundColor = ConsoleColor.Green;//색상
            Console.Write("●");
        }else if (a||d)
        {
            Console.ForegroundColor = ConsoleColor.Green;//색상
            Console.Write("●");
        }else if (d||f)
        {
            Console.ForegroundColor = ConsoleColor.Green;//색상
            Console.Write("●");
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;//색상
            Console.Write("●");
        }
        
        

    }
    Console.WriteLine();
}

