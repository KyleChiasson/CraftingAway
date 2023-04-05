using System.Collections.Generic;
using UnityEngine;
public abstract class Item
{
    public string Name;
    public abstract int MinCost();
    public abstract int MaxCost();
    public Sprite Sprite;
}
public class ResourceItem : Item
{
    public int Cost;
    public Item RequiredItem;
    public override int MinCost() { return Cost; }
    public override int MaxCost() { return Mathf.CeilToInt(Cost * 1.5f); }
}
public class CraftedItem : Item
{
    public Item[] ItemsUsed;
    public override int MinCost()
    {
        int cost = 0;
        for (int i = 0; i < ItemsUsed.Length; i++)
            cost += ItemsUsed[i].MinCost();
        return Mathf.CeilToInt(cost * 1.5f);
    }
    public override int MaxCost()
    {
        int cost = 0;
        for (int i = 0; i < ItemsUsed.Length; i++)
            cost += ItemsUsed[i].MaxCost();
        return Mathf.CeilToInt(cost * 1.5f);
    }
}
public class BoughtItem : Item
{
    public int Cost;
    public override int MinCost() { return -1 * Cost; }
    public override int MaxCost() { return -1 * Mathf.CeilToInt(Cost * 1.5f); }
}