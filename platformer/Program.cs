using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace platformer
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var window = new RenderWindow(
                       new VideoMode(500, 700), "Platformer"))
            {
                window.Closed += (o, e) => window.Close();
                Clock clock = new Clock();
                while (window.IsOpen)
                {
                    float deltaTime = clock.Restart().AsSeconds();
                    window.DispatchEvents();
                    //Update here
                    window.Clear(new Color(67, 160, 188));
                    //Draw here
                    window.Display();
                }
            }
        }
    }
}