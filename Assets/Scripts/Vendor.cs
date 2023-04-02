using System;
using TMPro;
using UnityEngine.UI;

public class Vendor : Interact
{
    public Item[] potentialItems;
    public bool Sell;
    public Image Image;
    public TMP_Text Text;
    public Item ForSale;
    public int Price;
    private void Awake()
    {
        UnityEngine.Random.InitState(DateTime.Now.Minute + DateTime.Now.Second + DateTime.Now.Millisecond);
    }
    public void SetItem()
    {
        float r = UnityEngine.Random.Range(0f, 1f);
        int i = 0;
        while (r > potentialItems[i].Chance && i < potentialItems.Length - 1)
        {
            r -= potentialItems[i].Chance;
            i++;
        }
        ForSale = potentialItems[i];
        Image.sprite = ForSale.Sprite;
        Price = UnityEngine.Random.Range(potentialItems[i].Min, potentialItems[i].Max + 1);
        Text.text = ((Sell ? -1 : 1) * Price).ToString();
    }
    public override void Interacted()
    {
        if (Sell)
        {
            if(Inventory.Instance.Currency >= Price)
            {
                if(ForSale.name == "Present")
                    GameManger.Instance.Win();
                else
                {
                    Inventory.Instance.ChangeCurrencyAmount(-Price);
                    Inventory.Instance.ChangeItemAmount(ForSale.Name, 5);
                }
            }
        }
        else
        {
            if (Inventory.Instance.ItemAmount(ForSale.Name) >= 1)
            {
                Inventory.Instance.ChangeCurrencyAmount(Price);
                Inventory.Instance.ChangeItemAmount(ForSale.Name, -1);
            }
        }
    }
}