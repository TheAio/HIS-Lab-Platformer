using System;
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
    public virtual bool Solid => false;
    
    private static float timer = 0;
    private static int  animationTime = 0;
    

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
        AnimationTimer(deltaTime);
    }

    public virtual void Render(RenderTarget target)
    {
        target.Draw(sprite);
    }

    private void AnimationTimer(float deltaTime)
    {
        timer  += deltaTime;
        if (timer > 0.0166)
        {
            timer = 0;
            animationTime++;
            Console.WriteLine(animationTime);
            if (animationTime > 60.0f)
            {
                Console.WriteLine(animationTime);
                animationTime = 0;
            }
        }
    }
    
    public int AnimationTime
    {
        get => animationTime;
    }
}