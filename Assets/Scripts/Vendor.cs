using TMPro;
using UnityEngine.UI;

public class Vendor : Interact
{
    public string[] potentialItems;
    public Image Image;
    public TMP_Text Text;
    public Item ForSale;
    public int Price;
    private new void Update()
    {
        base.Update();
        if ((Price < 0 && Inventory.Instance.Currency + Price <= 0) || (Price > 0 && Inventory.Instance.ItemAmount(ForSale.Name) <= 0))
            InteractNotifier.color = UnityEngine.Color.red;
        else InteractNotifier.color = UnityEngine.Color.white;
    }
    public void SetItem()
    {
        int r = UnityEngine.Random.Range(0, potentialItems.Length);
        ForSale = GameManger.Items[potentialItems[r]];
        Image.sprite = ForSale.Sprite;
        Price = UnityEngine.Random.Range(GameManger.Items[potentialItems[r]].MinCost(), GameManger.Items[potentialItems[r]].MaxCost() + 1);
        Text.text = Price.ToString();
    }
    public override void Interacted()
    {
        if (Price <= 0 && Inventory.Instance.Currency >= Price)
        {
           if(ForSale.Name == "Present")
            {
                GameManger.Instance.Win();
                return;
            }
            Inventory.Instance.ChangeCurrencyAmount(Price);
            Inventory.Instance.ChangeItemAmount(ForSale.Name, 5);
        }
        else if(Price > 0 && Inventory.Instance.ItemAmount(ForSale.Name) >= 1)
        {
            Inventory.Instance.ChangeCurrencyAmount(Price);
            Inventory.Instance.ChangeItemAmount(ForSale.Name, -1);
        }
    }
}