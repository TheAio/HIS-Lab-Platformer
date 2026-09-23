using System;
using Platformer;
using SFML.Graphics;
using SFML.System;

namespace platformer;

public class Door : Entity
{
    public string NextRoom;
    public bool Unlocked;
    
    public Door() : base("tileset")
    {
        sprite.TextureRect = new IntRect(180, 103, 18, 23);
        sprite.Origin = new Vector2f(9, 11);
        // TODO FROM POINT 56
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
                NextRoom = "level1";
                scene.Load(NextRoom);
            }
        }
        base.Update(scene, deltaTime);
    }
}

