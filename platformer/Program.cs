using System;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace platformer
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var window = new RenderWindow(new VideoMode(Settings.Graphics.ScreenWidth, Settings.Graphics.ScreenHeight), "Platformer"))
            {
                window.Closed += (o, e) => window.Close();
                window.SetView(new View(
                    new Vector2f(200, 150),
                    new Vector2f(400, 300)
                ));
                
                Clock clock = new Clock();
                Scene scene = new();
                scene.Load("level0");

                
                while (window.IsOpen)
                {
                    float deltaTime = clock.Restart().AsSeconds();
                    
                    window.DispatchEvents();
                    scene.UpdateAll(deltaTime);
                    
                    window.Clear(new Color(67, 160, 188));
                    scene.RenderAll(window);
                    
                    window.Display();
                }
            }
        }
    }
}