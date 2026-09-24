using System;
using System.Collections.Generic;
using Platformer;
using SFML.Graphics;
using SFML.System;


namespace platformer;

public class Coin : Entity
{
    private List<IntRect> coinAnimationTextures = new List<IntRect>();
    private float coinAnimationTimer = 0;
    
    public Coin() : base("tileset")
    {
        coinAnimationTextures.Add(new IntRect(198, 126, 18, 23));
        coinAnimationTextures.Add(new IntRect(216, 126, 18, 23));
        sprite.TextureRect = coinAnimationTextures[0];
        sprite.Origin = new Vector2f(9, 9);
    }
    
    public override void Update(Scene scene, float deltaTime)
    {
        sprite.TextureRect = GetNextAnimationTexture(coinAnimationTextures, deltaTime, 0.3f, ref coinAnimationTimer);
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