using System;
using System.Collections.Generic;
using SFML.Graphics;

namespace platformer;

public class Scene
{
    private readonly Dictionary<string, Texture> textures;
    private readonly List<Entity> entities;

    public Scene()
    {
        textures = new Dictionary<string, Texture>();
        entities = new List<Entity>();
    }
    public void Spawn(Entity entity)
    {
        
    }

    public void UpdateAll(float deltaTime)
    {
        
    }

    public void RenderAll(RenderTarget target)
    {
        
    }
}