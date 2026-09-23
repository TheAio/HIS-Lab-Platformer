using System;
using Platformer;
using SFML.Graphics;
using SFML.System;


namespace platformer;

public class Coin : Entity
{
    public Coin() : base("tileset")
    {
        sprite.TextureRect = new IntRect(198, 126, 18, 23);
        sprite.Origin = new Vector2f(9, 9);
    }
    
    public override void Update(Scene scene, float deltaTime)
    {
        if (scene.FindByType<Hero>(out Hero hero))
        {
            if (Collision.RectangleRectangle(Bounds, hero.Bounds, out _))
            {
                if (scene.FindByType<Door>(out Door door))
                {
                    Hero.Coins = 1;
                    Dead = true;
                }
            }
        }
        base.Update(scene, deltaTime);
    }
}