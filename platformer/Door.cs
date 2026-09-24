using System;
using Platformer;
using SFML.Graphics;
using SFML.System;

namespace platformer;

public class Door : Entity
{
    public string NextRoom;
    public bool Unlocked;
    private static int index = 1;
    
    public Door() : base("tileset")
    {
        sprite.TextureRect = new IntRect(180, 103, 18, 23);
        sprite.Origin = new Vector2f(9, 11);
    }

    public override void Update(Scene scene, float deltaTime)
    {
        if (Unlocked)
        {
            sprite.Color = Color.Black;
        }
        
        if (scene.FindByType<Hero>(out Hero hero))
        {
            if (Collision.RectangleRectangle(Bounds, hero.Bounds, out _) && Unlocked)
            {
                // felhantera så det inte crashar när det tar slut på levels
                if (index > scene.Levels.Count-1)
                {
                    Scene.DoReload = true;
                    index = scene.Levels.Count - 1;
                    scene.Reload();
                }
                scene.Load(scene.Levels[index]);
                index++;
            }
        }
        base.Update(scene, deltaTime);
    }
}

