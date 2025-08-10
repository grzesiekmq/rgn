using System;
using System.Threading;
using rgn;

class Program
{
    public static void Main()
    {
        // engine test
        
        var engine = new Engine
        {
            idleRpm = 800,
            maxRpm = 8000,
            inertia = 0.01f
        };
        
        int i = 0;

        int gaugeWidth = 50;
        float throttle = 0f;

        while (true)
        {
            throttle += 0.05f;
            engine.Update(0.016f, throttle);
            
            // ASCII rpm meter
            float rpmPercent = engine.rpm / engine.maxRpm;
            rpmPercent = Maths.Clamp(rpmPercent, 0f, 1f);
            int bars = (int)(rpmPercent * gaugeWidth);

            Console.CursorLeft = 0;
            Console.Write("[" + new string('#', bars) + new string('-', gaugeWidth - bars) + $"] {engine.rpm,5:0} rpm");


            // Console.WriteLine(i + ": " + engine.rpm + " rpm");
            i++;
            
            // Write is slow, delay then
            Thread.Sleep(100);
        }
    }
}