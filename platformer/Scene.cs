using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Platformer;
using SFML.Graphics;
using SFML.System;

namespace platformer;

public class Scene
{
    private Dictionary<string, Texture> textures;
    private List<Entity> entities;

    private string nextScene;
    private string currentScene;

    private int oldCoins = 0;
    private static bool doReload;

    public Scene()
    {
        textures = new Dictionary<string, Texture>();
        entities = new List<Entity>();
    }
    public void Spawn(Entity entity)
    {
        entities.Add(entity);
        entity.Create(this);
    }

    public void UpdateAll(float deltaTime)
    {
        Reload();
        HandleSceneChange();
        //Todo: try replacing this with a foreach loop
        for (int i = entities.Count - 1; i >= 0; i--)
        {
            Entity entity = entities[i];
            entity.Update(this, deltaTime);
        }

        for (int i = 0; i < entities.Count;)
        {
            Entity entity = entities[i];
            if (entity.Dead)
            {
                entities.RemoveAt(i);
            }
            else
            {
                i++;
            }
        }
    }

    public void RenderAll(RenderTarget target)
    {
        foreach (Entity entity in entities)
        {
            entity.Render(target);
            
        }
        UpdateCoinsGui();
    }
    
    public Texture LoadTexture(string name)
    {
        if (textures.TryGetValue(name, out Texture found))
        {
            return found;
        }
        string fileName = $"assets/{name}.png";
        Texture texture = new Texture(fileName);
        textures.Add(name, texture);
        return texture;
    }
    
    // Scenechange functions
    public void Reload()
    {
        if (doReload)
        {
            Hero.SetCoins(oldCoins);
            nextScene = currentScene;
            doReload = false;
        }
    }

    public void Load(string input)
    {
        nextScene = input;
    }

    void KillCoinsGui()
    {
        foreach (Entity entity in entities)
        {
            if (entity is Gui)
            {
                entity.Dead = true;
            }
        }
    }
    
    void UpdateCoinsGui()
    {
        // Gui code
        KillCoinsGui();
        // Gui code will sadly crash if you get more then 123456788 coins :(
        Gui gui = new(-1, new Vector2f(9, 9));
        List<int> guiDigits = gui.GetGuiDigitsFromNumber(Hero.Coins);
        List<Vector2f> guiOffsets = gui.GetGuiOffsets(Hero.Coins, new Vector2f(27, 9));
        for (int i = 0; i < guiDigits.Count; i++)
        {
            Spawn(new Gui(guiDigits[i], guiOffsets[i]));
        }
        Spawn(gui);
    }
    
    private void HandleSceneChange()
    {
        if (nextScene == null) return;
        oldCoins = Hero.Coins;
        entities.Clear();
        Spawn(new Background());
        
        string file = $"assets/{nextScene}.txt";
        Console.WriteLine($"Loading scene '{file}'");

        foreach (var line in File.ReadLines(file, Encoding.UTF8))
        {
            string parsed = line.Trim();
            
            int commentAt = parsed.IndexOf('#');
            if (commentAt >= 0)
            {
                parsed = parsed.Substring(0, commentAt);
                parsed = parsed.Trim();
            }

            if (parsed.Length == 0)
            {
                continue;
            }
            
            string[] words = parsed.Split(' ');
            string spawnType = words[0];
            float posX = float.Parse(words[1]);
            float posY = float.Parse(words[2]);
            string scene = "";
            if (spawnType == "d")
            {
                scene = words[3];
            }

            switch (spawnType)
            {
                case "w" :
                    Platform platform = new();
                    platform.Position = new Vector2f(posX, posY);
                    Spawn(platform);
                    break;
                case "c":
                    Coin coin = new();
                    coin.Position = new Vector2f(posX, posY);
                    Spawn(coin);
                    break;
                case "d" :
                    Door door = new();
                    door.Position = new Vector2f(posX, posY);
                    door.NextRoom = scene;
                    Spawn(door);
                    break;
                case "k" :
                    Key key = new();
                    key.Position = new Vector2f(posX, posY);
                    Spawn(key);
                    break;
                case "h" :
                    Hero hero = new();
                    hero.Position = new Vector2f(posX, posY);
                    Spawn(hero);
                    break;
            }
        }
        currentScene = nextScene;
        nextScene = null;
    }
    
    // Collision checks
    public bool TryMove(Entity entity, Vector2f movement)
    {
        entity.Position += movement;
        bool collided = false;
        
        for (int i = 0; i < entities.Count; i++)
        {
            Entity other = entities[i];
            if (!other.Solid) continue;
            if (other == entity) continue;
            
            FloatRect boundsA = entity.Bounds;
            FloatRect boundsB = other.Bounds;
            if (Collision.RectangleRectangle(boundsA, boundsB, out Collision.Hit hit))
            {
                entity.Position += hit.Normal * hit.Overlap;
                i = -1;
                collided = true;
            }
        }
        return collided;
    }

    public bool FindByType<T>(out T found) where T : Entity
    {
        foreach (Entity entity in entities)
        {
            if (!entity.Dead && entity is T typed)
            {
                found = typed;
                return true;
            }
        }
        found = default(T);
        return false;
    }
    
    public static bool DoReload
    {
        get => doReload;
        set => doReload = value;
    }
}