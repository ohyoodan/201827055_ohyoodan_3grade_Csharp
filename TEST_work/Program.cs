using System;
using System.Threading;

public class Program
{
    static int sharedData = 0;

    static void Main(string[] args)
    {
        Thread t1 = new Thread(Increment);
        Thread t2 = new Thread(Decrement);

        t1.Start();
        t2.Start();

        t1.Join();
        t2.Join();

        Console.WriteLine("The final value of sharedData is: " + sharedData);
    }

    static void Increment()
    {
        for (int i = 0; i < 1000000; i++)
        {
            sharedData++;
        }
    }

    static void Decrement()
    {
        for (int i = 0; i < 1000000; i++)
        {
            sharedData--;
        }
    }
}
