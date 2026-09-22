using System;
using SFML.Graphics;
using SFML.System;

namespace platformer;


public class Platform : Entity
{
    public Platform() : base("tileset")
    {
        Sprite sprite = GetSprite;
        sprite.TextureRect = new IntRect(0, 0, 18, 18);
        sprite.Origin = new Vector2f(9, 9);
    }
    
}
