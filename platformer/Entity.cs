using System.Net.Http;
using SFML.Graphics;
using SFML.System;

namespace platformer;

public class Entity
{
    private readonly Sprite sprite;
    protected string textureName;
    public bool dead;
    private Vector2f position;
    private readonly FloatRect bounds;

    public Vector2f Position
    {
        get => position;
        set => position = value;
    }

    public FloatRect Bounds
    {
        get => bounds;
    }

    protected Entity(string textureName)
    {
        
    }

    public void Create(Scene scene)
    {
        
    }

    public void Update(Scene scene, float deltaTime)
    {
        
    }

    public void Render(RenderTarget target)
    {
        
    }
    
}