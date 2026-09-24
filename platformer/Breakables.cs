using System;
using System.Buffers.Text;
using System.Data.SqlTypes;
using System.Runtime.CompilerServices;
using Platformer;
using SFML.Graphics;
using SFML.System;

namespace platformer;

public class Breakables : Entity
{
    //public override bool Solid => true;
    
    public Breakables() : base("tileset")
    {
        Sprite sprite = GetSprite;
        sprite.TextureRect = new IntRect(108, 0, 18, 18);
        sprite.Origin = new Vector2f(9, 9);
        Solid = true;
    }

    public override void Update(Scene scene, float deltaTime)
    {
        if (scene.FindByType<Hero>(out Hero hero))
        {
            Solid = hero.Position.Y > Position.Y ? false : true;
            if (Collision.RectangleRectangle(Bounds, hero.Bounds, out _))
            {
                if ((hero.Position.X > Position.X - 9) && !(hero.Position.X > Position.X + 9) &&!(hero.Position.Y > Position.Y + 9))
                {
                    Console.WriteLine("asdasdasd");
                    Dead = true;
                }
            }
        }
        base.Update(scene, deltaTime);
    }
}