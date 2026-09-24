using System;
using System.Collections.Generic;
using System.Net.Http;
using SFML.Graphics;
using SFML.System;

namespace platformer;

public class Entity
{
    private string textureName;
    protected readonly Sprite sprite;
    public bool Dead;
    private Vector2f position;
    private readonly FloatRect bounds;
    private bool solid;
    
    //public virtual bool Solid => false;
    public virtual bool Solid
    {
        get => solid;
        set => solid = value;
    }
    

    protected Entity(string TextureName)
    {
        textureName = TextureName;
        sprite = new Sprite();
    }

    public Sprite GetSprite
    {
        get => sprite;
    }
    
    public virtual Vector2f Position
    {
        // sprite.Position is native SFML code
        // bra at tutorialen döper saker till exakt samma som som andra saker heter, using using anyone?
        get => sprite.Position;
        set => sprite.Position = value;
    }

    public virtual FloatRect Bounds
    {
        get => sprite.GetGlobalBounds();
    }

    
    public virtual void Create(Scene scene)
    {
        sprite.Texture = scene.LoadTexture(textureName);
    }

    public virtual void Update(Scene scene, float deltaTime)
    {

    }

    public virtual void Render(RenderTarget target)
    {
            target.Draw(sprite);
    }
    
    public virtual IntRect GetNextAnimationTexture(List<IntRect> animationFrames, float deltaTime,float animationLoopTime, ref float animationTimer)
    {
        animationTimer += deltaTime;
        if (animationTimer > animationLoopTime)
        {
            animationTimer = 0;
        }
        return animationTimer >= (animationLoopTime*0.5f) ? animationFrames[0] : animationFrames[1];
    }
}