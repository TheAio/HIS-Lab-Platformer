using System;
using SFML.Window;

namespace platformer;

public class Settings
{
    public class Graphics : Settings
    {
        private static uint screenWidth = 1280;
        private static uint screenHeight = 720;

        public static uint ScreenWidth
        {
            get => screenWidth;
            set
            {
                screenWidth = value;
                screenHeight = screenWidth * (9 / 16);
            }
        }
        
        public static uint ScreenHeight
        {
            get => screenHeight;
            set 
            {
                screenHeight = value;
                screenWidth = screenHeight * (16 / 9);
            }
        }
    }
}