using System.Net.Http;
using SFML.Graphics;
using SFML.System;

namespace platformer;

public class Entity
{
    protected string textureName;
    private readonly Sprite sprite;
    public bool Dead;
    private Vector2f position;
    private readonly FloatRect bounds;

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
        get => position;
        set => position = value;
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
    
    /*public class Platform : Entity
    {
        public Platform() : base("tileset")
        {
            //Sprite sprite = GetSprite;
            sprite.TextureRect = new IntRect(0, 0, 18, 18);
            sprite.Origin = new Vector2f(9, 9);
        }
    }*/
    
}