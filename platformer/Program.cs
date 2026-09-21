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
            using (var window = new RenderWindow(new VideoMode(500, 700), "Platformer"))
            {
                window.Closed += (o, e) => window.Close();
                window.SetView(new View(
                    new Vector2f(200, 150),
                    new Vector2f(400, 300)
                ));
                
                Clock clock = new Clock();
                Scene scene = new();
                
                for (int i = 0; i < 10; i++) { scene.Spawn(new Platform {
                        Position = new Vector2f(18 + i * 18, 288)
                    });
                }
                
                while (window.IsOpen)
                {
                    float deltaTime = clock.Restart().AsSeconds();
                    window.DispatchEvents();
                    //Update here
                    scene.UpdateAll(deltaTime);
                    
                    window.Clear(new Color(67, 160, 188));
                    //Draw here
                    scene.RenderAll(window);
                    
                    window.Display();
                }
            }
        }
    }
}