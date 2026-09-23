using System;
using System.Collections.Generic;
using Platformer;
using SFML.Graphics;
using SFML.System;

namespace platformer;

public class Gui : Entity
{
    public Gui(int guiNumber) : base("tileset")
    {
        sprite.TextureRect = new IntRect(180 + guiNumber*18, 144, 18, 23);
    }
}