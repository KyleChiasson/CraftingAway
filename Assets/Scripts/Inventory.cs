using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : Singleton<Inventory>
{
    [System.Serializable]
    public class Tuple
    {
        public string Identifier;
        public TMP_Text Text;
        public int Amt;
    }
    public Tuple[] Numbers;
    public Dictionary<string, int> Items;
    public void ChangeItemAmount(string _name, int _amt)
    {
        for (int i = 0; i < Numbers.Length; i++)
            if (Numbers[i].Identifier == _name)
            {
                Numbers[i].Amt = Mathf.Clamp(Numbers[i].Amt + _amt, 0, 99);
                Numbers[i].Text.text = (Numbers[i].Amt < 10 ? "0" : "") + Numbers[i].Amt.ToString();
            }
    }
    public int ItemAmount(string _name)
    {
        for (int i = 0; i < Numbers.Length; i++)
            if (Numbers[i].Identifier == _name)
                return Numbers[i].Amt;
        return 0;
    }
    public void ChangeCurrencyAmount(int _amt)
    {
        Currency = Mathf.Clamp(Currency + _amt, 0, 9999);
        CurrencyText.text = (Currency < 10 ? "0" : "") + Currency.ToString();
    }
    public int Currency = 0;
    public TMP_Text CurrencyText;

    public void CraftPaste()
    {
        if(ItemAmount("Rock") > 0 && ItemAmount("Leaf") > 0)
        {
            ChangeItemAmount("Rock", -1);
            ChangeItemAmount("Leaf", -1);
            ChangeItemAmount("Paste", 1);
        }
    }
    public void CraftLever()
    {
        if (ItemAmount("Rock") > 0 && ItemAmount("Stick") > 0)
        {
            ChangeItemAmount("Rock", -1);
            ChangeItemAmount("Stick", -1);
            ChangeItemAmount("Lever", 1);
        }
    }
    public void CraftMedicine()
    {
        if (ItemAmount("Rock") > 0 && ItemAmount("Plant") > 0)
        {
            ChangeItemAmount("Rock", -1);
            ChangeItemAmount("Plant", -1);
            ChangeItemAmount("Medicine", 1);
        }
    }
    public void CraftHammer()
    {
        if (ItemAmount("Rock") > 0 && ItemAmount("Lumber") > 0)
        {
            ChangeItemAmount("Rock", -1);
            ChangeItemAmount("Lumber", -1);
            ChangeItemAmount("Hammer", 1);
        }
    }
    public void CraftBroom()
    {
        if (ItemAmount("Leaf") > 0 && ItemAmount("Stick") > 0)
        {
            ChangeItemAmount("Leaf", -1);
            ChangeItemAmount("Stick", -1);
            ChangeItemAmount("Broom", 1);
        }
    }
    public void CraftWreath()
    {
        if (ItemAmount("Leaf") > 0 && ItemAmount("Ore") > 0)
        {
            ChangeItemAmount("Leaf", -1);
            ChangeItemAmount("Ore", -1);
            ChangeItemAmount("Wreath", 1);
        }
    }
    public void CraftUmbrella()
    {
        if (ItemAmount("Leaf") > 0 && ItemAmount("Lumber") > 0)
        {
            ChangeItemAmount("Leaf", -1);
            ChangeItemAmount("Lumber", -1);
            ChangeItemAmount("Umbrella", 1);
        }
    }
    public void CraftWand()
    {
        if (ItemAmount("Stick") > 0 && ItemAmount("Ore") > 0)
        {
            ChangeItemAmount("Stick", -1);
            ChangeItemAmount("Ore", -1);
            ChangeItemAmount("Wand", 1);
        }
    }
    public void CraftDecorativePlant()
    {
        if (ItemAmount("Stick") > 0 && ItemAmount("Plant") > 0)
        {
            ChangeItemAmount("Stick", -1);
            ChangeItemAmount("Plant", -1);
            ChangeItemAmount("Decorative Plant", 1);
        }
    }
    public void CraftFertilizer()
    {
        if (ItemAmount("Ore") > 0 && ItemAmount("Plant") > 0)
        {
            ChangeItemAmount("Ore", -1);
            ChangeItemAmount("Plant", -1);
            ChangeItemAmount("Fertilizer", 1);
        }
    }
    public void CraftStaff()
    {
        if (ItemAmount("Ore") > 0 && ItemAmount("Lumber") > 0)
        {
            ChangeItemAmount("Ore", -1);
            ChangeItemAmount("Lumber", -1);
            ChangeItemAmount("Staff", 1);
        }
    }
    public void CraftTent()
    {
        if (ItemAmount("Plant") > 0 && ItemAmount("Lumber") > 0)
        {
            ChangeItemAmount("Plant", -1);
            ChangeItemAmount("Lumber", -1);
            ChangeItemAmount("Tent", 1);
        }
    }
}