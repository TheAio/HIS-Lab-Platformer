using System;
using System.Collections.Generic;
using System.Linq;
using Platformer;
using SFML.Graphics;
using SFML.System;

namespace platformer;

public class Gui : Entity
{
    public Gui(int guiDigit, Vector2f guiPosition) : base("tileset")
    {
        if (guiDigit == -1)
        {
            sprite.TextureRect = new IntRect(198, 126, 18, 18);
        }
        else
        {
            sprite.TextureRect = new IntRect(180 + guiDigit * 18, 144, 18, 18);
        }
        sprite.Position = guiPosition;
    }
    
    
    public List<int> GetGuiDigitsFromNumber(int number)
    {
        List<int> digits = new List<int>();
        char[] a = number.ToString().ToArray();
        for (int i = 0; i < number.ToString().ToArray().Length; i++)
        {
            digits.Add(a[i] - '0');
            // -'0' is needed because it tricks C# into converting the char correctly to an int.
        }
        return digits;
    }
    
    public List<Vector2f> GetGuiOffsets(int bigGuiNumber, Vector2f offset)
    {
        List<Vector2f> vectors = new List<Vector2f>();
        Vector2f mainVector = offset;
        int j = 10;
        vectors.Add(mainVector);
        for (int i = 0; i <= bigGuiNumber; i++)
        {
            if (i - j >= 0)
            {
                j *= 10;
                mainVector.X += 18;
                vectors.Add(mainVector);
            }
        }
        return vectors;
    }
}