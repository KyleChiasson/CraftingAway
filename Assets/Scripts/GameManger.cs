using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManger : Singleton<GameManger>
{
    public static Dictionary<string, Item> Items { get; private set; } = new Dictionary<string, Item>();
    private new void Awake()
    {
        base.Awake();
        Items.Add("Axe", new BoughtItem()
        {
            Name = "Axe",
            Cost = 15,
            Sprite = Resources.Load<Sprite>("Sprites/Items/Axe"),
        });
        Items.Add("Pickaxe", new BoughtItem()
        {
            Name = "Pickaxe",
            Cost = 35,
            Sprite = Resources.Load<Sprite>("Sprites/Items/Pickaxe"),
        });
        Items.Add("Present", new BoughtItem()
        {
            Name = "Present",
            Cost = 500,
            Sprite = Resources.Load<Sprite>("Sprites/Items/Present"),
        });
        Items.Add("Shovel", new BoughtItem()
        {
            Name = "Shovel",
            Cost = 25,
            Sprite = Resources.Load<Sprite>("Sprites/Items/Shovel"),
        });
        Items.Add("Leaf", new ResourceItem()
        {
            Name = "Leaf",
            Cost = 2,
            Sprite = Resources.Load<Sprite>("Sprites/Items/Leaf"),
            RequiredItem = null,
        });
        Items.Add("Lumber", new ResourceItem()
        {
            Name = "Lumber",
            Cost = 4,
            Sprite = Resources.Load<Sprite>("Sprites/Items/Lumber"),
            RequiredItem = Items["Axe"],
        });
        Items.Add("Ore", new ResourceItem()
        {
            Name = "Ore",
            Cost = 8,
            Sprite = Resources.Load<Sprite>("Sprites/Items/Ore"),
            RequiredItem = Items["Pickaxe"],
        });
        Items.Add("Plant", new ResourceItem()
        {
            Name = "Plant",
            Cost = 6,
            Sprite = Resources.Load<Sprite>("Sprites/Items/Plant"),
            RequiredItem = Items["Shovel"],
        });
        Items.Add("Rock", new ResourceItem()
        {
            Name = "Rock",
            Cost = 3,
            Sprite = Resources.Load<Sprite>("Sprites/Items/Rock"),
            RequiredItem = null,
        });
        Items.Add("Stick", new ResourceItem()
        {
            Name = "Stick",
            Cost = 1,
            Sprite = Resources.Load<Sprite>("Sprites/Items/Stick"),
            RequiredItem = null,
        });
        Items.Add("Broom", new CraftedItem()
        {
            Name = "Broom",
            ItemsUsed = new Item[] { Items["Leaf"], Items["Stick"] },
            Sprite = Resources.Load<Sprite>("Sprites/Items/Broom"),
        });
        Items.Add("Decorative Plant", new CraftedItem()
        {
            Name = "Decorative Plant",
            ItemsUsed = new Item[] { Items["Stick"], Items["Plant"] },
            Sprite = Resources.Load<Sprite>("Sprites/Items/Decorative Plant"),
        });
        Items.Add("Fertilizer", new CraftedItem()
        {
            Name = "Fertilizer",
            ItemsUsed = new Item[] { Items["Ore"], Items["Plant"] },
            Sprite = Resources.Load<Sprite>("Sprites/Items/Fertilizer"),
        });
        Items.Add("Hammer", new CraftedItem()
        {
            Name = "Hammer",
            ItemsUsed = new Item[] { Items["Lumber"], Items["Rock"] },
            Sprite = Resources.Load<Sprite>("Sprites/Items/Hammer"),
        });
        Items.Add("Lever", new CraftedItem()
        {
            Name = "Lever",
            ItemsUsed = new Item[] { Items["Stick"], Items["Rock"] },
            Sprite = Resources.Load<Sprite>("Sprites/Items/Lever"),
        });
        Items.Add("Medicine", new CraftedItem()
        {
            Name = "Medicine",
            ItemsUsed = new Item[] { Items["Plant"], Items["Rock"] },
            Sprite = Resources.Load<Sprite>("Sprites/Items/Medicine"),
        });
        Items.Add("Paste", new CraftedItem()
        {
            Name = "Paste",
            ItemsUsed = new Item[] { Items["Leaf"], Items["Rock"] },
            Sprite = Resources.Load<Sprite>("Sprites/Items/Paste"),
        });
        Items.Add("Staff", new CraftedItem()
        {
            Name = "Staff",
            ItemsUsed = new Item[] { Items["Lumber"], Items["Ore"] },
            Sprite = Resources.Load<Sprite>("Sprites/Items/Staff"),
        });
        Items.Add("Tent", new CraftedItem()
        {
            Name = "Tent",
            ItemsUsed = new Item[] { Items["Lumber"], Items["Plant"] },
            Sprite = Resources.Load<Sprite>("Sprites/Items/Tent"),
        });
        Items.Add("Umbrella", new CraftedItem()
        {
            Name = "Umbrella",
            ItemsUsed = new Item[] { Items["Lumber"], Items["Leaf"] },
            Sprite = Resources.Load<Sprite>("Sprites/Items/Umbrella"),
        });
        Items.Add("Wand", new CraftedItem()
        {
            Name = "Wand",
            ItemsUsed = new Item[] { Items["Stick"], Items["Ore"] },
            Sprite = Resources.Load<Sprite>("Sprites/Items/Wand"),
        });
        Items.Add("Wreath", new CraftedItem()
        {
            Name = "Wreath",
            ItemsUsed = new Item[] { Items["Leaf"], Items["Ore"] },
            Sprite = Resources.Load<Sprite>("Sprites/Items/Wreath"),
        });
    }

    public GameObject Woods;
    public GameObject Town;
    public GameObject Home;
    public GameObject ResourcesPrefab;
    public Transform ResourcesParent;
    public TMP_Text TimeText;
    public GameObject Timer;
    public GameObject PassButton;
    public Vendor[] Vendors;
    private enum Scene { NULL = 0, Woods = 1, Home = 2, Town = 3}
    private Scene currentScene = 0;
    public void ChangeScene()
    {
        CharacterControler.Instance.transform.SetPositionAndRotation(Vector3.zero, Quaternion.identity);
        if(currentScene == Scene.Woods)
        {
            Woods.SetActive(false);
            Destroy(ResourcesParent.GetChild(0).gameObject);
            Timer.SetActive(false);
            PassButton.SetActive(true);
        }
        else if(currentScene == Scene.Home)
        {
            Home.SetActive(false);
        }
        else if (currentScene == Scene.Town)
        {
            Town.SetActive(false);
        }
        //
        if (currentScene == Scene.Woods)
        {
            currentScene = Scene.Home;
            Home.SetActive(true);
        }
        else if (currentScene == Scene.Home)
        {
            currentScene = Scene.Town;
            foreach (Vendor v in Vendors)
                v.SetItem();
            Town.SetActive(true);
        }
        else
        {
            PassButton.SetActive(false);
            Timer.SetActive(true);
            currentScene = Scene.Woods;
            Instantiate(ResourcesPrefab, ResourcesParent);
            time = 60f;
            Woods.SetActive(true);
        }
    }
    public void Start() { UnityEngine.Random.InitState(DateTime.Now.Minute + DateTime.Now.Second + DateTime.Now.Millisecond); }
    private float time;
    private void Update()
    {
        if(currentScene == Scene.Woods)
        {
            if (time<=0)
                ChangeScene();
            else
            {
                time -= Time.deltaTime;
                TimeText.text = Mathf.FloorToInt(time / 60) + ":" + Mathf.FloorToInt(time - time / 60);
            }
        }
    }
    public GameObject End;
    public GameObject StartPanel;
    public void Win() { End.SetActive(true); }
    public void Quit() { Application.Quit(); }
    public void StartGame() 
    { 
        ChangeScene();
        StartPanel.SetActive(false);
    }
}