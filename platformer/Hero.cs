using System;
using System.Collections.Generic;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace platformer;

public class Hero : Entity
{
    private static bool hasKey;
    private static int coins;
    private bool faceRight = false;

    public const float WalkSpeed = 100.0f;
    public const float JumpForce = 250.0f;
    public const float GravityForce = 400.0f;
    
    private float verticalSpeed;
    private bool isGrounded;
    private bool isUpPressed;

    private float heroAnimationTime = 0;
    private List<IntRect> heroAnimationFrames = new List<IntRect>();

    public Hero() : base("characters")
    {
        heroAnimationFrames.Add(new  IntRect(0, 0, 24, 24));
        heroAnimationFrames.Add(new  IntRect(24, 0, 24, 24));
        
        sprite.TextureRect = heroAnimationFrames[0];
        sprite.Origin = new Vector2f(12, 12);
    }

    public override void Update(Scene scene, float deltaTime)
    {
        CheckHeroIsOnScreen();
        
        if (Keyboard.IsKeyPressed(Keyboard.Key.Left))
        {
            scene.TryMove(this, new Vector2f(-WalkSpeed * deltaTime, 0));
            faceRight = false;
            HeroWalkAnimation(deltaTime);
        }

        if (Keyboard.IsKeyPressed(Keyboard.Key.Right))
        {
            scene.TryMove(this, new Vector2f(WalkSpeed * deltaTime, 0));
            faceRight = true;
            HeroWalkAnimation(deltaTime);
        }
        
        verticalSpeed += GravityForce * deltaTime;
        if (verticalSpeed > 500.0f) verticalSpeed = 500.0f;
        isGrounded = false;
        Vector2f velocity = new Vector2f(0, verticalSpeed * deltaTime);
        if (scene.TryMove(this, velocity))
        {
            if (verticalSpeed > 0.0f)
            {
                isGrounded = true;
                verticalSpeed = 0.0f;
            }
            else
            {
                verticalSpeed = -0.5f * verticalSpeed;
                
            }
        }
        
        if (Keyboard.IsKeyPressed(Keyboard.Key.Up) && isGrounded)
        {
            if (isGrounded && !isUpPressed)
            {
                VerticalSpeed = -JumpForce;
                isUpPressed = true;
            }
        }
        else
        {
            isUpPressed = false;
        }
    }

    public override FloatRect Bounds 
    {
        get 
        {
            var bounds = base.Bounds;
            bounds.Left += 3;
            bounds.Width -= 6;
            bounds.Top += 3;
            bounds.Height -= 3;
            return bounds;
        }
    }
    
    public static int Coins
    {
        get => coins;
        set => coins += value;
    }

    public static void SetCoins(int value)
    {
        coins = value;
    }

    public override void Render(RenderTarget target)
    {
        sprite.Scale = new Vector2f(faceRight ? -1 : 1, 1);
        base.Render(target);
    }
    
    public float VerticalSpeed
    {
        get => verticalSpeed;
        set => verticalSpeed = value;
    }
    
    private void CheckHeroIsOnScreen()
    {
        if (sprite.Position.Y < 0 || 
            sprite.Position.X < 0 || 
            sprite.Position.Y > Settings.Graphics.ScreenHeight || 
            sprite.Position.X > Settings.Graphics.ScreenWidth
            )
        {
            Scene.DoReload = true;
        }
    }

    private void HeroWalkAnimation(float deltaTime)
    {
        if (isGrounded)
        {
            sprite.TextureRect = GetNextAnimationTexture(heroAnimationFrames, deltaTime, 0.4f, ref heroAnimationTime);
        }
    }
}

